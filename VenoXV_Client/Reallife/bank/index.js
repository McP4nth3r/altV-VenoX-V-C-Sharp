import * as alt from 'alt-client';
import * as game from "natives";
import { ShowCursor, vnxCreateCEF, vnxDestroyCEF, CreateBlip } from '../../Globals/VnX-Lib';

let ATM_Blips = {};
let ATM_Tabelle = {};
let ATM_BROWSER = null;
alt.onServer('showATM', (k, k1, k2, k3, u1, u2, u3) => {
	try {
		game.freezeEntityPosition(alt.Player.local.scriptID, true);
		ATM_BROWSER = vnxCreateCEF("ATM", "Reallife/bank/main.html", "Reallife");
		alt.setTimeout(() => {
			ATM_BROWSER.emit("Bank:Load", k, k1, k2, k3, u1, u2, u3);
			ATM_BROWSER.focus();
		}, 200);
		ATM_BROWSER.on('closeATM', () => {
			vnxDestroyCEF("ATM");
			ShowCursor(false);
			game.freezeEntityPosition(alt.Player.local.scriptID, false);
		});

		ATM_BROWSER.on('atm_money_button_triggered', (btn, e) => {
			alt.emitServer('ATM_MONEY_BUTTON_TRIGGER', btn, e);
		});

		ATM_BROWSER.on('atm_send_money', (e, v, v2) => {
			alt.emitServer('ATM_MONEY_SEND_TO', e, v, v2);
		});
		ATM_BROWSER.on('atm_load_money_storage', () => {
			let money = alt.Player.local.getSyncedMeta("PLAYER_BANK");
			ATM_BROWSER.emit("Bank:LoadMoneyStorage", money)
		});
		ShowCursor(true);
	}
	catch { }
});





var ATMCount = 0;

