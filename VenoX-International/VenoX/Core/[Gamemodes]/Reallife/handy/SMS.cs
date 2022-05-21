using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.handy
{
    public class Sms : IScript
    {
        private static VnXPlayer FindPlayerByName(string name)
        {
            try
            {
                VnXPlayer found = null;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
                {
                    if (players.CharacterUsername == name) { found = players; }
                }
                return found;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return null; }
        }
        [VenoXRemoteEvent("Phone:OnSMSMessageSend")]
        public static void OnSMSMessageSend(VnXPlayer player, string name, string message)
        {
            try
            {
                VnXPlayer receiver = FindPlayerByName(name);
                if (receiver == null) { return; }
                ConsoleHandling.OutputDebugString(player.CharacterUsername + " hat " + receiver.CharacterUsername + " SMS geschickt : " + message);
                if (receiver == player) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du kannst nicht mit dir selbst Chatten..."); return; }
                _RootCore_.VenoX.TriggerClientEvent(receiver, "Phone:AddNewSMS", player.CharacterUsername, player.Phone.Number, message);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

    }
}
