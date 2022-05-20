
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCursor, GetCursorStatus } from './index.js';

//ToDo: vnxHideWindow(), vnxDrawButton(), vnxDrawButtonColored(), vnxDrawImage(), vnxDrawGridlist(), vnxDrawScrollbar(), vnxDrawEdit(), 
let screenRes = game.getActiveScreenResolution(0, 0);
export function isCursorOverRectangle(posX, posY, width, height) {
    let mouseX = alt.getCursorPos().x;
    let mouseY = alt.getCursorPos().y;
    let clientW = screenRes[1];
    let clientH = screenRes[2];
    mouseX = mouseX / clientW;
    mouseY = mouseY / clientH;

    if (mouseX >= posX && mouseX <= (posX + width) && mouseY >= posY && mouseY <= (posY + height)) {
        return true;
    }
    else {
        return false;
    }
}


let Libary_Cache = {};


export function vnxDrawWindow(WindowClass, id, text, x, y, sx, sy, moveable, func) {
    Libary_Cache[WindowClass] = { WindowClass: WindowClass, id: id, text: text, x: x, y: y, sx: sx, sy: sy, moveable: moveable, func: func, classType: "vnxDrawWindow" }
}

export function vnxDrawText(TextClass, id, text, x, y, scale, font, color, ParentClass, func) {
    let vnxDrawText_offsetx = 0;
    let vnxDrawText_offsety = 0;
    for (var Element in Libary_Cache) {
        if (Libary_Cache[Element].classType == "vnxDrawWindow" && Libary_Cache[Element].WindowClass == ParentClass) {
            vnxDrawText_offsetx = x;
            vnxDrawText_offsety = y;
            x = x + Libary_Cache[Element].x;
            y = y + Libary_Cache[Element].y;
        }
    }
    Libary_Cache[TextClass] = { TextClass: TextClass, id: id, text: text, x: x, offsetx: vnxDrawText_offsetx, y: y, offsety: vnxDrawText_offsety, ParentClass: ParentClass, scale: scale, font: font, color: color, func: func, classType: "vnxDrawText" }
}


export function vnxDrawButton(ButtonClass, id, text, x, y, sx, sy, ParentClass, func) {
    let offsetx = 0;
    let offsety = 0;
    for (var Element in Libary_Cache) {
        if (Libary_Cache[Element].classType == "vnxDrawWindow" && Libary_Cache[Element].WindowClass == ParentClass) {
            offsetx = x;
            offsety = y;
            x = x + Libary_Cache[Element].x;
            y = y + Libary_Cache[Element].y;
        }
    }
    Libary_Cache[ButtonClass] = { ButtonClass: ButtonClass, id: id, text: text, x: x, offsetx: offsetx, y: y, offsety: offsety, sx: sx, sy: sy, ParentClass: ParentClass, func: func, classType: "vnxDrawButton" }
}

export function vnxDestroyWindow(WindowClass) {
    for (var Element in Libary_Cache) {
        if (Libary_Cache[Element].WindowClass == WindowClass || Libary_Cache[ContainerItems].ParentClass == WindowClass) {
            alt.log("Element.WindowClass Wurde Gelöscht : " + Libary_Cache[Element].WindowClass);
            Libary_Cache.splice(Libary_Cache[Element].WindowClass, 1);
        }
    }
}



function MoveWindow(Element) {
    let mouseX = alt.getCursorPos().x;
    let mouseY = alt.getCursorPos().y;
    let clientW = screenRes[1];
    let clientH = screenRes[2];
    mouseX = mouseX / clientW;
    mouseY = mouseY / clientH;
    Libary_Cache[Element].x = mouseX;
    Libary_Cache[Element].y = mouseY + 0.1;
    for (var ContainerItems in Libary_Cache) {
        if (Libary_Cache[ContainerItems].ParentClass == Element) {
            Libary_Cache[ContainerItems].x = Libary_Cache[ContainerItems].offsetx + Libary_Cache[Element].x;
            Libary_Cache[ContainerItems].y = Libary_Cache[ContainerItems].offsety + Libary_Cache[Element].y;
        }
    }
}



alt.on('keyup', (key) => {
    if (key == 16) {
        for (var Element in Libary_Cache) {
            if (Libary_Cache[Element].Move) {
                Libary_Cache[Element].Move = false;
            }
        }
    }
});

