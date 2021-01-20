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
		let hp = NametagsCache[player.scriptID].Health;

		let armor = NametagsCache[player.scriptID].Armor;
		//if (hp <= 0 || player.getStreamSyncedMeta("PLAYER_KILLED") == 1)
		if (hp <= 0) return [40, 40, 40];

		else {
			if (armor > 0) {
				armor = Math.abs(armor - 0.01);
				return [(2.55 * armor), (255), (2.55 * armor)];
			}
			else {
				hp = Math.abs(hp - 0.01);
				return [(200 - hp) * 2.55 / 2, (hp * 2.55), 0];
			}
		}
	}
	catch { return [40, 40, 40]; }
}


function isStateFaction(player) {
	if (NametagsCache[player.scriptID].Faction == 1 || NametagsCache[player.scriptID].Faction == 6 || NametagsCache[player.scriptID].Faction == 8) return true;
	return false;
}

function isBadFaction(player) {
	if (NametagsCache[player.scriptID].Faction == 2 || NametagsCache[player.scriptID].Faction == 3 || NametagsCache[player.scriptID].Faction == 7
		|| NametagsCache[player.scriptID].Faction == 9 || NametagsCache[player.scriptID].Faction == 12 || NametagsCache[player.scriptID].Faction == 13) return true;

	return false;
}

