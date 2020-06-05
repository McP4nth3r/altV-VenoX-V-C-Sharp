//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";

let HospitalWindow;
alt.onServer('DeathScreen:Show', (time) => {
	if (HospitalWindow != null) { return; }
	HospitalWindow = new alt.WebView("http://resource/VenoXV_Client/Reallife/environment/death/main.html");
	HospitalWindow.emit('Timer:Init', time);
	alt.setTimeout(() => {
		if (HospitalWindow != null) {
			HospitalWindow.destroy();
			HospitalWindow = null;
			alt.emitServer('Reallife:Revive');
		}
	}, time);
});
