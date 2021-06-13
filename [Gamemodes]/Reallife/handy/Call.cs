using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.handy.model;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Call : IScript
    {
        private static List<CallModel> _playerCalls = new List<CallModel>();
        private static void ChangeTargetCallerAvatar(VnXPlayer player, string id, string avatar)
        {
            VenoX.TriggerClientEvent(player, "Phone:ChangeCallTargetAvatar", id, avatar);
        }

        [VenoXRemoteEvent("VenoXPhone:CallTarget")]
        public static void OnTargetCallButtonPressed(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            if (target.Phone.IsCallActive) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Spieler ist am Telefonieren!"); return; }
            if (target == player) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du kannst dich nicht selbst anrufen!"); return; }
            if (target.Discord.IsOpen)
            {
                ChangeTargetCallerAvatar(player, target.Discord.Id, target.Discord.Avatar);
            }
            VenoX.TriggerClientEvent(target, "Phone:Shpw", true);
            VenoX.TriggerClientEvent(target, "Phone:ShowIncomingCall", player.Username, player.Phone.Number);
        }

        [VenoXRemoteEvent("VenoXPhone:CallAccepted")]
        public static void OnCallAccepted(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            if (player.Phone.IsCallActive) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du Telefonierst bereits!"); return; }
            CallModel callClass = new CallModel
            {
                Caller = player,
                Target = target,
                CurrentCallChannel = Alt.CreateVoiceChannel(false, 20f)
            };
            callClass.CurrentCallChannel.AddPlayer(player);
            callClass.CurrentCallChannel.AddPlayer(target);
            player.Phone.IsCallActive = true;
            target.Phone.IsCallActive = false;
            _playerCalls.Add(callClass);
        }

        [VenoXRemoteEvent("VenoXPhone:CallDenied")]
        public static void OnCallDenied(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            target.SendChatMessage(player.Username + " hat aufgelegt!");
            player.SendChatMessage("Du hast aufgelegt!");
        }

        [VenoXRemoteEvent("VenoXPhone:CallHangup")]
        public static void OnCallHangup(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            VenoX.TriggerClientEvent(target, "Phone:HangupCall");
            foreach (CallModel callClass in _playerCalls.ToList())
            {
                if (callClass.Caller == player)
                {
                    callClass.CurrentCallChannel.RemovePlayer(player);
                    if (target != null) { callClass.CurrentCallChannel.RemovePlayer(target); }
                    Alt.RemoveVoiceChannel(callClass.CurrentCallChannel);
                    _playerCalls.Remove(callClass);
                }
            }
        }
    }
}
