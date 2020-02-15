//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../Globals/VnX-Lib';

export function Render7TowersLobby() {
    DrawText("1:34", [0.5, 0.006], [0.5, 0.5], 0, [255, 255, 255, 255], true, true);
    game.drawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
}