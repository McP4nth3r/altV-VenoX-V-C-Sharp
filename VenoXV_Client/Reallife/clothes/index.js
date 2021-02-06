//----------------------------------//
///// VenoX Gaming & Fun 2021 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
alt.log('called clothes 1');
import {
    CreateSideMenu,
    DestroySideMenu
} from '../../Globals/VnX-Lib/index.js';
alt.log('called clothes 2');


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


alt.onServer('showClothesMenu', (business, price) => {
    browser = CreateSideMenu();
    browser.emit('populateClothesShopMenu', JSON.stringify(clothesTypeArray), business, price);

    browser.on('getClothesByType', (index) => {
        selectedIndex = index;
        alt.emitServer('getClothesByType', clothesTypeArray[index].type, clothesTypeArray[index].slot);
    });
    browser.on('CloseClotheShop_c', () => {
        DestroySideMenu();
        alt.emitServer('CloseClotheShop');
    });

    browser.on('replacePlayerClothes', (index, texture) => {
        if (clothesTypes[index].type === 0)
            game.setPedComponentVariation(alt.Player.local.scriptID, clothesTypes[index].bodyPart, clothesTypes[index].clothesId, texture, 0);
        else
            game.setPedPropIndex(alt.Player.local.scriptID, clothesTypes[index].bodyPart, clothesTypes[index].clothesId, texture, true);
    });

    browser.on('purchaseClothes', (index, texture) => {
        let clothesModel = {};
        clothesModel.type = clothesTypes[index].type;
        clothesModel.slot = clothesTypes[index].bodyPart;
        clothesModel.drawable = clothesTypes[index].clothesId;
        clothesModel.texture = parseInt(texture);
        alt.emitServer('clothesItemSelected', JSON.stringify(clothesModel));
    });

    browser.on('clearClothes', (index) => {
        let type = clothesTypes[index].type;
        let slot = clothesTypes[index].bodyPart;
        alt.emitServer('dressEquipedClothes', type, slot);
    });
});


alt.onServer('showTypeClothes', (clothesJson) => {
    let player = alt.Player.local;
    let type = clothesTypeArray[selectedIndex].type;
    let slot = clothesTypeArray[selectedIndex].slot;
    clothesTypes = JSON.parse(clothesJson);
    for (let i = 0; i < clothesTypes.length; i++) {
        clothesTypes[i].textures = type == 0 ? game.getNumberOfPedTextureVariations(player.scriptID, clothesTypes[i].clothesId) : game.getNumberOfPedPropTextureVariations(player.scriptID, clothesTypes[i].clothesId);
    }

    browser.emit('populateTypeClothes', JSON.stringify(clothesTypes).replace(/'/g, "\\'"));
});