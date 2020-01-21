using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class BusinessModel
    {
        public int id { get; set; }
        public int type { get; set; }
        public string ipl { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
        public int Dimension { get; set; }
        public string owner { get; set; }
        public int funds { get; set; }
        public int products { get; set; }
        public float multiplier { get; set; }
        public bool locked { get; set; }
    }
}
