using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Tactics.admin
{
    public class Main : IScript
    {
        [Command("skipround")]
        public static void SkipRound(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Tactics.Globals.Functions.SendTacticRoundMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat die Tactic Runde übersprungen!");
                Reallife.vnx_stored_files.logfile.WriteLogs("tactics_admin", player.GetVnXName<string>() + " hat die Runde übersprungen!");
                Tactics.Globals.Functions.ShowOutroScreen("[VnX]" + player.GetVnXName<string>() + " hat die Tactic Runde übersprungen!");
            }
        }
    }
}
