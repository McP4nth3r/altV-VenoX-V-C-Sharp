//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

function CreateWeaponEntry(_ImageName, _WeaponName, _WeaponAmount = "[ 0 ]") {
    $('.area').append('<div class="column"><img src="images/' + _ImageName + '.png" class="columnimage"><div class="columnbutton" id="' + _WeaponName + '">' + _WeaponName + ' ' + _WeaponAmount + '</div></div>')
}

function UpdateWeaponEntryAmount(_WeaponName, _WeaponAmount = "[0/250]") {
    $('#' + _WeaponName).text(_WeaponName + " " + _WeaponAmount);
}

if ('alt' in window) {
    alt.on('WeaponSelect:UpdateButton', (_WeaponName, _WeaponAmount) => {
        UpdateWeaponEntryAmount(_WeaponName, _WeaponAmount);
    });
    alt.on('fguns:createentrys', (state) => {
        if (state) {
            CreateWeaponEntry('weapon_nightstick', 'Schlagstock');
            CreateWeaponEntry('weapon_stungun', 'Tazer');
            CreateWeaponEntry('weapon_pistol', 'Pistole');
            CreateWeaponEntry('weapon_pistol50', 'Pistole50');
            CreateWeaponEntry('weapon_pumpshotgun', 'Shotgun');
            CreateWeaponEntry('weapon_combatpdw', 'PDW');
            CreateWeaponEntry('weapon_carbinerifle', 'Karabiner');
            CreateWeaponEntry('weapon_advancedrifle', 'Kampfgewehr');
            CreateWeaponEntry('weapon_sniperrifle', 'Sniper');
        }
        else {
            CreateWeaponEntry('weapon_baseballbat', 'Baseball Schläger');
            CreateWeaponEntry('weapon_pistol', 'Pistole');
            CreateWeaponEntry('weapon_pistol50', 'Pistole50');
            CreateWeaponEntry('weapon_revolver', 'Revolver');
            CreateWeaponEntry('weapon_pumpshotgun', 'Shotgun');
            CreateWeaponEntry('weapon_minismg', 'SMG');
            CreateWeaponEntry('weapon_ak47', 'AK47');
            CreateWeaponEntry('weapon_musket', 'Rifle');
            CreateWeaponEntry('weapon_rocketlauncher', 'RPG');
        }
        $('.columnbutton').click(function () {
            alt.emit('fguns:selectweapon', $(this).attr('id'));
        });
    });
    //parseInt("0") = 0;
    alt.on('fguns:ForceStateWindowUpdate', (nightstick_text, nightstick_amount, Tazer, weapon_tazer, Pistole, weapon_pistol, Pistole50, weapon_pistol50, Shotgun, weapon_pumpshotgun, CombatPDW, weapon_combatpdw, Karabiner, weapon_carbinerifle, Kampfgewehr, weapon_advancedrifle, Sniper, weapon_sniperrifle) => {
        UpdateWeaponEntryAmount(nightstick_text, nightstick_amount);
        UpdateWeaponEntryAmount(Tazer, weapon_tazer);
        UpdateWeaponEntryAmount(Pistole, weapon_pistol);
        UpdateWeaponEntryAmount(Pistole50, weapon_pistol50);
        UpdateWeaponEntryAmount(Shotgun, weapon_pumpshotgun);
        UpdateWeaponEntryAmount(CombatPDW, weapon_combatpdw);
        UpdateWeaponEntryAmount(Karabiner, weapon_carbinerifle);
        UpdateWeaponEntryAmount(Kampfgewehr, weapon_advancedrifle);
        UpdateWeaponEntryAmount(Sniper, weapon_sniperrifle);
    });
}

function CreateMagazineEntry(_MagazineName, _MagazineAmount = "[0/1000]") {
    $('.magazine_window').append('<div class="columnmagazine" id="' + _MagazineName + '">' + _MagazineName + ' ' + _MagazineAmount + '</div>')
}

function UpdateMagazineEntryAmount(_MagazineName, _MagazineAmount = "[0/1000]") {
    $('#' + _MagazineName).text(_MagazineName + " " + _MagazineAmount);
}

if ('alt' in window) {
    alt.on('Fguns:UpdateMagazin', (_MagazineName, _MagazineAmount) => {
        UpdateMagazineEntryAmount(_MagazineName, _MagazineAmount);
    });
    alt.on('fguns:createmagazineentrys', (state) => {
        if (state) {
            CreateMagazineEntry('weapon_pistol', 'Pistole');
            CreateMagazineEntry('weapon_pistol50', 'Pistole50');
            CreateMagazineEntry('weapon_pumpshotgun', 'Shotgun');
            CreateMagazineEntry('weapon_combatpdw', 'PDW');
            CreateMagazineEntry('weapon_carbinerifle', 'Karabiner');
            CreateMagazineEntry('weapon_advancedrifle', 'Kampfgewehr');
            CreateMagazineEntry('weapon_sniperrifle', 'Sniper');
        }
        else {
            CreateMagazineEntry('weapon_pistol', 'Pistole');
            CreateMagazineEntry('weapon_pistol50', 'Pistole50');
            CreateMagazineEntry('weapon_revolver', 'Revolver');
            CreateMagazineEntry('weapon_pumpshotgun', 'Shotgun');
            CreateMagazineEntry('weapon_minismg', 'SMG');
            CreateMagazineEntry('weapon_ak47', 'AK47');
            CreateMagazineEntry('weapon_musket', 'Rifle');
            CreateMagazineEntry('weapon_rocketlauncher', 'RPG');
        }
    });
    alt.on('fguns:ForceStateWindowUpdate', (Pistole, weapon_pistol, Pistole50, weapon_pistol50, Shotgun, weapon_pumpshotgun, CombatPDW, weapon_combatpdw, Karabiner, weapon_carbinerifle, Kampfgewehr, weapon_advancedrifle, Sniper, weapon_sniperrifle) => {
        UpdateMagazineEntryAmount(Pistole, weapon_pistol);
        UpdateMagazineEntryAmount(Pistole50, weapon_pistol50);
        UpdateMagazineEntryAmount(Shotgun, weapon_pumpshotgun);
        UpdateMagazineEntryAmount(CombatPDW, weapon_combatpdw);
        UpdateMagazineEntryAmount(Karabiner, weapon_carbinerifle);
        UpdateMagazineEntryAmount(Kampfgewehr, weapon_advancedrifle);
        UpdateMagazineEntryAmount(Sniper, weapon_sniperrifle);
    });
}


