//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../Globals/VnX-Lib';

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

let IsSyncer = false;


function SetZombieCorrectSkin(zombieEntity, facefeaturesarray, headblendsarray, headoverlaysarray) {
    try {
        let facefeatures = JSON.parse(facefeaturesarray);
        let headblends = JSON.parse(headblendsarray);
        let headoverlays = JSON.parse(headoverlaysarray);

        game.setPedHeadBlendData(zombieEntity, headblends[0], headblends[1], 0, headblends[2], headblends[5], 0, headblends[3], headblends[4], 0, 0);
        game.setPedHeadOverlayColor(zombieEntity, 1, 1, parseInt(headoverlays[2][1]), 1);
        game.setPedHeadOverlayColor(zombieEntity, 2, 1, parseInt(headoverlays[2][2]), 1);
        game.setPedHeadOverlayColor(zombieEntity, 5, 2, parseInt(headoverlays[2][5]), 1);
        game.setPedHeadOverlayColor(zombieEntity, 8, 2, parseInt(headoverlays[2][8]), 1);
        game.setPedHeadOverlayColor(zombieEntity, 10, 1, parseInt(headoverlays[2][10]), 1);
        game.setPedEyeColor(zombieEntity, parseInt(headoverlays[0][14]));
        game.setPedHeadOverlay(zombieEntity, 0, parseInt(headoverlays[0][0]), parseInt(headoverlays[1][0]));
        game.setPedHeadOverlay(zombieEntity, 1, parseInt(headoverlays[0][1]), parseFloat(headoverlays[1][1]));
        game.setPedHeadOverlay(zombieEntity, 2, parseInt(headoverlays[0][2]), parseFloat(headoverlays[1][2]));
        game.setPedHeadOverlay(zombieEntity, 3, parseInt(headoverlays[0][3]), parseInt(headoverlays[1][3]));
        game.setPedHeadOverlay(zombieEntity, 4, parseInt(headoverlays[0][4]), parseInt(headoverlays[1][4]));
        game.setPedHeadOverlay(zombieEntity, 5, parseInt(headoverlays[0][5]), parseInt(headoverlays[1][5]));
        game.setPedHeadOverlay(zombieEntity, 6, parseInt(headoverlays[0][6]), parseInt(headoverlays[1][6]));
        game.setPedHeadOverlay(zombieEntity, 7, parseInt(headoverlays[0][7]), parseInt(headoverlays[1][7]));
        game.setPedHeadOverlay(zombieEntity, 8, parseInt(headoverlays[0][8]), parseInt(headoverlays[1][8]));
        game.setPedHeadOverlay(zombieEntity, 9, parseInt(headoverlays[0][9]), parseInt(headoverlays[1][9]));
        game.setPedHeadOverlay(zombieEntity, 10, parseInt(headoverlays[0][10]), parseInt(headoverlays[1][10]));
        game.setPedComponentVariation(zombieEntity, 2, parseInt(headoverlays[0][13]), 0, 0);
        game.setPedHairColor(zombieEntity, parseInt(headoverlays[2][13]), parseInt(headoverlays[1][13]));
        for (let i = 0; i < 20; i++) {
            game.setPedFaceFeature(zombieEntity, i, facefeatures[i]);
        }
    }
    catch{ }
}


alt.onServer('Zombies:ApplyBloodToZombie', (Id) => {
    try {
        let zombieEntity = Zombies[Id].Entity;
        game.applyPedDamagePack(zombieEntity, "Fall", 100, 100 * 300);
    }
    catch{ }
});


alt.onServer('Zombies:Sync', (state) => {
    try {
        IsSyncer = state;
        if (SyncInterval) { alt.clearInterval(SyncInterval); SyncInterval = null; }
        if (IsSyncer) {
            SyncInterval = alt.setInterval(() => {
                for (var counter in Zombies) {
                    let Zombie = Zombies[counter];
                    if (!Zombie) { return; }
                    if (Zombie.Entity != null) {
                        let zombiePos = game.getEntityCoords(Zombie.Entity, true);
                        alt.emitServer('Zombies:OnSyncerCall', Zombie.Id, zombiePos.x, zombiePos.y, zombiePos.z);
                    }
                };
            }, 1500);
        }
    }
    catch{ }
});

