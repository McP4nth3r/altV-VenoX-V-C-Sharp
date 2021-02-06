using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.handy
{
    public class CallContactModel
    {
        public string Username { get; set; }
        public string Number { get; set; }
    }
    public class Allround
    {
        public static void UpdatePhonePlayerlist()
        {
            List<CallContactModel> CallClassList = new List<CallContactModel>();
            foreach (VnXPlayer players in VenoXV._Globals_.Main.ReallifePlayers.ToList())
            {
                CallContactModel CallClass = new CallContactModel
                {
                    Username = players.Username,
                    Number = players.Phone.Number.ToString()
                };
                if (!CallClassList.Contains(CallClass)) { CallClassList.Add(CallClass); }
            }
            foreach (VnXPlayer players in VenoXV._Globals_.Main.ReallifePlayers.ToList())
            {
                VenoX.TriggerClientEvent(players, "Phone:LoadPlayerList", JsonConvert.SerializeObject(CallClassList, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
        }
    }
}
