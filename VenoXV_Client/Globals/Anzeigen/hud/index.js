//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, vnxCreateCEF, vnxDestroyCEF } from '../../VnX-Lib';
import { GetWeaponData } from '../../Weapons/Combat';


let HUD_BROWSER = null;
let CURRENT_HUD = 0;
let handcuffed = false;


alt.onServer('Reallife:LoadHUD', (e) => {
	vnxDestroyCEF("ReallifeHUD");
	HUD_BROWSER = vnxCreateCEF("ReallifeHUD", "Globals/Anzeigen/hud/Reallife/HUD-" + e + "/main.html");
	CURRENT_HUD = e;
	HUD_BROWSER.emit("HUD:Show", true);
});

alt.onServer('Reallife:UnloadHUD', () => {
	vnxDestroyCEF("ReallifeHUD");
});

alt.onServer('toggleHandcuffed', (toggle) => {
	handcuffed = toggle;
});


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


let zoneNamesShort = ["AIRP", "ALAMO", "ALTA", "ARMYB", "BANHAMC", "BANNING", "BEACH", "BHAMCA", "BRADP", "BRADT", "BURTON", "CALAFB", "CANNY", "CCREAK", "CHAMH", "CHIL", "CHU", "CMSW", "CYPRE", "DAVIS", "DELBE", "DELPE", "DELSOL", "DESRT", "DOWNT", "DTVINE", "EAST_V", "EBURO", "ELGORL", "ELYSIAN", "GALFISH", "GOLF", "GRAPES", "GREATC", "HARMO", "HAWICK", "HORS", "HUMLAB", "JAIL", "KOREAT", "LACT", "LAGO", "LDAM", "LEGSQU", "LMESA", "LOSPUER", "MIRR", "MORN", "MOVIE", "MTCHIL", "MTGORDO", "MTJOSE", "MURRI", "NCHU", "NOOSE", "OCEANA", "PALCOV", "PALETO", "PALFOR", "PALHIGH", "PALMPOW", "PBLUFF", "PBOX", "PROCOB", "RANCHO", "RGLEN", "RICHM", "ROCKF", "RTRAK", "SANAND", "SANCHIA", "SANDY", "SKID", "SLAB", "STAD", "STRAW", "TATAMO", "TERMINA", "TEXTI", "TONGVAH", "TONGVAV", "VCANA", "VESP", "VINE", "WINDF", "WVINE", "ZANCUDO", "ZP_ORT", "ZQ_UAR"];

let zoneNames = ["Los Santos International Airport", "Alamo Sea", "Alta", "Fort Zancudo", "Banham Canyon Dr", "Banning", "Vespucci Beach", "Banham Canyon", "Braddock Pass", "Braddock Tunnel", "Burton", "Calafia Bridge", "Raton Canyon", "Cassidy Creek", "Chamberlain Hills", "Vinewood Hills", "Chumash", "Chiliad Mountain State Wilderness", "Cypress Flats", "Davis", "Del Perro Beach", "Del Perro", "La Puerta", "Grand Senora Desert", "Downtown", "Downtown Vinewood", "East Vinewood", "El Burro Heights", "El Gordo Lighthouse", "Elysian Island", "Galilee", "GWC and Golfing Society", "Grapeseed", "Great Chaparral", "Harmony", "Hawick", "Vinewood Racetrack", "Humane Labs and Research", "Bolingbroke Penitentiary", "Little Seoul", "Land Act Reservoir", "Lago Zancudo", "Land Act Dam", "Legion Square", "La Mesa", "La Puerta", "Mirror Park", "Morningwood", "Richards Majestic", "Mount Chiliad", "Mount Gordo", "Mount Josiah", "Murrieta Heights", "North Chumash", "N.O.O.S.E", "Pacific Ocean", "Paleto Cove", "Paleto Bay", "Paleto Forest", "Palomino Highlands", "Palmer-Taylor Power Station", "Pacific Bluffs", "Pillbox Hill", "Procopio Beach", "Rancho", "Richman Glen", "Richman", "Rockford Hills", "Redwood Lights Track", "San Andreas", "San Chianski Mountain Range", "Sandy Shores", "Mission Row", "Stab City", "Maze Bank Arena", "Strawberry", "Tataviam Mountains", "Terminal", "Textile City", "Tongva Hills", "Tongva Valley", "Vespucci Canals", "Vespucci", "Vinewood", "Ron Alternates Wind Farm", "West Vinewood", "Zancudo River", "Port of South Los Santos", "Davis Quartz"];



