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
                foreach (Client players in VenoXV.Globals.Main.RacePlayers)
                {
                    players?.SendTranslatedChatMessage(text);
                }
            }
            catch { }
        }

    }
}
