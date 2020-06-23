using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class ObjectModel
    {
        public int ID { get; set; }
        public string Parent { get; set; }
        public string Hash { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Quaternion Quaternion { get; set; }
        public bool HashNeeded { get; set; }
        public int Dimension { get; set; }
        public Client VisibleOnlyFor { get; set; }

    }
}
