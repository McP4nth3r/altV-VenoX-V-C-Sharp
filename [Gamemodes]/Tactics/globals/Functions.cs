using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;

namespace VenoXV.Tactics.Globals
{
    public class Functions
    {
        public static void SendTacticRoundMessage(string text)
        {
            try
            {
                foreach (IPlayer players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    players?.SendChatMessage(text);
                }
            }
            catch { }
        }

        public static void ShowOutroScreen(string text)
        {
            Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
            Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
            Lobby.Main.SyncEndTacticRound(text);
        }
    }
}
