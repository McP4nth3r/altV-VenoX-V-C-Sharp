//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import {
    CreateBlip,
    ShowCursor,
    CreatePed,
    GetCursorStatus,
    DrawText,
    vnxDestroyAllCEF
} from './index';
import {
    KeyUp,
    KeyDown
} from '../Scoreboard';
import {
    BasicKeyBinds
} from '../../preload/login';
import {
    OnInventoryKeyPressed
} from '../../Reallife/inventory';
import {
    XMENU_KEY,
    OnXKeyUp,
    OnXKeyDown
} from '../../Reallife/xmenu';
import {
    OnVoiceKeyDown,
    OnVoiceKeyUp
} from '../Sync';
import {
    interpolateCamera,
    destroyCamera
} from './camera';
import {
    GetFemaleTorsoLists,
    GetMaleTorsoLists
} from './assets';
export let PLAYER_LOBBY_MAIN = "Lobby";
export let PLAYER_LOBBY_REALLIFE = "Reallife";
export let PLAYER_LOBBY_ZOMBIES = "Zombies";
export let PLAYER_LOBBY_TACTICS = "Tactics";
export let PLAYER_LOBBY_7TOWERS = "Seven-Towers";
export let PLAYER_LOBBY_DERBY = "Derby";


let CurrentLobby = PLAYER_LOBBY_MAIN;
let LocalPlayer = alt.Player.local;


let CURSOR_KEY = 18;


export function GetCurrentLobby() {
    try {
        return CurrentLobby;
    } catch {}
}
export function FreezeClient(bool) {
    try {
        game.freezeEntityPosition(LocalPlayer.scriptID, bool);
    } catch {}
}
export function SetEntityAlpha(Entity, alpha) {
    try {
        game.setEntityAlpha(Entity.scriptID, alpha, true);
    } catch {}
}

alt.onServer("Player:ChangeCurrentLobby", (Lobby) => {
    try {
        CurrentLobby = Lobby;
    } catch {}
});



//////////////////////////////////////////////////////////////////////////////////////////
alt.onServer('Player:Freeze', (bool) => {
    try {
        game.freezeEntityPosition(LocalPlayer.scriptID, bool);
    } catch {}
});
alt.onServer('Player:FreezeAfterMS', (MS, bool) => {
    try {
        alt.setTimeout(() => {
            game.freezeEntityPosition(LocalPlayer.scriptID, bool);
        }, MS);
    } catch {}
});


alt.onServer('Player:Spawn', () => {
    try {
        game.displayHud(true);
        game.clearPedBloodDamage(LocalPlayer.scriptID);
    } catch {}
});

alt.onServer('Vehicle:Freeze', (veh, bool) => {
    try {
        game.freezeEntityPosition(veh.scriptID, bool);
    } catch {}
});
alt.onServer('Vehicle:Godmode', (veh, bool) => {
    try {
        game.setEntityInvincible(veh.scriptID, bool);
    } catch {}
});
alt.onServer('Vehicle:Repair', (veh) => {
    try {
        game.setVehicleFixed(veh.scriptID);
    } catch {}
});

let CalledToSpawn = false;
alt.onServer("movecamtocurrentpos_client", () => {
    try {
        moveFromToAir(LocalPlayer, 'up', 1, false);
        FreezeClient(true);

        alt.setTimeout(() => {
            if (CalledToSpawn) {
                return;
            }
            alt.emitServer('load_data_login');
            CalledToSpawn = true;
            ShowCursor(false);
            alt.setTimeout(() => {
                moveFromToAir(LocalPlayer, 'down');
                CalledToSpawn = false;
            }, 8000);
        }, 6000);
    } catch {}
});

let BlipList = {};
alt.onServer("BlipClass:CreateBlip", (ID, Name, X, Y, Z, Sprite, Color, ShortRange) => {
    try {
        if (BlipList[ID]) return;
        let cBlip = CreateBlip(Name, [X, Y, Z], Sprite, Color, ShortRange);
        BlipList[ID] = {
            ID: ID,
            Entity: cBlip,
            Name: Name,
            X: X,
            Y: Y,
            Z: Z,
            Sprite: Sprite,
            Color: Color,
            ShortRange: ShortRange
        };
    } catch {}
});

alt.onServer('BlipClass:RemoveBlip', (ID) => {
    if (BlipList[ID] != null) {
        game.removeBlip(BlipList[ID].Entity);
        delete BlipList[ID];
    }
});

alt.onServer('BlipClass:RemoveAllBlips', () => {
    for (var _c in BlipList) {
        if (BlipList[_c].Entity != null) game.removeBlip(BlipList[_c].Entity);
        delete BlipList[_c];
    }
});


