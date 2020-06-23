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
    if (game.isEntityAVehicle(entity.scriptID)) {
        game.setVehicleEngineOn(entity.scriptID, false, true, true);
    }
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


/* Sync : TextLabels */

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

alt.Discord.currentUser.avatar

alt.onServer('Sync:RemoveLabels', () => {
    //outputted = false;
    CurrentLabels = {};
});

/* Sync : Marker-Map */
let CurrentMarkers = {};
alt.onServer('Sync:LoadMarkers', (ID, Type, PosX, PosY, PosZ, ScaleX, ScaleY, ScaleZ, ColorR, ColorG, ColorB, ColorA) => {
    if (CurrentMarkers[ID] != null) { return; }
    CurrentMarkers[ID] = {
        ID: ID,
        Type: Type,
        PosX: PosX,
        PosY: PosY,
        PosZ: PosZ,
        Scale: [ScaleX, ScaleY, ScaleZ],
        Color: [ColorR, ColorG, ColorB, ColorA],
    };
})
alt.onServer('Sync:RemoveMarkers', () => {
    CurrentMarkers = {};
});

let cObjs = {};
let cObjCounter = 0;
alt.onServer('Sync:LoadObjs', (Parent, Hash, Position, Rotation, HashNeeded) => {
    let Entity;
    if (HashNeeded) {

        alt.loadModel(game.getHashKey(Hash));
        Entity = game.createObjectNoOffset(game.getHashKey(Hash), Position.x, Position.y, Position.z, false, false, false);
    }
    else {
        alt.loadModel(Hash);
        Entity = game.createObjectNoOffset(Hash, Position.x, Position.y, Position.z, false, false, false);
    }
    game.setEntityRotation(Entity, Rotation.x, Rotation.y, Rotation.z, 2, true);
    game.setEntityQuaternion(Entity, 0, 0, 0, 0);
    cObjs[cObjCounter++] = {
        Entity: Entity,
        Parent: Parent
    };
});

alt.onServer('Sync:DestroyObjs', () => {
    for (var counter in cObjs) {
        if (cObjs[counter].Entity != null) {
            game.deleteObject(cObjs[counter].Entity);
        }
    }
    cObjs = {};
    cObjCounter = 0;
});


function SyncTextLabels() {
    for (var labels in CurrentLabels) {
        let data = CurrentLabels[labels];
        Draw3DText(data.Text, data.PosX, data.PosY, data.PosZ, data.Font, data.Color, data.Range, true, true);
    }
}

function SyncMarkers() {
    for (var Markers in CurrentMarkers) {
        let data = CurrentMarkers[Markers];
        game.drawMarker(data.Type, data.PosX, data.PosY, data.PosZ, 0, 0, 0, 0, 0, 0, data.Scale[0], data.Scale[1], data.Scale[2], data.Color[0], data.Color[1], data.Color[2], data.Color[3], false, true, 2, false, undefined, undefined, false);
    }
}


alt.everyTick(() => {
    SyncTextLabels();
    SyncMarkers();
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
let MapObjects = {};
let MapC = 0;
alt.onServer('Sync:LoadMap', (MapName, Hash, Position, RotOrder, Rotation, freeze, HashNeeded, HighLod = false) => {
    let Entity;
    if (HashNeeded) {
        alt.loadModel(game.getHashKey(Hash));
        Entity = game.createObjectNoOffset(game.getHashKey(Hash), Position.x, Position.y, Position.z, false, false, false);
    }
    else {
        alt.loadModel(Hash);
        Entity = game.createObjectNoOffset(Hash, Position.x, Position.y, Position.z, false, false, false);
    }
    if (freeze) { game.freezeEntityPosition(Entity, true); }
    game.setEntityRotation(Entity, Rotation.x, Rotation.y, Rotation.z, RotOrder, true);
    if (HighLod) { game.setEntityLodDist(Entity, 2000); }
    //game.setEntityQuaternion(Entity, QuaternionX, QuaternionY, QuaternionZ, QuaternionW);
    //game.freezeEntityPosition(Entity, freeze);
    MapObjects[MapC++] = {
        Entity: Entity,
        MapName: MapName
    };
});

alt.onServer('Sync:UnloadMap', (MapName) => {
    for (var obj in MapObjects) {
        if (MapObjects[obj].MapName == MapName) {
            game.deleteObject(MapObjects[obj].Entity);
            MapC--;
            MapObjects[obj] = {};
        }
    }
});


//////////////////////////////////////////////////////////////////////////////////////////////////////////////