//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import alt from 'alt-client';
import * as game from "natives";

import * as Notification from '/VenoXV_Client/Globals/Notification/index.js';
import * as CaseOpening from '/VenoXV_Client/Globals/Premium/Case/index.js';
import * as Chat from '/VenoXV_Client/Globals/Chat/index.js';
import * as ServerLibary from '/VenoXV_Client/Globals/VnX-Lib/index.js';
import * as CameraLib from '/VenoXV_Client/Globals/VnX-Lib/camera.js';
import * as EventLib from '/VenoXV_Client/Globals/VnX-Lib/events.js';
import * as Nametags from '/VenoXV_Client/Globals/Anzeigen/nametags/nametags.js';
import * as CharCreator from '/VenoXV_Client/Globals/Charcreator/index.js';
import * as Tacho from '/VenoXV_Client/Globals/Anzeigen/tacho/index.js';
import * as hud from '/VenoXV_Client/Globals/Anzeigen/hud/index.js';
import * as Sync from '/VenoXV_Client/Globals/Sync/index.js';
import * as Settings from '/VenoXV_Client/Globals/Settings/index.js';
import * as Rathaus from '/VenoXV_Client/Reallife/environment/rathaus/index.js';

import * as serverEvents from '/VenoXV_Client/preload/login/index.js';
import * as PreloadEvent from '/VenoXV_Client/preload/index.js';
import * as TacticsLobby from '/VenoXV_Client/Tactics/Lobby/index.js';
import * as TacticsSpectator from '/VenoXV_Client/Tactics/Spectator/index.js';
import * as jobs from '/VenoXV_Client/Reallife/jobs/allround.js';
import * as environment_house from '/VenoXV_Client/Reallife/environment/house/index.js';
import * as environment_greenzone from '/VenoXV_Client/Reallife/environment/greenzone/index.js';
import * as environment_gas from '/VenoXV_Client/Reallife/environment/tankstellen/index.js';
import * as bank from '/VenoXV_Client/Reallife/bank/index.js';
import * as StateFguns from '/VenoXV_Client/Reallife/factions/state/fguns/index.js';
import * as BadDuty from '/VenoXV_Client/Reallife/factions/bad/duty/index.js';
import * as StateDuty from '/VenoXV_Client/Reallife/factions/state/duty/index.js';
import * as Inventory from '/VenoXV_Client/Reallife/inventory/index.js';
import * as StateStellen from '/VenoXV_Client/Reallife/factions/state/stellen/index.js';
import * as XMenu from '/VenoXV_Client/Reallife/xmenu/index.js';
import * as WeedShop from '/VenoXV_Client/Reallife/environment/weed/index.js';
import * as Death from '/VenoXV_Client/Reallife/environment/death/index.js';
import * as GasStation from '/VenoXV_Client/Reallife/vehicles/gasstation/index.js';
import * as Handy from '/VenoXV_Client/Reallife/handy/index.js';
import * as RaceGM from '/VenoXV_Client/Race/index.js';
import * as ZombiesGM from '/VenoXV_Client/Zombies/KI/index.js';
import * as Ammunation from '/VenoXV_Client/Reallife/ammunation/index.js';
import * as Tuning from '/VenoXV_Client/Reallife/vehicles/tuning/index.js';
import * as SevenTowers from '/VenoXV_Client/SevenTowers/Lobby/index.js';
alt.setStat('stamina', 100);
alt.setStat('strength', 100);
alt.setStat('lung_capacity', 100);
alt.setStat('wheelie_ability', 100);
alt.setStat('flying_ability', 100);
alt.setStat('shooting_ability', 100);
alt.setStat('stealth_ability', 100);

game.pauseClock(true); //Freezes the Current-Ingame Time! 



/*
alt.beginScaleformMovieMethodMinimap('SETUP_HEALTH_ARMOUR');
game.scaleformMovieMethodAddParamInt(3);
game.endScaleformMovieMethod();
*/
game.replaceHudColourWithRgba(142, 0, 200, 255, 255); //Waypoint

// Alle Chars
game.replaceHudColourWithRgba(143, 0, 200, 255, 255);
game.replaceHudColourWithRgba(144, 0, 200, 255, 255);
game.replaceHudColourWithRgba(145, 0, 200, 255, 255);



