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
		let hp = player.getStreamSyncedMeta("PLAYER_HEALTH");

		let armor = player.getStreamSyncedMeta("PLAYER_ARMOR");
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
				return [(210 - hp) * 2.35 / 2, (hp * 2.35), 0];
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


function DrawText(msg, player, posx, posy, posz, fontSize, fontType, ColorRGB, useOutline = true, useDropShadow = true, drawFaction = false, drawDistance, maxDistance_load) {
	let hex = msg.match('{.*}');
	let localPlayer = alt.Player.local;
	if (hex) {
		const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
		r = rgb[0];
		g = rgb[1];
		b = rgb[2];
		msg = msg.replace(hex[0], '');
	}
	if (ColorRGB == undefined || ColorRGB == null) ColorRGB = 255;
	let scale = 1 - (0.8 * drawDistance) / maxDistance_load;
	let newfontSize = fontSize * scale;
	const lineHeight = game.getTextScaleHeight(scale, fontType);

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
	game.setTextScale(newfontSize, newfontSize);
	game.setTextProportional(true);
	game.setTextCentre(true);
	game.setTextColour(ColorRGB[0], ColorRGB[1], ColorRGB[2], ColorRGB[3]);
	game.setTextOutline();
	game.addTextComponentSubstringPlayerName(msg);
	game.endTextCommandDisplayText(0, 0);
	let SpriteScale = [2 * lineHeight / 3, 2 * lineHeight / 3];

	//let screenPos = game.getScreenCoordFromWorldCoord(Vector.X, Vector.Y, Vector.Z + 1);
	if (drawFaction) {
		if (player.getStreamSyncedMeta("PLAYER_WANTEDS") > 0 && localPlayer.getStreamSyncedMeta("PLAYER_FACTION") > 0) {
			game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), lineHeight - 1.4 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			game.drawSprite('images', 'wanted' + player.getStreamSyncedMeta('PLAYER_WANTEDS'), lineHeight - 0.7 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0.04, 0, 255, 255, 255, 255, 200);
			if (player.isTalking) game.drawSprite('images', 'Voice_true', lineHeight - 0.1 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
		}
		else {
			//const width = 0.0005 * scale;
			if (player.isTalking) {
				game.drawSprite('images', 'Voice_true', lineHeight - 0.7 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
				game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), lineHeight - 1.4 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			}
			else {
				game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), 0, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			}
		}
	}
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
					DrawText(name, player, player.pos.x, player.pos.y, player.pos.z + 1.22, 0.7, 4, [r, g, b, 255], true, true, true, distance, maxDistance_load);
					DrawText(player.getStreamSyncedMeta("PLAYER_SOCIALSTATE"), player, player.pos.x, player.pos.y, player.pos.z + 1, 0.4, 4, [r1, g1, b1, 255], true, true, false, distance, maxDistance_load);
				}
			}
		}
	}
}
