using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Globals_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Sms : IScript
    {
        private static VnXPlayer FindPlayerByName(string name)
        {
            try
            {
                VnXPlayer found = null;
                foreach (VnXPlayer players in Main.ReallifePlayers.ToList())
                {
                    if (players.Username == name) { found = players; }
                }
                return found;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
        [VenoXRemoteEvent("Phone:OnSMSMessageSend")]
        public static void OnSMSMessageSend(VnXPlayer player, string name, string message)
        {
            try
            {
                VnXPlayer receiver = FindPlayerByName(name);
                if (receiver == null) { return; }
                Debug.OutputDebugString(player.Username + " hat " + receiver.Username + " SMS geschickt : " + message);
                if (receiver == player) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du kannst nicht mit dir selbst Chatten..."); return; }
                VenoX.TriggerClientEvent(receiver, "Phone:AddNewSMS", player.Username, player.Phone.Number, message);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
