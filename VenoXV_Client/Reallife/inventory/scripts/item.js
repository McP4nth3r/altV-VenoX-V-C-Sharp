//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
//Clientside ItemNames = {

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

OnUpdateItems("1233311452", 12, "1233311452", GetCompleteItemInfo(GetItemNameByHash(1233311452), 12));
OnUpdateItems("1234355453", 50, "1234355453", GetCompleteItemInfo(GetItemNameByHash(1234355453), 50));
OnUpdateItems("1243644492", 50, "1243644492", GetCompleteItemInfo(GetItemNameByHash(1243644492), 50));
OnUpdateItems("1243844452", 3, "1243844452", GetCompleteItemInfo(GetItemNameByHash(1243844452), 3));
OnUpdateItems("1243844492", 53, "1243844492", GetCompleteItemInfo(GetItemNameByHash(1243844492), 53));
OnUpdateItems("1244044492", 12, "1244044492", GetCompleteItemInfo(GetItemNameByHash(1244044492), 12));
OnUpdateItems("1244044492", 14, "1244044492", GetCompleteItemInfo(GetItemNameByHash(1244044492), 14));
OnUpdateItems("PistolAmmo", 11, "PistolAmmo", GetCompleteItemInfo("PistolAmmo", 11));


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