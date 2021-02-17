using System;
using System.Linq;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.SevenTowers.globals
{
    public class Chat
    {
        public static void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer players in _Globals_.Main.SevenTowersPlayers.ToList())
                {
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [SevenTowers]" + RageApi.GetHexColorcode(255, 255, 255) + " " + player.Username + " : " + message);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