function OnStart() {
	if (!game.hasStreamedTextureDictLoaded("images")) game.requestStreamedTextureDict('images');

	alt.setTimeout(() => {
		alt.everyTick(() => {
			DrawRoleplayNametags();
		});
	}, 5000);
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

		if (NametagsCache[player.scriptID].Wanteds > 0 && NametagsCache[localPlayer.scriptID].Faction > 0) {
			game.drawSprite('images', 'faction_' + NametagsCache[player.scriptID].Faction, lineHeight - 1.4 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			game.drawSprite('images', 'wanted' + NametagsCache[player.scriptID].Wanteds, lineHeight - 0.7 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0.04, 0, 255, 255, 255, 255, 200);
			if (player.isTalking) game.drawSprite('images', 'Voice_true', lineHeight - 0.1 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
		}
		else {
			//const width = 0.0005 * scale;
			if (player.isTalking) {
				game.drawSprite('images', 'Voice_true', lineHeight - 0.7 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
				game.drawSprite('images', 'faction_' + NametagsCache[player.scriptID].Faction, lineHeight - 1.4 * lineHeight, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			}
			else {
				game.drawSprite('images', 'faction_' + NametagsCache[player.scriptID].Faction, 0, lineHeight - 1.3 * lineHeight, SpriteScale[0], SpriteScale[1], 0, 255, 255, 255, 255, 200);
			}
		}
	}
	if (useOutline) game.setTextOutline();
	if (useDropShadow) game.setTextDropShadow();
	game.clearDrawOrigin();
}

let NametagsCache = {};

function DrawGlobalNametags() {
	let players = alt.Player.all;
	if (players.length > 0) {
		let localPlayer = alt.Player.local;
		for (let i = 0; i < players.length; i++) {
			let player = players[i];
			if (player.scriptID == 0) continue;
			//if (player == localPlayer) continue;
			if (!NametagsCache[player.scriptID]) {
				NametagsCache[player.scriptID] = {
					Username: player.getStreamSyncedMeta("PLAYER_NAME"),
					AdminRank: player.getStreamSyncedMeta("PLAYER_ADMIN_RANK"),
					Faction: player.getStreamSyncedMeta("PLAYER_FACTION"),
					ADuty: player.getStreamSyncedMeta("PLAYER_ADMIN_ON_DUTY"),
					SocialState: player.getStreamSyncedMeta("PLAYER_SOCIALSTATE"),
					Wanteds: player.getStreamSyncedMeta("PLAYER_WANTEDS"),
					Health: player.getStreamSyncedMeta("PLAYER_HEALTH"),
					Armor: player.getStreamSyncedMeta("PLAYER_ARMOR")
				}
			}
			let playerPos = localPlayer.pos;
			let playerPos2 = player.pos;
			if (!game.hasEntityClearLosToEntity(localPlayer.scriptID, player.scriptID, 17)) continue;
			let distance = game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
			if (player.vehicle && localPlayer.vehicle) maxDistance_load = 60; else maxDistance_load = maxDistance;
			if (distance <= maxDistance_load) {
				if (NametagsCache[player.scriptID].AdminRank > 2)
					name = "[VnX]" + NametagsCache[player.scriptID].Username;
				else
					name = NametagsCache[player.scriptID].Username;

				if (isStateFaction(player) && isBadFaction(localPlayer) || isStateFaction(localPlayer) && isBadFaction(player)) {
					r1 = 200; g1 = 0; b1 = 0;
				}
				else if (NametagsCache[player.scriptID].Faction == NametagsCache[localPlayer.scriptID].Faction && NametagsCache[player.scriptID].Faction > 0) {
					r1 = 0; g1 = 200; b1 = 0;
				}
				else { r1 = 0; g1 = 105; b1 = 145; }
				if (NametagsCache[player.scriptID].ADuty == 1) {
					r = 0; g = 200; b = 255;
				}
				else {
					let values = returnRGB(player);
					r = values[0]; g = values[1]; b = values[2];
				}
				DrawText(name, player, player.pos.x, player.pos.y, player.pos.z + 1.22, 0.7, 4, [r, g, b, 255], true, true, true, distance, maxDistance_load);
				DrawText(NametagsCache[player.scriptID].SocialState, player, player.pos.x, player.pos.y, player.pos.z + 1, 0.4, 4, [r1, g1, b1, 255], true, true, false, distance, maxDistance_load);
			}
		}
	}
}
function DrawRoleplayNametags() {
	let players = alt.Player.all;
	if (players.length > 0) {
		let localPlayer = alt.Player.local;
		for (let i = 0; i < players.length; i++) {
			let player = players[i];
			if (player.scriptID == 0) continue;
			if (player == localPlayer) continue;
			if (!NametagsCache[player.scriptID]) {
				NametagsCache[player.scriptID] = {
					Username: player.getStreamSyncedMeta("PLAYER_NAME"),
					AdminRank: player.getStreamSyncedMeta("PLAYER_ADMIN_RANK"),
					Faction: player.getStreamSyncedMeta("PLAYER_FACTION"),
					ADuty: player.getStreamSyncedMeta("PLAYER_ADMIN_ON_DUTY"),
					SocialState: player.getStreamSyncedMeta("PLAYER_SOCIALSTATE"),
					Wanteds: player.getStreamSyncedMeta("PLAYER_WANTEDS"),
					Health: player.getStreamSyncedMeta("PLAYER_HEALTH"),
					Armor: player.getStreamSyncedMeta("PLAYER_ARMOR")
				}
			}
			let playerPos = localPlayer.pos;
			let playerPos2 = player.pos;
			if (!game.hasEntityClearLosToEntity(localPlayer.scriptID, player.scriptID, 17)) continue;
			let distance = game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
			if (player.vehicle && localPlayer.vehicle) maxDistance_load = 60; else maxDistance_load = maxDistance;
			if (distance <= maxDistance_load) {
				if (NametagsCache[player.scriptID].AdminRank > 2)
					name = "[VnX]" + NametagsCache[player.scriptID].Username;
				else
					name = NametagsCache[player.scriptID].Username;

				if (isStateFaction(player) && isBadFaction(localPlayer) || isStateFaction(localPlayer) && isBadFaction(player)) {
					r1 = 200; g1 = 0; b1 = 0;
				}
				else if (NametagsCache[player.scriptID].Faction == NametagsCache[localPlayer.scriptID].Faction && NametagsCache[player.scriptID].Faction > 0) {
					r1 = 0; g1 = 200; b1 = 0;
				}
				else { r1 = 0; g1 = 105; b1 = 145; }
				if (NametagsCache[player.scriptID].ADuty == 1) {
					r = 0; g = 200; b = 255;
				}
				else {
					let values = returnRGB(player);
					r = values[0]; g = values[1]; b = values[2];
				}
				DrawText(NametagsCache[player.scriptID].Username, player, player.pos.x, player.pos.y, player.pos.z + 1.22, 0.45, 4, [225, 225, 225, 255], true, true, false, distance, maxDistance_load);
			}
		}
	}
}


alt.on('streamSyncedMetaChange', (Entity, key, value, oldValue) => {
	if (Entity.scriptID == 0) return;
	if (!NametagsCache[Entity.scriptID]) {
		NametagsCache[Entity.scriptID] = {
			Username: Entity.getStreamSyncedMeta("PLAYER_NAME"),
			AdminRank: Entity.getStreamSyncedMeta("PLAYER_ADMIN_RANK"),
			Faction: Entity.getStreamSyncedMeta("PLAYER_FACTION"),
			ADuty: Entity.getStreamSyncedMeta("PLAYER_ADMIN_ON_DUTY"),
			SocialState: Entity.getStreamSyncedMeta("PLAYER_SOCIALSTATE"),
			Wanteds: Entity.getStreamSyncedMeta("PLAYER_WANTEDS"),
			Health: Entity.getStreamSyncedMeta("PLAYER_HEALTH"),
			Armor: Entity.getStreamSyncedMeta("PLAYER_ARMOR")
		}
		return;
	}
	switch (key) {
		case 'PLAYER_NAME':
			NametagsCache[Entity.scriptID].Username = value;
			return;
		case 'PLAYER_ADMIN_RANK':
			NametagsCache[Entity.scriptID].AdminRank = value;
			return;
		case 'PLAYER_FACTION':
			NametagsCache[Entity.scriptID].Faction = value;
			return;
		case 'PLAYER_ADMIN_ON_DUTY':
			NametagsCache[Entity.scriptID].ADuty = value;
			return;
		case 'PLAYER_SOCIALSTATE':
			NametagsCache[Entity.scriptID].SocialState = value;
			return;
		case 'PLAYER_WANTEDS':
			NametagsCache[Entity.scriptID].Wanteds = value;
			return;
		case 'PLAYER_HEALTH':
			NametagsCache[Entity.scriptID].Health = value;
			return;
		case 'PLAYER_ARMOR':
			NametagsCache[Entity.scriptID].Armor = value;
			return;
	}
});