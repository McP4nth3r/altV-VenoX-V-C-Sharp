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
    Phone.on('Phone:CallAccepted', (Name) => {
        alt.emitServer('VenoXPhone:CallAccepted', Name);
    });
    Phone.on('Phone:CallDenied', (Name) => {
        alt.emitServer('VenoXPhone:CallDenied', Name);
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


// Set Discord Avatar of Target
alt.onServer('Phone:ChangeCallTargetAvatar', (ID, Avatar) => {
    if (!Phone) { return; }
    Phone.emit("Phone:ChangeCallTargetAvatar", ID, Avatar);
});

alt.onServer('Phone:ShowIncomingCall', (Name, Telnr) => {
    if (!Phone) { return; }
    Phone.emit('Phone:ShowIncomingCall', Name, Telnr);
});

alt.on('keyup', (key) => {
    if (key == 'O'.charCodeAt()) {
        if (!GetCursorStatus()) {
            Phone.focus();
            PhoneOpen = true;
            ShowCursor(true);
            Phone.emit('Phone:Show', true);
        }
        else if (PhoneOpen) {
            Phone.unfocus();
            PhoneOpen = false;
            ShowCursor(false);
            Phone.emit('Phone:Show', false);
        }
    }
});