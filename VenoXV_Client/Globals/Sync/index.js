//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { Draw3DText } from '../VnX-Lib';

let LabelList = {};
let LabelListCounter = 0;

let LabelListNearLocal = {};
let LabelListNearLocalCounter = 0;
alt.onServer('Sync:LoadTextLabels', (LabelJson) => {
    let LabelItems = JSON.parse(LabelJson);
    for (let i = 0; i < LabelItems.length; i++) {
        let data = LabelItems[i];
        LabelList[LabelListCounter] = {
            Text: data.Text,
            PosX: data.PosX,
            PosY: data.PosY,
            PosZ: data.PosZ,
            Font: data.Font,
            Color: [data.ColorR, data.ColorG, data.ColorB, data.ColorA],
            Dimension: data.Dimension,
            Range: data.Range
        }
        LabelListCounter++;
    }
})

alt.setInterval(() => {
    LabelListNearLocal = {};
    LabelListNearLocalCounter = 0;
    for (var i in LabelList) {
        let data = LabelList[i];
        if (game.getDistanceBetweenCoords(data.PosX, data.PosY, data.PosZ, alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, 1) <= 200) {
            LabelListNearLocal[LabelListNearLocalCounter] = {
                Text: data.Text,
                PosX: data.PosX,
                PosY: data.PosY,
                PosZ: data.PosZ,
                Font: data.Font,
                Color: data.Color,
                Dimension: data.Dimension,
                Range: data.Range
            }
            LabelListNearLocalCounter++;
        }
    }
}, 5000);

alt.everyTick(() => {
    for (var labels in LabelListNearLocal) {
        let data = LabelListNearLocal[labels];
        //alt.log(data.Text + " | " + data.PosX + " | " + data.PosY + " | " + data.PosZ + " | " + data.Font + " | " + data.Color[0] + " | " + data.Color[1] + " | " + data.Color[2] + " | " + data.Range);
        Draw3DText(data.Text, data.PosX, data.PosY, data.PosZ, data.Font, data.Color, data.Range, true, true);
    }
});