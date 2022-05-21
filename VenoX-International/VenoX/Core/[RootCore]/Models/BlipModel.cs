namespace VenoX.Core._RootCore_.Models
{
    public class BlipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int Sprite { get; set; }
        public int Color { get; set; }
        public bool ShortRange { get; set; }
        public VnXPlayer VisibleOnlyFor { get; set; }
    }
}
