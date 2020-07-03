namespace VenoXV._Maps_.Models
{

    public class PositionRotation
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float Yaw { get; set; }
    }
    public class MenyooMapModel
    {
        public string ModelHash { get; set; }
        public string HashName { get; set; }
        public PositionRotation PositionRotation { get; set; }
    }
}
