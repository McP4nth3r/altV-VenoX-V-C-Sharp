using System;
using System.Linq;
using System.Numerics;
using VenoX.Core._Gamemodes_.Zombie.KI;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Zombie.Models
{
    public class ZombieModel
    {
        public int Id { get; set; }
        public int Sex { get; set; }
        public int RandomSkinUid { get; set; }
        public string SkinName { get; set; }
        private Vector3 _Position { get; set; }
        public VnXPlayer Killer { get; set; }
        public Vector3 Position
        {
            get => _Position;
            init
            {
                _Position = value;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers).Where(players => players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer)) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:SetPosition", Id, value.X, value.Y, value.Z);
            }
        }
        private Vector3 _Rotation { get; set; }
        public Vector3 Rotation
        {
            get => _Rotation;
            set
            {
                _Rotation = value;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers).Where(players => players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer)) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:SetRotation", Id, value.X, value.Y, value.Z);
            }
        }
        public void UpdatePositionAndRotation(Vector3 position, Vector3 rotation, bool sync = false)
        {
            try
            {
                _Position = position;
                _Rotation = rotation;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers))
                    if (players.Zombies.NearbyZombies.Contains(this) && !players.Zombies.IsSyncer && sync) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:UpdatePositionAndRotation", Id, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        private int _Armor { get; set; }
        public int Armor
        {
            get => _Armor;
            set
            {
                _Armor = value;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers).Where(players => players.Zombies.NearbyZombies.Contains(this))) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:SetArmor", Id, value);
            }
        }
        private int _Health { get; set; }
        public int Health
        {
            get => _Health;
            set
            {
                _Health = value;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers).Where(players => players.Zombies.NearbyZombies.Contains(this))) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:SetHealth", Id, value);
            }
        }
        private bool _IsDead { get; set; }
        public bool IsDead
        {
            get => _IsDead;
            set
            {
                _IsDead = value;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers).Where(players => players.Zombies.NearbyZombies.Contains(this) && Killer != players)) _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:SetDead", Id, value);
            }
        }
        public void Destroy()
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ZombiePlayers))
                    if (players.Zombies.NearbyZombies.Contains(this)) { _RootCore_.VenoX.TriggerClientEvent(players, "Zombies:Destroy", Id); players?.Zombies.NearbyZombies.Remove(this); }
                
                Spawner.CurrentZombies.Remove(this);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public VnXPlayer TargetEntity { get; set; }
    }
}
