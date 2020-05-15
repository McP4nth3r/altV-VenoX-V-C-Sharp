using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.admin
{
    public class Main : IScript
    {
        [Command("skipround")]
        public static void SkipRound(Client player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Tactics.Globals.Functions.SendTacticRoundMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName() + " hat die Tactic Runde übersprungen!");
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("tactics_admin", player.GetVnXName() + " hat die Runde übersprungen!");
                Tactics.Globals.Functions.ShowOutroScreen("[VnX]" + player.GetVnXName() + " hat die Tactic Runde übersprungen!");
            }
        }
    }
}
