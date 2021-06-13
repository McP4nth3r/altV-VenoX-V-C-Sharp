using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VenoXV._Globals_;
using VenoXV.Models;

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
            List<CallContactModel> callClassList = new List<CallContactModel>();
            foreach (VnXPlayer players in Main.ReallifePlayers.ToList())
            {
                CallContactModel callClass = new CallContactModel
                {
                    Username = players.Username,
                    Number = players.Phone.Number.ToString()
                };
                if (!callClassList.Contains(callClass)) { callClassList.Add(callClass); }
            }
            foreach (VnXPlayer players in Main.ReallifePlayers.ToList())
            {
                VenoX.TriggerClientEvent(players, "Phone:LoadPlayerList", JsonConvert.SerializeObject(callClassList, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
        }
    }
}
