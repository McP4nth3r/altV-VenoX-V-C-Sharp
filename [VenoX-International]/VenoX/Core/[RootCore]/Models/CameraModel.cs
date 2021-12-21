using System.Numerics;

namespace VenoXV.Models
{
    public class CameraModel
    {
        public string CameraCreator { get; set; }
        public Vector3 StartPosition { get; set; }
        public Vector3 StartRotation { get; set; }
        public Vector3 EndPosition { get; set; }
        public Vector3 EndRotation { get; set; }
        public int DurationInMs { get; set; }
        public int Id { get; set; }
    }
}
