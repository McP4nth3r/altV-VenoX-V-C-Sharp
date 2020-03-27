//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives"
import { ShowCursor, GetCursorStatus } from '../../Globals/VnX-Lib';
import { KeyUp, KeyDown } from '../../Globals/Scoreboard';
import Camera from '../../Globals/VnX-Lib/camera';

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
		loginbrowser = new alt.WebView("http://resource/VenoXV_Client/preload/login/login.html");
		alt.gameControlsEnabled(false);
		loginbrowser.on("loginReady", () => {
			alt.setTimeout(() => {
				loginbrowser.emit("LoginLoad", name, changelogs);
				ShowCursor(true);
				loginbrowser.focus();
			}, 500);
		});
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

const statNames = ["SP0_STAMINAï»¿", "SP0_STRENGTH", "SP0_LUNG_CAPACITY", "SP0_WHEELIE_ABILITY", "SP0_FLYING_ABILITY", "SP0_SHOOTING_ABILITY", "SP0_STEALTH_ABILITY"];
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
	}
	if (Login_Kamera != undefined) {
		CamerasManager.setActiveCamera(Login_Kamera, false);
		//Login_Kamera.destroy();
		Login_Kamera = undefined;
	}
	if (Login_Timer_Load != undefined) {
		alt.clearInterval(Login_Timer_Load);
	}
});

alt.onServer('showLoginError', () => {

});





//Cam : 


alt.onServer("StartCameraMovementVnX", (p1, p2, p3, p4, p5, p6, p7, p8) => {
	//Login_Kamera = CamerasManager.createCamera('Login_C', 'default', p1, p3, p5);
	//CamerasManager.setActiveCameraWithInterp(Login_Kamera, p2, p4, p6, 0, 0);
	alt.log(p1 + " | " + p2 + " | " + p3 + " | " + p4 + " | " + p5 + " | " + p6 + " | " + p7 + " | " + p8);
	Login_Value = p7;
	Login_Value_2 = p8;
});

alt.onServer("SetCamera_Event_Login", (p1, p2, p3, p4, p5, p6, p7, p8) => {
	if (Login_Kamera != undefined) {
		//CamerasManager.setActiveCamera(Login_Kamera, false);
		//Login_Kamera.destroy();
	}

	let camera = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", p1.X, p1.Y, p1.Z, 0, 0, p3.Z, p5, false, 0)[0];
	let interpolCam = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", p2.X, p2.Y, p2.Z, 0, 0, p4.Z, p5, false, 0)[0];
	game.setCamActiveWithInterp(interpolCam, camera, p6, 1, 1);
	game.renderScriptCams(true, false, 0, true, false);

	//StopCam.setActiveWithInterp(StopCam, p6, 0, 0);
	//Login_Kamera = CamerasManager.createCamera('Login_C', 'default', p1, p3, p5);
	//CamerasManager.setActiveCameraWithInterp(Login_Kamera, p2, p4, p6, 0, 0);
	alt.log(p1 + " | " + p2 + " | " + p3 + " | " + p4 + " | " + p5 + " | " + p6 + " | " + p7 + " | " + p8);
	Login_Value = p7;
	Login_Value_2 = p8;
});

function VnX_LoadCamera_Event() {
	Login_Timer_Load = alt.setInterval(function () {
		alt.emitServer("Load_New_Login_Cam", Login_Value, Login_Value_2);
	}, 60000);
}