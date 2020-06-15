//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { GetCursorStatus, ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../Globals/VnX-Lib';

let Phone;
let PhoneOpen = false;
alt.onServer('Phone:Load', () => {
    if (Phone) { return; }
    Phone = vnxCreateCEF("VenoXPhone", "Reallife/handy/main.html");
});

alt.onServer('Phone:Unload', () => {
    if (!Phone) { return; }
    vnxDestroyCEF("VenoXPhone");
    Phone = null;
});

alt.onServer('LoadPlayerList', (Phonelist) => {
    if (!Phone) { return; }
    Phone.emit('CallList:Init', Phonelist);
    alt.log(Phonelist);
});

alt.on('keyup', (key) => {
    if (key == 'O'.charCodeAt() && !GetCursorStatus()) {
        Phone.focus();
        PhoneOpen = !PhoneOpen;
        ShowCursor(!PhoneOpen);
        Phone.emit('Phone:Show', !PhoneOpen);
    }
});