using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class SMS : IScript
    {
        private static Client FindPlayerByName(string Name)
        {
            try
            {
                Client Found = null;
                foreach (Client players in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (players.Username == Name) { Found = players; }
                }
                return Found;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("FindPlayerByName", ex); return null; }
        }
        [ClientEvent("Phone:OnSMSMessageSend")]
        public static void OnSMSMessageSend(Client player, string Name, string Message)
        {
            try
            {
                Client Receiver = FindPlayerByName(Name);
                if (Receiver == null) { return; }
                Core.Debug.OutputDebugString(player.Username + " hat " + Receiver.Username + " SMS geschickt : " + Message);
                if (Receiver == player) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du kannst nicht mit dir selbst Chatten..."); return; }
                Alt.Server.TriggerClientEvent(Receiver, "Phone:AddNewSMS", player.Username, player.Phone.Number, Message);
            }
            catch { }
        }

    }
}
