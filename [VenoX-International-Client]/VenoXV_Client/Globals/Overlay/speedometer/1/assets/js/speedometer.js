const fuelProgress = document.getElementById('fuelProgress');
const tahoProgress = document.getElementById('tahoProgress');
const speedProgress = document.getElementById('speedProgress');


alt.on('updatePanel', (KmH, mileage, fuel, rpm, door, gear) => {
	document.getElementById("speed").innerHTML = `${KmH}`;

	let kilometraj = mileage / 1000;
	document.getElementById("mileage").innerHTML = `${kilometraj} km`;

	let percentKM = 240 / KmH;
	let kmdraw = 100 / percentKM;

	let percentFuel = 100 / fuel;
	let fueldraw = 100 / percentFuel;

	let percentrpm = 11000 / rpm;
	let tahodraw = 100 / percentrpm;

	document.getElementById("fuelRate").innerHTML = `${Math.round(fuel)}L`;

	document.getElementById("gear").innerHTML = `${gear}`;

	// IMAGE DOOR STATUS
	if (door == 2) document.getElementById("door").setAttribute('href', 'assets/images/doorClose.png');
	else document.getElementById("door").setAttribute('href', 'assets/images/doorOpen.png');


	// IMAGE HEADLIGHT STATUS


	// IMAGE SAFETY BELT STATUS


	// IMAGE ENGINE STATUS
	if (engineStatus) document.getElementById("key").setAttribute('href', 'assets/images/keyOn.png');
	else document.getElementById("key").setAttribute('href', 'assets/images/keyOff.png');

	setProgressFuel(fueldraw);
	setProgressrpm(tahodraw);
	setProgressSpeed(kmdraw);
});


function setProgressSpeed(percent) {
	const offsetSpeed = (535 - percent / 100 * 535) + 790; // minimum 790 			1325 maximum 		535
	if (offsetSpeed < 1325) speedProgress.style.strokeDashoffset = offsetSpeed;
	else speedProgress.style.strokeDashoffset = 1325;
}

function setProgressrpm(percent) {
	const offsetrpm = (234 - percent / 100 * 234) + 475; // 475 minimum 		709 maximum 			234	
	if (offsetrpm < 709) tahoProgress.style.strokeDashoffset = offsetrpm;
	else tahoProgress.style.strokeDashoffset = 709;
}

function setProgressFuel(percent) {
	const offsetFuel = (104, 5 - percent / 100 * 104, 5) + 503; // 503 minimum   607.5 maximum   						104,5 
	if (offsetFuel < 607.5) fuelProgress.style.strokeDashoffset = offsetFuel;
	else fuelProgress.style.strokeDashoffset = 607.5;
}