//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../../Globals/VnX-Lib';

alt.onServer('createGasWindow', (GasPrice) => {
	vnxDestroyCEF("GasStation");
	let GasWindow = vnxCreateCEF("GasStation", "Reallife/environment/tankstellen/main.html");
	alt.setTimeout(() => {
		GasWindow.emit('Window:Load', GasPrice);
		GasWindow.focus();
		ShowCursor(true);
	}, 200);
	GasWindow.on('Fill_Car_C', () => {
		alt.emitServer('Fill_Car');
	});
	GasWindow.on('Buy_Kanister', () => {
		alt.emitServer('Buy_Kanister_Server');
	});
	GasWindow.on('Buy_Snack', () => {
		alt.emitServer('Buy_Snack_Server');
	});
	GasWindow.on('SendRequestedDatas', (Gas_Liter) => {
		alt.setTimeout(function () {
			alt.emitServer('Fill_Gas_Liter', Gas_Liter);
		}, 100);
	});
	GasWindow.on('destroyGasWindow', () => {
		GasWindow.unfocus();
		alt.emitServer('Close_Gas_Window');
		vnxDestroyCEF("GasStation");
		ShowCursor(false);
	});
});


alt.onServer('Fill_Car_Accepted', (v, ms) => {
	alt.setTimeout(function () {
		alt.emitServer("Fill_Car_Done", v);
	}, ms);
});