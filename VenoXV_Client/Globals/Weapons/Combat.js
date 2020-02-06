
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

var w = undefined;
var a = undefined;


function GetWeaponData(e, v) {
    if (e == 7872484) {
        if (v == "Name") {
            return "compactlauncher";
        }
        else {
            return "125959754";
        }
    }
    else if (e == 37527445) {
        if (v == "Name") {
            return "ball";
        }
        else {
            return "600439132";
        }
    }
    else if (e == 100416529) {
        if (v == "Name") {
            return "Sniper";
        }
        else {
            return "100416529";
        }
    }
    else if (e == 101631238) {
        if (v == "Name") {
            return "fireextinguisher";
        }
        else {
            return "101631238";
        }
    }
    else if (e == 101716584) {
        if (v == "Name") {
            return "gusenberg";
        }
        else {
            return "1627465347";
        }
    }

    else if (e == 111591470) {
        if (v == "Name") {
            return "marksmanrifle_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 126349499) {
        if (v == "Name") {
            return "Schneeball";
        }
        else {
            return "126349499";
        }
    }

    else if (e == 137902532) {
        if (v == "Name") {
            return "vintagepistol";
        }
        else {
            return "137902532";
        }
    }

    else if (e == 171789620) {
        if (v == "Name") {
            return "Einsatz PDW";
        }
        else {
            return "171789620";
        }
    }

    else if (e == 177293209) {
        if (v == "Name") {
            return "heavysniper_mk2";
        }
        else {
            return "177293209";
        }
    }

    else if (e == 3173288789) {
        if (v == "Name") {
            return "Mini - SMG";
        }
        else {
            return "-1121678507";
        }
    }

    else if (e == 205991906) {
        if (v == "Name") {
            return "heavysniper";
        }
        else {
            return "205991906";
        }
    }

    else if (e == 317205821) {
        if (v == "Name") {
            return "autoshotgun";
        }
        else {
            return "317205821";
        }
    }

    else if (e == 324215364) {
        if (v == "Name") {
            return "microsmg";
        }
        else {
            return "324215364";
        }
    }

    else if (e == 419712736) {
        if (v == "Name") {
            return "weapon_wrench";
        }
        else {
            return "419712736";
        }
    }

    else if (e == 453432689) {
        if (v == "Name") {
            return "Pistol";
        }
        else {
            return "453432689";
        }
    }

    else if (e == 487013001) {
        if (v == "Name") {
            return "Pump Shotgun";
        }
        else {
            return "487013001";
        }
    }

    else if (e == 584646201) {
        if (v == "Name") {
            return "appistol";
        }
        else {
            return "584646201";
        }
    }

    else if (e == 615608432) {
        if (v == "Name") {
            return "molotov";
        }
        else {
            return "615608432";
        }
    }

    else if (e == 736523883) {
        if (v == "Name") {
            return "MP";
        }
        else {
            return "736523883";
        }
    }

    else if (e == 741814745) {
        if (v == "Name") {
            return "Haftbombe";
        }
        else {
            return "741814745";
        }
    }

    else if (e == 883325847) {
        if (v == "Name") {
            return "petrolcan";
        }
        else {
            return "883325847";
        }
    }

    else if (e == 911657153) {
        if (v == "Name") {
            return "Tazer";
        }
        else {
            return "911657153";
        }
    }

    else if (e == 940833800) {
        if (v == "Name") {
            return "weapon_stone_hatchet";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 961495388) {
        if (v == "Name") {
            return "assaultrifle_mk2";
        }
        else {
            return "961495388";
        }
    }

    else if (e == 984333226) {
        if (v == "Name") {
            return "Schwere Shotgun";
        }
        else {
            return "984333226";
        }
    }

    else if (e == 1119849093) {
        if (v == "Name") {
            return "Minigun";
        }
        else {
            return "1119849093";
        }
    }

    else if (e == 1141786504) {
        if (v == "Name") {
            return "Golfschläger";
        }
        else {
            return "1141786504";
        }
    }

    else if (e == 1198879012) {
        if (v == "Name") {
            return "flaregun";
        }
        else {
            return "1198879012";
        }
    }

    else if (e == 1233104067) {
        if (v == "Name") {
            return "flare";
        }
        else {
            return "1233104067";
        }
    }

    else if (e == 1305664598) {
        if (v == "Name") {
            return "grenadelauncher_smoke";
        }
        else {
            return "1305664598";
        }
    }

    else if (e == 1317494643) {
        if (v == "Name") {
            return "weapon_hammer";
        }
        else {
            return "1317494643";
        }
    }

    else if (e == 1432025498) {
        if (v == "Name") {
            return "pumpshotgun_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 1593441988) {
        if (v == "Name") {
            return "Gefechtspistole";
        }
        else {
            return "1593441988";
        }
    }


    else if (e == 1649403952) {
        if (v == "Name") {
            return "compactrifle";
        }
        else {
            return "1649403952";
        }
    }

    else if (e == 1672152130) {
        if (v == "Name") {
            return "hominglauncher";
        }
        else {
            return "1672152130";
        }
    }

    else if (e == 1737195953) {
        if (v == "Name") {
            return "Schlagstock";
        }
        else {
            return "1737195953";
        }
    }

    else if (e == 1834241177) {
        if (v == "Name") {
            return "Railgun";
        }
        else {
            return "1737195953";
        }
    }

    else if (e == 2017895192) {
        if (v == "Name") {
            return "Abgesägte Shotgun";
        }
        else {
            return "2017895192";
        }
    }

    else if (e == 2024373456) {
        if (v == "Name") {
            return "smg_mk2";
        }
        else {
            return "2024373456";
        }
    }

    else if (e == 2132975508) {
        if (v == "Name") {
            return "bullpuprifle";
        }
        else {
            return "2132975508";
        }
    }

    else if (e == 2138347493) {
        if (v == "Name") {
            return "firework";
        }
        else {
            return "2138347493";
        }
    }

    else if (e == 2144741730) {
        if (v == "Name") {
            return "combatmg";
        }
        else {
            return "2144741730";
        }
    }

    else if (e == 2210333304) {
        if (v == "Name") {
            return "Karabiner";
        }
        else {
            return "-2084633992";
        }
    }

    else if (e == 2227010557) {
        if (v == "Name") {
            return "weapon_crowbar";
        }
        else {
            return "-2067956739";
        }
    }

    else if (e == 2228681469) {
        if (v == "Name") {
            return "bullpuprifle_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }


    else if (e == 2285322324) {
        if (v == "Name") {
            return "snspistol_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 2343591895) {
        if (v == "Name") {
            return "Taschenlampe";
        }
        else {
            return "-1951375401";
        }
    }

    else if (e == 2460120199) {
        if (v == "Name") {
            return "weapon_dagger";
        }
        else {
            return "-1834847097";
        }
    }

    else if (e == 2481070269) {
        if (v == "Name") {
            return "Granate";
        }
        else {
            return "-1813897027";
        }
    }

    else if (e == 2484171525) {
        if (v == "Name") {
            return "weapon_poolcue";
        }
        else {
            return "-1810795771";
        }
    }

    else if (e == 2508868239) {
        if (v == "Name") {
            return "Baseball";
        }
        else {
            return "-1786099057";
        }
    }

    else if (e == 2526821735) {
        if (v == "Name") {
            return "specialcarbine_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 2548703416) {
        if (v == "Name") {
            return "doubleaction";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 2578377531) {
        if (v == "Name") {
            return "Pistol 50.";
        }
        else {
            return "2578377531";
        }
    }

    else if (e == 2578778090) {
        if (v == "Name") {
            return "Messer";
        }
        else {
            return "-1716189206";
        }
    }

    else if (e == 2634544996) {
        if (v == "Name") {
            return "MG";
        }
        else {
            return "-1660422300";
        }
    }

    else if (e == 2640438543) {
        if (v == "Name") {
            return "bullupshotgun";
        }
        else {
            return "-1654528753";
        }
    }

    else if (e == 2694266206) {
        if (v == "Name") {
            return "bzgas";
        }
        else {
            return "-1600701090";
        }
    }

    else if (e == 2725352035) {
        if (v == "Name") {
            return "unbewaffnet";
        }
        else {
            return "-1569615261";
        }
    }

    else if (e == 2726580491) {
        if (v == "Name") {
            return "grenadelauncher";
        }
        else {
            return "-1568386805";
        }
    }

    else if (e == 2828843422) {
        if (v == "Name") {
            return "musket";
        }
        else {
            return "-1466123874";
        }
    }

    else if (e == 2874559379) {
        if (v == "Name") {
            return "mine";
        }
        else {
            return "-1420407917";
        }
    }

    else if (e == 2937143193) {
        if (v == "Name") {
            return "Kampfgewehr";
        }
        else {
            return "-1357824103";
        }
    }

    else if (e == 2982836145) {
        if (v == "Name") {
            return "RPG";
        }
        else {
            return "-1312131151";
        }
    }

    else if (e == 3125143736) {
        if (v == "Name") {
            return "pipebomb";
        }
        else {
            return "-1169823560";
        }
    }

    else if (e == 3218215474) {
        if (v == "Name") {
            return "snspistol";
        }
        else {
            return "-1076751822";
        }
    }

    else if (e == 3219281620) {
        if (v == "Name") {
            return "pistol_mk2";
        }
        else {
            return "3219281620";
        }
    }

    else if (e == 3220176749) {
        if (v == "Name") {
            return "assaultrifle";
        }
        else {
            return "-1074790547";
        }
    }

    else if (e == 3231910285) {
        if (v == "Name") {
            return "specialcarbine";
        }
        else {
            return "-1063057011";
        }
    }


    else if (e == 3249783761) {
        if (v == "Name") {
            return "Revolver";
        }
        else {
            return "3249783761";
        }
    }

    else if (e == 3342088282) {
        if (v == "Name") {
            return "marksmanrifle";
        }
        else {
            return "-952879014";
        }
    }

    else if (e == 3415619887) {
        if (v == "Name") {
            return "revolver_mk2";
        }
        else {
            return "NOT DEFINED";
        }
    }

    else if (e == 3441901897) {
        if (v == "Name") {
            return "weapon_battleaxe";
        }
        else {
            return "-853065399";
        }
    }

    else if (e == 3523564046) {
        if (v == "Name") {
            return "schwere pistole";
        }
        else {
            return "-771403250";
        }
    }

    else if (e == 3638508604) {
        if (v == "Name") {
            return "weapon_knuckle";
        }
        else {
            return "-656458692";
        }
    }

    else if (e == 3675956304) {
        if (v == "Name") {
            return "machinepistol";
        }
        else {
            return "-619010992";
        }
    }

    else if (e == 3686625920) {
        if (v == "Name") {
            return "combatmg_mk2";
        }
        else {
            return "3686625920";
        }
    }

    else if (e == 3696079510) {
        if (v == "Name") {
            return "marksmanpistol";
        }
        else {
            return "-598887786";
        }
    }

    else if (e == 3713923289) {
        if (v == "Name") {
            return "Machete";
        }
        else {
            return "-581044007";
        }
    }

    else if (e == 3756226112) {
        if (v == "Name") {
            return "Messer";
        }
        else {
            return "-538741184";
        }
    }

    else if (e == 3800352039) {
        if (v == "Name") {
            return "assaultshotgun";
        }
        else {
            return "-494615257";
        }
    }

    else if (e == 4019527611) {
        if (v == "Name") {
            return "dbshotgun";
        }
        else {
            return "-275439685";
        }
    }

    else if (e == 4024951519) {
        if (v == "Name") {
            return "assaultsmg";
        }
        else {
            return "-270015777";
        }
    }

    else if (e == 4191993645) {
        if (v == "Name") {
            return "weapon_hatchet";
        }
        else {
            return "-102973651";
        }
    }

    else if (e == 4192643659) {
        if (v == "Name") {
            return "weapon_bottle";
        }
        else {
            return "-102323637";
        }
    }

    else if (e == 4208062921) {
        if (v == "Name") {
            return "carbinerifle_mk2";
        }
        else {
            return "4208062921";
        }
    }

    else if (e == 4222310262) {
        if (v == "Name") {
            return "Fallschirm";
        }
        else {
            return "-72657034";
        }
    }

    else if (e == 4256991824) {
        if (v == "Name") {
            return "Smokegrenade";
        }
        else {
            return "-37975472";
        }
    }
}

var player_bones = {
    "SKEL_L_UpperArm": {
        bone_id: 45509,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_UpperArm": {
        bone_id: 40269,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Forearm": {
        bone_id: 61163,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_Forearm": {
        bone_id: 28252,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_Head": {
        bone_id: 31086,
        threshold: 0.25,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_Hand": {
        bone_id: 57005,
        threshold: 0.06,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Hand": {
        bone_id: 18905,
        threshold: 0.06,
        offset: {
            x: 0,
            y: 0,
            z: 0.05
        }
    },
    "SKEL_R_Clavicle": {
        bone_id: 10706,
        threshold: 0.1,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Clavicle": {
        bone_id: 64729,
        threshold: 0.1,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_Spine0": {
        bone_id: 23553,
        threshold: 0.15,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_Spine1": {
        bone_id: 24816,
        threshold: 0.15,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_Spine2": {
        bone_id: 24817,
        threshold: 0.15,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_Spine3": {
        bone_id: 24818,
        threshold: 0.15,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_Calf": {
        bone_id: 36864,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Calf": {
        bone_id: 63931,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Thigh": {
        bone_id: 58271,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_Thigh": {
        bone_id: 51826,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_R_Foot": {
        bone_id: 52301,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    },
    "SKEL_L_Foot": {
        bone_id: 14201,
        threshold: 0.08,
        offset: {
            x: 0,
            y: 0,
            z: 0
        }
    }
}

function getWeaponDetails(weapon) {
    return {
        spray: 2.5,
        max_dist: 30
    };
}

function getIsHitOnBone(hitPosition, target) {
    let nearest_bone = "";
    let nearest_bone_dist = 99;
    if (target != null) {
        for (let bone in player_bones) {
            let bone_id = player_bones[bone].bone_id;
            let offset = player_bones[bone].offset;
            let threshold = player_bones[bone].threshold;
            let headPos = game.getPedBoneCoords(alt.Player.local, 12844, 0, 0, 0);
            let pos = target.getBoneCoords(bone_id, offset.x, offset.y, offset.z);
            let hit_dist = game.vdist(hitPosition.x, hitPosition.y, hitPosition.z, pos.x, pos.y, pos.z);
            if (hit_dist < 1.6) {
                let vector = new alt.Vector3(hitPosition.x - headPos.x, hitPosition.y - headPos.y, hitPosition.z - headPos.z);
                let dist_aim = game.vdist(hitPosition.x, hitPosition.y, hitPosition.z, headPos.x, headPos.y, headPos.z);
                let vectorNear = vector.normalize(dist_aim);
                //....
                let dist = game.vdist(pos.x, pos.y, pos.z, headPos.x, headPos.y, headPos.z);
                let vectorAtPos = vectorNear.multiply(dist);
                let aimdist = game.vdist(pos.x, pos.y, pos.z, headPos.x + vectorAtPos.x, headPos.y + vectorAtPos.y, headPos.z + vectorAtPos.z)
                if (nearest_bone_dist > aimdist) {
                    if (aimdist <= threshold) {
                        nearest_bone = bone;
                        nearest_bone_dist = aimdist;
                    }
                }
            }
        }
    }
    return {
        hit: (nearest_bone != "" ? true : false),
        bone: nearest_bone,
        dist: nearest_bone_dist
    };
}

function isWallbugging(target_position) {
    let gun_pos = game.getPedBoneCoords(alt.Player.local, 40269, 0, 0, 0);
    let raycast = game.startShapeTestRay(target_position, gun_pos, alt.Player.local, -1);

    if (raycast) {
        let hit_pos = raycast.position;
        let entry_point = new alt.Vector3(hit_pos.x - gun_pos.x, hit_pos.y - gun_pos.y, hit_pos.z - gun_pos.z);
        let entry_dist = game.vdist(hit_pos.x, hit_pos.y, hit_pos.z, gun_pos.x, gun_pos.y, gun_pos.z);
        let entry_normalize = entry_point.normalize(entry_dist / 2);
        let entry_final_point = entry_normalize.multiply(entry_dist / 2);
        let entry_point_vector = new alt.Vector3(hit_pos.x + entry_final_point.x, hit_pos.y + entry_final_point.y, hit_pos.z + entry_final_point.z)
        let exit_point_vector = new alt.Vector3(hit_pos.x - entry_final_point.x, hit_pos.y - entry_final_point.y, hit_pos.z - entry_final_point.z)
        let entry_point_pos = game.startShapeTestRay(entry_point_vector, exit_point_vector, alt.Player.local, -1);
        let exit_point_pos = game.startShapeTestRay(exit_point_vector, entry_point_vector, alt.Player.local, -1);
        if ((entry_point_pos) && (exit_point_pos)) {
            let dist = game.vdist(entry_point_pos.position.x, entry_point_pos.position.y, entry_point_pos.position.z, exit_point_pos.position.x, exit_point_pos.position.y, exit_point_pos.position.z)
            if (dist < 0.45) {
                return false;
            } else {
                return true;
            }
        } else {
            return true;
        }
    } else {
        return false;
    }
}

function calculateShotgunPelletsOnPlayers() {
    let currentweaponn = game.getCurrentPedWeaponEntityIndex(alt.Player.local.scriptID);
    let hitted_entity = null;
    var gun_pos = game.getPedBoneCoords(alt.Player.local, 40269, 0, 0, 0);
    let aim_point = alt.Player.local.aimingAt;
    let raycast = game.startShapeTestRay(aim_point, gun_pos, alt.Player.local, -1);
    if (!raycast) {
        alt.forEachInStreamRange((ped) => {
            if (alt.Player.local != ped) {
                let pos = ped.getWorldPositionOfBone(ped.getBoneIndexByName("IK_Head"));
                let raycast1 = game.startShapeTestRay(gun_pos, pos, alt.Player.local, -1);
                if (!raycast1) {
                    let headPos = game.getPedBoneCoords(alt.Player.local, 12844, 0, 0, 0);
                    let vector = new alt.Vector3(aim_point.x - headPos.x, aim_point.y - headPos.y, aim_point.z - headPos.z);
                    let dist_aim = game.vdist(aim_point.x, aim_point.y, aim_point.z, headPos.x, headPos.y, headPos.z);
                    let vectorNear = vector.normalize(dist_aim);
                    //....
                    let dist = game.vdist(pos.x, pos.y, pos.z, headPos.x, headPos.y, headPos.z);
                    let vectorAtPos = vectorNear.multiply(dist);
                    let aim_vector = new alt.Vector3(headPos.x + vectorAtPos.x, headPos.y + vectorAtPos.y, headPos.z + vectorAtPos.z);
                    let spray_dist = game.vdist(pos.x, pos.y, pos.z, headPos.x + vectorAtPos.x, headPos.y + vectorAtPos.y, headPos.z + vectorAtPos.z)
                    let ped_dist = game.vdist(pos.x, pos.y, pos.z, gun_pos.x, gun_pos.y, gun_pos.z)
                    let w_data = getWeaponDetails(Number(currentweaponn));
                    if (w_data) {
                        let spray_size = VnX_lerp(0.5, w_data.spray, 1 / w_data.max_dist * ped_dist)
                        if (spray_size > w_data.spray) spray_size = w_data.spray;
                        let would_hit = false;
                        if (spray_size > spray_dist) would_hit = true;
                        if (would_hit == true) {
                            hitted_entity = ped;
                        }
                    }
                }
            }
        });
    }
    return hitted_entity;
}

var VnXTM = 0;
alt.everyTick(() => {
    if (game.isPedShooting(alt.Player.scriptID)) {
        //game.GetShot
    }
    game.resetPlayerStamina(alt.Player.local.scriptID);
    if (!game.hasStreamedTextureDictLoaded("hud_reticle")) {
        game.requestStreamedTextureDict("hud_reticle", true);
    }
    if (game.hasStreamedTextureDictLoaded("hud_reticle")) {
        if ((Date.now() / 1000 - VnXTM) <= 0.1) {
            game.drawSprite("hud_reticle", "reticle_ar", 0.5, 0.5, 0.025, 0.040, 45, 255, 255, 255, 150);
        }
    }
});

function playerWeaponShot(targetPosition, targetEntity) {
    let currentweaponn = game.getCurrentPedWeaponEntityIndex(alt.Player.local.scriptID);
    let weapon_hash = GetWeaponData(currentweaponn, "Name");
    var wh = GetWeaponData(Number(currentweaponn), "Name"),
        w = currentweaponn,

        a = game.getAmmoInClip(alt.Player.local.scriptID, currentweapon);
    game.getCurrentPedWeapon(alt.Player.local.weapon.scriptID)
    game.getCurrentPedWeaponEntityIndex(alt.Player.local.scriptID);
    //mp.events.callRemote("WeaponFiredToServer", wh, a);
    game.setPlayerTargetingMode(1);
    game.setPlayerLockon(altv.Player.local.scriptID, false);
    game.setPlayerLockonRangeOverride(altv.Player.local.scriptID, 0.0);
    if (isWallbugging(targetPosition) == false) {
        if (targetEntity) {
            let bone = getIsHitOnBone(targetPosition, targetEntity).bone;
            if (bone.length < 2) { bone = "EMPTY"; }
            if (targetEntity.vehicle) {
                alt.log("Du hast ein Auto gehittet!");
                //mp.events.callRemote("OnHittedEntity", targetEntity, weapon_hash, bone);
                return;
            }
            else {
                alt.log("Du hast einen Spieler gehittet!");
                //mp.events.callRemote("OnHittedEntity", targetEntity, weapon_hash, bone);
            }
            let hp = targetEntity.getHealth();
            if (hp > 0) {
                VnXTM = Date.now() / 1000;
            }
        } else {
            if (game.getWeapontypeGroup(currentweaponn) == 860033945) {
                let shotgunHitEntity = calculateShotgunPelletsOnPlayers();
                if (shotgunHitEntity != null) {
                    alt.log("Du hast mit einer Shotgun einen Spieler gehittet!");
                    //mp.events.callRemote("OnHittedEntity", shotgunHitEntity, weapon_hash, "EMPTY");
                    if (hp > 0) {
                        VnXTM = Date.now() / 1000;
                    }
                }
            }
        }
    }
};



alt.Vector3.prototype.findRot = function (rz, dist, rot) {
    let nVector = new alt.Vector3(this.x, this.y, this.z);
    let degrees = (rz + rot) * (Math.PI / 180);
    nVector.x = this.x + dist * Math.cos(degrees);
    nVector.y = this.y + dist * Math.sin(degrees);
    return nVector;
}
alt.Vector3.prototype.rotPoint = function (pos) {
    let temp = new alt.Vector3(this.x, this.y, this.z);
    let temp1 = new alt.Vector3(pos.x, pos.y, pos.z);
    let gegenkathete = temp1.z - temp.z
    let a = temp.x - temp1.x;
    let b = temp.y - temp1.y;
    let ankathete = Math.sqrt(a * a + b * b);
    let winkel = Math.atan2(gegenkathete, ankathete) * 180 / Math.PI
    return winkel;
}


alt.Vector3.prototype.lerp = function (vector2, deltaTime) {
    let nVector = new alt.Vector3(this.x, this.y, this.z);
    nVector.x = this.x + (vector2.x - this.x) * deltaTime
    nVector.y = this.y + (vector2.y - this.y) * deltaTime
    nVector.z = this.z + (vector2.z - this.z) * deltaTime
    return nVector;
}
alt.Vector3.prototype.multiply = function (n) {
    let nVector = new alt.Vector3(this.x, this.y, this.z);
    nVector.x = this.x * n;
    nVector.y = this.y * n;
    nVector.z = this.z * n;
    return nVector;
}
alt.Vector3.prototype.dist = function (to) {
    let a = this.x - to.x;
    let b = this.y - to.y;
    let c = this.z - to.z;
    return Math.sqrt(a * a + b * b + c * c);;
}
alt.Vector3.prototype.dist2d = function (to) {
    let a = this.x - to.x;
    let b = this.y - to.y;
    return Math.sqrt(a * a + b * b);
}
alt.Vector3.prototype.getOffset = function (to) {
    let x = this.x - to.x;
    let y = this.y - to.y;
    let z = this.z - to.z;
    return new alt.Vector3(x, y, z);
}
alt.Vector3.prototype.cross = function (to) {
    let vector = new alt.Vector3(0, 0, 0);
    vector.x = this.y * to.z - this.z * to.y;
    vector.y = this.z * to.x - this.x * to.z;
    vector.z = this.x * to.y - this.y * to.x;
    return vector;
}
alt.Vector3.prototype.normalize = function () {
    let vector = new alt.Vector3(0, 0, 0);
    let mag = Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
    vector.x = this.x / mag;
    vector.y = this.y / mag;
    vector.z = this.z / mag;
    return vector;
}
alt.Vector3.prototype.dot = function (to) {
    return this.x * to.x + this.y * to.y + this.z * to.z;
}
alt.Vector3.prototype.length = function () {
    return Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
}
alt.Vector3.prototype.angle = function (to) {
    return Math.acos(this.normalize().dot(to.normalize()));
}
alt.Vector3.prototype.ground = function () {
    let nVector = new alt.Vector3(this.x, this.y, this.z);
    let z = game.getGroundZFor3dCoord(nVector.x, nVector.y, nVector.z, 0, false)
    let z1 = game.getGroundZFor3dCoord(nVector.x + 0.01, nVector.y + 0.01, nVector.z, 0, false)
    let z2 = game.getGroundZFor3dCoord(nVector.x - 0.01, nVector.y - 0.01, nVector.z, 0, false)
    nVector.z = z;
    if ((z + 0.1 < z1) || (z + 0.1 < z2)) {
        if (z1 < z2) {
            nVector.z = z2;
        } else {
            nVector.z = z1;
        }
    }
    return nVector;
}
alt.Vector3.prototype.ground2 = function (ignore) {
    let nVector = new alt.Vector3(this.x, this.y, this.z);
    let r = game.startShapeTestRay(nVector.add(0, 0, 1), nVector.sub(0, 0, 100), ignore.handle, (1 | 16));
    if ((r) && (r.position)) {
        nVector = mp.vector(r.position);
    }
    return nVector;
}
alt.Vector3.prototype.sub = function (x, y, z) {
    return new alt.Vector3(this.x - x, this.y - y, this.z - z);
};
alt.Vector3.prototype.add = function (x, y, z) {
    return new alt.Vector3(this.x + x, this.y + y, this.z + z);
};
alt.Vector3.prototype.insidePolygon = function (polygon) {
    let x = this.x,
        y = this.y;
    let inside = false;
    for (let i = 0, j = polygon.length - 1; i < polygon.length; j = i++) {
        let xi = polygon[i][0],
            yi = polygon[i][1];
        let xj = polygon[j][0],
            yj = polygon[j][1];
        let intersect = ((yi > y) != (yj > y)) && (x < (xj - xi) * (y - yi) / (yj - yi) + xi);
        if (intersect) inside = !inside;
    }
    return inside;
};
alt.vector = function (vec) {
    return new alt.Vector3(vec.x, vec.y, vec.z);
}
Array.prototype.shuffle = function () {
    let i = this.length;
    while (i) {
        let j = Math.floor(Math.random() * i);
        let t = this[--i];
        this[i] = this[j];
        this[j] = t;
    }
    return this;
}