async function loadModel(dict) {
    return new Promise(resolve => {
        if (game.hasModelLoaded(dict)) resolve(true);
        game.requestModel(dict);
        let inter = alt.setInterval(() => {
            if (game.hasModelLoaded(dict)) {
                resolve(true);
                alt.clearInterval(inter);
            }
        }, 5);
    });
}


let Zombies = [];
game.requestAnimDict("special_ped@zombie@monologue_6@monologue_6a");
alt.onServer('Zombies:SpawnKI', (Id, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target) => {
    try {
        if (Zombies[Id]) { return; }
        Hash = alt.hash(Hash);
        let res = loadModel(Hash);
        res.then(() => {
            let zombieEntity = game.createPed(2, Hash, Position.x, Position.y, Position.z, 0, false, false);
            Zombies[Id] = {
                Id: Id,
                Entity: zombieEntity,
                IsZombieKI: true,
                Position: Position,
                IsDead: false,
                Frozen: true,
                TargetEntity: Target,
            }
            game.freezeEntityPosition(Zombies[Id].Entity, true);
            game.setEntityAsMissionEntity(Zombies[Id].Entity, true, false);
            game.setPedCanRagdoll(Zombies[Id].Entity, false);
            game.setEntityCanBeDamaged(Zombies[Id].Entity, true);
            game.setEntityOnlyDamagedByPlayer(Zombies[Id].Entity, false);
            game.setPedRagdollOnCollision(Zombies[Id].Entity, true);
            game.setPedCanRagdollFromPlayerImpact(Zombies[Id].Entity, true)
            game.setPedCombatMovement(Zombies[Id].Entity, 100);
            game.setPedCombatAbility(Zombies[Id].Entity, 100);
            game.setPedFleeAttributes(Zombies[Id].Entity, 0, false);
            game.setPedCombatAttributes(Zombies[Id].Entity, 16, true);
            game.setPedCombatAttributes(Zombies[Id].Entity, 17, true);
            game.setBlockingOfNonTemporaryEvents(Zombies[Id].Entity, true);
            game.setEntityProofs(Zombies[Id].Entity, false, true, false, true, false, false, false, false);
            SetZombieCorrectSkin(Zombies[Id].Entity, FaceFeatures, HeadBlendData, HeadOverlays);
        });
    }
    catch{ }
});

alt.onServer('Zombies:ClothesLoad', (Id, clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedComponentVariation(Zombies[Id].Entity, clothesslot, clothesdrawable, clothestexture);
    }
    catch{ }
});


alt.onServer("Zombies:AccessoriesLoad", (Id, clothesslot, clothesdrawable, clothestexture) => {
    try {
        game.setPedPreloadVariationData(Zombies[Id].Entity, clothesslot, clothesdrawable, clothestexture);
    }
    catch{ }
});



let DestroyedOne = false;
alt.setInterval(() => {
    if (DestroyedOne) { DestroyedOne = false; return; }
    if (!DestroyedOne) {
        for (var _c in Zombies) {
            if (Zombies[_c].IsDead == true) {
                DestroyedOne = true;
                alt.log('Zombies[_c].IsDead 0 : ' + Zombies[_c].IsDead + " | Other ID : " + _c);
                alt.log('Zombie Log Called : ' + Zombies[_c].Id);
                if (game.doesEntityExist(Zombies[_c].Entity)) {
                    game.deleteEntity(Zombies[_c].Entity);
                    if (game.doesEntityExist(Zombies[_c].Entity)) {
                        game.deletePed(Zombies[_c].Entity);
                    }
                }
                Zombies.splice(DeadZombieId, 1);
            }
        }
    }
}, 500);


