﻿using AltV.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._RootCore_.Sync
{
    public class Sync
    {
        //Settings
        public static int UpdateInterval = 5; // Sync Update in Seconds.

        public static List<BlipModel> BlipList = new List<BlipModel>();
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static List<NPCModel> NPCList = new List<NPCModel>();
        public static List<MarkerModel> MarkerList = new List<MarkerModel>();
        public static List<ColShapeModel> ColShapeList = new List<ColShapeModel>();
        public static DateTime NextSyncTick = DateTime.Now;

        //BlipClass Sync
        public static void LoadBlips(Client playerClass)
        {
            List<BlipModel> AlleBlips = new List<BlipModel>();

            foreach (BlipModel blip in BlipList)
            {
                if (blip.VisibleOnlyFor == playerClass || blip.VisibleOnlyFor == null)
                {
                    AlleBlips.Add(blip);
                }
            }
            Alt.Server.TriggerClientEvent(playerClass, "BlipClass:CreateBlip", JsonConvert.SerializeObject(AlleBlips));
        }


        // TextLabel Sync
        private static void SyncTextLabels(Client playerClass)
        {
            Alt.Server.TriggerClientEvent(playerClass, "Sync:RemoveLabels");
            foreach (LabelModel labels in LabelList)
            {
                if (playerClass.Position.Distance(new Vector3(labels.PosX, labels.PosY, labels.PosZ)) <= 200 && labels.Dimension == playerClass.Dimension)
                {
                    if (labels.VisibleOnlyFor == null || labels.VisibleOnlyFor == playerClass)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, labels.Text, labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                    }
                }
            }
        }

        // Marker Sync
        private static void SyncMarker(Client playerClass)
        {
            Alt.Server.TriggerClientEvent(playerClass, "Sync:RemoveMarkers");
            foreach (MarkerModel marker in MarkerList)
            {
                if (playerClass.Position.Distance(marker.Position) <= 200 && marker.Dimension == playerClass.Dimension)
                {
                    if (marker.VisibleOnlyFor == null || marker.VisibleOnlyFor == playerClass)
                    {
                        Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadMarkers", marker.ID, marker.Type, marker.Position.X, marker.Position.Y, marker.Position.Z, marker.Scale.X, marker.Scale.Y, marker.Scale.Z, marker.Color[0], marker.Color[1], marker.Color[2], marker.Color[3]);
                    }
                }
            }
        }
        public static void LoadAllNPCs(Client playerClass)
        {
            try
            {
                foreach (NPCModel npcClass in NPCList)
                {
                    Alt.Server.TriggerClientEvent(playerClass, "NPC:Create", npcClass.Name, npcClass.Position, npcClass.Rotation.Z);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("LoadAllNPCs", ex); }
        }

        public static void OnSyncTick()
        {
            try
            {
                if (NextSyncTick <= DateTime.Now)
                {
                    foreach (Client playerClass in Alt.GetAllPlayers())
                    {
                        SyncTextLabels(playerClass);
                        SyncMarker(playerClass);
                    }
                    NextSyncTick = DateTime.Now.AddSeconds(UpdateInterval);
                }
            }
            catch { }
        }
    }
}
