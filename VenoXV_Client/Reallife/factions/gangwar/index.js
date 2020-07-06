//----------------------------------///
///// VenoX Gaming & Fun 2019 © ///////
///////////////////////////////////////
////////www.venox-reallife.com/////////
//----------------------------------///
import * as alt from 'alt-client';
import * as game from "natives";
var area = {};

alt.onServer('gw:ca', (n, x, y, z, r, c, r2) => {
    if (area[n] != null) {
        game.removeBlip(area[n]);
    }
    area[n] = game.addBlipForRadius(x, y, z, r);
    game.setBlipSprite(area[n], 5);
    game.setBlipAlpha(area[n], 150);
    game.setBlipColour(area[n], c);
    game.setBlipRotation(area[n], r2);
});

let alpha = 220;
let currentstate = "done";
let attackarea = null;
let GangWarTimer = null;
alt.onServer('gw:aa', (x, y, z, r, r1, c) => {
    try {
        if (attackarea != null) {
            game.removeBlip(attackarea);
        }
        attackarea = mp.game.ui.addBlipForRadius(x, y, z, r);
        game.setBlipSprite(attackarea, 5);
        game.setBlipAlpha(attackarea, alpha);
        game.setBlipColour(attackarea, c);
        game.setBlipRotation(attackarea, r1);
        GangWarTimer = alt.setInterval(function () {
            if (alpha < 220 && currentstate == "not done") { alpha = alpha + 20; if (alpha == 220) { currentstate = "done"; } }
            else { alpha = alpha - 20; if (alpha <= 20) { currentstate = "not done"; } }
            game.setBlipAlpha(attackarea, alpha);
        }, 50);
    }
    catch{ }
});

alt.onServer('StopCurrentGangwar', (n) => {
    if (GangWarTimer != null) {
        alt.clearInterval(GangWarTimer);
        GangWarTimer = null;
    }
    if (attackarea != null) {
        game.removeBlip(attackarea);
    }
});