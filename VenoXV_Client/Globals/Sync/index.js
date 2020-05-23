//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { Draw3DText } from '../VnX-Lib';


let muted = true;
export function OnVoiceKeyDown(key) {
    if (key == 0x4D) {
        muted = false;
        alt.emitServer('Voice:ChangeState', muted);
    }
}

export function OnVoiceKeyUp(key) {
    if (key == 0x4D) {
        muted = true;
        alt.emitServer('Voice:ChangeState', muted);
    }
}

alt.on("gameEntityCreate", entity => {
    if (entity.hasStreamSyncedMeta('VEHICLE_FROZEN')) {
        game.freezeEntityPosition(entity.scriptID, entity.getStreamSyncedMeta('VEHICLE_FROZEN'));
    }
    if (entity.hasStreamSyncedMeta('VEHICLE_GODMODE')) {
        game.setEntityInvincible(entity.scriptID, entity.getStreamSyncedMeta('VEHICLE_GODMODE'));
    }
});


function loadModel(model) {
    if (!game.isModelValid(model)) { return; }

    if (!game.isModelInCdimage(model)) { return; }

    if (game.hasModelLoaded(model)) { return; }

    game.requestModel(model);

    let interval = alt.setInterval(() => {
        if (game.hasModelLoaded(model)) {
            alt.clearInterval(interval);
        }
    }, 5);
}

let ModelCounter = 0;
let ModelList = {};
ModelList[ModelCounter] = "s_f_y_cop_01";
ModelList[ModelCounter++] = "ig_ramp_gang";
ModelList[ModelCounter++] = "s_m_y_swat_01";
ModelList[ModelCounter++] = "s_f_y_stripper_01";
ModelList[ModelCounter++] = "mp_m_fibsec_01";
ModelList[ModelCounter++] = "ig_claypain";
ModelList[ModelCounter++] = "s_m_m_movalien_01";
ModelList[ModelCounter++] = "u_m_y_zombie_01";
ModelList[ModelCounter++] = "g_m_y_lost_03";
ModelList[ModelCounter++] = "mp_m_execpa_01";
ModelList[ModelCounter++] = "csb_mweather";
ModelList[ModelCounter++] = "s_m_y_marine_03";
ModelList[ModelCounter++] = "g_m_m_chicold_01";
function LoadModelsOnStart() {
    alt.setTimeout(() => {
        for (var models in ModelList) {
            loadModel(ModelList[models]);
        };
    }, 2000);
}
LoadModelsOnStart();




let CurrentLabels = {};
alt.onServer('Sync:LoadTextLabels', (ID, Text, PosX, PosY, PosZ, Font, ColorR, ColorG, ColorB, ColorA, Dimension, Range) => {
    if (CurrentLabels[ID] != null) { return; }
    CurrentLabels[ID] = {
        ID: ID,
        Text: Text,
        PosX: PosX,
        PosY: PosY,
        PosZ: PosZ,
        Font: Font,
        Color: [ColorR, ColorG, ColorB, ColorA],
        Dimension: Dimension,
        Range: Range
    };
});

alt.onServer('Sync:RemoveLabels', () => {
    //outputted = false;
    CurrentLabels = {};
});
/*
let outputted = false;
function DebugLog() {
    let c = 0;
    for (var labels in CurrentLabels) {
        c++;
    }
    alt.log(c);
    outputted = true;
}*/
alt.everyTick(() => {
    //if (!outputted) { DebugLog(); }
    for (var labels in CurrentLabels) {
        let data = CurrentLabels[labels];
        //alt.log(data.Text + " | " + data.PosX + " | " + data.PosY + " | " + data.PosZ + " | " + data.Font + " | " + data.Color[0] + " | " + data.Color[1] + " | " + data.Color[2] + " | " + data.Range);
        Draw3DText(data.Text, data.PosX, data.PosY, data.PosZ, data.Font, data.Color, data.Range, true, true);
    }
});