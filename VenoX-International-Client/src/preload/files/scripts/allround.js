//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
let ExecutedHoverFunc = false;
let lobbyEntries = {};
let audioElement = null;
let hoverSoundtrack;
let clickSoundtrack;

function playAudio(v) {
    if (!hoverSoundtrack || clickSoundtrack) {
        hoverSoundtrack = document.getElementById('hoversoundtrack');
        clickSoundtrack = document.getElementById('clicksoundtrack');
    }
    if (v == 1) {
        hoverSoundtrack.currentTime = 0;
        hoverSoundtrack.play();
    } else {
        clickSoundtrack.currentTime = 0;
        clickSoundtrack.play();
    }
}

function addGamemode(id, name, hoverName, imgSource, hoverImg, hoverSound) {
    if (lobbyEntries[name]) return console.log('[ERROR]: Lobby already exist!');
    lobbyEntries[name] = {
        id: id,
        name: name,
        hoverName: hoverName,
        imgSource: imgSource,
        hoverImg: hoverImg,
        hoverSound: hoverSound,
    };
    $('.wrap').append(
        `<div id="rectangle" class="LobbyChild rec_` +
            id +
            `" onmouseenter="playAudio(1)" style="background-image: url('` +
            imgSource +
            `');"><div class="rec_text">` +
            name +
            `</div><div class="rec_lobbyinfo_parent d-none"><div class="rec_column_header rec_column rec_columnhover">` +
            hoverName +
            `</div><div class="rec_lobbyinfo"></div></div></div>`
    );
}

function OnWindowLoad() {
    let rnumber = Math.floor(Math.random() * 5);
    $('.background').attr('src', 'https://venox-international.com/images/gtav/preload_wallpaper/' + rnumber + '.jpg');
    //$('.background').attr('src', 'https://www.venox-international.com/home/images/style-2/background.jpg');

    //console.log('called src : ' + rnumber);
    //console.log('called src : ' + $('.background').attr("src"));
}

function OnHover() {
    if (!audioElement) audioElement = document.createElement('audio');
    console.log(audioElement);
    var recs = document.querySelectorAll('#rectangle');
    [].forEach.call(recs, function (currentrec) {
        $(currentrec).mouseover(function () {
            if (ExecutedHoverFunc) return;

            let gamemode = $(currentrec).children('.rec_text').html();
            let entry = lobbyEntries[gamemode];
            $(currentrec).css('background-image', 'url(' + entry.hoverImg + ')');
            $(currentrec).children('.rec_lobbyinfo_parent').removeClass('d-none');
            ExecutedHoverFunc = true;

            audioElement.setAttribute('src', entry.hoverSound);
            audioElement.load();
            audioElement.play();

            audioElement.addEventListener(
                'ended',
                function () {
                    this.play();
                },
                false
            );
        });

        $(currentrec).mouseleave(function () {
            if (!ExecutedHoverFunc) return;

            let gamemode = $(currentrec).children('.rec_text').html();
            let entry = lobbyEntries[gamemode];
            $(currentrec).css('background-image', 'url(' + entry.imgSource + ')');

            $(currentrec).children('.rec_lobbyinfo_parent').addClass('d-none');

            audioElement.pause();
            console.log('removed audioElement : ' + audioElement);

            ExecutedHoverFunc = false;
        });
    });
}

if ('alt' in window) {
    alt.on(
        'Load:RefreshGamemodeStats',
        (
            AllPlayers,
            AllPlayersMax,
            ReallifePlayers,
            ReallifePlayersMax,
            TacticPlayers,
            TacticPlayersMax,
            ZombiePlayers,
            ZombiePlayersMax,
            RacePlayers,
            RacePlayersMax,
            SevenTowersPlayers,
            SevenTowersPlayersMax
        ) => {
            $('#rec_0_userinfo').text(ZombiePlayers + ' / ' + ZombiePlayersMax + ' Online');
            $('#rec_1_userinfo').text(ReallifePlayers + ' / ' + ReallifePlayersMax + ' Online');
            $('#rec_2_userinfo').text(TacticPlayers + ' / ' + TacticPlayersMax + ' Online');
            $('#rec_3_userinfo').text(RacePlayers + ' / ' + RacePlayersMax + ' Online');
            $('#rec_4_userinfo').text(SevenTowersPlayers + ' / ' + SevenTowersPlayersMax + ' Online');
        }
    );
}

