using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Models
{
    public class VehRace
    {
        private Vehicle _vehicle;
        public VnXPlayer Owner { get; set; }
        public VehRace(Vehicle vehicle)
        {
            try
            {
                _vehicle = vehicle;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
    public class Weapons
    {
        private Vehicle _vehicle;
        public static List<WeaponModel> List = new List<WeaponModel>();
        public Weapons(Vehicle vehicle)
        {
            try
            {
                _vehicle = vehicle;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
    public class VehReallife
    {
        private Vehicle _vehicle;
        public bool DrivingSchoolVehicle { get; set; }
        public string DrivingSchoolLicense { get; set; }
        public bool ActionVehicle { get; set; }
        public int Koks { get; set; }
        public Weapons Weapons { get; set; }
        public VehReallife(Vehicle vehicle)
        {
            try
            {
                _vehicle = vehicle;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
    public class VehicleModel : Vehicle
    {
        public int DatabaseId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public Vector3 SpawnCoord { get; set; }
        public Vector3 SpawnRot { get; set; }
        private string _Plate { get; set; }
        public string Plate { get => _Plate;
            set { _Plate = value; NumberplateText = Plate; } }
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public int Faction { get; set; }
        public bool Locked { get; set; }
        public int Price { get; set; }
        public string Job { get; set; }
        public bool NotSave { get; set; }
        private bool VehGodmode { get; set; }
        public bool Npc { get; set; }
        public bool Godmode { get { return VehGodmode; } set { VehGodmode = value; VenoX.TriggerEventForAll("Vehicle:Godmode", this, value); this.VnxSetStreamSharedElementData("VEHICLE_GODMODE", value); } }
        public bool IsTestVehicle { get; set; }
        public bool Rented { get; set; }
        private bool VehFrozen { get; set; }
        public bool Frozen { get { return VehFrozen; } set { VehFrozen = value; VenoX.TriggerEventForAll("Vehicle:Freeze", this, value); this.VnxSetStreamSharedElementData("VEHICLE_FROZEN", value); } }
        private float VehGas { get; set; }
        public float Gas { get { return VehGas; } set { VehGas = value; this.VnxSetStreamSharedElementData("VEHICLE_GAS", value); } }
        private float VehKms { get; set; }
        public float Kms { get { return VehKms; } set { VehKms = value; this.VnxSetStreamSharedElementData("VEHICLE_KMS", value); } }
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
            Npc = true;
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
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
    }

}
