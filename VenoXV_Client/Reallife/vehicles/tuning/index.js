//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


import * as alt from 'alt-client';
import * as game from 'natives';
import { vnxCreateCEF, ShowCursor, vnxDestroyCEF } from '../../../Globals/VnX-Lib';

let slotsArray = [
    { slot: 0, desc: 'Spoiler', products: 2500 },
    { slot: 1, desc: 'Front Karosserie', products: 3500 },
    { slot: 2, desc: 'Heck Karosserie', products: 3500 },
    { slot: 3, desc: 'Seitenschweller', products: 2000 },
    { slot: 4, desc: 'Auspuff', products: 2000 },
    { slot: 5, desc: 'Fahrgestell', products: 5500 },
    { slot: 6, desc: 'Kühlergrill', products: 3200 },
    { slot: 7, desc: 'Motorhaube', products: 4500 },
    { slot: 8, desc: 'mechanic.fender', products: 3000 },
    { slot: 9, desc: 'mechanic.right-fender', products: 3000 },
    { slot: 10, desc: 'Dach', products: 2500 },
    { slot: 11, desc: 'Motor [ EMS ] ', products: 6000 },
    { slot: 12, desc: 'Bremsen', products: 5000 },
    { slot: 13, desc: 'Getriebe', products: 5500 },
    { slot: 14, desc: 'Hupe', products: 10000 },
    { slot: 15, desc: 'Tieferlegung', products: 4000 },
    { slot: 18, desc: 'Turbolader', products: 12000 },
    { slot: 22, desc: 'Lichter', products: 1500 },
    { slot: 23, desc: 'Felgen', products: 8500 },
    { slot: 24, desc: 'mechanic.back-wheels', products: 5000 },
    { slot: 25, desc: 'Kennzeichen', products: 2500 },
    //{slot: 27, desc: 'trim-design', products: 800},
    //{slot: 28, desc: 'ornaments', products: 150}, 
    //{slot: 33, desc: 'steering-wheel', products: 100}, 
    //{slot: 34, desc: 'shift-lever', products: 100}, 
    //{slot: 38, desc: 'hydraulics', products: 1200}, 
    { slot: 46, desc: 'Scheibenfolierung', products: 4000 }
];


function FillTuningList() {
    for (let i = 0; i < slotsArray.length; i++) {
        let modNumber = game.getNumVehicleMods(alt.Player.local.vehicle.scriptID, slotsArray[i].slot);
        if (modNumber > 0) {

            for (let m = 0; m < modNumber; m++) {
                alt.log(game.getModSlotName(alt.Player.local.vehicle.scriptID, slotsArray[i].slot));
            }
        }
    }
}

alt.onServer('Tuning:Show', () => {
    let cTuning = vnxCreateCEF("Reallife-Tuning", "Reallife/vehicles/tuning/main.html");
    cTuning.focus();
    ShowCursor(true);
    cTuning.on('Tuning:Destroy', () => {
        vnxDestroyCEF('Reallife-Tuning');
    });
    FillTuningList();
});
