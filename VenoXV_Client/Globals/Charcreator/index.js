//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from '../VnX-Lib';

let CharCreator;
let loginCamera;
let charcreatorPedHandle;
let charcreatorModelHash;

alt.onServer('CharCreator:Start', (gender = 1) => {
    if (CharCreator) { return; }
    spawnCreatorPed(gender);
    CharCreator = new alt.WebView("http://resource/VenoXV_Client/Globals/Charcreator/cef/charselector/index.html");
    CharCreator.focus();
    ShowCursor(true);
    alt.setTimeout(() => {
        game.freezeEntityPosition(charcreatorPedHandle, false);
    }, 2500);
    loginCamera = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", 3280, 5220, 26, 0, 0, 240, 50, true, 2);
    alt.setTimeout(() => {
        createLoginCam(402.85, -999, -98.4, 358);
        CharCreator.emit("CEF:Charcreator:openCreator");
        CharCreator.on("Client:Charcreator:UpdateHeadOverlays", (headoverlaysarray) => {
            let headoverlays = JSON.parse(headoverlaysarray);
            game.setPedHeadOverlayColor(charcreatorPedHandle, 1, 1, parseInt(headoverlays[2][1]), 1);
            game.setPedHeadOverlayColor(charcreatorPedHandle, 2, 1, parseInt(headoverlays[2][2]), 1);
            game.setPedHeadOverlayColor(charcreatorPedHandle, 5, 2, parseInt(headoverlays[2][5]), 1);
            game.setPedHeadOverlayColor(charcreatorPedHandle, 8, 2, parseInt(headoverlays[2][8]), 1);
            game.setPedHeadOverlayColor(charcreatorPedHandle, 10, 1, parseInt(headoverlays[2][10]), 1);
            game.setPedEyeColor(charcreatorPedHandle, parseInt(headoverlays[0][14]));
            game.setPedHeadOverlay(charcreatorPedHandle, 0, parseInt(headoverlays[0][0]), parseInt(headoverlays[1][0]));
            game.setPedHeadOverlay(charcreatorPedHandle, 1, parseInt(headoverlays[0][1]), parseFloat(headoverlays[1][1]));
            game.setPedHeadOverlay(charcreatorPedHandle, 2, parseInt(headoverlays[0][2]), parseFloat(headoverlays[1][2]));
            game.setPedHeadOverlay(charcreatorPedHandle, 3, parseInt(headoverlays[0][3]), parseInt(headoverlays[1][3]));
            game.setPedHeadOverlay(charcreatorPedHandle, 4, parseInt(headoverlays[0][4]), parseInt(headoverlays[1][4]));
            game.setPedHeadOverlay(charcreatorPedHandle, 5, parseInt(headoverlays[0][5]), parseInt(headoverlays[1][5]));
            game.setPedHeadOverlay(charcreatorPedHandle, 6, parseInt(headoverlays[0][6]), parseInt(headoverlays[1][6]));
            game.setPedHeadOverlay(charcreatorPedHandle, 7, parseInt(headoverlays[0][7]), parseInt(headoverlays[1][7]));
            game.setPedHeadOverlay(charcreatorPedHandle, 8, parseInt(headoverlays[0][8]), parseInt(headoverlays[1][8]));
            game.setPedHeadOverlay(charcreatorPedHandle, 9, parseInt(headoverlays[0][9]), parseInt(headoverlays[1][9]));
            game.setPedHeadOverlay(charcreatorPedHandle, 10, parseInt(headoverlays[0][10]), parseInt(headoverlays[1][10]));
            game.setPedComponentVariation(charcreatorPedHandle, 2, parseInt(headoverlays[0][13]), 0, 0);
            game.setPedHairColor(charcreatorPedHandle, parseInt(headoverlays[2][13]), parseInt(headoverlays[1][13]));
        });

        CharCreator.on("Client:Charcreator:UpdateFaceFeature", (facefeaturesdata) => {
            let facefeatures = JSON.parse(facefeaturesdata);

            for (let i = 0; i < 20; i++) {
                game.setPedFaceFeature(charcreatorPedHandle, i, facefeatures[i]);
            }
        });

        CharCreator.on("Client:Charcreator:UpdateHeadBlends", (headblendsdata) => {
            let headblends = JSON.parse(headblendsdata);
            game.setPedHeadBlendData(charcreatorPedHandle, headblends[0], headblends[1], 0, headblends[2], headblends[5], 0, headblends[3], headblends[4], 0, 0);
        });

        CharCreator.on("Client:Charcreator:updateCam", (category) => {
            if (category == "face") updateLoginCam(402.8, -997.8, -98.3, 0, 0, 358, 50);
            else updateLoginCam(402.85, -999, -98.4, 0, 0, 358, 50);
        });

        CharCreator.on("Client:Charcreator:CreateCharacter", (facefeaturesarray, headblendsdataarray, headoverlaysarray) => {
            alt.emitServer("CharCreator:Create", facefeaturesarray, headblendsdataarray, headoverlaysarray);
        });
    }, 1500);

});


alt.onServer('CharCreator:Close', () => {
    if (CharCreator) {
        CharCreator.destroy();
        CharCreator = false;
        game.deletePed(charcreatorPedHandle);
    }
});


///////////////////////////////////////////////////////////////////////////////////////////////////////

function setClothes(entity, compId, draw, tex) {
    game.setPedComponentVariation(entity, compId, draw, tex, 0);
}

function updateLoginCam(posX, posY, posZ, rotX, rotY, rotZ, fov) {
    if (loginCamera == null) return;
    game.setCamCoord(loginCamera, posX, posY, posZ);
    game.setCamRot(loginCamera, rotX, rotY, rotZ, 2);
    game.setCamFov(loginCamera, fov);
    game.setCamActive(loginCamera, true);
    game.renderScriptCams(true, false, 0, true, false);
}

function createLoginCam(x, y, z, rot) {
    if (loginCamera != null) game.destroyCam(loginCamera, true);
    loginCamera = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", x, y, z, 0, 0, rot, 50, true, 2);
    game.setCamActive(loginCamera, true);
    game.renderScriptCams(true, false, 0, true, false);
}


function spawnCreatorPed(gender) { //gender (0 - male | 1 - female)
    if (gender == 0) charcreatorModelHash = game.getHashKey('mp_m_freemode_01');
    else if (gender == 1) charcreatorModelHash = game.getHashKey('mp_f_freemode_01');
    else return;
    game.requestModel(charcreatorModelHash);
    let interval = alt.setInterval(() => {
        if (game.hasModelLoaded(charcreatorModelHash)) {
            alt.clearInterval(interval);
            charcreatorPedHandle = game.createPed(4, charcreatorModelHash, 402.778, -996.9758, -100.01465, 0, false, true);
            game.setEntityHeading(charcreatorPedHandle, 180.0);
            game.setEntityInvincible(charcreatorPedHandle, true);
            game.disablePedPainAudio(charcreatorPedHandle, true);
            game.freezeEntityPosition(charcreatorPedHandle, true);
            game.taskSetBlockingOfNonTemporaryEvents(charcreatorPedHandle, true);


            setClothes(charcreatorPedHandle, 11, 15, 0);
            if (gender == 0) setClothes(charcreatorPedHandle, 8, 57, 0);
            else if (gender == 1) setClothes(charcreatorPedHandle, 8, 3, 0);
            setClothes(charcreatorPedHandle, 3, 15, 0);
        }
    }, 0);
}
