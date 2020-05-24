using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using VenoXV._Maps_.Model;
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
        //private static readonly List<MapModel> WUERFELPARKMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + WUERFELPARK_MAP + ".json"));        

        public const string SEVENTOWERS_MAP = "SEVENTOWERS";
        private static readonly List<MapModel> SEVENTOWERSMAP = JsonConvert.DeserializeObject<List<MapModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Maps/" + SEVENTOWERS_MAP + ".json"));

        public static void LoadMap(Client playerClass, string MapName)
        {
            switch (MapName)
            {
                case LSPD_MAP:
                    foreach (MapModel mapClass in LSPDMAP)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position.X, mapClass.Position.Y, mapClass.Position.Z, mapClass.Rotation.X, mapClass.Rotation.Y, mapClass.Rotation.Z, true);
                    }
                    break;
                case NOOBSPAWN_MAP:
                    foreach (MapModel mapClass in NOOBSPAWNMAP)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position.X, mapClass.Position.Y, mapClass.Position.Z, mapClass.Rotation.X, mapClass.Rotation.Y, mapClass.Rotation.Z, true);
                    }
                    break;
                case STADTHALLE_MAP:
                    foreach (MapModel mapClass in STADTHALLEMAP)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position.X, mapClass.Position.Y, mapClass.Position.Z, mapClass.Rotation.X, mapClass.Rotation.Y, mapClass.Rotation.Z, true);
                    }
                    break;
                case SEVENTOWERS_MAP:
                    foreach (MapModel mapClass in SEVENTOWERSMAP)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position.X, mapClass.Position.Y, mapClass.Position.Z, mapClass.Rotation.X, mapClass.Rotation.Y, mapClass.Rotation.Z, true);
                    }
                    break;
                case WUERFELPARK_MAP:
                    /*foreach (MapModel mapClass in WUERFELPARKMAP)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMap", MapName, mapClass.Hash, mapClass.Position.X, mapClass.Position.Y, mapClass.Position.Z);
                    }*/
                    break;
            }
        }
        public static void UnloadMap(Client playerClass, string MapName)
        {
            Alt.Server.TriggerClientEvent(playerClass, "Sync:UnloadMap", MapName);
        }

        [Command("loadmap")]
        public static void LoadMapCMD(Client playerClass, string Map)
        {
            LoadMap(playerClass, Map);
        }
        [Command("unloadmap")]
        public static void UnloadMapCMD(Client playerClass, string Map)
        {
            UnloadMap(playerClass, Map);
        }
    }
}
