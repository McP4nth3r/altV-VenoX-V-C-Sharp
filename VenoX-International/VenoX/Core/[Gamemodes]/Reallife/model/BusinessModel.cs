using AltV.Net.Data;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Ipl { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Dimension { get; set; }
        public string Owner { get; set; }
        public int Funds { get; set; }
        public int Products { get; set; }
        public float Multiplier { get; set; }
        public bool Locked { get; set; }
    }
}
