//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

// SMS Events
let d = 0;

/*-------------------------------------------------------------*/
let ChatOpenPlayers = [];
let _cCounter = 0;


function AddPlayertoChatList(Name, Telnr, ChatOpen = true) {
    if (!ChatOpen) {
        if (d == 0) {
            $('.smsscreenGridbg').append('<div class="screenline"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
            d++;
        }
        else {
            $('.smsscreenGridbg').append('<div class="screenlinedark"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
            d--;
        }
        $('.screenlinedark').click(function () { OnCallGridClick(this); });
        $('.screenline').click(function () { OnCallGridClick(this); });
    }
    else {
        if (d == 0) {
            $('.chatscreenGridbg').append('<div class="screenline"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
            d++;
        }
        else {
            $('.chatscreenGridbg').append('<div class="screenlinedark"><div class="Username">' + Name + '</div><div class="Telnr">' + Telnr + '</div></div>');
            d--;
        }
        ChatOpenPlayers[_cCounter++] = {
            Name: Name,
            Telnr: Telnr
        };
        $('.screenlinedark').click(function () { OnCallGridClick(this); });
        $('.screenline').click(function () { OnCallGridClick(this); });
        return;
    }
    $('#PhoneWriteSMSScreen').append('<div id="Chat_' + Name + '" class="SMS-Chats d-none" ><div class="ChatArea"></div></div>');
}

function ShowSMSChat() {
    $('#PhoneSMSScreen').addClass('d-none');
    $('#PhoneNewSMSScreen').addClass('d-none');
    $('#PhoneWriteSMSScreen').removeClass('d-none');
    $('#PhoneWriteSMSScreen').removeClass('d-none');
    $('.ChatScreenHeader').html(SelectedObjName);
    $('#Chat_' + SelectedObjName).removeClass('d-none');
}

$('.sms_button').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    ShowSMSChat();
});




function AddSendMessagetoSMSList(Message) {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    $('#Chat_' + SelectedObjName).children('.ChatArea').append('<div class="sbright">' + Message + '</div>');
    alt.emit('Phone:OnSMSMessageSend', SelectedObjName, Message);
    let found = false;
    for (var _c in ChatOpenPlayers) {
        if (ChatOpenPlayers[_c].Name == SelectedObjName) { found = true; }
    }
    if (found) { return; }
    AddPlayertoChatList(SelectedObjName, SelectedObjTelnr, true);
}

function OnMessageReceived(From, TelNr, Message) {
    $('#Chat_' + From).children('.ChatArea').append('<div class="sbleft">' + Message + '</div>');
    let found = false;
    for (var _c in ChatOpenPlayers) {
        if (ChatOpenPlayers[_c].Name == SelectedObjName) { found = true; }
    }
    if (found) { return; }
    AddPlayertoChatList(From, TelNr, true);
}




$('.send_button').click(function () {
    let msg = $('#message').val();
    if (msg.length <= 1) { return; }
    $('#message').val('');
    AddSendMessagetoSMSList(msg);
});

if ('alt' in window) {
    alt.on('Phone:AddNewSMS', (From, TelNr, Message) => {
        OnMessageReceived(From, TelNr, Message);
    });
}

