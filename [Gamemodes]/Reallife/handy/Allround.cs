using Newtonsoft.Json;
using System.Linq;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Allround
    {
        public static void UpdatePhonePlayerlist()
        {
            foreach (VnXPlayer players in VenoXV.Globals.Main.ReallifePlayers.ToList())
            {
                players.Emit("Phone:LoadPlayerList", JsonConvert.SerializeObject(VenoXV.Globals.Main.ReallifePlayers, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
        }
    }
}
