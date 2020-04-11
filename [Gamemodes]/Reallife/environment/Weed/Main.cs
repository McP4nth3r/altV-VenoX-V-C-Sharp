using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV.Core;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.environment.Weed
{
    public class Main : IScript
    {
        public static List<WeedModel> WeedList = new List<WeedModel>();


        ///////////////////////////////////////////////////////////////////////////////////
        //Settings : 

        public const int MAX_WEED_DISTANCE = 50; // Die Maximale Distanz um ein Weed Objekt zu Streamen.
        public const int UPDATE_INTERVAL_WEED = 2; // Distance Interval zum Checken der Maximalen Distanz für jeden Spieler.
        public const int MAX_LIST_SIZE = 70;


        //Const
        public static DateTime NextUpdate = DateTime.Now;


        ///////////////////////////////////////////////////////////////////////////////////

        public static void CreateWeedObject(WeedModel weed)
        {
            try
            {
                foreach (IPlayer player in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (player.Position.Distance(weed.Position) <= MAX_WEED_DISTANCE)
                    {
                        player.Emit("Weed:Create", JsonConvert.SerializeObject(weed));
                    }
                }
            }
            catch { }
        }

        [Command("createweedplants")]
        public static void CreateWeedPlants(IPlayer player, int count)
        {
            for (int i = 0; i < count; i++)
            {
                WeedModel weed = new WeedModel
                {
                    CreatedBy = RageAPI.GetVnXName<string>(player),
                    Name = "Hanfpflanze",
                    Position = new Position(player.Position.X + (i / 2), player.Position.Y + (i / 2), player.Position.Z),
                    Rotation = player.Rotation,
                    Created = DateTime.Now,
                    Value = 15,
                    IsInWeedGarage = false,
                    IsFakeWeedPlant = false,
                };
                WeedList.Add(weed);
            }
        }
        public static void OnUpdate()
        {
            if (NextUpdate > DateTime.Now) { return; }
            foreach (IPlayer player in VenoXV.Globals.Main.ReallifePlayers)
            {
                player.Emit("Weed:Destroy");
                List<WeedModel> NearestWeedPlants = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants1 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants2 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants3 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants4 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants5 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants6 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants7 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants8 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants9 = new List<WeedModel>();
                List<WeedModel> NearestWeedPlants10 = new List<WeedModel>();
                foreach (WeedModel weed in WeedList)
                {
                    if (player.Position.Distance(weed.Position) <= MAX_WEED_DISTANCE)
                    {
                        if (NearestWeedPlants.Count < MAX_LIST_SIZE) { NearestWeedPlants.Add(weed); }
                        else if (NearestWeedPlants1.Count < MAX_LIST_SIZE) { NearestWeedPlants1.Add(weed); }
                        else if (NearestWeedPlants2.Count < MAX_LIST_SIZE) { NearestWeedPlants2.Add(weed); }
                        else if (NearestWeedPlants3.Count < MAX_LIST_SIZE) { NearestWeedPlants3.Add(weed); }
                        else if (NearestWeedPlants4.Count < MAX_LIST_SIZE) { NearestWeedPlants4.Add(weed); }
                        else if (NearestWeedPlants5.Count < MAX_LIST_SIZE) { NearestWeedPlants5.Add(weed); }
                    }
                }
                if (NearestWeedPlants.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants)); }
                if (NearestWeedPlants1.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants1)); }
                if (NearestWeedPlants2.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants2)); }
                if (NearestWeedPlants3.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants3)); }
                if (NearestWeedPlants4.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants4)); }
                if (NearestWeedPlants5.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants5)); }
                if (NearestWeedPlants6.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants6)); }
                if (NearestWeedPlants7.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants7)); }
                if (NearestWeedPlants8.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants8)); }
                if (NearestWeedPlants9.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants9)); }
                if (NearestWeedPlants10.Count > 0) { player.Emit("Weed:Update", JsonConvert.SerializeObject(NearestWeedPlants10)); }
            }
            NextUpdate = DateTime.Now.AddSeconds(UPDATE_INTERVAL_WEED);
        }
    }
}
