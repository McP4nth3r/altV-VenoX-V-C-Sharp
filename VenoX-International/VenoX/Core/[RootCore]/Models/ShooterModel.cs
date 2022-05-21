using System;
using AltV.Net.Elements.Entities;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models
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
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
