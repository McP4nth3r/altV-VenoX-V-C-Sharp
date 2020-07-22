
//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../../Globals/VnX-Lib';


let RathausBrowser;
let Rathaus_Button_State;

alt.onServer('showRathausWindow', (HEADER, PERSO_BTN, CAR_BTN, LKW_BTN, BIKE_BTN, PLANE_A_BTN, PLANE_B_BTN, HELICOPTER_BTN, BOAT_BTN, FISHER_BTN, WEAPON_BTN, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen) => {
    if (RathausBrowser) { return; }
    RathausBrowser = vnxCreateCEF('Rathaus', 'Reallife/environment/rathaus/main.html');
    RathausBrowser.focus();
    ShowCursor(true);

    RathausBrowser.on('Selected_Button', (buttontext) => {
        Rathaus_Button_State = "" + buttontext;
    });
    RathausBrowser.on('Buy_Button_Rathaus', () => {
        alt.emitServer('On_Clicked_Button_Rathaus', Rathaus_Button_State);
    });
    game.freezeEntityPosition(alt.Player.local.scriptID, true);
    alt.setTimeout(() => {
        RathausBrowser.emit('Rathaus:Load', HEADER, PERSO_BTN, CAR_BTN, LKW_BTN, BIKE_BTN, PLANE_A_BTN, PLANE_B_BTN, HELICOPTER_BTN, BOAT_BTN, FISHER_BTN, WEAPON_BTN, perso, fuehrer, lkw, bike, fa, fb, heli, boot, angel, waffen);
    }, 500);
});


alt.onServer('destroyRathausWindow', () => {
    if (RathausBrowser != null) {
        vnxDestroyCEF('Rathaus');
        RathausBrowser = null;
        game.freezeEntityPosition(alt.Player.local.scriptID, false);
        ShowCursor(false);
        return
    }
});
