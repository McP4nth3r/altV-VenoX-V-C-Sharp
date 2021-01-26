//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
////By Solid_Snake, 7EN7E & VnX RL Crew//
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import {
	vnxCreateCEF,
	vnxDestroyCEF
} from '../../VnX-Lib';

// variables

let speedo;
let speedoId;
let speedotimer;
let kmS = 0;
let gas = 0;
alt.onServer('Speedometer:Create', Id => {
	if (speedoId == Id && speedo) return;
	if (speedo) vnxDestroyCEF("Speedometer");
	speedo = vnxCreateCEF("Speedometer", "Globals/Overlay/speedometer/" + Id + "/main.html");
});

alt.onServer('Speedometer:Visible', state => {
	if (!speedo) return;
	speedo.emit('Speedometer:Visible', state);
	if (state) {
		speedotimer = alt.setInterval(function () {
			if (alt.Player.local.vehicle)
				alt.emitServer("Tacho:CalculateFuel", alt.Player.local.vehicle.speed);
		}, 5000);
	} else {
		alt.clearInterval(speedotimer);
		speedotimer = null;
	}
});

alt.setInterval(() => {
	if (!speedo || !alt.Player.local.vehicle) return;
	let vel = (game.getEntitySpeed(alt.Player.local.vehicle.scriptID) * 3.6);
	let rpm = alt.Player.local.vehicle.rpm * 1000;
	speedo.emit('Speedo:Update', vel, rpm, gas, kmS);
}, 75);



alt.on('streamSyncedMetaChange', (entity, key, value, oldvalue) => {
	if (entity && alt.Player.local.vehicle == entity) {
		if (key == "VEHICLE_GAS") gas = value;
		else if (key == "VEHICLE_KMS") kmS = value;
	}
});