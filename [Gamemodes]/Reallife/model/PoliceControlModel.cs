using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class PoliceControlModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int item { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public AltV.Net.IBaseBaseObjectPool controlObject { get; set; }

        public PoliceControlModel() { }
    }
}
