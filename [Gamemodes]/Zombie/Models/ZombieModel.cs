using System.Numerics;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Models
{
    public class ZombieModel
    {
        public int ID { get; set; }
        public string SkinName { get; set; }
        public Vector3 Position { get; set; }
        public bool IsDead { get; set; }
        public Client TargetEntity { get; set; }
    }
}
