using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Functions
    {
        public static void SendTacticRoundMessage(string text)
        {
            try
            {
                foreach (PlayerModel players in VenoXV.Globals.Main.TacticsPlayers)
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

        public static void InitializePlayerData(PlayerModel player)
        {
            try
            {
                //Tactic 
                player.vnxSetElementData(Tactics.Globals.EntityData.PLAYER_TACTIC_KILLS, 0);
                player.vnxSetElementData(Tactics.Globals.EntityData.PLAYER_TACTIC_TODE, 0);
            }
            catch { }
        }
    }
}
