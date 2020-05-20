using AltV.Net;
using System;
using VenoXV._RootCore_.Models;
namespace VenoXV.Anti_Cheat
{
    public class AntiCheat_Allround : IScript
    {
        public static void SetTimeOutTeleport(Client player, int value)
        {
            player.Emit("FreezeTPTimer", value);
        }

        public static void SetTimeOutHealth(Client player, int value)
        {
            player.Emit("FreezeHealthTimer", value);
        }

        public static void StartTimerTeleport(Client player)
        {
            player.Emit("StartTPTimer");
        }

        public static void StopTimerTeleport(Client player)
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



        /* [Command("createacped")]
         public static void CreateACPED(PlayerModel player)
         {
             foreach (PlayerModel players in Alt.GetAllPlayers())
             {
                 Create_Anticheat_Peds(players);
             }
         }*/
    }
}
