let HomeBackground = 1;
let HomeBackgroundUrl = $('.PhoneBackground').css("background-image");
/*-------------------------------------------------------------*/
function DestroyAllScreens() {
	$("#PhoneHomeScreen").addClass("d-none");
	$("#PhoneCallScreen").addClass("d-none");
	$("#PhoneSMSScreen").addClass("d-none");
	$("#PhoneCallScreenActive").addClass("d-none");
}

/*-------------------------------------------------------------*/

function ChangeHomeScreen(Id) {
	$('.PhoneBackground').css("background-image", "url(./files/images/homescreen_" + Id + ".png)");
}
ChangeHomeScreen(HomeBackground);

function DrawHomeScreen() {
	if (IsCallInProcess) { return; }
	DestroyAllScreens();
	$("#PhoneHomeScreen").removeClass("d-none");
}

function OnAppClick(appbtn) {
	$("#PhoneHomeScreen").addClass("d-none");
	$("#" + appbtn).removeClass("d-none");
}
/*-------------------------------------------------------------*/



/*-------------------------------------------------------------*/
//

//alt:V Events.

if ('alt' in window) {
	alt.on('Call:CreateGridEntry', (Name, Tel) => {
		AddPlayertoCallList(Name, Tel);
	});
	alt.on('Phone:Show', (State) => {
		if (State) {
			$('.all').removeClass('d-none');
		} else {
			$('.all').addClass('d-none');
		}
	});
}


$(".PhoneIndex").draggable({ disabled: false });

////////////////////////////////////////////////////