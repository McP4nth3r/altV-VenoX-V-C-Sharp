﻿using System.Numerics;

namespace VenoX.Core._RootCore_.Models
{
    public class NpcModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Gamemode { get; set; }
    }
}
