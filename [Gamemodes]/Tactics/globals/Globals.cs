using AltV.Net;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Main : IScript
    {

        public static void OnResourceStart()
        {
            _Gamemodes_.Tactics.weapons.Combat.OnResourceStart();
        }

        public static void OnUpdate()
        {
            try
            {
                Lobby.Main.OnUpdate();
            }
            catch { }
        }

        public static void OnPlayerDisconnect(PlayerModel player, string type, string reason)
        {
            try
            {
                Tactics.Lobby.Main.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }
    }
}
