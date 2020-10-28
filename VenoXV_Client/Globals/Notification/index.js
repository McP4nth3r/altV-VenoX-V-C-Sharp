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

alt.onServer('Quests:Show', (State) => {
    browser_1.emit('Quests:Show', State);
});
alt.onServer('Quest:SetCurrentQuest', (QuestText, QuestMoney, QuestLevel) => {
    browser_1.emit('Quests:SetCurrentQuest', QuestText, QuestMoney, QuestLevel);
});

/*
var seats = {
    0: "seat_pside_f", // passanger side front
    1: "seat_dside_r", // driver side rear
    2: "seat_pside_r", // passanger side rear
    3: "seat_dside_r1", // driver side rear1
    4: "seat_pside_r1", // passanger side rear1
    5: "seat_dside_r2", // driver side rear2
    6: "seat_pside_r2", // passanger side rear2
    7: "seat_dside_r3", // driver side rear3
    8: "seat_pside_r3", // passanger side rear3
    9: "seat_dside_r4", // driver side rear4
    10: "seat_pside_r4", // passanger side rear4
    11: "seat_dside_r5", // driver side rear5
    12: "seat_pside_r5", // passanger side rear5
    13: "seat_dside_r6", // driver side rear6
    14: "seat_pside_r6", // passanger side rear6
    15: "seat_dside_r7", // driver side rear7
    16: "seat_pside_r7", // passanger side rear7
}

let NearestVehicle = [];
let targetVeh = {
    veh: null,
    dist: 100
}
*/
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

        /*
                game.enableControlAction(0, 23, true);
                game.disableControlAction(0, 58, true);
                if (game.isDisabledControlJustPressed(0, 58)) {
                    SyncVehicleList();
                    if (NearestVehicle.length > 0) {
                        let pos = alt.Player.local.pos;
                        let veh = targetVeh.veh;
                        if (veh != null) {
                            if (game.areAnyVehicleSeatsFree(veh.scriptID)) {
                                let toEnter = {
                                    seat: 0,
                                    dist: 99999,
                                    pos: new alt.Vector3(0, 0, 0)
                                }
                                let insideSeatsFree = false;
                                let seats_count = game.getVehicleModelNumberOfSeats(veh.model);
        
                                for (var i = 0; i <= seats_count; i++) {
                                    if (game.isVehicleSeatFree(veh.scriptID, i)) {
                                        if (i <= 2) {
                                            insideSeatsFree = true;
                                        }
                                        let seat = seats[i];
                                        let seat_pos = game.getWorldPositionOfEntityBone(veh.scriptID, game.getEntityBoneIndexByName(veh.scriptID, seat));
                                        let seat_dist = game.vdist2(pos.x, pos.y, pos.z, seat_pos.x, seat_pos.y, seat_pos.z);
        
                                        if ((i > 2) && (insideSeatsFree == true)) { } else {
        
                                            if (veh.model == 1917016601 && i > 0) {
                                                if ((toEnter.dist > 30)) {
                                                    toEnter.dist = 30;
                                                    toEnter.seat = i;
                                                }
                                            }
        
                                            if ((seat_dist < toEnter.dist)) {
                                                toEnter.dist = seat_dist;
                                                toEnter.seat = i;
                                            }
                                        }
                                    }
                                }
                                if ((veh.model == 1475773103) && (toEnter.seat > 0)) { // if rumpo3
                                    game.taskEnterVehicle(alt.Player.local.scriptID, veh.scriptID, 5000, toEnter.seat, 2.0, 16, 0);
                                } else {
                                    game.taskEnterVehicle(alt.Player.local.scriptID, veh.scriptID, 5000, toEnter.seat, 2.0, 1, 0);
                                }
                            }
                        }
                    }
                }
                */
    }
    catch (e) { alt.log(e); }
});

/*
function SyncVehicleList() {
    NearestVehicle = [];
    targetVeh = {
        veh: null,
        dist: 100
    }
    let position = alt.Player.local.pos;
    for (var vehCounter in alt.Vehicle.all) {
        let vehicle = alt.Vehicle.all[vehCounter];
        let distance = game.getDistanceBetweenCoords(position.x, position.y, position.z, vehicle.pos.x, vehicle.pos.y, vehicle.pos.z, true);
        if (distance <= 25) {
            NearestVehicle.push(vehicle);
        }
    }
    GetNearestVehicle();
}

function GetNearestVehicle() {
    let pos = alt.Player.local.pos;
    for (var vehCounter in alt.Vehicle.all) {
        let veh = alt.Vehicle.all[vehCounter];
        let vp = veh.pos;
        let dist = game.vdist2(pos.x, pos.y, pos.z, vp.x, vp.y, vp.z);
        if (dist < targetVeh.dist) {
            targetVeh.dist = dist;
            targetVeh.veh = veh;
        }
    }
}
*/


