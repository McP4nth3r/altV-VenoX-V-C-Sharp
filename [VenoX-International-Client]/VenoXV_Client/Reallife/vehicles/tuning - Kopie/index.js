//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


import * as alt from 'alt-client';
import * as game from 'natives';
import { vnxCreateCEF, ShowCursor, vnxDestroyCEF } from '../../../Globals/VnX-Lib';


var TuningNumbers = {}
TuningNumbers[0] = true
TuningNumbers[1] = true
TuningNumbers[2] = true
TuningNumbers[3] = true
TuningNumbers[4] = true
TuningNumbers[5] = true
TuningNumbers[6] = true
TuningNumbers[7] = true
TuningNumbers[8] = true
TuningNumbers[9] = true
TuningNumbers[10] = true
TuningNumbers[11] = true
TuningNumbers[12] = true
TuningNumbers[13] = true
TuningNumbers[14] = true
TuningNumbers[15] = true
TuningNumbers[18] = true
TuningNumbers[22] = true
TuningNumbers[23] = true
TuningNumbers[24] = true
TuningNumbers[25] = true
TuningNumbers[27] = true
TuningNumbers[28] = true
TuningNumbers[30] = true
TuningNumbers[33] = true
TuningNumbers[34] = true
TuningNumbers[35] = true
TuningNumbers[38] = true
TuningNumbers[46] = true
TuningNumbers[48] = true
TuningNumbers[69] = true
TuningNumbers[200] = true




function FillTuningList() {
    for (var i in TuningNumbers) {
        if (TuningNumbers[i]) {
            let VEHICLE_MOD_ID = game.getNumVehicleMods(alt.Player.local.vehicle.scriptID, Number(i));
            alt.log(game.getModSlotName(alt.Player.local.vehicle.scriptID, Number(i)));
            if (VEHICLE_MOD_ID > 0) {
                alt.log(game.getModSlotName(alt.Player.local.vehicle.scriptID, i));
            }
        }
    }
}

alt.onServer('Tuning:Show', () => {
    try {
        let cTuning = vnxCreateCEF("Reallife-Tuning", "Reallife/vehicles/tuning/main.html", "Reallife");
        cTuning.focus();
        ShowCursor(true);
        cTuning.on('Tuning:Destroy', () => {
            vnxDestroyCEF('Reallife-Tuning');
            alt.emitServer('Reallife-Tuning:Close');
        });
        FillTuningList();
    }
    catch{ }
});
