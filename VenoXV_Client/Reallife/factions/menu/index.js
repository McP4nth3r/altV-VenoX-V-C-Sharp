//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor, ShowCountdown } from '../../../Globals/VnX-Lib';

let FactionWindow;
//Basics : 
alt.onServer('FactionMenu:Show', (Json) => {
    if (FactionWindow) { return; }
    FactionWindow = vnxCreateCEF('Reallife-FactionWindow', 'Reallife/factions/menu/main.html');
    FactionWindow.focus();
    ShowCursor(true);
    FactionWindow.on('FactionWindow:Select', (kaufen) => {
        alt.emitServer('Rathaus:Buy', kaufen);
    });

    FactionWindow.on('FactionWindow:Close', () => {
        if (!FactionWindow) { return; }
        FactionWindow.unfocus();
        vnxDestroyCEF('FactionWindow:Select');
        FactionWindow = null;
        ShowCursor(false);
    });

});