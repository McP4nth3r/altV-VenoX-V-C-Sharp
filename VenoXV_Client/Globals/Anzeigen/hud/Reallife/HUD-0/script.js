/*//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//*/


function UpdateHUDStats(Faction, Armor, Health, Hunger, Money) {
    // Update Faction
    $('.HUD_HEADER_FACTION').css("background-image", "url(files/images/" + Faction + ".png)");
    // Update Armor
    $('.HUD_HEADER_ARMOR_BACKGROUND').children('.HUD_STATS_TEXT').text(Armor + "%");
    $('.HUD_HEADER_ARMOR_BAR').css("width", Armor + "%");
    // Update Health
    $('.HUD_HEADER_HEALTH_BACKGROUND').children('.HUD_STATS_TEXT').text(Health + "%");
    $('.HUD_HEADER_HEALTH_BAR').css("width", Health + "%");
    // Update Hunger
    $('.HUD_HEADER_HUNGER_BACKGROUND').children('.HUD_STATS_TEXT').text(Hunger + "%");
    $('.HUD_HEADER_HUNGER_BAR').css("width", Hunger + "%");
    // Update Money
    $('.HUD_BOTTOM_MONEY').html(Money + "$");
}
UpdateHUDStats(1, 38, 50, 40, 500);


function UpdateVoiceState(State) {
    // Update Voice
    $('.HUD_BOTTOM_VOICE').attr("src", "files/images/Voice" + State + ".png");
}
UpdateVoiceState(0);

function UpdateHUDWanteds(Wanteds) {
    for (let i = 0; i <= 6; i++) {
        if (Wanteds < i) {
            $('#Wanteds-' + i).attr("src", "files/images/wanted_inactive.png");
        }
        else {
            $('#Wanteds-' + i).attr("src", "files/images/wanted_active.png");
        }
    }
}
UpdateHUDWanteds(0);

function UpdateLocation(Location) {
    $('.HUD_HEADER_TEXT').html(Location);
}
//UpdateLocation("L.S.P.D - Los Santos");

function ShowHUD(State) {
    if (State) { $("#HUD").removeClass('d-none'); }
    else { $("#HUD").addClass('d-none'); }
}
ShowHUD(true);
if ('alt' in window) {
    alt.on('HUD:UpdateStats', (Faction, Armor, Health, Hunger, Money) => {
        UpdateHUDStats(Faction, Armor, Health, Hunger, Money);
    });
    alt.on('HUD:UpdateVoiceState', (State) => {
        UpdateVoiceState(State);
    });
    alt.on('HUD:UpdateWanteds', (Wanteds) => {
        UpdateHUDWanteds(Wanteds);
    });
    alt.on('HUD:UpdateLocation', (Location) => {
        UpdateLocation(Location);
    });
    alt.on('HUD:Show', (State) => {
        ShowHUD(State);
    });
}