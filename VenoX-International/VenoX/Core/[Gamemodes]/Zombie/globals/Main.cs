using System;
using AltV.Net;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Zombie.globals
{
    public class Main : IScript
    {

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Initialize.ZombiePlayers.Count <= 0) return;
                World.Main.OnUpdate();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("OnZombieKill")]
        public static void OnZombieKill(VnXPlayer player)
        {
            try
            {
                player.Zombies.ZombieKills += 1;
                Console.WriteLine(player.CharacterUsername + " hat einen Zombie Getötet!");
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
