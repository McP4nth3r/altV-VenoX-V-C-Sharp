using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Main : IScript
    {

        public static void OnResourceStart()
        {
        }

        public static void OnUpdate()
        {
            try
            {
                Lobby.Main.OnUpdate();
            }
            catch { }
        }

        public static void OnPlayerDisconnect(Client player, string type, string reason)
        {
            try
            {
                Lobby.Main.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }
    }
}
