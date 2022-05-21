using System;
using AltV.Net.Elements.Entities;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
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
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }

}
