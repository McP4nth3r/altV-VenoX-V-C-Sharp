namespace VenoXV.Models
{
    public class BlipModel
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public float PosX { get; init; }
        public float PosY { get; init; }
        public float PosZ { get; init; }
        public int Sprite { get; init; }
        public int Color { get; init; }
        public bool ShortRange { get; init; }
        public VnXPlayer VisibleOnlyFor { get; init; }
    }
}
