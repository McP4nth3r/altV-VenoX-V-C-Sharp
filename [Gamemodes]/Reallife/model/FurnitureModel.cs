using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace VenoXV.Reallife.model
{
    public class FurnitureModel
    {
        public int id { get; set; }
        public uint hash { get; set; }
        public uint house { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public AltV.Net.IBaseBaseObjectPool handle { get; set; }
    }
}
