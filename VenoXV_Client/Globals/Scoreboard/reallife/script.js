//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

alt.on('Scoreboard:Show', function () {
	$("#playerlist").removeClass("d-none")
});
alt.on('Scoreboard:Hide', function () {
	$("#playerlist").addClass("d-none")
});


function load_datatables() {
	var c = document.body.children;
	var i;
	for (i = 0; i < c.length; i++) {
		document.getElementById("scoreboardplayer").innerHTML = '';
		document.getElementById("scoreboardspielzeit").innerHTML = '';
		document.getElementById("scoreboardstatus").innerHTML = '';
		document.getElementById("scoreboardfaction").innerHTML = '';
		document.getElementById("scoreboardVIP").innerHTML = '';
		document.getElementById("scoreboardping").innerHTML = '';
	}
};


alt.on("FillScoreboard", (pl_li) => {
	load_datatables();
	let p = JSON.parse(pl_li);
	p.sort((a, b) => {
		if (a.FID < b.FID)
			return -1;
		else
			return 123321112;
	});
	for (let i = 0; i < p.length; i++) {
		let data_pl = p[i];
		let name = data_pl.SpielerName;
		let spielzeit = data_pl.Spielzeit;
		let state = data_pl.SozialerStatus;
		let VIP = data_pl.VIP;
		let faction = data_pl.Fraktion;
		let ping = data_pl.Ping;
		let R_Storage = data_pl.ColorStorageR;
		let G_Storage = data_pl.ColorStorageG;
		let B_Storage = data_pl.ColorStorageB;

		let VR_Storage = data_pl.ColorStorageVR;
		let VG_Storage = data_pl.ColorStorageVG;
		let VB_Storage = data_pl.ColorStorageVB;
		let LSPD = data_pl.LSPD;
		let LCN = data_pl.LCN;
		let YAKUZA = data_pl.YAKUZA;
		let NEWS = data_pl.NEWS;
		let FBI = data_pl.FBI;
		let VL = data_pl.VL;
		let USARMY = data_pl.USARMY;
		let SAMCRO = data_pl.SAMCRO;
		let MEDIC = data_pl.MEDIC;
		let MECHANIKER = data_pl.MECHANIKER;
		let BALLAS = data_pl.BALLAS;
		let COMPTON = data_pl.GROVE;
		let TOTAL = data_pl.TOTALPLAYERS;

		var first = document.createElement("li");

		first.className = 'player_v';
		var second = document.createElement("li");
		second.className = 'player_v_s_v';

		var first_spielzeit = document.createElement("li");
		first_spielzeit.className = 'player_v_spielzeit';
		var second_spielzeit = document.createElement("li");
		second_spielzeit.className = 'player_v_s_v_spielzeit';

		var first_state = document.createElement("li");
		first_state.className = 'player_v_state';
		var second_state = document.createElement("li");
		second_state.className = 'player_v_s_v_state';

		var first_VIP = document.createElement("li");
		first_VIP.className = 'player_v_VIP';
		var second_VIP = document.createElement("li");
		second_VIP.className = 'player_v_s_v_VIP';

		var first_faction = document.createElement("li");
		first_faction.className = 'player_v_faction';
		var second_faction = document.createElement("li");
		second_faction.className = 'player_v_s_v_faction';

		var first_ping = document.createElement("li");
		first_ping.className = 'player_v_ping';
		var second_ping = document.createElement("li");
		second_ping.className = 'player_v_s_v_ping';

		var textnode = document.createTextNode(name);
		//second.removeChild( second.firstChild );
		second.appendChild(textnode);
		document.getElementById("scoreboardplayer").appendChild(first);
		document.getElementById("scoreboardplayer").appendChild(second);

		var spielzeit_dev = document.createTextNode(spielzeit);
		second_spielzeit.appendChild(spielzeit_dev);
		document.getElementById("scoreboardspielzeit").appendChild(first_spielzeit);
		document.getElementById("scoreboardspielzeit").appendChild(second_spielzeit);

		var socialstate_dev = document.createTextNode(state);
		second_state.appendChild(socialstate_dev);
		document.getElementById("scoreboardstatus").appendChild(first_state);
		document.getElementById("scoreboardstatus").appendChild(second_state);


		var faction_dev = document.createTextNode(faction);
		second_faction.appendChild(faction_dev);
		document.getElementById("scoreboardfaction").appendChild(first_faction);
		document.getElementById("scoreboardfaction").appendChild(second_faction);


		var vip_dev = document.createTextNode(VIP);
		second_VIP.appendChild(vip_dev);
		document.getElementById("scoreboardVIP").appendChild(first_VIP);
		document.getElementById("scoreboardVIP").appendChild(second_VIP);

		var ping_dev = document.createTextNode(ping);
		second_ping.appendChild(ping_dev);
		document.getElementById("scoreboardping").appendChild(first_ping);
		document.getElementById("scoreboardping").appendChild(second_ping);

		second_faction.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";
		second_VIP.style.color = "rgba(" + VR_Storage + "," + VG_Storage + "," + VB_Storage + ",1)";

		document.getElementById('police').innerHTML = "L.S.P.D : " + LSPD;
		document.getElementById('mafia').innerHTML = "La Cosa Nostra : " + LCN;
		document.getElementById('yakuza').innerHTML = "Yakuza : " + YAKUZA;
		document.getElementById('weazel_news').innerHTML = "Weazel News : " + NEWS;
		document.getElementById('fib').innerHTML = "F.I.B : " + FBI;
		document.getElementById('vatos_locos').innerHTML = "Narcos : " + VL;
		document.getElementById('army').innerHTML = "U.S Army : " + USARMY;
		document.getElementById('samcro').innerHTML = "SAMCRO : " + SAMCRO;
		document.getElementById('medic').innerHTML = "Medic : " + MEDIC;
		document.getElementById('mechaniker').innerHTML = "Mechaniker : " + MECHANIKER;
		document.getElementById('ballas').innerHTML = "Rollin Height's : " + BALLAS;
		document.getElementById('compton').innerHTML = "Compton Family's : " + COMPTON;
		document.getElementById('player').innerHTML = "Online : " + TOTAL;
	}
});