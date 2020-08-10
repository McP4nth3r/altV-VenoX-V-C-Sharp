
//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../../Globals/VnX-Lib';

let vehcatalog = [];
let vehcounter = 0;
let VehCatalogBrowser;
alt.onServer('VehicleCatalog:Fill', (row, name, cost, max) => {
    if (vehcounter == max) { FillWindowWithStuff(); return; }
    vehcatalog[vehcounter++] = {
        row: row,
        name: name,
        cost: cost
    };
});

function FillWindowWithStuff() {
    if (!VehCatalogBrowser) { return; }
    if (vehcatalog.length > 0) {
        alt.setTimeout(() => {
            VehCatalogBrowser.emit('VehCatalog:Fill', vehcatalog);
        }, 500);
    }
}


alt.onServer('VehicleCatalog:Show', () => {
    if (VehCatalogBrowser) { return; }
    VehCatalogBrowser = vnxCreateCEF('VehCatalog', 'Reallife/vehicles/catalog/main.html');
    ShowCursor(true);
    VehCatalogBrowser.focus();
    VehCatalogBrowser.on('VehCatalog:Destroy', () => { VehCatalogBrowser.unfocus(); vnxDestroyCEF('VehCatalog'); ShowCursor(false); VehCatalogBrowser = null; });
    FillWindowWithStuff();
});