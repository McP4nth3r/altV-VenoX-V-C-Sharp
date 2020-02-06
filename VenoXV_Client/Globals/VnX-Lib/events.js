
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { TacticsEveryTick } from '../../Tactics/VenoXV/Lobby';
import { OnCameraEveryTick } from './camera';
import { DrawText, CreateBlip } from './index';
import { dxLibaryEveryTick } from './dxClass';
import { RenderHitMarker } from '../Notification';
import { RenderTacho } from '../Anzeigen/tacho';
import { KeyUp, KeyDown } from '../Scoreboard';
export let PLAYER_LOBBY_MAIN = "Lobby";
export let PLAYER_LOBBY_REALLIFE = "Reallife";
export let PLAYER_LOBBY_ZOMBIES = "Zombies";
export let PLAYER_LOBBY_TACTICS = "Tactics";
export let PLAYER_LOBBY_7TOWERS = "Seven-Towers";


let CurrentLobby = PLAYER_LOBBY_REALLIFE;

export function GetCurrentLobby() { return CurrentLobby; }
alt.onServer("Player:ChangeCurrentLobby", (Lobby) => { CurrentLobby = Lobby; });



//////////////////////////////////////////////////////////////////////////////////////////
alt.onServer('FreezePlayerPLAYER_VnX', (bool) => {
    game.freezeEntityPosition(alt.Player.local.scriptID, bool);
});

alt.onServer("movecamtocurrentpos_client", () => {
    let executedcmd = false;
    game.switchOutPlayer(alt.Player.local.scriptID);
    game.freezeEntityPosition(alt.Player.local.scriptID, true);
    alt.setTimeout(() => {
        if (executedcmd == false) {
            alt.emitServer('load_data_login');
            game.setEntityAlpha(alt.Player.local.scriptID, 255);
            executedcmd = true;
        }
    }, 6000);

    alt.setTimeout(() => {
        game.switchInPlayer(alt.Player.local.scriptID);
        alt.setTimeout(() => {
            game.freezeEntityPosition(alt.Player.local.scriptID, false);
        }, 8000);
    }, 8000);
});

alt.onServer("BlipClass:CreateBlip", (BlipJson) => {
    let Blip = JSON.parse(BlipJson);
    for (let i = 0; i < Blip.length; i++) {
        let data_blip = Blip[i];
        //alt.log("Datas : " + data_blip.Name + " | " + [data_blip.posX, data_blip.posY, data_blip.posZ] + " | " + data_blip.Sprite + " | " + data_blip.Color + " | " + data_blip.ShortRange);
        CreateBlip(data_blip.Name, [data_blip.posX, data_blip.posY, data_blip.posZ], data_blip.Sprite, data_blip.Color, data_blip.ShortRange);
    }
});

alt.onServer("Clothes:Load", (clothesslot, clothesdrawable, clothestexture) => {
    game.setPedPreloadVariationData(alt.Player.local, clothesslot, clothesdrawable, clothestexture);
    alt.log
});

alt.onServer("Accessories:Load", (clothesslot, clothesdrawable, clothestexture) => {
    game.setPedPreloadVariationData(alt.Player.local, clothesslot, clothesdrawable, clothestexture);
});

//////////////////////////////////////////////////////////////////////////////////////////


alt.onServer('Player:Visible', (bool) => {
    game.setEntityVisible(alt.Player.local.scriptID, bool, 0);
    alt.log("Invisible = " + bool);
});


alt.on('keyup', (key) => {
    KeyUp(key);
});

alt.on('keydown', (key) => {
    KeyDown(key);
});

//////////////////////////////////////////////////////////////////////////////////////////





let lastFrameCount = game.getFrameCount();
let CurrentFPS = 0;

alt.setInterval(() => {
    CurrentFPS = game.getFrameCount() - lastFrameCount;
    lastFrameCount = game.getFrameCount();
}, 1000);

function DrawGlobalHUD() {
    DrawText(CurrentFPS.toString(), [0.99, 0.002], [0.5, 0.5], 0, [0, 105, 145, 200], true, true);
}

alt.everyTick(() => {
    DrawGlobalHUD();
    TacticsEveryTick();
    dxLibaryEveryTick();
    OnCameraEveryTick();
    RenderHitMarker();
    RenderTacho();
});

//////////////////////////////////////////////////////////////////////////////////////////
