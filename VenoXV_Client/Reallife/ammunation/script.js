//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
let browser = null;

mp.events.add('Buy_Item_C', (item) => {
	mp.events.callRemote('Buy_Item_S', item);
});

mp.events.add('Buy_Item_C_Ammo', (item) => {
	mp.events.callRemote('Buy_Item_Ammo_S', item);
});



mp.events.add("DestroyAmmunation",() => {
	if (browser != null) {
		mp.gui.cursor.show(false, false);
		mp.players.local.freezePosition(false);
        browser.destroy();
        browser = null;
        return
    }
});


mp.events.add("ShowAmmunation_C",() => {
	if (browser != null) {
        browser.destroy();
        browser = null;
        return
    }
	mp.players.local.freezePosition(true);
	mp.gui.cursor.show(true, true);
	browser = mp.browsers.new("package://VenoXV/Ammunation/ammunation.html");
});

