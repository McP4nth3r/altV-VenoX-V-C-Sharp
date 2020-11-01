using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_.Sync
{
    public class Sync
    {
        //Settings
        public static int UpdateInterval = 1; // Sync Update in Seconds.
        public static int RenderDistance = 1000; // Distance to a Obj to Create.

        public static List<BlipModel> BlipList = new List<BlipModel>();
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static List<NPCModel> NPCList = new List<NPCModel>();
        public static List<MarkerModel> MarkerList = new List<MarkerModel>();
        public static List<ObjectModel> ObjectList = new List<ObjectModel>();
        public static List<ColShapeModel> ColShapeList = new List<ColShapeModel>();
        public static DateTime NextSyncTick = DateTime.Now;

        //BlipClass Sync
        public static void LoadBlips(VnXPlayer playerClass)
        {
            try
            {
                //List<BlipModel> AlleBlips = new List<BlipModel>();
                foreach (BlipModel blip in BlipList.ToList())
                {
                    if (blip.VisibleOnlyFor == playerClass || blip.VisibleOnlyFor == null)
                    {
                        //AlleBlips.Add(blip);
                        Alt.Server.TriggerClientEvent(playerClass, "BlipClass:CreateBlip", blip.ID, blip.Name, blip.posX, blip.posY, blip.posZ, blip.Sprite, blip.Color, blip.ShortRange);
                    }
                }
                //Alt.Server.TriggerClientEvent(playerClass, "BlipClass:CreateBlip", JsonConvert.SerializeObject(AlleBlips.ToList(), Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch { }
        }


        private static void SyncObjects(VnXPlayer playerClass)
        {
            try
            {
                Alt.Server.TriggerClientEvent(playerClass, "Sync:DestroyObjs");
                foreach (ObjectModel obj in ObjectList.ToList())
                {
                    if (playerClass.Position.Distance(obj.Position) <= RenderDistance && obj.Dimension == playerClass.Dimension)
                    {
                        if (obj.VisibleOnlyFor == playerClass || obj.VisibleOnlyFor == null)
                        {
                            Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadObjs", obj.Parent, obj.Hash, obj.Position, obj.Rotation, obj.HashNeeded);
                        }
                    }
                }
            }
            catch { }
        }

        // TextLabel Sync
        private static void SyncTextLabels(VnXPlayer playerClass)
        {
            try
            {
                Alt.Server.TriggerClientEvent(playerClass, "Sync:RemoveLabels");
                foreach (LabelModel labels in LabelList.ToList())
                {
                    if (playerClass.Position.Distance(new Vector3(labels.PosX, labels.PosY, labels.PosZ)) <= RenderDistance && labels.Dimension == playerClass.Dimension)
                    {
                        if (labels.VisibleOnlyFor == null || labels.VisibleOnlyFor == playerClass)
                        {
                            Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, labels.Text, labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                        }
                    }
                }
            }
            catch { }
        }

        // Marker Sync
        private static void SyncMarker(VnXPlayer playerClass)
        {
            try
            {
                Alt.Server.TriggerClientEvent(playerClass, "Sync:RemoveMarkers");
                foreach (MarkerModel marker in MarkerList.ToList())
                {
                    if (playerClass.Position.Distance(marker.Position) <= RenderDistance && marker.Dimension == playerClass.Dimension)
                    {
                        if (marker.VisibleOnlyFor == null || marker.VisibleOnlyFor == playerClass)
                        {
                            Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMarkers", marker.ID, marker.Type, marker.Position.X, marker.Position.Y, marker.Position.Z, marker.Scale.X, marker.Scale.Y, marker.Scale.Z, marker.Color[0], marker.Color[1], marker.Color[2], marker.Color[3]);
                        }
                    }
                }
            }
            catch { }
        }
        public static void LoadAllNPCs(VnXPlayer playerClass)
        {
            try
            {
                foreach (NPCModel npcClass in NPCList.ToList())
                {
                    Alt.Server.TriggerClientEvent(playerClass, "NPC:Create", npcClass.Name, npcClass.Position, npcClass.Rotation.Z);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnSyncTick()
        {
            try
            {
                if (NextSyncTick <= DateTime.Now)
                {
                    foreach (VnXPlayer playerClass in VenoX.GetAllPlayers().ToList())
                    {
                        SyncTextLabels(playerClass);
                        SyncMarker(playerClass);
                        SyncObjects(playerClass);
                    }
                    NextSyncTick = DateTime.Now.AddSeconds(UpdateInterval);
                }
            }
            catch { }
        }
    }
}
