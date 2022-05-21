using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using VenoX.Core._Gamemodes_.Reallife.house;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Language_;
using VenoX.Core._Preload_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;
using VehicleModel = VenoX.Core._RootCore_.Models.VehicleModel;

namespace VenoX.Core._RootCore_.Sync
{
    public class Sync
    {
        //Settings
        public static int UpdateInterval = 10000; // Sync Update in MS.
        public static int EntityUpdateInterval = 10; // Sync Update in Seconds.
        public static int RenderDistance = 1500; // Distance to a Obj to Create.
        public static int EntityDistance = 300; // Distance to a Obj to Create.
        private static int _currentHour = 15; // Current Hour for DateTime Sync.


        public static List<BlipModel> BlipList = new List<BlipModel>();
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static List<NpcModel> NpcList = new List<NpcModel>();
        public static List<MarkerModel> MarkerList = new List<MarkerModel>();
        public static List<ObjectModel> ObjectList = new List<ObjectModel>();
        public static List<ColShapeModel> ColShapeList = new List<ColShapeModel>();
        public static DateTime NextSyncTick = DateTime.Now;
        public static DateTime NextEntityUpdateTick = DateTime.Now;

        //BlipClass Sync
        public static void LoadBlips(VnXPlayer playerClass)
        {
            try
            {
                foreach (BlipModel blip in BlipList.ToList())
                {
                    if (blip.VisibleOnlyFor == playerClass || blip.VisibleOnlyFor == null)
                        VenoX.TriggerClientEvent(playerClass, "BlipClass:CreateBlip", blip.Id, blip.Name, blip.PosX, blip.PosY, blip.PosZ, blip.Sprite, blip.Color, blip.ShortRange);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        private static void SyncNearbyDroppedItems(VnXPlayer player)
        {
            foreach (ItemModel items in Inventory.DatabaseItems.ToList())
            {
                if (items.Uid == -1 && items.Dropped <= DateTime.Now)
                {
                    Inventory.DatabaseItems.Remove(items);
                    Database.Database.RemoveItem(items.Id);
                    if (player.Sync.CurrentNearbyItems.Contains(items))
                    {
                        Inventory.DeleteDroppedObject(player, items);
                        player.Sync.CurrentNearbyItems.Remove(items);
                    }
                }
                if (player.Position.Distance(items.Position) < RenderDistance && items.Uid == -1)
                {
                    if (!player.Sync.CurrentNearbyItems.Contains(items))
                    {
                        Inventory.CreateDroppedObject(player, items);
                        player.Sync.CurrentNearbyItems.Add(items);
                    }
                }
                else if (player.Sync.CurrentNearbyItems.Contains(items))
                {
                    Inventory.DeleteDroppedObject(player, items);
                    player.Sync.CurrentNearbyItems.Remove(items);
                }
            }
        }

        private static void SyncNearbyPlayers(VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    if (player is null || !player.Exists || players is null || !players.Exists) continue;

                    if (player.Position.Distance(players.Position) < EntityDistance && player.Dimension == players.Dimension && player != players)
                        player.NearbyPlayers.Add(players);

                    else player.NearbyPlayers.Remove(players);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        private static void SyncObjects(VnXPlayer playerClass)
        {
            try
            {
                foreach (ObjectModel obj in ObjectList.ToList())
                {
                    if (playerClass.Position.Distance(obj.Position) <= RenderDistance && (obj.Dimension == playerClass.Dimension || obj.Dimension == Dimension.GlobalDimension))
                    {
                        if (obj.VisibleOnlyFor == playerClass || obj.VisibleOnlyFor == null)
                        {
                            if (!playerClass.Sync.CurrentObjs.Contains(obj))
                            {
                                playerClass.Sync.CurrentObjs.Add(obj);
                                VenoX.TriggerClientEvent(playerClass, "Sync:LoadObjs", obj.Id, obj.Parent, obj.Hash, obj.Position, obj.Rotation, obj.HashNeeded);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentObjs.Contains(obj))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveObjByID", obj.Id);
                        playerClass.Sync.CurrentObjs.Remove(obj);
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        // TextLabel Sync
        private static async void SyncTextLabels(VnXPlayer playerClass)
        {
            try
            {
                foreach (LabelModel labels in LabelList.ToList())
                {
                    if (playerClass.Position.Distance(new Vector3(labels.PosX, labels.PosY, labels.PosZ)) <= RenderDistance && (labels.Dimension == playerClass.Dimension || labels.Dimension == Dimension.GlobalDimension))
                    {
                        if (labels.VisibleOnlyFor == null || labels.VisibleOnlyFor == playerClass)
                        {
                            if (!playerClass.Sync.CurrentLabels.Contains(labels))
                            {
                                // Normal Sync.
                                if (!labels.Translate && !labels.IsHouseLabel) VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.Id, labels.Text, labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                // House Sync.
                                else if (labels.IsHouseLabel) VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.Id, await House.GetHouseLabelText(null, (Constants.Languages)playerClass.Language, labels.HouseLabelId), labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                // Normal Translated Sync.
                                else VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.Id, await Main.GetTranslatedTextAsync((Constants.Languages)playerClass.Language, labels.Text), labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                playerClass.Sync.CurrentLabels.Add(labels);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentLabels.Contains(labels))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveLabelByID", labels.Id);
                        playerClass.Sync.CurrentLabels.Remove(labels);
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        // Marker Sync
        private static void SyncMarker(VnXPlayer playerClass)
        {
            try
            {
                foreach (MarkerModel marker in MarkerList.ToList())
                {
                    if (playerClass.Position.Distance(marker.Position) <= RenderDistance && (marker.Dimension == playerClass.Dimension || marker.Dimension == Dimension.GlobalDimension))
                    {
                        if (marker.VisibleOnlyFor == null || marker.VisibleOnlyFor == playerClass)
                        {
                            if (!playerClass.Sync.CurrentMarker.Contains(marker))
                            {
                                playerClass.Sync.CurrentMarker.Add(marker);
                                VenoX.TriggerClientEvent(playerClass, "Sync:LoadMarkers", marker.Id, marker.Type, marker.Position.X, marker.Position.Y, marker.Position.Z, marker.Scale.X, marker.Scale.Y, marker.Scale.Z, marker.Color[0], marker.Color[1], marker.Color[2], marker.Color[3]);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentMarker.Contains(marker))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveMarkerByID", marker.Id);
                        playerClass.Sync.CurrentMarker.Remove(marker);
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void LoadAllNpCs(VnXPlayer playerClass)
        {
            try
            {
                foreach (NpcModel npcClass in NpcList.ToList())
                    VenoX.TriggerClientEvent(playerClass, "NPC:Create", npcClass.Name, npcClass.Position, npcClass.Rotation.Z);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void OnSyncTick()
        {
            try
            {
                if (NextSyncTick <= DateTime.Now)
                {
                    foreach (VnXPlayer playerClass in VenoX.GetAllPlayers().ToList())
                    {
                        if (playerClass is null || !playerClass.Exists || playerClass.Gamemode == (int)Preload.Gamemodes.SevenTowers) continue;
                        SyncTextLabels(playerClass);
                        SyncMarker(playerClass);
                        SyncObjects(playerClass);
                        SyncNearbyDroppedItems(playerClass);
                        SyncNearbyPlayers(playerClass);

                        /*if (NextEntityUpdateTick <= DateTime.Now)
                        {
                            SyncNearbyPlayers(playerClass);
                            NextEntityUpdateTick = DateTime.Now.AddSeconds(EntityUpdateInterval);
                        }*/
                    }
                    NextSyncTick = DateTime.Now.AddMilliseconds(UpdateInterval);
                }

            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void ForceSyncUpdate()
        {
            try
            {
                NextSyncTick = DateTime.Now;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void ForceClientSyncUpdate(VnXPlayer player)
        {
            try
            {
                SyncTextLabels(player);
                SyncMarker(player);
                SyncObjects(player);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void OnMinuteSpend()
        {
            if (_currentHour < 23) _currentHour++;
            else _currentHour = 0;
        }



        /* Weather & DateTime Sync */
        public static int WeatherCounter;
        public static int WeatherCurrent; // Current Weather
        public static int GetRandomWeather(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }
        public static void SyncWeather(VnXPlayer player)
        {
            try
            {
                switch (WeatherCounter)
                {
                    case >= 60:
                    {
                        int weather = 0;
                        if (WeatherCurrent == 9)
                        {
                            weather = 0;
                        }
                        else
                        {
                            //weather = 13;
                            weather = GetRandomWeather(0, 2);
                            switch (weather)
                            {
                                case 0:
                                    weather = 0;
                                    break;
                                case 1:
                                    weather = 8;
                                    break;
                                case 2:
                                    weather = 9;
                                    break;
                                case 3:
                                    weather = 3;
                                    break;
                            }
                        }
                        WeatherCounter = 0;
                        WeatherCurrent = weather;

                        player.SetWeather((WeatherType)WeatherCurrent);
                        break;
                    }
                    case < 60:
                        player.SetWeather((WeatherType)WeatherCurrent);
                        WeatherCounter += 1;
                        break;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void SyncDateTime(VnXPlayer player)
        {
            try
            {
                DateTime currentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _currentHour, 0, 0);
                player.SetDateTime(currentDateTime);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        // Assets for better stable results : 
        public static void DeleteVehicleThreadSafe()
        {
            try
            {
                //int i = 0;
                foreach (VehicleModel vehClass in Enumerable.ToList<VehicleModel>(_Globals_.Initialize.AllVehicles))
                {
                    if (Enumerable.ToList<VehicleModel>(_Globals_.Initialize.AllVehicles).Contains(vehClass) && vehClass.MarkedForDelete)
                    {
                        //Debug.OutputDebugString("DeleteVehicleThreadSafe : " + i++);
                        _Globals_.Initialize.AllVehicles.Remove(vehClass);
                        vehClass.Remove();
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static void DeleteColShapesThreadSafe()
        {
            try
            {
                //int i = 0;
                foreach (ColShapeModel colShape in ColShapeList.ToList())
                {
                    if (ColShapeList.Contains(colShape) && colShape.MarkedForDelete)
                    {
                        //Debug.OutputDebugString("DeleteColShapesThreadSafe : " + i++);
                        ColShapeList.Remove(colShape);
                        Alt.RemoveColShape(colShape);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

    }
}
