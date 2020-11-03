using AltV.Net;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV.Core
{

    public class VnX : IScript
    {
        public static object Usefull { get; internal set; }
        public static string PLAYER_MONEY = Globals.EntityData.PLAYER_MONEY;
        public static string PLAYER_BANKMONEY = Globals.EntityData.PLAYER_BANK;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Der Spieler wird Definiert.</param>
        /// <param name="args">[0] = Element Name, [1] = value für die Element Data, [2] Type der Value, [3] = TimeInMS (TimeOut-JS-CS)</param>
        public static void SetDelayedData(VnXPlayer player, object[] args)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "delay_element_data", args[0], args[1], args[2], args[3]);
            }
            catch { }
        }
    }
}
