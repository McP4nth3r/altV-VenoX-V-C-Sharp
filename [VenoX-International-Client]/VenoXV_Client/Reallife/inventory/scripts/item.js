//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

//OnUpdateItems("Weed", 12, "Drugs", 0.1);
// /giveitem Weed 1 1 0.1

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