using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV.SevenTowers.globals
{
    public class Main : IScript
    {
        public static void OnPlayerDisconnect(Client player)
        {
            try
            {
                Globals.Main.SevenTowersPlayers.Remove(player);
            }
            catch { }
        }
    }
}
