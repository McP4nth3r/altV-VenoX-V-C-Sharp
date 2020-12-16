using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VenoXV._Maps_.Model;
using VenoXV._Maps_.Models;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Maps_
{
    public class Main : IScript
    {
        public const string LSPD_MAP = "LSPD";
        private static readonly List<MapModel> LSPDMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + LSPD_MAP + ".json"));

        public const string NOOBSPAWN_MAP = "NOOBSPAWN";
        private static readonly List<MapModel> NOOBSPAWNMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + NOOBSPAWN_MAP + ".json"));

        public const string STADTHALLE_MAP = "STADTHALLE";
        private static readonly List<MapModel> STADTHALLEMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + STADTHALLE_MAP + ".json"));

        public const string WUERFELPARK_MAP = "WUERFELPARK";
        private static readonly List<MapModel> WUERFELPARKMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + WUERFELPARK_MAP + ".json"));

        public const string SEVENTOWERS_MAP = "SEVENTOWERS";
        private static readonly List<MapModel> SEVENTOWERSMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + SEVENTOWERS_MAP + ".json"));

        public const string DERBY1_MAP = "DERBY1";
        private static readonly List<DurtyMapModel> DERBY1MAP = JsonConvert.DeserializeObject<List<DurtyMapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + DERBY1_MAP + ".json"));

        private static readonly int ROT_ORDER_NORMAL = 2;
        public static void LoadMap(VnXPlayer playerClass, string MapName)
        {
            try
            {
                int i = 0;
                switch (MapName)
                {
                    case LSPD_MAP:
                        foreach (MapModel mapClass in LSPDMAP)
                        {
                            i++;
                            VenoX.TriggerPreloadEvent(playerClass, "Loading Map[LSPD][" + i + "/" + LSPDMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position, ROT_ORDER_NORMAL, mapClass.Rotation, true, false);
                        }
                        break;
                    case NOOBSPAWN_MAP:
                        foreach (MapModel mapClass in NOOBSPAWNMAP)
                        {
                            i++;
                            VenoX.TriggerPreloadEvent(playerClass, "Loading Map[Noobspawn][" + i + "/" + NOOBSPAWNMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position, ROT_ORDER_NORMAL, mapClass.Rotation, true, false);
                        }
                        break;
                    case STADTHALLE_MAP:
                        foreach (MapModel mapClass in STADTHALLEMAP)
                        {
                            i++;
                            VenoX.TriggerPreloadEvent(playerClass, "Loading Map[Cityhall][" + i + "/" + STADTHALLEMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position, ROT_ORDER_NORMAL, mapClass.Rotation, true, false);
                        }
                        break;
                    case SEVENTOWERS_MAP:
                        foreach (MapModel mapClass in SEVENTOWERSMAP)
                        {
                            i++;
                            VenoX.TriggerPreloadEvent(playerClass, "Loading Map[SevenTowers][" + i + "/" + SEVENTOWERSMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position, 2, mapClass.Rotation, true, false, true, mapClass.Properties.TextureVariation);
                        }
                        break;
                    case WUERFELPARK_MAP:
                        foreach (MapModel mapClass in WUERFELPARKMAP)
                        {
                            i++;
                            VenoX.TriggerPreloadEvent(playerClass, "Loading Map[Park][" + i + "/" + WUERFELPARKMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position, ROT_ORDER_NORMAL, mapClass.Rotation, true, false, true);
                        }
                        break;
                    case DERBY1_MAP:
                        foreach (DurtyMapModel mapClass in DERBY1MAP)
                        {
                            if (mapClass.Model == 665940918)
                            {
                                i++;
                                VenoX.TriggerPreloadEvent(playerClass, "Loading Map[Derby][" + i + "/" + DERBY1MAP.Count + "]", "Sync:LoadMap", MapName, "v_corp_postbox", mapClass.PositionRotation.Position, 2, mapClass.PositionRotation.Rotation, true, true, true, mapClass.Properties.TextureVariation);
                            }
                            else
                            {
                                i++;
                                VenoX.TriggerPreloadEvent(playerClass, "Loading Map[Derby][" + i + "/" + LSPDMAP.Count + "]", "Sync:LoadMap", MapName, mapClass.Model, mapClass.PositionRotation.Position, 2, mapClass.PositionRotation.Rotation, true, false, true, mapClass.Properties.TextureVariation);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void UnloadMap(VnXPlayer playerClass, string MapName)
        {
            VenoX.TriggerClientEvent(playerClass, "Sync:UnloadMap", MapName);
        }

        [Command("loadmap")]
        public static void LoadMapCMD(VnXPlayer playerClass, string Map)
        {
            LoadMap(playerClass, Map);
        }
        [Command("unloadmap")]
        public static void UnloadMapCMD(VnXPlayer playerClass, string Map)
        {
            UnloadMap(playerClass, Map);
        }
    }
}
