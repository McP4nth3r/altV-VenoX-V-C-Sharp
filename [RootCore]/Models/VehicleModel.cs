using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class VehRace
    {
        private Vehicle Vehicle;
        public VnXPlayer Owner { get; set; }
        public VehRace(Vehicle vehicle)
        {
            try
            {
                Vehicle = vehicle;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Weapons
    {
        private Vehicle Vehicle;
        public static List<AltV.Net.Enums.WeaponModel> List = new List<AltV.Net.Enums.WeaponModel>();
        public Weapons(Vehicle vehicle)
        {
            try
            {
                Vehicle = vehicle;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class VehReallife
    {
        private Vehicle Vehicle;
        public bool DrivingSchoolVehicle { get; set; }
        public string DrivingSchoolLicense { get; set; }
        public bool ActionVehicle { get; set; }
        public int Koks { get; set; }
        public Weapons Weapons { get; set; }
        public VehReallife(Vehicle vehicle)
        {
            try
            {
                Vehicle = vehicle;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class VehicleModel : Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public Vector3 SpawnCoord { get; set; }
        public Vector3 SpawnRot { get; set; }
        public string _Plate { get; set; }
        public string Plate { get { return _Plate; } set { _Plate = value; NumberplateText = Plate; } }
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public int Faction { get; set; }
        public bool Locked { get; set; }
        public int Price { get; set; }
        public string Job { get; set; }
        public bool NotSave { get; set; }
        private bool vehGodmode { get; set; }
        public bool NPC { get; set; }
        public bool Godmode { get { return vehGodmode; } set { vehGodmode = value; Alt.EmitAllClients("Vehicle:Godmode", this, value); this.vnxSetStreamSharedElementData("VEHICLE_GODMODE", value); } }
        public bool Testing { get; set; }
        public bool Rented { get; set; }
        private bool vehFrozen { get; set; }
        public bool Frozen { get { return vehFrozen; } set { vehFrozen = value; Alt.EmitAllClients("Vehicle:Freeze", this, value); this.vnxSetStreamSharedElementData("VEHICLE_FROZEN", value); } }
        private float vehGas { get; set; }
        public float Gas { get { return vehGas; } set { vehGas = value; this.vnxSetStreamSharedElementData("VEHICLE_GAS", value); } }
        private float vehKms { get; set; }
        public float Kms { get { return vehKms; } set { vehKms = value; this.vnxSetStreamSharedElementData("VEHICLE_KMS", value); } }
        public bool MarkedForDelete { get; set; }
        public VehRace Race { get; }
        public VehReallife Reallife { get; }
        public VehicleModel(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {

        }
        public VehicleModel(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            Plate = "alt-V";
            Locked = true;
            Godmode = true;
            Owner = "";
            Gas = 100;
            Kms = 0;
            Race = new VehRace(this);
            MarkedForDelete = false;
            Reallife = new VehReallife(this)
            {
                Weapons = new Weapons(this)
            };
            ManualEngineControl = true;
            NPC = true;
        }
        public List<VnXPlayer> Passenger = new List<VnXPlayer>();

    }
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr playerPointer, ushort id)
        {
            try
            {
                return new VehicleModel(playerPointer, id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
    }

}
