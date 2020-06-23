using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.environment.Weed
{
    public class Main : IScript
    {
        public static List<WeedModel> WeedList = new List<WeedModel>();


        ///////////////////////////////////////////////////////////////////////////////////

        public static void CreateWeedObject(WeedModel weed)
        {
            try
            {
                string Text = "~g~" + weed.Name + "\n____________\n ~g~Gewachsen : ~w~" + weed.Value + "% \n ~g~Erstellt am : ~w~ " + weed.Created;
                Core.RageAPI.CreateObject("WeedObjects", "prop_weed_01", weed.Position, weed.Rotation, new Quaternion(0, 0, 0, 0), true);
                Core.RageAPI.CreateTextLabel(Text, weed.Position, 20, 1, 0, new int[] { 255, 255, 255, 255 });
            }
            catch { }
        }

        [Command("createweedplants")]
        public static void CreateWeedPlants(Client player, int count)
        {
            for (int i = 0; i <= count; i++)
            {
                WeedModel weed = new WeedModel
                {
                    CreatedBy = player.Username,
                    Name = "Hanfpflanze",
                    Position = new Position(player.Position.X + (i / 2), player.Position.Y + (i / 2), player.Position.Z - 1f),
                    Rotation = player.Rotation,
                    Created = DateTime.Now,
                    Value = 15,
                    IsInWeedGarage = false,
                    IsFakeWeedPlant = false,
                };
                CreateWeedObject(weed);
                WeedList.Add(weed);
            }
        }
    }
}
