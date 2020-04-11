//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCursor, GetCursorStatus } from '../../VnX-Lib';
import { GetWeaponData } from '../../Weapons/Combat';
import { CreateThirdHUD } from './third';


let HUD_BROWSER = null;
let CURRENT_HUD = 0;
let handcuffed = false;


//mp.voiceChat.muted = true;

alt.onServer('SetVoiceStatusVnX', (state) => {
	//mp.voiceChat.muted = state;
});




alt.onServer('Reallife:LoadHUD', (e) => {
	if (HUD_BROWSER != null) {
		HUD_BROWSER.destroy();
	}
	switch (e) {
		case 0:
			HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/hud/main/main.html");
			CURRENT_HUD = e;
			HUD_BROWSER.emit("HUD:Show");
			break;
		case 1:
			HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/hud/second/main.html");
			CURRENT_HUD = e;
			HUD_BROWSER.emit("HUD:Show");
			break;
		case 3:
			CreateThirdHUD();
			CURRENT_HUD = e;
			break
	}
	alt.log(e);
});
/*
alt.onServer('Tactics:LoadHUD', () => {
	if (HUD_BROWSER != null) {
		HUD_BROWSER.destroy();
	}
	HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/second/main.html");
	CURRENT_HUD = 0;
});
*/
/*
mp.keys.bind(18, true, function () {
   if (mp.gui.cursor.show) {
	   mp.gui.cursor.show = false;
   }
   else {
	   mp.gui.cursor.show = true;
   }
});*/


alt.onServer('UpdateHUD', (e, f, fr, m, s, h, fid, a, qold, qimg, qc, qw) => {
	if (HUD_BROWSER == null) { return; }
	HUD_BROWSER.emit("HUD:UpdateMain", e, f, fr, m, s, h, fid, a, qold, qimg, qc, qw);
});


alt.onServer('UpdateStars', (s, h) => {
	if (HUD_BROWSER == null) { return; }
	HUD_BROWSER.emit("HUD:UpdateStars", s, h);
});

alt.onServer('UpdateFaction', (f, fr, v) => {
	if (HUD_BROWSER == null) { return; }
	HUD_BROWSER.emit("HUD:UpdateFaction", f, fr, v);
});



alt.onServer('UpdateHunger', (e) => {
	if (HUD_BROWSER == null) { return; }
	HUD_BROWSER.emit("HUD:UpdateHunger", e);
});

alt.onServer('UpdateHealth', (a, h) => {
	if (HUD_BROWSER == null) { return; }
	HUD_BROWSER.emit("HUD:UpdateHealth", a, h, CURRENT_HUD);
});


alt.onServer('toggleHandcuffed', (toggle) => {
	handcuffed = toggle;
});
/*
mp.keys.bind(0x73, true, function () {
	//mp.voiceChat.muted = !//mp.voiceChat.muted;
	mp.game.graphics.notify("VoiceChat: " + ((!//mp.voiceChat.muted) ? "~g~Angeschaltet" : "~r~Ausgeschaltet"));
   if (//mp.voiceChat.muted == false) { //HUD_BROWSER.execute(`$("#Muted").addClass("d-none"); $("#NMuted").removeClass("d-none"); `); }
   else { //HUD_BROWSER.execute(`$("#Muted").removeClass("d-none"); $("#NMuted").addClass("d-none"); `); }
	});

var lastHealth = 0;
var lastArmor = 0;*/


alt.onServer('pressgkey', () => {
	if (HUD_BROWSER == null) { return; }
	const localPlayer = alt.Player.local;
	if (localPlayer.vehicle === null) {
		let seats = 0;
		let remoteId = 0;
		let isVehicleFound = false;
		alt.Vehicle.all((vehicle) => {
			const dist = distanceTo(localPlayer.pos, vehicle.pos);
			if (!isVehicleFound && dist < 4) {
				isVehicleFound = true;
				seats = game.getVehicleMaxNumberOfPassengers(vehicle.scriptID);
				remoteId = vehicle.scriptID;
				if (seats < 1 || seats === 1) {
					isVehicleFound = false;
					game.taskEnterVehicle(localPlayer.scriptID, vehicle.scriptID, 5000, 0, 2.0, 1, 0);
				} else {
					ShowCursor(true);
					HUD_BROWSER.emit("HUD:ShowVehicleSeats", seats, remoteId);
				}
			}
		});
	}
});

alt.onServer('log_dmg_ped', (e, w, v) => {
	alt.emitServer('log_damage_ped', e, w, v);
	//HUD_BROWSER.execute(`document.getElementById('hit').currentTime = 0; document.getElementById('hit').play(); document.getElementById('hit').volume = 0.15; `);
});

alt.onServer('closeSeatCef', () => {
	//HUD_BROWSER.execute("$('#VehicleSeat_State').addClass('d-none');");
	ShowCursor(false);
});


