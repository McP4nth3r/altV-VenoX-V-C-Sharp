//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from './index';

let executedcmd = false;



const CamerasManagerInfo = {
    gameplayCamera: null,
    activeCamera: null,
    interpCamera: null,
    interpActive: false,
    _events: new Map(),
    cameras: new Map([
        ['testCamera', game.createCamWithParams("default", 0, 0, 0, 0, 0, 0, 50.0, false, 0)],
    ])
};

export function OnCameraEveryTick() {
    if (CamerasManagerInfo.interpCamera && CamerasManager.doesExist(CamerasManagerInfo.interpCamera) && !game.isCamInterpolating(CamerasManagerInfo.activeCamera)) {
        CamerasManager.fireEvent('stopInterp', CamerasManagerInfo.activeCamera);

        game.setCamActive(CamerasManagerInfo.interpCamera, false);
        game.destroyCam(CamerasManagerInfo.interpCamera);
        CamerasManagerInfo.interpCamera = null;
    }
}



export class CamerasManager {

    static on(eventName, eventFunction) {
        if (CamerasManagerInfo._events.has(eventName)) {
            const event = CamerasManagerInfo._events.get(eventName);

            if (!event.has(eventFunction)) {
                event.add(eventFunction);
            }
        } else {
            CamerasManagerInfo._events.set(eventName, new Set([eventFunction]));
        }
    }

    static fireEvent(eventName, ...args) {
        if (CamerasManagerInfo._events.has(eventName)) {
            const event = CamerasManagerInfo._events.get(eventName);

            event.forEach(eventFunction => {
                eventFunction(...args);
            });
        }
    }

    static getCamera(name) {

        const camera = CamerasManagerInfo.cameras.get(name);

        if (typeof camera.setActiveCamera !== 'function') {
            //cameraSerialize(camera);
        }

        return camera;
    }

    static setCamera(name, camera) {
        CamerasManagerInfo.cameras.set(name, camera);
    }

    static hasCamera(name) {
        return CamerasManagerInfo.cameras.has(name);
    }

    static destroyCamera(camera) {
        if (this.doesExist(camera)) {
            if (camera === this.activeCamera) {
                game.setCamActive(this.activeCamera, false);
            }
            camera.destroy();
        }
    }

    static createCamera(name, type, position, rotation, fov) {
        const cam = game.createCamWithParams("default", position.x, position.y, position.z, rotation.x, rotation.y, rotation.z, fov);
        //cameraSerialize(cam);
        CamerasManagerInfo.cameras.set(name, cam);
        return cam;
    }

    static setActiveCamera(activeCamera, toggle) {
        if (!toggle) {
            if (this.doesExist(CamerasManagerInfo.activeCamera)) {
                CamerasManagerInfo.activeCamera = null;
                game.setCamActive(activeCamera, false);
                game.renderScriptCams(false, false, 0, false, false);
            }

            if (this.doesExist(CamerasManagerInfo.interpCamera)) {
                game.setCamActive(CamerasManagerInfo.interpCamera, false);
                game.destroyCam(CamerasManagerInfo.interpCamera);
                CamerasManagerInfo.interpCamera = null;
            }

        } else {
            if (this.doesExist(CamerasManagerInfo.activeCamera)) {
                game.setCamActive(CamerasManagerInfo.activeCamera, false);
            }
            CamerasManagerInfo.activeCamera = activeCamera;
            game.setCamActive(activeCamera, true);
            game.renderScriptCams(true, false, 0, false, false);
        }
    }

    static setActiveCameraWithInterp(activeCamera, position, rotation, duration, easeLocation, easeRotation) {

        if (this.doesExist(CamerasManagerInfo.activeCamera)) {
            game.setCamActive(CamerasManagerInfo.activeCamera, false);
        }

        if (this.doesExist(CamerasManagerInfo.interpCamera)) {

            CamerasManager.fireEvent('stopInterp', CamerasManagerInfo.interpCamera);

            game.setCamActive(CamerasManagerInfo.interpCamera, false);
            game.destroyCam(CamerasManagerInfo.interpCamera, true);
            CamerasManagerInfo.interpCamera = null;
        }
        const interpCamera = game.createCamWithParams('default', game.getCamCoord(activeCamera), game.getCamRot(activeCamera, 2), game.getCamFov(activeCamera));
        game.setCamCoord(activeCamera, position.x, position.y, position.z);
        game.setCamRot(activeCamera, rotation.x, rotation.y, rotation.z, 2);
        game.stopCamPointing(activeCamera);

        CamerasManagerInfo.activeCamera = activeCamera;
        CamerasManagerInfo.interpCamera = interpCamera;
        game.setCamActiveWithInterp(activeCamera.scriptID, interpCamera.scriptID, duration, easeLocation, easeRotation);
        game.renderScriptCams(true, false, 0, false, false);

        CamerasManager.fireEvent('startInterp', CamerasManagerInfo.interpCamera);
        alt.log("Executed!");
    }

    static doesExist(camera) {
        return game.doesCamExist(camera);
    }

    static get activeCamera() {
        return CamerasManagerInfo.activeCamera;
    }

    static get gameplayCam() {
        if (!CamerasManagerInfo.gameplayCamera) {
            CamerasManagerInfo.gameplayCamera = game.createCameraWithParams("default", game.getGameplayCamCoord().x, game.getGameplayCamCoord().y, game.getGameplayCamCoord().z, game.getGameplayCamRot(2).x, game.getGameplayCamRot(2).y, game.getGameplayCamRot(2).z, game.getGameplayCamFov(), false, 0);
        }
        return CamerasManagerInfo.gameplayCamera;
    }
}
/*
const proxyscriptIDr = {
    get: (target, name, receiver) => typeof CamerasManager[name] !== 'undefined' ? CamerasManager[name] : CamerasManagerInfo.cameras.get(name)
};

exports = new Proxy({}, proxyscriptIDr);*/
