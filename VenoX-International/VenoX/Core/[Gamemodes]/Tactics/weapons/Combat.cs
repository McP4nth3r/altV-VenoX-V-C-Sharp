using System;
using AltV.Net;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Tactics.weapons
{
    public class Combat : IScript
    {
        public static void OnTacticsDamage(VnXPlayer player, VnXPlayer killer, float damage)
        {
            try
            {
                Round currentLobby = player.Tactics.CurrentLobby;
                if (currentLobby is null) return;
                if (Initialize.TacticsPlayers.Contains(killer)) killer.Tactics.CurrentDamage += (int)damage;
                currentLobby.SyncPlayerStats();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
