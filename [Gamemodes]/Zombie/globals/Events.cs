using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Events : IScript
    {
        public static List<int> KilledZombieIds = new List<int>();
        [ClientEvent("Zombies:OnZombieDeath")]
        public static void OnZombieDeath(VnXPlayer player, int Id)
        {
            try
            {
                Core.Debug.OutputDebugString("Zombies:OnZombieDeath with ID : " + Id + " called");
                if (KilledZombieIds.Contains(Id)) return;
                KilledZombieIds.Add(Id);
                //Spawner.DestroyZombieById(Id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                player.Zombies.IsSyncer = false;
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    if (players.Zombies.NearbyPlayers.Contains(player)) { player.Zombies.NearbyPlayers.Remove(player); }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ClientEvent("Zombies:OnSyncerCall")]
        public static void OnZombiesSyncerCall(VnXPlayer player, int ZombieId, float ZombiePosX, float ZombiePosY, float ZombiePosZ)
        {
            try
            {
                foreach (ZombieModel zombieClass in KI.Spawner.CurrentZombies.ToList())
                {
                    if (zombieClass.ID == ZombieId)
                    {
                        zombieClass.Position = new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ);
                        foreach (VnXPlayer nearbyClients in player.Zombies.NearbyPlayers.ToList())
                        {
                            if (nearbyClients == null) { player.Zombies.NearbyPlayers.Remove(nearbyClients); }
                            else { nearbyClients.Emit("Zombies:SetPosition", ZombieId, ZombiePosX, ZombiePosY, ZombiePosZ); }
                        }
                    }
                }
                World.Main.SyncZombieTargeting();
                /*if (!foundById)
                {
                    foreach (Client nearbyClients in player.Zombies.NearbyPlayers)
                    {
                        nearbyClients.Emit("Zombies:Delete", ZombieId);
                    }
                }*/
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
