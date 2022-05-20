//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///

import * as alt from 'alt-client';
import * as game from 'natives';

let notifyBrowser = new alt.WebView('http://resource/VenoXV_Client/Globals/Notification/notify.html');

alt.onServer('Globals:PlayHitsound', () => {
    notifyBrowser.emit('Notify:PlayHitSound');
    hitMarker = Date.now() / 1000;
});

alt.onServer('createVnXLiteNotify', (e, v) => notifyBrowser.emit('SideNotification:Create', e, v));

alt.onServer('Globals:ShowBloodScreen', () => notifyBrowser.emit('Notify:BloodScreen'));

alt.onServer('Quests:Show', (state: boolean) => notifyBrowser.emit('Quests:Show', state));

alt.onServer('Quest:SetCurrentQuest', (QuestText, QuestMoney, QuestLevel) => notifyBrowser.emit('Quests:SetCurrentQuest', QuestText, QuestMoney, QuestLevel));

var hitMarker = 0;
if (!game.hasStreamedTextureDictLoaded('hud_reticle')) game.requestStreamedTextureDict('hud_reticle', true);

alt.everyTick(() => {
    game.resetPlayerStamina(alt.Player.local.scriptID);
    if (game.hasStreamedTextureDictLoaded('hud_reticle')) if (Date.now() / 1000 - hitMarker <= 0.1) game.drawSprite('hud_reticle', 'reticle_ar', 0.5, 0.5, 0.025, 0.04, 45, 255, 255, 255, 150, false);
});
