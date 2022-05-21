
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { CreateBlip } from '../../../Globals/VnX-Lib';


alt.onServer('ShowTankstellenBlips', (Tankstellen) => {
    try {
        CreateBlip("Tankstelle", Tankstellen, 361, 3, true);
    }
    catch{ }
});