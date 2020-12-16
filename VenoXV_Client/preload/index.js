//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import {
    ShowCursor, vnxCreateCEF
}
from '../Globals/VnX-Lib';

let preloadbrowser = vnxCreateCEF("Preload", "preload/main.html");

preloadbrowser.on('load_selected_gm', (v) => {
    alt.emitServer("Load_selected_gm_server", v);
    game.setEntityAlpha(alt.Player.local.scriptID, 255);
    game.freezeEntityPosition(alt.Player.local.scriptID, false);
    game.displayRadar(true);
    game.displayHud(true);
    ShowCursor(false);
});

preloadbrowser.on('Preload:FinishedPrivacyPolicy', () => {
    alt.emitServer('Preload:FinishedPrivacyPolicy');
})

preloadbrowser.on('Preload:SelectLanguage', (Pair) => {
    alt.emitServer('Preload:SelectLanguage', Pair);
})

alt.onServer('preload_gm_list', () => {
    try {
        preloadbrowser.emit('Load:ShowPreload');
        ShowCursor(true);
        preloadbrowser.focus();

    } catch {}
});


alt.onServer('LoadPreloadUserInfo', (AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax) => {
    preloadbrowser.emit('Load:RefreshGamemodeStats', AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax);
});

alt.onServer('LoadingScreen:ShowPreload', (state) => {
    preloadbrowser.emit('LoadingScreen:ShowPreload', state);
});

alt.onServer('Preload:UpdateDownloadState', (EventText) => {
    preloadbrowser.emit('LoadingScreen:UpdateCurrentState', EventText);
});


alt.onServer("Charselector:setCorrectSkin", (facefeaturesarray, headblendsarray, headoverlaysarray) => {
    try {
        let facefeatures = JSON.parse(facefeaturesarray);
        let headblends = JSON.parse(headblendsarray);
        let headoverlays = JSON.parse(headoverlaysarray);

        game.setPedHeadBlendData(alt.Player.local.scriptID, headblends[0], headblends[1], 0, headblends[2], headblends[5], 0, headblends[3], headblends[4], 0, 0);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, 1, 1, parseInt(headoverlays[2][1]), 1);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, 2, 1, parseInt(headoverlays[2][2]), 1);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, 5, 2, parseInt(headoverlays[2][5]), 1);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, 8, 2, parseInt(headoverlays[2][8]), 1);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, 10, 1, parseInt(headoverlays[2][10]), 1);
        game.setPedEyeColor(alt.Player.local.scriptID, parseInt(headoverlays[0][14]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 0, parseInt(headoverlays[0][0]), parseInt(headoverlays[1][0]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 1, parseInt(headoverlays[0][1]), parseFloat(headoverlays[1][1]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 2, parseInt(headoverlays[0][2]), parseFloat(headoverlays[1][2]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 3, parseInt(headoverlays[0][3]), parseInt(headoverlays[1][3]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 4, parseInt(headoverlays[0][4]), parseInt(headoverlays[1][4]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 5, parseInt(headoverlays[0][5]), parseInt(headoverlays[1][5]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 6, parseInt(headoverlays[0][6]), parseInt(headoverlays[1][6]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 7, parseInt(headoverlays[0][7]), parseInt(headoverlays[1][7]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 8, parseInt(headoverlays[0][8]), parseInt(headoverlays[1][8]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 9, parseInt(headoverlays[0][9]), parseInt(headoverlays[1][9]));
        game.setPedHeadOverlay(alt.Player.local.scriptID, 10, parseInt(headoverlays[0][10]), parseInt(headoverlays[1][10]));
        game.setPedComponentVariation(alt.Player.local.scriptID, 2, parseInt(headoverlays[0][13]), 0, 0);
        game.setPedHairColor(alt.Player.local.scriptID, parseInt(headoverlays[2][13]), parseInt(headoverlays[1][13]));

        for (let i = 0; i < 20; i++) {
            game.setPedFaceFeature(alt.Player.local.scriptID, i, facefeatures[i]);
        }
    } catch {}
});
