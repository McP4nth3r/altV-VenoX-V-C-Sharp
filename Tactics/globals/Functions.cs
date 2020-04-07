﻿using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV.Core;

namespace VenoXV.Tactics.Globals
{
    public class Functions : IScript
    {
        public static void SendTacticRoundMessage(string text)
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.Globals.EntityData.GAMEMODE_TACTICS)
                    {
                        players.SendChatMessage(text);
                    }
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