ATM_Tabelle[ATMCount] = new alt.Vector3(-846.6537, -341.509, 37.6685); // 1
ATM_Tabelle[ATMCount++] = new alt.Vector3(1153.747, -326.7634, 69.2050); // 2
ATM_Tabelle[ATMCount++] = new alt.Vector3(285.6829, 143.4019, 104.169); //3
ATM_Tabelle[ATMCount++] = new alt.Vector3(-847.204, -340.4291, 37.6793); // 4
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1410.736, -98.9279, 51.397); //5
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1410.183, -100.6454, 51.3965); //6
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2295.853, 357.9348, 173.6014); //7
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2295.069, 356.2556, 173.6014);//8
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2294.3, 354.6056, 173.6014); //9
ATM_Tabelle[ATMCount++] = new alt.Vector3(-282.7141, 6226.43, 30.4965); //10
ATM_Tabelle[ATMCount++] = new alt.Vector3(-386.4596, 6046.411, 30.474); // 11
ATM_Tabelle[ATMCount++] = new alt.Vector3(24.5933, -945.543, 28.333); // 12
ATM_Tabelle[ATMCount++] = new alt.Vector3(5.686, -919.9551, 28.4809); //13
ATM_Tabelle[ATMCount++] = new alt.Vector3(296.1756, -896.2318, 28.2901); //14
ATM_Tabelle[ATMCount++] = new alt.Vector3(296.8775, -894.3196, 28.2615); //15
ATM_Tabelle[ATMCount++] = new alt.Vector3(-846.6537, -341.509, 37.6685); //16
ATM_Tabelle[ATMCount++] = new alt.Vector3(-847.204, -340.4291, 37.6793); //17
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1410.736, -98.9279, 51.397); //18
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1410.183, -100.6454, 51.3965); //19
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2295.853, 357.9348, 173.6014); //20
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2295.069, 356.2556, 173.6014); //21
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2294.3, 354.6056, 173.6014); //22
ATM_Tabelle[ATMCount++] = new alt.Vector3(-282.7141, 6226.43, 30.4965); //23
ATM_Tabelle[ATMCount++] = new alt.Vector3(-386.4596, 6046.411, 30.474); //24
ATM_Tabelle[ATMCount++] = new alt.Vector3(24.5933, -945.543, 28.333); //25
ATM_Tabelle[ATMCount++] = new alt.Vector3(5.686, -919.9551, 28.4809); //26
ATM_Tabelle[ATMCount++] = new alt.Vector3(296.1756, -896.2318, 28.2901); //27
ATM_Tabelle[ATMCount++] = new alt.Vector3(296.8775, -894.3196, 28.2615);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-712.9357, -818.4827, 22.7407);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-710.0828, -818.4756, 22.7363);
ATM_Tabelle[ATMCount++] = new alt.Vector3(289.53, -1256.788, 28.4406);
ATM_Tabelle[ATMCount++] = new alt.Vector3(289.2679, -1282.32, 28.6552);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1569.84, -547.0309, 33.9322);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1570.765, -547.7035, 33.9322);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1305.708, -706.6881, 24.3145);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2071.928, -317.2862, 12.3181);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-821.8936, -1081.555, 10.1366);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-712.9357, -818.4827, 22.7407);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-710.0828, -818.4756, 22.7363);
ATM_Tabelle[ATMCount++] = new alt.Vector3(289.53, -1256.788, 28.4406);
ATM_Tabelle[ATMCount++] = new alt.Vector3(289.2679, -1282.32, 28.6552);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1569.84, -547.0309, 33.9322);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1570.765, -547.7035, 33.9322);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1305.708, -706.6881, 24.3145);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2071.928, -317.2862, 12.3181);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-821.8936, -1081.555, 10.1366);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-867.013, -187.9928, 36.8822);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-867.9745, -186.3419, 36.8822);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-3043.835, 594.1639, 6.7328);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-3241.455, 997.9085, 11.5484);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-204.0193, -861.0091, 29.2713);
ATM_Tabelle[ATMCount++] = new alt.Vector3(118.6416, -883.5695, 30.1395);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-256.6386, -715.8898, 32.7883);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-259.2767, -723.2652, 32.7015);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-254.5219, -692.8869, 32.5783);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-867.013, -187.9928, 36.8822);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-867.9745, -186.3419, 36.8822);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-3043.835, 594.1639, 6.7328);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-3241.455, 997.9085, 11.5484);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-204.0193, -861.0091, 29.2713);
ATM_Tabelle[ATMCount++] = new alt.Vector3(118.6416, -883.5695, 30.1395);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-256.6386, -715.8898, 32.7883);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-259.2767, -723.2652, 32.7015);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-254.5219, -692.8869, 32.5783);
ATM_Tabelle[ATMCount++] = new alt.Vector3(89.8134, 2.8803, 67.3521);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-617.8035, -708.8591, 29.0432);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-617.8035, -706.8521, 29.0432);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-614.5187, -705.5981, 30.224);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-611.8581, -705.5981, 30.224);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-537.8052, -854.9357, 28.2754);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-526.7791, -1223.374, 17.4527);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1315.416, -834.431, 15.9523);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1314.466, -835.6913, 15.9523);
ATM_Tabelle[ATMCount++] = new alt.Vector3(89.8134, 2.8803, 67.3521);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-617.8035, -708.8591, 29.0432);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-617.8035, -706.8521, 29.0432);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-614.5187, -705.5981, 30.224);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-611.8581, -705.5981, 30.224);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-537.8052, -854.9357, 28.2754);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-526.7791, -1223.374, 17.4527);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1315.416, -834.431, 15.9523);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1314.466, -835.6913, 15.9523);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1205.378, -326.5286, 36.851);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1206.142, -325.0316, 36.851);
ATM_Tabelle[ATMCount++] = new alt.Vector3(147.4731, -1036.218, 28.3678);
ATM_Tabelle[ATMCount++] = new alt.Vector3(145.8392, -1035.625, 28.3678);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1205.378, -326.5286, 36.851);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1206.142, -325.0316, 36.851);
ATM_Tabelle[ATMCount++] = new alt.Vector3(147.4731, -1036.218, 28.3678);
ATM_Tabelle[ATMCount++] = new alt.Vector3(145.8392, -1035.625, 28.3678);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1109.797, -1690.808, 4.375014);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-721.1284, -415.5296, 34.98175);
ATM_Tabelle[ATMCount++] = new alt.Vector3(130.1186, -1292.669, 29.26953);
ATM_Tabelle[ATMCount++] = new alt.Vector3(129.7023, -1291.954, 29.26953);
ATM_Tabelle[ATMCount++] = new alt.Vector3(129.2096, -1291.14, 29.26953);
ATM_Tabelle[ATMCount++] = new alt.Vector3(288.8256, -1282.364, 29.64128);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1077.768, -776.4548, 58.23997);
ATM_Tabelle[ATMCount++] = new alt.Vector3(527.2687, -160.7156, 57.08937);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-57.64693, -92.66162, 57.77995);
ATM_Tabelle[ATMCount++] = new alt.Vector3(527.3583, -160.6381, 57.0933);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-165.1658, 234.8314, 94.92194);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-165.1503, 232.7887, 94.92194);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1091.462, 2708.637, 18.95291);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1172.492, 2702.492, 38.17477);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1171.537, 2702.492, 38.17542);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1822.637, 3683.131, 34.27678);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1686.753, 4815.806, 42.00874);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1701.209, 6426.569, 32.76408);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1091.42, 2708.629, 18.95568);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-660.703, -853.971, 24.484);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-660.703, -853.971, 24.484);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1409.782, -100.41, 52.387);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1410.279, -98.649, 52.436);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-2975.014, 380.129, 14.99909);
ATM_Tabelle[ATMCount++] = new alt.Vector3(155.9642, 6642.763, 31.60284);
ATM_Tabelle[ATMCount++] = new alt.Vector3(174.1721, 6637.943, 31.57305);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-97.33363, 6455.411, 31.46716);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-95.49733, 6457.243, 31.46098);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-303.2701, -829.7642, 32.41727);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-301.6767, -830.1, 32.41727);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-717.6539, -915.6808, 19.21559);
ATM_Tabelle[ATMCount++] = new alt.Vector3(-1391.023, -590.3637, 30.31957);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1138.311, -468.941, 66.73091);
ATM_Tabelle[ATMCount++] = new alt.Vector3(1167.086, -456.1151, 66.79015);




alt.onServer("Reallife:ShowATMBlips", () => {
	for (var blips in ATM_Tabelle) {
		ATM_Blips[blips] = CreateBlip("Bankautomat", [ATM_Tabelle[blips].x, ATM_Tabelle[blips].y, ATM_Tabelle[blips].z], 277, 2, true);
	}
});

alt.onServer("Reallife:DestroyATMBlips", () => {
	for (var AllBlips in ATM_Blips) {
		if (ATM_Blips[AllBlips] != null) game.removeBlip(ATM_Blips[AllBlips]);
		delete ATM_Blips[AllBlips];
	}
});


