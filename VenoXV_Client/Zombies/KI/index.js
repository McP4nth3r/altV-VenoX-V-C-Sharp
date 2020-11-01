//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText } from '../../Globals/VnX-Lib';

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Settings

// Needed variables
let IsSyncer = false;
let DestroyedOne = false;
let Zombies = {};
let SyncInterval;

// Require 
game.requestAnimSet('move_m@drunk@verydrunk');
game.requestAnimSet('facials@gen_male@base');
game.requestAnimSet('move_m@injured');

game.requestAnimDict("special_ped@zombie@monologue_6@monologue_6a");

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

alt.onServer('Zombies:Sync', async (state) => {
    try {
        IsSyncer = state;
        if (IsSyncer) {
            SyncInterval = alt.setInterval(() => {
                let numb = 0;
                for (var counter in Zombies) {
                    let Zombie = Zombies[counter];
                    if (!Zombie) continue;
                    if (numb >= 25) return;
                    if (Zombie.Entity != null && !Zombie.OutOfStreamingRange) {
                        let zombiePos = game.getEntityCoords(Zombie.Entity, true);
                        let zombieRot = game.getEntityRotation(Zombie.Entity, 2);
                        alt.emitServer('Zombies:OnSyncerCall', Zombie.Id, zombiePos.x, zombiePos.y, zombiePos.z - 1.0, zombieRot.x, zombieRot.y, zombieRot.z);
                        numb++;
                    }
                };
                //Debug.
                //if (numb > 0) alt.log("Called : " + numb);
            }, 850);

        }
        else {
            if (SyncInterval) alt.clearInterval(SyncInterval);
            SyncInterval = null;
        }
    }
    catch { }
});

alt.onServer('Zombies:SpawnKI', async (Id, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target) => {
    SpawnZombie(parseInt(Id), Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target);
});

alt.onServer('Zombies:ClothesLoad', async (Id, clothesslot, clothesdrawable, clothestexture) => {
    game.setPedComponentVariation(Zombies[parseInt(Id)].Entity, clothesslot, clothesdrawable, clothestexture);
});


alt.onServer("Zombies:AccessoriesLoad", async (Id, clothesslot, clothesdrawable, clothestexture) => {
    game.setPedPreloadVariationData(Zombies[parseInt(Id)].Entity, clothesslot, clothesdrawable, clothestexture);
});

alt.onServer('Zombies:SetDead', (Id, state) => {
    if (!Zombies[parseInt(Id)]) return;
    Zombies[parseInt(Id)].IsDead = state;
    game.setEntityAsMissionEntity(Zombies[parseInt(Id)].Entity, false, true);
})


alt.setInterval(() => {
    if (DestroyedOne) DestroyedOne = false;
    else {
        for (var _c in Zombies) {
            if (Zombies[_c].IsDead === true) {
                DestroyedOne = true;
                if (Zombies[_c].Entity == null) return delete Zombies[_c];;
                game.deletePed(Zombies[_c].Entity);
                delete Zombies[_c];
            }
        }
    }
}, 250);

alt.onServer('Zombies:SetArmor', async (Id, Armour) => {
    if (!Zombies[parseInt(Id)]) return;
    game.setPedArmour(Zombies[parseInt(Id)].Entity, parseInt(Armour));
});

alt.onServer('Zombies:SetHealth', async (Id, Health) => {
    if (!Zombies[parseInt(Id)]) return;
    game.setEntityHealth(Zombies[parseInt(Id)].Entity, parseInt(Health));
});

alt.onServer("Zombies:UpdatePositionAndRotation", async (Id, PosX, PosY, PosZ, RotX, RotY, RotZ) => {
    if (!Zombies[parseInt(Id)]) return;
    game.setEntityCoords(Zombies[parseInt(Id)].Entity, PosX, PosY, PosZ);
    game.setEntityRotation(Zombies[parseInt(Id)].Entity, RotX, RotY, RotZ, 2, true);
});

alt.onServer("Zombies:SetPosition", async (Id, PosX, PosY, PosZ) => {
    if (!Zombies[parseInt(Id)]) return;
    game.setEntityCoords(Zombies[parseInt(Id)].Entity, PosX, PosY, PosZ);
});

alt.onServer("Zombies:SetRotation", async (Id, RotX, RotY, RotZ) => {
    if (!Zombies[parseInt(Id)]) return;
    game.setEntityRotation(Zombies[parseInt(Id)].Entity, RotX, RotY, RotZ, 2, true);
});

alt.onServer('Zombies:Destroy', async (Id) => {
    if (!Zombies[parseInt(Id)]) return;
    Zombies[parseInt(Id)].IsDead = true;
});

