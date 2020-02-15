//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let preloadbrowser = null;
import * as alt from 'alt-client';
import * as game from "natives";
import * as dxClass from '../Globals/VnX-Lib/dxClass';
import { ShowCursor } from '../Globals/VnX-Lib';


function test() {
	dxClass.vnxDestroyWindow("TestWindow");
}



/*
dxClass.vnxDrawWindow("TestWindow", "Irgend n Window zum Testen lel", "Willkommen Solid", 0.5, 0.5, 0.28, 0.25, true, test);

dxClass.vnxDrawButton("Smart_Kaufen", "Irgend ein Test Button WTF", "Panto Mieten [180$]", -0.05, 0.09, 0.09, 0.04, "TestWindow", test);

dxClass.vnxDrawButton("Roller_Kaufen", "Dies ist eine Info für dich ;)", "Roller Mieten [75$]", 0.05, 0.09, 0.09, 0.04, "TestWindow", test);

dxClass.vnxDrawText("RollerText", "Roller Vermietungs Text lol", "Hello Alt:V,\nThis is a Test lmfao ^_^", 0, -0.03, [0.7, 0.55], 1, [255, 255, 255, 255], "TestWindow", test);*/

//dxClass.vnxDrawWindow("FynnZeigt", "Info für FynnScheisst", "Fynnzeigts erstes Window", 0, 0, 0.3, 0.2, penis);




alt.onServer('preload_gm_list', () => {
	if (preloadbrowser != null) {
		preloadbrowser.destroy();
		preloadbrowser = null;
	}
	alt.hash
	//ToDo : Hide/ShowChat - mp.gui.chat.activate(false);
	//ToDo : Hide/ShowChat - mp.gui.chat.show(false);
	//ToDo : Hide/ShowCursor - mp.gui.cursor.show(true, true);
	//ToDo :Freeze/Unfreeze Player - mp.players.local.freezePosition(true);
	preloadbrowser = new alt.WebView("http://resource/VenoXV_Client/preload/main.html");
	preloadbrowser.focus();
	ShowCursor(true);
	preloadbrowser.on('load_selected_gm', (v) => {
		if (preloadbrowser != null) {
			preloadbrowser.destroy();
			preloadbrowser = null;
		}
		if (v == 0) {
			//eval(`import "./Reallife/VenoXV/index.js"`);
		}
		else if (v == 1) {
			////eval(`import "./Zombie/VenoXV/index.js"`);	
		}
		else if (v == 2) {
		}
		alt.emitServer("Load_selected_gm_server", v);
		game.setEntityAlpha(alt.Player.local.scriptID, 255);
		game.freezeEntityPosition(alt.Player.local.scriptID, false);
		game.displayRadar(true);
		game.displayHud(true);
		ShowCursor(false);

	});
});


alt.onServer('LoadReallifeGamemodeRemote', () => {
	//eval(`import "./Reallife/VenoXV/index.js"`);
});

alt.onServer('LoadPreloadUserInfo', (z, r, t) => {
	//preloadbrowser.execute(`document.getElementById('rec_0_userinfo').innerHTML="` + z + `";document.getElementById('rec_1_userinfo').innerHTML="` + r + `";document.getElementById('rec_2_userinfo').innerHTML="` + t + `";`);
});


alt.onServer('Load_Zombie_GM', () => {
	//ToDo :Freeze/Unfreeze Player - mp.players.local.freezePosition(false);
	//ToDo : Hide/ShowCursor - mp.gui.cursor.show(false, false);
	//eval(`import "./Zombie/VenoXV/index.js"`);	
});