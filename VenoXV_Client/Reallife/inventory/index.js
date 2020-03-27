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


//Clientside ItemNames = {

let Drugs = {
    Weed: "Weed",
    Kokain: "Kokain",
};
let Eatable = {
    TankstellenSnack: "Snack",
    Lebkuchen: "Lebkuchen",
};
let VehicleItems = {
    Bezinkanister: "Kanister",
};

//}

let ItemHashes = {
    1233311452: Drugs.Weed,
    1243344492: Eatable.TankstellenSnack,
    1243355452: Drugs.Kokain,
    1243444492: Eatable.Lebkuchen,
    1243844452: VehicleItems.Bezinkanister,
};

//Clientside UnitNames = {

let UnitNames = {
    Gramm: "g",
    Kilogramm: "kg",
    Kilo: "Kilo",
    Tonnen: "Tonnen",
    Stück: "Stück",
    Liter: "Liter",
}

//}

function GetItemNameByHash(Hash) {
    return ItemHashes[Hash];
}


function GetCompleteItemInfo(ItemName, Amount) {
    let Desc_Name = "";
    let Desc_Amount = "";
    let Desc_Weight = "";
    let Desc_Unit = "";
    switch (ItemName) {
        // Drugs 
        case Drugs.Weed:
            Desc_Name = ItemName;
            Desc_Amount = Amount;
            Desc_Weight = Amount;
            Desc_Unit = UnitNames.Gramm;
            break;
        case Drugs.Kokain:
            Desc_Name = ItemName;
            Desc_Amount = Amount;
            Desc_Weight = Amount;
            Desc_Unit = UnitNames.Gramm;
            break;

        // Eatable
        case Eatable.Lebkuchen:
            Desc_Name = ItemName;
            Desc_Amount = Amount;
            Desc_Weight = Amount * 1.4;
            Desc_Unit = UnitNames.Kilogramm;
            break;
        case Eatable.TankstellenSnack:
            Desc_Name = ItemName;
            Desc_Amount = Amount;
            Desc_Weight = Amount * 2.4;
            Desc_Unit = UnitNames.Kilogramm;
            break;

        // Vehicle
        case VehicleItems.Bezinkanister:
            Desc_Name = ItemName;
            Desc_Amount = Amount;
            Desc_Weight = Amount * 7.5;
            Desc_Unit = UnitNames.Kilogramm;
            break;
        default:
            Desc_Name = ItemName;
            Desc_Amount = "ERROR";
            Desc_Weight = "ERROR";
            Desc_Unit = "ERROR";
            break;
    }
    return "<br>Item Name : " + Desc_Name + "<br>Item Anzahl : " + Desc_Amount + "<br>Item Gewicht : " + Desc_Weight + Desc_Unit;
}


alt.onServer('Inventory:Update', (InventoryJson) => {
    let InventoryItems = JSON.parse(InventoryJson);
    for (let i = 0; i < InventoryItems.length; i++) {
        let data = InventoryItems[i];
        let ItemName = GetItemNameByHash(data.hash);
        InventoryBrowser.emit('Inventory:Update', data.hash, data.amount, ItemName, GetCompleteItemInfo(ItemName, data.amount));
    }
});

alt.onServer('Inventory:RemoveAll', () => {
    InventoryBrowser.emit('Inventory:RemoveAll', data.hash, data.amount, ItemName, GetCompleteItemInfo(ItemName, data.amount));
});
