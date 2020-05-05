using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
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

        // ENTITYDATAS & TIMER
        public static DateTime TIME_TO_SPAWN_ZOMBIES = DateTime.Now;



        public static void SendPlayerWelcomeNotify(PlayerModel player)
        {
            try
            {
                player.SendChatMessage("Willkommen im VenoX ~r~Zombie + " + RageAPI.GetHexColorcode(255, 255, 255) + "Modus");
                player.SendChatMessage("Kämpfe um dein Überleben!");
            }
            catch { }
        }

        public static void InitializePlayerData(PlayerModel player)
        {
            try
            {
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_KILLS, 0);
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, 0);
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_TODE, 0);

            }
            catch { }
        }


        public static void OnSelectedZombieGM(PlayerModel player)
        {
            try
            {
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                //NAPI.player.SpawnPlayerPlayer(player, PLAYER_SPAWN_NOOBSPAWN);
                //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                player.Emit("Zombie:OnResourceStart");
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 999);
                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 999);
                SendPlayerWelcomeNotify(player);
            }
            catch { }
        }

        public static void OnUpdate()
        {
            if (TIME_TO_SPAWN_ZOMBIES <= DateTime.Now)
            {
                TIME_TO_SPAWN_ZOMBIES = DateTime.Now.AddSeconds(TIME_INTERVAL_ZOMBIES);
                for (var i = 0; i <= ZOMBIE_AMMOUNT_EACH_SPAWN; i++)
                {
                    KI.Spawner.SpawnZombiesArroundPlayers();
                }
            }
        }
    }
}
