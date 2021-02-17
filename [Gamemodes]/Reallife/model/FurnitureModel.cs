using AltV.Net;
using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class FurnitureModel
    {
        public int Id { get; set; }
        public uint Hash { get; set; }
        public uint House { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public IBaseBaseObjectPool Handle { get; set; }
    }
}
