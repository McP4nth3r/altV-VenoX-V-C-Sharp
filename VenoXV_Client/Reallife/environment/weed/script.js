//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Vincent & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from '../../../Globals/VnX-Lib';


let weedshop_browser = null;


alt.onServer('showWeedShopWindow', (e) => {
    weedshop_browser = new alt.WebView("http://resource/VenoXV_Client/Reallife/environment/weed/main.html");
    weedshop_browser.focus();
	ShowCursor(true);

	weedshop_browser.on('ButtonPressed', (value) => {
        alt.log('triggered value : ' + value);
		alt.emitServer('WeedShop_Server_Event', value);
		if (weedshop_browser != null) {
            weedshop_browser.destroy();
			weedshop_browser = null;
            ShowCursor(false);
            return
		}
    });
    
	weedshop_browser.on('destroyWeedShopWindow', () => {
        if (weedshop_browser != null) {
            weedshop_browser.destroy();
			weedshop_browser = null;
            ShowCursor(false);
            return
		}
	});
});

/*
░░░░░░░█▐▓▓░████▄▄▄█▀▄▓▓▓▌█ very cool
░░░░░▄█▌▀▄▓▓▄▄▄▄▀▀▀▄▓▓▓▓▓▌█
░░░▄█▀▀▄▓█▓▓▓▓▓▓▓▓▓▓▓▓▀░▓▌█
░░█▀▄▓▓▓███▓▓▓███▓▓▓▄░░▄▓▐█▌ such awsome
░█▌▓▓▓▀▀▓▓▓▓███▓▓▓▓▓▓▓▄▀▓▓▐█
▐█▐██▐░▄▓▓▓▓▓▀▄░▀▓▓▓▓▓▓▓▓▓▌█▌
█▌███▓▓▓▓▓▓▓▓▐░░▄▓▓███▓▓▓▄▀▐█ much amaze
█▐█▓▀░░▀▓▓▓▓▓▓▓▓▓██████▓▓▓▓▐█
▌▓▄▌▀░▀░▐▀█▄▓▓██████████▓▓▓▌█▌
▌▓▓▓▄▄▀▀▓▓▓▀▓▓▓▓▓▓▓▓█▓█▓█▓▓▌█▌
█▐▓▓▓▓▓▓▄▄▄▓▓▓▓▓▓█▓█▓█▓█▓▓▓▐█ wow
*/