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
    counter = counter + 1;
    let NewHouseBlip = new alt.PointBlip(blippos.x, blippos.y, blippos.z);
    NewHouseBlip.sprite = 411;
    NewHouseBlip.color = c;
    NewHouseBlip.shortRange = true;
    NewHouseBlip.name = n;
    HouseBlip[blippos + counter] = NewHouseBlip;
});

alt.onServer("Destroy_HouseBlips", () => {
    counter = 0;
    for (var AllBlips in HouseBlip) HouseBlip[AllBlips].destroy();
});
