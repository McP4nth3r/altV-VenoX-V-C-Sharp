//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCountdown } from '../Globals/VnX-Lib';

let RACE_TIMER = null;
let RACE_COUNTDOWN = null;
let RACE_PLAYER_COUNTER = 1;
let RACE_PLAYERS = {};
let RACE_PLAYER_CURRENT_PLACE = 10;
/*
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Solid_Snake";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Sheby";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "LastAttacker";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Uno87";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Forces";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Folienkleber";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Bonus";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Heron";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "Slade";
RACE_PLAYERS[RACE_PLAYER_COUNTER++] = "LuisSnake";
*/
/*
alt.onServer('Race:Unload', () => {
    if (RaceTimer) {
        alt.clearEveryTick(RaceTimer);
        RaceTimer = null;
    }
});

let RaceTimer;
alt.onServer('Race:Load', () => {
    if (RaceTimer) { return; }
    RaceTimer = alt.everyTick(() => {
        try {
            if (!RACE_TIMER) { return };
            game.drawRect(0.93, 0.5, 0.1, 0.3, 0, 0, 0, 200);
            game.drawRect(0.93, 0.365, 0.1, 0.03, 0, 0, 0, 180);
            game.drawRect(0.93, 0.349, 0.1, 0.003, 0, 150, 200, 255);
            DrawText("Race-Info", [0.93, 0.350], [0.5, 0.5], 1, [255, 255, 255, 255], true, true);
            DrawText("Timer : " + RACE_COUNTDOWN, [0.5, 0.01], [0.5, 0.5], 1, [255, 255, 255, 255], true, true);

            if (!game.hasStreamedTextureDictLoaded("hunting")) {
                game.requestStreamedTextureDict("hunting", true);
            }
            if (game.hasStreamedTextureDictLoaded("hunting")) {
                game.drawSprite("hunting", "hunting_gold_128", 0.89, 0.390, 0.015, 0.015, 0, 255, 255, 255, 255);
                game.drawSprite("hunting", "hunting_silver_128", 0.89, 0.415, 0.015, 0.015, 0, 255, 255, 255, 255);
                game.drawSprite("hunting", "hunting_bronze_128", 0.89, 0.443, 0.015, 0.015, 0, 255, 255, 255, 255);
            }
            let counter = 0;
            let RACE_PLAYERS_LENGTH = 0;
            for (var player in RACE_PLAYERS) {
                DrawText(player + ") " + RACE_PLAYERS[player], [0.93, 0.378 + counter], [0.4, 0.4], 1, [0, 200, 255, 255], true, true);
                if (alt.Player.local.getStreamSyncedMeta('PLAYER_NAME') == RACE_PLAYERS[player]) {
                    RACE_PLAYER_CURRENT_PLACE = player;
                }
                counter += 0.0270;
                RACE_PLAYERS_LENGTH++
            }
            DrawText(RACE_PLAYER_CURRENT_PLACE + " / " + RACE_PLAYERS_LENGTH, [0.95, 0.01], [0.8, 0.8], 1, [0, 200, 255, 255], true, true);
        }
        catch{ }
    });
});


alt.onServer('Race:ClearPlayerList', () => {
    RACE_PLAYERS = {};
    RACE_PLAYER_COUNTER = 1;
});

alt.onServer('Race:FillPlayerList', (player) => {
    try {
        RACE_PLAYERS[RACE_PLAYER_COUNTER++] = player;
    }
    catch{ }
});

alt.onServer('Race:StartTimer', (timer, seconds) => {
    try {
        startTimer(timer);
        ShowCountdown(seconds);
    }
    catch{ }
});


function startTimer(duration) {
    try {
        var timer = duration, minutes, seconds;
        if (RACE_TIMER != null) { alt.clearInterval(RACE_TIMER); }
        RACE_TIMER = alt.setInterval(function () {
            minutes = parseInt(timer / 60, 10);
            seconds = parseInt(timer % 60, 10);

            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;

            RACE_COUNTDOWN = minutes + ":" + seconds;

            if (--timer < 0) {
                timer = duration;
            }
        }, 1000);
    }
    catch{ }
}

alt.onServer('Race:ShowCountdown', (DateTime) => {
    let CurrentDateTime = new Date(GetCurrentDateTime());
    DateTime = new Date(DateTime);
    alt.log(CurrentDateTime);
    alt.log(DateTime);
    let Interval = alt.setInterval(() => {
        if (CurrentDateTime <= DateTime) {
            alt.log('Smaller than DateTime.Now');
            alt.clearInterval(Interval);
        }
    }, 100);
});
*/