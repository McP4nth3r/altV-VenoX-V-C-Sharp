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
    F5: 116,
    W: 87, //232
    S: 83, //31, 219, 233, 268, 269
    A: 65, //234
    D: 68, //30, 218, 235, 266, 267
    Space: 32,
    LCtrl: 17,
    Shift: 16
};

let fastMult = 0.5;
let slowMult = 0.15;
let devfly = { flying: false, f: 2.0, w: 2.0, h: 2.0 };


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
    }
    if (key == controlsIds.F5) {
        F5Pressed = !F5Pressed;
    }
}


alt.everyTick(() => {
    const aduty = true;
    if (aduty) {
        let fly = devfly;
        if (F5Pressed) {
            const direction = game.getFinalRenderedCamCoord();
            let updated = false;
            let position = alt.Player.local.pos;
            let x = position.x;
            let y = position.y;
            let z = position.z;
            if (W_Pressed) {
                x = position.x + direction.x * fastMult * slowMult;
                y = position.y + direction.y * fastMult * slowMult;
                z = position.z + direction.z * fastMult * slowMult;
                updated = true;
            }
            else if (S_Pressed) {
                x = position.x - direction.x * fastMult * slowMult;
                y = position.y - direction.y * fastMult * slowMult;
                z = position.z - direction.z * fastMult * slowMult;
                updated = true;
            }
            else {
                fly.f = 2.0;
            }

            if (A_Pressed) {
                x = position.x + (-direction.y) * fastMult * slowMult;;
                y = position.y + direction.x * fastMult * slowMult;;
                updated = true;
            }
            else if (D_Pressed) {
                if (fly.l < 8.0)
                    fly.l *= 1.05;

                x = position.x - (-direction.y) * fastMult * slowMult;;
                y = position.y - direction.x * fastMult * slowMult;;
                updated = true;
            }
            else {
                fly.l = 2.0;
            }

            if (SpacePressed) {

                z = position.z + fastMult * slowMult;;
                updated = true;
            }
            else {
                fly.h = 2.0;
            }

            if (updated) {
                game.setEntityCoordsNoOffset(alt.Player.local.scriptID, x, y, z, false, false, false);
                //game.setEntityCoords(alt.Player.local.scriptID, x, y, z);
            }
        }
    }
});