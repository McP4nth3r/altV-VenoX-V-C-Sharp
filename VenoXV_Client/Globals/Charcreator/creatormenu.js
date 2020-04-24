import * as alt from 'alt-client';
import * as game from "natives";
import * as NativeUI from '/VenoXV_Client/Globals/VnX-Lib/NativeUI/NativeUI';


import { maxHairColor, maxBlushColor, maxLipstickColor, fatherNames, motherNames, fathers, mothers, featureNames, appearanceNames, appearanceItemNames, hairList, eyeColors } from './chardata';




//*************************************************************************/ Charcreator Stuff
let creatorMenus = [];
let similarities = [];
let angles = [];
let hairColors = [];
let blushColors = [];
let lipstickColors = [];
let featureData = [];
let appearanceData = [];
let appearanceItems = [];
let appearanceOpacityItems = [];
let opacities = [];
let featureItems = [];
let features = [];

let currentGender = 0;

let hairItem;
let hairColorItem;
let hairHighlightItem;
let eyebrowColorItem;
let beardColorItem;
let eyeColorItem;
let blushColorItem;
let lipstickColorItem;
let chestHairColorItem;



for (let i = 0; i < maxHairColor; i++) hairColors.push(i.toString());
for (let i = 0; i <= 100; i++) similarities.push(i + "%");
for (let i = -180.0; i <= 180.0; i += 5.0) angles.push(i.toFixed(1));
for (let i = 0; i < maxBlushColor; i++) blushColors.push(i.toString());
for (let i = 0; i < maxLipstickColor; i++) lipstickColors.push(i.toString());

for (let i = -1.0; i <= 1.01; i += 0.01) features.push(i.toFixed(2));
for (let i = 0; i <= 100; i++) opacities.push(i + "%");


const MenuPoint = new NativeUI.Point(50, 50);

var clothesMainMenu = new NativeUI.Menu("Kleidung", "", MenuPoint);
clothesMainMenu.Visible = false;
clothesMainMenu.AddItem(new NativeUI.UIMenuItem("Einfaches", "Ein einfaches Outfit."));
clothesMainMenu.AddItem(new NativeUI.UIMenuItem("Ordentlich", "Ein ordentliches Outfit"));
clothesMainMenu.AddItem(new NativeUI.UIMenuItem("Anzug", "Ein einfacher Anzug für angehende Geschäftsmänner"));
clothesMainMenu.AddItem(new NativeUI.UIMenuItem("Outfit auswählen", "Bedenke deine Entscheidung ist einmalig"));

var creatorMainMenu = new NativeUI.Menu("Creator", "", MenuPoint);
//mp.events.callRemote("clientConsoleLog", "creatorMainMenu geladen");
creatorMainMenu.Visible = false;
let genderItem = new NativeUI.UIMenuListItem("Geschlecht", "~r~Dies setzt deine Veränderungen zurück.", new NativeUI.ItemsCollection(["Male", "Female"]));
creatorMainMenu.AddItem(genderItem);
creatorMainMenu.AddItem(new NativeUI.UIMenuItem("Eltern", "Deine Eltern."));
creatorMainMenu.AddItem(new NativeUI.UIMenuItem("Gesicht", "Dein Gesicht."));
creatorMainMenu.AddItem(new NativeUI.UIMenuItem("Aussehen", "Dein Aussehen."));
creatorMainMenu.AddItem(new NativeUI.UIMenuItem("Haare & Farben", "Deine Haare und Farben."));
creatorMainMenu.AddItem(new NativeUI.UIMenuItem("Einreisen", "Erstelle deinen Charakter."));
for (let i = -180.0; i <= 180.0; i += 5.0) angles.push(i.toFixed(1));
let angleItem = new NativeUI.UIMenuListItem("Rotation", "", new NativeUI.ItemsCollection(angles));
creatorMainMenu.AddItem(angleItem);

let creatorParentsMenu = new NativeUI.Menu("Eltern", "", MenuPoint);
creatorParentsMenu.Visible = false;

