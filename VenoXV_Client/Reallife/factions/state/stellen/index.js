import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF } from '../../../../Globals/VnX-Lib';


let stellen_browser = null;

alt.onServer('showStellenWindow', (e) => {
	vnxDestroyCEF("Stellen");
	stellen_browser = vnxCreateCEF("Stellen", "Reallife/factions/state/stellen/main.html");

	alt.setTimeout(() => {
		stellen_browser.emit("Duty:Load", e, alt.Player.local.getSyncedMeta("PLAYER_NAME"));
		stellen_browser.focus();
		ShowCursor(true);
	}, 200);

	stellen_browser.on('ButtonPressed', () => {
		alt.emitServer('Stellen_server_event');
		vnxDestroyCEF("Stellen");
		ShowCursor(false);
	});

	stellen_browser.on('destroyStellenWindow', () => {
		vnxDestroyCEF("Stellen");
		ShowCursor(false);
	});
});
