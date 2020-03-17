
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { TacticsEveryTick } from '../../Tactics/VenoXV/Lobby';
import { OnCameraEveryTick } from './camera';
import { DrawText, Draw3DText, CreateBlip } from './index';
import { dxLibaryEveryTick } from './dxClass';
import { RenderHitMarker } from '../Notification';
import { RenderTacho } from '../Anzeigen/tacho';
import { KeyUp, KeyDown } from '../Scoreboard';
import { RenderHUDs } from '../Anzeigen/hud';
import { Render7TowersLobby } from '../../SevenTowers/Lobby';
import { DrawNametags } from '../Anzeigen/nametags/nametags';
import { BasicKeyBinds } from '../../preload/login';
export let PLAYER_LOBBY_MAIN = "Lobby";
export let PLAYER_LOBBY_REALLIFE = "Reallife";
export let PLAYER_LOBBY_ZOMBIES = "Zombies";
export let PLAYER_LOBBY_TACTICS = "Tactics";
export let PLAYER_LOBBY_7TOWERS = "Seven-Towers";

let CurrentLobby = PLAYER_LOBBY_REALLIFE;
let LocalPlayer = alt.Player.local;
export function GetCurrentLobby() { return CurrentLobby; }
export function FreezeClient(bool) { game.freezeEntityPosition(alt.Player.local.scriptID, bool); }

alt.onServer("Player:ChangeCurrentLobby", (Lobby) => { CurrentLobby = Lobby; });



//////////////////////////////////////////////////////////////////////////////////////////
alt.onServer('FreezePlayerPLAYER_VnX', (bool) => {
    game.freezeEntityPosition(LocalPlayer.scriptID, bool);
});