let fatherItem = new NativeUI.UIMenuListItem("Vater", "Dein Vater.", new NativeUI.ItemsCollection(fatherNames));
let motherItem = new NativeUI.UIMenuListItem("Mutter", "Deine Mutter.", new NativeUI.ItemsCollection(motherNames));
let similarityItem = new NativeUI.UIMenuListItem("Ähnlichkeit", "Ähnlichkeit zu den Eltern.\n(weniger = mutter, höher = vater)", new NativeUI.ItemsCollection(similarities));
let skinSimilarityItem = new NativeUI.UIMenuListItem("Hautfarbe", "Ähnlichkeit zu den Eltern.\n(weniger = mutter, höher = vater)", new NativeUI.ItemsCollection(similarities));
creatorParentsMenu.AddItem(fatherItem);
creatorParentsMenu.AddItem(motherItem);
creatorParentsMenu.AddItem(similarityItem);
creatorParentsMenu.AddItem(skinSimilarityItem);
creatorParentsMenu.AddItem(new NativeUI.UIMenuItem("Randomize", "~r~Zufällig generieren."));


// Charcreator => Hair zeugs
let creatorHairMenu = new NativeUI.Menu("Haare & Farben", "", MenuPoint);
creatorHairMenu.Visible = false;
fillHairMenu();

let creatorAppearanceMenu = new NativeUI.Menu("Aussehen", "", MenuPoint);
creatorAppearanceMenu.Visible = false;

let creatorFeaturesMenu = new NativeUI.Menu("Gesicht", "", MenuPoint);
creatorFeaturesMenu.Visible = false;


function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function colorForOverlayIdx(index) {
    let color;

    switch (index) {
        case 1:
            color = beardColorItem.Index;
            break;

        case 2:
            color = eyebrowColorItem.Index;
            break;

        case 5:
            color = blushColorItem.Index;
            break;

        case 8:
            color = lipstickColorItem.Index;
            break;

        case 10:
            color = chestHairColorItem.Index;
            break;

        default:
            color = 0;
    }

    return color;
}

function updateParents() {
    game.setPedHeadBlendData(game.playerPedId(), fatherItem.Index, motherItem.Index, 0, fatherItem.Index, motherItem.Index, 0, 1.00 - similarityItem.Index, 1.00 - skinSimilarityItem.Index, 0, 0);
    /*mp.players.local.setHeadBlendData(
        // shape
        mothers.mothers[motherItem.Index],
        fathers.fathers[fatherItem.Index],
        0,

        // skin
        mothers.mothers[motherItem.Index],
        fathers.fathers[fatherItem.Index],
        0,

        // mixes
        similarityItem.Index * 0.01,
        skinSimilarityItem.Index * 0.01,
        0.0,

        false
    );*/
}

function updateFaceFeature(index) {
    game.setPedFaceFeature(game.playerPedId(), index, featureItems[index].SelectedValue);
    //mp.players.local.setFaceFeature(index, parseFloat(featureItems[index].SelectedValue));
}

function updateAppearance(index) {
    let overlayID = (appearanceItems[index].Index == 0) ? 255 : appearanceItems[index].Index - 1;
    //mp.players.local.setHeadOverlay(index, overlayID, appearanceOpacityItems[index].Index * 0.01, colorForOverlayIdx(index), 0);
    game.setPedHeadOverlay(game.playerPedId(), index, overlayID, appearanceOpacityItems[index].Index * 0.01);
}


