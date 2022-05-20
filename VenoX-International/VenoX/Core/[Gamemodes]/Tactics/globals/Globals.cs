using System;
using System.Linq;
using AltV.Net;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Tactics.globals
{
    public class Main : IScript
    {

        public static void OnResourceStart()
        {
            Pointer.Alpha.TacticPlayerDimension = _Globals_.Initialize.TacticsDimensionAlpha;
            Pointer.Beta.TacticPlayerDimension = _Globals_.Initialize.TacticsDimensionBeta;
            Pointer.Gamma.TacticPlayerDimension = _Globals_.Initialize.TacticsDimensionGamma;
            Pointer.Delta.TacticPlayerDimension = _Globals_.Initialize.TacticsDimensionDelta;
        }

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Initialize.TacticsPlayers.Count <= 0) return;
                foreach (Round lobbys in Pointer._TacticLobbyPointers.Values.ToList().Where(lobbys => lobbys.MemberCountMaxBfac > 0 || lobbys.MemberCountMaxCops > 0))
                    lobbys.OnUpdate();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason)
        {
            try
            {
                player.Tactics.CurrentLobby?.OnPlayerDisconnect(player, type, reason);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
