using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;

namespace VenoXV.Globals
{
    public class Globals : IScript
    {
            
        

        //[ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            try
            {
                Reallife.Globals.Main.OnResourceStart();
                Tactics.globals.Globals.OnResourceStart();
            }
            catch { }
        }

        //[ServerEvent(Event.PlayerEnterIColShape)]
        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                Reallife.Globals.Main.OnPlayerEnterIColShape(shape, player);
            }
            catch { }
        }
               
        //[ServerEvent(Event.PlayerExitIColShape)]
        public static void OnPlayerExitIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                Reallife.Globals.Main.OnPlayerExitIColShape(shape, player);
            }
            catch { }
        }

        //[ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(IPlayer player, IPlayer killer, uint reason)
        {
            if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
            {
                if (killer == null || Functions.IstargetInSameLobby(player, killer))
                {
                    VenoXV.Tactics.environment.Death.OnPlayerDeath(player, killer);
                }
                return;
            }
            else if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_REALLIFE)
            {
                if (killer == null || Functions.IstargetInSameLobby(player, killer))
                {
                    VenoXV.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                }
            }
        }

        //[ServerEvent(Event.Update)]
        public static void OnUpdate()
        {
            try
            {
                Reallife.Globals.Main.OnUpdate();
                Tactics.globals.Globals.OnUpdate();
                Zombie.globals.Main.OnUpdate();
            }
            catch
            {

            }
        }

        //[ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(IPlayer player, string type, string reason)
        {
            try
            {
                Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                Tactics.globals.Globals.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }

    }
}
