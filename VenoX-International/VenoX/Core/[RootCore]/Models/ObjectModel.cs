using System.Numerics;

namespace VenoX.Core._RootCore_.Models
{
    public class ObjectModel
    {
        public int Id { get; set; }
        public string Parent { get; set; }
        public string Hash { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Quaternion Quaternion { get; set; }
        public bool HashNeeded { get; set; }
        public int Dimension { get; set; }
        public VnXPlayer VisibleOnlyFor { get; set; }

    }
}
