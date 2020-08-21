using AltV.Net;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Globals;

namespace VenoXV._Gamemodes_.Tactics.weapons
{
    public class Combat : IScript
    {

        public static void OnTacticsDamage(VnXPlayer player, VnXPlayer killer, float Damage)
        {
            try { if (Main.TacticsPlayers.Contains(player)) { player.Tactics.CurrentDamage += (int)Damage; } Lobby.Main.SyncPlayerStats(); }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnTacticsDamage", ex); }
        }
    }
}
