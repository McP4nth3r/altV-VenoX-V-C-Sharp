//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


import * as alt from 'alt-client';
import * as game from 'natives';
import {
    ShowCursor,
    vnxCreateCEF,
    vnxDestroyCEF
} from '../../../Globals/VnX-Lib';

let previewVehicle;
let previewCamera;
let previewBrowser;

async function loadModel(dict) {
	dict = parseInt(dict);
    return new Promise(resolve => {
        if (game.hasModelLoaded(dict)) return resolve(true);
        game.requestModel(dict);
        let inter = alt.setInterval(() => {
            if (game.hasModelLoaded(dict)) {
                alt.clearInterval(inter);
                return resolve(true);
            }
        }, 5);
    });
}

alt.on('VehicleCatalog:PreviewVehicle', async (Model) => {
    if (previewVehicle) previewVehicle.destroy();
    let vehicleHash = parseInt(game.getHashKey(Model));
    let res = loadModel(vehicleHash);
    res.then(() => {
        if (!game.hasModelLoaded(vehicleHash)) game.Lo
        previewVehicle = game.createVehicle(vehicleHash, -31.98111, -1090.434, 26.42225, 180.0, false, false, false);
        previewCamera = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", -37.83527, -1088.096, 27.92234, -20.0, 0.0, 250.0, 90, false, 2);
        game.setCamActive(previewCamera, true);
        game.renderScriptCams(true, false, 0, true, false);
        game.displayHud(false);
        game.displayRadar(false);

        previewBrowser = vnxCreateCEF('Reallife-PreviewBrowser', 'Reallife/vehicles/preview/index.html');
        previewBrowser.focus();
        ShowCursor(true);
        previewBrowser.on('previewVehicleChangeColor', (color, colorMain) => {
            if (colorMain) {
                //previewVehicle.setCustomPrimaryColour(hexToRgb(color).r, hexToRgb(color).g, hexToRgb(color).b);
                game.setVehicleCustomPrimaryColour(previewVehicle, hexToRgb(color).r, hexToRgb(color).g, hexToRgb(color).b);
            } else {
                //previewVehicle.setCustomSecondaryColour(hexToRgb(color).r, hexToRgb(color).g, hexToRgb(color).b);
                game.setVehicleCustomSecondaryColour(previewVehicle, hexToRgb(color).r, hexToRgb(color).g, hexToRgb(color).b);
            }
        });

        previewBrowser.on('rotatePreviewVehicle', (rotation) => {
            //previewVehicle.setHeading(rotation);
            game.setEntityHeading(previewVehicle, rotation);
        });

        previewBrowser.on('purchaseVehicle', () => {
            let firstColorObject = game.getVehicleCustomPrimaryColour(previewVehicle, 0, 0, 0);
            let secondColorObject = game.getVehicleCustomSecondaryColour(previewVehicle, 0, 0, 0);
            let firstColor = firstColorObject[1] + ',' + firstColorObject[2] + ',' + firstColorObject[3];
            let secondColor = secondColorObject[1] + ',' + secondColorObject[2] + ',' + secondColorObject[3];
            alt.emitServer('CarShop:BuyVehicle', Model, firstColor, secondColor);
            ClosePreview();
        });


        previewBrowser.on('testVehicle', () => {
            let firstColorObject = game.getVehicleCustomPrimaryColour(previewVehicle, 0, 0, 0);
            let secondColorObject = game.getVehicleCustomSecondaryColour(previewVehicle, 0, 0, 0);

            let firstColor = firstColorObject[1] + ',' + firstColorObject[2] + ',' + firstColorObject[3];
            let secondColor = secondColorObject[1] + ',' + secondColorObject[2] + ',' + secondColorObject[3];
            alt.emitServer('CarShop:TestVehicle', Model, firstColor, secondColor);
            ClosePreview();
        });
        previewBrowser.on('VehiclePreview:Close', () => {
            ClosePreview();
        });
    });
});

// assets 
function hexToRgb(hex) {
    var shorthandRegex = /^#?([a-f\d])([a-f\d])([a-f\d])$/i;
    hex = hex.replace(shorthandRegex, function (m, r, g, b) {
        return r + r + g + g + b + b;
    });

    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}

function ClosePreview() {
    vnxDestroyCEF('Reallife-PreviewBrowser');
    previewBrowser = null;
    ShowCursor(false);

    game.deleteVehicle(previewVehicle);
    previewVehicle = null;

    game.displayHud(true);
    game.displayRadar(true);

    game.setCamActive(previewCamera, true);
    game.renderScriptCams(false, false, 0, true, false);
    previewCamera.destroy();
    previewCamera = null;
}