
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
let player = alt.Player.local;
let cursor = false;
let cBrowserList = [];
let cBrowserId = 0;
let cNPCList = [];
let cNPCId = 0;


export function ShowCursor(bool) {
    try {
        if (cursor == false && bool == false || cursor == true && bool == true) {
            return;
        }
        alt.toggleGameControls(!bool);
        alt.showCursor(bool);
        cursor = bool;
    }
    catch{ }
}
export function GetCursorStatus() {
    try {
        if (cursor) { return true; }
        else { return false; }
    }
    catch{ }
}
export function DrawText(msg, screenPos, scale, fontType, ColorRGB, useOutline = true, useDropShadow = true, layer = 0, align = 0) {
    try {
        let hex = msg.match('{.*}');
        if (hex) {
            const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
            r = rgb[0];
            g = rgb[1];
            b = rgb[2];
            msg = msg.replace(hex[0], '');
        }
        if (ColorRGB == undefined || ColorRGB == null) { ColorRGB = 255; }
        //game.setScriptGfxDrawOrder(layer);
        game.beginTextCommandDisplayText('STRING');
        game.addTextComponentSubstringPlayerName(msg);
        game.setTextFont(fontType);
        game.setTextScale(scale[0], scale[1]);
        game.setTextWrap(0.0, 1.0);
        game.setTextCentre(true);
        game.setTextColour(ColorRGB[0], ColorRGB[1], ColorRGB[2], ColorRGB[3]);
        game.setTextJustification(align);

        if (useOutline) game.setTextOutline();

        if (useDropShadow) game.setTextDropShadow();

        game.endTextCommandDisplayText(screenPos[0], screenPos[1]);
    }
    catch{ }
}
export function Draw3DText(msg, x, y, z, fontType, color, range = 20, useOutline = true, useDropShadow = true) {
    try {
        const [bol, _x, _y] = game.getScreenCoordFromWorldCoord(x, y, z);
        const camCord = game.getFinalRenderedCamCoord();
        const dist = game.getDistanceBetweenCoords(camCord.x, camCord.y, camCord.z, x, y, z, 1)


        if (dist > range) return;

        let scale = (4.00001 / dist) * 0.4
        if (scale > 0.6)
            scale = 0.6;


        const fov = (1 / game.getGameplayCamFov()) * 100;
        scale = scale * fov;

        if (bol) {
            game.setTextScale(scale, scale);
            game.setTextFont(fontType);
            game.setTextProportional(true);
            game.setTextColour(color[0], color[1], color[2], color[3]);
            game.setTextDropshadow(0, 0, 0, 0, 255);
            game.setTextEdge(2, 0, 0, 0, 150);
            game.setTextDropShadow();
            game.setTextOutline();
            game.setTextCentre(true);
            game.beginTextCommandDisplayText("STRING");
            game.addTextComponentSubstringPlayerName(msg);
            if (useOutline) game.setTextOutline();
            if (useDropShadow) game.setTextDropShadow();
            game.endTextCommandDisplayText(_x, _y);
        }
    }
    catch{ }
}
export function CreateBlip(name, pos, sprite, color, shortrange) {
    try {
        let blip = new alt.PointBlip(pos[0], pos[1], pos[2]);
        blip.alpha = 255;
        blip.sprite = sprite;
        blip.color = color;
        blip.shortRange = shortrange;
        blip.name = name;
        return blip;
    }
    catch{ }
}
export function CreatePed(PedName, Vector3Pos, rot = 0) {
    let PedHash = game.getHashKey(PedName);
    if (!game.hasModelLoaded(PedHash)) {
        alt.loadModel(PedHash);
        game.requestModel(PedHash);
    }
    if (game.hasModelLoaded(PedHash)) {
        let Entity = game.createPed(2, PedHash, Vector3Pos.x, Vector3Pos.y, Vector3Pos.z, rot, false, false);
        alt.setTimeout(() => { game.freezeEntityPosition(Entity, true); }, 3000);
        cNPCList[cNPCId++] = {
            Entity: Entity,
            ID: cNPCId,
            Name: PedName,
            Hash: PedHash
        };
        game.setEntityAsMissionEntity(Entity, true, false); // make sure its not despawned by game engine
        game.setBlockingOfNonTemporaryEvents(Entity, true); // make sure ped doesnt flee etc only do what its told
        game.setPedCanBeTargetted(Entity, false);
        game.setPedCanBeKnockedOffVehicle(Entity, 1);
        game.setPedCanBeDraggedOut(Entity, false);
        game.setPedSuffersCriticalHits(Entity, false);
        game.setPedDropsWeaponsWhenDead(Entity, false);
        game.setPedDiesInstantlyInWater(Entity, false);
        game.setPedCanRagdoll(Entity, false);
        game.setPedDiesWhenInjured(Entity, false);
        game.taskSetBlockingOfNonTemporaryEvents(Entity, true);
        game.setPedFleeAttributes(Entity, 0, false);
        game.setPedConfigFlag(Entity, 32, false); // ped cannot fly thru windscreen
        game.setPedConfigFlag(Entity, 281, true); // ped no writhe
        game.setPedGetOutUpsideDownVehicle(Entity, false);
        game.setPedCanEvasiveDive(Entity, false);
        return Entity;
    }
    else {
        alt.log("Model not Loaded " + PedHash);
    }
}
export function frontOfPlayer(distance) {
    try {
        var result = game.getEntityForwardVector(player.scriptID);
        var pos = {
            x: player.pos.x + result.x * distance,
            y: player.pos.y + result.y * distance,
            z: player.pos.z + result.z * distance
        }
        return pos;
    }
    catch{ }
}

export function vnxCreateCEF(Name, Path) {
    for (var Browser in cBrowserList) {
        if (cBrowserList[Browser].Name == Name) {
            return;
        }
    }
    let cPath = "http://resource/VenoXV_Client/";
    let cBrowser = new alt.WebView(cPath + Path);
    cBrowserList[cBrowserId++] = {
        ID: cBrowserId,
        CEF: cBrowser,
        Name: Name,
        Path: Path
    };
    return cBrowser;
}

export function vnxDestroyCEF(Name) {
    for (var Browser in cBrowserList) {
        if (cBrowserList[Browser].Name == Name) {
            if (cBrowserList[Browser].CEF != null) {
                cBrowserList[Browser].CEF.destroy();
                cBrowserList.splice(Browser, 1);
            }
        }
    }
}

export function vnxDestroyAllCEF() {
    let i = cBrowserList.length;
    while (i--) {
        cBrowserList.splice(i, 1);
    }
}