alt.onServer('Zombies:DeleteTempZombieById', async (ID) => {
    if (!Zombies[parseInt(ID)]) return;
    Zombies[parseInt(ID)].OutOfStreamingRange = true;
    DeleteZombieById(parseInt(ID));
});


alt.onServer('Zombies:MoveToTarget', async (ID, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, TargetEntity) => {
    if (!Zombies[parseInt(ID)]) {
        SpawnZombie(parseInt(ID), Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, TargetEntity);
        return;
    }
    if (!TargetEntity) return;
    MoveZombieToTarget(parseInt(ID), TargetEntity);
});


alt.on("disconnect", () => {
    DeleteEveryZombie();
});
alt.onServer('Zombies:OnGamemodeDisconnect', () => {
    DeleteEveryZombie();
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function DeleteEveryZombie() {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            game.deletePed(Zombies[Id].Entity);
        }
        delete Zombies[Id];
    };
}


function DeleteZombieById(ID) {
    if (!Zombies[ID]) return;
    for (var _c in Zombies) {
        if (Zombies[_c].Id == ID) {
            Zombies[_c].IsDead = true;
            game.setEntityAsMissionEntity(Zombies[_c].Entity, false, true);
        }
    }
}

function CheckZombieHealths() {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null && !Zombies[Id].IsDead) {
            if (game.hasEntityBeenDamagedByEntity(Zombies[Id].Entity, alt.Player.local.scriptID)) {
                game.clearEntityLastDamageEntity(Zombies[Id].Entity);
                if (game.getEntityHealth(Zombies[Id].Entity) <= 0 && !Zombies[Id].OutOfStreamingRange) {
                    Zombies[Id].IsDead = true;
                    game.setEntityAsMissionEntity(Zombies[Id].Entity, false, true);
                    alt.emitServer("Zombies:OnZombieDeath", parseInt(Zombies[Id].Id));
                }
            }
        }
    };
}

alt.setInterval(() => {
    CheckZombieHealths();
}, 500);


function DrawNametags() {
    for (var Id in Zombies) {
        if (Zombies[Id].Entity != null) {
            let playerPos2 = game.getEntityCoords(Zombies[Id].Entity);
            let distance = game.getDistanceBetweenCoords(alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, playerPos2.x, playerPos2.y, playerPos2.z, true);
            let screenPos = game.getScreenCoordFromWorldCoord(playerPos2.x, playerPos2.y, playerPos2.z + 1);
            //if(distance <= maxDistance_load && player.getStreamSyncedMeta("PLAYER_LOGGED_IN")) {
            if (distance <= 30) {
                DrawText("Zombie ~r~[" + Zombies[Id].Id + "]\n~w~IsDead : ~b~" + Zombies[Id].IsDead, [screenPos[1], screenPos[2] - 0.035], [0.55, 0.55], 4, [255, 255, 255, 255], true, true);
            }
        }
    }
}


