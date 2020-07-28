//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let HomeBackground = 1;
let HomeBackgroundUrl = $('.PhoneBackground').css("background-image");
let PhoneState = true; //Handy Angeschaltet Status

/*-------------------------------------------------------------*/

function DestroyAllScreens() {
	$("#PhoneHomeScreen").addClass("d-none");
	$("#PhoneCallScreen").addClass("d-none");
	$("#PhoneSMSScreen").addClass("d-none");
	$("#PhoneNewSMSScreen").addClass("d-none");
	$("#PhoneCallScreenActive").addClass("d-none");
	$("#PhoneOffScreen").addClass("d-none");
	$("#PhoneMusicScreen").addClass("d-none");
	$("#PhoneWriteSMSScreen").addClass("d-none");
}

/*-------------------------------------------------------------*/

function ChangeHomeScreen(Id) {
	$('.PhoneBackground').css("background-image", "url(./files/images/homescreen_" + Id + ".png)");
}
ChangeHomeScreen(HomeBackground);

function DrawHomeScreen() {
	if (IsCallInProcess || !PhoneState) { return; }
	DestroyAllScreens();
	$("#PhoneHomeScreen").removeClass("d-none");
}

function OnAppClick(appbtn) {
    DestroyAllScreens();
	$("#" + appbtn).removeClass("d-none");
}

function TurnPhoneOn(State) {
    DestroyAllScreens();
    PhoneState = State;
	if(!State) { $("#PhoneOffScreen").removeClass("d-none"); }
    else { DestroyAllScreens(); DrawHomeScreen(); }
}

/*-------------------------------------------------------------*/

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

/*-------------------------------------------------------------*/