using System;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV.Models.SubClasses.PlayerModel
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }

}
