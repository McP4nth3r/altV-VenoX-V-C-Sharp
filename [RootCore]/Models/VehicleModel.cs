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
        public bool Godmode { get { return vehGodmode; } set { vehGodmode = value; AltV.Net.Alt.EmitAllClients("Vehicle:Godmode", this, value); this.vnxSetStreamSharedElementData("VEHICLE_GODMODE", value); } }
        public bool Testing { get; set; }
        public bool Rented { get; set; }
        private bool vehFrozen { get; set; }
        public bool Frozen { get { return vehFrozen; } set { vehFrozen = value; AltV.Net.Alt.EmitAllClients("Vehicle:Freeze", this, value); this.vnxSetStreamSharedElementData("VEHICLE_FROZEN", value); } }
        private float vehGas { get; set; }
        public float Gas { get { return vehGas; } set { vehGas = value; this.vnxSetStreamSharedElementData("VEHICLE_GAS", value); } }
        private float vehKms { get; set; }
        public float Kms { get { return vehKms; } set { vehKms = value; this.vnxSetStreamSharedElementData("VEHICLE_KMS", value); } }
        public VehicleModel(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {

        }
        public VehicleModel(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            Plate = "alt-V";
            Locked = true;
            Godmode = true;
            Frozen = true;
            Owner = "";
            Gas = 100;
            Kms = 0;
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
