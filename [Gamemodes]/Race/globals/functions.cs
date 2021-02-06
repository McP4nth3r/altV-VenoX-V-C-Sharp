using System.Linq;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Race.Globals
{
    public class Functions
    {
        public static void SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (VnXPlayer players in VenoXV._Globals_.Main.RacePlayers.ToList())
                {
                    players?.SendTranslatedChatMessage(text);
                }
            }
            catch { }
        }

    }
}
