using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.chat
{
    public class Chat : IScript
    {
        public static void OnChatMessage(Client player, string message)
        {
            foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
            {
                players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Tactics]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
            }
        }
    }
}
