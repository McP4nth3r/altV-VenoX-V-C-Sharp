using AltV.Net;
using AltV.Net.Async;
using System;
using System.Collections.Generic;
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
        public static List<VehicleModel> ZombieVehicles = new List<VehicleModel>();
        private static List<AltV.Net.Enums.VehicleModel> RandomVehicleList = new List<AltV.Net.Enums.VehicleModel>
        {
            { AltV.Net.Enums.VehicleModel.Adder },
            { AltV.Net.Enums.VehicleModel.Voltic2 },
            { AltV.Net.Enums.VehicleModel.Hakuchou },
            { AltV.Net.Enums.VehicleModel.F620 },
            { AltV.Net.Enums.VehicleModel.Sultan },
            { AltV.Net.Enums.VehicleModel.Faction },
            { AltV.Net.Enums.VehicleModel.Raiden },
            { AltV.Net.Enums.VehicleModel.Elegy },
        };


        //public static List<int> KilledZombieIds = new List<int>();
        [AsyncClientEvent("Zombies:OnZombieDeath")]
        public static void OnZombieDeath(VnXPlayer player = null, int Id = 0, float ZombiePosX = 0, float ZombiePosY = 0, float ZombiePosZ = 0, float ZombieRotX = 0, float ZombieRotY = 0, float ZombieRotZ = 0)
        {
            try
            {
                ZombieModel zombie = Spawner.CurrentZombies.FirstOrDefault(z => z.ID == Id);
                if (zombie != null) zombie.IsDead = true;
                if (player is null || !player.Exists) return;
                lock (player)
                {
                    if (zombie != null) zombie.Killer = player;
                    player.Zombies.Zombie_kills += 1;
                    if (LevelSystem.LevelWeapons.ContainsKey(player.Zombies.Zombie_kills))
                    {
                        player.SendTranslatedChatMessage("Neue Waffen freigeschaltet! [" + RageAPI.GetHexColorcode(0, 200, 255) + player.Zombies.Zombie_kills + RageAPI.GetHexColorcode(255, 255, 255) + " - " + LevelSystem.LevelWeapons[player.Zombies.Zombie_kills] + "]");
                        LevelSystem.GivePlayerWeaponsByLevel(player);
                    }
                    CreateVehicleSpawnChance(player, new Vector3(ZombiePosX, ZombiePosY, ZombiePosZ), new Vector3(ZombieRotX, ZombieRotY, ZombieRotZ));
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void CreateVehicleSpawnChance(VnXPlayer player, Vector3 Position, Vector3 Rotation)
        {
            try
            {
                Random random = new Random();
                int randomnumb = random.Next(0, 20);
                Core.Debug.OutputDebugString("Chance  : " + randomnumb);
                if (randomnumb == 10)
                {
                    Core.Debug.OutputDebugString("Position  : " + Position);
                    Core.Debug.OutputDebugString("Rotation  : " + Rotation);
                    Random random1 = new Random();
                    int RandomVehIndex = random1.Next(0, RandomVehicleList.Count);
                    VehicleModel veh = (VehicleModel)Alt.CreateVehicle(RandomVehicleList[RandomVehIndex], Position, Rotation);
                    veh.Dimension = VenoXV._Globals_.Main.ZOMBIES_DIMENSION;
                    veh.NotSave = true;
                    veh.EngineOn = true;
                    veh.Owner = player.Username;
                    veh.Kms = 0;
                    veh.Gas = 1000f;
                    ZombieVehicles.Add(veh);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                player.Zombies.IsSyncer = false;
                if (VenoXV._Globals_.Main.ZombiePlayers.Count <= 0)
                {
                    foreach (VehicleModel vehicleClass in ZombieVehicles.ToList())
                        RageAPI.DeleteVehicleThreadSafe(vehicleClass);
                    ZombieVehicles.Clear();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("Zombies:OnSyncerCall")]
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
