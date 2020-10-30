let bankSelectedOption = 0;
let vehicleArray = undefined;
let catalogSelectedOption = 0;

$(document).ready(function () {
	$('#colorpicker').farbtastic(function (color) {
		var colorMain = $('#color-main').prop('checked');
		alt.emit('previewVehicleChangeColor', color, colorMain);
	});
});

////////////////////////////////////////////////////////////

function catalogBack() {
	switch (catalogSelectedOption) {
		case 1:
			$('#vehicle-container').removeClass('hidden');
			break;
	}
	alt.emit('VehiclePreview:Close');
	catalogSelectedOption = 0;
}


function rotatePreviewVehicle() {
	var rotation = parseFloat(document.getElementById('vehicle-slider').value);
	alt.emit('rotatePreviewVehicle', rotation);
}

function goBackToCatalog() {
	alt.emit('VehiclePreview:Close');
}

function purchaseVehicle() {
	alt.emit('purchaseVehicle');
}

function testVehicle() {
	alt.emit('testVehicle');
}
