using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.handy.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Call : IScript
    {
        private static List<CallModel> PlayerCalls = new List<CallModel>();
        private static void ChangeTargetCallerAvatar(VnXPlayer player, string ID, string Avatar)
        {
            Alt.Server.TriggerClientEvent(player, "Phone:ChangeCallTargetAvatar", ID, Avatar);
        }

        [ClientEvent("VenoXPhone:CallTarget")]
        public static void OnTargetCallButtonPressed(VnXPlayer player, string TargetName)
        {
            VnXPlayer target = Core.RageAPI.GetPlayerFromName(TargetName);
            if (target == null) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            if (target.Phone.IsCallActive) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist am Telefonieren!"); return; }
            if (target == player) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du kannst dich nicht selbst anrufen!"); return; }
            if (target.Discord.IsOpen)
            {
                ChangeTargetCallerAvatar(player, target.Discord.ID, target.Discord.Avatar);
            }
            target.Emit("Phone:Shpw", true);
            target.Emit("Phone:ShowIncomingCall", player.Username, player.Phone.Number);
        }

        [ClientEvent("VenoXPhone:CallAccepted")]
        public static void OnCallAccepted(VnXPlayer player, string TargetName)
        {
            VnXPlayer target = Core.RageAPI.GetPlayerFromName(TargetName);
            if (target == null) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            if (player.Phone.IsCallActive) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du Telefonierst bereits!"); return; }
            CallModel callClass = new CallModel()
            {
                Caller = player,
                Target = target,
                CurrentCallChannel = Alt.CreateVoiceChannel(false, 20f)
            };
            callClass.CurrentCallChannel.AddPlayer(player);
            callClass.CurrentCallChannel.AddPlayer(target);
            player.Phone.IsCallActive = true;
            target.Phone.IsCallActive = false;
            PlayerCalls.Add(callClass);
        }

        [ClientEvent("VenoXPhone:CallDenied")]
        public static void OnCallDenied(VnXPlayer player, string TargetName)
        {
            VnXPlayer target = Core.RageAPI.GetPlayerFromName(TargetName);
            if (target == null) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            target.SendChatMessage(player.Username + " hat aufgelegt!");
            player.SendChatMessage("Du hast aufgelegt!");
        }

        [ClientEvent("VenoXPhone:CallHangup")]
        public static void OnCallHangup(VnXPlayer player, string TargetName)
        {
            VnXPlayer target = Core.RageAPI.GetPlayerFromName(TargetName);
            if (target == null) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            target.Emit("Phone:HangupCall");
            foreach (CallModel callClass in PlayerCalls.ToList())
            {
                if (callClass.Caller == player)
                {
                    callClass.CurrentCallChannel.RemovePlayer(player);
                    if (target != null) { callClass.CurrentCallChannel.RemovePlayer(target); }
                    Alt.RemoveVoiceChannel(callClass.CurrentCallChannel);
                    PlayerCalls.Remove(callClass);
                }
            }
        }
    }
}
