//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF } from '../../Globals/VnX-Lib';

let ZombieBrowser;

alt.onServer('Zombies:CreateHUD', (level) => {
    if (ZombieBrowser) return;
    ZombieBrowser = vnxCreateCEF('ZombieHUD', 'Zombies/HUD/index.html');
    alt.setTimeout(() => {
        ZombieBrowser.emit('UpdateZombieKills', level);
    }, 500);
});

alt.onServer('Zombies:DestroyHUD', () => {
    if (!ZombieBrowser) return;
    vnxDestroyCEF('ZombieHUD');
    ZombieBrowser = null;
});

alt.on('syncedMetaChange', (Entity, key, value, oldValue) => {
    if (!ZombieBrowser) return;
    if (Entity == alt.Player.local) {
        if (key == 'ZOMBIE_KILLS')
            ZombieBrowser.emit('UpdateZombieKills', value);
    }
});