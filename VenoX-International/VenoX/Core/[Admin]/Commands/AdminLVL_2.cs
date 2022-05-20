using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;

namespace VenoX.Core._Admin_.Commands
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
                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + target.CharacterUsername + " got kicked by " + player.CharacterUsername + "! Reason : " + reason);
                Logfile.WriteLogs("admin", target.CharacterUsername + " got kicked by " + player.CharacterUsername + "! Reason : " + reason);
                target.Kick(reason);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("achat", true)]
        public void ACommand(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer targetsingame in _RootCore_.VenoX.GetAllPlayers().ToList())
                {
                    if (targetsingame.AdminRank < Constants.AdminlvlTsupporter) continue;
                    switch (player.AdminRank)
                    {
                        case Constants.AdminlvlProjektleiter:
                            targetsingame.SendChatMessage("{{ ACHAT {B40000}Project Leader " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Project Leader " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlStellvp:
                            targetsingame.SendChatMessage("{{ ACHAT {EC0000}Rep. Project Leader " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Rep. Project Leader " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlAdministrator:
                            targetsingame.SendChatMessage("{{ ACHAT {E8AE00}Administrator " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlModerator:
                            targetsingame.SendChatMessage("{{ ACHAT {002DE0}Moderator " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlSupporter:
                            targetsingame.SendChatMessage("{{ ACHAT {006600}Supporter " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                        case Constants.AdminlvlTsupporter:
                            targetsingame.SendChatMessage("{{ ACHAT {C800C8}Ticket - Supporter " + player.CharacterUsername + ": {FFFFFF}" + message + " }} ");
                            Logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.CharacterUsername + ": " + message + " }} ");
                            return;
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