alt.onServer("Clothes:Reset", () => {
    try {
        game.setPedDefaultComponentVariation(LocalPlayer.scriptID);
    } catch {}
});


const torsoDataMale = GetMaleTorsoLists();
const torsoDataFemale = GetFemaleTorsoLists();
const freemodeModels = [parseInt(game.getHashKey("mp_m_freemode_01")), parseInt(game.getHashKey("mp_f_freemode_01"))];
alt.onServer("Clothes:Load", (slot, drawable, texture) => {
    if (slot == 11) {
        drawable = Number(drawable);
        texture = Number(texture);
        if (isNaN(drawable) || isNaN(texture)) {
            alt.log("SYNTAX: [drawable] [texture]");
        } else {
            if (alt.Player.local.model == freemodeModels[0]) {
                // male
                if (torsoDataMale[drawable] === undefined || torsoDataMale[drawable][texture] === undefined) {
                    alt.log("Invalid top drawable/texture.");
                } else {
                    game.setPedComponentVariation(LocalPlayer.scriptID, 11, drawable, texture, 2);
                    if (torsoDataMale[drawable][texture].BestTorsoDrawable != -1) game.setPedComponentVariation(LocalPlayer.scriptID, torsoDataMale[drawable][texture].BestTorsoDrawable, torsoDataMale[drawable][texture].BestTorsoTexture, 2);
                }
            } else {
                // female
                if (torsoDataFemale[drawable] === undefined || torsoDataFemale[drawable][texture] === undefined) {
                    alt.log("Invalid top drawable/texture.");
                } else {
                    game.setPedComponentVariation(LocalPlayer.scriptID, 11, drawable, texture, 2);
                    if (torsoDataFemale[drawable][texture].BestTorsoDrawable != -1) game.setPedComponentVariation(LocalPlayer.scriptID, torsoDataFemale[drawable][texture].BestTorsoDrawable, torsoDataFemale[drawable][texture].BestTorsoTexture, 2);
                }
            }
        }
    } else {
        game.setPedComponentVariation(LocalPlayer.scriptID, slot, drawable, texture, 0);
    }
});

alt.onServer("Prop:Load", (clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedPropIndex(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture, true);
    } catch {}
});

alt.onServer("Accessories:Load", (clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedPreloadVariationData(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture);
    } catch {}
});

alt.onServer('Sync:CreateNPC', (PedJson) => {
    try {
        CreatePed();
    } catch {}
});

//////////////////////////////////////////////////////////////////////////////////////////


alt.onServer('Player:Visible', (bool) => {
    try {
        game.setEntityVisible(LocalPlayer.scriptID, bool, 0);
    } catch {}
});

alt.onServer('Player:DefaultComponentVariation', () => {
    game.setPedDefaultComponentVariation(LocalPlayer.scriptID);
});

alt.onServer('Player:SetWaypoint', (X, Y) => {
    try {
        game.setNewWaypoint(X, Y);
    } catch {}
});
alt.onServer('Player:Alpha', (alpha) => {
    try {
        game.setEntityAlpha(LocalPlayer.scriptID, alpha, true);
    } catch {}
});

alt.onServer('Player:WarpIntoVehicle', (veh, seat) => {
    if (!veh) return;
    if (!(veh instanceof alt.Vehicle)) return;
    const interval = alt.setInterval(() => {
        if (!veh.valid || veh.scriptID <= 0) return;
        game.taskWarpPedIntoVehicle(LocalPlayer.scriptID, veh.scriptID, seat);
        alt.clearInterval(interval);
    }, 10);
});

alt.onServer('Player:WarpOutOfVehicle', () => {
    try {
        if (LocalPlayer.vehicle) {
            game.taskLeaveVehicle(alt.Player.local.scriptID, LocalPlayer.vehicle.scriptID, 16);
        }
    } catch {}
});

alt.onServer('Player:LoadIPL', (IPL) => {
    try {
        if (!game.isIplActive(IPL)) game.requestIpl(IPL);
    } catch {}
});

alt.onServer('start_screen_fx', (effectName, duration, looped) => {
    try {
        game.animpostfxPlay(effectName, duration, looped);
    } catch {}
});

alt.onServer('Vehicle:DisableEngineToggle', state => {
    try {
        game.setVehicleEngineOn(LocalPlayer.vehicle.scriptID, state, true, state);
    } catch {}
});

