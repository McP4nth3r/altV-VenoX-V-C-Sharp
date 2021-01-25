using System;
using System.Linq;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Functions
    {
        public static void SendTacticRoundMessage(string text, Round TacticRound)
        {
            try
            {
                foreach (VnXPlayer players in VenoXV.Globals.Main.TacticsPlayers.ToList())
                {
                    if (players.Tactics.CurrentLobby == TacticRound)
                        players?.SendTranslatedChatMessage(text);
                }
            }
            catch { }
        }

        public static void ShowOutroScreen(string text, Round TacticRound)
        {
            try
            {
                TacticRound.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(TacticRound.TACTIC_ROUND_START_AFTER_LOADING);
                TacticRound.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                TacticRound.SyncEndTacticRound(text);
            }
            catch { }
        }
    }
}
