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
    Onload();
    let rnumber = Math.floor((Math.random() * 6));
    $('.background').attr("src", "https://venox-reallife.com/images_vnx/preload_wallpaper/" + rnumber + ".jpg");
    console.log('called ' + rnumber);
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

// Loading Screen : 

let CurrentBackground = 0;
function ChangeBackground() {
    if (CurrentBackground > 0) { $('#part-3').addClass('Anim_Out'); }
    setTimeout(() => {
        $('#part-3').removeClass('Anim_Out');
        $('.Loading-Ped-' + CurrentBackground).removeClass('Anim_LeftToRight');
        $('.Loading-Ped-' + CurrentBackground).removeClass('Anim_RightToLeft');
        $('#part-3').addClass('Anim_In');
        $('#part-3').addClass('d-none');
        setTimeout(() => {
            $('#part-3').removeClass('d-none');
            $('.Loading-Background').css("background-image", "url(files/images/wallpaper/bg-" + CurrentBackground + ".png)");
            $('.Loading-Ped-' + CurrentBackground).removeClass('d-none');
            setTimeout(() => {
                $('.Loading-Ped-' + CurrentBackground).addClass('d-none');
                CurrentBackground++;
                ChangeBackground();
            }, 5000);
        }, 2000);
    }, 3000);
}
function Onload() {

    $('.Loading-Screen-Main').removeClass('d-none');
    setTimeout(() => {
        $('.Loading-Screen-Main').addClass('d-none');
    }, 50000);


    setTimeout(() => {
        $('#LoadingBar').removeClass('d-none');
    }, 1500);
    setTimeout(() => {
        $('#part-1').removeClass('d-none');
        setTimeout(() => {
            $('#part-1').addClass('d-none');
            $('#part-2').removeClass('d-none');
            setTimeout(() => {
                $('#part-2').addClass('d-none');
                ChangeBackground();
            }, 5000);
        }, 5000);
    }, 5000);
}


if ('alt' in window) {
    alt.on('LoadingScreen:Show', (MS) => {
        $('.Loading-Screen-Main').removeClass('d-none');
        setTimeout(() => {
            $('.Loading-Screen-Main').addClass('d-none');
        }, MS);
    });

    alt.on('Load:RefreshGamemodeStats', (AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax) => {
        $('#rec_0_userinfo').text(ZombiePlayers + ' / ' + ZombiePlayersMax + ' Online');
        $('#rec_1_userinfo').text(ReallifePlayers + ' / ' + ReallifePlayersMax + ' Online');
        $('#rec_2_userinfo').text(TacticPlayers + ' / ' + TacticPlayersMax + ' Online');
        $('#rec_3_userinfo').text(RacePlayers + ' / ' + RacePlayersMax + ' Online');
        $('#rec_4_userinfo').text(SevenTowersPlayers + ' / ' + SevenTowersPlayersMax + ' Online');
    });
}