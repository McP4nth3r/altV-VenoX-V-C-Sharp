﻿using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class ColShapeModel : ColShape
    {
        public Vector3 CurrentPosition { get; set; }
        public float Radius { get; set; }
        public int Faction { get; set; }
        public bool GangSkinCol { get; set; }
        public bool NeutralSkinCol { get; set; }
        public ColShapeModel(IntPtr nativePointer) : base(nativePointer)
        {
            Faction = 0;
            GangSkinCol = false;
            NeutralSkinCol = false;
        }
    }
    public class MyColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(IntPtr playerPointer)
        {
            try
            {
                return new ColShapeModel(playerPointer);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
    }
}
