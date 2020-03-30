using AltV.Net;
using AltV.Net.Elements.Entities;

namespace VenoXV.Tactics.Globals
{
    public class Main : IScript
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