alt.onServer('takeSeat', (seatNum, remoteId) => {
	let vehicle;
	alt.Vehicle.all((veh) => {
		if (veh.scriptID == remoteId) {
			vehicle = veh;
		}
	});
	if (vehicle == null) { return; }
	let seats = vehicle.getMaxNumberOfPassengers();
	if (seats > 6) {
		if (seatNum < 4) {
			game.taskEnterVehicle(localPlayer.scriptID, vehicle.scriptID, 5000, seatNum, 2.0, 1, 0);

		} else {
			game.taskWarpPedIntoVehicle(alt.Player.local.scriptID, vehicle.scriptID, seatNum);
		}
	}
	else {
		game.taskEnterVehicle(localPlayer.scriptID, vehicle.scriptID, 5000, seatNum, 2.0, 1, 0);
	}
	ShowCursor(false);
	//HUD_BROWSER.execute("$('#VehicleSeat_State').addClass('d-none');");
});

function distanceTo(vec1, vec2) {
	return Math.hypot(vec2.x - vec1.x, vec2.y - vec1.y, vec2.z - vec1.z);
}

var GW_COUNTDOWN = "";

let gwtimer = null;
function startTimer(duration) {
	var timer = duration, minutes, seconds;
	if (gwtimer != null) { alt.clearInterval(gwtimer); }
	gwtimer = alt.setInterval(function () {
		minutes = parseInt(timer / 60, 10);
		seconds = parseInt(timer % 60, 10);

		minutes = minutes < 10 ? "0" + minutes : minutes;
		seconds = seconds < 10 ? "0" + seconds : seconds;

		GW_COUNTDOWN = minutes + ":" + seconds;

		if (--timer < 0) {
			timer = duration;
		}
	}, 1000);
}

alt.onServer("playerQuit", (p, t, r) => {
	if (p == mp.players.local) {
		if (gwtimer != null) { alt.clearInterval(gwtimer); }
	}
});

let countdownexec = false;
let Current_Damage = 0;
let Current_Kills = 0;
var isGW = false;
let fn1 = "ERROR_1";
let fn2 = "ERROR_2";
let cma = "ERROR_3";
let cmd = "ERROR_4";
let atr = 255;
let atg = 255;
let atb = 255;
let dfr = 255;
let dfg = 255;
let dfb = 255;
let ap = 175;
function drawGW() {
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

	if (game.hasStreamedTextureDictLoaded("mpinventory") && game.hasStreamedTextureDictLoaded("mpleaderboard")) {
		game.drawSprite("mpinventory", "deathmatch", 0.826, 0.30, 0.025, 0.025, 0, 255, 255, 255, 255);
		DrawText(Current_Kills.toString() + " KILLS", [0.850, 0.289], [0.35, 0.33], 4, [225, 225, 225, 255], true);


		game.drawSprite("mpinventory", "mp_specitem_weapons", 0.8935, 0.30, 0.0215, 0.0215, 0, 255, 255, 255, 255);
		DrawText(Math.ceil(Current_Damage.toString()) + " DMG", [0.92, 0.289], [0.4, 0.33], 4, [225, 225, 225, 255], true, true);

		game.drawSprite("mpleaderboard", "leaderboard_time_icon", 0.956, 0.30, 0.027, 0.027, 0, 255, 255, 255, 255);
		DrawText(GW_COUNTDOWN, [0.979, 0.289], [0.5, 0.33], 4, [225, 225, 225, 255], true, true);
	}

	game.drawRect(0.86, 0.36, 0.09, 0.06, atr, atg, atb, ap);
	DrawText(fn1, [0.86, 0.326], [0.5, 0.33], 4, [225, 225, 225, 255], true);
	DrawText(cma, [0.86, 0.35], [0.8, 0.53], 4, [225, 225, 225, 255], true, true);
	game.drawRect(0.953, 0.36, 0.09, 0.06, dfr, dfg, dfb, ap);
	DrawText(fn2, [0.953, 0.326], [0.5, 0.33], 4, [225, 225, 225, 255], true, true);
	DrawText(cmd, [0.953, 0.35], [0.5, 0.33], 4, [225, 225, 225, 255], true, true);
}


alt.onServer('gw:updateStats', (e, e1, cma_, cmd_) => {
	Current_Damage = e;
	Current_Kills = e1;
	cma = cma_;
	cmd = cmd_;

});

alt.onServer('gw:updateTime', (v) => {
	startTimer(v);
});

alt.onServer('gw:joinedPlayer', (cma_, cmd_) => {
	cma = cma_;
	cmd = cmd_;
});

