using System;
using AltV.Net.Elements.Entities;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
{
    public class Tactics
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public bool Joined { get; set; }
        public bool IsDead { get; set; }
        public bool Spawned { get; set; }
        public int CurrentDamage { get; set; }
        public int CurrentKills { get; set; }
        public int CurrentStreak { get; set; }
        public string Team { get; set; }
        public Round CurrentLobby { get; set; }
        public Tactics(Player player)
        {
            try
            {
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
