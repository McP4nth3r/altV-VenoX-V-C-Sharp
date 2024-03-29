const PRICE_PIZZA = 20;
const PRICE_HAMBURGER = 10;
const PRICE_SANDWICH = 5;

let tunningComponents = [];
let tattooZones = [];
let clothesTypes = [];
let selectedOptions = [];
let purchasedAmount = 1;
let multiplier = 0.0;
let selected = undefined;
let drawable = undefined;
let messagesLoaded = false;
let timeout = undefined;

$(document).ready(function () {
    i18next.use(window.i18nextXHRBackend).init({
        backend: {
            loadPath: '../i18n/en.json'
        }
    }, function (err, t) {
        jqueryI18next.init(i18next, $);
        messagesLoaded = true;
    });
});

function populateBusinessItems(businessItemsJson, businessName, multiplier) {
    // Check if the messages are loaded
    if (messagesLoaded) {
        // Initialize the values
        purchasedAmount = 1;
        selected = undefined;

        // Get items to show
        let businessItemsArray = JSON.parse(businessItemsJson);
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Show business name
        header.textContent = businessName;

        for (let i = 0; i < businessItemsArray.length; i++) {
            let item = businessItemsArray[i];

            let itemContainer = document.createElement('div');
            let imageContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemAmountContainer = document.createElement('div');
            let amountTextContainer = document.createElement('div');
            let addSubstractContainer = document.createElement('div');
            let itemImage = document.createElement('img');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');
            let itemAmount = document.createElement('span');
            let itemAdd = document.createElement('span');
            let itemSubstract = document.createElement('span');

            itemContainer.classList.add('item-row');
            imageContainer.classList.add('item-image');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemAmountContainer.classList.add('item-amount-container', 'hidden');
            amountTextContainer.classList.add('item-amount-desc-container');
            addSubstractContainer.classList.add('item-add-substract-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');
            itemAmount.classList.add('item-amount-description');
            itemAdd.classList.add('item-adder');
            itemSubstract.classList.add('item-substract', 'hidden');

            itemImage.src = '../img/inventory/' + item.hash + '.png';
            itemDescription.textContent = item.description;
            itemPrice.innerHTML = '<b>' + i18next.t('general.unit-price') + '</b>' + Math.round(item.products * parseFloat(multiplier)) + '$';
            itemAmount.innerHTML = '<b>' + i18next.t('general.amount') + '</b>' + purchasedAmount;
            itemAdd.textContent = '+';
            itemSubstract.textContent = '-';

            itemContainer.onclick = (function () {
                // Check if the item is not selected
                if (selected !== i) {
                    // Check if there was any item selected
                    if (selected != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[selected];
                        let previousAmountNode = findFirstChildByClass(previousSelected, 'item-amount-container');
                        previousSelected.classList.remove('active-item');
                        previousAmountNode.classList.add('hidden');
                    }

                    // Select the item
                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    let currentAmountNode = findFirstChildByClass(currentSelected, 'item-amount-container');
                    currentSelected.classList.add('active-item');
                    currentAmountNode.classList.remove('hidden');

                    // Store the item and initialize the amount
                    purchasedAmount = 1;
                    selected = i;

                    // Update the element's text
                    itemAmount.innerHTML = '<b>' + i18next.t('general.amount') + '</b>' + purchasedAmount;
                    document.getElementsByClassName('item-adder')[selected].classList.remove('hidden');
                    document.getElementsByClassName('item-substract')[selected].classList.add('hidden');
                }
            });

            itemAdd.onclick = (function () {
                // Add one unit
                purchasedAmount++;

                let adderButton = document.getElementsByClassName('item-adder')[selected];
                let substractButton = document.getElementsByClassName('item-substract')[selected];

                if (purchasedAmount == 10) {
                    // Maximum amount reached
                    adderButton.classList.add('hidden');
                } else if (substractButton.classList.contains('hidden') === true) {
                    // Show the button
                    substractButton.classList.remove('hidden');
                }

                // Update the amount
                let amountSpan = document.getElementsByClassName('item-amount-description')[selected];
                amountSpan.innerHTML = '<b>' + i18next.t('general.amount') + '</b>' + purchasedAmount;
            });

            itemSubstract.onclick = (function () {
                // Substract one unit
                purchasedAmount--;

                let adderButton = document.getElementsByClassName('item-adder')[selected];
                let substractButton = document.getElementsByClassName('item-substract')[selected];

                if (purchasedAmount == 1) {
                    // Minimum amount reached
                    substractButton.classList.add('hidden');
                } else if (adderButton.classList.contains('hidden') === true) {
                    // Show the button
                    adderButton.classList.remove('hidden');
                }

                // Update the amount
                let amountSpan = document.getElementsByClassName('item-amount-description')[selected];
                amountSpan.innerHTML = '<b>' + i18next.t('general.amount') + '</b>' + purchasedAmount;
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(imageContainer);
            itemContainer.appendChild(infoContainer);
            imageContainer.appendChild(itemImage);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
            purchaseContainer.appendChild(itemAmountContainer);
            itemAmountContainer.appendChild(amountTextContainer);
            amountTextContainer.appendChild(itemAmount);
            itemAmountContainer.appendChild(addSubstractContainer);
            addSubstractContainer.appendChild(itemAdd);
            addSubstractContainer.appendChild(itemSubstract);
        }

        // Add option buttons
        let purchaseButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        // Add classes for the buttons
        purchaseButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        // Add text for the buttons
        purchaseButton.textContent = i18next.t('general.purchase');
        cancelButton.textContent = i18next.t('general.exit');

        purchaseButton.onclick = (function () {
            // Check if the user purchased anything
            if (selected != undefined) {
                alt.emit('purchaseItem', selected, purchasedAmount);
            }
        });

        cancelButton.onclick = (function () {
            // Close the purchase window
            alt.emit('destroyBrowser');
        });

        options.appendChild(purchaseButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateBusinessItems(businessItemsJson, businessName, multiplier);
        }, 100);
    }
}

function populateTunningMenu(tunningComponentsJSON) {
    if (messagesLoaded) {
        // Add the title to the menu
        let header = document.getElementById('header');
        header.textContent = i18next.t('tunning.title');

        // Get the components list
        tunningComponents = JSON.parse(tunningComponentsJSON);

        // Show the main menu
        populateTunningHome();

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTunningMenu(tunningComponentsJSON);
        }, 100);
    }
}

