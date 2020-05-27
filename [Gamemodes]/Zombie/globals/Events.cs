using AltV.Net;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.KI;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Events : IScript
    {
        public static List<int> KilledZombieIds = new List<int>();
        [ClientEvent("Zombies:OnZombieDeath")]
        public static void OnZombieDeath(Client player, int Id)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.ZombiePlayers)
                {
                    Alt.Server.TriggerClientEvent(players, "Zombies:SetHealth", Id, 0);
                }
                if (!KilledZombieIds.Contains(Id)) KilledZombieIds.Add(Id);
                Spawner.DestroyZombieById(Id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Zombies:OnZombieDeath", ex); }
        }

        [ClientEvent("Zombies:OnSyncerCall")]
        public static void OnZombiesSyncerCall(Client player, int ZombieId, float ZombiePosX, float ZombiePosY, float ZombiePosZ)
        {
            try
            {
                bool foundById = false;
                foreach (ZombieModel zombieClass in KI.Spawner.CurrentZombies)
                {
                    if (zombieClass.ID == ZombieId)
                    {
                        foundById = true;
                        zombieClass.Position = new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ);
                        foreach (Client nearbyClients in player.Zombies.NearbyPlayers)
                        {
                            nearbyClients.Emit("Zombies:SetPosition", ZombieId, ZombiePosX, ZombiePosY, ZombiePosZ);
                        }
                    }
                }
                if (!foundById)
                {
                    foreach (Client nearbyClients in player.Zombies.NearbyPlayers)
                    {
                        nearbyClients.Emit("Zombies:Delete", ZombieId);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Zombies:OnSyncerCall", ex); }
        }
    }
}
