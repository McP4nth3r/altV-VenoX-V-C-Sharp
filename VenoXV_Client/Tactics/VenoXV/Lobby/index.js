//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../../Globals/VnX-Lib';

let gamemode_version = "1.0.0";
let RageMP_version = "0.3.7";
let tactictimer = null;
let TACTIC_COUNTDOWN = "";
let CURRENT_LSPD_IN_ROUND = 0;
let CURRENT_LSPD_ALIVE_IN_ROUND = 0;
let CURRENT_BFAC_IN_ROUND = 0;
let CURRENT_BFAC_ALIVE_IN_ROUND = 0;
let Current_Damage = 0;
let Current_Kills = 0;
let WinnerText = "";
let ShowWinningWindow = false;
let BG_AP = 0;
alt.onServer('LoadTacticUI', () => {
    game.freezeEntityPosition(alt.Player.local.scriptID, false);
    game.displayHud(true);
    game.displayRadar(true);
});

alt.onServer('Tactics:UpdateMemberInfo', (L, LA, B, BA) => {
    CURRENT_LSPD_IN_ROUND = L;
    CURRENT_LSPD_ALIVE_IN_ROUND = LA;
    CURRENT_BFAC_IN_ROUND = B;
    CURRENT_BFAC_ALIVE_IN_ROUND = BA;
});

function startTimer(duration) {
    var timer = duration, minutes, seconds;
    if (tactictimer != null) { alt.clearInterval(tactictimer); }
    tactictimer = alt.setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        TACTIC_COUNTDOWN = minutes + ":" + seconds;

        if (--timer < 0) {
            timer = duration;
        }
    }, 1000);
}
alt.setInterval(() => {
    game.setEntityProofs(alt.Player.local.scriptID, true, false, false, false, false, false, false, false);
}, 1000)

function Tactics_Show_Winner() {
    if (BG_AP < 255) { BG_AP += 1; }
    if (BG_AP >= 40) { game.freezeEntityPosition(alt.Player.local.scriptID, true); }
    DrawText(WinnerText, [0.5, 0.5], [1, 1], 0, [255, 255, 255, BG_AP], false, true);
    DrawText("VenoX Tactics", [0.5, 0.57], [0.9, 0.9], 1, [0, 200, 255, BG_AP], true, true);
    game.drawRect(0, 0, 10, 10, 0, 0, 0, BG_AP);
    game.drawRect(0.5, 0.57, 0.25, 0.005, 0, 200, 255, BG_AP);
}

alt.onServer('Tactics:UpdatePlayerStats', (d, k) => {
    Current_Damage = d;
    Current_Kills = k;
});

alt.onServer('Tactics:OnTacticEndRound', (v) => {
    WinnerText = v;
    ShowWinningWindow = true;
    alt.setTimeout(function () {
        BG_AP = 0;
        ShowWinningWindow = false;
        game.freezeEntityPosition(alt.Player.local.scriptID, false);
    }, 5000);
});

alt.onServer('Tactics:SpectatePlayer', (p) => {
    //let cam = mp.cameras.new('default', new mp.Vector3(-485, 1095.75, 323.85), new mp.Vector3(0,0,0), 40);
    //cam.attachTo(p.handle, 0.0, 0.0, 10.0, true);
    //cam.setActive(true);
    //mp.game.cam.renderScriptCams(true, false, 0, true, false);
});

export function TacticsEveryTick() {
    if (tactictimer == null) { return; }
    if (ShowWinningWindow) { Tactics_Show_Winner(); return; }

    DrawText("L.S.P.D", [0.42478, 0.006], [0.4, 0.4], 0, [255, 255, 255, 255], true, true);
    DrawText(CURRENT_LSPD_ALIVE_IN_ROUND + " / " + CURRENT_LSPD_IN_ROUND, [0.42478, 0.028], [0.25, 0.25], 0, [255, 255, 255, 255], true, true);
    DrawText(TACTIC_COUNTDOWN, [0.5, 0.006], [0.5, 0.5], 0, [255, 255, 255, 255], true, true);
    DrawText("Grove Street", [0.575, 0.006], [0.4, 0.4], 0, [255, 255, 255, 255], true, true);
    DrawText(CURRENT_BFAC_ALIVE_IN_ROUND + " / " + CURRENT_BFAC_IN_ROUND, [0.575, 0.028], [0.25, 0.25], 0, [255, 255, 255, 255], true, true);

    game.drawRect(0.42478, 0, 0.1, 0.1, 0, 140, 183, 175);
    game.drawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
    game.drawRect(0.575, 0, 0.1, 0.1, 0, 152, 0, 175);

    game.drawRect(0.846, 0.30, 0.06, 0.035, 0, 0, 0, 175);
    game.drawRect(0.9105, 0.30, 0.06, 0.035, 0, 0, 0, 175);
    game.drawRect(0.975, 0.30, 0.06, 0.035, 0, 0, 0, 175);

    game.drawRect(0.916, 0.2818, 0.20, 0.003, 0, 150, 200, 175);
    if (!game.hasStreamedTextureDictLoaded("mpinventory")) {
        game.requestStreamedTextureDict("mpinventory", true);
    }

    if (!game.hasStreamedTextureDictLoaded("mpleaderboard")) {
        game.requestStreamedTextureDict("mpleaderboard", true);
    }

    if (!game.hasStreamedTextureDictLoaded("mpinventory")) {
        game.requestStreamedTextureDict("mpinventory", true);
    }

    game.drawSprite("mpinventory", "deathmatch", 0.826, 0.30, 0.025, 0.025, 0, 255, 255, 255, 255);
    DrawText(Current_Kills + " KILLS", [0.850, 0.289], [0.35, 0.33], 4, [225, 225, 225, 255], true, true);
    game.drawSprite("mpinventory", "mp_specitem_weapons", 0.8935, 0.30, 0.0215, 0.0215, 0, 255, 255, 255, 255);
    DrawText(Math.ceil(Current_Damage) + " DMG", [0.92, 0.289], [0.4, 0.33], 4, [225, 225, 225, 255], true, true);

    //mp.game.graphics.drawSprite("mpleaderboard", "leaderboard_time_icon", 0.956, 0.30, 0.027, 0.027, 0, 255, 255, 255, 255);
    DrawText("VnX Tactics", [0.979, 0.289], [0.5, 0.33], 4, [225, 225, 225, 255], true, true);


    //game.drawRect(0.9, 0.15, 0.20, 0.15, 0, 0, 0, 175);

    DrawText("German Venox Tactics " + gamemode_version + " dev r1", [0.927, 0.98], [0.6, 0.3], 0, [225, 225, 225, 175], true, true);
    //DrawText("Alt:V " + RageMP_version, 0.927, 0.96, 0.6, 0, 225, 225, 225, 135, true, true);
}


alt.onServer('Tactics:LoadTimer', (v) => {
    startTimer(v);
});