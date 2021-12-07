//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


// Loading Screen : 

let Songs = [
    "http://venox-reallife.com/preload/sounds/gta4-loading.mp3",
    "http://venox-reallife.com/preload/sounds/Jan Hammer - Crockett's Theme (Miami Vice).mp3",
    "http://venox-reallife.com/preload/sounds/G-Eazy - No Limit REMIX ft. A$AP Rocky, Cardi B, French Montana, Juicy J, Belly.mp3",
    "http://venox-reallife.com/preload/sounds/Purple Disco Machine, Sophie and the Giants - Hypnotized (Official Video).mp3",
    "http://venox-reallife.com/preload/sounds/In Da Hoopty.mp3",
    "http://venox-reallife.com/preload/sounds/Nuthin' But A _G_ Thang.mp3"
]

function PlayMusic(state) {
    if (state) {
        let RandomPlay = Math.round(Math.random() * Songs.length);
        $("#Soundtrack").attr("src", Songs[RandomPlay]);
        document.getElementById('Soundtrack').volume = 0.05;
        document.getElementById('Soundtrack').play();
        document.getElementById('Soundtrack').currentTime = 0;
    } else {
        document.getElementById('Soundtrack').pause();
        document.getElementById('Soundtrack').currentTime = 0;
    }
}

function ShowPrivacyPolicy(state) {
    if (state) {
        setTimeout(() => {
            $('#part-1').removeClass('d-none');
        }, 1000);
    } else $('#part-1').addClass('d-none');

}

function ShowPoweredBy(state) {
    if (state) $('#part-2').removeClass('d-none');
    else $('#part-2').addClass('d-none');
}

function ShowLoadingScreen(state) {
    if (state) $('#part-3').removeClass('d-none');
    else $('#part-3').addClass('d-none');
}

function ShowLoadingBar(state) {
    if (state) $('#LoadingBar').removeClass('d-none');
    else $('#LoadingBar').addClass('d-none');
}

function SetLoadingState(text) {
    $(".VnX-LoadingBar-Parent").children(".VnX-LoadingBar").text(text);
}

function ShowPreload(state) {
    if (state) {
        OnWindowLoad(); // get new wallpaper.
        $('.Loading-Screen-Main').removeClass('d-none');
        ShowPrivacyPolicy(true);
        ShowLoadingBar(true);
        PlayMusic(true);
        setTimeout(() => {
            ShowPrivacyPolicy(false);
            ShowPoweredBy(true);
            setTimeout(() => {
                ShowLoadingScreen(true);
                alt.emit('Preload:FinishedPrivacyPolicy');
            }, 5000);
        }, 7000);
    } else {
        $('.Loading-Screen-Main').addClass('d-none');
        ShowLoadingScreen(false);
        ShowLoadingBar(false);
        ShowPoweredBy(false);
        PlayMusic(false);
    }

}


if ('alt' in window) {
    alt.on('LoadingScreen:Show', (state) => {
        if (state) $('.Loading-Screen-Main').removeClass('d-none');
        else $('.Loading-Screen-Main').addClass('d-none');
    });

    alt.on('LoadingScreen:UpdateCurrentState', (text) => {
        SetLoadingState(text);
    });

    alt.on('LoadingScreen:ShowPreload', (state) => {
        ShowPreload(state);
    });
}