//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCursor } from '../../VnX-Lib';


let HUD_BROWSER = null;
let executed = true;
let stexecuted = true;
let allowed = true;
let removed = false;
let RemovedSeat = false; //	browser.execute(`document.getElementById('class_` + getRandomInt(11) + `').play();
let hungermain = 0;
let CURRENT_HUD = 0;

let gamemode_version = "1.1.1";
let RageMP_version = "0.3.7";
let resolution = undefined;
let handcuffed = false;


//mp.voiceChat.muted = true;

alt.onServer('SetVoiceStatusVnX', (state) => {
	//mp.voiceChat.muted = state;
});


alt.onServer('Reallife:LoadHUD', (e) => {
	if (HUD_BROWSER != null) {
		HUD_BROWSER.destroy();
	}
	if (e == 0) {
		HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/hud/main/main.html");
		hungermain = 14;
		CURRENT_HUD = e;
		//HUD_BROWSER.execute(`$("#Main").removeClass("d-none")`);
	}
	else if (e == 1) {
		HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/second/main.html");
		hungermain = 10.70;
		CURRENT_HUD = e;
		//HUD_BROWSER.execute(`$("#Main").removeClass("d-none")`);
	}
});

alt.onServer('Tactics:LoadHUD', () => {
	if (HUD_BROWSER != null) {
		HUD_BROWSER.destroy();
	}
	HUD_BROWSER = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/second/main.html");
	hungermain = 14;
	CURRENT_HUD = 0;
});

/*
mp.keys.bind(18, true, function () {
   if (mp.gui.cursor.show) {
	   mp.gui.cursor.show = false;
   }
   else {
	   mp.gui.cursor.show = true;
   }
});*/

function clear_data_storage_hud(e) {
	if (e == "stars") {
		//HUD_BROWSER.execute(`$("#star_1").addClass("d-none");$("#star_2").addClass("d-none");$("#star_3").addClass("d-none");$("#star_4").addClass("d-none");$("#star_5").addClass("d-none");$("#star_6").addClass("d-none");`);
	}
	if (e == "faction") {
		//HUD_BROWSER.execute(`$("#HUD_FACTION_0").addClass("d-none");$("#HUD_FACTION_1").addClass("d-none");$("#HUD_FACTION_2").addClass("d-none");$("#HUD_FACTION_3").addClass("d-none");$("#HUD_FACTION_5").addClass("d-none");$("#HUD_FACTION_6").addClass("d-none");$("#HUD_FACTION_7").addClass("d-none");$("#HUD_FACTION_8").addClass("d-none");$("#HUD_FACTION_9").addClass("d-none");$("#HUD_FACTION_10").addClass("d-none");$("#HUD_FACTION_11").addClass("d-none");$("#HUD_FACTION_12").addClass("d-none");$("#HUD_FACTION_13").addClass("d-none");`);
	}
}

