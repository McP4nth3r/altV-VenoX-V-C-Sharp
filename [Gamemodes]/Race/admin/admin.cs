using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV._Gamemodes_.Race.admin
{
    public class Admin : IScript
    {

        [Command("skipcurrentrace")]
        public static void SkipRound(IPlayer player)
        {
            Core.Debug.OutputDebugString("Called with : " + player.GetVnXName<string>());
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Race.Globals.Functions.SendRaceRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + player.Name + " hat das Rennen übersprungen!");
                Race.Lobby.Main.StartNewRound();
            }
        }
    }
}
