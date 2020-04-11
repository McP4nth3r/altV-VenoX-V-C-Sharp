using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace VenoXV._Gamemodes_.Race.model
{
    public class VehicleModel
    {
        public string Vehicle_Owner { get; set; }
        public AltV.Net.Enums.VehicleModel Vehicle_Hash { get; set; }
        public Position Vehicle_Position { get; set; }
        public Position Vehicle_Rotation { get; set; }
        public IVehicle vehicle { get; set; }
    }
}
