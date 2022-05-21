using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Tactics.chat
{
    public class Chat : IScript
    {
        public static void OnChatMessage(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Tactics]" + RageApi.GetHexColorcode(255, 255, 255) + " " + player.CharacterUsername + " : " + message);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
