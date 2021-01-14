//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import {
    ShowCursor,
    GetCursorStatus,
    vnxCreateCEF,
    vnxDestroyCEF
} from '../../Globals/VnX-Lib';

let InventoryCreated = false;
let InventoryOpen = false;
let InventoryBrowser;

export function OnInventoryKeyPressed(key) {
    try {
        if (key == 0x49) {
            if (!InventoryCreated) return;
            if (GetCursorStatus() && !InventoryOpen) return;
            if (!InventoryOpen) {
                InventoryBrowser.focus();
                ShowCursor(true);
                InventoryBrowser.emit("Inventory:Open");
            } else {
                ShowCursor(false);
                InventoryBrowser.emit("Inventory:Close");
            }
            InventoryOpen = !InventoryOpen;
        }
    } catch {}
}



let Drugs = {
    Weed: "Weed",
    Kokain: "Cocaine",
    WeedSeeds: "Weed-Seeds",
};


let Eatable = {
    TankstellenSnack: "Snack",
    Lebkuchen: "Lebkuchen",
    Milk: "Milk",
    Cookies: "Cookies",
    Wine: "Wine"
};


let VehicleItems = {
    Bezinkanister: "Kanister",
};

//}

let ItemHashes = {
    // Drugs
    1233311452: Drugs.Weed,
    1243355452: Drugs.Kokain,
    1234355453: Drugs.WeedSeeds,
    // Eatable
    1243344492: Eatable.TankstellenSnack,
    1243444492: Eatable.Lebkuchen,
    1243544492: Eatable.Milk,
    1243644492: Eatable.Cookies,
    1243744492: Eatable.Wine,
    //Vehicle 
    1243844452: VehicleItems.Bezinkanister,
};

//Clientside UnitNames = {

let UnitNames = {
    Gramm: "g",
    Kilogramm: "kg",
    Kilo: "Kilo",
    Tonnen: "Tonnen",
    Stueck: "Stueck",
    Liter: "Liter",
}

//}

function GetItemNameByHash(Hash) {
    return ItemHashes[Hash];
}

function GetItemWeightByName(ItemHash, ItemAmount) {
    switch (ItemHash) {
        case Eatable.Lebkuchen:
            return ItemAmount * 1.4;
        case Eatable.TankstellenSnack:
            return ItemAmount * 2.4;
        case VehicleItems.Bezinkanister:
            return ItemAmount * 7.5;
        default:
            return ItemAmount * 0.01;
    }
}

function GetItemUnitByName(ItemHash, ItemAmount) {
    switch (ItemHash) {
        case Eatable.Lebkuchen:
        case Drugs.Weed:
        case VehicleItems.Bezinkanister:
        case Eatable.TankstellenSnack:
            return UnitNames.Kilogramm;
        default:
            if (ItemAmount > 1000) return UnitNames.Kilogramm;
            return UnitNames.Gramm;
    }
}

function GetCompleteItemInfo(ItemName, ItemAmount) {
    return ItemName + "<br>Item Weight : " + GetItemWeightByName(ItemName, ItemAmount).toFixed(2) + " " + GetItemUnitByName(ItemName, ItemAmount);
}



alt.onServer('Inventory:Update', (InventoryJson) => {
    try {
        if (!InventoryCreated) return;
        InventoryBrowser.emit('Inventory:RemoveAll');
        let InventoryItems = JSON.parse(InventoryJson);
        for (let i = 0; i < InventoryItems.length; i++) {
            let data = InventoryItems[i];
            let ItemName = GetItemNameByHash(data.hash);
            InventoryBrowser.emit('Inventory:Update', data.hash, data.amount, ItemName, GetCompleteItemInfo(ItemName, data.amount));
        }
    } catch {}
});

alt.onServer('Inventory:RemoveAll', () => {
    try {
        if (!InventoryCreated) return;
        InventoryBrowser.emit('Inventory:RemoveAll', data.hash, data.amount, ItemName, GetCompleteItemInfo(ItemName, data.amount));
    } catch {}
});


alt.onServer('Inventory:Load', () => {
    try {
        if (InventoryCreated) return;
        InventoryBrowser = vnxCreateCEF("Inventory-Reallife", "Reallife/inventory/main.html", "Reallife");
        InventoryCreated = true;

        InventoryBrowser.on('OnInventoryButtonClicked', (Btn, Hash) => {
            switch (Btn) {
                case 'use':
                    alt.emitServer('Inventory:Use', Hash);
                case 'remove':
                    alt.emitServer('Inventory:Remove', Hash);
            }
        });
    } catch {}
});

alt.onServer('Inventory:Unload', () => {
    try {
        if (!InventoryCreated) {
            return;
        }
        vnxDestroyCEF("Inventory-Reallife");
        InventoryCreated = false;
    } catch {}
});