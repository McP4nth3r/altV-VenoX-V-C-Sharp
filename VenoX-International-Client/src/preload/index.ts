//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import alt from 'alt-client';
import * as game from 'natives';
import { ShowCursor, vnxCreateCEF } from '../Globals/VnX-Lib';

let preloadbrowser = vnxCreateCEF('Preload', 'preload/main.html');

preloadbrowser.on('Preload:SelectGamemode', (Gamemode: any, Lobby: any) => {
    console.log('Preload:SelectGamemode : ' + Gamemode, Lobby);
    alt.emitServer('Preload:SelectGamemode', Gamemode, '' + Lobby, true);
    game.setEntityAlpha(alt.Player.local.scriptID, 255, false);
    game.freezeEntityPosition(alt.Player.local.scriptID, false);
    game.displayRadar(true);
    game.displayHud(true);
    ShowCursor(false);
});

preloadbrowser.on('Preload:FinishedPrivacyPolicy', () => alt.emitServer('Preload:FinishedPrivacyPolicy'));

preloadbrowser.on('Preload:SelectLanguage', (Pair: any) => alt.emitServer('Preload:SelectLanguage', Pair));

alt.onServer('Preload:ShowGamemodes', (state: boolean) => {
    preloadbrowser.emit('Preload:ShowGamemodes', state);
    ShowCursor(state);
    if (state) preloadbrowser.focus();
});

alt.onServer(
    'LoadPreloadUserInfo',
    (
        AllPlayers: any,
        AllPlayersMax: any,
        ReallifePlayers: any,
        ReallifePlayersMax: any,
        TacticPlayers: any,
        TacticPlayersMax: any,
        ZombiePlayers: any,
        ZombiePlayersMax: any,
        RacePlayers: any,
        RacePlayersMax: any,
        SevenTowersPlayers: any,
        SevenTowersPlayersMax: any
    ) => {
        preloadbrowser.emit(
            'Load:RefreshGamemodeStats',
            AllPlayers,
            AllPlayersMax,
            ReallifePlayers,
            ReallifePlayersMax,
            TacticPlayers,
            TacticPlayersMax,
            ZombiePlayers,
            ZombiePlayersMax,
            RacePlayers,
            RacePlayersMax,
            SevenTowersPlayers,
            SevenTowersPlayersMax
        );
    }
);

alt.onServer('LoadingScreen:ShowPreload', (state: boolean) => {
    alt.setTimeout(() => preloadbrowser.emit('LoadingScreen:ShowPreload', state), 500);
});

alt.onServer('Preload:UpdateDownloadState', (EventText: any) => preloadbrowser.emit('LoadingScreen:UpdateCurrentState', EventText));
