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
        public static void OnZombieDeath(VnXPlayer player = null, int Id = 0)
        {
            try
            {
                ZombieModel zombie = Spawner.CurrentZombies.FirstOrDefault(z => z.ID == Id);
                if (zombie != null) zombie.IsDead = true;
                if (player is null || !player.Exists) return;
                lock (player)
                {
                    player.Zombies.Zombie_kills += 1;
                    if (LevelSystem.LevelWeapons.ContainsKey(player.Zombies.Zombie_kills))
                    {
                        player.SendChatMessage("Neue Waffen freigeschaltet! [" + RageAPI.GetHexColorcode(0, 200, 255) + player.Zombies.Zombie_kills + RageAPI.GetHexColorcode(255, 255, 255) + " - " + LevelSystem.LevelWeapons[player.Zombies.Zombie_kills] + "]");
                        LevelSystem.GivePlayerWeaponsByLevel(player);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
        public static void OnZombiesSyncerCall(VnXPlayer player = null, int ZombieId = 0, float ZombiePosX = 0, float ZombiePosY = 0, float ZombiePosZ = 0, float ZombieRotX = 0, float ZombieRotY = 0, float ZombieRotZ = 0)
        {
            try
            {
                ZombieModel zombie = Spawner.CurrentZombies.FirstOrDefault(z => z.ID == ZombieId);
                if (zombie != null) zombie.UpdatePositionAndRotation(new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ), new Vector3(ZombieRotX, ZombieRotY, ZombieRotZ));
                World.Main.SyncZombieTargeting();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
