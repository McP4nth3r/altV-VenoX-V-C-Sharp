using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.KI;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Zombie.World
{
    public class Main : IScript
    {
        //public static Position PLAYER_SPAWN_NOOBSPAWN = new Position(-2132.323f, 2821.959f, 34.84159f); // Noobspawn
        public static Position PLAYER_SPAWN_NOOBSPAWN = new Position(0, 0, 72); // Noobspawn
        public static int TIME_INTERVAL_ZOMBIES = 10; // Zeit in sekunden wie oft Zombies spawnen sollten.
        public static int ZOMBIE_AMMOUNT_EACH_SPAWN = 1; // Zombies die Pro Spawn-Function Aufruf spawnen sollen.
        public static int TIME_INTERVAL_DELETE_ZOMBIES = 5;
        public static int TIME_INTERVAL_SYNCER_UPDATE = 1; // Time in Minutes
        public static int TIME_INTERVAL_TARGET_UPDATE = 1; // Time in Seconds
        public static int MAX_ZOMBIE_RANGE = 150;
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
                Alt.Server.TriggerClientEvent(player, "Zombie:OnResourceStart");
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.RPG, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Grenade, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.GrenadeLauncher, 999);
                SendPlayerWelcomeNotify(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void SetBestPlayerByPing(VnXPlayer player)
        {
            try
            {
                uint BestPing = player.Ping;
                //Clear NearbyPlayers.
                player.Zombies.NearbyPlayers.Clear();

                // Get Nearby Players
                foreach (VnXPlayer otherplayers in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    if (otherplayers.Position.Distance(player.Position) <= MAX_ZOMBIE_RANGE && player != otherplayers)
                        player.Zombies.NearbyPlayers.Add(otherplayers);
                }
                //If no one is near you, you are the Syncer.
                if (player.Zombies.NearbyPlayers.Count <= 0) player.Zombies.IsSyncer = true;
                else
                {
                    // Get New Syncer.
                    foreach (VnXPlayer nearbyPlayers in player.Zombies.NearbyPlayers.ToList())
                    {
                        if (BestPing < nearbyPlayers.Ping)
                        {
                            BestPing = nearbyPlayers.Ping;
                            nearbyPlayers.Zombies.IsSyncer = true;
                            player.Zombies.IsSyncer = false;
                            //Core.Debug.OutputDebugString("Syncer for nearest Area : " + nearbyPlayers.Username);
                        }
                        else
                        {
                            nearbyPlayers.Zombies.IsSyncer = false;
                            player.Zombies.IsSyncer = true;
                            Alt.Server.TriggerClientEvent(player, "Zombies:Sync", false);
                            nearbyPlayers.Emit("Zombies:Sync", false);
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
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
                        if (player.Zombies.IsSyncer)
                            Alt.Server.TriggerClientEvent(player, "Zombies:Sync", true);
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
                        if (player is null) continue;
                        // Get new Zombie Target Entity.
                        if (player.Position.Distance(zombieClass.Position) < 50) zombieClass.TargetEntity = player;
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void SyncZombieTargeting()
        {
            try
            {
                foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                {
                    foreach (VnXPlayer player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    {
                        if (player != null)
                        {
                            if (player.Position.Distance(zombieClass.Position) < 150 && !zombieClass.IsDead)
                                Alt.Server.TriggerClientEvent(player, "Zombies:MoveToTarget", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                            else
                            {
                                player.Zombies.NearbyZombies.Remove(zombieClass);
                                Alt.Server.TriggerClientEvent(player, "Zombies:DeleteTempZombieById", zombieClass.ID);
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
                    SyncZombieTargeting();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
