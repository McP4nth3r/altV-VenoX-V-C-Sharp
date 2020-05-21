using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {
        public static void InitializePlayerData(Client player)
        {
            player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_STATUS, "VenoX");
            player.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
        }

    }
}
