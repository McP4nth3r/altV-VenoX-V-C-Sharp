//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { FreezeClient } from '../../Globals/VnX-Lib/events';

let SpacePressed = false;
let F5Pressed = false;
let W_Pressed = false;
let S_Pressed = false;
let A_Pressed = false;
let D_Pressed = false;
let LCtrl_Pressed = false;
let Shift_Pressed = false;
const controlsIds =
{
    F5: 327,
    W: 32, //232
    S: 33, //31, 219, 233, 268, 269
    A: 34, //234
    D: 35, //30, 218, 235, 266, 267
    Space: 321,
    LCtrl: 326,
    Shift: 16
};

let devfly = { flying: false, f: 2.0, w: 2.0, h: 2.0 };
let gameplayCam = game.createCamera('gameplay');

let fastMult = 3;
let slowMult = 0.5;

export function onTacticsSpectatorKeyDown(key) {
    if (key == controlsIds.W) { W_Pressed = true };
    if (key == controlsIds.A) { A_Pressed = true };
    if (key == controlsIds.S) { S_Pressed = true };
    if (key == controlsIds.D) { D_Pressed = true };
    if (key == controlsIds.LCtrl) { LCtrl_Pressed = true };
    if (key == controlsIds.Shift) { Shift_Pressed = true };


    if (key == controlsIds.Shift) {
        fastMult = 3;
    }
    if (key == controlsIds.LCtrl) {
        slowMult = 0.5;
    }
    if (key == controlsIds.Space) {
        SpacePressed = true;
    }
    if (key == controlsIds.F5) {
        alt.log('key down ' + key);
        F5Pressed = true;
    }
    if (key == controlsIds.F5) {
        fly.flying = !fly.flying;
        const player = alt.Player.local;
        FreezeClient(fly.flying);
        if (!fly.flying && !SpacePressed) {
            let position = player.pos;
            position.z = game.getGroundZFor3dCoord(position.x, position.y, position.z, 0.0, false);
            game.setEntityCoordsNoOffset(player.scriptID, position.x, position.y, position.z, false, false, false);
        }
    }
}


export function OnTacticsSpectatorKeyUp(key) {
    if (key == controlsIds.W) { W_Pressed = false; };
    if (key == controlsIds.A) { A_Pressed = false };
    if (key == controlsIds.S) { S_Pressed = false };
    if (key == controlsIds.D) { D_Pressed = false };
    if (key == controlsIds.LCtrl) { LCtrl_Pressed = false };
    if (key == controlsIds.Shift) { Shift_Pressed = false };


    if (key == controlsIds.Space) {
        SpacePressed = false;
        alt.log('key up ' + key);
    }
    if (key == controlsIds.F5) {
        F5Pressed = false;
        alt.log('key up ' + key);
    }
}


alt.everyTick(() => {
    const aduty = true;
    if (aduty) {
        let fly = devfly;
        const direction = game.getFinalRenderedCamCoord();
        var fastMult = 1;
        var slowMult = 1;


        if (F5Pressed) {
            fly.flying = !fly.flying;
            FreezeClient(fly.flying);
            if (!fly.flying && !SpacePressed) {
                let position = alt.Player.pos;
                position.z = game.getGroundZFor3dCoord(position.x, position.y, position.z, 0.0, false);
                game.setEntityCoordsNoOffset(alt.Player.local.scriptID, position.x, position.y, position.z, false, false, false);
            }
            alt.log('If F5 Pressed Called');
        }
        else if (fly.flying) {
            let updated = false;
            let position = alt.Player.pos;

            alt.log('If Fly Fyling Called');
            if (W_Pressed) {
                position.x += direction.x * fastMult * slowMult;;
                position.y += direction.y * fastMult * slowMult;;
                position.z += direction.z * fastMult * slowMult;;
                updated = true;
            }
            else if (S_Pressed) {

                position.x -= direction.x * fastMult * slowMult;;
                position.y -= direction.y * fastMult * slowMult;;
                position.z -= direction.z * fastMult * slowMult;;
                updated = true;
            }
            else {
                fly.f = 2.0;
            }

            if (A_Pressed) {
                position.x += (-direction.y) * fastMult * slowMult;;
                position.y += direction.x * fastMult * slowMult;;
                updated = true;
            }
            else if (D_Pressed) {
                if (fly.l < 8.0)
                    fly.l *= 1.05;

                position.x -= (-direction.y) * fastMult * slowMult;;
                position.y -= direction.x * fastMult * slowMult;;
                updated = true;
            }
            else {
                fly.l = 2.0;
            }

            if (SpacePressed) {

                position.z += fastMult * slowMult;;
                updated = true;
            }
            else {
                fly.h = 2.0;
            }

            if (updated) {
                game.setEntityCoordsNoOffset(alt.Player.local.scriptID, position.x, position.y, position.z, false, false, false);
            }
        }
    }
});