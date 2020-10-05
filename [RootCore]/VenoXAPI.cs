using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_
{
    public class VenoX
    {
        public static List<VnXPlayer> GetAllPlayers()
        {
            try { return Globals.Main.AllPlayers; }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<VnXPlayer>(); }
        }
    }
}
