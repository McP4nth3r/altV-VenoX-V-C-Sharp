//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

var is_colliding = function ($div1, $div2) {
    // Div 1 data
    var d1_offset = $div1.offset();
    var d1_height = $div1.outerHeight(true);
    var d1_width = $div1.outerWidth(true);
    var d1_distance_from_top = d1_offset.top + d1_height;
    var d1_distance_from_left = d1_offset.left + d1_width;

    // Div 2 data
    var d2_offset = $div2.offset();
    var d2_height = $div2.outerHeight(true);
    var d2_width = $div2.outerWidth(true);
    var d2_distance_from_top = d2_offset.top + d2_height;
    var d2_distance_from_left = d2_offset.left + d2_width;

    var not_colliding = (d1_distance_from_top < d2_offset.top || d1_offset.top > d2_distance_from_top || d1_distance_from_left < d2_offset.left || d1_offset.left > d2_distance_from_left);

    // Return whether it IS colliding
    return !not_colliding;
};

let SoundInterval;
$("#spin_button").click(() => {
    let FoundWinningCard = false;
    var card = $(".Card");
    var cardSize = 50;
    var marginSize = 24;
    var winningCardNumber = 58;
    var startOfWinningCard = -Math.abs(((cardSize / 2) + marginSize) + ((cardSize + marginSize) * (winningCardNumber - 4))) - (cardSize / 2);
    var numberRand = (Math.floor(Math.random() * 250) + 1);
    var totalTranslate = startOfWinningCard - numberRand;
    var animationTime = 10000;

    card.css('transition', 'all ' + animationTime + 'ms cubic-bezier(.09,.08,.1,.99');
    card.css('transform', 'translateX(' + totalTranslate + 'px) rotate3d(0,0,0, 0deg');

    setTimeout(() => {
        [].forEach.call(card, function (e) {
            let rect1 = $(e);
            let rect2 = $('.middle');
            var isOverlaying = is_colliding(rect1, rect2);
            if (isOverlaying) {
                FoundWinningCard = true;
                rect1.addClass('.winning-card');
                //rect1.css('transition', 'all 300ms');
                //rect1.css('transform', 'translateX(' + 5 + 'px) scale(1.5) rotate3d(1,1,0, 360deg');
                console.log(rect1.children().text());
                console.log(Object.keys(rect1));
                alt.emit('CaseOpening:Winning', rect1.children().text());
                //finishedSliding(rect1, rect1, winningCardNumber);
            } else {
                rect1.css('opacity', '.3');
            }
        });
        if (!FoundWinningCard) {
            // To Do : zurückerstatten.
        }

        //finishedSliding(centerOfWinningCard, card, winningCardNumber)
        if (SoundInterval) {
            clearInterval(SoundInterval);
        }
    }, animationTime + 500);

    document.getElementById('ClickSound').volume = 0.15;
    SoundInterval = setInterval(() => {
        [].forEach.call(card, function (e) {
            let rect1 = $(e);
            let rect2 = $('.middle');
            var isOverlaying = is_colliding(rect1, rect2);
            if (isOverlaying && !rect1.hasClass('SoundCalled')) {
                document.getElementById('ClickSound').currentTime = 0;
                document.getElementById('ClickSound').play();
                rect1.addClass('SoundCalled');
            }
        });
    }, 50);
});


let itemTypes = []
function AddChances(Class) { itemTypes.push(Class); }

let CurrentCaseItems = [];
function AddCaseItems(CaseItem) { CurrentCaseItems.push(CaseItem); }

alt.on('CaseOpening:LoadChances', (ChancesJson) => {
    itemTypes = JSON.parse(ChancesJson);
});
alt.on('CaseOpening:LoadCases', (CaseJson) => {
    CurrentCaseItems = JSON.parse(CaseJson);
    fillSlider(CurrentCaseItems);
});




function fillSlider(caseData) {
    var cards = [];
    var startItem = 0;
    var totalCardsAmount = 60;
    fillCards(caseData, cards, totalCardsAmount, startItem);
    $(".Card-Slots").html(cards);
}


function fillCards(caseData, cards, totalCardsAmount, startItem) {
    if (startItem >= totalCardsAmount) {
        return cards;
    }
    var randomNumber = parseFloat(Math.random() * 100).toFixed(2);
    var chosenItem;
    var itemType;
    var previousChance;

    for (k = 0; k < itemTypes.length; k++) {
        if (k === 0) {
            previousChance = 0;
            currentChance = itemTypes[k].Chance;
        } else {
            previousChance = previousChance + itemTypes[k - 1].Chance;
            currentChance = itemTypes[k].Chance + previousChance;
        }

        if (randomNumber <= currentChance && randomNumber > previousChance) {
            var allItemsOfType = caseData.find(item => item.Type == itemTypes[k].Name)
            console.log(allItemsOfType[Math.floor(Math.random() * allItemsOfType.length)]);
            if (allItemsOfType != null) {
                allItemsOfType = allItemsOfType.Items
                chosenItem = allItemsOfType[Math.floor(Math.random() * allItemsOfType.length)];
                itemType = itemTypes[k].Class;
                cards.push(`<div class="Card">
                    <img class="Card-Image" src="` + chosenItem.URL + `">
                    <div class="Card-State ` + itemTypes[k].Class + `">
                        <div class="Card-Name">` + chosenItem.Name + `</div>
                        <div class="Card-Info">` + chosenItem.Info + `</div>
                    </div>
                </div>`);
                k = itemTypes.length;
            }
        }
    };
    startItem++;
    fillCards(caseData, cards, totalCardsAmount, startItem)
}
