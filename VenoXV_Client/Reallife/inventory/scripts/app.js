//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

// Variables : 

let ClickedOnItem = false;
let LastItemClicked = null;
let CurrentInventoryItems = {};

let ClothesColumnId = "ClothesColumn";
let ClothesColumnString = `<div class="column" id="` + ClothesColumnId + `" data-ItemId="-1"><div class="column_amount"></div><div class="info d-none"></div><div class="OptionsMenu d-none"><div class="OptionsButtonsUse" onclick="OnInventoryButtonPressed('use ');">Use</div><div class="OptionsButtonsDelete" onclick="OnInventoryButtonPressed('remove');">Drop</div></div></div>`;
let GunColumnId = "GunColumn";
let GunColumnString = `<div class="column" id="` + GunColumnId + `" data-ItemId="-1"><div class="column_amount"></div><div class="info d-none"></div><div class="OptionsMenu d-none"><div class="OptionsButtonsUse" onclick="OnInventoryButtonPressed('use ');">Use</div><div class="OptionsButtonsDelete" onclick="OnInventoryButtonPressed('remove');">Drop</div></div></div>`;

let ItemTypes = {}
ItemTypes[0] = "Drugs";
ItemTypes[1] = "Useable";
ItemTypes[2] = "Clothes";
ItemTypes[3] = "Gun";

// Settings : 

let ClothesColumnCount = 5; //Maximum Clothe-Slots Columns.
let GunSlotColumnCount = 5; // Maximum Gun-Slots Columns.
let ColumnCount = 48; // Maximum Inventory Columns
let CurrentInventorySpace = 30; // Maximum KG in inventory.

// Column Init.

// Init columns.
for (let i = 0; i < ClothesColumnCount; i++) {
    $('.InventoryCharacterClothebar').append(ClothesColumnString);
}
for (let i = 0; i < GunSlotColumnCount; i++) {
    $('.InventoryCharacterWeaponbar').append(GunColumnString);
}
for (let i = 0; i < ColumnCount; i++) {
    $('.inventar_column_container').append(`<div class="column" data-ItemId="-1"><div class="column_amount"></div><div class="info d-none"></div><div class="OptionsMenu d-none"><div class="OptionsButtonsUse" onclick="OnInventoryButtonPressed('use ');">Use</div><div class="OptionsButtonsDelete" onclick="OnInventoryButtonPressed('remove');">Drop</div></div></div>`);
}

// After initializing stuff.
let drop_area1 = $(".drop_area1");
let drop_area2 = $(".drop_area2");
let drop_area3 = $(".drop_area3");
let drop_area4 = $(".drop_area4");
let box = $(".column");
let mainCanvas = $(".columns");



////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////JQuery - Events/////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////

/* Use Item / Remove Item */
box.click(function () {
    let name = $(this).css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css') return;


    if (LastItemClicked != null) {
        LastItemClicked.children('.OptionsMenu').addClass('d-none');
        LastItemClicked = null;
        ClickedOnItem = false;
        return;
    }
    $(this).children('.OptionsMenu').removeClass('d-none');
    $(this).children('.info').addClass('d-none');
    ClickedOnItem = true;
    LastItemClicked = $(this);
});

/* Hover */
box.mouseover(function (e, ui) {
    let name = $(this).css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css' || ClickedOnItem) return;
    $(this).children('.info').removeClass('d-none');
});

box.mouseout(function (e, ui) {
    $(this).children('.info').addClass('d-none');
});

/* Dragable */
box.draggable({
    containment: mainCanvas,
    helper: "clone",

    start: function (event, ui) {
        let name = $(this).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        if (text == 'style.css') return false;
    },

    drag: function (event, ui) {
        //console.log("drag");
        //if($(this).css('background-image') == ''){ return;}
    },

    stop: function () {
        $(this).css({
            opacity: 1
        });
    }
});

