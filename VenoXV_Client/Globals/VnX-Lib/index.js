
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
let player = alt.Player.local;
let cursor = false;
export function ShowCursor(bool) {
    if (cursor == false && bool == false || cursor == true && bool == true) {
        return;
    }
    alt.toggleGameControls(!bool);
    alt.showCursor(bool);
    cursor = bool;
}
export function GetCursorStatus() {
    if (cursor) { return true; }
    else { return false; }
}

export function DrawText(msg, screenPos, scale, fontType, ColorRGB, useOutline = true, useDropShadow = true, layer = 0, align = 0) {
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








export function Draw3DText(msg, pos, fontType, color, scale, range, useOutline = true, useDropShadow = true, layer = 0) {
    alt.log(msg + " | " + pos + " | " + fontType + " | " + color + " | " + scale + " | " + range)
    let hex = msg.match('{.*}');
    if (hex) {
        const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
        color[0] = rgb[0];
        color[1] = rgb[1];
        color[2] = rgb[2];
        msg = msg.replace(hex[0], '');
    }

    native.setDrawOrigin(pos[0], pos[1], pos[2], 0);
    native.beginTextCommandDisplayText('STRING');
    native.addTextComponentSubstringPlayerName(msg);
    native.setTextFont(fontType);
    native.setTextScale(1, scale);
    native.setTextWrap(0.0, 1.0);
    native.setTextCentre(true);
    native.setTextColour(color[0], color[1], color[2], color[3]);

    if (useOutline) native.setTextOutline();

    if (useDropShadow) native.setTextDropShadow();

    native.endTextCommandDisplayText(0, 0);
    native.clearDrawOrigin();
}

export function CreateBlip(name, pos, sprite, color, shortrange) {
    let blip = new alt.PointBlip(pos[0], pos[1], pos[2]);
    blip.alpha = 10;
    blip.sprite = sprite;
    blip.color = color;
    blip.shortRange = shortrange;
    blip.name = name;
}

export function CreatePed(PedName, Vector3Pos, rot) {
    game.createPed(0, alt.hash(PedName), Vector3Pos[0], Vector3Pos[1], Vector3Pos[2], rot, 0, 0);
}


export function getOffset(x, y, z, rz, rx, ry, offX, offY, offZ) {
    let pos = [];

    pos[0] = (cos(rz) * sin(ry) + cos(ry) * sin(rz) * sin(rx)) * offZ + (-cos(rx) * sin(rz)) * offY + (cos(rz) * cos(ry) - sin(rz) * sin(rx) * sin(ry)) * offX + x;
    pos[1] = (sin(rz) * sin(ry) - cos(rz) * cos(ry) * sin(rx)) * offZ + (cos(rz) * cos(rx)) * offY + (cos(ry) * sin(rz) + cos(rz) * sin(rx) * sin(ry)) * offX + y;
    pos[2] = (cos(rx) * cos(ry)) * offZ + (sin(rx)) * offY + (-cos(rx) * sin(ry)) * offX + z;

    return pos;
}