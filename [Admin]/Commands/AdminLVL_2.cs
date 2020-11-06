using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.admin
{
    public class AdminLVL_2 : IScript
    {
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////

        [Command("kick")]
        public static void KickPlayer(VnXPlayer player, string target_name, params string[] grundArray)
        {
            try
            {
                string reason = string.Join(" ", grundArray);
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) return;
                if (player.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                {
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + target.Username + " got kicked by " + player.Username + "! Reason : " + reason);
                    logfile.WriteLogs("admin", target.Username + " got kicked by " + player.Username + "! Reason : " + reason);
                    target.Kick(reason);
                }
            }
            catch { }
        }

        [Command("achat", true)]
        public void ACommand(VnXPlayer player, string message)
        {
            try
            {
                foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers().ToList())
                {
                    if (targetsingame.AdminRank < Constants.ADMINLVL_TSUPPORTER) continue;
                    switch (player.AdminRank)
                    {
                        case Constants.ADMINLVL_PROJEKTLEITER:
                            targetsingame.SendChatMessage("{{ ACHAT {B40000}Project Leader " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Project Leader " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.ADMINLVL_STELLVP:
                            targetsingame.SendChatMessage("{{ ACHAT {EC0000}Rep. Project Leader " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Rep. Project Leader " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.ADMINLVL_ADMINISTRATOR:
                            targetsingame.SendChatMessage("{{ ACHAT {E8AE00}Administrator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.ADMINLVL_MODERATOR:
                            targetsingame.SendChatMessage("{{ ACHAT {002DE0}Moderator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.ADMINLVL_SUPPORTER:
                            targetsingame.SendChatMessage("{{ ACHAT {006600}Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.Username + ": " + message + " }} ");
                            return;
                        case Constants.ADMINLVL_TSUPPORTER:
                            targetsingame.SendChatMessage("{{ ACHAT {C800C8}Ticket - Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.Username + ": " + message + " }} ");
                            return;
                    }
                }
            }
            catch { }
        }
    }
}
