//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";

import { GetCursorStatus, ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../Globals/VnX-Lib';

let Phone;
let PhoneOpen = false;
alt.onServer('Phone:Load', () => {
    if (Phone) return;
    Phone = vnxCreateCEF("VenoXPhone", "Reallife/handy/main.html", "Reallife");
    Phone.on('Phone:CallingTarget', (Name) => alt.emitServer('VenoXPhone:CallTarget', Name));
    Phone.on('Phone:CallAccepted', (Name) => alt.emitServer('VenoXPhone:CallAccepted', Name));
    Phone.on('Phone:CallDenied', (Name) => alt.emitServer('VenoXPhone:CallDenied', Name));
    Phone.on('Phone:OnSMSMessageSend', (Name, Message) => alt.emitServer('Phone:OnSMSMessageSend', Name, Message));
});

alt.onServer('Phone:Unload', () => {
    try {
        if (!Phone) return;
        vnxDestroyCEF("VenoXPhone");
        Phone = null;
    }
    catch{ }
});

alt.onServer('Phone:LoadPlayerList', (Phonelist) => {
    if (!Phone) return;
    alt.setTimeout(() => {
        Phone.emit('Phone:AddNewPlayerEntry', Phonelist);
    }, 500);
});

alt.onServer('Phone:AddNewSMS', (From, Telnr, Message) => {
    if (!Phone) return;
    Phone.emit('Phone:AddNewSMS', From, Telnr, Message);
});


// Set Discord Avatar of Target
alt.onServer('Phone:ChangeCallTargetAvatar', (ID, Avatar) => {
    try {
        if (!Phone) return;
        Phone.emit("Phone:ChangeCallTargetAvatar", ID, Avatar);
    }
    catch{ }
});

alt.onServer('Phone:ShowIncomingCall', (Name, Telnr) => {
    try {
        if (!Phone) return;
        Phone.emit('Phone:ShowIncomingCall', Name, Telnr);
    }
    catch{ }
});

alt.onServer('Phone:HangupCall', () => {
    try {
        if (!Phone) return;
        Phone.emit('Phone:HangupCall');
    }
    catch{ }
});

alt.onServer('Phone:Show', (Show) => {
    try {
        if (!Phone) return;
        if (Show) {
            Phone.focus();
            Phone.emit('Phone:Show', true);
        }
        else {
            Phone.unfocus();
            Phone.emit('Phone:Show', false);
        }
    }
    catch{ }
});

alt.on('keyup', (key) => {
    try {
        if (key == 'O'.charCodeAt()) {
            if (!Phone) return;
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
    catch (e) { alt.log(e); }
});