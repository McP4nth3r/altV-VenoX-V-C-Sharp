//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import {
    ShowCursor,
    vnxCreateCEF
}
from '../Globals/VnX-Lib';

let preloadbrowser = vnxCreateCEF("Preload", "preload/main.html");

preloadbrowser.on('Preload:SelectGamemode', (Gamemode, Lobby) => {
    alt.emitServer("Preload:SelectGamemode", Gamemode, Lobby, true);
    game.setEntityAlpha(alt.Player.local.scriptID, 255, false);
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

alt.onServer('Preload:ShowGamemodes', state => {
    preloadbrowser.emit('Preload:ShowGamemodes', state);
    ShowCursor(state);
    if(state)
        preloadbrowser.focus();
});


alt.onServer('LoadPreloadUserInfo', (AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax) => {
    preloadbrowser.emit('Load:RefreshGamemodeStats', AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax);
});

alt.onServer('LoadingScreen:ShowPreload', (state) => {
    if (state) {
        alt.setTimeout(() => {
            preloadbrowser.emit('LoadingScreen:ShowPreload', state);
        }, 500);
        return;
    }
    preloadbrowser.emit('LoadingScreen:ShowPreload', state);
});

alt.onServer('Preload:UpdateDownloadState', (EventText) => {
    preloadbrowser.emit('LoadingScreen:UpdateCurrentState', EventText);
});