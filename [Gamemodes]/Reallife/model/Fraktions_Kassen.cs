using System;

namespace VenoXV.Reallife.model
{
    public class Fraktions_Kassen
    {
        
        public int mats { get; set; }
        public int koks { get; set; }
        public int weed { get; set; }
        public int money { get; set; }


        public Fraktions_Kassen() { }
        public Fraktions_Kassen(int mats, int koks, int weed, int money)
        {
            this.mats = mats;
            this.koks = koks;
            this.weed = weed;
            this.money = money;
        }
        
    }
}
