//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import alt, {
    gameControlsEnabled
} from 'alt-client';
import * as game from "natives";

import {
    ShowCursor,
    GetCursorStatus,
    vnxCreateCEF,
    vnxDestroyCEF,
    Draw3DText,
    frontOfPlayer
} from '../../Globals/VnX-Lib';

let InventoryCreated = false;
let InventoryOpen = false;
let InventoryBrowser;

export function OnInventoryKeyPressed(key) {
    if (key == 0x49) {
        if (!InventoryCreated) return;
        if (GetCursorStatus() && !InventoryOpen) return;
        if (!InventoryOpen) {
            InventoryBrowser.focus();
            ShowCursor(true);
            InventoryBrowser.emit("Inventory:Open");
        } else {
            ShowCursor(false);
            InventoryBrowser.emit("Inventory:Close");
        }
        InventoryOpen = !InventoryOpen;
    }
}



alt.onServer('Inventory:Update', (InventoryJson) => {
    if (!InventoryCreated) return;
    let InventoryItems = JSON.parse(InventoryJson);
    for (let i = 0; i < InventoryItems.length; i++) {
        let data = InventoryItems[i];
        InventoryBrowser.emit('Inventory:Update', data.Id, data.Hash, data.Amount, data.Type, data.Weight, data.IsUsing);
    }
});

alt.onServer('Inventory:RemoveAll', () => {
    if (!InventoryCreated) return;
    InventoryBrowser.emit('Inventory:RemoveAll');
});


alt.onServer('Inventory:Load', () => {
    if (InventoryCreated) return;
    InventoryBrowser = vnxCreateCEF("Inventory-Reallife", "Reallife/inventory/main.html", "Reallife");
    InventoryCreated = true;

    InventoryBrowser.on('OnInventoryButtonClicked', (Btn, Hash) => {
        switch (Btn) {
            case 'use':
                alt.emitServer('Inventory:Use', Hash);
            case 'remove':
                alt.emitServer('Inventory:Remove', Hash);
        }
    });


    InventoryBrowser.on('Inventory:UseItem', (Id) => {
        alt.emitServer('Inventory:UseItem', Id);
    });

    InventoryBrowser.on('Inventory:DropItem', (Hash, Amount) => {
        alt.emitServer('Inventory:DropItem', Hash, parseInt(Amount));
    });
});

alt.onServer('Inventory:Unload', () => {
    if (!InventoryCreated) {
        return;
    }
    vnxDestroyCEF("Inventory-Reallife");
    InventoryCreated = false;
});



// Obj Drop : 
let DroppedObjList = {};
alt.everyTick(() => {
    for (var obj in DroppedObjList) {
        let coords = game.getEntityCoords(DroppedObjList[obj].Obj);
        Draw3DText(DroppedObjList[obj].Text, coords.x, coords.y, coords.z, 0, [255, 255, 255, 255], 10, true, true, 0.2);
    }
});

alt.onServer('Inventory:DropObj', (Id, Hash, Text) => {
    if (DroppedObjList[Id]) return;
    Hash = game.getHashKey(Hash);
    let Position = frontOfPlayer(0.5);
    if (!game.hasModelLoaded(Hash)) game.requestModel(Hash);
    let Obj = game.createObjectNoOffset(Hash, Position.x, Position.y, Position.z, false, false, true);
    game.setActivateObjectPhysicsAsSoonAsItIsUnfrozen(Obj, true);
    game.activatePhysics(Obj);
    game.setEntityHasGravity(Obj, true);
    DroppedObjList[Id] = {
        Id: Id,
        Hash: Hash,
        Text: Text,
        Obj: Obj
    };
});

alt.onServer('Inventory:DeleteObj', Id => {
    DeleteDroppedItem(Id);
});


function DeleteDroppedItem(Id) {
    if (!DroppedObjList[Id]) return;
    game.deleteObject(DroppedObjList[Id].Obj);
    delete DroppedObjList[Id];
    alt.log('Called DeleteDroppedItem');
}

export function CheckDroppedObjects() {
    for (var counter in DroppedObjList) {
        if (!DroppedObjList[counter] || !DroppedObjList[counter].Obj) continue;
        let objCoords = game.getEntityCoords(DroppedObjList[counter].Obj);
        let playerCoords = alt.Player.local.pos;
        let Distance = game.getDistanceBetweenCoords(objCoords.x, objCoords.y, objCoords.z, playerCoords.x, playerCoords.y, playerCoords.z, true);
        if (Distance < 1.5) {
            alt.emitServer('Inventory:PickupItem', parseInt(DroppedObjList[counter].Id));
            DeleteDroppedItem(DroppedObjList[counter].Id);
            return true;
        }
    }
    return false;
}