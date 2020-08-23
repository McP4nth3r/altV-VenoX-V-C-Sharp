//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../../Globals/VnX-Lib';
import { FreezeClient } from '../../../../Globals/VnX-Lib/events';

let duty_browser = null;
alt.onServer('showDutyWindow', (e, pname) => {
    if (duty_browser) { return; }
    duty_browser = vnxCreateCEF("LSPD-Duty", "Reallife/factions/state/duty/main.html", "Reallife");
    alt.setTimeout(() => {
        duty_browser.focus();
        ShowCursor(true);
        duty_browser.emit("Duty:Load", e, pname);
    }, 500);
    duty_browser.on('ButtonPressed', (button) => {
        switch (button) {
            case "Duty":
                alt.emitServer('goDUTYServer');
                break;
            case "OffDuty":
                alt.emitServer('goOFFDUTYServer');
                break;
            case "Swat":
                alt.emitServer('goSWATServer');
                break;
        }
        vnxDestroyCEF("LSPD-Duty");
        duty_browser = null;
        FreezeClient(false);
        ShowCursor(false);
    });
    duty_browser.on('destroyDutyWindow', () => {
        vnxDestroyCEF("LSPD-Duty");
        duty_browser = null;
        FreezeClient(false);
        ShowCursor(false);
    });
});