alt.onServer('gw:showUp', (e, fn1_, fn2_, atr_, atg_, atb_, dfr_, dfg_, dfb_) => {
	if (e) {
		isGW = e;
		fn1 = fn1_;
		fn2 = fn2_;
		atr = atr_;
		atg = atg_;
		atb = atb_;
		dfr = dfr_;
		dfg = dfg_;
		dfb = dfb_;
	} else {
		setTimeout(function () {
			isGW = e;
			fn1 = fn1_;
			fn2 = fn2_;
			atr = atr_;
			atg = atg_;
			atb = atb_;
			dfr = dfr_;
			dfg = dfg_;
			dfb = dfb_;
		}, 30 * 1000);
	}
});

//mp.game.invoke("0x1760FFA8AB074D66", mp.players.local, false);

let DrawSafeZoneNow = false;
function DrawSafezone() {
	if (DrawSafeZoneNow) {
		game.drawRect(0.91, 0.337, 0.17, 0.005, 0, 105, 145, 175);
		game.drawRect(0.91, 0.350, 0.17, 0.02, 0, 0, 0, 175);
		game.drawRect(0.91, 0.39, 0.17, 0.10, 0, 0, 0, 175);
		DrawText("VenoX Reallife NO-DM Zone", [0.91, 0.338], [0.4, 0.4], 1, [200, 200, 200, 255], true, true);
		DrawText("Du hast eine NO-DM Zone betreten!\nJegliches Deathmatch ist verboten!\nAusnahme : Staatsfraktionen.", [0.91, 0.367], [0.3, 0.25], 0, [0, 150, 200, 255], false);
	}
}

alt.onServer('Greenzone:ChangeStatus', (e) => {
	DrawSafeZoneNow = e;
});

export function RenderHUDs() {
	let player = alt.Player.local;
	game.displayAmmoThisFrame(false);

	game.enableControlAction(0, 23, true);
	game.disableControlAction(0, 58, true);
	if (game.isDisabledControlJustPressed(0, 58) && !GetCursorStatus()) {
		alt.emit('pressgkey');
	}
	if (game.isPedSprinting(player.scriptID)) {
		game.restorePlayerStamina(player.scriptID, 100);
	}
	game.setPlayerHealthRechargeMultiplier(player.scriptID, 0.0);

	DrawSafezone();
	if (player.getSyncedMeta("HideHUD") != 1) {
		if (isGW) { drawGW(); }

		let waffe = game.getSelectedPedWeapon(player.scriptID);
		let ammo = "" + game.getAmmoInPedWeapon(player.scriptID, waffe);
		var weapon = GetWeaponData(waffe, "Name");
		if (weapon == "Tazer" || weapon == "Schlagstock" || weapon == "Taschenlampe") { ammo = "-" };
		if (weapon != "unbewaffnet" && weapon != undefined) {
			if (CURRENT_HUD == 0) {
				if (weapon.length < 6) {
					DrawText(weapon, [0.77, 0.040], [0.5, 0.5], 1, [0, 150, 200, 255], true, true);
					DrawText(ammo, [0.77, 0.070], [0.5, 0.5], 1, [0, 105, 145, 255], true, true);
				}
				else {
					DrawText(weapon, [0.75, 0.040], [0.5, 0.5], 1, [0, 150, 200, 255], true, true);
					DrawText(ammo, [0.75, 0.070], [0.5, 0.5], 1, [0, 105, 145, 255], true, true);
				}
			}
			else if (CURRENT_HUD == 1) {
				if (weapon.length < 6) {
					DrawText(weapon, [0.80, 0.040], [0.5, 0.5], 1, [0, 150, 200, 255], true, true);
					DrawText(ammo, [0.80, 0.070], [0.5, 0.5], 1, [0, 105, 145, 255], true, true);
				}
				else {
					DrawText(weapon, [0.78, 0.040], [0.5, 0.5], 1, [0, 150, 200, 255], true, true);
					DrawText(ammo, [0.78, 0.070], [0.5, 0.5], 1, [0, 105, 145, 255], true, true);
				}

			}
		}
		if (player.getSyncedMeta("PLAYER_KNASTZEIT") > 0) {
			game.drawRect(0.91, 0.337, 0.17, 0.005, 0, 105, 145, 175);
			game.drawRect(0.91, 0.350, 0.17, 0.02, 0, 0, 0, 175);
			game.drawRect(0.91, 0.37, 0.17, 0.06, 0, 0, 0, 175);
			DrawText("VenoX Police Department", [0.91, 0.338], [0.4, 0.4], 1, [200, 200, 200, 255], true, true);
			DrawText("Du bist noch " + player.getSyncedMeta("PLAYER_KNASTZEIT") + " Minuten im Knast.", [0.91, 0.367], [0.3, 0.3], 0, [200, 200, 200, 255], false, true);
		}
	}
	if (handcuffed) {
		game.disableControlAction(alt.Player.local.scriptID, 2, 12, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 13, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 14, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 15, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 16, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 17, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 21, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 22, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 23, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 24, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 25, true);
		game.disableControlAction(alt.Player.local.scriptID, 2, 75, true);
	}
};
