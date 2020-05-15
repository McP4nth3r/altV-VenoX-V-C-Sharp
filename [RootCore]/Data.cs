using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV.Core
{

    public class VnX : IScript
    {
        public static object Usefull { get; internal set; }
        public static string PLAYER_MONEY = VenoXV.Globals.EntityData.PLAYER_MONEY;
        public static string PLAYER_BANKMONEY = VenoXV.Globals.EntityData.PLAYER_BANK;


        public static void UpdateHUDArmorHealth(Client player)
        {
            try
            {
                player.Emit("UpdateHealth", player.Armor, player.Health);
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Der Spieler wird Definiert.</param>
        /// <param name="args">[0] = Element Name, [1] = value für die Element Data, [2] Type der Value, [3] = TimeInMS (TimeOut-JS-CS)</param>
        public static void SetDelayedData(Client player, string[] args)
        {
            try
            {
                player.Emit("delay_element_data", args[0], args[1], args[2], args[3]);
            }
            catch { }
        }
        public static void SetDelayedBoolSharedData(Client player, string element, bool value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "bool", TimeInMS);
            }
            catch { }
        }
        public static void SetDelayedINTSharedData(Client player, string element, int value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "int", TimeInMS);
            }
            catch { }
        }
    }
}
