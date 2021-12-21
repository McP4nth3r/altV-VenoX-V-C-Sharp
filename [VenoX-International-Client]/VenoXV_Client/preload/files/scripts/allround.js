//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
let ExecutedHoverFunc = false;

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
    //$('.background').attr("src", "https://venox-international.com/images_vnx/preload_wallpaper/" + rnumber + ".jpg");
    $('.background').attr("src", "https://www.venox-international.com/home/images/style-2/background.jpg");

    //console.log('called src : ' + rnumber);
    //console.log('called src : ' + $('.background').attr("src"));
}


let timer;

function OnHover() {
    var recs = document.querySelectorAll('#rectangle');
    [].forEach.call(recs, function (currentrec) {
        $(currentrec).mouseover(function () {
            if (ExecutedHoverFunc) return;
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
            ExecutedHoverFunc = true;
        });

        $(currentrec).mouseleave(function () {
            if (!ExecutedHoverFunc) return;
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
            ExecutedHoverFunc = false;
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
    AddLobbyToGamemode(1, 'files/images/flag-ru.png', '[RU] Alpha', 0, 'ru', '253 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-de.png', '[DE] Charlie', 0, 'de', '40 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-us.png', '[EN] Gamma', 0, 'en', '54 / 500');
    AddLobbyToGamemode(1, 'files/images/flag-es.png', '[ES] Delta', 0, 'es', '84 / 600');

    AddLobbyToGamemode(2, '', 'Alpha', 2, '0', '0 / 20');
    AddLobbyToGamemode(2, '', 'Beta', 2, '1', '10 / 20');
    AddLobbyToGamemode(2, '', 'Gamma', 2, '2', '10 / 20');
    AddLobbyToGamemode(2, '', 'Delta', 2, '3', '30 / 50');
}, 200);

function AddLobbyToGamemode(RectangleId, imgpath, lobbyname, lobbyId, lobbycountry, lobbycount) {
    if (imgpath == '')
        $('.rec_' + RectangleId).children('.rec_lobbyinfo_parent').children('.rec_lobbyinfo').append('<div class="rec_column" onclick="TriggerSelectedGM(' + lobbyId + ', `' + lobbycountry + '`)"><div class="rec_column_lobby_name">' + lobbyname + '</div><div class="rec_column_lobby_count">' + lobbycount + '</div></div>');
    else
        $('.rec_' + RectangleId).children('.rec_lobbyinfo_parent').children('.rec_lobbyinfo').append('<div class="rec_column" onclick="TriggerSelectedGM(' + lobbyId + ', `' + lobbycountry + '`)"><img src="' + imgpath + '" class="rec_column_lobby_image"><div class="rec_column_lobby_name">' + lobbyname + '</div><div class="rec_column_lobby_count">' + lobbycount + '</div></div>');
}