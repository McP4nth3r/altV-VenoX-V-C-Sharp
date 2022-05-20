using AltV.Net.Data;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class HouseModel
    {
        public int Id { get; set; }
        public string Ipl { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Dimension { get; set; }
        public int Price { get; set; }
        public string Owner { get; set; }
        public int Status { get; set; }
        public int Tenants { get; set; }
        public int Rental { get; set; }
        public bool Locked { get; set; }
        //public TextLabel houseLabel { get; set; }
    }
}
