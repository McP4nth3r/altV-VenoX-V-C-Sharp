/*//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//*/

const { addToClockTime } = require("natives");


// OnLoad : 
let ATM_STATE = false;
let HAUS_STATE = false;
let TACHO_STATE = false;
let QUEST_STATE = false;
let REPORTER_STATE = false;
let GLOBALCHAT_STATE = false;

function LoadClientSettings() {

}

alt.on('Settings:CheckButton', (btn, state) => {
	console.log(btn + " :  " + state);
	if (state == 1) { state = true; } else { state = false; }
	document.getElementById(btn).checked = state;
})


/* Show Buttons */
let Button = "";
function HideAll() {
	$('.Gameplay_Window').addClass("d-none");
	$('.Show_Window').addClass("d-none");
	$('.Voice_Window').addClass("d-none");
	$('.Account_Window').addClass("d-none");
	$('.Information_Window').addClass("d-none");
	$('.SettingsButton').removeClass("btnActive");
}

$("#Gameplay").click(function () {
	HideAll();
	$('.Gameplay_Window').removeClass("d-none");
	$('#Gameplay').addClass("btnActive");
});

$("#Show").click(function () {
	HideAll();
	$('.Show_Window').removeClass("d-none");
	$('#Show').addClass("btnActive");
});

$("#Voice").click(function () {
	HideAll();
	$('.Voice_Window').removeClass("d-none");
	$('#Voice').addClass("btnActive");
});

$("#Account").click(function () {
	HideAll();
	$('.Account_Window').removeClass("d-none");
	$('#Account').addClass("btnActive");
});

$("#Information").click(function () {
	HideAll();
	$('.Information_Window').removeClass("d-none");
	$('#Information').addClass("btnActive");
});

/* Voice Lautstärke Regler */
/*
var slider = document.getElementById("value");
var output = document.getElementById("voice_volume");
output.innerHTML = slider.value;

slider.oninput = function () {
	output.innerHTML = this.value;
}
*/
/* Password Change Überprüfung */

$("input[type=password]").keyup(function () {
	var upletter = new RegExp("[A-Z]+");
	var lowletter = new RegExp("[a-z]+");
	var number = new RegExp("[0-9]+");

	/* 8 Zeichen */
	if ($("#password1").val().length >= 8) {
		$("#8character").removeClass("glyphicon-remove");
		$("#8character").addClass("glyphicon-ok");
		$("#8character").css("color", "#00A41E");
	}
	else {
		$("#8character").removeClass("glyphicon-ok");
		$("#8character").addClass("glyphicon-remove");
		$("#8character").css("color", "#FF0004");
	}

	/* Großbuchstaben */
	if (upletter.test($("#password1").val())) {
		$("#upletter").removeClass("glyphicon-remove");
		$("#upletter").addClass("glyphicon-ok");
		$("#upletter").css("color", "#00A41E");
	}
	else {
		$("#upletter").removeClass("glyphicon-ok");
		$("#upletter").addClass("glyphicon-remove");
		$("#upletter").css("color", "#FF0004");
	}

	/* Kleinbuchstaben */
	if (lowletter.test($("#password1").val())) {
		$("#lowletter").removeClass("glyphicon-remove");
		$("#lowletter").addClass("glyphicon-ok");
		$("#lowletter").css("color", "#00A41E");
	}
	else {
		$("#lowletter").removeClass("glyphicon-ok");
		$("#lowletter").addClass("glyphicon-remove");
		$("#lowletter").css("color", "#FF0004");
	}

	/* Zahlen */
	if (number.test($("#password1").val())) {
		$("#number").removeClass("glyphicon-remove");
		$("#number").addClass("glyphicon-ok");
		$("#number").css("color", "#00A41E");
	}
	else {
		$("#number").removeClass("glyphicon-ok");
		$("#number").addClass("glyphicon-remove");
		$("#number").css("color", "#FF0004");
	}

	/* Passwort übereinstimmig */
	if ($("#password1").val() == $("#password2").val() && $("#password1").val().length > 0) {
		$("#pwmatch").removeClass("glyphicon-remove");
		$("#pwmatch").addClass("glyphicon-ok");
		$("#pwmatch").css("color", "#00A41E");
	}
	else {
		$("#pwmatch").removeClass("glyphicon-ok");
		$("#pwmatch").addClass("glyphicon-remove");
		$("#pwmatch").css("color", "#FF0004");
	}
});



if ('alt' in window) {
	alt.on('Settings:Show', (state) => {
		if (state) {
			$('.VnX-Window').removeClass('d-none');
		}
		else {
			$('.VnX-Window').addClass('d-none');
		}
	})
}