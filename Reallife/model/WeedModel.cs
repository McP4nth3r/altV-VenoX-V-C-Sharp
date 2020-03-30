﻿using AltV.Net.Data;
using System;

namespace VenoXV.Reallife.model
{
    public class WeedModel
    {
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public DateTime Created { get; set; }
        public int Value { get; set; }
        public bool IsInWeedGarage { get; set; }
        public bool IsFakeWeedPlant { get; set; }
    }
}
