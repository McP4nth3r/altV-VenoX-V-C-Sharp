using System;
using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;
using VenoXV.Models;

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
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void OnColShapeHit(IColShape shape, VnXPlayer player)
        {
            _Gamemodes_.SevenTowers.Main.OnColShapeHit(shape, player);
        }
    }
}
