//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, GetCursorStatus } from '../../Globals/VnX-Lib';
let InventoryOpen = false;
let InventoryBrowser = new alt.WebView("http://resource/VenoXV_Client/Reallife/inventory/main.html");

export function OnInventoryKeyPressed(key) {
    if (key == 0x49) {
        if (!InventoryOpen) { if (!GetCursorStatus()) { InventoryBrowser.focus(); ShowCursor(true); InventoryBrowser.emit("Inventory:Open"); } }
        else { ShowCursor(false); InventoryBrowser.emit("Inventory:Close"); }
        InventoryOpen = !InventoryOpen;
    }
}