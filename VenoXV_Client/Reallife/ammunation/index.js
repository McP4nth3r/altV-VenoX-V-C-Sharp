//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import { vnxCreateCEF, vnxDestroyCEF, CreatePed, ShowCursor } from '../../Globals/VnX-Lib';
CreatePed("s_m_y_ammucity_01", new alt.Vector3(21.88107, -1105.19, 29.79704), 160);

alt.onServer('Ammunation:Show', () => {
	try {
		let cef = vnxCreateCEF("Ammunation", "Reallife/ammunation/main.html");
		ShowCursor(true);
		cef.focus();
		cef.on('Ammunation:Hide', () => {
			cef.unfocus();
			vnxDestroyCEF("Ammunation");
		});
		cef.on('Ammunation:BuyWeapon', (item) => {
			alt.emitServer('Ammunation:BuyWeapon', item);
		});
		cef.on('Ammunation:BuyAmmo', (item) => {
			alt.emitServer('Ammunation:BuyAmmo', item);
		});
	}
	catch{ }
});
