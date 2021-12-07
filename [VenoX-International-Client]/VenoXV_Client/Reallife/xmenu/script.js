//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let preloadbrowser = null;
var piemenu;
$id = 0;
$type = "";

$itemNames = [];


function setID(anordnung, id) {
	$id = id;
	document.getElementById('xTitle').innerHTML = $itemNames[anordnung];
}

function runMethod() {
	alt.emit('XMenu:ButtonApplied', $id);
}

function closeX() {
	runMethod();
	piemenu.raphael.remove();
}

function createX(type, tag = "normal") {
	document.body.addEventListener("click", function (evt) { evt.preventDefault(); });
	$type = type;
	piemenu = new wheelnav('piemenu');
	piemenu.cssMode = true;
	piemenu.animatetime = 0;
	piemenu.wheelRadius = piemenu.wheelRadius * 0.85;
	piemenu.selectedNavItemIndex = null;
	piemenu.slicePathFunction = slicePath().DonutSlice;
	piemenu.clickModeRotate = false;

	if (type == "veh") {
		piemenu.createWheel([icon.lock, icon.bolt, icon.cross, icon.books]);
		piemenu.navItems[0].navSlice.mouseover(function () { setID(0, 9900); });
		piemenu.navItems[1].navSlice.mouseover(function () { setID(1, 9901); });
		piemenu.navItems[2].navSlice.mouseover(function () { setID(2, 0); });
		piemenu.navItems[3].navSlice.mouseover(function () { setID(3, 9902); });
		$itemNames = ["Auf & Zuschliessen", "Motor an / ausschalten", "Schliessen", "Informationen"];
	}
	else if (type == "self") {
		piemenu.createWheel([icon.cross, icon.package, icon.car]);
		piemenu.navItems[0].navSlice.mouseover(function () { setID(0, 0); });
		piemenu.navItems[1].navSlice.mouseover(function () { setID(1, 0); });
		piemenu.navItems[2].navSlice.mouseover(function () { setID(2, 0); });
		$itemNames = ["Schliessen", "Inventar", "Fahrzeuge anzeigen"];
	}
	else {
		if (tag == "leader") {
			piemenu.createWheel([icon.geldGeben, icon.fesseln, icon.durchsuchen, icon.cross]);
			$itemNames = ["Geld geben", "Fesseln", "Durchsuchen", "Schliessen"];
			piemenu.navItems[0].navSlice.mouseover(function () { setID(0, 8800); });
			piemenu.navItems[1].navSlice.mouseover(function () { setID(1, 8801); });
			piemenu.navItems[2].navSlice.mouseover(function () { setID(2, 8802); });
			piemenu.navItems[3].navSlice.mouseover(function () { setID(3, 0); });
		} else {
			piemenu.createWheel([icon.geldGeben, icon.fesseln, icon.durchsuchen, icon.cross]);
			$itemNames = ["Geld geben", "Fesseln", "Durchsuchen", "Schliessen"];
			piemenu.navItems[0].navSlice.mouseover(function () { setID(0, 8800); });
			piemenu.navItems[1].navSlice.mouseover(function () { setID(1, 8801); });
			piemenu.navItems[2].navSlice.mouseover(function () { setID(2, 8802); });
			piemenu.navItems[3].navSlice.mouseover(function () { setID(3, 0); });
		}
	}
};
