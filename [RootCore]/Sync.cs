using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;

namespace VenoXV.RootCore
{
    public class Sync
    {
        public static void LoadAllTextLabels(PlayerModel player)
        {
            var json = JsonConvert.SerializeObject(Main.LabelList);
            var list = new List<string>();
            for (int i = 0; i < json.Length; i += 5000)
                list.Add(json.Substring(i, Math.Min(5000, json.Length - i)));

            for (int i = 0; i < list.Count; ++i)
                player.Emit("Sync:LoadTextLabels", list[i], i, list.Count);

            /*if (Main.LabelList.Count > 0)
            { 
                player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); 
            }*/
        }
    }
}
