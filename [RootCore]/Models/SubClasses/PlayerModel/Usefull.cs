using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Usefull
    {
        public DateTime LastVehicleLeaveEventCall { get; set; }
        public Usefull(Player player)
        {
            try
            {
                LastVehicleLeaveEventCall = DateTime.Now;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

}
