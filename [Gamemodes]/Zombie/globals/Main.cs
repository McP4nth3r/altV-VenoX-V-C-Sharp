using AltV.Net;
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
                if (VenoXV.Globals.Main.ZombiePlayers.Count <= 0) { return; }
                World.Main.OnUpdate();
            }
            catch { }
        }

        [ClientEvent("OnZombieKill")]
        public static void OnZombieKill(Client player)
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
