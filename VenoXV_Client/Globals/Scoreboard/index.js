//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, GetCursorStatus, vnxCreateCEF, vnxDestroyCEF } from '../VnX-Lib';
import { GetCurrentLobby, PLAYER_LOBBY_REALLIFE, PLAYER_LOBBY_TACTICS } from '../VnX-Lib/events';

let CurrentBrowser = null;
let CurrentBrowserPath = "";
let removed = false;
let allowed = true;
let ReallifeScoreboardPath = "Globals/Scoreboard/reallife/tab.html";
let TacticsScoreboardPath = "Globals/Scoreboard/tactics/tab.html";


function CheckCurrentBrowser() {
	if (GetCurrentLobby() == PLAYER_LOBBY_REALLIFE) {
		if (CurrentBrowserPath != ReallifeScoreboardPath) {
			if (CurrentBrowser != null) { vnxDestroyCEF("Scoreboard"); }
			CurrentBrowser = vnxCreateCEF("Scoreboard", ReallifeScoreboardPath);
			CurrentBrowserPath = ReallifeScoreboardPath;
			alt.log("Scoreboard for " + GetCurrentLobby() + " Created! ");
		}
	}
	else if (GetCurrentLobby() == PLAYER_LOBBY_TACTICS) {
		if (CurrentBrowserPath != TacticsScoreboardPath) {
			if (CurrentBrowser != null) { vnxDestroyCEF("Scoreboard"); }
			CurrentBrowser = vnxCreateCEF("Scoreboard", TacticsScoreboardPath);
			CurrentBrowserPath = TacticsScoreboardPath;
			alt.log("Scoreboard for " + GetCurrentLobby() + " Created! ");
		}
	}
}


alt.onServer('UpdateScoreboard_Event', (pl_li) => {
	CheckCurrentBrowser();
	if (CurrentBrowser != null) {
		CurrentBrowser.emit("FillScoreboard", pl_li);
		//alt.log(Object.keys(pl_li));
	}
});



/*
alt.onServer('ScoreBoard_Allow', () => {
	allowed = false;
	alt.setTimeout(function () {
		allowed = true;
	}, 350);
});*/


export function KeyDown(key) {
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

export function KeyUp(key) {
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
