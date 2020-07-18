//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../VnX-Lib/index';


let CaseOpeningWindow;

alt.onServer('CaseOpening:Show', () => {
    if (CaseOpeningWindow) { vnxDestroyCEF('CaseWindow'); }
    CaseOpeningWindow = vnxCreateCEF('CaseWindow', 'Globals/Premium/Case/index.html');
    ShowCursor(true);
    CaseOpeningWindow.focus();
    CaseOpeningWindow.on('CaseOpening:Close', () => {
        vnxDestroyCEF('CaseWindow');
        CaseOpeningWindow = null;
    });
    CaseOpeningWindow.on('CaseOpening:Winning', (win) => {
        alt.log('Dein Gewinn : ' + win);
    });
    alt.log('CaseOpening Window Loaded!');
});

alt.onServer('CaseOpening:LoadChances', (json) => {
    if (!CaseOpeningWindow) { return; }
    alt.setTimeout(() => {
        alt.log(json);
        CaseOpeningWindow.emit('CaseOpening:LoadChances', json);
    }, 2000);
});

alt.onServer('CaseOpening:LoadCase', (json) => {
    if (!CaseOpeningWindow) { return; }
    alt.setTimeout(() => {
        alt.log(json);
        CaseOpeningWindow.emit('CaseOpening:LoadCases', json);
    }, 2000);
});