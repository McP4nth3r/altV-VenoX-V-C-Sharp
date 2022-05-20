using System;
using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.SevenTowers.globals
{
    public class Main : IScript
    {
        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                lobby.Main.TakePlayerFromRound(player);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void OnColShapeHit(IColShape shape, VnXPlayer player)
        {
            lobby.Main.OnColShapeHit(shape, player);
        }
    }
}
