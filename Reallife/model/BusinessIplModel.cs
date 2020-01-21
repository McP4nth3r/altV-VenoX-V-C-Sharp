using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class BusinessIplModel
    {
        public int type { get; set; }
        public string ipl { get; set; }
        public Position position { get; set; }

        public BusinessIplModel(int type, string ipl, Position position)
        {
            this.type = type;
            this.ipl = ipl;
            this.position = position;
        }
    }
}
