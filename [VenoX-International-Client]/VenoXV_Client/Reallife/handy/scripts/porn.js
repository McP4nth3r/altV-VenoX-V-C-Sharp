//----------------------------------//
///// VenoX Gaming & Fun 2021 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let IsPhoneInPornView = false;
function CreatePhoneInPornView(){
    if(IsPhoneInPornView) return;
    OnAppClick('PhonePornhubScreen');
    $('.PhoneIndex').removeClass('RotateFromPornView');
    $('.PhoneIndex').addClass('RotateToPornView');
    IsPhoneInPornView = true;
}

function DestroyPhoneInPornView(){
    if(!IsPhoneInPornView) return;
    $('.PhoneIndex').removeClass('RotateToPornView');
    $('.PhoneIndex').addClass('RotateFromPornView');
    IsPhoneInPornView = false;
}