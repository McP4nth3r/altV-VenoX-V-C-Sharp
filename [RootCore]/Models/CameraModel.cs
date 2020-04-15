using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class CameraModel
    {
        public string CameraCreator { get; set; }
        public Vector3 StartPosition { get; set; }
        public Vector3 StartRotation { get; set; }
        public Vector3 EndPosition { get; set; }
        public Vector3 EndRotation { get; set; }
        public int DurationInMS { get; set; }
        public int ID { get; set; }
    }
}
