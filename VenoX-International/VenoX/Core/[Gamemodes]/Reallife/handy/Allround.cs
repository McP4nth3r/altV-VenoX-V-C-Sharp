using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Gamemodes_.Reallife.handy
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
            foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
            {
                CallContactModel callClass = new CallContactModel
                {
                    Username = players.CharacterUsername,
                    Number = players.Phone.Number.ToString()
                };
                if (!callClassList.Contains(callClass)) { callClassList.Add(callClass); }
            }
            foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
            {
                _RootCore_.VenoX.TriggerClientEvent(players, "Phone:LoadPlayerList", JsonConvert.SerializeObject(callClassList, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
        }
    }
}
