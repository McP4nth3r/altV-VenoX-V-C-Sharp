﻿using AltV.Net;
using System;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Main : IScript
    {

        public static void OnUpdate()
        {
            try
            {
                if (VenoXV._Globals_.Main.ZombiePlayers.Count <= 0) return;
                World.Main.OnUpdate();
            }
            catch { }
        }

        [VenoXRemoteEvent("OnZombieKill")]
        public static void OnZombieKill(VnXPlayer player)
        {
            try
            {
                player.Zombies.Zombie_kills += 1;
                Console.WriteLine(player.Username + " hat einen Zombie Getötet!");
            }
            catch { }
        }
    }
}
