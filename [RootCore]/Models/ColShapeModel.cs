using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV.Models
{
    public class ColShapeModel : ColShape
    {
        public Vector3 CurrentPosition { get; set; }
        public float Radius { get; set; }
        public int Faction { get; set; }
        public bool GangSkinCol { get; set; }
        public bool NeutralSkinCol { get; set; }
        public string ActionCol { get; set; }
        public bool MarkedForDelete { get; set; }
        public ColShapeModel(IServer server, IntPtr nativePointer) : base(server, nativePointer)
        {
            Faction = 0;
            GangSkinCol = false;
            NeutralSkinCol = false;
            MarkedForDelete = false;
            ActionCol = "";
        }
    }
    public class MyColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(IServer server, IntPtr baseObjectPointer)
        {
            try
            {
                return new ColShapeModel(server, baseObjectPointer);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
    }
}
