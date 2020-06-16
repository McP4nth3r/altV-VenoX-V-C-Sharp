using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy.model
{
    public class CallModel
    {
        public Client Caller { get; set; }
        public Client Target { get; set; }
        public IVoiceChannel CurrentCallChannel { get; set; }
    }
}
