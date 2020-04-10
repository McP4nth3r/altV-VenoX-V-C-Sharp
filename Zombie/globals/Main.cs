using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Zombie.globals
{
    public class Main : IScript
    {

        public static void OnUpdate()
        {
            World.Main.OnUpdate();
        }

        //[AltV.Net.ClientEvent("OnZombieKill")]
        public static void OnZombieKill(IPlayer player)
        {
            try
            {
                player.vnxSetElementData<object>(Reallife.Globals.EntityData.PLAYER_ZOMBIE_KILLS, player.vnxGetElementData<int>(Reallife.Globals.EntityData.PLAYER_ZOMBIE_KILLS) + 1);
                Console.WriteLine(player.GetVnXName<string>() + " hat einen Zombie Getötet!");
            }
            catch { }
        }
    }
}
