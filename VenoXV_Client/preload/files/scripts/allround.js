//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

function playAudio(v) {
    if (v == 1) {
        document.getElementById('hoversoundtrack').currentTime = 0;
        document.getElementById('hoversoundtrack').play();
    } else {
        document.getElementById('clicksoundtrack').currentTime = 0;
        document.getElementById('clicksoundtrack').play();
    }
}


function OnWindowLoad() {
    OnHover();
    let rnumber = Math.floor((Math.random() * 6));
    $('.background').attr("src", "https://venox-reallife.com/images_vnx/preload_wallpaper/" + rnumber + ".jpg");
    //console.log('called src : ' + rnumber);
    //console.log('called src : ' + $('.background').attr("src"));
}


let timer;

function OnHover() {
    var recs = document.querySelectorAll('#rectangle');
    [].forEach.call(recs, function (currentrec) {
        $(currentrec).mouseover(function () {
            $('.background').removeClass('blurout');
            $(currentrec).children('.rec_lobbyinfo_parent').removeClass('d-none');
            $('.background').addClass('blurin');
            if (timer != null) clearTimeout(timer);

            timer = setTimeout(function () {
                $('.background').removeClass('blurin');
                $('.background').css({
                    filter: "blur(8px)"
                });
                timer = false;
            }, 900);
        });

        $(currentrec).mouseleave(function () {
            $('.background').removeClass('blurin');
            $('.background').addClass('blurout');
            $(currentrec).children('.rec_lobbyinfo_parent').addClass('d-none');
            if (timer != null) clearTimeout(timer);

            timer = setTimeout(function () {
                $('.background').css({
                    filter: "blur(0px)"
                });
                $('.background').removeClass('blurout');
            }, 900);
        });
    });
}

if ('alt' in window) {
    alt.on('Load:RefreshGamemodeStats', (AllPlayers, AllPlayersMax, ReallifePlayers, ReallifePlayersMax, TacticPlayers, TacticPlayersMax, ZombiePlayers, ZombiePlayersMax, RacePlayers, RacePlayersMax, SevenTowersPlayers, SevenTowersPlayersMax) => {
        $('#rec_0_userinfo').text(ZombiePlayers + ' / ' + ZombiePlayersMax + ' Online');
        $('#rec_1_userinfo').text(ReallifePlayers + ' / ' + ReallifePlayersMax + ' Online');
        $('#rec_2_userinfo').text(TacticPlayers + ' / ' + TacticPlayersMax + ' Online');
        $('#rec_3_userinfo').text(RacePlayers + ' / ' + RacePlayersMax + ' Online');
        $('#rec_4_userinfo').text(SevenTowersPlayers + ' / ' + SevenTowersPlayersMax + ' Online');
    });
}

setTimeout(() => {
    OnWindowLoad(); // get new wallpaper.
    AddLobbyToGamemode(1, 'files/images/flag-ru.png', '[RU] Alpha', '253 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-de.png', '[DE] Charlie', '40 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-us.png', '[EN] Gamma', '54 / 500');
    AddLobbyToGamemode(1, 'files/images/flag-es.png', '[ES] Delta', '84 / 600');

}, 200);

function AddLobbyToGamemode(Id, imgpath, lobbyname, lobbycount) {
    $('.rec_' + Id).children('.rec_lobbyinfo_parent').children('.rec_lobbyinfo').append('<div class="rec_column"><img src="' + imgpath + '" class="rec_column_lobby_image"><div class="rec_column_lobby_name">' + lobbyname + '</div><div class="rec_column_lobby_count">' + lobbycount + '</div></div>');
}