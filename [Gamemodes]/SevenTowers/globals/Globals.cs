using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;

namespace VenoXV.SevenTowers.globals
{
    public class Main : IScript
    {
        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
            }
            catch { }
        }
        public static void OnColShapeHit(IColShape shape, VnXPlayer player)
        {
            VenoXV._Gamemodes_.SevenTowers.Main.OnColShapeHit(shape, player);
        }
    }
}