function SetZombieCorrectSkin(zombieEntity, facefeaturesarray, headblendsarray, headoverlaysarray) {
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

function SetZombieAttributes(zombie) {
    /*
    game.setPedCanPlayGestureAnims(zombie, false);
    game.setPedCanPlayAmbientAnims(zombie, false);
    game.setPedCanEvasiveDive(zombie, false);
    game.setPedPathCanUseLadders(zombie, false);
    game.setPedPathCanUseClimbovers(zombie, false);
    game.applyPedDamagePack(zombie, 'BigHitByVehicle', 0.0, 1);
    game.applyPedDamagePack(zombie, 'ExplosionMed', 0.0, 1);
    game.setPedAlertness(zombie, 0);
    game.setPedCombatAttributes(zombie, 46, true);
    game.setPedConfigFlag(zombie, 281, true);
    // move to spawn.
    let ZombiePos = game.getEntityCoords(zombie);
    game.taskWanderInArea(zombie, ZombiePos.x, ZombiePos.y, ZombiePos.z, 100);
    game.setPedKeepTask(zombie, true);



    game.setPedCanPlayGestureAnims(zombie, false);
    game.setPedCanPlayAmbientAnims(zombie, false);
    game.setPedCanEvasiveDive(zombie, false);*/
    game.setPedPathCanUseLadders(zombie, false);
    game.setPedPathCanUseClimbovers(zombie, false);

    game.setPedCanRagdoll(zombie, false);
    game.setEntityAsMissionEntity(zombie, true, false);
    game.setPedRelationshipGroupHash(zombie, game.getHashKey('zombeez'));
    //game.setPedArmour(zombie, 100);
    game.setPedAccuracy(zombie, 25);
    game.setPedSeeingRange(zombie, 100.0);
    game.setPedHearingRange(zombie, 100.0);
    game.setPedFleeAttributes(zombie, 0, 0);
    game.setPedCombatAttributes(zombie, 16, 1);
    game.setPedCombatAttributes(zombie, 17, 0);
    game.setPedCombatAttributes(zombie, 46, 1);
    game.setPedCombatAttributes(zombie, 1424, 0);
    game.setPedCombatAttributes(zombie, 5, 1);
    game.setPedCombatRange(zombie, 2);
    game.setAmbientVoiceName(zombie, 'ALIENS');
    game.setPedEnableWeaponBlocking(zombie, true);
    game.disablePedPainAudio(zombie, true);
    game.setPedDiesInWater(zombie, false);
    game.setPedDiesWhenInjured(zombie, false);
    if (game.hasAnimSetLoaded('move_m@drunk@verydrunk')) {
        game.setPedMovementClipset(zombie, 'move_m@drunk@verydrunk');
    }
    game.applyPedDamagePack(zombie, 'BigHitByVehicle', 0.0, 9.0);
    game.applyPedDamagePack(zombie, 'SCR_Dumpster', 0.0, 9.0);
    game.applyPedDamagePack(zombie, 'SCR_Torture', 0.0, 9.0);
    game.stopPedSpeaking(zombie, true);
    game.setAiMeleeWeaponDamageModifier(10000);

    /*let ZombiePos = game.getEntityCoords(zombie);
    game.taskWanderInArea(zombie, ZombiePos.x, ZombiePos.y, ZombiePos.z, 100);*/
}


async function loadModel(dict) {
    return new Promise(resolve => {
        if (game.hasModelLoaded(dict)) return resolve(true);
        game.requestModel(dict);
        let inter = alt.setInterval(() => {
            if (game.hasModelLoaded(dict)) {
                alt.clearInterval(inter);
                return resolve(true);
            }
        }, 5);
    });
}

/*
async function CreateKI(Id, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target) {
    return new Promise(resolve => {
        if (Zombies[Id]) return;
        for (var _c in Zombies) { if (Zombies[_c].Id == Id) { return; } }
        //if (Zombies.length > 0) if (Zombies.find(Zombie => Zombie.Id === Id)) return;
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
                OutOfStreamingRange: false,
                TargetEntity: Target,
            }
            SetZombieCorrectSkin(Zombies[Id].Entity, FaceFeatures, HeadBlendData, HeadOverlays);
            SetZombieAttributes(Zombies[Id].Entity);
        });
        return resolve(true);
    });
}
*/
async function SpawnZombie(Id, Hash, FaceFeatures, HeadBlendData, HeadOverlays, Position, Target) {
    try {
        if (Zombies[Id]) return;
        for (var _c in Zombies)
            if (Zombies[_c].Id == Id) return;

        //if (Zombies.length > 0) if (Zombies.find(Zombie => Zombie.Id === Id)) return;
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
                OutOfStreamingRange: false,
                TargetEntity: Target,
            }
            SetZombieCorrectSkin(Zombies[Id].Entity, FaceFeatures, HeadBlendData, HeadOverlays);
            SetZombieAttributes(Zombies[Id].Entity);
        });
    }
    catch (e) { alt.log(e); }
}



function MoveZombieToTarget(ID, TargetEntity) {
    if (Zombies[ID].IsDead) return;
    if (Zombies[ID].Frozen)
        game.freezeEntityPosition(Zombies[ID].Entity, false); Zombies[ID].Frozen = false;

    Zombies[ID].TargetEntity = TargetEntity;
    Zombies[ID].OutOfStreamingRange = false;

    let playerPos = game.getEntityCoords(Zombies[ID].TargetEntity.scriptID, true);
    game.taskGoToCoordAnyMeans(Zombies[ID].Entity, playerPos.x, playerPos.y, playerPos.z, 5, 0, false, 786603, 0);
    game.taskPutPedDirectlyIntoMelee(Zombies[ID].Entity, Zombies[ID].TargetEntity.scriptID, 0.0, -5.0, 1.0, false);


    if (game.isPedRunning(Zombies[ID].Entity)) {
        game.disablePedPainAudio(Zombies[ID].Entity, false);
        game.playPain(Zombies[ID].Entity, 8);
        //move_m@injured
        //game.setPedAlternateMovementAnim(Zombies[ID].Entity, 1, "move_m@injured", "sprint");
        //game.taskPlayAnim(Zombies[ID].Entity, "move_m@injured", "sprint", 8.0, 0, )
    }

}

/*
alt.everyTick(() => {
    DrawNametags();
});
*/



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





