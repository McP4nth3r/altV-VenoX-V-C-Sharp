using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Zombie.Models;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Zombies
    {
        private Player client;
        private int _Zombie_kills { get; set; }
        public int Zombie_kills { get { return _Zombie_kills; } set { _Zombie_kills = value; client.vnxSetSharedElementData("ZOMBIE_KILLS", value); } }
        public int Zombie_player_kills { get; set; }
        public int Zombie_tode { get; set; }
        public bool IsSyncer { get; set; }
        public List<ZombieModel> NearbyZombies { get; set; }
        public Zombies(Player player)
        {
            try
            {
                client = player;
                NearbyZombies = new List<ZombieModel>();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
