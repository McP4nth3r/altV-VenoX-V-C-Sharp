//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { Draw3DText } from '../VnX-Lib';

let muted = true;
export function OnVoiceKeyDown(key) {
    try {
        if (key == 0x4D) {
            muted = false;
            alt.emitServer('Voice:ChangeState', muted);
        }
    }
    catch { }
}

export function OnVoiceKeyUp(key) {
    try {
        if (key == 0x4D) {
            muted = true;
            alt.emitServer('Voice:ChangeState', muted);
        }
    } catch { }
}

alt.on("gameEntityCreate", entity => {
    try {
        if (game.isEntityAVehicle(entity.scriptID)) {
            game.setVehicleEngineOn(entity.scriptID, false, true, true);
        }
        if (entity.hasStreamSyncedMeta('VEHICLE_FROZEN')) {
            game.freezeEntityPosition(entity.scriptID, entity.getStreamSyncedMeta('VEHICLE_FROZEN'));
        }
        if (entity.hasStreamSyncedMeta('VEHICLE_GODMODE')) {
            game.setEntityInvincible(entity.scriptID, entity.getStreamSyncedMeta('VEHICLE_GODMODE'));
        }
    }
    catch { }
});

/* Sync : TextLabels */

let CurrentLabels = {};
alt.onServer('Sync:LoadTextLabels', (ID, Text, PosX, PosY, PosZ, Font, ColorR, ColorG, ColorB, ColorA, Dimension, Range) => {
    try {
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
    }
    catch { }
});

alt.onServer('Sync:RemoveLabels', () => {
    try {
        //outputted = false;
        CurrentLabels = {};
    }
    catch { }
});

/* Sync : Marker-Map */
let CurrentMarkers = {};
alt.onServer('Sync:LoadMarkers', (ID, Type, PosX, PosY, PosZ, ScaleX, ScaleY, ScaleZ, ColorR, ColorG, ColorB, ColorA) => {
    try {
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
    }
    catch { }
})
alt.onServer('Sync:RemoveMarkers', () => {
    try {
        CurrentMarkers = {};
    }
    catch { }
});

let cObjs = {};
let cObjCounter = 0;
alt.onServer('Sync:LoadObjs', (Parent, Hash, Position, Rotation, HashNeeded) => {
    try {
        let Entity;
        if (HashNeeded) {
            let newHash = game.getHashKey(Hash);
            if (!game.hasModelLoaded(newHash)) {
                alt.loadModel(newHash);
                game.requestModel(newHash);
            }
            Entity = game.createObjectNoOffset(newHash, Position.x, Position.y, Position.z, false, false, false);
        }
        else {
            if (!game.hasModelLoaded(Hash)) {
                alt.loadModel(Hash);
                game.requestModel(Hash);
            }
            Entity = game.createObjectNoOffset(Hash, Position.x, Position.y, Position.z, false, false, false);
        }
        game.setEntityRotation(Entity, Rotation.x, Rotation.y, Rotation.z, 2, true);
        game.setEntityQuaternion(Entity, 0, 0, 0, 0);
        cObjs[cObjCounter++] = {
            Entity: Entity,
            Parent: Parent
        };
    }
    catch { }
});

alt.onServer('Sync:DestroyObjs', () => {
    try {
        for (var counter in cObjs) {
            if (cObjs[counter].Entity != null) {
                game.deleteObject(cObjs[counter].Entity);
            }
        }
        cObjs = {};
        cObjCounter = 0;
    }
    catch { }
});


function SyncTextLabels() {
    try {
        for (var labels in CurrentLabels) {
            let data = CurrentLabels[labels];
            Draw3DText(data.Text, data.PosX, data.PosY, data.PosZ, data.Font, data.Color, data.Range, true, true);
        }
    }
    catch { }
}

function SyncMarkers() {
    try {
        for (var Markers in CurrentMarkers) {
            let data = CurrentMarkers[Markers];
            game.drawMarker(data.Type, data.PosX, data.PosY, data.PosZ, 0, 0, 0, 0, 0, 0, data.Scale[0], data.Scale[1], data.Scale[2], data.Color[0], data.Color[1], data.Color[2], data.Color[3], false, true, 2, false, undefined, undefined, false);
        }
    }
    catch { }
}


alt.everyTick(() => {
    try {
        SyncTextLabels();
        SyncMarkers();
    }
    catch { }
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
let MapObjects = {};
let MapC = 0;
alt.onServer('Sync:LoadMap', (MapName, Hash, Position, RotOrder, Rotation, freeze, HashNeeded, HighLod = false, Tint = 0) => {
    let Entity;
    if (Hash == 665940918 || Hash == "v_corp_postbox") alt.log('Hash : ' + Hash);
    if (HashNeeded) {
        if (!game.hasModelLoaded(game.getHashKey(Hash))) {
            if (Hash == 665940918 || Hash == "v_corp_postbox") alt.log('Hash neeed for : ' + Hash);
            alt.loadModel(game.getHashKey(Hash));
        }
        Entity = game.createObjectNoOffset(game.getHashKey(Hash), Position.x, Position.y, Position.z, false, false, false);
    }
    else {
        if (!game.hasModelLoaded(Hash)) alt.loadModel(Hash);
        Entity = game.createObjectNoOffset(Hash, Position.x, Position.y, Position.z, false, false, false);
    }
    if (freeze) game.freezeEntityPosition(Entity, true);
    if (HighLod) game.setEntityLodDist(Entity, 2000);
    if (Tint > 0) game.setObjectTextureVariation(Entity, Tint);
    game.setEntityRotation(Entity, Rotation.x, Rotation.y, Rotation.z, RotOrder, true);

    //game.setEntityQuaternion(Entity, QuaternionX, QuaternionY, QuaternionZ, QuaternionW);
    //game.freezeEntityPosition(Entity, freeze);
    MapObjects[MapC++] = {
        Entity: Entity,
        MapName: MapName
    };
});

alt.onServer('Sync:UnloadMap', (MapName) => {
    try {
        for (var obj in MapObjects) {
            if (MapObjects[obj].MapName == MapName) {
                game.deleteObject(MapObjects[obj].Entity);
                MapC--;
                MapObjects[obj] = {};
            }
        }
    }
    catch { }
});


//////////////////////////////////////////////////////////////////////////////////////////////////////////////