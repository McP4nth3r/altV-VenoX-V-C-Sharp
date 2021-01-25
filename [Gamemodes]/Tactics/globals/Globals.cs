using AltV.Net;
using System.Linq;
using VenoXV._Gamemodes_.Tactics.Lobby;
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
                if (VenoXV.Globals.Main.TacticsPlayers.Count <= 0) return;
                foreach (Round lobbys in Tactics.Lobby.Lobbys.TacticLobbys.Values.ToList())
                    if (lobbys.MEMBER_COUNT_MAX_BFAC > 0 || lobbys.MEMBER_COUNT_MAX_COPS > 0)
                        lobbys.OnUpdate();
            }
            catch { }
        }

        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason)
        {
            try
            {
                if (player.Tactics.CurrentLobby is not null)
                    player.Tactics.CurrentLobby.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }
    }
}