box.droppable({
    drop: function (event, ui) {
        let DragPoint = $(this);
        let DropPoint = ui.draggable;
        let DragPointId = $(this).attr('id');
        let DropPointId = ui.draggable.attr('id');

        // Remove Hovers
        DragPoint.removeClass('overgreen');
        DropPoint.removeClass('overgreen');
        DragPoint.removeClass('overred');
        DropPoint.removeClass('overred');

        if (DragPointId == GunColumnId && DropPointId != "Gun")
            return false;
        else if (DragPointId == ClothesColumnId && DropPointId != "Clothes")
            return false;
        else {
            // Creating Drag-Point Copy
            let DragId = DragPoint.attr('id');
            let DropId = DropPoint.attr('id');

            // Item Id 
            let DragItemId = DragPoint.data('ItemId');
            let DropItemId = DropPoint.data('ItemId');
            //
            let DragPointContent = DragPoint.html();
            let DragPointStyle = DragPoint.attr('style');
            if (!DragPointStyle) DragPointStyle = '';

            // Creating Drop-Point Copy
            let DropPointContent = DropPoint.html();
            let DropPointStyle = DropPoint.attr('style');
            if (!DropPointStyle) DropPointStyle = '';

            // Swapping the Items : 
            DragPoint.html(DropPointContent);
            DragPoint.attr('style', DropPointStyle);
            DragPoint.data('ItemId', DropItemId);


            DropPoint.html(DragPointContent);
            DropPoint.attr('style', DragPointStyle);
            DropPoint.data('ItemId', DragItemId);

            // Fix ID - Spawn
            if (DragId == undefined || DragId == '') {
                DropPoint.attr('id', "");
                if (DropPointId == GunColumnId) {
                    DropPoint.attr('id', GunColumnId);
                    DragPoint.attr('id', "Gun");
                } else if (DropPointId == ClothesColumnId) {
                    DropPoint.attr('id', ClothesColumnId);
                    DragPoint.attr('id', "Clothes");
                    console.log(DragPoint.data('ItemId') + " is now not more active!")
                    if ('alt' in window)
                        alt.emit('Inventory:UseItem', parseInt(DragPoint.data('ItemId')));
                } else
                    DragPoint.attr('id', DropPointId);
            } else if (DragId == GunColumnId || DragId == ClothesColumnId) {
                DragPoint.attr('id', DragId);
                DropPoint.attr('id', DropId);
                console.log(DropPoint.data('ItemId') + " is now active!")
                if ('alt' in window)
                    alt.emit('Inventory:UseItem', parseInt(DropPoint.data('ItemId')));
            } else if (DropId.length > 0) {
                DragPoint.attr('id', DropId);
                DropPoint.attr('id', DragId);
            }
            setTimeout(() => {
                ClearCachedIds();
            }, 250);
        }
    },

    over: function (event, ui) {
        let DragPoint = $(this).attr('id');
        let DropPoint = ui.draggable.attr('id');
        if (DragPoint == GunColumnId && DropPoint != "Gun")
            return $(this).addClass('overred');
        else if (DragPoint == ClothesColumnId && DropPoint != "Clothes")
            return $(this).addClass('overred');
        else
            $(this).addClass('overgreen');
    },

    out: function (event, ui) {
        $(this).removeClass('overgreen');
        $(this).removeClass('overred');
    }
});

drop_area1.droppable({
    drop: function (event, ui) {
        var draggable = ui.draggable;
        DropItem(draggable, $(draggable).css('background-image'), $(draggable).children('.column_amount').text());
    }
});
drop_area2.droppable({
    drop: function (event, ui) {
        var draggable = ui.draggable;
        DropItem(draggable, $(draggable).css('background-image'), $(draggable).children('.column_amount').text());
    }
});
drop_area3.droppable({
    drop: function (event, ui) {
        var draggable = ui.draggable;
        DropItem(draggable, $(draggable).css('background-image'), $(draggable).children('.column_amount').text());
    }
});
drop_area4.droppable({
    drop: function (event, ui) {
        var draggable = ui.draggable;
        DropItem(draggable, $(draggable).css('background-image'), $(draggable).children('.column_amount').text());
    }
});


