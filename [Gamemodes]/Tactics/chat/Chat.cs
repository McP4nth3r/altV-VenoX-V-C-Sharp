using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.chat
{
    public class Chat : IScript
    {
        public static void OnChatMessage(Client player, string message)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers.ToList())
                {
                    players.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Tactics]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
                }
            }
            catch { }
        }
    }
}
