
//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../../Globals/VnX-Lib';

let vehcatalog = {};
let vehcounter = 0;
let VehCatalogBrowser;
let ExecutedFill = false;
alt.onServer('VehicleCatalog:Fill', (row, name, cost, max) => {
    if (vehcounter >= max) {
        if (!ExecutedFill) { FillWindowWithStuff(); ExecutedFill = true; return; }
    }
    vehcatalog[vehcounter] = {
        row: row,
        name: name,
        cost: cost
    };
    vehcounter++;
});

function FillWindowWithStuff() {
    if (!VehCatalogBrowser) return;
    if (vehcounter > 0) {
        alt.setTimeout(() => {
            VehCatalogBrowser.emit('VehCatalog:Fill', vehcatalog);
            alt.log('Called fill function');
        }, 500);
    }
}


alt.onServer('VehicleCatalog:Show', () => {
    if (VehCatalogBrowser) return;
    VehCatalogBrowser = vnxCreateCEF('VehCatalog', 'Reallife/vehicles/catalog/main.html', "Reallife");
    VehCatalogBrowser.focus();
    ShowCursor(true);
    VehCatalogBrowser.on('VehCatalog:Destroy', () => { VehCatalogBrowser.unfocus(); vnxDestroyCEF('VehCatalog'); ShowCursor(false); VehCatalogBrowser = null; ExecutedFill = false; });
    VehCatalogBrowser.on('VehCatalog:SelectVehicle', (Name) => {
        VehCatalogBrowser.unfocus();
        vnxDestroyCEF('VehCatalog');
        ShowCursor(false);
        VehCatalogBrowser = null;
        ExecutedFill = false;
        alt.emit('VehicleCatalog:PreviewVehicle', Name);
    });
});

