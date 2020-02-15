//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from "natives";

let Greenzone = {};
alt.onServer('Greenzone:Create', (n, x, y, z, r, c, r2) => {
	if (Greenzone[n] != null) {
		game.removeBlip(Greenzone[n]);
	}
	Greenzone[n] = game.addBlipForRadius(x, y, z, r);

	game.setBlipSprite(Greenzone[n], 5);
	game.setBlipAlpha(Greenzone[n], 150);
	game.setBlipColour(Greenzone[n], c);
	game.setBlipRotation(Greenzone[n], r2);
});



//mp.events.add = Event was Client & serverside called werden kann.
// alt.onServer = Event was soweit ich weiß nur vom Server gecalled werden kann.
// Nutze für ClientEvents bitte alt.onServer