using System.Numerics;

namespace VenoXV.Models
{
    public class MarkerModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public Vector3 Position { get; set; }
        public int[] Color { get; set; }
        public Vector3 Scale { get; set; }
        public bool Visible { get; set; }
        public int Dimension { get; set; }
        public VnXPlayer VisibleOnlyFor { get; set; }
    }
}
