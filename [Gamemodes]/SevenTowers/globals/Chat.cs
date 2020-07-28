using System.Linq;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.SevenTowers.globals
{
    public class Chat
    {
        public static void OnChatMessage(Client player, string message)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.SevenTowersPlayers.ToList())
                {
                    players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [SevenTowers]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
                }
            }
            catch { }
        }

    }
}
