using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Call : IScript
    {
        private static void ChangeTargetCallerAvatar(Client player, string ID, string Avatar)
        {
            Alt.Server.TriggerClientEvent(player, "Phone:ChangeCallTargetAvatar", ID, Avatar);
        }

        [ClientEvent("VenoXPhone:CallTarget")]
        public static void OnTargetCallButtonPressed(Client player, string TargetName)
        {
            Client target = Core.RageAPI.GetPlayerFromName(TargetName);
            if (target == null) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Der Spieler ist Offline."); return; }
            if (target.Discord.IsOpen)
            {
                ChangeTargetCallerAvatar(player, target.Discord.ID, target.Discord.Avatar);
            }
            if (target == player) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du kannst dich nicht selbst anrufen!"); }
        }
    }
}
