//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import { vnxCreateCEF, vnxDestroyCEF } from '../../../Globals/VnX-Lib';

let HospitalWindow;
alt.onServer('DeathScreen:Show', (time) => {
	try {
		if (HospitalWindow != null) { return; }
		HospitalWindow = vnxCreateCEF("HospitalReallife", "Reallife/environment/death/main.html", "Reallife");
		alt.setTimeout(() => {
			HospitalWindow.emit('Timer:Init', time);
		}, 500);
		alt.setTimeout(() => {
			HospitalWindow = null;
			vnxDestroyCEF("HospitalReallife");
			alt.emitServer('Reallife:Revive');
		}, time);
	}
	catch{ }
});
