using AltV.Net;
using AltV.Net.Data;
using System;
using System.Linq;
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
        public static int TIME_INTERVAL_ZOMBIES = 20; // Zeit in sekunden wie oft Zombies spawnen sollten.
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


        public static void OnSelectedZombieGM(VnXPlayer player)
        {
            try
            {
                player.SpawnPlayer(PLAYER_SPAWN_NOOBSPAWN);
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
                player.Zombies.NearbyPlayers.Clear();
                foreach (VnXPlayer otherplayers in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    if (otherplayers.Position.Distance(player.Position) <= MAX_ZOMBIE_RANGE && player != otherplayers)
                    {
                        player.Zombies.NearbyPlayers.Add(otherplayers);
                    }
                }
                if (player.Zombies.NearbyPlayers.Count <= 0) player.Zombies.IsSyncer = true;
                else
                {
                    foreach (VnXPlayer nearbyPlayers in player.Zombies.NearbyPlayers.ToList())
                    {
                        if (BestPing < nearbyPlayers.Ping)
                        {
                            BestPing = nearbyPlayers.Ping;
                            nearbyPlayers.Zombies.IsSyncer = true;
                            player.Zombies.IsSyncer = false;
                            Core.Debug.OutputDebugString("Syncer for nearest Area : " + nearbyPlayers.Username);
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
                        {
                            Alt.Server.TriggerClientEvent(player, "Zombies:Sync", true);
                        }
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
                        if (player != null)
                        {
                            if (player.Position.Distance(zombieClass.Position) < 50)
                            {
                                zombieClass.TargetEntity = player;
                            }
                        }
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
                            if (player.Position.Distance(zombieClass.Position) < 150 && !Globals.Events.KilledZombieIds.Contains(zombieClass.ID))
                            {
                                Alt.Server.TriggerClientEvent(player, "Zombies:MoveToTarget", zombieClass.ID, zombieClass.SkinName, zombieClass.FaceFeatures, zombieClass.HeadBlendData, zombieClass.HeadOverlays, zombieClass.Position, zombieClass.TargetEntity);
                            }
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
                    if (Globals.Events.KilledZombieIds.Count > 0)
                    {
                        Debug.OutputDebugString("TIME_TO_DELETE_ZOMBIES Called!");
                        foreach (int Id in Globals.Events.KilledZombieIds.ToList())
                        {
                            Spawner.DestroyZombieById(Id);
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
