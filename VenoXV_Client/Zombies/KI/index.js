//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import * as alt from 'alt-client';
import * as game from "natives";


// SETTINGS 

let DestroyZombiesAfterMS = 5000;


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
let Zombies = [];
game.requestAnimDict("special_ped@zombie@monologue_6@monologue_6a");
let ZombieHash = game.getHashKey("u_m_y_zombie_01");
alt.loadModel(ZombieHash);
game.requestModel(ZombieHash);
alt.onServer('Zombies:SpawnKI', (Id, Hash, Position, Target) => {
    if (Zombies[Id]) { return; }
    let zombieEntity = game.createPed(2, game.getHashKey(Hash), Position.x, Position.y, Position.z, 0, false, false);
    Zombies[Id] = {
        Id: Id,
        Entity: zombieEntity,
        IsZombieKI: true,
        Position: Position,
        IsDead: false,
        TargetEntity: Target,
    }
    game.setPedCanRagdoll(Zombies[Id], true);
    game.setEntityCanBeDamaged(Zombies[Id], true);
    game.setEntityOnlyDamagedByPlayer(Zombies[Id], false);
    game.setPedRagdollOnCollision(Zombies[Id], true);
    game.setPedCanRagdollFromPlayerImpact(Zombies[Id], true)
    game.setPedCombatMovement(Zombies[Id], 100);
    game.setPedCombatAbility(Zombies[Id], 100);
    game.setPedFleeAttributes(Zombies[Id], 0, false);
    game.setPedCombatAttributes(Zombies[Id], 16, true);
    game.setPedCombatAttributes(Zombies[Id], 17, true);
    game.setBlockingOfNonTemporaryEvents(Zombies[Id], true);
    game.setEntityProofs(Zombies[Id], false, false, false, false, false, false, false, false)
});

alt.onServer('Zombies:DeleteZombieById', (Id) => {
    for (var counter in Zombies) {
        if (Zombies[counter].Id == Id) {
            game.deletePed(Zombies[counter].Entity);
            Zombies.splice(counter, 1);
        }
    }
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

function MoveZombiesToPlayers() {
    for (var counter in Zombies) {
        let Zombie = Zombies[counter];
        if (Zombie.Entity != null) {
            let playerPos = game.getEntityCoords(Zombie.TargetEntity.scriptID, true);
            let zombiePos = Zombie.Position;
            if (game.getDistanceBetweenCoords(playerPos.x, playerPos.y, playerPos.z, zombiePos.x, zombiePos.y, zombiePos.z, false) < 35) {
                game.taskGoToCoordAnyMeans(Zombie.Entity, playerPos.x, playerPos.y, playerPos.z, 5, 0, false, 786603, 0);
                game.taskPutPedDirectlyIntoMelee(Zombie.Entity, Zombie.TargetEntity.scriptID, 0.0, -5.0, 1.0, false);
            }
            else {
                //ToDo : Tell it to the Server, Send a new Target to the Client/- or Destroy the Zombie!
            }
            if (game.getEntityHealth(Zombie.Entity) <= 0 && !Zombie.IsDead) {
                alt.emitServer("Zombies:OnZombieDeath", Zombie.Id);
                Zombie.IsDead = true;
                //mp.events.callRemote('OnZombieKill');
            }
        }
    }
}

alt.setInterval(() => {
    MoveZombiesToPlayers();
}, 100);

