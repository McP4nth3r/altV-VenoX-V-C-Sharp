//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
let maxDistance = 20;
let maxDistance_load = 20;
let name = "";
let r = 0;
let g = 0;
let b = 0;
let r1 = 0;
let g1 = 0;
let b1 = 0;
let typing = false;
//mp.nametags.enabled = false;

function returnRGB(player) {
	try {
		let hp = game.getEntityHealth(player.scriptID);

		let armor = game.getPedArmour(player.scriptID);
		//if (hp <= 0 || player.getStreamSyncedMeta("PLAYER_KILLED") == 1)
		if (hp <= 0) {
			return [40, 40, 40];
		}
		else {
			if (armor > 0) {
				armor = Math.abs(armor - 0.01);
				return [(2.55 * armor), (255), (2.55 * armor)];
			}
			else {
				hp = Math.abs(hp - 0.01);
				return [(200 - hp) * 2.35 / 2, (hp * 2.35), 0];
			}
		}
	}
	catch { return [40, 40, 40]; }
}


function isStateFaction(player) {
	try {
		if (player.getStreamSyncedMeta("PLAYER_FACTION") == 1 || player.getStreamSyncedMeta("PLAYER_FACTION") == 6 || player.getStreamSyncedMeta("PLAYER_FACTION") == 8) {
			return true;
		}
		return false;
	}
	catch { return false; }
}

function isBadFaction(player) {
	try {
		if (player.getStreamSyncedMeta("PLAYER_FACTION") == 2 || player.getStreamSyncedMeta("PLAYER_FACTION") == 3 || player.getStreamSyncedMeta("PLAYER_FACTION") == 7
			|| player.getStreamSyncedMeta("PLAYER_FACTION") == 9 || player.getStreamSyncedMeta("PLAYER_FACTION") == 12 || player.getStreamSyncedMeta("PLAYER_FACTION") == 13) {
			return true;
		}
		return false;
	}
	catch { return false; }
}

function OnStart() {
	try {
		if (!game.hasStreamedTextureDictLoaded("images")) {
			game.requestStreamedTextureDict('images');
			alt.log('Requested Packages!');
		}
		alt.setTimeout(() => {
			alt.everyTick(() => {
				DrawNametags();
			});
		}, 5000);
	}
	catch { }
}
OnStart();


function DrawText(msg, player, posx, posy, posz, scale, fontType, ColorRGB, useOutline = true, useDropShadow = true, drawFaction = false) {
	let hex = msg.match('{.*}');
	if (hex) {
		const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
		r = rgb[0];
		g = rgb[1];
		b = rgb[2];
		msg = msg.replace(hex[0], '');
	}
	if (ColorRGB == undefined || ColorRGB == null) ColorRGB = 255;
	const lineHeight = game.getTextScaleHeight(scale[0], fontType);
	const entity = player.vehicle ? player.vehicle.scriptID : player.scriptID;
	const vector = game.getEntityVelocity(entity);
	const frameTime = game.getFrameTime();
	let Vector = {
		X: posx + vector.x * frameTime,
		Y: posy + vector.y * frameTime,
		Z: posz + vector.z * frameTime
	}
	// Names
	game.setDrawOrigin(Vector.X, Vector.Y, Vector.Z, 0);
	game.beginTextCommandDisplayText('STRING');
	game.setTextFont(fontType);
	game.setTextScale(scale[0], scale[1]);
	game.setTextProportional(true);
	game.setTextCentre(true);
	game.setTextColour(ColorRGB[0], ColorRGB[1], ColorRGB[2], ColorRGB[3]);
	game.setTextOutline();
	game.addTextComponentSubstringPlayerName(msg);
	game.endTextCommandDisplayText(0, 0);
	//let screenPos = game.getScreenCoordFromWorldCoord(Vector.X, Vector.Y, Vector.Z + 1);
	if (player.isTalking) game.drawSprite('images', 'Voice_true', -0.035, (lineHeight + 0.25 * lineHeight) - 0.05, 0.0425, 0.0425, 0, 255, 255, 255, 255, 200);

	/*if (player.getStreamSyncedMeta("PLAYER_WANTEDS") > 0 && localPlayer.getStreamSyncedMeta("PLAYER_FACTION") > 0) {
		game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), -0.025, (lineHeight + 0.25 * lineHeight) - 0.05, 0.035, 0.035, 0, 255, 255, 255, 255, 200);
		game.drawSprite('images', 'wanted' + player.getStreamSyncedMeta('PLAYER_WANTEDS'), 0.025, (lineHeight + 0.25 * lineHeight) - 0.05, 0.04, 0.04, 0, 255, 255, 255, 255, 200);
	}
	else {*/
	if (drawFaction) game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), 0, (lineHeight + 0.25 * lineHeight) - 0.08, 0.035, 0.035, 0, 255, 255, 255, 255, 200);
	//}

	if (useOutline) game.setTextOutline();
	if (useDropShadow) game.setTextDropShadow();
	game.clearDrawOrigin();
}

function DrawNametags() {
	let players = alt.Player.all;
	if (players.length > 0) {
		let localPlayer = alt.Player.local;
		for (let i = 0; i < players.length; i++) {
			let player = players[i];
			let playerPos = localPlayer.pos;
			let playerPos2 = player.pos;
			if (!game.hasEntityClearLosToEntity(localPlayer.scriptID, player.scriptID, 17)) continue;
			let distance = game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
			if (player != localPlayer) {
				if (player.vehicle && localPlayer.vehicle) maxDistance_load = 60; else maxDistance_load = maxDistance;
				//if (distance <= maxDistance_load && player.getStreamSyncedMeta("PLAYER_LOGGED_IN")) {
				if (distance <= maxDistance_load) {
					if (player.getStreamSyncedMeta("PLAYER_ADMIN_RANK") > 2) { name = "[VnX]" + player.getStreamSyncedMeta("PLAYER_NAME"); }
					else { name = player.getStreamSyncedMeta("PLAYER_NAME"); }
					if (isStateFaction(player) && isBadFaction(localPlayer) || isStateFaction(localPlayer) && isBadFaction(player)) { r1 = 200; g1 = 0; b1 = 0; }
					else if (player.getStreamSyncedMeta("PLAYER_FACTION") == localPlayer.getStreamSyncedMeta("PLAYER_FACTION") && player.getStreamSyncedMeta("PLAYER_FACTION") > 0) { r1 = 0; g1 = 200; b1 = 0; }
					else { r1 = 0; g1 = 105; b1 = 145; }
					if (player.getStreamSyncedMeta("PLAYER_ADMIN_ON_DUTY") == 1) { r = 0; g = 200; b = 255; }
					else { let values = returnRGB(player); r = values[0]; g = values[1]; b = values[2]; }
					DrawText(name, player, player.pos.x, player.pos.y, player.pos.z + 1.2, [0.65, 0.65], 4, [r, g, b, 255], true, true, true);
					DrawText(player.getStreamSyncedMeta("PLAYER_SOCIALSTATE"), player, player.pos.x, player.pos.y, player.pos.z + 1, [0.45, 0.45], 4, [r1, g1, b1, 255], true, true);
				}
			}
		}
	}
}
