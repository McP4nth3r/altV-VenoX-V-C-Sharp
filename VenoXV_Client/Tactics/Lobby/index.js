//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCountdown } from '../../Globals/VnX-Lib';

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
let Team_A_Name = "";
let Team_A_R = 0;
let Team_A_G = 0;
let Team_A_B = 0;

let Team_B_Name = "";
let Team_B_R = 0;
let Team_B_G = 0;
let Team_B_B = 0;

alt.onServer('LoadTacticUI', (A_Name, B_Name, r, g, b, r1, g1, b1) => {
    try {
        if (alt.Player.local.getStreamSyncedMeta("RAGEAPI:SpawnedPlayer") == true) { game.freezeEntityPosition(alt.Player.local.scriptID, false); }
        game.displayHud(true);
        game.displayRadar(true);
        Team_A_Name = A_Name;
        Team_A_R = r;
        Team_A_G = g;
        Team_A_B = b;
        ////////////////
        Team_B_Name = B_Name;
        Team_B_R = r1;
        Team_B_G = g1;
        Team_B_B = b1;
    }
    catch{ }
});

alt.onServer('Tactics:OnDeath', () => {
    try {
        game.setFadeOutAfterDeath(false);
        game.ignoreNextRestart(true);
        game.displayHud(true);
    }
    catch{ }
});

alt.onServer('Tactics:UpdateMemberInfo', (L, LA, B, BA) => {
    try {
        CURRENT_LSPD_IN_ROUND = L;
        CURRENT_LSPD_ALIVE_IN_ROUND = LA;
        CURRENT_BFAC_IN_ROUND = B;
        CURRENT_BFAC_ALIVE_IN_ROUND = BA;
    }
    catch{ }
});

function startTimer(duration) {
    try {
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
    catch{ }
}

function Tactics_Show_Winner() {
    try {
        if (BG_AP < 255) { BG_AP += 1; }
        if (BG_AP >= 40) { game.freezeEntityPosition(alt.Player.local.scriptID, true); alt.toggleGameControls(false); }
        DrawText(WinnerText, [0.5, 0.5], [1, 1], 0, [255, 255, 255, BG_AP], false, true);
        DrawText("VenoX Tactics", [0.5, 0.57], [0.9, 0.9], 1, [0, 200, 255, BG_AP], true, true);
        game.drawRect(0, 0, 10, 10, 0, 0, 0, BG_AP);
        game.drawRect(0.5, 0.57, 0.25, 0.005, 0, 200, 255, BG_AP);
    }
    catch{ }
}

alt.onServer('Tactics:UpdatePlayerStats', (d, k) => {
    try {
        Current_Damage = d;
        Current_Kills = k;
    }
    catch{ }
});

alt.onServer('Tactics:OnTacticEndRound', (v) => {
    try {
        WinnerText = v;
        ShowWinningWindow = true;
        alt.setTimeout(function () {
            BG_AP = 0;
            ShowWinningWindow = false;
            TimerCreated = false;
        }, 5000);
    }
    catch{ }
});

alt.onServer('Tactics:SpectatePlayer', (p) => {
    //let cam = mp.cameras.new('default', new mp.Vector3(-485, 1095.75, 323.85), new mp.Vector3(0,0,0), 40);
    //cam.attachTo(p.handle, 0.0, 0.0, 10.0, true);
    //cam.setActive(true);
    //mp.game.cam.renderScriptCams(true, false, 0, true, false);
});

let TimerCreated = false;
function DrawTacticCountdown() {
    try {
        ShowCountdown(3);
    }
    catch{ }
}

export function TacticsEveryTick() {
    try {
        if (tactictimer == null) { return; }
        if (ShowWinningWindow) { Tactics_Show_Winner(); return; }
        if (!TimerCreated) { TimerCreated = true; DrawTacticCountdown(); };
        DrawText(Team_A_Name, [0.42478, 0.006], [0.4, 0.4], 0, [255, 255, 255, 255], true, true);
        DrawText(CURRENT_LSPD_ALIVE_IN_ROUND + " / " + CURRENT_LSPD_IN_ROUND, [0.42478, 0.028], [0.25, 0.25], 0, [255, 255, 255, 255], true, true);
        DrawText(TACTIC_COUNTDOWN, [0.5, 0.006], [0.5, 0.5], 0, [255, 255, 255, 255], true, true);
        DrawText(Team_B_Name, [0.575, 0.006], [0.4, 0.4], 0, [255, 255, 255, 255], true, true);
        DrawText(CURRENT_BFAC_ALIVE_IN_ROUND + " / " + CURRENT_BFAC_IN_ROUND, [0.575, 0.028], [0.25, 0.25], 0, [255, 255, 255, 255], true, true);

        game.drawRect(0.42478, 0, 0.1, 0.1, Team_A_R, Team_A_G, Team_A_B, 175);
        game.drawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
        game.drawRect(0.575, 0, 0.1, 0.1, Team_B_R, Team_B_G, Team_B_B, 175);

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
    catch{ }
}


alt.onServer('Tactics:LoadTimer', (v) => {
    try { startTimer(v); }
    catch{ }
});