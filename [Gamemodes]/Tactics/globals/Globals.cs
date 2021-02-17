using System.Linq;
using AltV.Net;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Main : IScript
    {

        public static void OnResourceStart()
        {
            Lobbys.Alpha.TacticPlayerDimension = _Globals_.Main.TacticsDimensionAlpha;
            Lobbys.Beta.TacticPlayerDimension = _Globals_.Main.TacticsDimensionBeta;
            Lobbys.Gamma.TacticPlayerDimension = _Globals_.Main.TacticsDimensionGamma;
            Lobbys.Delta.TacticPlayerDimension = _Globals_.Main.TacticsDimensionDelta;
        }

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.TacticsPlayers.Count <= 0) return;
                foreach (Round lobbys in Lobbys.TacticLobbys.Values.ToList())
                    if (lobbys.MemberCountMaxBfac > 0 || lobbys.MemberCountMaxCops > 0)
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
