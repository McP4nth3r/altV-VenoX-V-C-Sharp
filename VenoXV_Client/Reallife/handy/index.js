//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
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
    Phone.on('Phone:CallingTarget', (Name) => {
        alt.emitServer('VenoXPhone:CallTarget', Name);
    });
});

alt.onServer('Phone:Unload', () => {
    if (!Phone) { return; }
    vnxDestroyCEF("VenoXPhone");
    Phone = null;
});

alt.onServer('Phone:LoadPlayerList', (Phonelist) => {
    if (!Phone) { return; }
    alt.setTimeout(() => {
        Phone.emit('CallList:Init', Phonelist);
        //alt.log(Phonelist);
    }, 500);
});

alt.onServer('Phone:ChangeCallTargetAvatar', (ID, Avatar) => {
    if (!Phone) { return; }
    Phone.emit("Phone:ChangeCallTargetAvatar", ID, Avatar);
});

alt.on('keyup', (key) => {
    if (key == 'O'.charCodeAt() && !GetCursorStatus()) {
        Phone.focus();
        PhoneOpen = !PhoneOpen;
        ShowCursor(!PhoneOpen);
        Phone.emit('Phone:Show', !PhoneOpen);
    }
});