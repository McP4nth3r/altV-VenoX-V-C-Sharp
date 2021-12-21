using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using VenoXV.Core;
using VenoXV.Zombie.Models;

namespace VenoXV.Models.SubClasses.PlayerModel
{
    public class Zombies
    {
        private Player _client;
        private int _ZombieKills { get; set; }
        public int ZombieKills { get => _ZombieKills;
            set { _ZombieKills = value; _client.VnxSetSharedElementData("ZOMBIE_KILLS", value); } }
        public int ZombiePlayerKills { get; set; }
        public int ZombieDeaths { get; set; }
        public bool IsSyncer { get; set; }
        public List<ZombieModel> NearbyZombies { get; }
        public Zombies(Player player)
        {
            try
            {
                _client = player;
                NearbyZombies = new List<ZombieModel>();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
