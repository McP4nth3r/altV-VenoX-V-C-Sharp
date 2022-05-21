using System.Numerics;

namespace VenoX.Core._Gamemodes_.Shooter.Models
{
    public class SpawnModel
    {
        public Vector3 Coord { get; set; }
        public Vector3 Rotation { get; set; }
        public bool IsBeingUsed { get; set; }
    }
}
