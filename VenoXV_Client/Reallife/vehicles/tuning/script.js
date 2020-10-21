//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

/* Tuning */
var CurTuningMenuWindow = "none",
    SelectedVehicleTuningMenuColorBoxModtype = "none";

function ShowACLSTuningMenuWindow(subwindow, modtype) {
    if (CurTuningMenuWindow != "none") {
        document.getElementById(CurTuningMenuWindow).style.display = "none";
    }
    document.getElementById(subwindow).style.display = "block";
    CurTuningMenuWindow = subwindow;
    SelectedVehicleTuningMenuColorBoxModtype = modtype;
}

function closeTuningSubWindow(subwindow) {
    document.getElementById(subwindow).style.display = "none";
}

function closeTuningMenuCEF() {
    $("#VehicleTuningMainMenuBox").fadeOut(100, function () {
        $("#VehicleTuningMainMenuBox").hide();
        $("#VehicleTuningMenuColorSelection").hide();
        alt.emit("Tuning:Destroy");
    });
}

function VehicleTuningMenuColorSelectionTestColor(install) {
    var r = $("#rgbRvalField").val();
    var g = $("#rgbGvalField").val();
    var b = $("#rgbBvalField").val();
    if (install) {
        alt.emit("Client:Tuning:switchTuningColor", "Build", SelectedVehicleTuningMenuColorBoxModtype, r, g, b);
    } else {
        alt.emit("Client:Tuning:switchTuningColor", "Test", SelectedVehicleTuningMenuColorBoxModtype, r, g, b);
    }
}

function SwitchTuning(Type, ID, Action) {
    alt.emit("Client:Tuning:switchTuning", Type, ID, Action);
}

function openVehicleTuningMenu(Items) {
    var items = Items.split(";");
    var html = "";

    for (var i = 0; i < items.length; i++) {
        var itemValues = items[i].split(":");
        var modTyp = itemValues[0];
        var modTypeID = itemValues[1];

        html += `<li><span class='title'>${modTyp}</span><img src='../test.png'>`;

        if (modTyp.match("Neonröhren") || modTyp.match("Reifenqualm")) {
            html += "<span class='actionbtn' onclick='ShowACLSTuningMenuWindow(`VehicleTuningMenuColorSelection`, `" + modTyp + "`);'>Farbe auswählen</span>";
        } else {
            html += "<div class='far-div1' onclick='SwitchTuning(`Preview` ,`" + modTypeID + "`, `>`);'><i class='far fa-arrow-alt-circle-right'></i></div>" +
                "<div class='far-div2' onclick='SwitchTuning(`Preview` ,`" + modTypeID + "`, `<`);'> <i class='far fa-arrow-alt-circle-left'></i></div>" +
                "<span class='actionbtn' onclick='SwitchTuning(`Build` ,`" + modTypeID + "`, `>`);'>Montieren</span>";
        }
        html += "</li>";
    }

    $("#VehicleTuningMainMenuBoxList").html(html);
    $("#VehicleTuningMainMenuBox").fadeTo(1000, 1, function () { });
}

function closeTuningMenuCEF() {
    $("#VehicleTuningMainMenuBox").fadeOut(100, function () {
        $("#VehicleTuningMainMenuBox").hide();
        $("#VehicleTuningMenuColorSelection").hide();
        alt.emit("Client:Tuning:closeCEF");
    });
}

ColorPicker(

    document.getElementById('color-picker'),

    function (hex, hsv, rgb) {
        document.getElementById("rgbRvalField").value = rgb.r;
        document.getElementById("rgbGvalField").value = rgb.g;
        document.getElementById("rgbBvalField").value = rgb.b;
    });

$("#VehicleTuningMainMenuBox").hide();
$("#VehicleTuningMenuColorSelection").hide();


// alt:V Events 

if ('alt' in window) {
    alt.on("CEF:Tuning:openTuningMenu", (Items) => {
        openVehicleTuningMenu(Items);
    });
}