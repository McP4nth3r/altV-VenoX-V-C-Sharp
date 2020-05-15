using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Zombie.World
{
    public class Main : IScript
    {
        public static Position PLAYER_SPAWN_NOOBSPAWN = new Position(-2132.323f, 2821.959f, 34.84159f); // Noobspawn
        public static int TIME_INTERVAL_ZOMBIES = 10; // Zeit in sekunden wie oft Zombies spawnen sollten.
        public static int ZOMBIE_AMMOUNT_EACH_SPAWN = 2; // Zombies die Pro Spawn-Function Aufruf spawnen sollen.
        public static int TIME_INTERVAL_DELETE_ZOMBIES = 5;
        // ENTITYDATAS & TIMER
        public static DateTime TIME_TO_SPAWN_ZOMBIES = DateTime.Now;
        public static DateTime TIME_TO_DELETE_ZOMBIES = DateTime.Now;



        public static void SendPlayerWelcomeNotify(Client player)
        {
            try
            {
                player.SendTranslatedChatMessage("Willkommen im VenoX " + Core.RageAPI.GetHexColorcode(255, 0, 0) + " Zombie + " + RageAPI.GetHexColorcode(255, 255, 255) + "Modus");
                player.SendTranslatedChatMessage("Kämpfe um dein Überleben!");
            }
            catch { }
        }

        public static void InitializePlayerData(Client player)
        {
            try
            {
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_KILLS, 0);
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, 0);
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_TODE, 0);

            }
            catch { }
        }


        public static void OnSelectedZombieGM(Client player)
        {
            try
            {
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                player.SpawnPlayer(PLAYER_SPAWN_NOOBSPAWN);
                player.Emit("Zombie:OnResourceStart");
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 999);
                SendPlayerWelcomeNotify(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedZombieGM", ex); }
        }

        public static void OnUpdate()
        {
            if (TIME_TO_SPAWN_ZOMBIES <= DateTime.Now)
            {
                TIME_TO_SPAWN_ZOMBIES = DateTime.Now.AddSeconds(TIME_INTERVAL_ZOMBIES);
                for (var i = 0; i < ZOMBIE_AMMOUNT_EACH_SPAWN; i++)
                {
                    KI.Spawner.SpawnZombiesForEveryPlayer();
                }
            }
            if (TIME_TO_DELETE_ZOMBIES <= DateTime.Now)
            {
                TIME_TO_DELETE_ZOMBIES = DateTime.Now.AddSeconds(TIME_INTERVAL_DELETE_ZOMBIES);
                if (_Gamemodes_.Zombie.Globals.Events.KilledZombieIds.Count > 0)
                {
                    foreach (int Id in _Gamemodes_.Zombie.Globals.Events.KilledZombieIds)
                    {
                        KI.Spawner.DestroyZombieById(Id);
                    }
                }
            }
        }
    }
}
