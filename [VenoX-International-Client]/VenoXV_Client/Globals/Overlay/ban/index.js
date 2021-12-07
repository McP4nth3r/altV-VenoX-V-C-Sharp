//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF, vnxDestroyAllCEF } from '../../VnX-Lib';

let BanWindow;
alt.onServer('BanWindow:Create', (Name, BanDate, Reason) => {
    if (BanWindow) return;
    vnxDestroyAllCEF();
    BanWindow = vnxCreateCEF('BanWindow', 'Globals/Anzeigen/ban/main.html');
    alt.setTimeout(() => {
        BanWindow.emit('BanWindow:Init', Name, BanDate, Reason);
    }, 300);
});