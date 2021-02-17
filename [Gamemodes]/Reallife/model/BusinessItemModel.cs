using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class BusinessItemModel
    {
        public string Description { get; set; }
        public string Hash { get; set; }
        public int Type { get; set; }
        public int Products { get; set; }
        public float Weight { get; set; }
        public int Health { get; set; }
        public int Uses { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public int Business { get; set; }
        public float AlcoholLevel { get; set; }

        public BusinessItemModel(string description, string hash, int type, int products, float weight, int health, int uses, Position position, Rotation rotation, int business, float alcoholLevel)
        {
            this.Description = description;
            this.Hash = hash;
            this.Type = type;
            this.Products = products;
            this.Weight = weight;
            this.Health = health;
            this.Uses = uses;
            this.Position = position;
            this.Rotation = rotation;
            this.Business = business;
            this.AlcoholLevel = alcoholLevel;
        }
    }
}
