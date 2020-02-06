//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

let speedo = new alt.WebView("http://resource/VenoXV_Client/Globals/Anzeigen/tacho/speedometer.html");
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

export function RenderTacho() {
	//ToDo: Unperformant!
	/*if (player.getVariable("HIDE_SPEEDO")) {
		speedo.execute("hideSpeedo();");
		return;
	}
	else {

	}
	//ToDo: Unperformant!
	
	if (player.getVariable("PLAYER_DRIVINGSCHOOL") == true && player.vehicle) {
		let vel = player.vehicle.getSpeed() * 3.6;
		if (vel >= 125) {
			mp.events.callRemote('CancelDrivingSchool', vel);
			return;
		}
	}*/
	//ToDo : Unperformant!!
	if (alt.Player.local.vehicle) {
		if (showed === false) {
			speedo.emit("Tacho:Show");
			showed = true;
		}
		/*Get vehicle infos*/
		let vel = alt.Player.local.vehicle.speed * 3.6;
		let rpm = alt.Player.local.vehicle.rpm * 1000;
		gas = alt.Player.local.vehicle.getSyncedMeta('VEHICLE_GAS_CLIENT');
		kmS = alt.Player.local.vehicle.getSyncedMeta('VEHICLE_KMS_CLIENT');
		//alt.log(gas + " | " + kmS);
		speedo.emit('Tacho:Update', vel, rpm, gas, kmS);
	}
	else {
		if (showed) {
			speedo.emit("Tacho:Hide");
			showed = false;
		}
	}
}

alt.setInterval(function () {
	if (alt.Player.local.vehicle) { alt.emitServer("Tacho:CalculateTank", alt.Player.local.vehicle.speed); }
}, 5000);