alt.onServer('UpdateHUD', (e, f, fr, m, s, h, fid, a, qold, qimg, qc, qw) => {
	if (a == "ja") {
		//HUD_BROWSER.execute(`$("#quest_showed").removeClass("d-none"); $("#QuestMain_` + qold + `").addClass("d-none"); $("#QuestMain_` + qimg + `").removeClass("d-none"); document.getElementById('QuestMain_container').innerHTML="` + qc + `";document.getElementById('QuestMain_container_win').innerHTML="` + qw + `";`);
	} else {
		//HUD_BROWSER.execute(`$("#quest_showed").addClass("d-none");`);
	}
	if (h == 1) {
		//HUD_BROWSER.execute(`$("#Main").addClass("d-none")`);
		executed = true;
		return;
	}
	if (executed == true) {
		//HUD_BROWSER.execute(`$("#Main").removeClass("d-none")`);
		executed = false;
	};
	if (CURRENT_HUD == 0) { //HUD_BROWSER.execute(`document.getElementById('HUD_Player_Name').innerHTML="` + e + `";document.getElementById('HUD_Money').innerHTML="` + m + `"; `); }
   else if (CURRENT_HUD == 1) { //HUD_BROWSER.execute(`document.getElementById('HUD_Player_Name').innerHTML="` + e + `";document.getElementById('HUD_Faction_Name').innerHTML="` + f + `";document.getElementById('HUD_Faction_Rank').innerHTML="` + fr + `";document.getElementById('HUD_Money').innerHTML="` + m + `"; `); }
			if (fid >= 0) {
				//HUD_BROWSER.execute(`$("#HUD_FACTION_` + fid + `").removeClass("d-none")`);
			}
			if (s == 0) {
				//HUD_BROWSER.execute(`$("#stars_load").addClass("d-none")`);
				stexecuted = true;
				return;
			}
			if (stexecuted == true) {
				//HUD_BROWSER.execute(`$("#stars_load").removeClass("d-none")`);
				stexecuted = false;
			};
			//HUD_BROWSER.execute(`$("#star_` + s + `").removeClass("d-none")`);
		});

alt.onServer('UpdateStars', (s, h) => {
	if (h == 1) {
		return;
	}
	if (s == 0) {
		clear_data_storage_hud("stars");
		//HUD_BROWSER.execute(`$("#stars_load").addClass("d-none")`);
		stexecuted = true;
		return;
	}
	if (stexecuted == true) {
		//HUD_BROWSER.execute(`$("#stars_load").removeClass("d-none")`);
		stexecuted = false;
	};
	clear_data_storage_hud("stars");
	//HUD_BROWSER.execute(`$("#star_` + s + `").removeClass("d-none")`);
});

alt.onServer('UpdateFaction', (f, fr, v) => {
	if (v == 0) {
		if (CURRENT_HUD == 1) {
			clear_data_storage_hud("faction");
			//HUD_BROWSER.execute(`document.getElementById('HUD_Faction_Name').innerHTML="` + f + `"; document.getElementById('HUD_Faction_Rank').innerHTML="` + fr + `";`);
		}
		return;
	}
	clear_data_storage_hud("faction");
	if (CURRENT_HUD == 0) { //HUD_BROWSER.execute(`$("#HUD_FACTION_` + v + `").removeClass("d-none");`); }
   else if (CURRENT_HUD == 1) { //HUD_BROWSER.execute(`document.getElementById('HUD_Faction_Name').innerHTML="` + f + `"; document.getElementById('HUD_Faction_Rank').innerHTML="` + fr + `";$("#HUD_FACTION_` + v + `").removeClass("d-none");`); }
		});



alt.onServer('UpdateHunger', (e) => {
	let currenthunger = hungermain * (e / 100);
	if (CURRENT_HUD == 0) {
		//HUD_BROWSER.execute(`document.getElementById('main_hud_hunger_1').style.width="` + currenthunger + `vw";document.getElementById('main_hud_hunger_text').innerHTML="` + e + `%";`);
	}
	else if (CURRENT_HUD == 1) {
		//HUD_BROWSER.execute(`document.getElementById('main_hud_hunger_1').style.width="` + currenthunger + `vw"; document.getElementById('main_hud_hunger_2').style.width="` + currenthunger + `vw";document.getElementById('main_hud_hunger_text').innerHTML="` + e + `%";`);
	}
});

alt.onServer('UpdateHealth', (a, h) => {
	if (CURRENT_HUD == 0) {
		let currentarmor = hungermain * (a / 100);
		let currenthealth = hungermain * (h / 100);
		//HUD_BROWSER.execute(`document.getElementById('main_hud_health_1').style.width="` + currenthealth + `vw"; document.getElementById('main_hud_health_1_text').innerHTML="` + h + `%";document.getElementById('main_hud_armor_1').style.width="` + currentarmor + `vw"; document.getElementById('main_hud_armor_1_text').innerHTML="` + a + `%";`);
	}
});


alt.onServer('toggleHandcuffed', (toggle) => {
	handcuffed = toggle;
});
/*
mp.keys.bind(0x73, true, function () {
   //mp.voiceChat.muted = !//mp.voiceChat.muted;
   mp.game.graphics.notify("VoiceChat: " + ((!//mp.voiceChat.muted) ? "~g~Angeschaltet" : "~r~Ausgeschaltet"));
   if (//mp.voiceChat.muted == false) { //HUD_BROWSER.execute(`$("#Muted").addClass("d-none"); $("#NMuted").removeClass("d-none");`); }
   else { //HUD_BROWSER.execute(`$("#Muted").removeClass("d-none"); $("#NMuted").addClass("d-none");`); }
   });

var lastHealth = 0;
var lastArmor = 0;


alt.onServer('pressgkey', () => {
   const localPlayer = mp.players.local;
   if (localPlayer.vehicle === null) {
	   let seats = 0;
	   let remoteId = 0;
	   let isVehicleFound = false;
	   mp.vehicles.forEachInStreamRange((vehicle) => {
		   const dist = distanceTo(localPlayer.position, vehicle.position);
		   if (!isVehicleFound && (localPlayer.isOnSpecificVehicle(vehicle.handle) || dist < 4)) {
			   isVehicleFound = true;
			   seats = vehicle.getMaxNumberOfPassengers();
			   remoteId = vehicle.remoteId;
			   if (seats < 1 || seats === 1) {
				   isVehicleFound = false;
				   mp.players.local.taskEnterVehicle(vehicle.handle, 5000, 0, 2.0, 1, 0);
			   } else {
				   ShowCursor(true);
				   //HUD_BROWSER.execute("$('#VehicleSeat_State').removeClass('d-none');showSeatSelection(" + seats + ", " + remoteId + ");");
			   }
		   }
	   });
   }
});

alt.onServer('log_dmg_ped', (e, w, v) => {
   alt.emitServer('log_damage_ped', e, w, v);
   //HUD_BROWSER.execute(`document.getElementById('hit').currentTime = 0; document.getElementById('hit').play(); document.getElementById('hit').volume = 0.15;`);
});

alt.onServer('Tactics:PlayHitsound', () => {
   //HUD_BROWSER.execute(`document.getElementById('hit').currentTime = 0; document.getElementById('hit').play(); document.getElementById('hit').volume = 0.15;`);
});

alt.onServer('closeSeatCef', () => {
   //HUD_BROWSER.execute("$('#VehicleSeat_State').addClass('d-none');");
   ShowCursor(false);
});


alt.onServer('takeSeat', (seatNum, remoteId) => {
   const vehicle = mp.vehicles.atRemoteId(remoteId);
   let seats = vehicle.getMaxNumberOfPassengers();
   if (seats > 6) {
	   if (seatNum < 4) {
		   mp.players.local.taskEnterVehicle(vehicle.handle, 5000, seatNum, 2.0, 1, 0);
	   } else {
		   mp.players.local.taskWarpIntoVehicle(vehicle.handle, seatNum);
	   }
   }
   else {
	   mp.players.local.taskEnterVehicle(vehicle.handle, 5000, seatNum, 2.0, 1, 0);
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
   if (gwtimer != null) { clearInterval(gwtimer); }
   gwtimer = setInterval(function () {
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
/*
alt.onServer("playerQuit", (p, t, r) => {
   if (p == mp.players.local)
   {
	   if(gwtimer != null){ clearInterval(gwtimer);}
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

   /*if (!mp.game.graphics.hasStreamedTextureDictLoaded("mpinventory")) {
	   mp.game.graphics.requestStreamedTextureDict("mpinventory", true);
   }

   if (!mp.game.graphics.hasStreamedTextureDictLoaded("mpleaderboard")) {
	   mp.game.graphics.requestStreamedTextureDict("mpleaderboard", true);
   }

   if (mp.game.graphics.hasStreamedTextureDictLoaded("mpinventory") && mp.game.graphics.hasStreamedTextureDictLoaded("mpleaderboard")) {
	   mp.game.graphics.drawSprite("mpinventory", "deathmatch", 0.826, 0.30, 0.025, 0.025, 0, 255, 255, 255, 255);
	   mp.game.graphics.drawText(Current_Kills.toString() + " KILLS", [0.850, 0.289], { font: 4, color: [225, 225, 225, 255], scale: [0.35, 0.33], outline: true });

	   mp.game.graphics.drawSprite("mpinventory", "mp_specitem_weapons", 0.8935, 0.30, 0.0215, 0.0215, 0, 255, 255, 255, 255);
	   mp.game.graphics.drawText(Math.ceil(Current_Damage.toString()) + " DMG", [0.92, 0.289], { font: 4, color: [225, 225, 225, 255], scale: [0.4, 0.33], outline: true });

	   mp.game.graphics.drawSprite("mpleaderboard", "leaderboard_time_icon", 0.956, 0.30, 0.027, 0.027, 0, 255, 255, 255, 255);
	   mp.game.graphics.drawText(GW_COUNTDOWN, [0.979, 0.289], { font: 4, color: [225, 225, 225, 255], scale: [0.5, 0.33], outline: true });
   }

   game.drawRect(0.86, 0.36, 0.09, 0.06, atr, atg, atb, ap);
   mp.game.graphics.drawText(fn1, [0.86, 0.326], { font: 4, color: [225, 225, 225, 255], scale: [0.5, 0.33], outline: false });
   mp.game.graphics.drawText(cma, [0.86, 0.35], { font: 4, color: [225, 225, 225, 255], scale: [0.7, 0.53], outline: false });
   game.drawRect(0.953, 0.36, 0.09, 0.06, dfr, dfg, dfb, ap);
   mp.game.graphics.drawText(fn2, [0.953, 0.326], { font: 4, color: [225, 225, 225, 255], scale: [0.5, 0.33], outline: false });
   mp.game.graphics.drawText(cmd, [0.953, 0.35], { font: 4, color: [225, 225, 225, 255], scale: [0.7, 0.53], outline: false });
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

mp.game.invoke("0x1760FFA8AB074D66", mp.players.local, false);

let DrawSafeZoneNow = false;
function DrawSafezone() {
   if (DrawSafeZoneNow) {
	   game.drawRect(0.91, 0.337, 0.17, 0.005, 0, 105, 145, 175);
	   game.drawRect(0.91, 0.350, 0.17, 0.02, 0, 0, 0, 175);
	   game.drawRect(0.91, 0.39, 0.17, 0.10, 0, 0, 0, 175);
	   //mp.game.graphics.drawText("VenoX Reallife NO-DM Zone", [0.91, 0.338], { font: 1, color: [200, 200, 200, 255], scale: [0.4, 0.4], outline: true });
	   //mp.game.graphics.drawText("Du hast eine NO-DM Zone betreten!\nJegliches Deathmatch ist verboten!\nAusnahme : Staatsfraktionen.", [0.91, 0.367], { font: 0, color: [0, 150, 200, 255], scale: [0.3, 0.25], outline: false });
   }
}

alt.onServer('Greenzone:ChangeStatus', (e) => {
   DrawSafeZoneNow = e;
});
*/
alt.everyTick(() => {
	CheckKilledNPCs();
	var healthLoss = 0;
	let a = mp.players.local.getArmour();
	let h = mp.players.local.getHealth();
	if (lastHealth != mp.players.local.getHealth()) {
		healthLoss = lastHealth - mp.players.local.getHealth();
		lastHealth = mp.players.local.getHealth();
	}
	if (healthLoss > 0) {
		if (CURRENT_HUD == 0) {
			let currentarmor = hungermain * (a / 100);
			let currenthealth = hungermain * (h / 100);
			//HUD_BROWSER.execute(`showBloodscreen(); document.getElementById('main_hud_health_1').style.width="` + currenthealth + `vw"; document.getElementById('main_hud_health_1_text').innerHTML="` + h + `%";document.getElementById('main_hud_armor_1').style.width="` + currentarmor + `vw"; document.getElementById('main_hud_armor_1_text').innerHTML="` + a + `%";`);
		}
		else {
			//HUD_BROWSER.execute(`showBloodscreen()`);
		}
	}
	var armorLoss = 0;
	if (lastArmor != mp.players.local.getArmour()) {
		armorLoss = lastArmor - mp.players.local.getArmour();
		lastArmor = mp.players.local.getArmour();
	}
	if (armorLoss > 0) {
		if (CURRENT_HUD == 0) {
			let currentarmor = hungermain * (a / 100);
			let currenthealth = hungermain * (h / 100);
			//HUD_BROWSER.execute(`showBloodscreen(); document.getElementById('main_hud_health_1').style.width="` + currenthealth + `vw"; document.getElementById('main_hud_health_1_text').innerHTML="` + h + `%";document.getElementById('main_hud_armor_1').style.width="` + currentarmor + `vw"; document.getElementById('main_hud_armor_1_text').innerHTML="` + a + `%";`);
		}
		else {
			//HUD_BROWSER.execute(`showBloodscreen()`);
		}
	}

	mp.game.ui.displayAmmoThisFrame(false);
	if (allowed == true) {
		if (mp.gui.cursor.visible == false && mp.keys.isDown(0x4D) === true) {
			if (removed == false) {
				//HUD_BROWSER.execute(`$("#Muted").addClass("d-none")`);
				//HUD_BROWSER.execute(`$("#NMuted").removeClass("d-none")`);
				removed = true;
				//mp.voiceChat.muted = false;
			}
		}
		else {
			if (removed == true) {
				//HUD_BROWSER.execute(`$("#Muted").removeClass("d-none")`);
				//HUD_BROWSER.execute(`$("#NMuted").addClass("d-none")`);
				removed = false;
				//mp.voiceChat.muted = true;
			}
		}
	}
	const controls = mp.game.controls;
	controls.enableControlAction(0, 23, true);
	controls.disableControlAction(0, 58, true);
	if (mp.players.local.getVariable("PLAYER_ADMIN_ON_DUTY") == 1) { mp.players.local.setProofs(true, true, true, true, true, true, true, true); }
	else if (mp.players.local.vehicle) {
		mp.players.local.setProofs(false, false, false, false, false, false, false, false);
	}
	else {
		mp.players.local.setProofs(true, false, false, false, false, false, false, false);
	}

	if (controls.isDisabledControlJustPressed(0, 58) && mp.gui.cursor.visible == false) {
		mp.events.call('pressgkey')
	}
	if (mp.players.local.isSprinting()) {
		mp.game.player.restoreStamina(100);
	}
	mp.game.player.setHealthRechargeMultiplier(0.0);
	let player = mp.players.local;
	let currentTime = new Date().getTime();
	mp.game.graphics.drawText("German Venox Reallife " + gamemode_version + " dev r1", [0.927, 0.96], { font: 0, color: [225, 225, 225, 175], scale: [0.6, 0.3], outline: false });
	mp.game.graphics.drawText("Rage:MP " + RageMP_version, [0.970, 0.98], { font: 0, color: [225, 225, 225, 135], scale: [0.6, 0.3], outline: false });
	DrawSafezone();
	if (player.getVariable('HideHUD') != 1) {
		if (isGW) { drawGW(); }

		let waffe = mp.players.local.weapon;
		let ammo = mp.players.local.getAmmoInClip(waffe);
		var weapon = GetWeaponData(waffe, "Name");
		if (weapon == "Tazer" || weapon == "Schlagstock" || weapon == "Taschenlampe") { ammo = "-" };
		if (weapon != "unbewaffnet" && weapon != undefined) {
			if (CURRENT_HUD == 0) {
				if (weapon.length < 6) {
					mp.game.graphics.drawText(weapon, [0.77, 0.040], { font: 1, color: [0, 150, 200, 255], scale: [0.5, 0.5], outline: true });
					mp.game.graphics.drawText(ammo, [0.77, 0.070], { font: 1, color: [0, 105, 145, 255], scale: [0.425, 0.425], outline: true });
				}
				else {
					mp.game.graphics.drawText(weapon, [0.75, 0.040], { font: 1, color: [0, 150, 200, 255], scale: [0.5, 0.5], outline: true });
					mp.game.graphics.drawText(ammo, [0.75, 0.070], { font: 1, color: [0, 105, 145, 255], scale: [0.425, 0.425], outline: true });
				}
			}
			else if (CURRENT_HUD == 1) {
				if (weapon.length < 6) {
					mp.game.graphics.drawText(weapon, [0.80, 0.040], { font: 1, color: [0, 150, 200, 255], scale: [0.5, 0.5], outline: true });
					mp.game.graphics.drawText(ammo, [0.80, 0.070], { font: 1, color: [0, 105, 145, 255], scale: [0.425, 0.425], outline: true });
				}
				else {
					mp.game.graphics.drawText(weapon, [0.78, 0.040], { font: 1, color: [0, 150, 200, 255], scale: [0.5, 0.5], outline: true });
					mp.game.graphics.drawText(ammo, [0.78, 0.070], { font: 1, color: [0, 105, 145, 255], scale: [0.425, 0.425], outline: true });
				}

			}
		}
		if (player.getVariable('PLAYER_KNASTZEIT') > 0) {
			game.drawRect(0.91, 0.337, 0.17, 0.005, 0, 105, 145, 175);
			game.drawRect(0.91, 0.350, 0.17, 0.02, 0, 0, 0, 175);
			game.drawRect(0.91, 0.37, 0.17, 0.06, 0, 0, 0, 175);
			mp.game.graphics.drawText("VenoX Police Department", [0.91, 0.338], { font: 1, color: [200, 200, 200, 255], scale: [0.4, 0.4], outline: true });
			mp.game.graphics.drawText("Du bist noch " + player.getVariable('PLAYER_KNASTZEIT') + " Minuten im Knast.", [0.91, 0.367], { font: 0, color: [200, 200, 200, 255], scale: [0.3, 0.3], outline: false });
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
});
