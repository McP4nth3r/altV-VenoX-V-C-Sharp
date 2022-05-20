namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class ClothesModel
    {
        public int Id { get; set; }
        public int Player { get; set; }
        public int Type { get; set; }
        public int Slot { get; set; }
        public int Drawable { get; set; }
        public int Texture { get; set; }
        public bool Dressed { get; set; }
    }
}