alt.on('keyup', (key) => {
    try {
        KeyUp(key);
        //OnTacticsSpectatorKeyUp(key);
        OnVoiceKeyUp(key);
        switch (key) {
            case XMENU_KEY:
                OnXKeyUp();
                break;
            case CURSOR_KEY || 17:
                ShowCursor(!GetCursorStatus());
                break;
        }
    } catch {}
});

alt.on('keydown', (key) => {
    try {
        OnInventoryKeyPressed(key);
        KeyDown(key);
        BasicKeyBinds(key);
        //onTacticsSpectatorKeyDown(key);
        OnVoiceKeyDown(key);
        switch (key) {
            case XMENU_KEY:
                OnXKeyDown();
                break;
        }
    } catch {}
});


alt.onServer('delay_element_data', (e, v, type, ms) => {
    try {
        let requesteddata = undefined;
        if (type == "bool") {
            requesteddata = "Store_Delayed_Element_Data_BOOL";
        } else if (type == "int") {
            requesteddata = "Store_Delayed_Element_Data_INT";
        } else if (type == "string") {
            requesteddata = "Store_Delayed_Element_Data_STRING";
        }
        if (requesteddata != undefined) {
            alt.setTimeout(function () {
                alt.emitServer(requesteddata, e, v);
            }, ms);
        }
    } catch {}
});

let CameraCreated = false;
alt.onServer('Player:CreateCameraMovement', (pos1X, pos1Y, pos1Z, rot1, pos2X, pos2Y, pos2Z, rot2, duration) => {
    try {
        if (CameraCreated) destroyCamera();
        interpolateCamera(pos1X, pos1Y, pos1Z, rot1, 0, pos2X, pos2Y, pos2Z, rot2, 0, duration);
        CameraCreated = true;
    } catch {}
});

alt.onServer('Player:DestroyCamera', () => {
    try {
        if (CameraCreated) destroyCamera();
    } catch {}
});

//////////////////////////////////////////////////////////////////////////////////////////
/*
let lastFrameCount = game.getFrameCount();
let CurrentFPS = 0;

alt.setInterval(() => {
    CurrentFPS = game.getFrameCount() - lastFrameCount;
    lastFrameCount = game.getFrameCount();
}, 2000);

function DrawGlobalHUD() {
    DrawText(CurrentFPS.toString(), [0.99, 0.001], [0.5, 0.5], 0, [0, 105, 145, 200], true, true);
}

DrawGlobalHUD();
dxLibaryEveryTick();
OnCameraEveryTick();

*/


//////////////////////////////////////////////////////////////////////////////////////////
let gui = 'true';

function moveFromToAir(player, moveTo, switchType, showGui) {
    try {
        switch (moveTo) {
            case 'up':
                if (showGui == false) {
                    //mp.gui.chat.show(showGui);
                    gui = 'false';
                };
                game.switchOutPlayer(player.scriptID, 0, switchType);
                break;
            case 'down':
                if (gui == 'false') {
                    checkCamInAir();
                };
                game.switchInPlayer(player.scriptID);
                SetEntityAlpha(player.scriptID, 255);
                break;

            default:
                break;
        }
    } catch {}
}

function checkCamInAir() {
    try {
        if (game.isPlayerSwitchInProgress()) {
            alt.setTimeout(() => {
                checkCamInAir();
            }, 400);
        } else {
            //mp.gui.chat.show(true);
            gui = 'true';
        }
    } catch {}
}



var area = {};
alt.onServer('AreaBlip:Create', (name, x, y, z, r, c, r2) => {
    try {
        if (area[name] != null) {
            game.removeBlip(area[name]);
        }
        area[name] = game.addBlipForRadius(x, y, z, r);
        game.setBlipSprite(area[name], 5);
        game.setBlipAlpha(area[name], 150);
        game.setBlipColour(area[name], c);
        game.setBlipRotation(area[name], r2);
    } catch {}
});

alt.onServer('NPC:Create', (PedName, Vector3Pos, rot) => {
    try {
        CreatePed(PedName, Vector3Pos, rot);
    } catch {}
});

alt.onServer('OnPlayerEnterVehicle', (ms) => {
    alt.setTimeout(() => {
        alt.emitServer('OnPlayerEnterVehicleCall');
    }, ms);
});

alt.on("disconnect", () => {
    vnxDestroyAllCEF();
});

alt.onServer('Admin:ShootTest', (Position1, Position2, damage, WeaponHash, Owner, audible, invisible, speed) => {
    let hash = parseInt(game.getHashKey(WeaponHash));
    game.shootSingleBulletBetweenCoords(Position1.x, Position1.y, Position1.z, Position2.x, Position2.y, Position2.z, damage, true, hash, Owner.scriptID, audible, invisible, speed);
    alt.log("Called SingleBullet");
});