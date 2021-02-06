using AltV.Net;
using System;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV._Globals_;

namespace VenoXV._Gamemodes_.Tactics.weapons
{
    public class Combat : IScript
    {
        public static void OnTacticsDamage(VnXPlayer player, VnXPlayer killer, float Damage)
        {
            try
            {
                Round CurrentLobby = player.Tactics.CurrentLobby;
                if (CurrentLobby is null) return;
                if (Main.TacticsPlayers.Contains(killer)) killer.Tactics.CurrentDamage += (int)Damage;
                CurrentLobby.SyncPlayerStats();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
