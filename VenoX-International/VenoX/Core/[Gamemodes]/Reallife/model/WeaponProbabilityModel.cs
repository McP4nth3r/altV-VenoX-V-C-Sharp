namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class WeaponProbabilityModel
    {
        public int Type { get; set; }
        public string Hash { get; set; }
        public int Amount { get; set; }
        public int MinChance { get; set; }
        public int MaxChance { get; set; }

        public WeaponProbabilityModel(int type, string hash, int amount, int minChance, int maxChance)
        {
            this.Type = type;
            this.Hash = hash;
            this.Amount = amount;
            this.MinChance = minChance;
            this.MaxChance = maxChance;
        }
    }
}
