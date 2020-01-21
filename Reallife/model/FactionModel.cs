using System;

namespace VenoXV.Reallife.model
{
    public class FactionModel
    {
        public string deIScriptionMale { get; set; }
        public string deIScriptionFemale { get; set; }
        public int faction { get; set; }
        public int rank { get; set; }
        public int salary { get; set; }

        public FactionModel(string deIScriptionMale, string deIScriptionFemale, int faction, int rank, int salary)
        {
            this.deIScriptionMale = deIScriptionMale;
            this.deIScriptionFemale = deIScriptionFemale;
            this.faction = faction;
            this.rank = rank;
            this.salary = salary;
        }
    }
}
