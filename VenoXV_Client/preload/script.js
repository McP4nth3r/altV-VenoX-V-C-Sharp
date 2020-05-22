//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

function playAudio(v) {
    if (v == 1) {
        document.getElementById('hoversoundtrack').currentTime = 0;
        document.getElementById('hoversoundtrack').play();
    }
    else {
        document.getElementById('clicksoundtrack').currentTime = 0;
        document.getElementById('clicksoundtrack').play();
    }
}



function OnWindowLoad() {
    playAudio();
    OnHover();
    let rnumber = Math.floor((Math.random() * 6));
    $('.background').attr("src", "https://venox-reallife.com/images_vnx/preload_wallpaper/" + rnumber + ".jpg");
}

let timer;
function OnHover() {
    var recs = document.querySelectorAll('#rectangle');
    [].forEach.call(recs, function (currentrec) {
        $(currentrec).mouseover(function () {
            $('.background').removeClass('blurout');
            $(currentrec).children().children().removeClass('d-none');
            $('.background').addClass('blurin');
            if (timer != null) {
                clearTimeout(timer);
            }
            timer = setTimeout(function () {
                $('.background').removeClass('blurin');
                $('.background').css({ filter: "blur(8px)" });
                timer = false;
            }, 900);
        });

        $(currentrec).mouseleave(function () {
            $('.background').removeClass('blurin');
            $('.background').addClass('blurout');
            $(currentrec).children().children().addClass('d-none');
            if (timer != null) {
                clearTimeout(timer);
            }
            timer = setTimeout(function () {
                $('.background').css({ filter: "blur(0px)" });
                $('.background').removeClass('blurout');
            }, 900);
        });
    });
}

