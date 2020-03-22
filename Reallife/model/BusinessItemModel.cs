using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class BusinessItemModel
    {
        public string description { get; set; }
        public string hash { get; set; }
        public int type { get; set; }
        public int products { get; set; }
        public float weight { get; set; }
        public int health { get; set; }
        public int uses { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public int business { get; set; }
        public float alcoholLevel { get; set; }

        public BusinessItemModel(string description, string hash, int type, int products, float weight, int health, int uses, Position position, Rotation rotation, int business, float alcoholLevel)
        {
            this.description = description;
            this.hash = hash;
            this.type = type;
            this.products = products;
            this.weight = weight;
            this.health = health;
            this.uses = uses;
            this.position = position;
            this.rotation = rotation;
            this.business = business;
            this.alcoholLevel = alcoholLevel;
        }
    }
}