function fillHairMenu() {
    hairItem = new NativeUI.UIMenuListItem("Haare", "Deine Haare.", new NativeUI.ItemsCollection(hairList[currentGender].map(h => h.Name)));
    creatorHairMenu.AddItem(hairItem);

    hairColorItem = new NativeUI.UIMenuListItem("Haar Farbe", "Deine Haarfarbe.", new NativeUI.ItemsCollection(hairColors));
    creatorHairMenu.AddItem(hairColorItem);

    hairHighlightItem = new NativeUI.UIMenuListItem("Haar Highlight Farbe", "Deine Haar Highlight Farbe.", new NativeUI.ItemsCollection(hairColors));
    creatorHairMenu.AddItem(hairHighlightItem);

    eyebrowColorItem = new NativeUI.UIMenuListItem("Augenbrauen Farbe", "Deine Augenbrauen Farbe.", new NativeUI.ItemsCollection(hairColors));
    creatorHairMenu.AddItem(eyebrowColorItem);

    beardColorItem = new NativeUI.UIMenuListItem("Bart Farbe", "Deine Bart Farbe.", new NativeUI.ItemsCollection(hairColors));
    creatorHairMenu.AddItem(beardColorItem);

    eyeColorItem = new NativeUI.UIMenuListItem("Augen Farbe", "Deine Augenfarbe.", new NativeUI.ItemsCollection(eyeColors));
    creatorHairMenu.AddItem(eyeColorItem);

    blushColorItem = new NativeUI.UIMenuListItem("Rötungsfarbe", "Deine Rötungsfarbe.", new NativeUI.ItemsCollection(blushColors));
    creatorHairMenu.AddItem(blushColorItem);

    lipstickColorItem = new NativeUI.UIMenuListItem("Lippenstift Farbe", "Deine Lippenstift Farbe.", new NativeUI.ItemsCollection(lipstickColors));
    creatorHairMenu.AddItem(lipstickColorItem);

    chestHairColorItem = new NativeUI.UIMenuListItem("Körper Haar Farbe", "Deine Körper Haar Farbe.", new NativeUI.ItemsCollection(hairColors));
    creatorHairMenu.AddItem(chestHairColorItem);

    creatorHairMenu.AddItem(new NativeUI.UIMenuItem("Randomize", "~r~Zufällig generieren."));
    creatorHairMenu.AddItem(new NativeUI.UIMenuItem("Zurücksetzen", "~r~Einstellung zurücksetzen."));
}

function updateHairAndColors() {
    //mp.players.local.setComponentVariation(2, hairList.hairList[currentGender][hairItem.Index].ID, 0, 2);
    game.setPedComponentVariation(game.playerPedId(), 2, hairList[currentGender][hairItem.Index].ID, 0, 0);
    //mp.players.local.setHairColor(hairColorItem.Index, hairHighlightItem.Index);
    game.setPedHairColor(game.playerPedId(), hairColorItem.Index, hairHighlightItem.Index);
    //mp.players.local.setEyeColor(eyeColorItem.Index);
    game.setPedEyeColor(game.playerPedId(), eyeColorItem.Index);
    //mp.players.local.setHeadOverlayColor(1, 1, beardColorItem.Index, 0);
    //mp.players.local.setHeadOverlayColor(2, 1, eyebrowColorItem.Index, 0);
    game.setPedHeadOverlayColor(game.playerPedId(), 2, 1, eyebrowColorItem.Index, 0);
    //mp.players.local.setHeadOverlayColor(5, 2, blushColorItem.Index, 0);
    game.setPedHeadOverlayColor(game.playerPedId(), 5, 2, blushColorItem.Index, 0);
    //mp.players.local.setHeadOverlayColor(8, 2, lipstickColorItem.Index, 0);
    game.setPedHeadOverlayColor(game.playerPedId(), 8, 2, lipstickColorItem.Index, 0);
    //mp.players.local.setHeadOverlayColor(10, 1, chestHairColorItem.Index, 0);
    game.setPedHeadOverlayColor(game.playerPedId(), 10, 1, chestHairColorItem.Index, 0);
}


function resetParentsMenu(refresh = false) {
    fatherItem.Index = 0;
    motherItem.Index = 0;
    similarityItem.Index = (currentGender == 0) ? 100 : 0;
    skinSimilarityItem.Index = (currentGender == 0) ? 100 : 0;

    updateParents();
    if (refresh) creatorParentsMenu.RefreshIndex();
}

function resetFeaturesMenu(refresh = false) {
    for (let i = 0; i < featureNames.length; i++) {
        featureItems[i].Index = 100;
        updateFaceFeature(i);
    }

    if (refresh) creatorFeaturesMenu.RefreshIndex();
}

