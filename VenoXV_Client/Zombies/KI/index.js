//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";

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
            }, 1000);
        }
    }
    catch{ }
});


let Zombies = [];
game.requestAnimDict("special_ped@zombie@monologue_6@monologue_6a");
alt.onServer('Zombies:SpawnKI', (Id, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target) => {
    try {
        if (Zombies[Id]) { return; }
        Hash = alt.hash(Hash);
        if (!game.hasModelLoaded(Hash)) {
            alt.loadModel(ZombieHash);
            game.requestModel(ZombieHash);
        }
        let zombieEntity = game.createPed(2, Hash, Position.x, Position.y, Position.z, 0, false, false);
        Zombies[Id] = {
            Id: Id,
            Entity: zombieEntity,
            IsZombieKI: true,
            Position: Position,
            IsDead: false,
            TargetEntity: Target,
        }
        game.setPedCanRagdoll(Zombies[Id].Entity, true);
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



alt.onServer('Zombies:SetHealth', (Id, Health) => {
    try {
        if (!Zombies[Id]) { return; }
        game.setEntityHealth(Zombies[Id].Entity, Health);
        if (game.getEntityHealth(Zombies[Id].Entity) <= 0 && Zombies[Id].Entity != null) {
            //alt.log("Zombie wurde gelöscht.");
            game.deletePed(Zombies[Id].Entity);
            Zombies.splice(Id, 1);
        }
    }
    catch{ }
});

let SyncInterval;
alt.onServer("Zombies:SetPosition", (Id, PosX, PosY, PosZ) => {
    try {
        if (!Zombies[Id]) { return; }
        game.setEntityCoords(Zombies[Id].Entity, PosX, PosY, PosZ - 1);
    }
    catch{ }
});

alt.on("resourceStop", () => {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            game.deletePed(Zombies[Id].Entity);
        }
    };
});


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





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
    if (!Zombies[ID]) { return; }
    let Zombie = Zombies[ID];
    Zombie.TargetEntity = TargetEntity;
    let playerPos = game.getEntityCoords(Zombie.TargetEntity.scriptID, true);
    game.taskGoToCoordAnyMeans(Zombie.Entity, playerPos.x, playerPos.y, playerPos.z, 5, 0, false, 786603, 0);
    //game.taskPutPedDirectlyIntoMelee(Zombie.Entity, Zombie.TargetEntity.scriptID, 0.0, -5.0, 1.0, false);
    if (game.getEntityHealth(Zombie.Entity) <= 0 && !Zombie.IsDead) {
        Zombie.IsDead = true;
        alt.emitServer("Zombies:OnZombieDeath", ID);
    }
});
