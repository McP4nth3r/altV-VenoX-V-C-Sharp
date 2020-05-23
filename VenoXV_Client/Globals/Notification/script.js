let counter = 0;
if ("alt" in window) {
    alt.on("Notify:PlayHitSound", () => {
        document.getElementById('audio_hitsound').currentTime = 0;
        document.getElementById('audio_hitsound').play();
    });
    alt.on('Notify:BloodScreen', () => {
        showBloodscreen();
    });
    alt.on("Notify:Create", (e, v) => {
        if (counter == 0) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value').innerHTML = "Information"; document.getElementById('header_value_scnd').innerHTML = "Information"; document.getElementById('value_t').innerHTML = v; document.getElementById('value_t_scnd').innerHTML = v; $("#showinfo").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value').innerHTML = "Warnung"; document.getElementById('header_value_scnd').innerHTML = "Warnung"; document.getElementById("showinfo").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t').innerHTML = v; document.getElementById('value_t_scnd').innerHTML = v; $("#showinfo").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value').innerHTML = "Fehler"; document.getElementById('header_value_scnd').innerHTML = "Fehler"; document.getElementById("showinfo").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t').innerHTML = v; document.getElementById('value_t_scnd').innerHTML = v; $("#showinfo").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo").addClass("d-none"); $("#moveawwayinfo").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 1) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_1").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_1").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_1').innerHTML = "Information"; document.getElementById('header_value_scnd_1').innerHTML = "Information"; document.getElementById('value_t_1').innerHTML = v; document.getElementById('value_t_scnd_1').innerHTML = v; $("#showinfo_1").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_1').innerHTML = "Warnung"; document.getElementById('header_value_scnd_1').innerHTML = "Warnung"; document.getElementById("showinfo_1").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_1").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_1').innerHTML = v; document.getElementById('value_t_scnd_1').innerHTML = v; $("#showinfo_1").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_1').innerHTML = "Fehler"; document.getElementById('header_value_scnd_1').innerHTML = "Fehler"; document.getElementById("showinfo_1").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_1").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_1').innerHTML = v; document.getElementById('value_t_scnd_1').innerHTML = v; $("#showinfo_1").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_1").addClass("d-none"); $("#moveawwayinfo_1").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_1").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 2) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_2").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_2").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_2').innerHTML = "Information"; document.getElementById('header_value_scnd_2').innerHTML = "Information"; document.getElementById('value_t_2').innerHTML = v; document.getElementById('value_t_scnd_2').innerHTML = v; $("#showinfo_2").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('header_value_2').innerHTML = "Warnung"; document.getElementById('header_value_scnd_2').innerHTML = "Warnung"; document.getElementById("showinfo_2").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_2").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_2').innerHTML = v; document.getElementById('value_t_scnd_2').innerHTML = v; $("#showinfo_2").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('header_value_2').innerHTML = "Fehler"; document.getElementById('header_value_scnd_2').innerHTML = "Fehler"; document.getElementById("showinfo_2").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_2").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_2').innerHTML = v; document.getElementById('value_t_scnd_2').innerHTML = v; $("#showinfo_2").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_2").addClass("d-none"); $("#moveawwayinfo_2").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_2").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 3) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_3").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_3").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_3').innerHTML = "Information"; document.getElementById('header_value_scnd_3').innerHTML = "Information"; document.getElementById('value_t_3').innerHTML = v; document.getElementById('value_t_scnd_3').innerHTML = v; $("#showinfo_3").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_3').innerHTML = "Warnung"; document.getElementById('header_value_scnd_3').innerHTML = "Warnung"; document.getElementById("showinfo_3").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_3").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_3').innerHTML = v; document.getElementById('value_t_scnd_3').innerHTML = v; $("#showinfo_3").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_3').innerHTML = "Fehler"; document.getElementById('header_value_scnd_3').innerHTML = "Fehler"; document.getElementById("showinfo_3").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_3").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_3').innerHTML = v; document.getElementById('value_t_scnd_3').innerHTML = v; $("#showinfo_3").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_3").addClass("d-none"); $("#moveawwayinfo_3").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_3").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 4) {

            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_4").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_4").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_4').innerHTML = "Information"; document.getElementById('header_value_scnd_4').innerHTML = "Information"; document.getElementById('value_t_4').innerHTML = v; document.getElementById('value_t_scnd_4').innerHTML = v; $("#showinfo_4").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_4').innerHTML = "Warnung"; document.getElementById('header_value_scnd_4').innerHTML = "Warnung"; document.getElementById("showinfo_4").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_4").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_4').innerHTML = v; document.getElementById('value_t_scnd_4').innerHTML = v; $("#showinfo_4").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_4').innerHTML = "Fehler"; document.getElementById('header_value_scnd_4').innerHTML = "Fehler"; document.getElementById("showinfo_4").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_4").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_4').innerHTML = v; document.getElementById('value_t_scnd_4').innerHTML = v; $("#showinfo_4").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_4").addClass("d-none"); $("#moveawwayinfo_4").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_4").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 5) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_5").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_5").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_5').innerHTML = "Information"; document.getElementById('header_value_scnd_5').innerHTML = "Information"; document.getElementById('value_t_5').innerHTML = v; document.getElementById('value_t_scnd_5').innerHTML = v; $("#showinfo_5").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_5').innerHTML = "Warnung"; document.getElementById('header_value_scnd_5').innerHTML = "Warnung"; document.getElementById("showinfo_5").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_5").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_5').innerHTML = v; document.getElementById('value_t_scnd_5').innerHTML = v; $("#showinfo_5").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_5').innerHTML = "Fehler"; document.getElementById('header_value_scnd_5').innerHTML = "Fehler"; document.getElementById("showinfo_5").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_5").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_5').innerHTML = v; document.getElementById('value_t_scnd_5').innerHTML = v; $("#showinfo_5").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_5").addClass("d-none"); $("#moveawwayinfo_5").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_5").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
        else if (counter == 6) {
            if (e == 0) {
                document.getElementById('audio_notify').play(); document.getElementById("showinfo_6").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById("moveawwayinfo_6").style.borderTopColor = "rgba(0,150,200,1)"; document.getElementById('header_value_6').innerHTML = "Information"; document.getElementById('header_value_scnd_6').innerHTML = "Information"; document.getElementById('value_t_6').innerHTML = v; document.getElementById('value_t_scnd_6').innerHTML = v; $("#showinfo_6").removeClass("d-none");
                counter = counter + 1;
            }
            else if (e == 1) {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_6').innerHTML = "Warnung"; document.getElementById('header_value_scnd_6').innerHTML = "Warnung"; document.getElementById("showinfo_6").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById("moveawwayinfo_6").style.borderTopColor = "rgba(225,180,0,1)"; document.getElementById('value_t_6').innerHTML = v; document.getElementById('value_t_scnd_6').innerHTML = v; $("#showinfo_6").removeClass("d-none");
                counter = counter + 1;
            }
            else {
                document.getElementById('audio_notify').play(); document.getElementById('header_value_6').innerHTML = "Fehler"; document.getElementById('header_value_scnd_6').innerHTML = "Fehler"; document.getElementById("showinfo_6").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById("moveawwayinfo_6").style.borderTopColor = "rgba(150,0,0,1)"; document.getElementById('value_t_6').innerHTML = v; document.getElementById('value_t_scnd_6').innerHTML = v; $("#showinfo_6").removeClass("d-none");
                counter = counter + 1;
            }
            setTimeout(function () {
                $("#showinfo_6").addClass("d-none"); $("#moveawwayinfo_6").removeClass("d-none");
                setTimeout(function () {
                    $("#moveawwayinfo_6").addClass("d-none");
                    if (counter != 0) {
                        counter = counter - 1;
                    }
                }, 1500);
            }, 5000);
            return;
        }
    });
}