let LastLocation = "";
let LastHealth = 100;
let LastArmor = 100;
let LastHunger = 100;
let LastFaction = 0;
let LastMoney = 0;
let LastWanteds = 0;
let LastVoiceState = false;
function CheckHUDUpdate() {
	if (!HUD_BROWSER) { return; }
	let Update = false;
	let LocalEntity = alt.Player.local;
	let LocalEntityScriptId = alt.Player.local.scriptID;
	let CurrentArmor = game.getPedArmour(LocalEntityScriptId);
	let CurrentHealth = game.getEntityHealth(LocalEntityScriptId);
	let CurrentHunger = LocalEntity.getStreamSyncedMeta('PLAYER_HUNGER');
	if (CurrentHealth <= 0) {
		CurrentArmor = 0;
		CurrentHealth = 0;
		CurrentHunger = 0;
	}
	let CurrentFaction = LocalEntity.getStreamSyncedMeta('PLAYER_FACTION');
	let CurrentMoney = LocalEntity.getStreamSyncedMeta('PLAYER_MONEY');
	let CurrentWanteds = LocalEntity.getStreamSyncedMeta('PLAYER_WANTEDS');
	let CurrentVoiceState = LocalEntity.isTalking;
	let CurrentLocation = game.getNameOfZone(LocalEntity.pos.x, LocalEntity.pos.y, LocalEntity.pos.z);
	if (CurrentArmor != LastArmor) {
		Update = true;
		LastArmor = CurrentArmor;
	}
	if (CurrentHealth != LastHealth) {
		Update = true;
		LastHealth = CurrentHealth;
	}
	if (CurrentHunger != LastHunger) {
		Update = true;
		LastHunger = CurrentHunger;
	}
	if (CurrentFaction != LastFaction) {
		Update = true;
		LastFaction = CurrentFaction;
	}
	if (CurrentMoney != LastMoney) {
		Update = true;
		LastMoney = CurrentMoney;
	}
	if (Update) {
		if (CurrentHealth <= 0) { CurrentHealth = 100; }
		HUD_BROWSER.emit('HUD:UpdateStats', CurrentFaction, CurrentArmor, CurrentHealth - 100, CurrentHunger, CurrentMoney);
	}
	if (CurrentLocation != LastLocation) {
		let zoneID = zoneNamesShort.indexOf(CurrentLocation);
		let realZoneName = zoneNames[zoneID];
		HUD_BROWSER.emit('HUD:UpdateLocation', realZoneName);
	}
	if (CurrentWanteds != LastWanteds) {
		LastWanteds = CurrentWanteds;
		HUD_BROWSER.emit('HUD:UpdateWanteds', CurrentWanteds);
	}
	if (CurrentVoiceState != LastVoiceState) {
		LastVoiceState = CurrentVoiceState;
		HUD_BROWSER.emit('HUD:UpdateVoiceState', CurrentVoiceState);
	}
}
let GamemodeVersion = "1.0.0";
alt.onServer('Gameversion:Update', (version) => {
	GamemodeVersion = version;
});

alt.everyTick(() => {
	DrawText("International Venox V." + GamemodeVersion + " dev r1", [0.927, 0.98], [0.6, 0.3], 0, [225, 225, 225, 175], true, true);
	let player = alt.Player.local;
	game.displayAmmoThisFrame(false);
	if (game.isPedSprinting(player.scriptID)) {
		game.restorePlayerStamina(player.scriptID, 100);
	}
	game.setPlayerHealthRechargeMultiplier(player.scriptID, 0.0);
	DrawSafezone();
	CheckHUDUpdate();
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
});
