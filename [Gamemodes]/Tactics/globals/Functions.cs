using System;
using System.Linq;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Functions
    {
        public static void SendTacticRoundMessage(string text, Round tacticRound)
        {
            try
            {
                foreach (VnXPlayer players in _Globals_.Main.TacticsPlayers.ToList())
                {
                    if (players.Tactics.CurrentLobby == tacticRound)
                        players?.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void ShowOutroScreen(string text, Round tacticRound)
        {
            try
            {
                tacticRound.TacticmanagerRoundStartAfterLoading = DateTime.Now.AddSeconds(tacticRound.TacticRoundStartAfterLoading);
                tacticRound.TacticmanagerRoundCurrenttime = DateTime.Now;
                tacticRound.SyncEndTacticRound(text);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
