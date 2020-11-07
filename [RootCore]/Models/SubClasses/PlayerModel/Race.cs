using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Race
    {
        private Player Player;
        public bool IsRacing { get; set; }
        public int RoundPlace { get; set; }
        public int CurrentMarker { get; set; }
        public MarkerModel LastMarker { get; set; }
        public ColShapeModel LastColShapeModel { get; set; }
        public Race(Player player)
        {
            try
            {
                Player = player;
                IsRacing = false;
                RoundPlace = 0;
                CurrentMarker = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
