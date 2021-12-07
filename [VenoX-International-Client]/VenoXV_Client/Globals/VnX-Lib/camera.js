//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as native from "natives"

let camera = null;
let interpolCam = null;

export function interpolateCamera(pos1X, pos1Y, pos1Z, rot1X, rot1Y, rot1Z, fov, pos2X, pos2Y, pos2Z, rot2X, rot2Y, rot2Z, fov2, duration) {
    try {
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

        camera = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos1X, pos1Y, pos1Z, rot1X, rot1Y, rot1Z, fov, false, 2);
        interpolCam = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos2X, pos2Y, pos2Z, rot2X, rot2Y, rot2Z, fov2, false, 2);
        native.setCamActive(camera, true);
        //native.setCamActive(interpolCam, true);
        native.setCamActiveWithInterp(interpolCam, camera, duration, 1, 1);
        native.renderScriptCams(true, false, 0, false, false);
    }
    catch { }
    //alt.log(pos1X + " | " + pos1Y + " | " + pos1Z + " | " + rot1X + " | " + rot1Y + " | " + rot1Z + " | " + fov + " | " + pos2X + " | " + pos2Y + " | " + pos2Z + " | " + rot2X + " | " + rot2Y + " | " + rot2Z + " | " + fov2 + " | " + duration);
}

alt.onServer('destroyCamera', () => {
    try {
        native.renderScriptCams(false, false, 0, true, false);
        native.destroyCam(camera, true);
        native.destroyCam(interpolCam, true);
        native.destroyAllCams(true);
        camera = null;
        interpolCam = null;
        native.setFollowPedCamViewMode(1);
        native.clearFocus();
    }
    catch { }
});

export function destroyCamera() {
    try {
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
    catch { }
}


alt.onServer('createCamera', () => {
    try {
        if (camera != null || interpolCam != null) {
            destroyCamera;
        }

        native.setFocusPosAndVel(pos1X, pos1Y, pos1Z, 0.0, 0.0, 0.0);
        native.setHdArea(pos1X, pos1Y, pos1Z, 30)

        camera = native.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", pos1X, pos1Y, pos1Z, rot1, fov, 0, 2, false, 0);
        native.setCamActive(camera, true);
        native.renderScriptCams(true, false, 0, false, false);
    }
    catch { }
});


/*
 * Copyright (C) 2020 Jovan Ivanovic (Dzeknjak) - All Rights Reserved
 * -----------------------------------------------------------------------------------
 * You may use, distribute and modify this given the written permission by the author.
 */
export default class Camera {
    /**
     * Create a new camera
     *
     * @param {alt.Vector3} position Initial position of the camera
     * @param {alt.Vector3} rotation Initial rotation of the camera
     * @param {number} fov Initial field of view of the camera
     */
    constructor(position, rotation, fov) {
        this._position = position;
        this._rotation = rotation;
        this._fov = fov;

        this.scriptID = native.createCamWithParams(
            'DEFAULT_SCRIPTED_CAMERA',
            this._position.x,
            this._position.y,
            this._position.z,
            this._rotation.x,
            this._rotation.y,
            this._rotation.z,
            this._fov,
            true,
            0
        );

        this.unrender();
        alt.log(`--> Created camera: ${this.scriptID}`);
    }

    /**
     * @type {number}
     */
    get fov() {
        return this._fov;
    }

    set fov(value) {
        this._fov = value;
        native.setCamFov(this.scriptID, this._fov);

        if (this.isRendering) this.render();
    }

    /**
     * @type {alt.Vector3}
     */
    get position() {
        return this._position;
    }

    set position(position) {
        this._position = position;
        native.setCamCoord(
            this.scriptID,
            this._position.x,
            this._position.y,
            this._position.z
        );

        if (this.isRendering) this.render();
    }

    /**
     * @type {alt.Vector3}
     */
    get rotation() {
        return this._rotation;
    }

    set rotation(rotation) {
        this._rotation = rotation;
        native.setCamRot(
            this.scriptID,
            this._rotation.x,
            this._rotation.y,
            this._rotation.z,
            0
        );

        if (this.isRendering) this.render();
    }

    /**
     * Stops rendering the camera on the screen
     */
    unrender() {
        native.renderScriptCams(false, false, 0, false, false);
        native.setCamActive(this.scriptID, false);

        this.isRendering = false;
    }

    /**
     * Renders the camera view on the screen
     */
    render() {
        native.setCamActive(this.scriptID, true);
        native.renderScriptCams(true, false, 0, true, false);

        this.isRendering = true;
    }

    /**
     * Destroys the camera
     */
    destroy() {
        native.destroyCam(this.scriptID, false);
        this.unrender();

        alt.log(`--> Destroyed camera: ${this.scriptID}`);
    }

    /**
     * Rotates camera so it points straight to a ped's specific bone
     *
     * @param {number} entity Ped handle that owns the bone
     * @param {number} bone Bone index
     * @param {number} xOffset Position offset of the camera X
     * @param {number} yOffset Position offset of the camera Y
     * @param {number} zOffset Position offset of the camera Z
     */
    pointAtBone(entity, bone, xOffset, yOffset, zOffset) {
        native.pointCamAtPedBone(
            this.scriptID,
            entity,
            bone,
            xOffset,
            yOffset,
            zOffset,
            false
        );

        if (this.isRendering) this.render();
    }

    /**
     * Rotates camera so it points straight to a position
     *
     * @param {alt.Vector3} position Vector3 to where to point the camera at
     */
    pointAtCoord(position) {
        native.pointCamAtCoord(this.scriptID, position.x, position.y, position.z);

        if (this.isRendering) this.render();
    }

    /**
     * Rotates camera so it points to an entity
     *
     * @param {number} entity Entity to point the camera to
     * @param {alt.Vector3} offset Offset of the point
     */
    pointAtEntity(entity, offset) {
        native.pointCamAtEntity(
            this.scriptID,
            entity,
            offset.x,
            offset.y,
            offset.z,
            true
        );

        if (this.isRendering) this.render();
    }

    /**
     * Attaches the camera to an entity with an offset
     *
     * @param {number} entity Entity to attach the camera to
     * @param {alt.Vector3} offset Camera's position offset
     * @param {boolean} relative Is the camera relative to the entity
     */
    attach(entity, offset, relative = true) {
        native.attachCamToEntity(
            this.scriptID,
            entity,
            offset.x,
            offset.y,
            offset.z,
            relative
        );

        if (this.isRendering) this.render();
    }

    /**
     * Switches from this camera to another with interpolation if duration is set
     *
     * @param {Camera} camera Instance of a Camera class to switch to
     * @param {number} duration How long should transition take in miliseconds
     */
    switchTo(camera, duration = 0) {
        return new Promise((resolve) => {
            native.setCamActiveWithInterp(camera.scriptID, this.scriptID, duration, 1, 1);
            alt.setTimeout(() => {
                camera.render();
                resolve(camera);
            }, duration);
        });
    }
}
