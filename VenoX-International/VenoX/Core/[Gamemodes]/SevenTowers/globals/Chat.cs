using System;
using System.Linq;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.SevenTowers.globals
{
    public class Chat
    {
        public static void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.SevenTowersPlayers))
                {
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [SevenTowers]" + RageApi.GetHexColorcode(255, 255, 255) + " " + player.CharacterUsername + " : " + message);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

    }
}
