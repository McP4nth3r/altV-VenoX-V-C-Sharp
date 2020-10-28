//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

import { vnxCreateCEF, ShowCursor } from '../VnX-Lib';

let SettingsBrowser = vnxCreateCEF("SettingsWindow", "Globals/Settings/main.html");
let SettingsBrowserOpen = false;
SettingsBrowser.on('Settings:Hide', () => {
    SettingsBrowser.emit('Settings:Show', false);
    SettingsBrowser.unfocus();
    ShowCursor(false);
    SettingsBrowserOpen = false;
});
alt.on('keydown', (key) => {
    // F3
    if (key == 114) {
        if (!SettingsBrowserOpen) {
            SettingsBrowser.emit('Settings:Show', true);
            SettingsBrowser.focus();
            ShowCursor(true);
            LoadClientSettings();
        }
        else {
            SettingsBrowser.emit('Settings:Show', false);
            SettingsBrowser.unfocus();
            ShowCursor(false);
        }
        SettingsBrowserOpen = !SettingsBrowserOpen;
    }
});

alt.onServer('Settings:Show', () => {
    if (!SettingsBrowserOpen) {
        SettingsBrowser.emit('Settings:Show', true);
        SettingsBrowser.focus();
        SettingsBrowserOpen = true;
        alt.setTimeout(() => {
            ShowCursor(true);
            LoadClientSettings();
        }, 500);
    }
});
//Spawnpoints :


SettingsBrowser.on('Settings:SelectSpawnpoint', (spawn) => {
    alt.emitServer('Settings:SelectSpawnpoint', spawn);
});


function LoadClientSettings() {
    SettingsBrowser.emit('Settings:CheckButton', 'atm', alt.Player.local.getStreamSyncedMeta('PLAYER_ATM_ANZEIGEN'));
    SettingsBrowser.emit('Settings:CheckButton', 'house', alt.Player.local.getStreamSyncedMeta('PLAYER_HAUS_ANZEIGEN'));
    SettingsBrowser.emit('Settings:CheckButton', 'tacho', alt.Player.local.getStreamSyncedMeta('PLAYER_TACHO_ANZEIGEN'));
    SettingsBrowser.emit('Settings:CheckButton', 'quests', alt.Player.local.getStreamSyncedMeta('PLAYER_QUEST_ANZEIGEN'));
    SettingsBrowser.emit('Settings:CheckButton', 'reporter', alt.Player.local.getStreamSyncedMeta('PLAYER_REPORTER_ANZEIGEN'));
    SettingsBrowser.emit('Settings:CheckButton', 'global', alt.Player.local.getStreamSyncedMeta('PLAYER_GLOBALCHAT_ANZEIGEN'));
}

