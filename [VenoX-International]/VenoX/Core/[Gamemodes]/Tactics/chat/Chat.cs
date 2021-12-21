using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Tactics.chat
{
    public class Chat : IScript
    {
        public static void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer players in Main.TacticsPlayers.ToList())
                {
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Tactics]" + RageApi.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
