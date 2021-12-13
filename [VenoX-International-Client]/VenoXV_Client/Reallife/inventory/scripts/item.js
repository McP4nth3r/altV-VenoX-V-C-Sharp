//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//



/*
let ItemTypes = {}
ItemTypes[0] = "Drugs";
ItemTypes[1] = "Useable";
ItemTypes[2] = "Clothes";
ItemTypes[3] = "Gun";


OnUpdateItems(1, "Weed", 12, 0, 0.1);
OnUpdateItems(2, "AdvancedRifle", 12, 3, 0.1);
OnUpdateItems(3, "Shirt", 1, 2, 0.5);
OnUpdateItems(45, "shoes", 1, 2, 0.5);
*/

function UpdateInventoryWeight() {
    let ItemArray = GetAllItems();
    let InventoryWheight = 0;
    for (var Items in ItemArray) {
        InventoryWheight += parseFloat(ItemArray[Items].Weight * ItemArray[Items].Amount);
    }
    UpdateInventoryAmountBar(parseFloat(InventoryWheight));
}

setTimeout(() => {
    UpdateInventoryWeight()
}, 250);


// 