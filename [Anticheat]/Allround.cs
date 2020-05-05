using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Anti_Cheat
{
    public class AntiCheat_Allround : IScript
    {
        public static void SetTimeOutTeleport(PlayerModel player, int value)
        {
            player.Emit("FreezeTPTimer", value);
        }

        public static void SetTimeOutHealth(PlayerModel player, int value)
        {
            player.Emit("FreezeHealthTimer", value);
        }

        public static void StartTimerTeleport(PlayerModel player)
        {
            player.Emit("StartTPTimer");
        }

        public static void StopTimerTeleport(PlayerModel player)
        {
            player.Emit("StopTPTimer");
        }


        public static string GetRandomAnticheatPeds()
        {
            Random random = new Random();
            int randomzahl = random.Next(1, 10);
            if (randomzahl == 1)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 2)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 3)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 4)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 5)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 6)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 7)
            {
                return "a_m_y_mexthug_01";
            }
            else if (randomzahl == 8)
            {
                return "a_m_y_mexthug_01";
            }
            else
            {
                return "a_m_y_mexthug_01";
            }
        }


        public static void Create_Anticheat_Peds(PlayerModel player)
        {
            try
            {
                player.SendChatMessage("AC:LOADED");
                int counter = 0;
                for (var i = 0; i <= 4; i++)
                {
                    if (counter == 0)
                    {
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(), 2, 0, 0, 1, 0, 0);
                    }
                    if (counter == 1)
                    {
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(), -2, 0, 0, -1, 0, 0);
                    }
                    if (counter == 2)
                    {
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(), 0, +2, 0, 0, 1, 0);
                    }
                    if (counter == 3)
                    {
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(), 0, -2, 0, 0, -1, 0);
                    }
                    counter += 1;
                }
            }
            catch { }
        }

        /* [Command("createacped")]
         public static void CreateACPED(PlayerModel player)
         {
             foreach (PlayerModel players in Alt.GetAllPlayers())
             {
                 Create_Anticheat_Peds(players);
             }
         }*/
        public static void Anticheat_time_ban(PlayerModel player, int time, string Banhash)
        {
            try
            {
                Database.AddPlayerTimeBan((int)player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), player.SocialClubId.ToString().ToString(), player.HardwareIdHash.ToString(), Banhash, "ANTI_CHEAT_" + Banhash, DateTime.Now.AddHours(time), DateTime.Now);
                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(255, 0, 0) + player.GetVnXName() + " wurde von [VenoX Anti-Cheat Shield] für " + time + " Stunden gebannt! Grund : # " + Banhash);
                player.Kick("~r~Grund : " + " [ANTI-CHEAT] Weapon # " + Banhash);
            }
            catch { }
        }
    }
}
