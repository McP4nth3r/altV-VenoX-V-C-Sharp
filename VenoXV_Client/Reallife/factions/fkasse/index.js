//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF, ShowCursor, vnxDestroyCEF } from '../../../Globals/VnX-Lib';

let FactionStuffBrowser = null;
alt.onServer('showFactionStuff', (fraktionsnamen, koks, mats, money, weed) => {
	if (FactionStuffBrowser) { return; }
	FactionStuffBrowser = vnxCreateCEF('FraktionskassenWindow', 'Reallife/factions/fkasse/main.html');
	FactionStuffBrowser.focus();
	ShowCursor(true);
	alt.setTimeout(() => {
		FactionStuffBrowser.emit('FactionStuff:Load', fraktionsnamen, koks, mats, money, weed);
	}, 500);
	FactionStuffBrowser.on('destroyFkassenWindow', () => {
		ShowCursor(false);
		FactionStuffBrowser.unfocus();
		vnxDestroyCEF('FraktionskassenWindow');
	});

	FactionStuffBrowser.on('requestFkasseGive', (money, mats, koks, weed) => {
		alt.setTimeout(function () {
			alt.emitServer('StoreFactionDatasServer', money, mats, koks, weed, "StoreDatas");
		}, 100);
	});
	FactionStuffBrowser.on('requestFkasseTake', (money, mats, koks, weed) => {
		alt.setTimeout(function () {
			alt.emitServer('StoreFactionDatasServer', money, mats, koks, weed, "TakeDatas");
		}, 100);
	});
});




