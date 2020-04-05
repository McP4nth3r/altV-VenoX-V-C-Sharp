var box = $(".column");
var mainCanvas = $(".columns");

let ClickedOnItem = false;
let LastItemClicked = null;


box.click(function () {
    let name = $(this).css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css') { return; }

    if (LastItemClicked != null) { LastItemClicked.children('.OptionsMenu').addClass('d-none'); LastItemClicked = null; ClickedOnItem = false; return; }
    $(this).children('.OptionsMenu').removeClass('d-none');
    $(this).children('.info').addClass('d-none');
    ClickedOnItem = true;
    LastItemClicked = $(this);
});


box.mouseover(function (e, ui) {
    let name = $(this).css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');

    if (text == 'style.css') { return; }
    else if (ClickedOnItem) { return; }
    $(this).children('.info').removeClass('d-none');
});


var CurrentInventoryItems = [];
function ItemExists(itemName) {
    for (let i = 0; i < CurrentInventoryItems.length; i++) {
        if (CurrentInventoryItems[i] == itemName) {
            return true;
        }
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

box.mouseout(function (e, ui) {
    $(this).children('.info').addClass('d-none');
});


box.draggable({
    containment: mainCanvas,
    helper: "clone",

    start: function (event, ui) {
        if ($(this).css('background-image') == '') { return; }
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
        if (text == "style.css") { return; }


        let draggableContent = draggable.html();
        let draggableStyle = draggable.attr('style');
        if (!draggableStyle) { draggableStyle = ""; }

        let droppedContent = dropped.html();
        let droppedStyle = dropped.attr('style');
        if (!droppedStyle) { droppedStyle = ""; }

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
        if (text == "style.css") { return; }

        $(this).addClass('over');
        //$(this).css("opacity", "0");
    },

    out: function (event, ui) {
        if ($(this).css('background-image') == '') { return; }
        $(this).removeClass('over');
    }
});

function OnInventoryButtonPressed(Btn) {
    if (!LastItemClicked) { return; }
    let name = LastItemClicked.css('background-image');
    let patt = /\"|\'|\)/g;
    let text = name.split('/').pop().replace(patt, '');
    if (text == 'style.css') { return; }

    alt.emit('OnInventoryButtonClicked', Btn, text);
}