using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class SMS : IScript
    {
        private static VnXPlayer FindPlayerByName(string Name)
        {
            try
            {
                VnXPlayer Found = null;
                foreach (VnXPlayer players in VenoXV._Globals_.Main.ReallifePlayers.ToList())
                {
                    if (players.Username == Name) { Found = players; }
                }
                return Found;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
        [ClientEvent("Phone:OnSMSMessageSend")]
        public static void OnSMSMessageSend(VnXPlayer player, string Name, string Message)
        {
            try
            {
                VnXPlayer Receiver = FindPlayerByName(Name);
                if (Receiver == null) { return; }
                Core.Debug.OutputDebugString(player.Username + " hat " + Receiver.Username + " SMS geschickt : " + Message);
                if (Receiver == player) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du kannst nicht mit dir selbst Chatten..."); return; }
                VenoX.TriggerClientEvent(Receiver, "Phone:AddNewSMS", player.Username, player.Phone.Number, Message);
            }
            catch { }
        }

    }
}
