using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class HouseModel
    {
        public int id { get; set; }
        public string ipl { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
        public int Dimension { get; set; }
        public int price { get; set; }
        public string owner { get; set; }
        public int status { get; set; }
        public int tenants { get; set; }
        public int rental { get; set; }
        public bool locked { get; set; }
        //public TextLabel houseLabel { get; set; }
    }
}
