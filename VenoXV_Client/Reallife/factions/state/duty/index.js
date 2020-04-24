//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from '../../../../Globals/VnX-Lib';
import { FreezeClient } from '../../../../Globals/VnX-Lib/events';

let duty_browser = null;
alt.onServer('showDutyWindow', (e, pname) => {
    duty_browser = new alt.WebView("http://resource/VenoXV_Client/Reallife/factions/state/duty/main.html");
    duty_browser.focus();
    ShowCursor(true);
    duty_browser.emit("Duty:Load", e, pname);

    duty_browser.on('ButtonPressed', (button) => {
        switch (button) {
            case "Duty":
                alt.emitServer('goDUTYServer');
            case "OffDuty":
                alt.emitServer('goOFFDUTYServer');
            case "Swat":
                alt.emitServer('goSWATServer');
        }
        alt.log(button);
        alt.emit("destroyDutyWindow");
    });

    duty_browser.on('destroyDutyWindow', () => {
        if (duty_browser != null) {
            duty_browser.destroy();
            duty_browser = null;
            FreezeClient(false);
            ShowCursor(false);
            return
        }
    });
});
