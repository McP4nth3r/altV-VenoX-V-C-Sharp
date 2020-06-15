//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../../Globals/VnX-Lib';

let StateFguns_Browser = null;
alt.onServer('showStateWeaponWindow', (s, t, p, p2, s2, p3, k, r, s3, i, st) => {
	vnxDestroyCEF("Staats-Fguns");
	game.freezeEntityPosition(alt.Player.local.scriptID, true);
	StateFguns_Browser = vnxCreateCEF("Staats-Fguns", "Reallife/factions/state/fguns/main.html");
	alt.setTimeout(() => {
		StateFguns_Browser.focus();
		ShowCursor(true);
		StateFguns_Browser.emit("OnStateWeaponLoad", s, t, p, p2, s2, p3, k, r, s3, i, st);
	}, 200);

	StateFguns_Browser.on('destroyStateWeaponWindow', () => {
		game.freezeEntityPosition(alt.Player.local.scriptID, false);
		ShowCursor(false);
		vnxDestroyCEF("Staats-Fguns");
	});

	StateFguns_Browser.on('triggerStateWeaponWindowBtn', (btnstring) => {
		alt.emitServer('triggerStateWeaponWindowBtn_S', btnstring);
	});
});
