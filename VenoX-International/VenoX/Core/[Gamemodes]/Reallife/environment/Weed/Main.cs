﻿using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.environment.Weed
{
    public class Main : IScript
    {
        public static List<WeedModel> WeedList = new List<WeedModel>();


        ///////////////////////////////////////////////////////////////////////////////////

        public static void CreateWeedObject(WeedModel weed)
        {
            try
            {
                string text = "~g~" + weed.Name + "\n____________\n ~g~Gewachsen : ~w~" + weed.Value + "% \n ~g~Erstellt am : ~w~ " + weed.Created;
                RageApi.CreateObject("WeedObjects", "prop_weed_01", weed.Position, weed.Rotation, new Quaternion(0, 0, 0, 0), true);
                RageApi.CreateTextLabel(text, weed.Position, 20, 1, 0, new[] { 255, 255, 255, 255 });
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("createweedplants")]
        public static void CreateWeedPlants(VnXPlayer player, int count)
        {
            for (int i = 0; i <= count; i++)
            {
                WeedModel weed = new WeedModel
                {
                    CreatedBy = player.CharacterUsername,
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
