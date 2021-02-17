using System;
using System.Linq;
using AltV.Net;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Models;
using VenoXV.Tactics.lobby;

namespace VenoXV._Gamemodes_.Tactics.Globals
{
    public class Main : IScript
    {

        public static void OnResourceStart()
        {
            Pointer.Alpha.TacticPlayerDimension = _Globals_.Main.TacticsDimensionAlpha;
            Pointer.Beta.TacticPlayerDimension = _Globals_.Main.TacticsDimensionBeta;
            Pointer.Gamma.TacticPlayerDimension = _Globals_.Main.TacticsDimensionGamma;
            Pointer.Delta.TacticPlayerDimension = _Globals_.Main.TacticsDimensionDelta;
        }

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.TacticsPlayers.Count <= 0) return;
                foreach (var lobbys in Pointer._TacticLobbyPointers.Values.ToList().Where(lobbys => lobbys.MemberCountMaxBfac > 0 || lobbys.MemberCountMaxCops > 0))
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
