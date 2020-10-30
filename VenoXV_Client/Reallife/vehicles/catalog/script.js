//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
function OnVehicleClick(Name) {
	alt.emit('VehCatalog:SelectVehicle', Name);
}

function InsertVehicle(row, name, cost) {
	$('#' + row).append('<div class="vehcolumn"><img src="https://www.venox-reallife.com/images_vnx/carshop/' + name + '.png" id="' + name + '"><div class="vehcolumnbutton" id="' + name + '">' + name + "<br>" + cost + ' $</div></div>');
}


if ('alt' in window) {
	alt.on('VehCatalog:Fill', (vehArray) => {
		for (var _c in vehArray) {
			InsertVehicle(vehArray[_c].row, vehArray[_c].name, vehArray[_c].cost);
		}
		$('.vehcolumnbutton').click(function () {
			OnVehicleClick($(this).attr('id'));
		});
	});
}