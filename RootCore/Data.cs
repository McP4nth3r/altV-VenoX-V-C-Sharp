using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV.Reallife.Globals;

namespace VenoXV.Core
{

    public class VnX : IScript
    {
        public static object Usefull { get; internal set; }
        public static string PLAYER_MONEY = EntityData.PLAYER_MONEY;
        public static string PLAYER_BANKMONEY = EntityData.PLAYER_BANK;


        public static void UpdateHUDArmorHealth(IPlayer player)
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
        public static void SetDelayedData(IPlayer player, string[] args)
        {
            try
            {
                player.Emit("delay_element_data", args[0], args[1], args[2], args[3]);
            }
            catch { }
        }
        public static void SetDelayedBoolSharedData(IPlayer player, string element, bool value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "bool", TimeInMS);
            }
            catch { }
        }
        public static void SetDelayedINTSharedData(IPlayer player, string element, int value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "int", TimeInMS);
            }
            catch { }
        }
    }
}
