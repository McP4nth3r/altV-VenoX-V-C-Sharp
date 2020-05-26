using AltV.Net;
using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Globals
{
    public class Events : IScript
    {
        public static List<int> KilledZombieIds = new List<int>();
        [ClientEvent("Zombies:OnZombieDeath")]
        public static void OnZombieDeath(Client player, int Id)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.ZombiePlayers)
                {
                    Alt.Server.TriggerClientEvent(players, "Zombies:SetHealth", Id, 0);
                }
                if (!KilledZombieIds.Contains(Id)) KilledZombieIds.Add(Id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Zombies:OnZombieDeath", ex); }
        }
    }
}
