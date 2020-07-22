//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../VnX-Lib';
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
	catch{ return [40, 40, 40]; }
}


function isStateFaction(player) {
	try {
		if (player.getStreamSyncedMeta("PLAYER_FACTION") == 1 || player.getStreamSyncedMeta("PLAYER_FACTION") == 6 || player.getStreamSyncedMeta("PLAYER_FACTION") == 8) {
			return true;
		}
		return false;
	}
	catch{ return false; }
}

function isBadFaction(player) {
	try {
		if (player.getStreamSyncedMeta("PLAYER_FACTION") == 2 || player.getStreamSyncedMeta("PLAYER_FACTION") == 3 || player.getStreamSyncedMeta("PLAYER_FACTION") == 7
			|| player.getStreamSyncedMeta("PLAYER_FACTION") == 9 || player.getStreamSyncedMeta("PLAYER_FACTION") == 12 || player.getStreamSyncedMeta("PLAYER_FACTION") == 13) {
			return true;
		}
		return false;
	}
	catch{ return false; }
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
	catch{ }
}
OnStart();

function DrawNametags() {
	try {
		let players = alt.Player.all
		if (players.length > 0) {
			let localPlayer = alt.Player.local;
			for (var i = 0; i < players.length; i++) {
				var player = players[i];
				let playerPos = localPlayer.pos;
				let playerPos2 = player.pos;
				let distance = game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
				if (player != localPlayer) {
					if (player.vehicle && localPlayer.vehicle) { maxDistance_load = 60; } else { maxDistance_load = maxDistance; }
					//if(distance <= maxDistance_load && player.getStreamSyncedMeta("PLAYER_LOGGED_IN")) {
					if (distance <= maxDistance_load) {
						if (player.getStreamSyncedMeta("PLAYER_ADMIN_RANK") > 2) { name = "[VnX]" + player.getStreamSyncedMeta("PLAYER_NAME"); }
						else { name = player.getStreamSyncedMeta("PLAYER_NAME"); }
						if (isStateFaction(player) && isBadFaction(localPlayer) || isStateFaction(localPlayer) && isBadFaction(player)) { r1 = 200; g1 = 0; b1 = 0; }
						else if (player.getStreamSyncedMeta("PLAYER_FACTION") == localPlayer.getStreamSyncedMeta("PLAYER_FACTION") && player.getStreamSyncedMeta("PLAYER_FACTION") > 0) { r1 = 0; g1 = 200; b1 = 0; }
						else { r1 = 0; g1 = 105; b1 = 145; }
						if (player.getStreamSyncedMeta("PLAYER_ADMIN_ON_DUTY") == 1) { r = 0; g = 200; b = 255; }
						else { let values = returnRGB(player); r = values[0]; g = values[1]; b = values[2]; }
						let screenPos = game.getScreenCoordFromWorldCoord(playerPos2.x, playerPos2.y, playerPos2.z + 1);
						if (player.isTalking) {
							game.drawSprite('images', 'Voice_true', screenPos[1] - 0.035, screenPos[2] - 0.05, 0.0425, 0.0425, 0, 255, 255, 255, 255, 200);
						}

						if (player.getStreamSyncedMeta("PLAYER_WANTEDS") > 0 && localPlayer.getStreamSyncedMeta("PLAYER_FACTION") > 0) {
							game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), screenPos[1] - 0.025, screenPos[2] - 0.05, 0.035, 0.04, 0, 255, 255, 255, 255, 200);
							game.drawSprite('images', 'wanted' + player.getStreamSyncedMeta('PLAYER_WANTEDS'), screenPos[1] + 0.025, screenPos[2] - 0.05, 0.04, 0.04, 0, 255, 255, 255, 255, 200);
						}
						else {
							game.drawSprite('images', 'faction_' + player.getStreamSyncedMeta('PLAYER_FACTION'), screenPos[1], screenPos[2] - 0.05, 0.035, 0.04, 0, 255, 255, 255, 255, 200);
						}
						DrawText(name, [screenPos[1], screenPos[2] - 0.030], [0.65, 0.65], 4, [r, g, b, 255], true, true);
						DrawText(player.getStreamSyncedMeta("PLAYER_SOCIALSTATE"), [screenPos[1], screenPos[2] + 0.012], [0.45, 0.45], 4, [r1, g1, b1, 255], true, true);
					}
				}
			}
		}
	}
	catch{ }
}

