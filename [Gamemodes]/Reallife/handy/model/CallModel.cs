using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy.model
{
    public class CallModel
    {
        public VnXPlayer Caller { get; set; }
        public VnXPlayer Target { get; set; }
        public IVoiceChannel CurrentCallChannel { get; set; }
    }
}
