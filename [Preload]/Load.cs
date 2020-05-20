using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {
        public static void InitializePlayerData(Client player)
        {
            player.vnxSetStreamSharedElementData("settings_atm", "ja");
            player.vnxSetStreamSharedElementData("settings_haus", "ja");
            player.vnxSetStreamSharedElementData("settings_tacho", "ja");
            player.vnxSetStreamSharedElementData("settings_quest", "ja");
            player.vnxSetStreamSharedElementData("settings_reporter", "ja");
            player.vnxSetStreamSharedElementData("settings_globalchat", "ja");
            player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_STATUS, "VenoX");
            player.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
        }

    }
}
