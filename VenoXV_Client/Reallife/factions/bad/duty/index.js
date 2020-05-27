//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { FreezeClient } from '../../../../Globals/VnX-Lib/events';
import { ShowCursor } from '../../../../Globals/VnX-Lib';


let duty_browser = null;
alt.onServer('show_duty_window_bad', (e) => {
    FreezeClient(true);
    duty_browser = new alt.WebView("http://resource/VenoXV_Client/Reallife/factions/bad/duty/main.html");
    duty_browser.focus();
    ShowCursor(true);
    if (e == true) { duty_browser.emit("Duty:Load"); }

    duty_browser.on('destroy_duty_window_bad', () => {
        FreezeClient(false);
        if (duty_browser != null) {
            duty_browser.destroy();
            duty_browser = null;
            ShowCursor(false);
            return
        }
    });
    duty_browser.on('duty_window_bad_btn_pressed', (state) => {
        alt.emitServer('goDUTYBADServer', state);
        alt.log('Called : Duty : ' + state);
        alt.emit("destroy_duty_window_bad");
    });
});

