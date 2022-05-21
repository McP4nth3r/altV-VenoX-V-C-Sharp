using System;
using System.Linq;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Tactics.globals
{
    public class Functions
    {
        public static void SendTacticRoundMessage(string text, Round tacticRound)
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.TacticsPlayers))
                {
                    if (players.Tactics.CurrentLobby == tacticRound)
                        players?.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void ShowOutroScreen(string text, Round tacticRound)
        {
            try
            {
                tacticRound.TacticmanagerRoundStartAfterLoading = DateTime.Now.AddSeconds(tacticRound.TacticRoundStartAfterLoading);
                tacticRound.TacticmanagerRoundCurrenttime = DateTime.Now;
                tacticRound.SyncEndTacticRound(text);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
