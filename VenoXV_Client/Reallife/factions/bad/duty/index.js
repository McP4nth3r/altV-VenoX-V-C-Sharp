//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { FreezeClient } from '../../../../Globals/VnX-Lib/events';
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../../Globals/VnX-Lib';


let duty_browser = null;
alt.onServer('show_duty_window_bad', (e) => {
    try {
        FreezeClient(true);
        vnxDestroyCEF("DutyBad");
        duty_browser = vnxCreateCEF("DutyBad", "Reallife/factions/bad/duty/main.html");
        alt.setTimeout(() => {
            duty_browser.focus();
            ShowCursor(true);
            if (e == true) { duty_browser.emit("Duty:Load"); }
        }, 200);
        duty_browser.on('destroy_duty_window_bad', () => {
            FreezeClient(false);
            vnxDestroyCEF("DutyBad");
            ShowCursor(false);
        });
        duty_browser.on('duty_window_bad_btn_pressed', (state) => {
            alt.emitServer('goDUTYBADServer', state);
            vnxDestroyCEF("DutyBad");
            ShowCursor(false);
            FreezeClient(false);
        });
    }
    catch{ }
});

