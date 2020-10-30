//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import { vnxCreateCEF, ShowCursor, vnxDestroyCEF } from '../../../Globals/VnX-Lib';

let FactionStuffBrowser = null;
alt.onServer('showFactionStuff', (fraktionsnamen, koks, mats, money, weed) => {
	if (FactionStuffBrowser) return;
	FactionStuffBrowser = vnxCreateCEF('FraktionskassenWindow', 'Reallife/factions/fkasse/main.html', "Reallife");
	FactionStuffBrowser.focus();
	ShowCursor(true);
	alt.setTimeout(() => {
		FactionStuffBrowser.emit('FactionStuff:Load', fraktionsnamen, koks, mats, money, weed);
	}, 500);
	FactionStuffBrowser.on('destroyFkassenWindow', () => {
		ShowCursor(false);
		FactionStuffBrowser.unfocus();
		FactionStuffBrowser = null;
		vnxDestroyCEF('FraktionskassenWindow');
	});

	FactionStuffBrowser.on('requestFkasseGive', (money, mats, koks, weed) => {
		alt.setTimeout(function () {
			alt.emitServer('StoreFactionDatasServer', parseInt(money), parseInt(mats), parseInt(koks), parseInt(weed), "StoreDatas");
		}, 100);
	});
	FactionStuffBrowser.on('requestFkasseTake', (money, mats, koks, weed) => {
		alt.setTimeout(function () {
			alt.emitServer('StoreFactionDatasServer', parseInt(money), parseInt(mats), parseInt(koks), parseInt(weed), "TakeDatas");
		}, 100);
	});
});




