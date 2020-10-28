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
	$('.SMS-Chats').addClass("d-none");
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
	if (!State) { $("#PhoneOffScreen").removeClass("d-none"); }
	else { DestroyAllScreens(); DrawHomeScreen(); }
}

/*-------------------------------------------------------------*/

//alt:V Events.
if ('alt' in window) {
	alt.on('Phone:Show', (State) => {
		if (State) {
			$('.all').removeClass('d-none');
		} else {
			$('.all').addClass('d-none');
		}
	});
	alt.on('Phone:AddNewPlayerEntry', (List) => {
		c = 0;
		d = 0;
		$(".callscreenGridbg").empty();
		$(".smsscreenGridbg").empty();
		$(".chatscreenGridbg").empty();
		let p = JSON.parse(List);
		for (let i = 0; i < p.length; i++) {
			let data = p[i];
			AddPlayertoCallList(data.Username, data.Number);
			AddPlayertoChatList(data.Username, data.Number, false);
		}
		console.log('Called AddNewPlayerEntry');
		$('.screenlinedark').click(function () { OnCallGridClick(this); }); // Event
		$('.screenline').click(function () { OnCallGridClick(this); }); // Event
	});
}
$(".PhoneIndex").draggable({ disabled: false });


/*-------------------------------------------------------------*/