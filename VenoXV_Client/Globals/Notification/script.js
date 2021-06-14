//----------------------------------///
///// VenoX Gaming & Fun 2021 © ///////
///////////////////////////////////////
////////www.venox-international.com////
//----------------------------------///

$(document).ready(function () {
    document.getElementById('SideNotification_Sound').volume = 0.35;
});

let NotificationCounter = 0;
let NotificationTypes = {
    Info: "Info",
    Warning: "Warning",
    Error: "Error"
}

function GetCorrectType(type) {
    switch (type) {
        case 0:
            return NotificationTypes.Info;
        case 1:
            return NotificationTypes.Warning;
        case 2:
            return NotificationTypes.Error;
    }
}

function DrawNotification(type, text) {
    $('.Notification_Container').append('<div class="Notification_Box NotificationColor' + GetCorrectType(type) + '" id="Notification_' + NotificationCounter + '"><div class="Notification_Text">' + text + '</div></div>');
    PlayNotificationSound();
    let NotificationId = NotificationCounter;
    $('#Notification_' + NotificationCounter).animate({
        left: '0%'
    }, 500);
    setTimeout(() => {
        $('#Notification_' + NotificationId).animate({
            left: '-100%'
        }, 500);
        setTimeout(() => {
            $('#Notification_' + NotificationId).remove();
        }, 2000);
    }, 4000);

    NotificationCounter++;
}

function PlayNotificationSound() {
    document.getElementById('SideNotification_Sound').currentTime = 0;
    document.getElementById('SideNotification_Sound').play();
}

function SetCurrentQuest(QuestText, QuestMoney, QuestLevel) {
    $('.QuestMain_container').html(QuestText);
    $('.QuestMain_container_win').html(QuestMoney);
    $('#QuestMain_' + QuestLevel).removeClass("d-none");
    $('#QuestMain_' + (QuestLevel -= 1)).addClass("d-none");
}

function ShowQuests(state) {
    if (state) $('#quest_showed').removeClass('d-none');
    else $('#quest_showed').addClass('d-none');
}

if ('alt' in window) {
    alt.on('SideNotification:Create', (type, text) => {
        DrawNotification(type, text);
    });
    alt.on('Quests:Show', (State) => {
        ShowQuests(State);
    });
    alt.on('Quests:SetCurrentQuest', (QuestText, QuestMoney, QuestLevel) => {
        SetCurrentQuest(QuestText, QuestMoney, QuestLevel);
    });
    alt.on("Notify:PlayHitSound", () => {
        document.getElementById('audio_hitsound').currentTime = 0;
        document.getElementById('audio_hitsound').play();
    });
    alt.on('Notify:BloodScreen', () => {
        showBloodscreen();
    });
}