//Render Stuff
export function dxLibaryEveryTick() {
    alt.on('keydown', (key) => {
        if (key == 16) {
            for (var Element in Libary_Cache) {
                if (Libary_Cache[Element].classType == "vnxDrawWindow" && Libary_Cache[Element].moveable) {
                    if (isCursorOverRectangle(Libary_Cache[Element].x, Libary_Cache[Element].y - 0.087, Libary_Cache[Element].sx * 5, 0.025 * 5)) {
                        Libary_Cache[Element].Move = true;
                    }
                    else if (Libary_Cache[Element].Move != false) {
                        Libary_Cache[Element].Move = false;
                    }
                }
            }
            return;
        }
    });
    for (var Element in Libary_Cache) {
        if (Libary_Cache[Element].Move) {
            MoveWindow(Element);
        }
        if (Libary_Cache[Element].classType == "vnxDrawWindow") {
            game.drawRect(Libary_Cache[Element].x, Libary_Cache[Element].y + Libary_Cache[Element].sy / 2 - 0.099, Libary_Cache[Element].sx, Libary_Cache[Element].sy, 0, 0, 0, 160);
            game.drawRect(Libary_Cache[Element].x, Libary_Cache[Element].y - 0.087, Libary_Cache[Element].sx, 0.025, 0, 0, 0, 120);
            game.drawRect(Libary_Cache[Element].x, Libary_Cache[Element].y - 0.10, Libary_Cache[Element].sx, 0.0035, 0, 105, 145, 255);
            //game.drawRect(Libary_Cache[Element].x + 0.09, Libary_Cache[Element].y - 0.087, 0.010, 0.025, 0, 105, 145, 255);
            //DrawText(Libary_Cache[Element].text, Libary_Cache[Element].x, Libary_Cache[Element].y, 1.5, 0);
            DrawText(Libary_Cache[Element].text, [Libary_Cache[Element].x, Libary_Cache[Element].y - 0.100], [0.4, 0.4], 0, [255, 255, 255, 255], false, true);
            if (isCursorOverRectangle(Libary_Cache[Element].x + Libary_Cache[Element].sx / 2 - 0.01, Libary_Cache[Element].y - 0.100, 0.015, 0.025)) {
                DrawText("X", [Libary_Cache[Element].x + Libary_Cache[Element].sx / 2 - 0.01, Libary_Cache[Element].y - 0.100], [0.4, 0.4], 0, [255, 0, 0, 255], true, true);
            }
            else {
                DrawText("X", [Libary_Cache[Element].x + Libary_Cache[Element].sx / 2 - 0.01, Libary_Cache[Element].y - 0.100], [0.4, 0.4], 0, [255, 255, 255, 255], true, true);
            }
        }
        if (Libary_Cache[Element].classType == "vnxDrawButton") {
            if (isCursorOverRectangle(Libary_Cache[Element].x, Libary_Cache[Element].y, Libary_Cache[Element].sx, Libary_Cache[Element].sy)) {
                game.drawRect(Libary_Cache[Element].x, Libary_Cache[Element].y, Libary_Cache[Element].sx, Libary_Cache[Element].sy, 0, 200, 255, 225);
                DrawText(Libary_Cache[Element].text, [Libary_Cache[Element].x, Libary_Cache[Element].y - 0.01], [0.4, 0.3], 0, [255, 255, 255, 255], true, true);
            }
            else {
                game.drawRect(Libary_Cache[Element].x, Libary_Cache[Element].y, Libary_Cache[Element].sx, Libary_Cache[Element].sy, 0, 105, 145, 225);
                DrawText(Libary_Cache[Element].text, [Libary_Cache[Element].x, Libary_Cache[Element].y - 0.01], [0.4, 0.3], 0, [255, 255, 255, 255], true, true);
            }
        }
        if (Libary_Cache[Element].classType == "vnxDrawText") {
            DrawText(Libary_Cache[Element].text, [Libary_Cache[Element].x, Libary_Cache[Element].y], [Libary_Cache[Element].scale[0], Libary_Cache[Element].scale[1]], Libary_Cache[Element].font, Libary_Cache[Element].color, true, true);
        }
    }
}


