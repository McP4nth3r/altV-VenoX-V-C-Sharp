//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives"
import { ShowCursor, GetCursorStatus } from '../../Globals/VnX-Lib';
import { interpolateCamera, destroyCamera } from '../../Globals/VnX-Lib/camera';

let loginbrowser = null;
let Login_Timer_Load = undefined;
let Login_Value = 0;
let Login_Value_2 = 0;
let Login_Kamera = undefined;

alt.onServer('showLoginWindow', (name, changelogs) => {
	alt.setTimeout(() => {
		var localplayer = alt.Player.local;
		if (loginbrowser != null) {
			loginbrowser.destroy();
			loginbrowser = null;
		}
		loginbrowser = new alt.WebView("http://resource/VenoXV_Client/preload/login/main.html");
		alt.gameControlsEnabled(false);
		alt.setTimeout(() => {
			ShowCursor(true);
			loginbrowser.focus();
		}, 500);
		loginbrowser.on('request_player_login', (n, p) => {
			alt.emitServer("loginAccount", n, p);
		});
		game.freezeEntityPosition(localplayer.scriptID, true);
		game.displayRadar(false);
		game.displayHud(false);
		//game.disableAllControlActions(localplayer.scriptID);
		VnX_LoadCamera_Event();
	}, 3000);
});

const statNames = ["SP0_STAMINAï»¿", "SP0_STRENGTH", "SP0_LUNG_CAPACITY", "SP0_WHEELIE_ABILITY", "SP0_FLYING_ABILITY", "SP0_SHOOTING_ABILITY"];
// maybe playerReady can be used instead, haven't tested
function OnPlayerSpawnLoad() {
	for (const stat of statNames) game.statSetInt(statNames, 100, false);
};


export function BasicKeyBinds(key) {
	switch (key) {
		case 0x4B:
			if (alt.Player.local.vehicle && game.getPedInVehicleSeat(alt.Player.local.vehicle.scriptID, -1) == alt.Player.local.scriptID && !GetCursorStatus()) {
				alt.emitServer("engineOnEventKey");
			}
			break;
		case 0x45:
			//if (!GetCursorStatus()) {
			alt.emitServer("checkPlayerEventKey");
			//}
			break;
	}
}


alt.onServer('DestroyLoginWindow', () => {
	if (loginbrowser != null) {
		loginbrowser.destroy();
		loginbrowser = null;
		OnPlayerSpawnLoad();
		ShowCursor(false);
		destroyCamera();
	}
	if (Login_Timer_Load != undefined) {
		alt.clearInterval(Login_Timer_Load);
	}
});

alt.onServer('showLoginError', () => {

});

alt.onServer("SetCamera_Event_Login", (StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber) => {
	interpolateCamera(StartPosition.x, StartPosition.y, StartPosition.z, StartRotation.z, Fov, EndPosition.x, EndPosition.y, EndPosition.z, EndRotation.z, 0, time);
});

function VnX_LoadCamera_Event() {
	Login_Timer_Load = alt.setInterval(function () {
		alt.emitServer("Load_New_Login_Cam", Login_Value, Login_Value_2);
	}, 60000);
}