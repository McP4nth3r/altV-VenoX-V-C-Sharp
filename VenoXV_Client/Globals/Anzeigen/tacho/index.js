//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF } from '../../VnX-Lib';

let speedo = vnxCreateCEF("Tacho", "Globals/Anzeigen/tacho/speedometer.html");
let showed = false;
let kmS = 0;
let gas = 0;

alt.onServer('Remote_Speedo_Hide', (state) => {
	if (state == true) {
		speedo.emit("Tacho:Show");

	}
	else {
		speedo.emit("Tacho:Hide");
	}
});

alt.setInterval(() => {
	//ToDo : Unperformant!!
	if (alt.Player.local.vehicle) {
		if (showed === false) {
			speedo.emit("Tacho:Show");
			showed = true;
		}
		/*Get vehicle infos*/
		let vel = alt.Player.local.vehicle.speed * 3.6;
		let rpm = alt.Player.local.vehicle.rpm * 1000;
		gas = alt.Player.local.vehicle.getStreamSyncedMeta('VEHICLE_GAS');
		kmS = alt.Player.local.vehicle.getStreamSyncedMeta('VEHICLE_KMS');
		//alt.log(gas + " | " + kmS);
		speedo.emit('Tacho:Update', vel, rpm, gas, kmS);
	}
	else {
		if (showed) {
			speedo.emit("Tacho:Hide");
			showed = false;
		}
	}
}, 100);

alt.setInterval(function () {
	if (alt.Player.local.vehicle) { alt.emitServer("Tacho:CalculateTank", alt.Player.local.vehicle.speed); }
}, 5000);


