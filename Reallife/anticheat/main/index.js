//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";


let player = alt.Player.local;
let position_last = new alt.Vector3(0, 0, 0);
let position_now = new alt.Vector3(0, 0, 0);
let FreezedTimer = false;
let FreezedHealthTimer = false;
let positionLoaded = false;
let TPTimer = null;
let lasthealth = 100;

function CreateLastPosition() {
	if (player != null) {
		alt.setTimeout(function () {
			if (player.vehicle) {
				position_last = new alt.Vector3(player.vehicle.pos.x, player.vehicle.pos.y, player.vehicle.pos.z);
				positionLoaded = true
			}
			else {
				position_last = new alt.Vector3(player.pos.x, player.pos.y, player.pos.z);
				positionLoaded = true;
			}
			lasthealth = game.getEntityHealth(player.scriptID);
		}, 500);
		return;
	}
	else {
		positionLoaded = false;
	}
}

let Anticheat_Info_Got = undefined;

function Anti_cheat_teleport() {
	CreateLastPosition();
	if (game.getEntityHealth(player.scriptID) > lasthealth) {
		if (Anticheat_Info_Got == undefined) {
			if (FreezedHealthTimer != true) {
				alt.emitServer('Anticheat_Server_Health');
				Anticheat_Info_Got = true;
			}
		}
		return;
	}
	if (FreezedTimer != true) {
		if (positionLoaded != false) {
			//mp.gui.chat.push("!{0,200,255}[AntiCheat] : !{255,255,255}"+positionLoaded)
			//mp.gui.chat.push("!{0,200,255}[AntiCheat] : !{255,255,255}"+FreezedTimer)
			if (player.vehicle) {
				position_vehicle = new alt.Vector3(player.vehicle.pos.x, player.vehicle.pos.y, player.vehicle.pos.z);
				if (game.getDistanceBetweenCoords(position_vehicle.x, position_vehicle.y, position_vehicle.z, position_last.x, position_last.y, position_last.z, false) > 50) {
					if (Anticheat_Info_Got == undefined) {
						alt.emitServer('Anticheat_Server_Teleport');
						Anticheat_Info_Got = true;
					}
				}
				return;
			}
			else {
				position_now = new alt.Vector3(player.pos.x, player.pos.y, player.pos.z);
				if (game.getDistanceBetweenCoords(position_now.x, position_now.y, position_now.z, position_last.x, position_last.y, position_last.z, false) > 20) {
					if (position_now.z < 150) {
						var distanz = game.getDistanceBetweenCoords(position_now.x, position_now.y, position_now.z, position_last.x, position_last.y, position_last.z, false);
						if (Anticheat_Info_Got == undefined) {
							alt.emitServer('Anticheat_Server_Speed', distanz, position_now + "", position_last + "");
							Anticheat_Info_Got = true;
						}
						return;
					}
				}
			}
		}
	}
};


function VnX_SET_ENTITY_NO_COLLISION(e, e2, v) {
	return game.setEntityNoCollisionEntity(e.scriptID, e2.scriptID, v);
}
function VnX_SET_ENTITY_NO_PAINSOUND(e, v) {
	return game.disablePedPainAudio(e.scriptID, v);
}

//ToDo : Render events als Funktion deklarieren / Eine Export funktion erstellen!
//Export Function RenderAnticheat(){code};


mp.events.add('FreezeTPTimer', (v) => {
	FreezedTimer = true;
	if (v == 0) { return; }
	alt.setTimeout(function () {
		FreezedTimer = false;
	}, v);
	game.restorePlayerStamina(player.scriptID, 100);
});

mp.events.add('FreezeHealthTimer', (v) => {
	FreezedHealthTimer = true;
	if (v == 0) { return; }
	alt.setTimeout(function () {
		FreezedHealthTimer = false;
	}, v);
	game.restorePlayerStamina(player.scriptID, 100);
});

mp.events.add('StartTPTimer', () => {
	TPTimer = alt.setInterval(function () {
		Anti_cheat_teleport()
	}, 1000);
	game.restorePlayerStamina(player.scriptID, 100);
	//mp.gui.chat.push("!{0,200,255}[AntiCheat] : !{255,255,255} loaded");
});


mp.events.add('StopTPTimer', () => {
	if (TPTimer != null) {
		alt.clearInterval(TPTimer);
	}
	game.restorePlayerStamina(player.scriptID, 100);
});