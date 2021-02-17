using System;
using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Main : IScript
    {

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.ZombiePlayers.Count <= 0) return;
                World.Main.OnUpdate();
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("OnZombieKill")]
        public static void OnZombieKill(VnXPlayer player)
        {
            try
            {
                player.Zombies.ZombieKills += 1;
                Console.WriteLine(player.Username + " hat einen Zombie Getötet!");
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
