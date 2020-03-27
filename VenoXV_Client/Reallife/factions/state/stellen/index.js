import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor } from '../../../../Globals/VnX-Lib';


let stellen_browser = null;
	
alt.onServer('showStellenWindow', (e) => {
    stellen_browser = new alt.WebView("http://resource/VenoXV_Client/Reallife/factions/state/stellen/main.html");
	stellen_browser.emit("Duty:Load", e, alt.Player.local.getSyncedMeta("PLAYER_NAME"));
    stellen_browser.focus();
	ShowCursor(true);
	ShowCursor

	stellen_browser.on('ButtonPressed', () => {
		alt.emitServer('Stellen_server_event');
		if (stellen_browser != null) {
            stellen_browser.destroy();
			stellen_browser = null;
            ShowCursor(false);
            return
		}
	});

	stellen_browser.on('destroyStellenWindow', () => {
        if (stellen_browser != null) {
            stellen_browser.destroy();
			stellen_browser = null;
            ShowCursor(false);
            return
		}
	});
});
