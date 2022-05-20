namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class TunningPriceModel
    {
        public int Slot { get; set; }
        public int Products { get; set; }

        public TunningPriceModel(int slot, int products)
        {
            this.Slot = slot;
            this.Products = products;
        }
    }
}
