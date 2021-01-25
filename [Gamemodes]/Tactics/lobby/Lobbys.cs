using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.Lobby
{
    public class Lobbys
    {
        public static Round Alpha = new Round();
        public static Round Beta = new Round();
        public static Round Gamma = new Round();
        public static Round Delta = new Round();

        public static Dictionary<int, Round> TacticLobbys = new Dictionary<int, Round>
        {
            { 0, Alpha },
            { 1, Beta },
            { 2, Gamma },
            { 3, Delta },
        };

        public static void OnSelectedTacticLobby(VnXPlayer player, int Lobby)
        {
            try
            {
                TacticLobbys.TryGetValue(Lobby, out Round val);
                if (val is null) return;
                val.OnSelectedTacticsGM(player);
                player.Tactics.CurrentLobby = val;
                // Debug : 
                Core.Debug.OutputDebugString("Alpha Map-Name : " + Alpha.CurrentMap.Map_Name);
                Core.Debug.OutputDebugString("Beta Map-Name : " + Beta.CurrentMap.Map_Name);
                Core.Debug.OutputDebugString("Gamma Map-Name : " + Gamma.CurrentMap.Map_Name);
                Core.Debug.OutputDebugString("Delta Map-Name : " + Delta.CurrentMap.Map_Name);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