alt.onServer('Zombies:SetHealth', (Id, Health) => {
    for (var _c in Zombies) {
        if (Zombies[_c].Id == Id) {
            game.setEntityHealth(Zombies[_c].Entity, parseInt(Health));
            if (game.getEntityHealth(Zombies[_c].Entity) <= 0 && Zombies[_c].Entity != null && !Zombies[_c].IsDead) {
                Zombies[_c].IsDead = true;
                game.setEntityAsMissionEntity(Zombies[_c].Entity, false, true);
                game.setEntityAsNoLongerNeeded(Zombies[_c].Entity);
                alt.log('Zombies[_c].IsDead 1 : ' + Zombies[_c].IsDead);
            }
        }
    }
});

let SyncInterval;
alt.onServer("Zombies:SetPosition", (Id, PosX, PosY, PosZ) => {
    try {
        if (!Zombies[Id]) { return; }
        //game.setEntityCoords(Zombies[Id].Entity, PosX, PosY, PosZ);
    }
    catch{ }
});

alt.on("disconnect", () => {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            game.deletePed(Zombies[Id].Entity);
        }
    };
});


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


function CheckZombieHealths() {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            if (game.getEntityHealth(Zombies[Id].Entity) <= 0) {
                if (!Zombies[Id].IsDead) {
                    alt.log('CS : Zombies:OnZombieDeath | State : ' + Zombies[Id].IsDead);
                    Zombies[Id].IsDead = true;
                    game.setEntityAsMissionEntity(Zombies[Id].Entity, false, true);
                    game.setEntityAsNoLongerNeeded(Zombies[Id].Entity);
                    alt.emitServer("Zombies:OnZombieDeath", parseInt(Zombies[Id].Id));
                }
            }
        }
    };
}


function DrawNametags() {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            let playerPos2 = game.getEntityCoords(Zombies[Id].Entity);
            let distance = game.getDistanceBetweenCoords(alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
            let screenPos = game.getScreenCoordFromWorldCoord(playerPos2.x, playerPos2.y, playerPos2.z + 1);
            //if(distance <= maxDistance_load && player.getStreamSyncedMeta("PLAYER_LOGGED_IN")) {
            if (distance <= 30) {
                DrawText("Zombie ~r~[" + Zombies[Id].Id + "]\n~w~IsDead : ~r~" + Zombies[Id].IsDead + "\n~w~Frozen : ~r~" + Zombies[Id].Frozen, [screenPos[1], screenPos[2] - 0.045], [0.65, 0.65], 4, [255, 255, 255, 255], true, true);
            }
        }
    }
}
alt.everyTick(() => {
    DrawNametags();
});




////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 
function CheckZombieDamage(Zombie) {
    if (game.hasEntityBeenDamagedByEntity(Zombie.Entity, alt.Player.local.scriptID, true)) {
        game.clearEntityLastDamageEntity(Zombie.Entity);
        if (game.getEntityHealth(e_values) <= 0) {
            e_values.IsDead = true;
            //mp.events.callRemote('OnZombieKill');
        }
    }
}
*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

alt.onServer('Zombies:MoveToTarget', (ID, TargetEntity) => {
    if (!Zombies[ID]) return;
    if (Zombies[ID].IsDead) return;
    let Zombie = Zombies[ID];
    if (Zombie.Frozen) {
        game.freezeEntityPosition(Zombie.Entity, false); Zombie.Frozen = false;
    }
    Zombie.TargetEntity = TargetEntity;
    let playerPos = game.getEntityCoords(Zombie.TargetEntity.scriptID, true);
    game.taskGoToCoordAnyMeans(Zombie.Entity, playerPos.x, playerPos.y, playerPos.z, 5, 0, false, 786603, 0);
    game.taskPutPedDirectlyIntoMelee(Zombie.Entity, Zombie.TargetEntity.scriptID, 0.0, -5.0, 1.0, false);
    CheckZombieHealths();
});
