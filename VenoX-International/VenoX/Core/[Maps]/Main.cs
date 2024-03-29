﻿using System;
using System.Collections.Generic;
using System.IO;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoX.Core._Maps_.Models;
using VenoX.Core._Maps_.Models.DurtyMapModel;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Maps_
{
    public class Main : IScript
    {
        public const string LspdMap = "LSPD";
        private static readonly List<MapModel> Lspdmap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + LspdMap + ".json"));

        public const string NoobspawnMap = "NOOBSPAWN";
        private static readonly List<MapModel> Noobspawnmap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + NoobspawnMap + ".json"));

        public const string StadthalleMap = "STADTHALLE";
        private static readonly List<MapModel> Stadthallemap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + StadthalleMap + ".json"));

        public const string WuerfelparkMap = "WUERFELPARK";
        private static readonly List<MapModel> Wuerfelparkmap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + WuerfelparkMap + ".json"));

        public const string SeventowersMap = "SEVENTOWERS";
        private static readonly List<MapModel> Seventowersmap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + SeventowersMap + ".json"));

        public const string Derby1Map = "DERBY1";
        private static readonly List<DurtyMapModel> Derby1map = JsonConvert.DeserializeObject<List<DurtyMapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + Derby1Map + ".json"));

        public const string ShooterMap = "SHOOTER";
        private static readonly List<MapModel> Shootermap = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + ShooterMap + ".json"));

        private static readonly int RotOrderNormal = 2;
        public static void LoadMap(VnXPlayer playerClass, string mapName)
        {
            try
            {
                switch (mapName)
                {
                    case LspdMap:
                        foreach (MapModel mapClass in Lspdmap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( LSPD )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, RotOrderNormal, mapClass.Rotation, true, false);
                        }
                        break;
                    case NoobspawnMap:
                        foreach (MapModel mapClass in Noobspawnmap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( Noobspawn )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, RotOrderNormal, mapClass.Rotation, true, false);
                        }
                        break;
                    case StadthalleMap:
                        foreach (MapModel mapClass in Stadthallemap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( CityHall )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, RotOrderNormal, mapClass.Rotation, true, false);
                        }
                        break;
                    case SeventowersMap:
                        foreach (MapModel mapClass in Seventowersmap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( SevenTowers )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, 2, mapClass.Rotation, true, false, true, mapClass.Properties.TextureVariation);
                        }
                        break;
                    case WuerfelparkMap:
                        foreach (MapModel mapClass in Wuerfelparkmap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( Cube-Park )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, RotOrderNormal, mapClass.Rotation, true, false, true);
                        }
                        break;
                    case Derby1Map:
                        foreach (DurtyMapModel mapClass in Derby1map)
                        {
                            if (mapClass.Model == 665940918)
                            {
                                _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( Derby )","Sync:LoadMap", mapName, "v_corp_postbox", mapClass.PositionRotation.Position, 2, mapClass.PositionRotation.Rotation, true, true, true, mapClass.Properties.TextureVariation);
                            }
                            else
                            {
                                _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( Derby )","Sync:LoadMap", mapName, mapClass.Model, mapClass.PositionRotation.Position, 2, mapClass.PositionRotation.Rotation, true, false, true, mapClass.Properties.TextureVariation);
                            }
                        }
                        break;
                    case ShooterMap:
                        foreach (MapModel mapClass in Shootermap)
                        {
                            _RootCore_.VenoX.TriggerPreloadEvent(playerClass, "Loading Map ( Shooter )","Sync:LoadMap", mapName, mapClass.Hash, mapClass.Position, RotOrderNormal, mapClass.Rotation, true, false, true);
                        }
                        break;
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static void UnloadMap(VnXPlayer playerClass, string mapName)
        {
            _RootCore_.VenoX.TriggerClientEvent(playerClass, "Sync:UnloadMap", mapName);
        }

        [Command("loadmap")]
        public static void LoadMapCmd(VnXPlayer playerClass, string map)
        {
            LoadMap(playerClass, map);
        }
        [Command("unloadmap")]
        public static void UnloadMapCmd(VnXPlayer playerClass, string map)
        {
            UnloadMap(playerClass, map);
        }
    }
}
