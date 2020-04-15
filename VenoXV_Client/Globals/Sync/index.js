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
    alt.log('[' + model + ']' + '[' + alt.hash(model) + ']' + 'Model successful fixed');

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
    alt.log('Called Model Loading');
    alt.setTimeout(() => {
        for (var models in ModelList) {
            loadModel(ModelList[models]);
        };
    }, 2000);
}
LoadModelsOnStart();