using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class MarkerModel
    {
        public int Type { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        public int[] Color { get; set; }
        public float Scale { get; set; }
        public bool Visible { get; set; }
        public int Dimension { get; set; }
    }
}