function resetAppearanceMenu(refresh = false) {
    for (let i = 0; i < appearanceNames.length; i++) {
        appearanceItems[i].Index = 0;
        appearanceOpacityItems[i].Index = 100;
        updateAppearance(i);
    }

    if (refresh) creatorAppearanceMenu.RefreshIndex();
}

function resetHairAndColorsMenu(refresh = false) {
    hairItem.Index = 0;
    hairColorItem.Index = 0;
    hairHighlightItem.Index = 0;
    eyebrowColorItem.Index = 0;
    beardColorItem.Index = 0;
    eyeColorItem.Index = 0;
    blushColorItem.Index = 0;
    lipstickColorItem.Index = 0;
    chestHairColorItem.Index = 0;
    updateHairAndColors();

    if (refresh) creatorHairMenu.RefreshIndex();
}


// Charcreator = 1
creatorMainMenu.ListChange.on((item, listIndex) => {
    if (item == genderItem) {
        currentGender = listIndex;
        alt.emitServer("creator_GenderChange", listIndex);

        alt.setTimeout(() => {
            //mp.players.local.clearTasksImmediately();
            //applyCreatorOutfit();
            angleItem.Index = 0;
            resetParentsMenu(true);
            resetFeaturesMenu(true);
            resetAppearanceMenu(true);

            creatorHairMenu.Clear();
            fillHairMenu();
            creatorHairMenu.RefreshIndex();
        }, 200);
    } else if (item == angleItem) {
        //mp.players.local.setHeading(parseFloat(angleItem.SelectedValue));
        //mp.players.local.clearTasksImmediately();
    }
});

// Charcreator = 2
creatorMainMenu.ItemSelect.on((item, index) => {
    switch (index) {
        case 1:
            creatorMainMenu.Visible = false;
            creatorParentsMenu.Visible = true;
            break;

        case 2:
            creatorMainMenu.Visible = false;
            creatorFeaturesMenu.Visible = true;
            break;

        case 3:
            creatorMainMenu.Visible = false;
            creatorAppearanceMenu.Visible = true;
            break;

        case 4:
            creatorMainMenu.Visible = false;
            creatorHairMenu.Visible = true;
            break;
        case 5:

            let parentData = {
                Father: fatherItem.Index,
                Mother: motherItem.Index,
                Similarity: similarityItem.Index,
                SkinSimilarity: skinSimilarityItem.Index
            };

            for (let i = 0; i < featureItems.length; i++) featureData.push(parseFloat(featureItems[i].SelectedValue));

            for (let i = 0; i < appearanceItems.length; i++) appearanceData.push({
                Value: ((appearanceItems[i].Index == 0) ? 255 : appearanceItems[i].Index - 1),
                Opacity: appearanceOpacityItems[i].Index * 0.01
            });

            let hairAndColors = [
                hairList[currentGender][hairItem.Index].ID,
                hairColorItem.Index,
                hairHighlightItem.Index,
                eyebrowColorItem.Index,
                beardColorItem.Index,
                eyeColorItem.Index,
                blushColorItem.Index,
                lipstickColorItem.Index,
                chestHairColorItem.Index
            ];

            alt.emitServer("createCharacter", JSON.stringify({
                "Gender": currentGender,
                "Parents": parentData,
                "Features": featureData,
                "Appearance": appearanceData,
                "Hair": hairAndColors
            }));
            break;
    }
});

// Charcreator = Close Menu
creatorMainMenu.MenuClose.on(() => {
    creatorMainMenu.Visible = true;
});

// Charctraor => Hair 1
creatorHairMenu.ItemSelect.on((item, index) => {
    switch (item.Text) {
        case "Randomize":
            hairItem.Index = getRandomInt(0, hairList[currentGender].length - 1);
            hairColorItem.Index = getRandomInt(0, maxHairColor);
            hairHighlightItem.Index = getRandomInt(0, maxHairColor);
            eyebrowColorItem.Index = getRandomInt(0, maxHairColor);
            beardColorItem.Index = getRandomInt(0, maxHairColor);
            eyeColorItem.Index = getRandomInt(0, maxEyeColor);
            blushColorItem.Index = getRandomInt(0, maxBlushColor);
            lipstickColorItem.Index = getRandomInt(0, maxLipstickColor);
            chestHairColorItem.Index = getRandomInt(0, maxHairColor);
            updateHairAndColors();
            break;

        case "Reset":
            resetHairAndColorsMenu();
            break;
    }
});

