//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
let player = alt.Player.local;
let cursor = false;
let cBrowserList = {};
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
    } catch {}
}
export function GetCursorStatus() {
    try {
        if (cursor || alt.isConsoleOpen()) {
            return true;
        } else {
            return false;
        }
    } catch {}
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
        if (ColorRGB == undefined || ColorRGB == null) {
            ColorRGB = 255;
        }
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
    } catch {}
}
export function Draw3DText(msg, x, y, z, fontType, color, range = 20, useOutline = true, useDropShadow = true, CustomScale = 0.4) {
    try {
        const [bol, _x, _y] = game.getScreenCoordFromWorldCoord(x, y, z);
        const camCord = game.getFinalRenderedCamCoord();
        const dist = game.getDistanceBetweenCoords(camCord.x, camCord.y, camCord.z, x, y, z, 1)


        if (dist > range) return;

        let scale = (4.00001 / dist) * CustomScale
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
    } catch {}
}
export function CreateBlip(name, pos, sprite, color, shortrange) {
    try {
        let blip = game.addBlipForCoord(pos[0], pos[1], pos[2]);
        game.setBlipAlpha(blip, 255);
        game.setBlipSprite(blip, sprite);
        game.setBlipColour(blip, color);
        game.setBlipAsShortRange(blip, shortrange);
        game.beginTextCommandSetBlipName("STRING");
        game.addTextComponentSubstringPlayerName(name);
        game.endTextCommandSetBlipName(blip);
        return blip;
    } catch {}
}



export function CreatePed(PedName, Vector3Pos, rot = 0) {
    try {
        let PedHash = game.getHashKey(PedName);
        if (!game.hasModelLoaded(PedHash)) {
            alt.loadModel(PedHash);
            game.requestModel(PedHash);
        }
        if (game.hasModelLoaded(PedHash)) {
            let Entity = game.createPed(2, PedHash, Vector3Pos.x, Vector3Pos.y, Vector3Pos.z - 1, rot, false, false);
            alt.setTimeout(() => {
                game.freezeEntityPosition(Entity, true);
            }, 3000);
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
        } else {
            alt.log("Model not Loaded " + PedHash);
        }
    } catch {}
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
    } catch {}
}

export function vnxCreateCEF(Name, Path) {
    try {
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
    } catch (e) {
        alt.log("Error Creating CEF Window : " + e);
        return null;
    }
}

export function vnxDestroyCEF(Name) {
    try {
        for (var Browser in cBrowserList) {
            if (cBrowserList[Browser].Name == Name) {
                if (cBrowserList[Browser].CEF != null)
                    cBrowserList[Browser].CEF.destroy();
                delete cBrowserList[Browser];
            }
        }
    } catch (e) {
        alt.log("Error Destroying CEF Window : " + e);
    }
}

export function vnxDestroyAllCEF() {
    for (var Browser in cBrowserList) {
        cBrowserList[Browser].CEF.destroy();
        delete cBrowserList[Browser];
    }
}

export function GetCurrentDateTime() {
    var date = new Date();
    var day = date.getDate(); // yields date
    var month = date.getMonth() + 1; // yields month (add one as '.getMonth()' is zero indexed)
    var year = date.getFullYear(); // yields year
    var hour = date.getHours(); // yields hours 
    var minute = date.getMinutes(); // yields minutes
    var second = date.getSeconds(); // yields seconds

    // After this construct a string with the above results as below
    var time = day + "." + month + "." + year + " " + hour + ':' + minute + ':' + second;
    //DateTime.ParseExact(YourString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    return time;
}

export function GetCurrentDateTimeString() {
    var date = new Date();
    var day = date.getDate(); // yields date
    var month = date.getMonth() + 1; // yields month (add one as '.getMonth()' is zero indexed)
    var year = date.getFullYear(); // yields year
    var hour = date.getHours(); // yields hours 
    var minute = date.getMinutes(); // yields minutes
    var second = date.getSeconds(); // yields seconds

    // After this construct a string with the above results as below
    var time = day + "." + month + "." + year + " " + hour + ':' + minute + ':' + second;
    return time;
}





let CountdownState = -1;
let CountdownEntityFrozen = false;
let TimeOut;
let ShowCountdownTick = false;
export function ShowCountdown(Seconds) {
    CountdownState = Seconds;
    alt.setTimeout(() => {
        CountdownEntityFrozen = false;
        if (!CountdownEntityFrozen) {
            if (player.vehicle) game.freezeEntityPosition(player.vehicle.scriptID, true);
            game.freezeEntityPosition(player.scriptID, true);
            CountdownEntityFrozen = true;
        }
    }, 350);
    TimeOut = alt.setInterval(() => {
        if (CountdownState > 0) {
            CountdownState -= 1;
            if (CountdownState <= 0) {
                if (TimeOut) {
                    alt.clearInterval(TimeOut);
                    TimeOut = null;
                }
                if (CountdownEntityFrozen) {
                    if (player.vehicle) game.freezeEntityPosition(player.vehicle.scriptID, false);
                    game.freezeEntityPosition(player.scriptID, false);
                    CountdownEntityFrozen = false;
                    alt.setTimeout(() => {
                        ShowCountdownTick = false;
                    }, 1250);
                }
            }
        }
    }, 1250);
    ShowCountdownTick = true;
}

alt.everyTick(() => {
    if (!ShowCountdownTick) return;
    if (CountdownState > 0) {
        DrawText(CountdownState + "...", [0.5, 0.5], [1, 1], 0, [255, 255, 255, 255], true, true);
    } else {
        DrawText("GO!", [0.5, 0.5], [1, 1], 0, [0, 200, 255, 255], true, true);
    }
});