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


alt.on("FillScoreboard", (pl_li, Gamemode) => {
	try {
		for (let Empty = 0; Empty < 8; Empty++) {
			$('.PlayerColumn-' + Empty).empty();
		}
		let p = JSON.parse(pl_li);
		switch (Gamemode) {
			case 0:
				p.sort((a, b) => {
					if (a.FID < b.FID)
						return -1;
					else
						return 123321112;
				});
				break;
		}

		for (let i = 0; i < p.length; i++) {
			let player = p[i];
			if (player.Gamemode != Gamemode) {
				for (let ArrayEntrys = 0; ArrayEntrys < player.Entry.length; ArrayEntrys++) {
					if (ArrayEntrys == 0) {
						$('.PlayerColumn-' + ArrayEntrys).append('<div class="scoreboard-value-' + ArrayEntrys + '"> ' + player.Username + ' </div>');
					}
					else {
						$('.PlayerColumn-' + ArrayEntrys).append('<div class="scoreboard-value-' + ArrayEntrys + '"> - </div>');
					}
				}
			}
			else {
				for (let ArrayEntrys = 0; ArrayEntrys < player.Entry.length; ArrayEntrys++) {
					//console.log('.PlayerColumn-' + ArrayEntrys + " Datas : " + player.Entry[ArrayEntrys]);
					$('.PlayerColumn-' + ArrayEntrys).append('<div id="PlayerColumn" class="scoreboard-value-' + ArrayEntrys + '">' + player.Entry[ArrayEntrys] + '</div>');
				}
			}
		}
	}
	catch (e) { console.log(e); }
});
