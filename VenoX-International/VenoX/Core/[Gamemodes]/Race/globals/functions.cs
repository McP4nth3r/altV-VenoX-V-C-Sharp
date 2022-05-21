using System;
using System.Linq;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Race.globals
{
    public class Functions
    {
        public static void SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.RacePlayers))
                {
                    players?.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

    }
}
