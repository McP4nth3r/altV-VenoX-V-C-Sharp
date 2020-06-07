using Newtonsoft.Json;
using System.Linq;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class Allround
    {
        public static void UpdatePhonePlayerlist()
        {
            foreach (Client players in VenoXV.Globals.Main.ReallifePlayers)
            {
                players.Emit("Phone:LoadPlayerList", JsonConvert.SerializeObject(VenoXV.Globals.Main.ReallifePlayers.ToList()));
            }
        }
    }
}
