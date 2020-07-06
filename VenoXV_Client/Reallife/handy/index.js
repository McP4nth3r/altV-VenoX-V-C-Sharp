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
    try {
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
    }
    catch{ }
});

alt.onServer('Phone:Unload', () => {
    try {
        if (!Phone) { return; }
        vnxDestroyCEF("VenoXPhone");
        Phone = null;
    }
    catch{ }
});

alt.onServer('Phone:LoadPlayerList', (Phonelist) => {
    try {
        if (!Phone) { return; }
        alt.setTimeout(() => {
            Phone.emit('CallList:Init', Phonelist);
            //alt.log(Phonelist);
        }, 500);
    }
    catch{ }
});


// Set Discord Avatar of Target
alt.onServer('Phone:ChangeCallTargetAvatar', (ID, Avatar) => {
    try {
        if (!Phone) { return; }
        Phone.emit("Phone:ChangeCallTargetAvatar", ID, Avatar);
    }
    catch{ }
});

alt.onServer('Phone:ShowIncomingCall', (Name, Telnr) => {
    try {
        if (!Phone) { return; }
        Phone.emit('Phone:ShowIncomingCall', Name, Telnr);
    }
    catch{ }
});

alt.onServer('Phone:HangupCall', () => {
    try {
        if (!Phone) { return; }
        Phone.emit('Phone:HangupCall');
    }
    catch{ }
});

alt.onServer('Phone:Show', (Show) => {
    try {
        if (!Phone) { return; }
        if (Show) {
            Phone.focus();
            PhoneOpen = true;
            Phone.emit('Phone:Show', true);
        }
        else {
            Phone.unfocus();
            PhoneOpen = false;
            Phone.emit('Phone:Show', false);
        }
    }
    catch{ }
});

alt.on('keyup', (key) => {
    try {
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
    }
    catch{ }
});