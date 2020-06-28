//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../Globals/VnX-Lib';

let SevenTowersTick;
let CurrentWinner = "Noob";

export function Render7TowersLobby() {
    try {
        //DrawText("1:34", [0.5, 0.006], [0.5, 0.5], 0, [255, 255, 255, 255], true, true);
        //game.drawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
        DrawText(CurrentWinner + " gewinnt die Runde.", [0.5, 0.5], [1, 1], 0, [255, 255, 255, 255], false, true);
        game.drawRect(0.5, 0.57, 0.25, 0.005, 255, 200, 0, 255);
    }
    catch{ }
}

alt.onServer('SevenTowers:ShowWinner', (Winner, DestoryMS) => {
    try {
        if (SevenTowersTick != null) { return; }
        alt.toggleGameControls(false);
        SevenTowersTick = alt.everyTick(() => {
            Render7TowersLobby();
            CurrentWinner = Winner;
        });
        alt.setTimeout(() => {
            if (SevenTowersTick != null) {
                alt.clearEveryTick(SevenTowersTick); SevenTowersTick = null; alt.toggleGameControls(true);
            }

        }, DestoryMS);
    }
    catch{ }
});