using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV.Tactics.lobby
{
    public class Pointer
    {
        public static readonly Round Alpha = new Round();
        public static readonly Round Beta = new Round();
        public static readonly Round Gamma = new Round();
        public static readonly Round Delta = new Round();

        public static readonly Dictionary<int, Round> _TacticLobbyPointers = new Dictionary<int, Round>
        {
            { 0, Alpha },
            { 1, Beta },
            { 2, Gamma },
            { 3, Delta },
        };

        public static void OnSelectedTacticLobby(VnXPlayer player, int lobby)
        {
            try
            {
                _TacticLobbyPointers.TryGetValue(lobby, out Round val);
                if (val is null) return;
                val.OnSelectedTacticsGM(player);
                player.Tactics.CurrentLobby = val;
                // Debug : 
                Debug.OutputDebugString("Alpha Map-Name : " + Alpha.CurrentMap.MapName);
                Debug.OutputDebugString("Beta Map-Name : " + Beta.CurrentMap.MapName);
                Debug.OutputDebugString("Gamma Map-Name : " + Gamma.CurrentMap.MapName);
                Debug.OutputDebugString("Delta Map-Name : " + Delta.CurrentMap.MapName);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
