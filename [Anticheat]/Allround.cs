using AltV.Net;
using VenoXV._RootCore_.Models;
namespace VenoXV.Anti_Cheat
{
    public class AntiCheat_Allround : IScript
    {
        public static void SetTimeOutTeleport(Client player, int value)
        {
            Alt.Server.TriggerClientEvent(player, "FreezeTPTimer", value);
        }

        public static void SetTimeOutHealth(Client player, int value)
        {
            Alt.Server.TriggerClientEvent(player, "FreezeHealthTimer", value);
        }

        public static void StartTimerTeleport(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "StartTPTimer");
        }

        public static void StopTimerTeleport(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "StopTPTimer");
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
