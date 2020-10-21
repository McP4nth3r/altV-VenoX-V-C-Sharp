using AltV.Net;
using AltV.Net.Async;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.KI;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Events : IScript
    {
        //public static List<int> KilledZombieIds = new List<int>();
        [AsyncClientEvent("Zombies:OnZombieDeath")]
        public static async void OnZombieDeath(VnXPlayer player, int Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    ZombieModel zombie = Spawner.CurrentZombies.FirstOrDefault(z => z.ID == Id);
                    if (zombie != null) zombie.IsDead = true;
                });
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
        public static async void OnZombiesSyncerCall(VnXPlayer player, int ZombieId, float ZombiePosX, float ZombiePosY, float ZombiePosZ, float ZombieRotX, float ZombieRotY, float ZombieRotZ)
        {
            try
            {
                await Task.Run(() =>
                {
                    foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                    {
                        if (zombieClass.ID == ZombieId)
                        {
                            zombieClass.Position = new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ);
                            zombieClass.Rotation = new Vector3(ZombieRotX, ZombieRotY, ZombieRotZ);
                        }
                    }
                });
                World.Main.SyncZombieTargeting();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