//Side Notify

$(document).ready(function () {
    document.getElementById('SideNotification_Sound').volume = 0.35;
});

let NotificationShowing = 0;
let NotificationTypes = {
    Info: "Info",
    Warning: "Warning",
    Error: "Error"
}
function GetCorrectType(type) {
    switch (type) {
        case 0:
            return NotificationTypes.Info;
        case 1:
            return NotificationTypes.Warning;
        case 2:
            return NotificationTypes.Error;
    }
}

function DrawNotification(type, text) {
    type = GetCorrectType(type);
    NotificationShowing++;
    $('.SideNotification_' + NotificationShowing).removeClass('d-none');
    $('.SideNotification_' + NotificationShowing).children().html(text)
    switch (type) {
        case NotificationTypes.Error:
            $('.SideNotification_' + NotificationShowing).css("border-top-color", "rgba(255,0,0)");
            break;
        case NotificationTypes.Warning:
            $('.SideNotification_' + NotificationShowing).css("border-top-color", "rgba(255,200,0)");
            break;
        case NotificationTypes.Info:
            $('.SideNotification_' + NotificationShowing).css("border-top-color", "rgba(0,200,255)");
            break;
    }
    PlayNotificationSound();
    setTimeout(() => {
        $('.SideNotification_' + NotificationShowing).addClass('d-none');
        NotificationShowing--;
    }, 3000);
}

function PlayNotificationSound() {
    document.getElementById('SideNotification_Sound').currentTime = 0;
    document.getElementById('SideNotification_Sound').play();
}


if ('alt' in window) {
    alt.on('SideNotification:Create', (type, text) => {
        DrawNotification(type, text);
    });
}