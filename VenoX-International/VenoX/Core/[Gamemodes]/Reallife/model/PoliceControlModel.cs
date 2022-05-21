using AltV.Net;
using AltV.Net.Data;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class PoliceControlModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Item { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public IBaseBaseObjectPool ControlObject { get; set; }
    }
}
