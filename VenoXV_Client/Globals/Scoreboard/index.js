//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, GetCursorStatus, vnxCreateCEF, vnxDestroyCEF } from '../VnX-Lib';
import { GetCurrentLobby, PLAYER_LOBBY_REALLIFE, PLAYER_LOBBY_TACTICS, PLAYER_LOBBY_7TOWERS } from '../VnX-Lib/events';

let CurrentBrowser = null;
let CurrentBrowserPath = "";
let removed = false;
let ReallifeScoreboardPath = "Globals/Scoreboard/reallife/tab.html";
let TacticsScoreboardPath = "Globals/Scoreboard/tactics/tab.html";
let SevenTowersScoreboardPath = "Globals/Scoreboard/seventowers/tab.html";


function CheckCurrentBrowser() {
	try {
		let Lobby = GetCurrentLobby();
		switch (Lobby) {
			case PLAYER_LOBBY_REALLIFE:
				if (CurrentBrowserPath != ReallifeScoreboardPath) {
					if (CurrentBrowser != null) { vnxDestroyCEF("Scoreboard"); }
					CurrentBrowser = vnxCreateCEF("Scoreboard", ReallifeScoreboardPath);
					CurrentBrowserPath = ReallifeScoreboardPath;
					alt.log("Scoreboard for " + Lobby + " Created! ");
				}
				break;
			case PLAYER_LOBBY_TACTICS:
				if (CurrentBrowserPath != TacticsScoreboardPath) {
					if (CurrentBrowser != null) { vnxDestroyCEF("Scoreboard"); }
					CurrentBrowser = vnxCreateCEF("Scoreboard", TacticsScoreboardPath);
					CurrentBrowserPath = TacticsScoreboardPath;
					alt.log("Scoreboard for " + Lobby + " Created! ");
				}
				break;
			case PLAYER_LOBBY_7TOWERS:
				if (CurrentBrowserPath != SevenTowersScoreboardPath) {
					if (CurrentBrowser != null) { vnxDestroyCEF("Scoreboard"); }
					CurrentBrowser = vnxCreateCEF("Scoreboard", SevenTowersScoreboardPath);
					CurrentBrowserPath = SevenTowersScoreboardPath;
					alt.log("Scoreboard for " + Lobby + " Created! ");
				}
				break;
		}
	}
	catch (e) { console.log(e); }
}


alt.onServer('UpdateScoreboard_Event', (pl_li, gm) => {
	try {
		CheckCurrentBrowser();
		if (CurrentBrowser != null) {
			CurrentBrowser.emit("FillScoreboard", pl_li, gm);
		}
	}
	catch (e) { console.log(e); }
});


export function KeyDown(key) {
	try {
		if (key == 0x59) {
			if (!CurrentBrowserPath) { return; }
			if (GetCursorStatus() == false) {
				if (removed == false) {
					game.displayHud(false);
					CurrentBrowser.emit("Scoreboard:Show");
					ShowCursor(true);
					removed = true;
					return;
				}
			}
		}
	}
	catch{ }
}

export function KeyUp(key) {
	try {
		if (key == 0x59) {
			if (!CurrentBrowserPath) { return; }
			if (removed == true) {
				game.displayHud(true);
				CurrentBrowser.emit("Scoreboard:Hide");
				ShowCursor(false);
				removed = false;
				return
			}
		}
	}
	catch{ }
}
