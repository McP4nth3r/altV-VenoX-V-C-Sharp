using System;
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
                foreach (var lobbys in Lobbys.TacticLobbys.Values.ToList().Where(lobbys => lobbys.MemberCountMaxBfac > 0 || lobbys.MemberCountMaxCops > 0))
                    lobbys.OnUpdate();
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason)
        {
            try
            {
                player.Tactics.CurrentLobby?.OnPlayerDisconnect(player, type, reason);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
