using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Race.Globals
{
    public class Functions
    {
        public static void SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (PlayerModel players in VenoXV.Globals.Main.RacePlayers)
                {
                    players?.SendChatMessage(text);
                }
            }
            catch { }
        }

    }
}
