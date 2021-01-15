using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public enum ItemType
    {
        Drugs = 0,
        Useable = 1,
        Clothes = 2,
        Gun = 3
    };
    public class ItemModel
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public int UID { get; set; }
        public int Amount { get; set; }
        public Position Position { get; set; }
        public int Dimension { get; set; }
        public float Weight { get; set; }
        public ItemType Type { get; set; }
    }
}
