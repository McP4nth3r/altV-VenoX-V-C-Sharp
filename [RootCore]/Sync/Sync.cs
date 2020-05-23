using AltV.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_.Sync
{
    public class Sync
    {
        //Settings
        public static int UpdateInterval = 5; // Sync Update in Seconds.

        public static List<BlipModel> BlipList = new List<BlipModel>();
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static DateTime NextSyncTick = DateTime.Now;

        //BlipClass Sync
        public static void LoadBlips(Client playerClass)
        {
            List<BlipModel> AlleBlips = Sync.BlipList;
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
                    Alt.Server.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, labels.Text, labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                }
            }

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
                    }
                    NextSyncTick.AddSeconds(UpdateInterval);
                }
            }
            catch { }
        }
    }
}
