using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class BlipModel
    {
        public string Name { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }
        public int Sprite { get; set; }
        public int Color { get; set; }
        public bool ShortRange { get; set; }
    }
}
