using System;
using AltV.Net;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._Globals_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Tactics.weapons
{
    public class Combat : IScript
    {
        public static void OnTacticsDamage(VnXPlayer player, VnXPlayer killer, float damage)
        {
            try
            {
                Round currentLobby = player.Tactics.CurrentLobby;
                if (currentLobby is null) return;
                if (Main.TacticsPlayers.Contains(killer)) killer.Tactics.CurrentDamage += (int)damage;
                currentLobby.SyncPlayerStats();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
