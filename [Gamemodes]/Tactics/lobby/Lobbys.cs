using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Tactics.Lobby
{
    public class Lobbys
    {
        private static Round Alpha = new Round();
        private static Round Beta = new Round();
        private static Round Gamma = new Round();
        private static Round Delta = new Round();

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
                if (TacticLobbys.TryGetValue(Lobby, out Round val)) return;
                if (val is not null)
                    val.OnSelectedTacticsGM(player);
                player.Tactics.CurrentLobby = val;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
