
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { TacticsEveryTick } from '../../Tactics/Lobby';
import { CreateBlip, ShowCursor, CreatePed, GetCursorStatus, DrawText, vnxDestroyAllCEF } from './index';
import { KeyUp, KeyDown } from '../Scoreboard';
import { BasicKeyBinds } from '../../preload/login';
import { OnInventoryKeyPressed } from '../../Reallife/inventory';
import { XMENU_KEY, OnXKeyUp, OnXKeyDown } from '../../Reallife/xmenu';
import { OnVoiceKeyDown, OnVoiceKeyUp } from '../Sync';
import { interpolateCamera, destroyCamera } from './camera';
export let PLAYER_LOBBY_MAIN = "Lobby";
export let PLAYER_LOBBY_REALLIFE = "Reallife";
export let PLAYER_LOBBY_ZOMBIES = "Zombies";
export let PLAYER_LOBBY_TACTICS = "Tactics";
export let PLAYER_LOBBY_7TOWERS = "Seven-Towers";

let CurrentLobby = PLAYER_LOBBY_MAIN;
let LocalPlayer = alt.Player.local;


let CURSOR_KEY = 18;


export function GetCurrentLobby() { try { return CurrentLobby; } catch{ } }
export function FreezeClient(bool) { try { game.freezeEntityPosition(alt.Player.local.scriptID, bool); } catch{ } }
export function SetEntityAlpha(Entity, alpha) { try { game.setEntityAlpha(Entity.scriptID, alpha, true); } catch{ } }

alt.onServer("Player:ChangeCurrentLobby", (Lobby) => { try { CurrentLobby = Lobby; } catch{ } });



//////////////////////////////////////////////////////////////////////////////////////////
alt.onServer('Player:Freeze', (bool) => {
    try {
        game.freezeEntityPosition(LocalPlayer.scriptID, bool);
    }
    catch{ }
});

alt.onServer('Player:Spawn', () => {
    try {
        game.displayHud(true);
    }
    catch{ }
});

alt.onServer('Vehicle:Freeze', (veh, bool) => {
    try {
        game.freezeEntityPosition(veh.scriptID, bool);
    }
    catch{ }
});
alt.onServer('Vehicle:Godmode', (veh, bool) => {
    try {
        game.setEntityInvincible(veh.scriptID, bool);
    }
    catch{ }
});
alt.onServer('Vehicle:Repair', (veh) => {
    try {
        game.setVehicleFixed(veh.scriptID);
    }
    catch{ }
});

let CalledToSpawn = false;
alt.onServer("movecamtocurrentpos_client", () => {
    try {
        moveFromToAir(alt.Player.local, 'up', 1, false);
        FreezeClient(true);

        alt.setTimeout(() => {
            if (CalledToSpawn) { return; }
            alt.emitServer('load_data_login');
            CalledToSpawn = true;
            ShowCursor(false);
        }, 6000);

        alt.setTimeout(() => {
            moveFromToAir(alt.Player.local, 'down');
            alt.setTimeout(() => {
                FreezeClient(false);
                alt.setTimeout(() => {
                    CalledToSpawn = false;
                }, 5000);
            }, 8000);
        }, 8000);
    }
    catch{ }
});

let BlipList = {};
let BlipC = 0;
alt.onServer("BlipClass:CreateBlip", (BlipJson) => {
    try {
        let Blip = JSON.parse(BlipJson);
        for (let i = 0; i < Blip.length; i++) {
            let data_blip = Blip[i];
            //alt.log("Datas : " + data_blip.Name + " | " + [data_blip.posX, data_blip.posY, data_blip.posZ] + " | " + data_blip.Sprite + " | " + data_blip.Color + " | " + data_blip.ShortRange);
            let cBlip = CreateBlip(data_blip.Name, [data_blip.posX, data_blip.posY, data_blip.posZ], data_blip.Sprite, data_blip.Color, data_blip.ShortRange);
            BlipList[BlipC++] = {
                Entity: cBlip,
                Name: data_blip.Name,
                X: data_blip.posX,
                Y: data_blip.posY,
                Z: data_blip.posZ
            };
        }
    }
    catch{ }
});

alt.onServer('BlipClass:RemoveBlip', (Name) => {
    for (var c_ in BlipList) {
        if (BlipList[c_].Name == Name) {
            //game.deleteObject(BlipList[c_].Entity);
            game.removeBlip(BlipList[c_].Entity);
            alt.log("Remove Blip : " + Name);
            BlipList.splice(c_, 1);
        }
    }
});

alt.onServer("Clothes:Reset", () => {
    try {
        game.setPedDefaultComponentVariation(LocalPlayer.scriptID);
    }
    catch{ }
});


alt.onServer("Clothes:Load", (clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedComponentVariation(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture);
    }
    catch{ }
});

alt.onServer("Prop:Load", (clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedPropIndex(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture, true);
    }
    catch{ }
});

