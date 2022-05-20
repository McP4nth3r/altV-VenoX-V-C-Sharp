const speedProgress = document.getElementById('speedProgress');
const engineProgress = document.getElementById('engineProgress');
const fuelProgress = document.getElementById('fuelProgress');

// 942.477 speedFerence
// 1162.389 engineFerence
// 1162.389 fuelFerence

alt.on('updatePanel', (KmH, mileage, fuel, engine, door, engineStatus) => {
	document.getElementById("speed").innerHTML = `${KmH}`;

	let kilometraj = mileage / 1000;
	document.getElementById("mileage").innerHTML = `${kilometraj} km`;

	let percentKM = 240 / KmH;
	let kmdraw = 100 / percentKM;

	let percentFuel = 50 / fuel;
	let fueldraw = 100 / percentFuel;
	document.getElementById("fuelRate").innerHTML = `${Math.round(fuel)}L`;

	let percentEngine = 1000 / engine;
	let enginedraw = 100 / percentEngine;
	if (enginedraw <= 0) enginedraw = 0;
	document.getElementById("percentEngine").innerHTML = `${Math.round(enginedraw)}%`;

	// IMAGE DOOR STATUS
	if (door == 2) document.getElementById("door").setAttribute('href', 'assets/images/doorClose.png');
	else document.getElementById("door").setAttribute('href', 'assets/images/doorOpen.png');


	// IMAGE HEADLIGHT STATUS


	// IMAGE SAFETY BELT STATUS


	// IMAGE ENGINE STATUS
	if (engineStatus) document.getElementById("engine").setAttribute('href', 'assets/images/engineOn.png');
	else document.getElementById("engine").setAttribute('href', 'assets/images/engineOff.png');


	setProgressEngine(enginedraw);
	setProgressFuel(fueldraw);
	setProgressSpeed(kmdraw);
});


function setProgressSpeed(percent) {
	const offsetSpeed = (709.4 - percent / 100 * 709.4) + 233; // МАКСИМАЛЬНЫЙ CIRCLEFERENCE 942.4		// МИНИМАЛЬНЫЙ CIRCUMFERENCE 233
	if (offsetSpeed > 233) speedProgress.style.strokeDashoffset = offsetSpeed;
	else speedProgress.style.strokeDashoffset = 233;
}

function setProgressEngine(percent) {
	const offsetEngine = (160 - percent / 100 * 160) + 787; // МАКСИМАЛЬНЫЙ CIRCLEFERENCE 947		// МИНИМАЛЬНЫЙ CIRCUMFERENCE 787
	if (offsetEngine > 787) engineProgress.style.strokeDashoffset = offsetEngine;
	else engineProgress.style.strokeDashoffset = 787;
}

function setProgressFuel(percent) {
	const offsetFuel = (160 - percent / 100 * 160) + 787;
	if (offsetFuel > 787) fuelProgress.style.strokeDashoffset = offsetFuel; // МАКСИМАЛЬНЫЙ CIRCLEFERENCE 947			// МИНИМАЛЬНЫЙ CIRCUMFERENCE 787
	else fuelProgress.style.strokeDashoffset = 787;
}