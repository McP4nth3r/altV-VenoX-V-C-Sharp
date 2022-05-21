//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Vincent & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../Globals/VnX-Lib';


let weedshop_browser = null;


alt.onServer('showWeedShopWindow', () => {
    try {
        weedshop_browser = vnxCreateCEF("WeedShop", "Reallife/environment/weed/main.html", "Reallife");
        weedshop_browser.focus();
        ShowCursor(true);

        weedshop_browser.on('ButtonPressed', (value) => {
            alt.emitServer('WeedShop_Server_Event', value);
            if (weedshop_browser != null) {
                vnxDestroyCEF("WeedShop");
                weedshop_browser = null;
                ShowCursor(false);
                return
            }
        });

        weedshop_browser.on('destroyWeedShopWindow', () => {
            if (weedshop_browser != null) {
                vnxDestroyCEF("WeedShop");
                weedshop_browser = null;
                ShowCursor(false);
                return
            }
        });
    }
    catch{ }
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