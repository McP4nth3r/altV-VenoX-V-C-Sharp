//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";
import {
    CreateBlip
} from '../../../Globals/VnX-Lib';

let HouseBlip = {};
let counter = 0;

alt.onServer("ShowHouseBlips", (blippos, c, n) => {
    HouseBlip[counter] = CreateBlip(n, [blippos.x, blippos.y, blippos.z], 411, c, true);
    counter++
});

alt.onServer("Reallife:DestroyHouseBlips", () => {
    for (var AllBlips in HouseBlip) {
        if (HouseBlip[AllBlips] != null) {
            game.removeBlip(HouseBlip[AllBlips]);
        }
        delete HouseBlip[AllBlips];
    }
});