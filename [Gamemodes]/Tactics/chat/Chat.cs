﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.chat
{
    public class Chat : IScript
    {
        public static void OnChatMessage(PlayerModel player, string message)
        {
            foreach (PlayerModel players in Alt.GetAllPlayers())
            {
                if (players.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.Globals.EntityData.GAMEMODE_TACTICS)
                {
                    players.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Tactics]" + RageAPI.GetHexColorcode(255, 255, 255) + " " + player.GetVnXName() + " : " + message);
                }
            }
        }
    }
}
