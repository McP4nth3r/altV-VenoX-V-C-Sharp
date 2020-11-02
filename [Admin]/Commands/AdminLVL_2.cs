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
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + target.Username + " wurde von " + player.Username + " gekickt! Grund : " + reason);
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + target.SocialClubId + "][" + target.Username + "] gekickt! Grund : " + reason);
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
                    if (targetsingame.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (player.AdminRank == 7)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {B40000}Projektleitung " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Projektleitung " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 6)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {EC0000}Stellv.Projektleitung " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Stellv.Projektleitung " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 5)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {E8AE00}Administrator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 4)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {002DE0}Moderator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 3)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {006600}Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 2)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {C800C8}Ticket-Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.Username + ": " + message + " }} ");
                        }
                    }
                }
            }
            catch { }
        }
    }
}
