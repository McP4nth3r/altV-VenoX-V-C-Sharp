//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives"
import { interpolateCamera, destroyCamera } from '../../Globals/VnX-Lib/camera';
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../Globals/VnX-Lib';
import { LoadChat } from '../../Globals/Chat';

let loginbrowser = null;
let Login_Timer_Load = undefined;
let Login_Value = 0;
let Login_Value_2 = 0;
let Login_Kamera = undefined;

alt.onServer('showLoginWindow', (name, changelogs) => {
	alt.setTimeout(() => {
		var localplayer = alt.Player.local;
		if (loginbrowser != null) {
			vnxDestroyCEF("LoginRegister");
			loginbrowser = null;
		}
		loginbrowser = vnxCreateCEF("LoginRegister", "preload/login/main.html");
		alt.gameControlsEnabled(false);
		ShowCursor(true);
		alt.setTimeout(() => {
			ShowCursor(false);
			ShowCursor(true);
			loginbrowser.focus();
		}, 1000);
		loginbrowser.focus();
		loginbrowser.on('request_player_login', (n, p) => {
			alt.emitServer("LoginAccount", n, p);
		});
		loginbrowser.on('Register:First', (username, email, password, password_retype, GenderSelected) => {
			alt.emitServer("Account:Register", username, email, password, password_retype, parseInt(GenderSelected), true);
			alt.log('Emitted to the Server : ' + username + " | " + email + " | " + password + " | " + password_retype + " | " + parseInt(GenderSelected));
		});
		game.setEntityHeading(localplayer.scriptID, 60);
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
	vnxDestroyCEF("LoginRegister");
	loginbrowser = null;
	OnPlayerSpawnLoad();
	ShowCursor(false);
	destroyCamera();
	game.displayRadar(true);
	game.displayHud(true);
	LoadChat();
	if (Login_Timer_Load != undefined) {
		alt.clearInterval(Login_Timer_Load);
	}
	if (alt.Discord.currentUser) {
		alt.emitServer('Discord:Auth', true, alt.Discord.currentUser.id, alt.Discord.currentUser.name, alt.Discord.currentUser.avatar, alt.Discord.currentUser.discriminator);
	}
	else {
		alt.emitServer('Discord:Auth', false, -1, "ERROR", "ERROR2", "ERROR");
	}
});

alt.onServer('showLoginError', () => {

});

alt.onServer("SetCamera_Event_Login", (StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber) => {
	game.displayRadar(false);
	game.displayHud(false);
	interpolateCamera(StartPosition.x, StartPosition.y, StartPosition.z, StartRotation.x, StartRotation.y, StartRotation.z, Fov, EndPosition.x, EndPosition.y, EndPosition.z, EndRotation.x, EndRotation.y, EndRotation.z, Fov, time);
});


alt.onServer("DestroyCamera_Event", () => {
	destroyCamera();
	game.displayRadar(true);
	game.displayHud(true);
});

function VnX_LoadCamera_Event() {
	Login_Timer_Load = alt.setInterval(function () {
		alt.emitServer("Load_New_Login_Cam", Login_Value, Login_Value_2);
	}, 60000);
}
