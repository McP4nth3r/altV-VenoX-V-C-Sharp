using System.Linq;
using System.Threading.Tasks;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Race.Globals
{
    public class Functions
    {
        public static async Task SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.RacePlayers.ToList())
                {
                    await players?.SendTranslatedChatMessage(text);
                }
            }
            catch { }
        }

    }
}