alt.onServer("movecamtocurrentpos_client", () => {
    let executedcmd = false;
    game.switchOutPlayer(LocalPlayer.scriptID);
    game.freezeEntityPosition(LocalPlayer.scriptID, true);
    alt.setTimeout(() => {
        if (executedcmd == false) {
            alt.emitServer('load_data_login');
            game.setEntityAlpha(LocalPlayer.scriptID, 255);
            executedcmd = true;
        }
    }, 6000);

    alt.setTimeout(() => {
        game.switchInPlayer(LocalPlayer.scriptID);
        alt.setTimeout(() => {
            game.freezeEntityPosition(LocalPlayer.scriptID, false);
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
    game.setPedComponentVariation(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture);
});

alt.onServer("Accessories:Load", (clothesslot, clothesdrawable, clothestexture) => {
    game.setPedPreloadVariationData(LocalPlayer.scriptID, clothesslot, clothesdrawable, clothestexture);
});

alt.onServer("HeadShape:Load", (HeadShapeJson) => {
    ///////////////////////////
    let firstHeadShape = 0;
    let secondHeadShape = 0;
    let firstSkinTone = 0
    let secondSkinTone = 0;
    let headMix = 0;
    let skinMix = 0;
    let eyesColor = 0;
    let firstHairColor = 0;
    let secondHairColor = 0;
    let faceFeatures = [];
    let blemishesModel = 0;
    let beardModel = 0;
    let beardColor = 0;
    let eyebrowsModel = 0;
    let eyebrowsColor = 0;
    let ageingModel = 0;
    let makeupModel = 0;
    let blushModel = 0;
    let blushColor = 0;
    let complexionModel = 0;
    let sundamageModel = 0;
    let lipstickModel = 0;
    let lipstickColor = 0;
    let frecklesModel = 0;
    let chestModel = 0;
    let chestColor = 0;
    ///////////////////////////
    let HeadoverlayDataFirst = 0;
    let HeadoverlayDataSecond = 0;

    alt.log(HeadShapeJson);
    let p = JSON.parse(HeadShapeJson);
    for (let i = 0; i < p.length; i++) {
        let data_pl = p[i];
        firstHeadShape = data_pl.firstHeadShape;
        secondHeadShape = data_pl.secondHeadShape;
        firstSkinTone = data_pl.firstSkinTone;
        secondSkinTone = data_pl.secondSkinTone;
        headMix = data_pl.headMix;
        skinMix = data_pl.skinMix;
        eyesColor = data_pl.eyesColor;
        firstHairColor = data_pl.firstHairColor;
        secondHairColor = data_pl.secondHairColor;

        blemishesModel = data_pl.blemishesModel;
        beardModel = data_pl.beardModel;
        beardColor = data_pl.beardColor;
        eyebrowsModel = data_pl.eyebrowsModel;
        eyebrowsColor = data_pl.eyebrowsColor;
        ageingModel = data_pl.ageingModel;
        makeupModel = data_pl.makeupModel;
        blushModel = data_pl.blushModel;
        blushColor = data_pl.blushColor;
        complexionModel = data_pl.complexionModel;
        sundamageModel = data_pl.sundamageModel;
        lipstickModel = data_pl.lipstickModel;
        lipstickColor = data_pl.lipstickColor;
        frecklesModel = data_pl.frecklesModel;
        chestModel = data_pl.chestModel;
        chestColor = data_pl.chestColor;
        faceFeatures = [
            data_pl.noseWidth, data_pl.noseHeight, data_pl.noseLength, data_pl.noseBridge, data_pl.noseTip, data_pl.noseShift, data_pl.browHeight,
            data_pl.browWidth, data_pl.cheekboneHeight, data_pl.cheekboneWidth, data_pl.cheeksWidth, data_pl.eyes, data_pl.lips, data_pl.jawWidth,
            data_pl.jawHeight, data_pl.chinLength, data_pl.chinPosition, data_pl.chinWidth, data_pl.chinShape, data_pl.neckWidth
        ];
    }
    for (var facef in faceFeatures) {
        game.setPedFaceFeature(LocalPlayer.scriptID, faceFeatures[facef], 1.0);
    }
    for (let i = 0; i < 11; i++) {
        switch (i) {
            case 0:
                HeadoverlayDataFirst = blemishesModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;
            case 1:
                HeadoverlayDataFirst = beardModel;
                HeadoverlayDataSecond = beardColor;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                game.setPedHeadOverlayColor(LocalPlayer.scriptID, i, 1, HeadoverlayDataSecond, 0);

            case 2:
                HeadoverlayDataFirst = eyebrowsModel;
                HeadoverlayDataSecond = eyebrowsColor;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                game.setPedHeadOverlayColor(LocalPlayer.scriptID, i, 1, HeadoverlayDataSecond, 0);
                break;

            case 3:
                HeadoverlayDataFirst = ageingModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;
            case 4:
                HeadoverlayDataFirst = makeupModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;

            case 5:
                HeadoverlayDataFirst = blushModel;
                HeadoverlayDataSecond = blushColor;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                game.setPedHeadOverlayColor(LocalPlayer.scriptID, i, 2, HeadoverlayDataSecond, 0);
                break;
            case 6:
                HeadoverlayDataFirst = complexionModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;
            case 7:
                HeadoverlayDataFirst = sundamageModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;
            case 8:
                HeadoverlayDataFirst = lipstickModel;
                HeadoverlayDataSecond = lipstickColor;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                game.setPedHeadOverlayColor(LocalPlayer.scriptID, i, 2, HeadoverlayDataSecond, 0);
                break;
            case 9:
                HeadoverlayDataFirst = frecklesModel;
                HeadoverlayDataSecond = 0;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                break;
            case 10:
                HeadoverlayDataFirst = chestModel;
                HeadoverlayDataSecond = chestColor;
                game.setPedHeadOverlay(LocalPlayer.scriptID, i, HeadoverlayDataFirst, 1);
                game.setPedHeadOverlayColor(LocalPlayer.scriptID, i, 1, HeadoverlayDataSecond, 0);
                break;
        }
    }
    game.setPedHeadBlendData(LocalPlayer.scriptID, firstHeadShape, secondHeadShape, 0, firstSkinTone, secondSkinTone, 0, headMix, skinMix, 0);
    game.setPedEyeColor(LocalPlayer.scriptID, eyesColor);
    game.setPedHairColor(LocalPlayer.scriptID, firstHairColor, secondHairColor);
    alt.log("HeadShape:Loaded");
});

//////////////////////////////////////////////////////////////////////////////////////////


alt.onServer('Player:Visible', (bool) => {
    game.setEntityVisible(LocalPlayer.scriptID, bool, 0);
    alt.log("Invisible = " + bool);
});

alt.onServer('Player:WarpIntoVehicle', (veh, seat) => {
    alt.setTimeout(() => {
        game.taskWarpPedIntoVehicle(LocalPlayer.scriptID, veh.scriptID, seat);
    }, 500);
});

alt.onServer('Player:WarpOutOfVehicle', () => {
    if (LocalPlayer.vehicle) {
        game.taskLeaveVehicle(alt.Player.local.scriptID, LocalPlayer.vehicle.scriptID, 16);
    }
});

alt.on('keyup', (key) => {
    KeyUp(key);
});

alt.on('keydown', (key) => {
    KeyDown(key);
    BasicKeyBinds(key);
});


alt.onServer('delay_element_data', (e, v, type, ms) => {
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
*/

alt.everyTick(() => {
    //DrawGlobalHUD();
    DrawNametags();
    dxLibaryEveryTick();
    OnCameraEveryTick();
    RenderHitMarker();
    RenderTacho();
    RenderHUDs();
    switch (CurrentLobby) {
        case PLAYER_LOBBY_7TOWERS:
            Render7TowersLobby();
            break;

        case PLAYER_LOBBY_TACTICS:
            TacticsEveryTick();
            break;
    }
});

//////////////////////////////////////////////////////////////////////////////////////////
