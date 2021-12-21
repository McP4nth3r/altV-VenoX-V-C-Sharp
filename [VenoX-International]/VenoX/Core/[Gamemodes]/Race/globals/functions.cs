using System;
using System.Linq;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Race.Globals
{
    public class Functions
    {
        public static void SendRaceRoundMessage(string text)
        {
            try
            {
                foreach (VnXPlayer players in _Globals_.Main.RacePlayers.ToList())
                {
                    players?.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
