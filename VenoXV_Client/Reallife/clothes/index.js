//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import {
    CreateSideMenu
} from "../../Globals/VnX-Lib";

let clothesTypeArray = [{
        type: 0,
        slot: 1,
        desc: 'clothes.masks'
    }, {
        type: 0,
        slot: 3,
        desc: 'clothes.torso'
    }, {
        type: 0,
        slot: 4,
        desc: 'clothes.legs'
    },
    {
        type: 0,
        slot: 5,
        desc: 'clothes.bags'
    }, {
        type: 0,
        slot: 6,
        desc: 'clothes.feet'
    }, {
        type: 0,
        slot: 7,
        desc: 'clothes.complements'
    },
    {
        type: 0,
        slot: 8,
        desc: 'clothes.undershirt'
    }, {
        type: 0,
        slot: 11,
        desc: 'clothes.tops'
    }, {
        type: 1,
        slot: 0,
        desc: 'clothes.hats'
    },
    {
        type: 1,
        slot: 1,
        desc: 'clothes.glasses'
    }, {
        type: 1,
        slot: 2,
        desc: 'clothes.earrings'
    }, {
        type: 1,
        slot: 6,
        desc: 'clothes.watches'
    },
    {
        type: 1,
        slot: 7,
        desc: 'clothes.bracelets'
    }
];

let selectedIndex = -1;
let clothesTypes = [];
let browser = null;
let camera = undefined;
let currentstatecam = 0;

/*mp.events.add('rotate_btn_clothes', (e) => {
    if (currentstatecam != 0) {
        camera = mp.cameras.new('default_clothes', new mp.Vector3(-159.3681, -299.175, 39.35), new mp.Vector3(9, 0, 350), 50);
        camera.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);

        currentstatecam = 0;
        return;
    }

    if (e == "left_btn") {
        currentstatecam = currentstatecam - 1;
        camera = mp.cameras.new('default_clothes', new mp.Vector3(-161.8059, -296.5924, 39.35), new mp.Vector3(9, 0, 255), 50);
        camera.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    } else {
        currentstatecam = currentstatecam + 1;
        camera = mp.cameras.new('default_clothes', new mp.Vector3(-155.8059, -297.5924, 39.35), new mp.Vector3(9, 0, 70), 50);
        camera.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    }
});
*/
mp.events.add('showClothesMenu', (business, price) => {
    mp.game.cam.renderScriptCams(true, false, 0, true, false);

    browser = CreateSideMenu();
    browser.emit('populateClothesShopMenu', JSON.stringify(clothesTypeArray), business, price);

    browser.on('getClothesByType', (index) => {

        selectedIndex = index;
        mp.events.callRemote('getClothesByType', clothesTypeArray[index].type, clothesTypeArray[index].slot);
    });

});


mp.events.add('showTypeClothes', (clothesJson) => {
    let player = alt.Player.local;
    let type = clothesTypeArray[selectedIndex].type;
    let slot = clothesTypeArray[selectedIndex].slot;
    clothesTypes = JSON.parse(clothesJson);

    for (let i = 0; i < clothesTypes.length; i++) {
        clothesTypes[i].textures = type == 0 ? player.getNumberOfTextureVariations(slot, clothesTypes[i].clothesId) : player.getNumberOfPropTextureVariations(slot, clothesTypes[i].clothesId);
    }

    browser.emit('populateTypeClothes', JSON.stringify(clothesTypes).replace(/'/g, "\\'"));
});

mp.events.add('replacePlayerClothes', (index, texture) => {
    let player = alt.Player.local;
    if (clothesTypes[index].type === 0) {
        player.setComponentVariation(clothesTypes[index].bodyPart, clothesTypes[index].clothesId, texture, 0);
    } else {
        player.setPropIndex(clothesTypes[index].bodyPart, clothesTypes[index].clothesId, texture, true);
    }
});

mp.events.add('purchaseClothes', (index, texture) => {
    let clothesModel = {};
    clothesModel.type = clothesTypes[index].type;
    clothesModel.slot = clothesTypes[index].bodyPart;
    clothesModel.drawable = clothesTypes[index].clothesId;
    clothesModel.texture = parseInt(texture);

    mp.events.callRemote('clothesItemSelected', JSON.stringify(clothesModel));
});

mp.events.add('clearClothes', (index) => {
    let type = clothesTypes[index].type;
    let slot = clothesTypes[index].bodyPart;

    mp.events.callRemote('dressEquipedClothes', type, slot);
});

mp.events.add('CloseClotheShop_c', () => {
    if (browser != null) {
        browser.destroy();
        browser = null;
    }
    mp.game.cam.renderScriptCams(false, false, 0, true, false);
    camera.destroy();
    camera = undefined;
    mp.events.callRemote('CloseClotheShop');
    mp.events.call('destroyBrowser');
    mp.gui.chat.show(true);
    currentstatecam = 0;
});