// Charctraor => Hair 2
creatorHairMenu.ListChange.on((item, listIndex) => {
    if (item == hairItem) {
        let hairStyle = hairList[currentGender][listIndex];
        //mp.players.local.setComponentVariation(2, hairStyle.ID, 0, 2);
        game.setPedComponentVariation(game.playerPedId(), 2, hairStyle.ID, 0, 0);
    } else {
        switch (creatorHairMenu.CurrentSelection) {
            case 1: // hair color
                //mp.players.local.setHairColor(listIndex, hairHighlightItem.Index);
                game.setPedHairColor(game.playerPedId(), listIndex, hairHighlightItem.Index);
                break;

            case 2: // hair highlight color
                mp.players.local.setHairColor(hairColorItem.Index, listIndex);
                game.setPedHairColor(game.playerPedId(), hairColorItem.Index, listIndex);
                break;

            case 3: // eyebrow color
                //mp.players.local.setHeadOverlayColor(2, 1, listIndex, 0);
                game.setPedHeadOverlayColor(game.playerPedId(), 2, 1, listIndex, 0);
                break;

            case 4: // facial hair color
                //mp.players.local.setHeadOverlayColor(1, 1, listIndex, 0);
                game.setPedHeadOverlayColor(game.playerPedId(), 1, 1, listIndex, 0);
                break;

            case 5: // eye color
                //mp.players.local.setEyeColor(listIndex);
                game.setPedEyeColor(game.playerPedId(), listIndex);
                break;

            case 6: // blush color
                //mp.players.local.setHeadOverlayColor(5, 2, listIndex, 0);
                game.setPedHeadOverlayColor(game.playerPedId(), 5, 2, listIndex, 0);
                break;

            case 7: // lipstick color
                //mp.players.local.setHeadOverlayColor(8, 2, listIndex, 0);
                game.setPedHeadOverlayColor(game.playerPedId(), 8, 2, listIndex, 0);
                break;

            case 8: // chest hair color
                //mp.players.local.setHeadOverlayColor(10, 1, listIndex, 0);
                game.setPedHeadOverlayColor(game.playerPedId(), 10, 1, listIndex, 0);
                break;
        }
    }
});

for (let i = 0; i < appearanceNames.length; i++) {
    let items = [];
    for (let i = 0; i < appearanceItemNames.length; i++) items.push(i.toString());
    let tempAppearanceItem = new NativeUI.UIMenuListItem(appearanceNames[i], "", new NativeUI.ItemsCollection(items));
    appearanceItems.push(tempAppearanceItem);
    creatorAppearanceMenu.AddItem(tempAppearanceItem);

    let tempAppearanceOpacityItem = new NativeUI.UIMenuListItem(appearanceNames[i] + " Opacity", "", new NativeUI.ItemsCollection(opacities));
    tempAppearanceOpacityItem.Index = 100;
    appearanceOpacityItems.push(tempAppearanceOpacityItem);
    creatorAppearanceMenu.AddItem(tempAppearanceOpacityItem);
}
creatorAppearanceMenu.AddItem(new NativeUI.UIMenuItem("Randomize", "~r~Zufällig Generieren."));
creatorAppearanceMenu.AddItem(new NativeUI.UIMenuItem("Zurücksetzen", "~r~Einstellung zurücksetzen."));

//Rdm zeugs das da sein muss, das funkt 1
creatorHairMenu.ParentMenu = creatorMainMenu;
creatorHairMenu.Visible = false;
creatorMenus.push(creatorHairMenu);

