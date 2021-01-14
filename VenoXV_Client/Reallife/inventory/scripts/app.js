let ColumnCount = 48;
let CurrentInventorySpace = 30;
// Init columns.
for (let i = 0; i < ColumnCount; i++) {
    $('.inventar_column_container').append(`<div class="column"><div class="column_amount"></div><div class="info d-none"></div><div class="OptionsMenu d-none"><div class="OptionsButtonsUse" onclick="OnInventoryButtonPressed('use ');">Benutzen</div><div class="OptionsButtonsDelete" onclick="OnInventoryButtonPressed('remove');">Wegwerfen</div></div></div>`);
}

// After initializing stuff.
var drop_area1 = $(".drop_area1");
var drop_area2 = $(".drop_area2");
var drop_area3 = $(".drop_area3");
var drop_area4 = $(".drop_area4");
var box = $(".column");
var mainCanvas = $(".columns");

let ClickedOnItem = false;
let LastItemClicked = null;
var CurrentInventoryItems = [];

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

function ItemExists(itemName) {
    for (let i = 0; i < CurrentInventoryItems.length; i++) {
        if (CurrentInventoryItems[i] == itemName) return true;
    }
    CurrentInventoryItems.push(itemName);
    return false;
}

function OnUpdateItems(hash, amount, itemname, iteminfo) {
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let name = $(col).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');


        if (text == 'style.css') {
            if (!ItemExists(itemname)) {
                $(col).css('background-image', 'url("./files/images/' + hash + '.png")');
                $(col).children('.column_amount').html(amount.toString());
                $(col).children('.info').html(iteminfo);
            }
        }
    });
}

function RemoveAllItems() {
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let name = $(col).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        CurrentInventoryItems = [];
        if (text != 'style.css') {
            $(col).css('background-image', 'url("style.css")');
            $(col).children('.column_amount').html("");
            $(col).children('.info').html("");
        }
    });
}

function GetAllItems() {
    let Items = {};
    let ItemCounter = 0;
    var cols = document.querySelectorAll('#columns .column');
    [].forEach.call(cols, function (col) {
        let name = $(col).css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        let TextHash = text.split('.').slice(0, -1).join('.');
        if (text != 'style.css') {
            Items[ItemCounter] = {
                Hash: TextHash,
                Image: $(col).css('background-image'),
                Amount: $(col).children('.column_amount').text(),
                Info: $(col).children('.info').text()
            }
            ItemCounter++;
        }
    });
    return Items;
}


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
        var draggable = ui.draggable;
        var dropped = $(this);

        let name = draggable.css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        if (text == "style.css") return;

        let draggableContent = draggable.html();
        let draggableStyle = draggable.attr('style');
        if (!draggableStyle) draggableStyle = "";

        let droppedContent = dropped.html();
        let droppedStyle = dropped.attr('style');
        if (!droppedStyle) droppedStyle = "";

        dropped.html(draggableContent);
        dropped.attr('style', draggableStyle);

        draggable.html(droppedContent);
        draggable.attr('style', droppedStyle);

        draggable.removeClass('over');
        dropped.removeClass('over');

        //dropped[0].outerHTML;
        //console.log(droppedContent);
        //console.log(droppedStyle);
        //console.log(draggableContent);
        //console.log(draggableStyle);
        /*dropped.replaceWith(draggableContent);
        draggable.replaceWith(droppableContent);*/
    },

    over: function (event, ui) {
        let name = ui.draggable.css('background-image');
        let patt = /\"|\'|\)/g;
        let text = name.split('/').pop().replace(patt, '');
        if (text == "style.css") return;
        $(this).addClass('over');
        //$(this).css("opacity", "0");
    },

    out: function (event, ui) {
        if ($(this).css('background-image') == '') return;
        $(this).removeClass('over');
    }
});

function DropItem(Draggable, ItemHash, ItemAmount) {
    let name = ItemHash;
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    let TextHash = text.split('.').slice(0, -1).join('.');
    //console.log(TextHash, ItemAmount);
    //alt.emit('Inventory:DropItem', ItemHash, ItemAmount);
    $(Draggable).css('background-image', 'url("style.css")');
    $(Draggable).children('.column_amount').html("");
    $(Draggable).children('.info').html("");
    setTimeout(() => {
        UpdateInventoryWeight();
    }, 250);
}

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


function OnInventoryButtonPressed(Btn) {
    if (!LastItemClicked) return;
    let name = LastItemClicked.css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css') return;
    alt.emit('OnInventoryButtonClicked', Btn, text);
}

function UpdateInventoryAmountBar(CurrentlyInInventory) {
    $('.Inventory_Amount_Bar').animate({
        width: (CurrentlyInInventory.toFixed(0) * 100) / CurrentInventorySpace + "%"
    });

    console.log(((CurrentlyInInventory * 100) / 100) + " | Amount");
    $('.Inventory_Amount_Amount').text(CurrentlyInInventory.toFixed(2) + " kg / " + CurrentInventorySpace.toFixed(2) + " kg.");
}