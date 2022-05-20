namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class FactionModel
    {
        public string DescriptionMale { get; set; }
        public string DescriptionFemale { get; set; }
        public int Faction { get; set; }
        public int Rank { get; set; }
        public int Salary { get; set; }

        public FactionModel(string descriptionMale, string descriptionFemale, int faction, int rank, int salary)
        {
            this.DescriptionMale = descriptionMale;
            this.DescriptionFemale = descriptionFemale;
            this.Faction = faction;
            this.Rank = rank;
            this.Salary = salary;
        }
    }
}
