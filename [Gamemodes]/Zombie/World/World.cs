using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.KI;
using VenoXV._Gamemodes_.Zombie.KI;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Zombie.World
{
    public class Main : IScript
    {
        //public static Position PLAYER_SPAWN_NOOBSPAWN = new Position(-2132.323f, 2821.959f, 34.84159f); // Noobspawn
        public static Position PLAYER_SPAWN_NOOBSPAWN = new Position(0, 0, 72); // Noobspawn
        public static int TIME_INTERVAL_ZOMBIES = 10; // Zeit in sekunden wie oft Zombies spawnen sollten.
        public static int ZOMBIE_AMMOUNT_EACH_SPAWN = 2; // Zombies die Pro Spawn-Function Aufruf spawnen sollen.
        public static int TIME_INTERVAL_DELETE_ZOMBIES = 5;
        public static int TIME_INTERVAL_SYNCER_UPDATE = 1; // Time in Minutes
        public static int TIME_INTERVAL_TARGET_UPDATE = 2; // Time in Seconds
        public static int MAX_ZOMBIE_RANGE = 300;
        // ENTITYDATAS & TIMER
        public static DateTime TIME_TO_SPAWN_ZOMBIES = DateTime.Now;
        public static DateTime TIME_TO_DELETE_ZOMBIES = DateTime.Now;
        public static DateTime TIME_TO_GET_NEW_SYNCER = DateTime.Now;
        public static DateTime TIME_TO_GET_NEW_TARGET = DateTime.Now;



        public static void SendPlayerWelcomeNotify(VnXPlayer player)
        {
            try
            {
                player.SendTranslatedChatMessage("Willkommen im VenoX " + RageAPI.GetHexColorcode(255, 0, 0) + " Zombie + " + RageAPI.GetHexColorcode(255, 255, 255) + "Modus");
                player.SendTranslatedChatMessage("Kämpfe um dein Überleben!");
            }
            catch { }
        }

        public static readonly List<Vector3> PLAYER_SPAWNS = new List<Vector3>
        {
            new Vector3(-117.03297f,-604.66815f,36.272583f),
            new Vector3(50.861538f,-136.21979f,55.194824f),
            new Vector3(213.27032f,-921.1517f,30.678345f),
            new Vector3(427.0681f,-978.989f,30.69519f),
            new Vector3(-10.892307f,-1118.6901f,27.578003f),
            new Vector3(130.66814f,-1032.8308f,29.431519f),
        };

        public static void OnSelectedZombieGM(VnXPlayer player)
        {
            try
            {
                Random random = new Random();
                int randomnumb = random.Next(0, PLAYER_SPAWNS.Count);
                player.SpawnPlayer(PLAYER_SPAWNS[randomnumb]);
                player.Dimension = VenoXV.Globals.Main.ZOMBIES_DIMENSION;
                //VenoX.TriggerClientEvent(player, "Zombie:OnResourceStart");
                LevelSystem.GivePlayerWeaponsByLevel(player);
                SendPlayerWelcomeNotify(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void OnPlayerDeath(VnXPlayer player)
        {
            try
            {
                Random random = new Random();
                int randomnumb = random.Next(0, PLAYER_SPAWNS.Count);
                player.SpawnPlayer(PLAYER_SPAWNS[randomnumb]);
                player.Dimension = VenoXV.Globals.Main.ZOMBIES_DIMENSION;
                player.Zombies.Zombie_tode += 1;
                LevelSystem.GivePlayerWeaponsByLevel(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void SetBestPlayerByPing(VnXPlayer player)
        {
            try
            {
                if (player is null || !player.Exists) return;
                uint BestPing = player.Ping;
                //If no one is near you, you are the Syncer.
                if (player.NearbyPlayers.Count <= 0) player.Zombies.IsSyncer = true;
                else
                {
                    // Get New Syncer.
                    foreach (VnXPlayer nearbyPlayers in player.NearbyPlayers.ToList())
                    {
                        if (nearbyPlayers is null || !nearbyPlayers.Exists) continue;
                        if (BestPing < nearbyPlayers.Ping)
                        {
                            BestPing = nearbyPlayers.Ping;
                            nearbyPlayers.Zombies.IsSyncer = true;
                            player.Zombies.IsSyncer = false;
                        }
                        else
                        {
                            nearbyPlayers.Zombies.IsSyncer = false;
                            player.Zombies.IsSyncer = true;
                            VenoX.TriggerClientEvent(player, "Zombies:Sync", false);
                            VenoX.TriggerClientEvent(nearbyPlayers, "Zombies:Sync", false);
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void GetBestAreaSyncer()
        {
            try
            {
                foreach (VnXPlayer player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    if (player != null)
                    {
                        SetBestPlayerByPing(player);
                        if (player.Zombies.IsSyncer) VenoX.TriggerClientEvent(player, "Zombies:Sync", true, player.NearbyPlayers.Count);
                        //VenoX.TriggerClientEvent(player, "Zombies:Sync", true);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void GetNewZombieTarget()
        {
            try
            {
                foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                {
                    foreach (VnXPlayer player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    {
                        if (player is null || !player.Exists) continue;
                        // Get new Zombie Target Entity.
                        if (player.Position.Distance(zombieClass.Position) < 50) zombieClass.TargetEntity = player;
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SyncZombieTargeting()
        {
            try
            {
                long move = Convert.ToInt64(DateTime.UtcNow.AddSeconds(5).Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
                foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                {
                    foreach (VnXPlayer player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    {
                        if (player != null && player.Exists)
                        {
                            if (player.Position.Distance(zombieClass.Position) < 150 && !zombieClass.IsDead)
                            {
                                if (!player.Zombies.NearbyZombies.Contains(zombieClass)) player.Zombies.NearbyZombies.Add(zombieClass);
                                VenoX.TriggerClientEvent(player, "Zombies:MoveToTarget", zombieClass.ID, zombieClass.SkinName, zombieClass.Position, zombieClass.Rotation, zombieClass.TargetEntity, move);
                            }
                            else
                            {
                                if (player.Zombies.NearbyZombies.Contains(zombieClass))
                                {
                                    player.Zombies.NearbyZombies.Remove(zombieClass);
                                    VenoX.TriggerClientEvent(player, "Zombies:DeleteTempZombieById", zombieClass.ID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        public static void OnUpdate()
        {
            try
            {
                if (TIME_TO_SPAWN_ZOMBIES <= DateTime.Now)
                {
                    TIME_TO_SPAWN_ZOMBIES = DateTime.Now.AddSeconds(TIME_INTERVAL_ZOMBIES);
                    for (var i = 0; i < ZOMBIE_AMMOUNT_EACH_SPAWN; i++)
                    {
                        Spawner.SpawnZombiesForEveryPlayer();
                    }
                }
                if (TIME_TO_DELETE_ZOMBIES <= DateTime.Now)
                {
                    TIME_TO_DELETE_ZOMBIES = DateTime.Now.AddSeconds(TIME_INTERVAL_DELETE_ZOMBIES);
                    foreach (ZombieModel zombies in Spawner.CurrentZombies.ToList())
                    {
                        if (zombies.IsDead)
                        {
                            // remove every nearby zombie for every client.
                            zombies.Destroy();
                        }
                    }
                }
                if (TIME_TO_GET_NEW_SYNCER <= DateTime.Now)
                {
                    TIME_TO_GET_NEW_SYNCER = DateTime.Now.AddMinutes(TIME_INTERVAL_SYNCER_UPDATE);
                    GetBestAreaSyncer();
                }
                if (TIME_TO_GET_NEW_TARGET <= DateTime.Now)
                {
                    TIME_TO_GET_NEW_TARGET = DateTime.Now.AddSeconds(TIME_INTERVAL_TARGET_UPDATE);
                    GetNewZombieTarget();
                    //SyncZombieTargeting();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
