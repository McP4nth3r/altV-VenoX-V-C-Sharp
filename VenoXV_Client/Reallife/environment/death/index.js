//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF } from '../../../Globals/VnX-Lib';

let HospitalWindow;
alt.onServer('DeathScreen:Show', (time) => {
	try {
		if (HospitalWindow != null) { return; }
		HospitalWindow = vnxCreateCEF("HospitalReallife", "Reallife/environment/death/main.html");
		alt.setTimeout(() => {
			HospitalWindow.emit('Timer:Init', time);
		}, 400);
		alt.setTimeout(() => {
			vnxDestroyCEF("HospitalReallife");
			alt.emitServer('Reallife:Revive');
		}, time);
	}
	catch{ }
});
