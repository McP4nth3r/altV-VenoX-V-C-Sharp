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
            Lobbys.Alpha.TACTIC_PLAYER_DIMENSION = VenoXV._Globals_.Main.TACTICS_DIMENSION_ALPHA;
            Lobbys.Beta.TACTIC_PLAYER_DIMENSION = VenoXV._Globals_.Main.TACTICS_DIMENSION_BETA;
            Lobbys.Gamma.TACTIC_PLAYER_DIMENSION = VenoXV._Globals_.Main.TACTICS_DIMENSION_GAMMA;
            Lobbys.Delta.TACTIC_PLAYER_DIMENSION = VenoXV._Globals_.Main.TACTICS_DIMENSION_DELTA;
        }

        public static void OnUpdate()
        {
            try
            {
                if (VenoXV._Globals_.Main.TacticsPlayers.Count <= 0) return;
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
