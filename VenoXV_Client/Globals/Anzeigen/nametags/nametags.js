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
let width = 0.03;
let height = 0.0065;
let border = 0.001;
let color = [255, 255, 255, 255];
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
	let hp = game.getEntityHealth(player.scriptID);

	let armor = game.getPedArmour(player.scriptID);
	//if (hp <= 0 || player.getStreamSyncedMeta("PLAYER_KILLED") == 1)
	if (hp <= 0) {
		return [40, 40, 40];
	}
	else {
		if (armor > 0) {
			armor = Math.abs(armor - 0.01);
			return [0 + (2.55 * armor), (255), 0 + (2.55 * armor)];
		}
		else {
			hp = Math.abs(hp - 0.01);
			return [(245 - hp) * 2.35 / 2, (hp * 2.35), 0];
		}
	}
	return;
}


function isStateFaction(player) {
	if (player.getStreamSyncedMeta("PLAYER_FACTION") == 1 || player.getStreamSyncedMeta("PLAYER_FACTION") == 6 || player.getStreamSyncedMeta("PLAYER_FACTION") == 8) {
		return true;
	}
	return false;
}

function isBadFaction(player) {
	if (player.getStreamSyncedMeta("PLAYER_FACTION") == 2 || player.getStreamSyncedMeta("PLAYER_FACTION") == 3 || player.getStreamSyncedMeta("PLAYER_FACTION") == 7
		|| player.getStreamSyncedMeta("PLAYER_FACTION") == 9 || player.getStreamSyncedMeta("PLAYER_FACTION") == 12 || player.getStreamSyncedMeta("PLAYER_FACTION") == 13) {
		return true;
	}
	return false;
}

export function DrawNametags() {
	let players = alt.Player.all;
	/*let graphics = mp.game.graphics;
	let screenRes = graphics.getScreenResolution(0, 0);
	if (mp.gui.cursor.visible == false) {
		if (mp.keys.isDown(84)) {
			mp.events.callRemote("CreateTypingEffect", true);
			typing = true;
		}
	}
	if (typing) {
		if (mp.keys.isDown(13)) {
			mp.events.callRemote("CreateTypingEffect", false);
		}
	}
	*/

	if (players.length > 1) {
		let localPlayer = alt.Player.local;

		for (var i = 0; i < players.length; i++) {
			var player = players[i];
			let playerPos = localPlayer.pos;
			let playerPos2 = player.pos;
			let distance = game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
			if (player.getStreamSyncedMeta("PLAYER_NAME") != localPlayer.getStreamSyncedMeta("PLAYER_NAME")) {
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
					if (player.getStreamSyncedMeta("PLAYER_WANTEDS") > 0 && localPlayer.getStreamSyncedMeta("PLAYER_FACTION") > 0) {
						if (!game.hasStreamedTextureDictLoaded("Commonmenu")) {
							game.requestStreamedTextureDict("Commonmenu", true);
						}

						if (game.hasStreamedTextureDictLoaded("Commonmenu")) {
							game.drawSprite("Commonmenu", "shop_new_star", screenPos[1], screenPos[2] - 0.020, 0.0625, 0.06315, 0, 255, 255, 255, 255);
							DrawText(player.getStreamSyncedMeta("PLAYER_WANTEDS").toString(), [screenPos[1] - 0.002, screenPos[2] + 0.030], [0.30, 0.30], 4, [255, 255, 255, 255], true, true);
						}
					}
					//alt.log("[DISTANCE ZUM SPIELER] : " + distance);
					//alt.log("[MAX_DISTANCE] : " + maxDistance_load);
					DrawText(name, [screenPos[1], screenPos[2] - 0.030], [0.65, 0.65], 4, [r, g, b, 255], true, true);
					DrawText(player.getStreamSyncedMeta("SocialState_NAMETAG"), [screenPos[1], screenPos[2] + 0.012], [0.45, 0.45], 4, [r1, g1, b1, 255], true, true);
				}
			}
		}
	}
}