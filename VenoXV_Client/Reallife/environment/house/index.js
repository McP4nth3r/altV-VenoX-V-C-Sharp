//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";
import { CreateBlip } from '../../../Globals/VnX-Lib';

let HouseBlip = {};
let counter = 0;

alt.onServer("ShowHouseBlips", (blippos, c, n) => {
    try {
        let Blip = CreateBlip(n, [blippos.x, blippos.y, blippos.z], 411, c, true);
        HouseBlip[counter++] = Blip;
    }
    catch{ }
});

alt.onServer("Destroy_HouseBlips", () => {
    try {
        counter = 0;
        for (var AllBlips in HouseBlip) HouseBlip[AllBlips].destroy();
    }
    catch{ }
});
