using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.admin
{
    public class Main : IScript
    {
        [Command("skipround")]
        public static void SkipRound(Client player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
                {
                    Tactics.Globals.Functions.SendTacticRoundMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat die Tactic Runde übersprungen!");
                    _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("tactics_admin", player.Username + " hat die Runde übersprungen!");
                    Tactics.Globals.Functions.ShowOutroScreen("[VnX]" + player.Username + " hat die Tactic Runde übersprungen!");
                }
            }
            catch { }
        }
    }
}
