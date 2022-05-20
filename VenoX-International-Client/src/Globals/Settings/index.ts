//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

import {
    vnxCreateCEF,
    ShowCursor
} from '../VnX-Lib';

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
        } else {
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
        }, 500);
    }
});

//Spawnpoints :
SettingsBrowser.on('Settings:SelectSpawnpoint', spawn => alt.emitServer('Settings:SelectSpawnpoint', spawn));

// HUD's : 
SettingsBrowser.on('Settings:SelectHUD', hud => alt.emitServer('Settings:SelectHUD', hud));

// Scoreboard Background : 
SettingsBrowser.on('Settings:SelectScoreboardBackground', scoreboardBg => alt.emitServer('Settings:SelectScoreboardBackground', scoreboardBg));

// Speedometer :
SettingsBrowser.on('Settings:SelectSpeedometer', speedo => alt.emitServer('Settings:SelectSpeedometer', speedo));


alt.on('syncedMetaChange', (Entity, key, value, oldValue) => {
    if (!SettingsBrowser) return;
    if (Entity == alt.Player.local) {
        switch (key) {
            case 'PLAYER_ATM_ANZEIGEN':
                SettingsBrowser.emit('Settings:CheckButton', 'atm', value);
                break;
            case 'PLAYER_TACHO_ANZEIGEN':
                SettingsBrowser.emit('Settings:CheckButton', 'tacho', value);
                break;
            case 'PLAYER_QUEST_ANZEIGEN':
                SettingsBrowser.emit('Settings:CheckButton', 'quests', value);
                break;
            case 'PLAYER_REPORTER_ANZEIGEN':
                SettingsBrowser.emit('Settings:CheckButton', 'reporter', value);
                break;
            case 'PLAYER_GLOBALCHAT_ANZEIGEN':
                SettingsBrowser.emit('Settings:CheckButton', 'global', value);
                break;
        }
    }
});