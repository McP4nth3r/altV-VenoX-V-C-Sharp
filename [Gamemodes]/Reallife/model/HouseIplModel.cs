using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class HouseIplModel
    {
        public string ipl { get; set; }
        public Position position { get; set; }

        public HouseIplModel(string ipl, Position position)
        {
            this.ipl = ipl;
            this.position = position;
        }
    }
}