function populateTunningHome() {
    if (messagesLoaded) {
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        selected = undefined;
        drawable = undefined;

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < tunningComponents.length; i++) {
            let group = tunningComponents[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            itemDescription.textContent = i18next.t(group.desc);

            itemContainer.onclick = (function () {
                selected = i;
                populateTunningComponents();
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let exitButton = document.createElement('div');

        exitButton.classList.add('single-button', 'cancel-button');
        exitButton.textContent = i18next.t('general.exit');

        exitButton.onclick = (function () {
            alt.emit('CloseTuningWindow');
        });

        options.appendChild(exitButton);

        clearTimeout(timeout);
    } else {
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTunningHome();
        }, 100);
    }
}

function populateTunningComponents() {
    if (messagesLoaded) {
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < tunningComponents[selected].components.length; i++) {
            let component = tunningComponents[selected].components[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');



            let costs = tunningComponents[selected].products;
            //Namen S
            if (component.desc == "Getriebe - 1") {
                itemDescription.textContent = "Straßen Getriebe";
                costs = 5500;
            } else if (component.desc == "Getriebe - 2") {
                itemDescription.textContent = "Sport Getriebe";
                costs = 11000;
            } else if (component.desc == "Getriebe - 3") {
                itemDescription.textContent = "Renn Getriebe";
                costs = 16500;
            } else if (component.desc == "Motor [ EMS ] - 1") {
                itemDescription.textContent = "EMS Verbesserung I [15% Mehr Leistung]";
                costs = 5500;
            } else if (component.desc == "Motor [ EMS ] - 2") {
                itemDescription.textContent = "EMS Verbesserung II [25% Mehr Leistung]";
                costs = 11000;
            } else if (component.desc == "Motor [ EMS ] - 3") {
                itemDescription.textContent = "EMS Verbesserung III [35% Mehr Leistung]";
                costs = 16500;
            } else if (component.desc == "Bremsen - 1") {
                itemDescription.textContent = "Bremsen Verbesserung I [15% Mehr Bremskraft]";
                costs = 5500;
            } else if (component.desc == "Bremsen - 2") {
                itemDescription.textContent = "Bremsen Verbesserung II [25% Mehr Bremskraft]";
                costs = 11000;
            } else if (component.desc == "Bremsen - 3") {
                itemDescription.textContent = "Bremsen Verbesserung III [35% Mehr Bremskraft]";
                costs = 16500;
            } else if (component.desc == "Tieferlegung - 1") {
                itemDescription.textContent = "Tieferlegung Stufe I";
                costs = 5500;
            } else if (component.desc == "Tieferlegung - 2") {
                itemDescription.textContent = "Tieferlegung Stufe II";
                costs = 11000;
            } else if (component.desc == "Tieferlegung - 3") {
                itemDescription.textContent = "Tieferlegung Stufe III";
                costs = 16500;
            } else if (component.desc == "Tieferlegung - 4") {
                itemDescription.textContent = "Tieferlegung Stufe IIII";
                costs = 16500;
            } else if (component.desc == "Turbolader - 1") {
                itemDescription.textContent = "Turbolader [35% Mehr Beschleunigung]";
                costs = 15000;
            } else {
                itemDescription.textContent = component.desc;
            }


            itemPrice.innerHTML = '<b>Kosten : </b>' + costs + '$';
            itemContainer.onclick = (function () {
                if (drawable !== i) {
                    if (drawable != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[drawable];
                        previousSelected.classList.remove('active-item');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    drawable = i;
                    // Update the vehicle's tunning
                    alt.emit('addVehicleComponent', tunningComponents[selected].slot, drawable);
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
        }

        // Add the buttons
        let purchaseButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        purchaseButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        purchaseButton.textContent = i18next.t('general.purchase');
        cancelButton.textContent = i18next.t('general.back');;

        purchaseButton.onclick = (function () {
            if (drawable != undefined) {
                alt.emit('Purchase_Tuning_C', tunningComponents[selected].slot, drawable);
            }
        });

        cancelButton.onclick = (function () {
            alt.emit('Reload_Tuning_C');
            // Back to the home menu
            populateTunningHome();
        });

        options.appendChild(purchaseButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTunningComponents();
        }, 100);
    }
}


function populateCharacterList(charactersJson) {
    if (messagesLoaded) {
        // Get the container nodes
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Get the players list
        let characters = JSON.parse(charactersJson);

        // Add the heading text
        header.textContent = i18next.t('character.title');

        for (let i = 0; i < characters.length; i++) {
            // Get the current character
            let character = characters[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            // Add the name
            itemDescription.textContent = character;

            itemContainer.onclick = (function () {
                // Load the selected character
                alt.emit('loadCharacter', character);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let createButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        createButton.classList.add('double-button', 'accept-button', 'double-button_greenaccept', 'accept-button_greenline');
        cancelButton.classList.add('double-button', 'cancel-button');

        createButton.textContent = i18next.t('character.create');
        cancelButton.textContent = i18next.t('general.exit');

        createButton.onclick = (function () {
            // Show the character creation menu
            alt.emit('showCharacterCreationMenu');
        });

        cancelButton.onclick = (function () {
            // Close the menu
            alt.emit('destroyBrowser');
        });

        options.appendChild(createButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded		
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateCharacterList(charactersJson);
        }, 100);
    }
}

function populateClothesShopMenu(clothesTypeArray, businessName, priceMultiplier) {
    if (messagesLoaded) {
        // Add the business name to the header
        let header = document.getElementById('header');
        header.textContent = businessName;

        // Load the clothes list
        clothesTypes = JSON.parse(clothesTypeArray);
        multiplier = priceMultiplier;

        // Show the main menu
        populateClothesShopHome();

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateClothesShopMenu(clothesTypeArray, businessName, priceMultiplier);
        }, 100);
    }
}

function populateClothesShopHome() {
    if (messagesLoaded) {
        // Get the container node
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        selected = undefined;
        drawable = undefined;

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < clothesTypes.length; i++) {
            // Get the current zone
            let type = clothesTypes[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            itemDescription.textContent = i18next.t(type.desc);

            itemContainer.onclick = (function () {
                selected = i;

                // Load the clothes from the zone
                alt.emit('getClothesByType', i);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let exitButton = document.createElement('div');

        exitButton.classList.add('single-button', 'cancel-button');
        exitButton.textContent = i18next.t('general.exit');

        exitButton.onclick = (function () {
            // Exit the menu
            alt.emit('CloseClotheShop_c');
        });

        options.appendChild(exitButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateClothesShopHome();
        }, 100);
    }
}

function populateTypeClothes(typeClothesJson) {
    if (messagesLoaded) {
        // Get the container node
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Get the clothes in the JSON object
        let typeClothesArray = JSON.parse(typeClothesJson);

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < typeClothesArray.length; i++) {
            let clothes = typeClothesArray[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemAmountContainer = document.createElement('div');
            let amountTextContainer = document.createElement('div');
            let addSubstractContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');
            let itemAmount = document.createElement('span');
            let itemAdd = document.createElement('span');
            let itemSubstract = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemAmountContainer.classList.add('item-amount-container', 'hidden');
            amountTextContainer.classList.add('item-amount-desc-container');
            addSubstractContainer.classList.add('item-add-substract-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');
            itemAmount.classList.add('item-amount-description');
            itemAdd.classList.add('item-adder');
            itemSubstract.classList.add('item-substract', 'hidden');

            itemDescription.textContent = clothes.description;
            itemPrice.innerHTML = '<b>' + i18next.t('general.price') + '</b>' + Math.round(clothes.products * multiplier) + '$';
            itemAdd.textContent = '+';
            itemSubstract.textContent = '-';

            itemContainer.onclick = (function () {
                if (drawable !== i) {

                    if (drawable != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[drawable];
                        let previousAmountNode = findFirstChildByClass(previousSelected, 'item-amount-container');
                        previousSelected.classList.remove('active-item');
                        previousAmountNode.classList.add('hidden');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    let currentAmountNode = findFirstChildByClass(currentSelected, 'item-amount-container');
                    currentSelected.classList.add('active-item');
                    currentAmountNode.classList.remove('hidden');

                    purchasedAmount = 0;
                    drawable = i;

                    itemAmount.innerHTML = '<b>' + i18next.t('clothes.variation') + '</b>' + purchasedAmount;

                    if (purchasedAmount < clothes.textures - 1) {
                        // Show add button
                        document.getElementsByClassName('item-adder')[drawable].classList.remove('hidden');
                    } else {
                        // Hide add button
                        document.getElementsByClassName('item-adder')[drawable].classList.add('hidden');
                    }
                    document.getElementsByClassName('item-substract')[drawable].classList.add('hidden');

                    // Replace the clothes on the character
                    alt.emit('replacePlayerClothes', drawable, purchasedAmount);
                }
            });

            itemAdd.onclick = (function () {
                // Get next variation
                purchasedAmount++;

                let adderButton = document.getElementsByClassName('item-adder')[drawable];
                let substractButton = document.getElementsByClassName('item-substract')[drawable];

                if (purchasedAmount == clothes.textures - 1) {
                    // Maximum reached
                    adderButton.classList.add('hidden');
                } else if (substractButton.classList.contains('hidden') === true) {
                    // Show the button
                    substractButton.classList.remove('hidden');
                }

                let amountSpan = document.getElementsByClassName('item-amount-description')[drawable];
                amountSpan.innerHTML = '<b>' + i18next.t('clothes.variation') + '</b>' + purchasedAmount;

                // Replace the clothes on the character
                alt.emit('replacePlayerClothes', drawable, purchasedAmount);
            });

            itemSubstract.onclick = (function () {
                // Get previous variation
                purchasedAmount--;

                let adderButton = document.getElementsByClassName('item-adder')[drawable];
                let substractButton = document.getElementsByClassName('item-substract')[drawable];

                if (purchasedAmount == 0) {
                    // Minimum reached
                    substractButton.classList.add('hidden');
                } else if (adderButton.classList.contains('hidden') === true) {
                    // Show the button
                    adderButton.classList.remove('hidden');
                }

                let amountSpan = document.getElementsByClassName('item-amount-description')[drawable];
                amountSpan.innerHTML = '<b>' + i18next.t('clothes.variation') + '</b>' + purchasedAmount;

                // Replace the clothes on the character
                alt.emit('replacePlayerClothes', drawable, purchasedAmount);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
            purchaseContainer.appendChild(itemAmountContainer);
            itemAmountContainer.appendChild(amountTextContainer);
            amountTextContainer.appendChild(itemAmount);
            itemAmountContainer.appendChild(addSubstractContainer);
            addSubstractContainer.appendChild(itemAdd);
            addSubstractContainer.appendChild(itemSubstract);
        }

        let purchaseButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        purchaseButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        purchaseButton.textContent = i18next.t('general.purchase');
        cancelButton.textContent = i18next.t('general.back');

        purchaseButton.onclick = (function () {
            if (selected != undefined) {
                alt.emit('purchaseClothes', drawable, purchasedAmount);
            }
        });

        cancelButton.onclick = (function () {
            // Back to the home menu
            populateClothesShopHome();

            // Clear player's clothes
            alt.emit('clearClothes', drawable);
        });

        options.appendChild(purchaseButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTypeClothes(typeClothesJson);
        }, 100);
    }
}

function populateTattooMenu(tattooZoneArray, businessName, priceMultiplier) {
    if (messagesLoaded) {
        // Set the business name as header
        let header = document.getElementById('header');
        header.textContent = businessName;

        // Get tattoo zones
        tattooZones = JSON.parse(tattooZoneArray);
        multiplier = priceMultiplier;

        // Show main menu
        populateTattooHome();

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTattooMenu(tattooZoneArray, businessName, priceMultiplier);
        }, 100);
    }
}

function populateTattooHome() {
    if (messagesLoaded) {
        // Get the container nodes
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        selected = undefined;
        drawable = undefined;

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < tattooZones.length; i++) {
            // Get the zone
            let zone = tattooZones[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            itemDescription.textContent = i18next.t(zone);

            itemContainer.onclick = (function () {
                selected = i;

                // Load the tattoos for the zone
                alt.emit('getZoneTattoos', i);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let exitButton = document.createElement('div');

        exitButton.classList.add('single-button', 'cancel-button');
        exitButton.textContent = i18next.t('general.exit');

        exitButton.onclick = (function () {
            // Exit the menu
            alt.emit('exitTattooShop');
        });

        options.appendChild(exitButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTattooHome();
        }, 100);
    }
}

function populateZoneTattoos(zoneTattooJson) {
    if (messagesLoaded) {
        // Get the container nodes
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Get the tattoos from the zone
        let zoneTattooArray = JSON.parse(zoneTattooJson);

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < zoneTattooArray.length; i++) {
            // Get the tattoo
            let tattoo = zoneTattooArray[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');

            itemDescription.textContent = tattoo.name;
            itemPrice.innerHTML = '<b>' + i18next.t('general.price') + '</b>' + Math.round(tattoo.price * multiplier) + '$';

            itemContainer.onclick = (function () {
                if (drawable !== i) {

                    if (drawable != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[drawable];
                        previousSelected.classList.remove('active-item');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    drawable = i;

                    // Update the tattoos
                    alt.emit('addPlayerTattoo', drawable);
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
        }

        let purchaseButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        purchaseButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        purchaseButton.textContent = i18next.t('general.purchase');
        cancelButton.textContent = i18next.t('general.back');

        purchaseButton.onclick = (function () {
            if (selected != undefined) {
                alt.emit('purchaseTattoo', selected, drawable);
            }
        });

        cancelButton.onclick = (function () {
            //  Back to the main menu
            populateTattooHome();

            // Clear the tattoos on the player
            alt.emit('clearTattoos');
        });

        options.appendChild(purchaseButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateZoneTattoos(zoneTattooJson);
        }, 100);
    }
}

function populateHairdresserMenu(faceOptionsJson, selectedFaceJson, businessName) {
    if (messagesLoaded) {
        // Get the container nodes
        let faceOptions = JSON.parse(faceOptionsJson);
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        header.textContent = businessName;
        selectedOptions = JSON.parse(selectedFaceJson);

        for (let i = 0; i < faceOptions.length; i++) {
            let face = faceOptions[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let itemAmountContainer = document.createElement('div');
            let amountTextContainer = document.createElement('div');
            let addSubstractContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemAmount = document.createElement('span');
            let itemAdd = document.createElement('span');
            let itemSubstract = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            itemAmountContainer.classList.add('item-amount-container');
            amountTextContainer.classList.add('item-amount-desc-container');
            addSubstractContainer.classList.add('item-add-substract-container');
            itemDescription.classList.add('item-description');
            itemAmount.classList.add('item-amount-description');
            itemAdd.classList.add('item-adder');
            itemSubstract.classList.add('item-substract');

            if (selectedOptions[i] == face.minValue) {
                itemSubstract.classList.add('hidden');
            } else if (selectedOptions[i] == face.maxValue) {
                itemAdd.classList.add('hidden');
            }

            itemDescription.textContent = i18next.t(face.desc);
            itemAmount.innerHTML = '<b>' + i18next.t('character.type') + '</b>' + selectedOptions[i];
            itemAdd.textContent = '+';
            itemSubstract.textContent = '-';

            itemAdd.onclick = (function () {
                selectedOptions[i]++;

                let adderButton = document.getElementsByClassName('item-adder')[i];
                let substractButton = document.getElementsByClassName('item-substract')[i];

                if (selectedOptions[i] == face.maxValue) {
                    // Maximum reached
                    adderButton.classList.add('hidden');
                } else if (substractButton.classList.contains('hidden') === true) {
                    // Show the button
                    substractButton.classList.remove('hidden');
                }

                let amountSpan = document.getElementsByClassName('item-amount-description')[i];
                amountSpan.innerHTML = '<b>' + i18next.t('character.type') + '</b>' + selectedOptions[i];

                // Update the hair
                alt.emit('updateFacialHair', i, selectedOptions[i]);
            });

            itemSubstract.onclick = (function () {
                selectedOptions[i]--;

                let adderButton = document.getElementsByClassName('item-adder')[i];
                let substractButton = document.getElementsByClassName('item-substract')[i];

                if (selectedOptions[i] == face.minValue) {
                    // Minimum reached
                    substractButton.classList.add('hidden');
                } else if (adderButton.classList.contains('hidden') === true) {
                    // Show the button
                    adderButton.classList.remove('hidden');
                }

                let amountSpan = document.getElementsByClassName('item-amount-description')[i];
                amountSpan.innerHTML = '<b>' + i18next.t('character.type') + '</b>' + selectedOptions[i];

                // Update the hair
                alt.emit('updateFacialHair', i, selectedOptions[i]);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(itemAmountContainer);
            itemAmountContainer.appendChild(amountTextContainer);
            amountTextContainer.appendChild(itemAmount);
            itemAmountContainer.appendChild(addSubstractContainer);
            addSubstractContainer.appendChild(itemAdd);
            addSubstractContainer.appendChild(itemSubstract);
        }

        let acceptButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        acceptButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        acceptButton.textContent = i18next.t('general.accept');
        cancelButton.textContent = i18next.t('general.exit');

        acceptButton.onclick = (function () {
            // Save the changes
            alt.emit('applyHairdresserChanges');
        });

        cancelButton.onclick = (function () {
            // Cancel the changes
            alt.emit('cancelHairdresserChanges');
            alt.emit('destroyBrowser');
        });

        options.appendChild(acceptButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateHairdresserMenu(faceOptionsJson, selectedFaceJson, businessName);
        }, 100);
    }
}

function populateTownHallMenu(townHallOptionsJson) {
    if (messagesLoaded) {
        let townHallOptions = JSON.parse(townHallOptionsJson);
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        header.textContent = i18next.t('townhall.title');
        selected = undefined;

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < townHallOptions.length; i++) {
            let townHall = townHallOptions[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');

            itemDescription.textContent = i18next.t(townHall.desc);

            if (townHall.price > 0) {
                // If there's any price, show it
                itemPrice.innerHTML = '<b>' + i18next.t('general.price') + '</b>' + townHall.price + '$';
            }

            itemContainer.onclick = (function () {
                if (selected !== i) {

                    if (selected != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[selected];
                        previousSelected.classList.remove('active-item');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    selected = i;

                    // Change the text in the button
                    let leftButton = document.getElementsByClassName('accept-button')[0];
                    leftButton.textContent = townHall.price > 0 ? i18next.t('townhall.pay') : i18next.t('townhall.check');
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
        }

        let acceptButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        acceptButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        // Añadimos el texto de los botones
        acceptButton.textContent = i18next.t('townhall.pay');
        cancelButton.textContent = i18next.t('general.exit');

        acceptButton.onclick = (function () {
            if (selected != undefined) {
                // Execute the selected operation
                alt.emit('executeTownHallOperation', selected);
            }
        });

        cancelButton.onclick = (function () {
            // Close the menu
            alt.emit('destroyBrowser');
        });

        options.appendChild(acceptButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateTownHallMenu(townHallOptionsJson);
        }, 100);
    }
}

function populateFinesMenu(finesJson) {
    if (messagesLoaded) {
        let finesList = JSON.parse(finesJson);
        let content = document.getElementById('content');
        let options = document.getElementById('options');
        selectedOptions = [];

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < finesList.length; i++) {
            let fine = finesList[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemAmountContainer = document.createElement('div');
            let amountTextContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');
            let itemAmount = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemAmountContainer.classList.add('item-amount-container');
            amountTextContainer.classList.add('item-amount-desc-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');
            itemAmount.classList.add('item-amount-description');

            itemDescription.textContent = fine.reason;
            itemPrice.innerHTML = '<b>' + i18next.t('general.amount') + '</b>' + fine.amount + '$';
            itemAmount.innerHTML = '<b>' + i18next.t('townhall.date') + '</b>' + fine.date.split(' ')[0];

            itemContainer.onclick = (function () {
                if (selectedOptions.indexOf(fine) === -1) {
                    // Mark the selected item
                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    // Save the index
                    selectedOptions.push(fine);
                } else {
                    // Unmark the selected item
                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.remove('active-item');

                    // Remove the index
                    selectedOptions.splice(selectedOptions.indexOf(fine), 1);
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
            purchaseContainer.appendChild(itemAmountContainer);
            itemAmountContainer.appendChild(amountTextContainer);
            amountTextContainer.appendChild(itemAmount);
        }

        let acceptButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        acceptButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        acceptButton.textContent = i18next.t('townhall.pay');
        cancelButton.textContent = i18next.t('general.back');

        acceptButton.onclick = (function () {
            if (selectedOptions.length > 0) {
                // Pay the selected fines
                alt.emit('payPlayerFines', JSON.stringify(selectedOptions));
            }
        });

        cancelButton.onclick = (function () {
            // Back to the main menu
            alt.emit('backTownHallIndex');
        });

        options.appendChild(acceptButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateFinesMenu(finesJson);
        }, 100);
    }
}

function populatePoliceControlsMenu(policeControlJson) {
    if (messagesLoaded) {
        let policeControls = JSON.parse(policeControlJson);
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Add the header text
        header.textContent = i18next.t('police.title');

        for (let i = 0; i < policeControls.length; i++) {
            let control = policeControls[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            itemDescription.textContent = control;

            itemContainer.onclick = (function () {
                if (selected !== i) {

                    if (selected != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[selected];
                        previousSelected.classList.remove('active-item');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    selected = i;
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let acceptButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        acceptButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        acceptButton.textContent = i18next.t('police.load');
        cancelButton.textContent = i18next.t('general.exit');

        acceptButton.onclick = (function () {
            // Process the option and close the menu
            alt.emit('proccessPoliceControlAction');
            alt.emit('destroyBrowser');
        });

        cancelButton.onclick = (function () {
            // Close the menu
            alt.emit('destroyBrowser');
        });

        options.appendChild(acceptButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populatePoliceControlsMenu(policeControlJson);
        }, 100);
    }
}

function populateWardrobeMenu(clothesTypeArray) {
    if (messagesLoaded) {
        let header = document.getElementById('header');
        header.textContent = i18next.t('house.title');

        clothesTypes = JSON.parse(clothesTypeArray);

        populateWardrobeHome();

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateWardrobeMenu(clothesTypeArray);
        }, 100);
    }
}

function populateWardrobeHome() {
    if (messagesLoaded) {
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        selected = undefined;
        drawable = undefined;

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < clothesTypes.length; i++) {
            let type = clothesTypes[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let itemDescription = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            itemDescription.classList.add('item-description');

            itemDescription.textContent = i18next.t(type.desc);

            itemContainer.onclick = (function () {
                selected = i;

                // Load the purchased clothes
                alt.emit('getPlayedPurchasedClothes', i);
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
        }

        let exitButton = document.createElement('div');

        exitButton.classList.add('single-button', 'cancel-button');
        exitButton.textContent = i18next.t('general.exit');

        exitButton.onclick = (function () {
            // Exit the menu
            alt.emit('destroyBrowser');
        });

        options.appendChild(exitButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateWardrobeHome();
        }, 100);
    }
}

function populateWardrobeClothes(typeClothesJson) {
    if (messagesLoaded) {
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        let typeClothesArray = JSON.parse(typeClothesJson);

        while (content.firstChild) {
            content.removeChild(content.firstChild);
        }

        while (options.firstChild) {
            options.removeChild(options.firstChild);
        }

        for (let i = 0; i < typeClothesArray.length; i++) {
            let clothes = typeClothesArray[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');

            itemDescription.textContent = clothes.description;
            itemPrice.innerHTML = '<b>' + i18next.t('clothes.variation') + '</b>' + clothes.texture;
            itemAdd.textContent = '+';
            itemSubstract.textContent = '-';

            itemContainer.onclick = (function () {
                if (drawable !== i) {

                    if (drawable != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[drawable];
                        previousSelected.classList.remove('active-item');
                    }

                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    drawable = i;

                    // Update the player's clothes
                    alt.emit('previewPlayerClothes', drawable);
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
            purchaseContainer.appendChild(itemAmountContainer);
            itemAmountContainer.appendChild(amountTextContainer);
            amountTextContainer.appendChild(itemAmount);
            itemAmountContainer.appendChild(addSubstractContainer);
            addSubstractContainer.appendChild(itemAdd);
            addSubstractContainer.appendChild(itemSubstract);
        }

        let dressButton = document.createElement('div');
        let cancelButton = document.createElement('div');

        dressButton.classList.add('double-button', 'accept-button');
        cancelButton.classList.add('double-button', 'cancel-button');

        dressButton.textContent = i18next.t('clothes.dress');
        cancelButton.textContent = i18next.t('general.back');

        dressButton.onclick = (function () {
            if (selected != undefined) {
                alt.emit('changePlayerClothes', selected, drawable);
            }
        });

        cancelButton.onclick = (function () {
            // Back to the main menu
            populateWardrobeHome();

            // Clear not dressed clothes
            alt.emit('clearClothes');
        });

        options.appendChild(dressButton);
        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateWardrobeClothes(typeClothesJson);
        }, 100);
    }
}

function populateContactsMenu(contactsJson, action) {
    // Check if the messages are loaded
    if (messagesLoaded) {
        // Initialize the values
        purchasedAmount = 1;
        selected = undefined;

        // Get items to show
        let contactsArray = JSON.parse(contactsJson);
        let header = document.getElementById('header');
        let content = document.getElementById('content');
        let options = document.getElementById('options');

        // Show business name
        header.textContent = i18next.t('telephone.contact-list');

        for (let i = 0; i < contactsArray.length; i++) {
            let item = contactsArray[i];

            let itemContainer = document.createElement('div');
            let infoContainer = document.createElement('div');
            let descContainer = document.createElement('div');
            let purchaseContainer = document.createElement('div');
            let priceContainer = document.createElement('div');
            let itemDescription = document.createElement('span');
            let itemPrice = document.createElement('span');

            itemContainer.classList.add('item-row');
            infoContainer.classList.add('item-content');
            descContainer.classList.add('item-header');
            purchaseContainer.classList.add('item-purchase');
            priceContainer.classList.add('item-price-container');
            itemDescription.classList.add('item-description');
            itemPrice.classList.add('item-price');

            itemDescription.textContent = item.contactName;
            itemPrice.innerHTML = '<b>' + item.contactNumber + '</b>';

            itemContainer.onclick = (function () {
                // Check if the item is not selected
                if (selected !== i) {
                    // Check if there was any item selected
                    if (selected != undefined) {
                        let previousSelected = document.getElementsByClassName('item-row')[selected];
                        previousSelected.classList.remove('active-item');
                    }

                    // Select the item
                    let currentSelected = document.getElementsByClassName('item-row')[i];
                    currentSelected.classList.add('active-item');

                    // Store the item
                    selected = i;
                }
            });

            content.appendChild(itemContainer);
            itemContainer.appendChild(infoContainer);
            infoContainer.appendChild(descContainer);
            descContainer.appendChild(itemDescription);
            infoContainer.appendChild(purchaseContainer);
            purchaseContainer.appendChild(priceContainer);
            priceContainer.appendChild(itemPrice);
        }

        // Add option buttons
        let cancelButton = document.createElement('div');

        // Add classes for the buttons
        cancelButton.classList.add('cancel-button');
        cancelButton.classList.add(parseInt(action) > 0 ? 'double-button' : 'single-button');

        // Add text for the buttons
        cancelButton.textContent = i18next.t('general.exit');

        if (parseInt(action) > 0) {
            let actionButton = document.createElement('div');
            actionButton.classList.add('double-button', 'accept-button');
            actionButton.textContent = getContactActionText(action);

            actionButton.onclick = (function () {
                // Check if the user purchased anything
                if (selected != undefined) {
                    alt.emit('executePhoneAction', selected);
                }
            });

            options.appendChild(actionButton);
        }

        cancelButton.onclick = (function () {
            // Close the purchase window
            alt.emit('destroyBrowser');
        });

        options.appendChild(cancelButton);

        clearTimeout(timeout);
    } else {
        // Wait for the messages to be loaded
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            populateContactsMenu(contactsJson, action);
        }, 100);
    }
}

function findFirstChildByClass(element, className) {
    let foundElement = undefined,
        found;

    function recurse(element, className, found) {
        for (let i = 0; i < element.childNodes.length && !found; i++) {
            let el = element.childNodes[i];
            let classes = el.className != undefined ? el.className.split(" ") : [];
            for (let j = 0, jl = classes.length; j < jl; j++) {
                if (classes[j] == className) {
                    found = true;
                    foundElement = element.childNodes[i];
                    break;
                }
            }
            if (found)
                break;
            recurse(element.childNodes[i], className, found);
        }
    }
    recurse(element, className, false);
    return foundElement;
}

function getContactActionText(action) {
    let text = undefined;

    switch (parseInt(action)) {
        case 2:
            text = i18next.t('telephone.action-modify');
            break;
        case 3:
            text = i18next.t('telephone.action-delete');
            break;
        case 5:
            text = i18next.t('telephone.action-sms');
            break;
    }

    return text;
}