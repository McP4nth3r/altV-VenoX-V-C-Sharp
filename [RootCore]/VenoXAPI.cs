using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_
{
    public class VenoX
    {
        public static List<Client> GetAllPlayers()
        {
            try
            {
                return Globals.Main.AllPlayers;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("GetAllPlayers", ex); return new List<Client>(); }
        }
    }
}
