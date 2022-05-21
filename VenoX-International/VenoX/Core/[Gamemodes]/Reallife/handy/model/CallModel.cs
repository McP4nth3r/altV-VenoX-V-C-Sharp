using AltV.Net.Elements.Entities;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Gamemodes_.Reallife.handy.model
{
    public class CallModel
    {
        public VnXPlayer Caller { get; set; }
        public VnXPlayer Target { get; set; }
        public IVoiceChannel CurrentCallChannel { get; set; }
    }
}