alt.setTimeout(() => {
    try {
        game.startAudioScene('FBI_HEIST_H5_MUTE_AMBIENCE_SCENE');
        game.startAudioScene('CHARACTER_CHANGE_IN_SKY_SCENE');
        game.requestIpl('chop_props');
        game.requestIpl('FIBlobby');
        game.removeIpl('FIBlobbyfake');
        game.requestIpl('FBI_colPLUG');
        game.requestIpl('FBI_repair');
        game.requestIpl('v_tunnel_hole');
        game.requestIpl('TrevorsMP');
        game.requestIpl('TrevorsTrailer');
        game.requestIpl('TrevorsTrailerTidy');
        game.removeIpl('farm_burnt');
        game.removeIpl('farm_burnt_lod');
        game.removeIpl('farm_burnt_props');
        game.removeIpl('farmint_cap');
        game.removeIpl('farmint_cap_lod');
        game.requestIpl('farm');
        game.requestIpl('farmint');
        game.requestIpl('farm_lod');
        game.requestIpl('farm_props');
        game.requestIpl('facelobby');
        game.removeIpl('CS1_02_cf_offmission');
        game.requestIpl('CS1_02_cf_onmission1');
        game.requestIpl('CS1_02_cf_onmission2');
        game.requestIpl('CS1_02_cf_onmission3');
        game.requestIpl('CS1_02_cf_onmission4');
        game.requestIpl('v_rockclub');
        game.requestIpl('v_janitor');
        game.removeIpl('hei_bi_hw1_13_door');
        game.requestIpl('bkr_bi_hw1_13_int');
        game.requestIpl('ufo');
        game.requestIpl('ufo_lod');
        game.requestIpl('ufo_eye');
        game.removeIpl('v_carshowroom');
        game.removeIpl('shutter_open');
        game.removeIpl('shutter_closed');
        game.removeIpl('shr_int');
        game.requestIpl('csr_afterMission');
        game.requestIpl('v_carshowroom');
        game.requestIpl('shr_int');
        game.requestIpl('shutter_closed');
        game.requestIpl('smboat');
        game.requestIpl('smboat_distantlights');
        game.requestIpl('smboat_lod');
        game.requestIpl('smboat_lodlights');
        game.requestIpl('cargoship');
        game.requestIpl('railing_start');
        game.removeIpl('sp1_10_fake_interior');
        game.removeIpl('sp1_10_fake_interior_lod');
        game.requestIpl('sp1_10_real_interior');
        game.requestIpl('sp1_10_real_interior_lod');
        game.removeIpl('id2_14_during_door');
        game.removeIpl('id2_14_during1');
        game.removeIpl('id2_14_during2');
        game.removeIpl('id2_14_on_fire');
        game.removeIpl('id2_14_post_no_int');
        game.removeIpl('id2_14_pre_no_int');
        game.removeIpl('id2_14_during_door');
        game.requestIpl('id2_14_during1');
        game.removeIpl('Coroner_Int_off');
        game.requestIpl('coronertrash');
        game.requestIpl('Coroner_Int_on');
        game.removeIpl('bh1_16_refurb');
        game.removeIpl('jewel2fake');
        game.removeIpl('bh1_16_doors_shut');
        game.requestIpl('refit_unload');
        game.requestIpl('post_hiest_unload');
        game.requestIpl('Carwash_with_spinners');
        game.requestIpl('KT_CarWash');
        game.requestIpl('ferris_finale_Anim');
        game.removeIpl('ch1_02_closed');
        game.requestIpl('ch1_02_open');
        game.requestIpl('AP1_04_TriAf01');
        game.requestIpl('CS2_06_TriAf02');
        game.requestIpl('CS4_04_TriAf03');
        game.removeIpl('scafstartimap');
        game.requestIpl('scafendimap');
        game.removeIpl('DT1_05_HC_REMOVE');
        game.requestIpl('DT1_05_HC_REQ');
        game.requestIpl('DT1_05_REQUEST');
        game.requestIpl('FINBANK');
        game.removeIpl('DT1_03_Shutter');
        game.removeIpl('DT1_03_Gr_Closed');
        game.requestIpl('golfflags');
        game.requestIpl('airfield');
        game.requestIpl('v_garages');
        game.requestIpl('v_foundry');
        game.requestIpl('hei_yacht_heist');
        game.requestIpl('hei_yacht_heist_Bar');
        game.requestIpl('hei_yacht_heist_Bedrm');
        game.requestIpl('hei_yacht_heist_Bridge');
        game.requestIpl('hei_yacht_heist_DistantLights');
        game.requestIpl('hei_yacht_heist_enginrm');
        game.requestIpl('hei_yacht_heist_LODLights');
        game.requestIpl('hei_yacht_heist_Lounge');
        game.requestIpl('hei_carrier');
        game.requestIpl('hei_Carrier_int1');
        game.requestIpl('hei_Carrier_int2');
        game.requestIpl('hei_Carrier_int3');
        game.requestIpl('hei_Carrier_int4');
        game.requestIpl('hei_Carrier_int5');
        game.requestIpl('hei_Carrier_int6');
        game.requestIpl('hei_carrier_LODLights');
        game.requestIpl('bkr_bi_id1_23_door');
        game.requestIpl('lr_cs6_08_grave_closed');
        game.requestIpl('hei_sm_16_interior_v_bahama_milo_');
        game.requestIpl('CS3_07_MPGates');
        game.requestIpl('cs5_4_trains');
        game.requestIpl('v_lesters');
        game.requestIpl('v_trevors');
        game.requestIpl('v_michael');
        game.requestIpl('v_comedy');
        game.requestIpl('v_cinema');
        game.requestIpl('V_Sweat');
        game.requestIpl('V_35_Fireman');
        game.requestIpl('redCarpet');
        game.requestIpl('triathlon2_VBprops');
        game.requestIpl('jetstenativeurnel');
        game.requestIpl('Jetsteal_ipl_grp1');
        game.requestIpl('v_hospital');
        game.removeIpl('RC12B_Default');
        game.removeIpl('RC12B_Fixed');
        game.requestIpl('RC12B_Destroyed');
        game.requestIpl('RC12B_HospitalInterior');
        game.requestIpl('canyonriver01');
        game.requestIpl('CanyonRvrShallow');
        game.requestIpl('CS3_05_water_grp1');
    }
    catch{ }
}, 1250);
