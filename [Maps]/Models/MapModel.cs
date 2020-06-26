using System.Numerics;

namespace VenoXV._Maps_.Model
{
    public class Properties
    {
        public string TextureVariation { get; set; }
    }
    public class MapModel
    {
        public string MapName { get; set; }
        public string Type { get; set; }
        public string Hash { get; set; }
        public bool Dynamic { get; set; }
        public bool Door { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Properties Properties { get; set; }
        public int Texture { get; set; }
    }
}