using System;
using System.Numerics;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Derby.Lobby
{
    public class Main
    {
        public static void OnPlayerJoin(VnXPlayer player)
        {
            try { player.SetPosition = new Vector3(-5176.1562f, -7722.7764f, 6.0960693f); }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
