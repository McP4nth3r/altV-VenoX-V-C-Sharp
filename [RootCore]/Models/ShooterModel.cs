using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Shooter
    {
        public bool IsAlive { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public Shooter(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
