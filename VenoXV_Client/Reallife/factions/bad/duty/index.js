//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { FreezeClient } from '../../../../Globals/VnX-Lib/events';
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../../Globals/VnX-Lib';


let dutybadbrowser = null;
alt.onServer('show_duty_window_bad', (Name, Neutral) => {
    if (dutybadbrowser) { return; }
    FreezeClient(true);
    dutybadbrowser = vnxCreateCEF("DutyBad", "Reallife/factions/bad/duty/main.html");
    alt.setTimeout(() => {
        dutybadbrowser.focus();
        ShowCursor(true);
        dutybadbrowser.emit("Duty:Load", Name, Neutral);
    }, 500);
    dutybadbrowser.on('destroy_duty_window_bad', () => {
        dutybadbrowser = null;
        FreezeClient(false);
        vnxDestroyCEF("DutyBad");
        ShowCursor(false);
    });
    dutybadbrowser.on('duty_window_bad_btn_pressed', (state) => {
        dutybadbrowser = null;
        alt.emitServer('goDUTYBADServer', state);
        vnxDestroyCEF("DutyBad");
        ShowCursor(false);
        FreezeClient(false);
    });
});

