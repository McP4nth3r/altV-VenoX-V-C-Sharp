using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Phone
    {
        private Player Player;
        public int Number { get; set; }
        public bool IsCallActive { get; set; }
        public Phone(Player player)
        {
            try
            {
                Player = player;

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

}
