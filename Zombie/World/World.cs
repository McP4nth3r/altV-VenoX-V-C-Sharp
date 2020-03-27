using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
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



        public static void SendPlayerWelcomeNotify(IPlayer player)
        {
            try
            {
                player.SendChatMessage( "Willkommen im VenoX ~r~Zombie + " + RageAPI.GetHexColorcode(255,255,255) + "Modus");
                player.SendChatMessage( "Kämpfe um dein Überleben!");
            }
            catch { }
        }


        public static void OnSelectedZombieGM(IPlayer player)
        {
            try
            {
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                //NAPI.Player.SpawnPlayer(player, PLAYER_SPAWN_NOOBSPAWN);
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
            if(TIME_TO_SPAWN_ZOMBIES <= DateTime.Now)
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
