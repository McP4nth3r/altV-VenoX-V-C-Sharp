//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, GetCursorStatus, frontOfPlayer } from '../../Globals/VnX-Lib';
export let XMENU_KEY = 0x58;
let XMenuBrowser;
let EntityType = null;
let XMenuOpen = false;

let XTYPES_VEHICLE = "veh";
let XTYPES_PLAYER = "player";
let XTYPES_SELF = "self";
///////////////////////////////////////////////////////////////////////////////////////

alt.onServer('XMenu:Load', () => {
    if (XMenuBrowser) { return; }
    XMenuBrowser = new alt.WebView("http://resource/VenoXV_Client/Reallife/xmenu/main.html");
    XMenuBrowser.on('XMenu:ButtonApplied', (Button) => {
        if (!XMenuBrowser) { return; }
        if (Button == 9900 || Button == 9901 || Button == 9902) { alt.emitServer('XMenu:ApplyServerButtonVehicle', Button, Hitted); }
        else { alt.emitServer('XMenu:ApplyServerButton', Button, Hitted); }
    });
});

alt.onServer('XMenu:Unload', () => {
    if (!XMenuBrowser) { return; }
    XMenuBrowser.destroy();
    XMenuBrowser = null;
});





function ToggleXMenu(EntityTypeName, EntityID) {
    if (!XMenuBrowser) { return; }
    if (!XMenuOpen) {
        if (!EntityTypeName) { return; }
        XMenuBrowser.emit('XMenu:Open', EntityTypeName);
        XMenuBrowser.focus();
        ShowCursor(true);
        XMenuOpen = true;
    }
    else {
        XMenuOpen = false;
        XMenuBrowser.unfocus();
        ShowCursor(false);
        XMenuBrowser.emit('XMenu:Close');
    }
}





///////////////////////////////////////////////////////////////////////////////////////

export function OnXKeyDown() {
    if (!XMenuBrowser) { return; }
    if (game.isPlayerDead(alt.Player.local.scriptID)) { return; }
    if (!GetCursorStatus()) {
        GetCurrentObject();
        if (alt.Player.local.vehicle) {
            Hitted = alt.Player.local.vehicle;
            ToggleXMenu(XTYPES_VEHICLE, alt.Player.local.vehicle);
            return;
        }
        let type = EntityType;
        if (type == "vehicle") {
            ToggleXMenu(XTYPES_VEHICLE, Hitted);
        }
        else if (type == "player") {
            ToggleXMenu(XTYPES_PLAYER, Hitted);
        }
        else {
            ToggleXMenu(XTYPES_SELF, null);
        }
    }
}
export function OnXKeyUp() {
    if (!XMenuBrowser) { return; }
    ToggleXMenu(null, null);
}



// Sync Stuff : 

let laststring = "";
let Hitted = null;
function GetCurrentObject() {
    if (!XMenuBrowser) { return; }
    let distance = 5;
    let position = alt.Player.local.pos;
    let farAway = frontOfPlayer(distance);
    const hitData = game.startShapeTestRay(position.x, position.y, position.z, farAway.x, farAway.y, farAway.z, 10, -1, alt.Player.local.scriptID);
    const result = game.getShapeTestResult(hitData, undefined, undefined, undefined, undefined);
    const entityTypes = [null, 'ped', 'vehicle', 'object'];
    if (result) {
        if (result[1] != true) { EntityType = null; Hitted = null; return; }
        const handleType = game.getEntityType(result[4]);
        EntityType = entityTypes[handleType];
        Hitted = result[4];
        // Vehicle Type
        if (handleType === 2) {
            Hitted = alt.Vehicle.all.find(v => v.scriptID === Hitted);
            //alt.emitServer('TriggerClientsideVehicle', Hitted);
            return Hitted;
        }
        // Player Type
        if (handleType === 4 || handleType == 8) {
            Hitted = alt.Player.all.find(p => p.scriptID === Hitted);
            return Hitted;
        }
    }
}