// Charcreator => Apperance 1
creatorAppearanceMenu.ItemSelect.on((item, index) => {
    switch (item.Text) {
        case "Randomize":
            for (let i = 0; i < appearanceNames.length; i++) {
                appearanceItems[i].Index = getRandomInt(0, game.getPedHeadOverlayValue(alt.Player.local.scriptID, i) - 1);
                appearanceOpacityItems[i].Index = getRandomInt(0, 100);
                updateAppearance(i);
            }
            break;

        case "Reset":
            resetAppearanceMenu();
            break;
    }
});

// Charcreator => Apperance 2
creatorAppearanceMenu.ListChange.on((item, listIndex) => {
    let idx = (creatorAppearanceMenu.CurrentSelection % 2 == 0) ? (creatorAppearanceMenu.CurrentSelection / 2) : Math.floor(creatorAppearanceMenu.CurrentSelection / 2);
    updateAppearance(idx);
});

//Rdm zeugs das da sein muss, das funkt 2
creatorAppearanceMenu.ParentMenu = creatorMainMenu;
creatorAppearanceMenu.Visible = false;
creatorMenus.push(creatorAppearanceMenu);

// Charcreator => Parents 1
creatorParentsMenu.ItemSelect.on((item, index) => {
    switch (item.Text) {
        case "Randomize":
            fatherItem.Index = getRandomInt(0, fathers.length - 1);
            motherItem.Index = getRandomInt(0, mothers.length - 1);
            similarityItem.Index = getRandomInt(0, 100);
            skinSimilarityItem.Index = getRandomInt(0, 100);
            updateParents();
            break;
    }
});

// Charcreator => Parents 2
creatorParentsMenu.ListChange.on((item, listIndex) => {
    updateParents();
});

//Rdm zeugs das da sein muss, das funkt 3
creatorParentsMenu.ParentMenu = creatorMainMenu;
creatorParentsMenu.Visible = false;
creatorMenus.push(creatorParentsMenu);

// Charcreator => Features 1
creatorFeaturesMenu.ItemSelect.on((item, index) => {
    switch (item.Text) {
        case "Randomize":
            for (let i = 0; i < featureNames.length; i++) {
                featureItems[i].Index = getRandomInt(0, 200);
                updateFaceFeature(i);
            }
            break;

        case "Reset":
            resetFeaturesMenu();
            break;
    }
});

// Charcreator => Features 2
creatorFeaturesMenu.ListChange.on((item, listIndex) => {
    updateFaceFeature(featureItems.indexOf(item));
});

for (let i = 0; i < featureNames.length; i++) {
    let tempFeatureItem = new NativeUI.UIMenuListItem(featureNames[i], "", new NativeUI.ItemsCollection(features));
    tempFeatureItem.Index = 100;
    featureItems.push(tempFeatureItem);
    creatorFeaturesMenu.AddItem(tempFeatureItem);
}

creatorFeaturesMenu.AddItem(new NativeUI.UIMenuItem("Randomize", "~r~Zufällige Generierung."));
creatorFeaturesMenu.AddItem(new NativeUI.UIMenuItem("Zurücksetzen", "~r~Einstellung zurücksetzen."));

//Rdm zeugs das da sein muss, das funkt 4
creatorFeaturesMenu.ParentMenu = creatorMainMenu;
creatorFeaturesMenu.Visible = false;
creatorMenus.push(creatorFeaturesMenu);


let camera = null;
alt.onServer("startCreator", () => {
    creatorMainMenu.Visible = true;
    alt.emitServer('setCharacterIntoCreator');
    camera = game.createCamWithParams("DEFAULT_SCRIPTED_CAMERA", 152.3708, -1001.75, -98.45, -20.0, 0.0, 0.0, 90, false, 2);
    game.setCamActive(camera, true);
    game.renderScriptCams(true, false, 0, false, false);
    game.displayHud(false);
    game.displayRadar(false);

});
alt.onServer("stopCreator", () => {
    creatorMainMenu.Visible = false;
    game.displayHud(true);
    game.displayRadar(true);
});
alt.on("genderChange", (player) => {
    //mp.players.local.setAlpha(255);
});