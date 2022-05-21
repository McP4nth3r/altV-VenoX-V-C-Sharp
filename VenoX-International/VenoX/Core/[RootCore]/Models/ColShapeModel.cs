using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models
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

        public ColShapeModel(ICore core, IntPtr nativePointer) : base(core, nativePointer)
        {
        }

        public ColShapeModel(ICore core, IntPtr nativePointer, BaseObjectType baseObjectType) : base(core, nativePointer, baseObjectType)
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
        public IColShape Create(ICore server, IntPtr baseObjectPointer)
        {
            try
            {
                return new ColShapeModel(server, baseObjectPointer);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return null; }
        }
    }
}
