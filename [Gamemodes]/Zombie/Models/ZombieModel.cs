using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.KI;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Models
{
    public class ZombieModel
    {
        public int ID { get; set; }
        public int Sex { get; set; }
        public int RandomSkinUID { get; set; }
        public string SkinName { get; set; }
        private Vector3 _Position { get; set; }
        public VnXPlayer Killer { get; set; }
        public Vector3 Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer) VenoX.TriggerClientEvent(players, "Zombies:SetPosition", this.ID, value.X, value.Y, value.Z);
            }
        }
        private Vector3 _Rotation { get; set; }
        public Vector3 Rotation
        {
            get { return _Rotation; }
            set
            {
                _Rotation = value;
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer) VenoX.TriggerClientEvent(players, "Zombies:SetRotation", this.ID, value.X, value.Y, value.Z);
            }
        }
        public void UpdatePositionAndRotation(Vector3 position, Vector3 rotation, bool sync = false)
        {
            try
            {
                _Position = position;
                _Rotation = rotation;
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer && sync) VenoX.TriggerClientEvent(players, "Zombies:UpdatePositionAndRotation", this.ID, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z);
            }
            catch { }
        }
        private int _Armor { get; set; }
        public int Armor
        {
            get { return _Armor; }
            set
            {
                _Armor = value; foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this)) VenoX.TriggerClientEvent(players, "Zombies:SetArmor", this.ID, value);
            }
        }
        private int _Health { get; set; }
        public int Health
        {
            get { return _Health; }
            set
            {
                _Health = value; foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this)) VenoX.TriggerClientEvent(players, "Zombies:SetHealth", this.ID, value);
            }
        }
        private bool _IsDead { get; set; }
        public bool IsDead
        {
            get { return _IsDead; }
            set
            {
                _IsDead = value;
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this) && this.Killer != players) VenoX.TriggerClientEvent(players, "Zombies:SetDead", this.ID, value);
            }
        }
        public void Destroy()
        {
            try
            {
                foreach (VnXPlayer players in VenoXV.Globals.Main.ZombiePlayers.ToList())
                    if (players.Zombies.NearbyZombies.Contains(this)) { VenoX.TriggerClientEvent(players, "Zombies:Destroy", this.ID); players?.Zombies.NearbyZombies.Remove(this); }
                Spawner.CurrentZombies.Remove(this);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public VnXPlayer TargetEntity { get; set; }
    }
}
