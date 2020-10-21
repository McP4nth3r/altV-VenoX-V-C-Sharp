//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


import * as alt from 'alt-client';
import * as game from 'natives';
import { vnxCreateCEF, ShowCursor, vnxDestroyCEF } from '../../../Globals/VnX-Lib';
let curTuningVeh;

alt.onServer('Tuning:Show', (veh, Items) => {
    try {
        let cTuning = vnxCreateCEF("Reallife-Tuning", "Reallife/vehicles/tuning/main.html", "Reallife");
        cTuning.focus();
        ShowCursor(true);
        cTuning.on('Tuning:Destroy', () => {
            vnxDestroyCEF('Reallife-Tuning');
            alt.emitServer('Reallife-Tuning:Close');
        });
        alt.setTimeout(() => {
            curTuningVeh = veh;
            cTuning.emit("CEF:Tuning:openTuningMenu", Items);
        }, 200);
    }
    catch { }
});
