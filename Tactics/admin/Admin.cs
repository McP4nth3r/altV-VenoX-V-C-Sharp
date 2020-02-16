using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Tactics.admin
{
    public class Main : IScript
    {
        [Command("skipround")]
        public static void SkipRound(IPlayer player)
        {
            if(player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Tactics.globals.Functions.SendTacticRoundMessage(Constants.Rgba_ADMIN_CLANTAG +player.GetVnXName<string>() + " hat die Tactic Runde übersprungen!");
                Reallife.vnx_stored_files.logfile.WriteLogs("tactics_admin",player.GetVnXName<string>() + " hat die Runde übersprungen!");
                Tactics.globals.Functions.ShowOutroScreen("[VnX]" +player.GetVnXName<string>() + " hat die Tactic Runde übersprungen!");
            }
        }
    }
}
