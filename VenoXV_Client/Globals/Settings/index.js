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
        }
        else {
            SettingsBrowser.emit('Settings:Show', false);
            SettingsBrowser.unfocus();
            ShowCursor(false);
        }
        SettingsBrowserOpen = !SettingsBrowserOpen;
    }
});