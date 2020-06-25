using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;

namespace VenoXV.SevenTowers.globals
{
    public class Main : IScript
    {
        public static void OnPlayerDisconnect(Client player)
        {
            try
            {
                _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                Globals.Main.SevenTowersPlayers.Remove(player);
            }
            catch { }
        }
        public static void OnColShapeHit(IColShape shape, Client player)
        {
            VenoXV._Gamemodes_.SevenTowers.Main.OnColShapeHit(shape, player);
        }
    }
}
