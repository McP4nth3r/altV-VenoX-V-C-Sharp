using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;

namespace VenoXV._Gamemodes_.Race.Globals
{
    public class Functions
    {
        public static void SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (IPlayer players in VenoXV.Globals.Main.RacePlayers)
                {
                    players?.SendChatMessage(text);
                }
            }
            catch { }
        }

    }
}