setTimeout(() => {
    OnWindowLoad(); // get new wallpaper.

    /* lobbys */
    addGamemode(0, 'Zombies', 'Lobby', './files/images/Zombie.jpg', './files/images/Zombie_hover.jpg', './files/sounds/zombie.mp3');
    addGamemode(1, 'Reallife', 'Roleplay', './files/images/Reallife.jpg', './files/images/Reallife_hover.jpg', './files/sounds/reallife.mp3');
    addGamemode(2, 'Tactics', 'Lobby', './files/images/Tactics.jpg', './files/images/Tactics_hover.jpg', './files/sounds/tactics.mp3');
    addGamemode(3, 'Race', 'Lobby', './files/images/Race.jpg', './files/images/Race_hover.jpg', './files/sounds/race.mp3');
    addGamemode(7, '7 - Towers', 'Lobby', './files/images/Towers.jpg', './files/images/Towers_hover.jpg', './files/sounds/towers.mp3');

    /* lobbys */
    AddLobbyToGamemode(0, 'files/images/zombies_icon.png', 'Zombies-Berlin', 0, '0', '0 / 20');
    AddLobbyToGamemode(0, 'files/images/zombies_icon.png', 'Zombies-New York', 0, '1', '10 / 20');
    AddLobbyToGamemode(0, 'files/images/zombies_icon.png', 'Zombies-Moscow', 0, '2', '10 / 20');
    AddLobbyToGamemode(0, 'files/images/zombies_icon.png', 'Zombies-Tokyo', 0, '3', '30 / 50');

    AddLobbyToGamemode(1, 'files/images/flag-ru.png', '[RU] Alpha', 0, 'ru', '253 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-de.png', '[DE] Charlie', 0, 'de', '40 / 700');
    AddLobbyToGamemode(1, 'files/images/flag-us.png', '[EN] Gamma', 0, 'en', '54 / 500');
    AddLobbyToGamemode(1, 'files/images/flag-es.png', '[ES] Delta', 0, 'es', '84 / 600');

    AddLobbyToGamemode(2, 'files/images/tactics_icon.png', 'TDM-Alpha', 2, '0', '0 / 20');
    AddLobbyToGamemode(2, 'files/images/tactics_icon.png', 'TDM-Beta', 2, '1', '10 / 20');
    AddLobbyToGamemode(2, 'files/images/tactics_icon.png', 'TDM-Gamma', 2, '2', '10 / 20');
    AddLobbyToGamemode(2, 'files/images/tactics_icon.png', 'TDM-Delta', 2, '3', '30 / 50');

    AddLobbyToGamemode(3, 'files/images/race_icon.png', 'Race-Alpha', 3, '0', '0 / 20');
    AddLobbyToGamemode(3, 'files/images/race_icon.png', 'Race-Beta', 3, '1', '10 / 20');
    AddLobbyToGamemode(3, 'files/images/race_icon.png', 'Race-Gamma', 3, '2', '10 / 20');
    AddLobbyToGamemode(3, 'files/images/race_icon.png', 'Race-Delta', 3, '3', '30 / 50');

    AddLobbyToGamemode(7, 'files/images/towers_icon.png', '7Towers-Alpha', 7, '0', '0 / 20');
    AddLobbyToGamemode(7, 'files/images/towers_icon.png', '7Towers-Beta', 7, '1', '10 / 20');
    AddLobbyToGamemode(7, 'files/images/towers_icon.png', '7Towers-Gamma', 7, '2', '10 / 20');
    AddLobbyToGamemode(7, 'files/images/towers_icon.png', '7Towers-Delta', 7, '3', '30 / 50');

    OnHover();
}, 50);

function AddLobbyToGamemode(RectangleId, imgpath, lobbyname, lobbyId, lobbycountry, lobbycount) {
    if (imgpath == '')
        $('.rec_' + RectangleId)
            .children('.rec_lobbyinfo_parent')
            .children('.rec_lobbyinfo')
            .append(
                '<div class="rec_column" onclick="TriggerSelectedGM(' +
                    lobbyId +
                    ', `' +
                    lobbycountry +
                    '`)"><div class="rec_column_lobby_name">' +
                    lobbyname +
                    '</div><div class="rec_column_lobby_count">' +
                    lobbycount +
                    '</div></div>'
            );
    else
        $('.rec_' + RectangleId)
            .children('.rec_lobbyinfo_parent')
            .children('.rec_lobbyinfo')
            .append(
                '<div class="rec_column" onclick="TriggerSelectedGM(' +
                    lobbyId +
                    ', `' +
                    lobbycountry +
                    '`)"><img src="' +
                    imgpath +
                    '" class="rec_column_lobby_image"><div class="rec_column_lobby_name">' +
                    lobbyname +
                    '</div><div class="rec_column_lobby_count">' +
                    lobbycount +
                    '</div></div>'
            );
}
