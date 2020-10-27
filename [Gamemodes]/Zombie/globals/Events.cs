using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.KI;
using VenoXV._Gamemodes_.Zombie.KI;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Events : IScript
    {
        //public static List<int> KilledZombieIds = new List<int>();
        [AsyncClientEvent("Zombies:OnZombieDeath")]
        public static void OnZombieDeath(VnXPlayer player, int Id)
        {
            try
            {
                lock (player)
                {
                    if (player is null || !player.Exists) return;
                    ZombieModel zombie = Spawner.CurrentZombies.FirstOrDefault(z => z.ID == Id);
                    if (zombie != null) zombie.IsDead = true;
                    player.Zombies.Zombie_kills += 1;
                    if (LevelSystem.LevelWeapons.ContainsKey(player.Zombies.Zombie_kills))
                    {
                        player.SendChatMessage("Neue Waffen freigeschaltet! [" + RageAPI.GetHexColorcode(0, 200, 255) + player.Zombies.Zombie_kills + RageAPI.GetHexColorcode(255, 255, 255) + " - " + LevelSystem.LevelWeapons[player.Zombies.Zombie_kills] + "]");
                        LevelSystem.GivePlayerWeaponsByLevel(player);
                    }
                }
                //Core.Debug.OutputDebugString("Zombies:OnZombieDeath with ID : " + Id + " called");
                //if (KilledZombieIds.Contains(Id)) return;
                //KilledZombieIds.Add(Id);
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
                    if (players.Zombies.NearbyPlayers.Contains(player)) players.Zombies.NearbyPlayers.Remove(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [AsyncClientEvent("Zombies:OnSyncerCall")]
        public static void OnZombiesSyncerCall(VnXPlayer player, int ZombieId, float ZombiePosX, float ZombiePosY, float ZombiePosZ, float ZombieRotX, float ZombieRotY, float ZombieRotZ)
        {
            try
            {
                lock (player)
                {
                    if (player is null || !player.Exists) return;
                    foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                    {
                        if (zombieClass.ID == ZombieId)
                        {
                            zombieClass.UpdatePositionAndRotation(new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ), new Vector3(ZombieRotX, ZombieRotY, ZombieRotZ));
                            //zombieClass.Position = new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ);
                            //zombieClass.Rotation = new Vector3(ZombieRotX, ZombieRotY, ZombieRotZ);
                        }
                    }
                }
                World.Main.SyncZombieTargeting();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
