//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

// SMS Events
let d = 0;

/*-------------------------------------------------------------*/

function AddPlayertoChatList(Name, Telnr) {
    if (d == 0) {
        $('.chatscreenGridbg').append('<div class="screenline"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
        d++;
    }
    else {
        $('.chatscreenGridbg').append('<div class="screenlinedark"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
        d--;
    }
}

function AddPlayertoSMSList(Name, Telnr) {
    if (d == 0) {
        $('.smsscreenGridbg').append('<div class="screenline"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
        d++;
    }
    else {
        $('.smsscreenGridbg').append('<div class="screenlinedark"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
        d--;
    }
}

AddPlayertoChatList('LargePeach', '666666');
AddPlayertoChatList('Solid_Snake', '777777');
AddPlayertoChatList('LastAttacker', '000000');
AddPlayertoChatList('Slowman', '555555');
AddPlayertoChatList('ItzSaske', '444444');

for(let i = 0; i <= 100; i++) {
    AddPlayertoSMSList('Forces', '153114');
}

$('.screenlinedark').click(function () { OnCallGridClick(this); });
$('.screenline').click(function () { OnCallGridClick(this); });

function ShowSMSChat() {
    $('#PhoneSMSScreen').addClass('d-none');
    $('#PhoneNewSMSScreen').addClass('d-none');
    $('#PhoneWriteSMSScreen').removeClass('d-none');
    $('.ChatScreenHeader').html(SelectedObjName);
}

$('.sms_button').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    ShowSMSChat();
});
