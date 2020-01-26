using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;

namespace VenoXV.Anti_Cheat
{
    public class AntiCheat_Allround : IScript
    {
        public static void SetTimeOutTeleport(IPlayer player, int value)
        {
            player.Emit("FreezeTPTimer", value);
        }

        public static void SetTimeOutHealth(IPlayer player, int value)
        {
            player.Emit("FreezeHealthTimer", value);
        }

        public static void StartTimerTeleport(IPlayer player)
        {
            player.Emit("StartTPTimer");
        }

        public static void StopTimerTeleport(IPlayer player)
        {
            player.Emit("StopTPTimer");
        }


        public static string GetRandomAnticheatPeds()
        {
            Random random = new Random();
            int randomzahl = random.Next(1, 10);
            if(randomzahl == 1)
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


        public static void Create_Anticheat_Peds(IPlayer player)
        {
            try
            {
                player.SendChatMessage("AC:LOADED");
                int counter = 0;
                for (var i = 0; i <= 4; i++)
                {
                    if (counter == 0)
                    {
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(), 2, 0, 0, 1, 0,0);
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
                        Alt.EmitAllClients("Anticheat:Load", player, GetRandomAnticheatPeds(),0, -2, 0, 0, -1, 0);
                    }
                    counter += 1;
                }
            }
            catch { }
        }

       /* [Command("createacped")]
        public static void CreateACPED(IPlayer player)
        {
            foreach (IPlayer players in Alt.GetAllPlayers())
            {
                Create_Anticheat_Peds(players);
            }
        }*/
        public static void Anticheat_time_ban(IPlayer player, int time, string Banhash)
        {
            try
            {
                Database.AddPlayerTimeBan((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), player.SocialClubId.ToString().ToString(), player.HardwareIdHash.ToString(), Banhash, "ANTI_CHEAT_" + Banhash, DateTime.Now.AddHours(time), DateTime.Now);
                Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(255,0,0) + player.Name + " wurde von [VenoX Anti-Cheat Shield] für " + time + " Stunden gebannt! Grund : # " + Banhash);
                player.Kick("~r~Grund : " + " [ANTI-CHEAT] Weapon # " + Banhash);
            }
            catch { }
        }
    }
}
