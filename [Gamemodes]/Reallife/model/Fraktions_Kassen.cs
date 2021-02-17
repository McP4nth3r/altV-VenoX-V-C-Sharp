namespace VenoXV._Gamemodes_.Reallife.model
{
    public class FraktionsKassen
    {
        
        public int Mats { get; set; }
        public int Koks { get; set; }
        public int Weed { get; set; }
        public int Money { get; set; }


        public FraktionsKassen() { }
        public FraktionsKassen(int mats, int koks, int weed, int money)
        {
            this.Mats = mats;
            this.Koks = koks;
            this.Weed = weed;
            this.Money = money;
        }
        
    }
}
