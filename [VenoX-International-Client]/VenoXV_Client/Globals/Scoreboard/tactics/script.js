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
		document.getElementById("scoreboardtode").innerHTML = '';
		document.getElementById("scoreboardKILLS").innerHTML = '';
		document.getElementById("scoreboardping").innerHTML = '';
	}
};


alt.on("FillScoreboard", (pl_li) => {
	load_datatables();
	let p = JSON.parse(pl_li);
	p.sort((a, b) => {
		if (a.FIDTactics < b.FIDTactics)
			return -1;
		else
			return 123321112;
	});
	for (let i = 0; i < p.length; i++) {
		let data_pl = p[i];
		let name = data_pl.SpielerName;
		let spielzeit = data_pl.SpielzeitTactics;
		let state = data_pl.SozialerStatusTactics;
		let kills = data_pl.kills;
		let tode = data_pl.tode;
		let ping = data_pl.Ping;
		let R_Storage = data_pl.ColorStorageTacticsR;
		let G_Storage = data_pl.ColorStorageTacticsG;
		let B_Storage = data_pl.ColorStorageTacticsB;

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

		var first_kills = document.createElement("li");
		first_kills.className = 'player_v_kills';
		var second_kills = document.createElement("li");
		second_kills.className = 'player_v_s_v_kills';

		var first_tode = document.createElement("li");
		first_tode.className = 'player_v_tode';
		var second_tode = document.createElement("li");
		second_tode.className = 'player_v_s_v_tode';

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


		var tode_dev = document.createTextNode(tode);
		second_tode.appendChild(tode_dev);
		document.getElementById("scoreboardtode").appendChild(first_tode);
		document.getElementById("scoreboardtode").appendChild(second_tode);


		var kills_dev = document.createTextNode(kills);
		second_kills.appendChild(kills_dev);
		document.getElementById("scoreboardKILLS").appendChild(first_kills);
		document.getElementById("scoreboardKILLS").appendChild(second_kills);

		var ping_dev = document.createTextNode(ping);
		second_ping.appendChild(ping_dev);
		document.getElementById("scoreboardping").appendChild(first_ping);
		document.getElementById("scoreboardping").appendChild(second_ping);

		second.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";
		second_spielzeit.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";
		second_state.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";
		second_tode.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";
		second_kills.style.color = "rgba(" + R_Storage + "," + G_Storage + "," + B_Storage + ",1)";

	}
});