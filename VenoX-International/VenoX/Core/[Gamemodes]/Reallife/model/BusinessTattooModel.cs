namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class BusinessTattooModel
    {
        public int Slot { get; set; }
        public string Name { get; set; }
        public string Library { get; set; }
        public string MaleHash { get; set; }
        public string FemaleHash { get; set; }
        public int Price { get; set; }

        public BusinessTattooModel(int slot, string name, string library, string maleHash, string femaleHash, int price)
        {
            this.Slot = slot;
            this.Name = name;
            this.Library = library;
            this.MaleHash = maleHash;
            this.FemaleHash = femaleHash;
            this.Price = price;
        }
    }
}
