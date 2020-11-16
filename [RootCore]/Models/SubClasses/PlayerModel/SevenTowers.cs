using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class SevenTowers
    {
        public int Wins { get; set; }
        public bool Spawned { get; set; }
        public bool IsSpectator { get; set; }
        public DateTime SpawnedTime { get; set; }
        public DateTime LastVehicleGot { get; set; }
        public SevenTowers(Player player)
        {
            try
            {
                SpawnedTime = DateTime.Now;
                LastVehicleGot = DateTime.Now;
                IsSpectator = false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
