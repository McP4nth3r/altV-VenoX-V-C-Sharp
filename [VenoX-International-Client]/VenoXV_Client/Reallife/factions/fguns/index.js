//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import {
    ShowCursor,
    vnxCreateCEF,
    vnxDestroyCEF
} from '../../../Globals/VnX-Lib';
let FgunsWindow;
alt.onServer('fguns:Open', (State) => {
    if (FgunsWindow) return;
    FgunsWindow = vnxCreateCEF('fguns', 'Reallife/factions/fguns/main.html');
    ShowCursor(true);
    FgunsWindow.focus();
    alt.setTimeout(() => {
        FgunsWindow.emit('fguns:createentrys', State);
    }, 250);
    FgunsWindow.on('fguns:selectweapon', (weapon) => {
        alt.emitServer('fguns:selectweapon', weapon);
    });
    FgunsWindow.on('fguns:destroy', () => {
        FgunsWindow.unfocus();
        FgunsWindow = null;
        vnxDestroyCEF('fguns');
        ShowCursor(false);
    });
});

alt.onServer('fguns:ForceStateWindowUpdate', (nightstick_text, nightstick_amount, Tazer, weapon_tazer, Pistole, weapon_pistol, Pistole50, weapon_pistol50, Shotgun, weapon_pumpshotgun, CombatPDW, weapon_combatpdw, Karabiner, weapon_carbinerifle, Kampfgewehr, weapon_advancedrifle, Sniper, weapon_sniperrifle) => {
    if (!FgunsWindow) return;
    alt.setTimeout(() => {
        FgunsWindow.emit('fguns:ForceStateWindowUpdate', nightstick_text, nightstick_amount, Tazer, weapon_tazer, Pistole, weapon_pistol, Pistole50, weapon_pistol50, Shotgun, weapon_pumpshotgun, CombatPDW, weapon_combatpdw, Karabiner, weapon_carbinerifle, Kampfgewehr, weapon_advancedrifle, Sniper, weapon_sniperrifle);
    }, 500);
});