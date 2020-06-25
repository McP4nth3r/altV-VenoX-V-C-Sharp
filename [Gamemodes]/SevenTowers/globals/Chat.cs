using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.SevenTowers.globals
{
    public class Chat
    {

        public static void OnChatMessage(Client player, string message)
        {
            foreach (Client players in VenoXV.Globals.Main.SevenTowersPlayers)
            {
                players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [SevenTowers]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
            }
        }
    }
}
