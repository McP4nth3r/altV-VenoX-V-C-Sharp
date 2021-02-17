using System;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Race
    {
        private Player _player;
        public bool IsRacing { get; set; }
        public int RoundPlace { get; set; }
        public int CurrentMarker { get; set; }
        public MarkerModel LastMarker { get; set; }
        public ColShapeModel LastColShapeModel { get; set; }
        public Race(Player player)
        {
            try
            {
                _player = player;
                IsRacing = false;
                RoundPlace = 0;
                CurrentMarker = 0;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
