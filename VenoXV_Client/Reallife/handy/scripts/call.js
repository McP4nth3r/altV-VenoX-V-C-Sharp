// Call Events
let SelectedObj;
let SelectedObjName;
let SelectedObjTelnr;
let IsCallInProcess;

/*-------------------------------------------------------------*/
function OnCallGridClick(element) {
    if (SelectedObj) { $(SelectedObj).removeClass('callscreenlineSelected'); }
    $(element).addClass('callscreenlineSelected');
    let Username = $(element).children('.Username').html();
    let Telnr = $(element).children('.Telnr').html();
    SelectedObj = $(element);
    SelectedObjName = Username;
    SelectedObjTelnr = Telnr;
}

/*-------------------------------------------------------------*/

function ShowCallOutgoing() {
    IsCallInProcess = true;
    $('#PhoneCallScreen').addClass('d-none');
    $('#PhoneCallScreenActive').removeClass('d-none');
    $('.PhoneCallActiveHangup').removeClass('d-none');
    //Blur
    $('.BlurBG').css("background-image", "url(./files/images/homescreen_" + HomeBackground + ".png)");
    //Name & State Insert
    $('.PhoneCallActiveName').html(SelectedObjName);
    ChangeCallingState("Klingeln...", "rgb(255,255,255)");
}

function ShowCallIncoming() {
    IsCallInProcess = true;
    $('#PhoneCallScreen').addClass('d-none');
    $('#PhoneCallScreenActive').removeClass('d-none');
    $('.PhoneCallActiveAccept').removeClass('d-none');
    $('.PhoneCallActiveDeny').removeClass('d-none');
    //Blur
    $('.BlurBG').css("background-image", "url(./files/images/homescreen_" + HomeBackground + ".png)");
    //Name & State Insert
    $('.PhoneCallActiveName').html(SelectedObjName);
    ChangeCallingState("Eingehender Anruf...", "rgb(255,255,255)");
}



$('.call_button').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    ShowCallOutgoing();
    //ShowCallIncoming();
});

$('.PhoneCallActiveDeny').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    $('.PhoneCallActiveName').html(SelectedObjName);
    $('.PhoneCallActiveAccept').addClass('d-none');
    $('.PhoneCallActiveDeny').addClass('d-none');
    ChangeCallingState("Abgelehnt.", "rgb(255,0,0)");
    setTimeout(() => {
        IsCallInProcess = false;
        DrawHomeScreen();
        alt.emit('Phone:Hangup', SelectedObjName);
        SelectedObj = null;
        SelectedObjName = null;
        SelectedObjTelnr = null;
    }, 5000);
});

$('.PhoneCallActiveAccept').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    $('#PhoneCallScreen').addClass('d-none');
    $('.PhoneCallActiveHangup').removeClass('d-none');
    $('.PhoneCallActiveAccept').addClass('d-none');
    $('.PhoneCallActiveDeny').addClass('d-none');
    //Blur
    $('.BlurBG').css("background-image", "url(./files/images/homescreen_" + HomeBackground + ".png)");
    //Name & State Insert
    $('.PhoneCallActiveName').html(SelectedObjName);
    ChangeCallingState("Angenommen.", "rgb(0,255,0)");
});


$('.PhoneCallActiveHangup').click(function () {
    if (!SelectedObj || !SelectedObjName || !SelectedObjTelnr) { return; }
    $('.PhoneCallActiveHangup').addClass('d-none');
    ChangeCallingState("Abgelehnt.", "rgb(255,0,0)");
    setTimeout(() => {
        IsCallInProcess = false;
        DrawHomeScreen();
        alt.emit('Phone:Hangup', SelectedObjName);
        SelectedObj = null;
        SelectedObjName = null;
        SelectedObjTelnr = null;
    }, 5000);
});

/*-------------------------------------------------------------*/
function ChangeCallingState(state, RGB) {
    $('.PhoneCallActiveStatus').html(state);
    $('.PhoneCallActiveStatus').css("color", RGB);
}

let c = 0;
function AddPlayertoCallList(username, telnr) {
    if (c == 0) {
        $('.callscreenGridbg').append('<div class="callscreenline"><div class="Username">' + username + '</div><div class="Telnr">' + telnr + '</div></div>'); c++;
    }
    else {
        $('.callscreenGridbg').append('<div class="callscreenlinedark"><div class="Username">' + username + '</div><div class="Telnr">' + telnr + '</div></div>');
        c--;
    }

}

if ('alt' in window) {
    alt.on('CallList:Init', (List) => {
        c = 0;
        $(".callscreenGridbg").empty();
        let p = JSON.parse(List);
        for (let i = 0; i < p.length; i++) {
            let data = p[i];
            AddPlayertoCallList(data.Username, data.Phone.Number);
        }
        $('.callscreenlinedark').click(function () { OnCallGridClick(this); }); // Event
        $('.callscreenline').click(function () { OnCallGridClick(this); }); // Event
    });
}

/*-------------------------------------------------------------*/
