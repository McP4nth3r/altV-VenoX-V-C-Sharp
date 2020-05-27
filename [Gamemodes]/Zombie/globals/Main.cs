using AltV.Net;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Main : IScript
    {

        public static void OnUpdate()
        {
            World.Main.OnUpdate();
        }

        [ClientEvent("OnZombieKill")]
        public static void OnZombieKill(Client player)
        {
            try
            {
                player.vnxSetElementData(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_KILLS, player.vnxGetElementData<int>(_Gamemodes_.Zombie.Globals.EntityData.PLAYER_ZOMBIE_KILLS) + 1);
                Console.WriteLine(player.Username + " hat einen Zombie Getötet!");
            }
            catch { }
        }
    }
}
