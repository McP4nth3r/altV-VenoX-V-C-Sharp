﻿using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
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
        public Tactics(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
