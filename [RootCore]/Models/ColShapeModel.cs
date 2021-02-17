using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class ColShapeModel : ColShape
    {
        public Vector3 CurrentPosition { get; set; }
        public float Radius { get; set; }
        public int Faction { get; set; }
        public bool GangSkinCol { get; set; }
        public bool NeutralSkinCol { get; set; }
        public string AktionCol { get; set; }
        public bool MarkedForDelete { get; set; }
        public ColShapeModel(IntPtr nativePointer) : base(nativePointer)
        {
            Faction = 0;
            GangSkinCol = false;
            NeutralSkinCol = false;
            MarkedForDelete = false;
            AktionCol = "";
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
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
    }
}
