using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.SevenTowers.globals
{
    public class Chat
    {
        public static void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer players in VenoXV.Globals.Main.SevenTowersPlayers.ToList())
                {
                    players.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [SevenTowers]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
                }
            }
            catch { }
        }

    }
}