////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////JQuery - Functions//////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////
function ClearCachedIds() {
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let ColId = $(col).attr('id');
        if (ColId && ColId.length > 1) {
            if (ColId != ClothesColumnId && ColId != GunColumnId) {
                let name = $(col).css('background-image');
                let patt = /\"|\'|\)/g;
                let text = name.split('/').pop().replace(patt, '');
                if (text == 'style.css') {
                    $(col).attr('id', '');
                }
            }
        }
    });
}


// called if item is being dropped out of inventory.
function DropItem(Draggable, ItemHash, ItemAmount) {
    let DroppedItemId = $(Draggable).attr('id');
    if (DroppedItemId == GunColumnId || DroppedItemId == ClothesColumnId) return;
    let name = ItemHash;
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    let TextHash = text.split('.').slice(0, -1).join('.');
    $(Draggable).css('background-image', 'url("style.css")');
    $(Draggable).children('.column_amount').html("");
    $(Draggable).children('.info').html("");
    delete CurrentInventoryItems[TextHash];
    setTimeout(() => {
        UpdateInventoryWeight();
        if ('alt' in window)
            alt.emit('Inventory:DropItem', TextHash, ItemAmount);
    }, 250);
}

// called if a column got pressed
function OnInventoryButtonPressed(Btn) {
    if (!LastItemClicked) return;
    let name = LastItemClicked.css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css') return;
    if ('alt' in window)
        alt.emit('OnInventoryButtonClicked', Btn, text);
}
// called Inventory Bar Update.
function UpdateInventoryAmountBar(CurrentlyInInventory) {
    let Calculation = ((CurrentlyInInventory.toFixed(0) * 100) / CurrentInventorySpace);
    if (Calculation > 100) Calculation = 100;
    $('.Inventory_Amount_Bar').animate({
        width: Calculation + "%"
    });
    //console.log(((CurrentlyInInventory * 100) / 100) + " | Amount");
    $('.Inventory_Amount_Amount').text(CurrentlyInInventory.toFixed(2) + " kg / " + CurrentInventorySpace.toFixed(2) + " kg.");
}

// called to check if Item Exists.
function ItemExists(itemName) {
    if (CurrentInventoryItems[itemName]) return true;
    return false;
}


function AddItem(id, hash, amount, itemtype, weight) {
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let name = $(col).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        if (text == 'style.css') {
            if (!ItemExists(hash)) {
                $(col).css('background-image', 'url("./files/images/' + hash + '.png")');
                $(col).attr('id', ItemTypes[parseInt(itemtype)]);
                $(col).children('.column_amount').html(amount.toString());
                $(col).children('.info').html(hash + "<br>Item Weight : " + (weight * amount).toFixed(2) + " kg");
                CurrentInventoryItems[hash] = {
                    Id: id,
                    Element: col,
                    Hash: hash,
                    Image: $(col).css('background-image'),
                    Amount: $(col).children('.column_amount').text(),
                    Info: $(col).children('.info').text(),
                    Weight: weight
                }
                UpdateInventoryWeight();
                $(col).data('ItemId', id);
                return;
            }
        }
    });
}

function UpdateItem(id, hash, amount, weight) {
    if (!CurrentInventoryItems[id].Element) return;
    $(CurrentInventoryItems[id].Element).children('.column_amount').html(amount.toString());
    $(CurrentInventoryItems[id].Element).children('.info').html(hash + "<br>Item Weight : " + (weight * amount).toFixed(2) + " kg");
    CurrentInventoryItems[id].Weight = weight;
    CurrentInventoryItems[id].Amount = amount;
    UpdateInventoryWeight();
    console.log('Updated');
}


// called if a new item got inserted.
function OnUpdateItems(id, hash, amount, itemtype, weight) {
    if (!ItemExists(id)) AddItem(id, hash, amount, itemtype, weight);
    else UpdateItem(id, hash, amount, weight);
}


// called if All items should be removed.
function RemoveAllItems() {
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let name = $(col).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        if (text != 'style.css') {
            $(col).css('background-image', 'url("style.css")');
            $(col).children('.column_amount').html("");
            $(col).children('.info').html("");
        }
    });
    CurrentInventoryItems = {};
}

function GetAllItems() {
    return CurrentInventoryItems;
}