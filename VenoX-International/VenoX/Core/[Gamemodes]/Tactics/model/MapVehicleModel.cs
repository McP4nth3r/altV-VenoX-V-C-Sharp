using System.Numerics;
using AltV.Net.Enums;

namespace VenoX.Core._Gamemodes_.Tactics.model
{
    public class MapVehicleModel
    {
        public VehicleModel VehicleHash { get; set; }
        public Vector3 VehiclePosition { get; set; }
        public Vector3 VehicleRotation { get; set; }
    }
}
