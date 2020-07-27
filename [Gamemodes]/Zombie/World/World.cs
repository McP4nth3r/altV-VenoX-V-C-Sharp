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
        public static int TIME_INTERVAL_ZOMBIES = 10; // Zeit in sekunden wie oft Zombies spawnen sollten.
        public static int ZOMBIE_AMMOUNT_EACH_SPAWN = 2; // Zombies die Pro Spawn-Function Aufruf spawnen sollen.
        public static int TIME_INTERVAL_DELETE_ZOMBIES = 5;
        public static int TIME_INTERVAL_SYNCER_UPDATE = 1; // Time in Minutes
        public static int TIME_INTERVAL_TARGET_UPDATE = 1; // Time in Seconds
        // ENTITYDATAS & TIMER
        public static DateTime TIME_TO_SPAWN_ZOMBIES = DateTime.Now;
        public static DateTime TIME_TO_DELETE_ZOMBIES = DateTime.Now;
        public static DateTime TIME_TO_GET_NEW_SYNCER = DateTime.Now;
        public static DateTime TIME_TO_GET_NEW_TARGET = DateTime.Now;



        public static void SendPlayerWelcomeNotify(Client player)
        {
            try
            {
                player.SendTranslatedChatMessage("Willkommen im VenoX " + RageAPI.GetHexColorcode(255, 0, 0) + " Zombie + " + RageAPI.GetHexColorcode(255, 255, 255) + "Modus");
                player.SendTranslatedChatMessage("Kämpfe um dein Überleben!");
            }
            catch { }
        }


        public static void OnSelectedZombieGM(Client player)
        {
            try
            {
                player.SpawnPlayer(PLAYER_SPAWN_NOOBSPAWN);
                Alt.Server.TriggerClientEvent(player, "Zombie:OnResourceStart");
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 999);
                SendPlayerWelcomeNotify(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedZombieGM", ex); }
        }

        private static void SetBestPlayerByPing(Client player)
        {
            try
            {
                uint BestPing = player.Ping;
                player.Zombies.NearbyPlayers.Clear();
                foreach (Client otherplayers in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    if (otherplayers.Position.Distance(player.Position) <= 100)
                    {
                        player.Zombies.NearbyPlayers.Add(otherplayers);
                    }
                }
                foreach (Client nearbyPlayers in player.Zombies.NearbyPlayers.ToList())
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
            catch (Exception ex) { Core.Debug.CatchExceptions("SetBestPlayerByPing", ex); }
        }
        public static void GetBestAreaSyncer()
        {
            try
            {
                foreach (Client player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                {
                    SetBestPlayerByPing(player);
                    if (player.Zombies.IsSyncer)
                    {
                        Alt.Server.TriggerClientEvent(player, "Zombies:Sync", true);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("GetBestAreaSyncer", ex); }
        }

        private static void GetNewZombieTarget()
        {
            try
            {
                foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                {
                    foreach (Client player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    {
                        if (player.Position.Distance(zombieClass.Position) < 50)
                        {
                            zombieClass.TargetEntity = player;
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("GetNewZombieTarget", ex); }
        }
        public static void SyncZombieTargeting()
        {
            try
            {
                foreach (ZombieModel zombieClass in Spawner.CurrentZombies.ToList())
                {
                    foreach (Client player in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    {
                        if (player.Position.Distance(zombieClass.Position) < 250)
                        {
                            Alt.Server.TriggerClientEvent(player, "Zombies:MoveToTarget", zombieClass.ID, zombieClass.TargetEntity);
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SyncZombieTargeting", ex); }
        }

        public static void OnUpdate()
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
                    foreach (int Id in Globals.Events.KilledZombieIds)
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
    }
}
