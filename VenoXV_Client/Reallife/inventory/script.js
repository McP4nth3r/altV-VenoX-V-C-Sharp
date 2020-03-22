var box = $(".column");
var mainCanvas = $(".columns");

box.mouseover(function(e, ui) {


	$(this).children().children().removeClass('d-none');
	
});


box.mouseout(function(e, ui) {
    $(this).children().children().addClass('d-none');
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
        if (text == "style.css") {return;}

        $(this).addClass('over');
        //$(this).css("opacity", "0");
    },

    out: function (event, ui) {
        if ($(this).css('background-image') == '') { return; }
        $(this).removeClass('over');
    }
});