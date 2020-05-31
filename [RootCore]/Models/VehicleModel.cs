using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Numerics;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class VehicleModel : Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public Vector3 SpawnCoord { get; set; }
        public Vector3 SpawnRot { get; set; }
        public string Plate { get; set; }
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public int Faction { get; set; }
        public bool Locked { get; set; }
        public int Price { get; set; }
        public string Job { get; set; }
        public bool Save { get; set; }
        public bool vehGodmode { get; set; }
        public bool Godmode { get { return vehGodmode; } set { vehGodmode = value; AltV.Net.Alt.EmitAllClients("Vehicle:Godmode", this, value); this.vnxSetSharedElementData("VEHICLE_GODMODE", value); } }
        public bool Testing { get; set; }
        public bool Rented { get; set; }
        private bool vehFrozen { get; set; }
        public bool Frozen { get { return vehFrozen; } set { vehFrozen = value; AltV.Net.Alt.EmitAllClients("Vehicle:Freeze", this, value); this.vnxSetSharedElementData("VEHICLE_FROZEN", value); } }
        public float Gas { get; set; }
        public float Kms { get; set; }
        public VehicleModel(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {
        }
        public VehicleModel(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
        }

    }

    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr playerPointer, ushort id)
        {
            try
            {
                return new VehicleModel(playerPointer, id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("VehicleFactory:Create", ex); return null; }
        }
    }

}
