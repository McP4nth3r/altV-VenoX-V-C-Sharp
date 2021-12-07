//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let CloseText = "back";
let LastWindowOpen;

function FillModList(Name) {
    $('.Tuning-Window-Home').append('<div class="Column">' + Name + '<img class="Column-Image" src="files/images/' + Name + '.png"></div>');
}

function ShowHomescreen() {
    $('.Tuning-Window-Home').removeClass('d-none');
    if (LastWindowOpen) {
        $('.Tuning-Window-List-' + LastWindowOpen).addClass('d-none');
        $('#back').remove();
    }
    return;
}

FillModList("Spoiler");
FillModList("Front-Karosserie");
FillModList("Heck-Karosserie");
FillModList("Seitenschweller");
FillModList("Auspuff");
FillModList("Motor");
FillModList("Turbo");
FillModList("Getriebe");
FillModList("Tieferlegung");
FillModList("Bremsen");
FillModList("Scheiben");
FillModList("Xenon");
FillModList("Farbe");

$('.Column').click(function (element) {
    let ElementName = $(this).text();
    $('.Tuning-Window-Home').addClass('d-none');
    LastWindowOpen = ElementName;
    $('.Tuning-Window-List-' + ElementName).removeClass('d-none');
    switch (ElementName) {
        case "Farbe":
            $('.Tuning-Window-List-' + ElementName).append('<div id="back" class="VnX-Button" style="top: 90%; width: 80%;" onclick="ShowHomescreen()">' + CloseText + '</div>');
            break;
        default:
            $('.Tuning-Window-List-' + ElementName).append('<div id="back" class="Column" onclick="ShowHomescreen()">' + CloseText + '<img class="Column-Image" src="files/images/cross.png" ></div>');
            break;
    }
});


function FillList(Name, Price) {
    $('.Tuning-Window-List-' + Name).append('<div class="Column">' + Name + '<img class="Column-Image" src="files/images/' + Name + '.png"><div class="Column-Price">' + Price + '</div></div>');
}
FillList('Spoiler', 1000);
