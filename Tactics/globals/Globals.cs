using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Tactics.globals
{
    public class Globals : IScript
    {

        public static void OnResourceStart()
        {
            VenoXV.Tactics.weapons.Combat.OnResourceStart();
        }

        public static void OnUpdate()
        {
            try
            {
                Lobby.Main.OnUpdate();
            }
            catch { }
        }

        public static void OnPlayerDisconnect(IPlayer player, string type, string reason)
        {
            try
            {
                Tactics.Lobby.Main.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }
    }
}
