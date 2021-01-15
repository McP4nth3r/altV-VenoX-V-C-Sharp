//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
//Clientside ItemNames = {
/*
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
*/
OnUpdateItems("Weed", 12, "Drugs", "Not setted by Server");
OnUpdateItems("Weed-Seeds", 50, "Useable", "Not setted by Server");
OnUpdateItems("Cookie", 50, "Eatable", "Not setted by Server");
OnUpdateItems("Petrolcan", 3, "Useable", "Not setted by Server");
OnUpdateItems("Ribs", 53, "Eatable", "Not setted by Server");
OnUpdateItems("Milkshake", 12, "Eatable", "Not setted by Server");
OnUpdateItems("Carbinerifle", 11, "Gun", "Not setted by Server");
OnUpdateItems("Rpg", 11, "Gun", "Not setted by Server");
OnUpdateItems("Pumpshotgun-Mk2", 11, "Gun", "Not setted by Server");
OnUpdateItems("Smg", 11, "Gun", "Not setted by Server");
OnUpdateItems("Sawnoffshotgun", 11, "Gun", "Not setted by Server");
OnUpdateItems("Machinepistol", 11, "Gun", "Not setted by Server");
OnUpdateItems("Pistol-Mk2", 11, "Gun", "Not setted by Server");
OnUpdateItems("cap", 11, "Clothes", "Not setted by Server");
OnUpdateItems("chain", 11, "Clothes", "Not setted by Server");
OnUpdateItems("shirt", 11, "Clothes", "Not setted by Server");
OnUpdateItems("jeans", 11, "Clothes", "Not setted by Server");
OnUpdateItems("shoes", 11, "Clothes", "Not setted by Server");


function UpdateInventoryWeight() {
    let ItemArray = GetAllItems();
    let InventoryWheight = 0;
    for (var Items in ItemArray) {
        let weight = GetItemWeightByName(GetItemNameByHash(ItemArray[Items].Hash), ItemArray[Items].Amount);
        InventoryWheight += weight;
    }
    console.log(InventoryWheight);
    UpdateInventoryAmountBar(InventoryWheight);
}

setTimeout(() => {
    UpdateInventoryWeight()
}, 250);


// 