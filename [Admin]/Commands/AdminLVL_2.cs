using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV.Commands
{
    public class AdminLvl2 : IScript
    {
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////

        [Command("kick")]
        public static void KickPlayer(VnXPlayer player, string targetName, params string[] reasonArray)
        {
            try
            {
                string reason = string.Join(" ", reasonArray);
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                if (player.AdminRank < Constants.AdminlvlTsupporter) return;
                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + target.Username + " got kicked by " + player.Username + "! Reason : " + reason);
                Logfile.WriteLogs("admin", target.Username + " got kicked by " + player.Username + "! Reason : " + reason);
                target.Kick(reason);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("achat", true)]
        public void ACommand(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers().ToList())
                {
                    if (targetsingame.AdminRank < Constants.AdminlvlTsupporter) continue;
                    switch (player.AdminRank)
                    {
                        case Constants.AdminlvlProjektleiter:
                            targetsingame.SendChatMessage("{{ ACHAT {B40000}Project Leader " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Project Leader " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlStellvp:
                            targetsingame.SendChatMessage("{{ ACHAT {EC0000}Rep. Project Leader " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Rep. Project Leader " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlAdministrator:
                            targetsingame.SendChatMessage("{{ ACHAT {E8AE00}Administrator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlModerator:
                            targetsingame.SendChatMessage("{{ ACHAT {002DE0}Moderator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlSupporter:
                            targetsingame.SendChatMessage("{{ ACHAT {006600}Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlTsupporter:
                            targetsingame.SendChatMessage("{{ ACHAT {C800C8}Ticket - Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.Username + ": " + message + " }} ");
                            return;
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
