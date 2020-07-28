﻿using System;
using System.Linq;
using System.Threading.Tasks;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Functions
    {
        public static async Task SendTacticRoundMessage(string text)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers.ToList())
                {
                    await players?.SendTranslatedChatMessage(text);
                }
            }
            catch { }
        }

        public static void ShowOutroScreen(string text)
        {
            try
            {
                Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
                Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                Lobby.Main.SyncEndTacticRound(text);
            }
            catch { }
        }
    }
}
