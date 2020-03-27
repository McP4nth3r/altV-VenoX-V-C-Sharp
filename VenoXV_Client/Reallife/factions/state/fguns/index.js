//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from '../../../../Globals/VnX-Lib';

let StateFguns_Browser = null;
alt.onServer('showStateWeaponWindow', (s, t, p, p2, s2, p3, k, r, s3, i, st) => {
	game.freezeEntityPosition(alt.Player.local.scriptID, true);
	alt.log("Called");
	StateFguns_Browser = new alt.WebView("http://resource/VenoXV_Client/Reallife/factions/state/fguns/main.html");
	StateFguns_Browser.focus();
	ShowCursor(true);
	StateFguns_Browser.emit("OnStateWeaponLoad", s, t, p, p2, s2, p3, k, r, s3, i, st);
	alt.log()

	StateFguns_Browser.on('destroyStateWeaponWindow', () => {
		game.freezeEntityPosition(alt.Player.local.scriptID, false);
		ShowCursor(false);
		if (StateFguns_Browser != null) {
			StateFguns_Browser.destroy();
			StateFguns_Browser = null;
			return
		}
	});


	StateFguns_Browser.on('triggerStateWeaponWindowBtn', (btnstring) => {
		alt.emitServer('triggerStateWeaponWindowBtn_S', btnstring);
	});
});
