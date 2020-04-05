using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using VenoXV.Reallife.Globals;

namespace VenoXV.RootCore
{
    public class Sync
    {
        public static void LoadAllTextLabels(IPlayer player)
        {
            if (Main.LabelList.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList1.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList2.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList3.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList4.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList5.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList6.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList7.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList8.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
            if (Main.LabelList9.Count > 0) { player.Emit("Sync:LoadTextLabels", JsonConvert.SerializeObject(Main.LabelList)); }
        }
    }
}
