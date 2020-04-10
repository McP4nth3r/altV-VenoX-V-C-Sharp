//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as native from "natives"

let camera = null;
let interpolCam = null;

export function interpolateCamera(pos1X, pos1Y, pos1Z, rot1, fov, pos2X, pos2Y, pos2Z, rot2, fov2, duration) {

    if (camera != null || interpolCam != null) {
        native.renderScriptCams(false, false, 0, true, false);
        native.destroyCam(camera, true);
        native.destroyCam(interpolCam, true);
        native.destroyAllCams(true);
        camera = null;
        interpolCam = null;
        native.setFollowPedCamViewMode(1);
        native.clearFocus();
    }

    native.setHdArea(pos1X, pos1Y, pos1Z, 30);

    camera = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos1X, pos1Y, pos1Z, -fov, 0, rot1, 80.0, false, 2);
    interpolCam = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos2X, pos2Y, pos2Z, -fov2, 0, rot2, 30.0, false, 2);
    native.setCamActive(camera, true);
    //native.setCamActive(interpolCam, true);
    native.setCamActiveWithInterp(interpolCam, camera, duration, 1, 1);
    native.renderScriptCams(true, false, 0, false, false);
    //alt.log(pos1X + " | " + pos1Y + " | " + pos1Z + " | " + rot1 + " | " + fov + " | " + pos2X + " | " + pos2Y + " | " + pos2Z + " | " + rot2 + " | " + fov2 + " | " + duration);
}

alt.onServer('destroyCamera', () => {
    native.renderScriptCams(false, false, 0, true, false);
    native.destroyCam(camera, true);
    native.destroyCam(interpolCam, true);
    native.destroyAllCams(true);
    camera = null;
    interpolCam = null;
    native.setFollowPedCamViewMode(1);
    native.clearFocus();
});

export function destroyCamera() {
    if (camera != null || interpolCam != null) {
        native.renderScriptCams(false, false, 0, true, false);
        native.destroyCam(camera, true);
        native.destroyCam(interpolCam, true);
        native.destroyAllCams(true);
        camera = null;
        interpolCam = null;
        native.setFollowPedCamViewMode(1);
        native.clearFocus();
    }
}


alt.onServer('createCamera', () => {
    if (camera != null || interpolCam != null) {
        destroyCamera;
    }

    native.setFocusPosAndVel(pos1X, pos1Y, pos1Z, 0.0, 0.0, 0.0);
    native.setHdArea(pos1X, pos1Y, pos1Z, 30)

    camera = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos1X, pos1Y, pos1Z, rot1, fov, 0, 2, false, 0);
    native.setCamActive(camera, true);
    native.renderScriptCams(true, false, 0, false, false);
});
