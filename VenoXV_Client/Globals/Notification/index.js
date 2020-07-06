//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";

let browser_1 = new alt.WebView("http://resource/VenoXV_Client/Globals/Notification/notify.html");

alt.onServer('createVnXLiteNotify', (e, v) => {
    browser_1.emit("Notify:Create", e, v);
    browser_1.emit("SideNotification:Create", e, v);
});

alt.onServer('Globals:PlayHitsound', () => {
    browser_1.emit('Notify:PlayHitSound');
    VnXTM = Date.now() / 1000;
});

alt.onServer('Globals:ShowBloodScreen', () => {
    browser_1.emit('Notify:BloodScreen');
    //alt.log("Bloodscreen got called");
});


var VnXTM = 0;
alt.everyTick(() => {
    try {
        game.resetPlayerStamina(alt.Player.local.scriptID);
        if (!game.hasStreamedTextureDictLoaded("hud_reticle")) {
            game.requestStreamedTextureDict("hud_reticle", true);
        }
        if (game.hasStreamedTextureDictLoaded("hud_reticle")) {
            if ((Date.now() / 1000 - VnXTM) <= 0.1) {
                game.drawSprite("hud_reticle", "reticle_ar", 0.5, 0.5, 0.025, 0.040, 45, 255, 255, 255, 150);
            }
        }
        /*
        game.enableControlAction(0, 23, true);
        game.disableControlAction(0, 58, true);
        if (game.enableControlAction(0, 58)) {
            // G Key
        }
        */
        //Enter Vehicle with G
        game.disableControlAction(0, 58, true);
        if (game.isDisabledControlJustPressed(0, 58)) {
            if (alt.Player.local.vehicle) return;

            const player = alt.Player.local;
            let vehicle = game.getClosestVehicle(player.pos.x, player.pos.y, player.pos.z, 5.0, 0, 70);

            if (!vehicle) return;
            if (vehicle.speed > 5) return;
            if (!game.isVehicleSeatFree(vehicle, 0) && !game.isVehicleSeatFree(vehicle, 1) && !game.isVehicleSeatFree(vehicle, 2)) return;

            let boneFRDoor = game.getEntityBoneIndexByName(vehicle, 'door_pside_f');//Front right
            const posFRDoor = game.getWorldPositionOfEntityBone(vehicle, boneFRDoor);
            const distFRDoor = distance({ x: posFRDoor.x, y: posFRDoor.y, z: posFRDoor.z }, alt.Player.local.pos);

            let boneBLDoor = game.getEntityBoneIndexByName(vehicle, 'door_dside_r');//Back Left
            const posBLDoor = game.getWorldPositionOfEntityBone(vehicle, boneBLDoor);
            const distBLDoor = distance({ x: posBLDoor.x, y: posBLDoor.y, z: posBLDoor.z }, alt.Player.local.pos);

            let boneBRDoor = game.getEntityBoneIndexByName(vehicle, 'door_pside_r');//Back Right
            const posBRDoor = game.getWorldPositionOfEntityBone(vehicle, boneBRDoor);
            const distBRDoor = distance({ x: posBRDoor.x, y: posBRDoor.y, z: posBRDoor.z }, alt.Player.local.pos);

            let minDist = Math.min(distFRDoor, distBLDoor, distBRDoor);

            if (minDist == distFRDoor) {
                if (minDist > 1.8) return;

                if (game.isVehicleSeatFree(vehicle, 0)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, 0, 2, 1, 0);
                } else if (game.isVehicleSeatFree(vehicle, 2)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, 2, 2, 1, 0);
                }
                else {
                    return;
                }
            }
            if (minDist == distBLDoor) {
                if (minDist > 1.8) return;

                if (game.isVehicleSeatFree(vehicle, 1)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, 1, 2, 1, 0);
                } else {
                    return;
                }
            }
            if (minDist == distBRDoor) {
                if (minDist > 1.8) return;

                if (game.isVehicleSeatFree(vehicle, 2)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, 2, 2, 1, 0);
                } else if (game.isVehicleSeatFree(vehicle, 0)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, 0, 2, 1, 0);
                }
                else {
                    return;
                }
            }
        }

        //Enter Vehicle with F
        game.disableControlAction(0, 23, true);
        if (game.isDisabledControlJustPressed(0, 23)) {
            if (alt.Player.local.vehicle == null) {
                const player = alt.Player.local;
                let vehicle = game.getClosestVehicle(player.pos.x, player.pos.y, player.pos.z, 5.0, 0, 70);
                if (!vehicle) return;
                if (vehicle.speed > 5) return;

                let boneFLDoor = game.getEntityBoneIndexByName(vehicle, 'door_dside_f');//Front Left
                const posFLDoor = game.getWorldPositionOfEntityBone(vehicle, boneFLDoor);
                const distFLDoor = distance({ x: posFLDoor.x, y: posFLDoor.y, z: posFLDoor.z }, alt.Player.local.pos);

                let boneFRDoor = game.getEntityBoneIndexByName(vehicle, 'door_pside_f');//Front Right
                const posFRDoor = game.getWorldPositionOfEntityBone(vehicle, boneFRDoor);
                const distFRDoor = distance({ x: posFRDoor.x, y: posFRDoor.y, z: posFRDoor.z }, alt.Player.local.pos);

                if (game.isVehicleSeatFree(vehicle, 0)) {
                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, -1, 2, 1, 0);
                } else {
                    if (distFRDoor < distFLDoor) return;

                    game.taskEnterVehicle(alt.Player.local.scriptID, vehicle, 5000, -1, 2, 1, 0);
                }
            }
        }
        if (alt.Player.local.vehicle != null) {
            game.setPedConfigFlag(alt.Player.local.scriptID, 184, true);
        }
    }
    catch (e) { alt.log(e); }
});

function distance(vector1, vector2) {
    if (vector1 === undefined || vector2 === undefined) {
        throw new Error('AddVector => vector1 or vector2 is undefined');
    }

    return Math.sqrt(
        Math.pow(vector1.x - vector2.x, 2) +
        Math.pow(vector1.y - vector2.y, 2) +
        Math.pow(vector1.z - vector2.z, 2)
    );
}