alt.onServer("Accessories:Load", (clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedPreloadVariationData(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture);
    }
    catch{ }
});

alt.onServer('Sync:CreateNPC', (PedJson) => {
    try {
        CreatePed();
    }
    catch{ }
});

//////////////////////////////////////////////////////////////////////////////////////////


alt.onServer('Player:Visible', (bool) => {
    try {
        game.setEntityVisible(LocalPlayer.scriptID, bool, 0);
    }
    catch{ }
});
alt.onServer('Player:SetWaypoint', (X, Y) => {
    try {
        game.setNewWaypoint(X, Y);
    }
    catch{ }
});
alt.onServer('Player:Alpha', (alpha) => {
    try {
        game.setEntityAlpha(Entity.scriptID, alpha, true);
    }
    catch{ }
});

alt.onServer('Player:WarpIntoVehicle', (veh, seat) => {
    try {
        alt.setTimeout(() => {
            game.taskWarpPedIntoVehicle(LocalPlayer.scriptID, veh.scriptID, seat);
            if (!LocalPlayer.vehicle) {
                alt.setTimeout(() => {
                    game.taskWarpPedIntoVehicle(LocalPlayer.scriptID, veh.scriptID, seat);
                    if (!LocalPlayer.vehicle) {
                        game.taskWarpPedIntoVehicle(LocalPlayer.scriptID, veh.scriptID, seat);
                    }
                }, 500);
            }
        }, 500);
    }
    catch{ }
});

alt.onServer('Player:WarpOutOfVehicle', () => {
    try {
        if (LocalPlayer.vehicle) {
            game.taskLeaveVehicle(alt.Player.local.scriptID, LocalPlayer.vehicle.scriptID, 16);
        }
    }
    catch{ }
});

alt.onServer('start_screen_fx', (effectName, duration, looped) => {
    try {
        game.animpostfxPlay(effectName, duration, looped);
    }
    catch{ }
});

alt.onServer('Vehicle:DisableEngineToggle', state => {
    game.setVehicleEngineOn(LocalPlayer.vehicle.scriptID, state, true, state);
    alt.log('Called DisableEngineToggle');
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
    }
    catch{ }
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
    }
    catch{ }
});


alt.onServer('delay_element_data', (e, v, type, ms) => {
    try {
        let requesteddata = undefined;
        if (type == "bool") {
            requesteddata = "Store_Delayed_Element_Data_BOOL";
        }
        else if (type == "int") {
            requesteddata = "Store_Delayed_Element_Data_INT";
        }
        else if (type == "string") {
            requesteddata = "Store_Delayed_Element_Data_STRING";
        }
        if (requesteddata != undefined) {
            alt.setTimeout(function () {
                alt.emitServer(requesteddata, e, v);
            }, ms);
        }
    }
    catch{ }
});

let CameraCreated = false;
alt.onServer('Player:CreateCameraMovement', (pos1X, pos1Y, pos1Z, rot1, pos2X, pos2Y, pos2Z, rot2, duration) => {
    try {
        if (CameraCreated) { destroyCamera(); }
        interpolateCamera(pos1X, pos1Y, pos1Z, rot1, 0, pos2X, pos2Y, pos2Z, rot2, 0, duration);
        CameraCreated = true;
    }
    catch{ }
});

alt.onServer('Player:DestroyCamera', () => {
    try {
        if (CameraCreated) { destroyCamera(); }
    }
    catch{ }
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

function OnTacticsTick() {
    TacticsEveryTick();
}
let TickEvent;
let Gamemodes = {
    Reallife: 0,
    Zombies: 1,
    Tactics: 2,
    Race: 3,
    SevenTowers: 4
};
alt.onServer('Preload:LoadTickEvents', (GamemodeId) => {
    if (TickEvent) { alt.clearEveryTick(TickEvent); TickEvent = null; }
    switch (GamemodeId) {
        case Gamemodes.Tactics:
            TickEvent = alt.everyTick(() => {
                OnTacticsTick();
            });
            break;
    };

});

alt.setInterval(() => {
    game.setEntityProofs(alt.Player.local.scriptID, true, false, false, false, false, false, false, false);
}, 1000);




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
                game.switchOutPlayer(player.scriptID, 0, parseInt(switchType));
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
    }
    catch{ }
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
    }
    catch{ }
}



var area = {};
alt.onServer('AreaBlip:Create', (name, x, y, z, r, c, r2) => {
    if (area[name] != null) {
        game.removeBlip(area[name]);
    }
    area[name] = game.addBlipForRadius(x, y, z, r);
    game.setBlipSprite(area[name], 5);
    game.setBlipAlpha(area[name], 150);
    game.setBlipColour(area[name], c);
    game.setBlipRotation(area[name], r2);
});

alt.onServer('NPC:Create', (PedName, Vector3Pos, rot) => {
    CreatePed(PedName, Vector3Pos, rot)
});

alt.on("disconnect", () => {
    vnxDestroyAllCEF();
});