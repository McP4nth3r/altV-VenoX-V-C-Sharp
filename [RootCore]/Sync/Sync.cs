using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_.Sync
{
    public class Sync
    {
        //Settings
        public static int UpdateInterval = 10000; // Sync Update in MS.
        public static int EntityUpdateInterval = 5; // Sync Update in Seconds.
        public static int RenderDistance = 1500; // Distance to a Obj to Create.
        public static int EntityDistance = 300; // Distance to a Obj to Create.

        public static List<BlipModel> BlipList = new List<BlipModel>();
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static List<NPCModel> NPCList = new List<NPCModel>();
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
                        VenoX.TriggerClientEvent(playerClass, "BlipClass:CreateBlip", blip.ID, blip.Name, blip.posX, blip.posY, blip.posZ, blip.Sprite, blip.Color, blip.ShortRange);
                }
            }
            catch { }
        }

        private static void SyncNearbyDroppedItems(VnXPlayer player)
        {
            foreach (ItemModel items in _Globals_.Inventory.Inventory.DatabaseItems.ToList())
            {
                if (items.UID == -1 && items.Dropped <= DateTime.Now)
                {
                    _Globals_.Inventory.Inventory.DatabaseItems.Remove(items);
                    Database.Database.RemoveItem(items.Id);
                    if (player.Sync.CurrentNearbyItems.Contains(items))
                    {
                        _Globals_.Inventory.Inventory.DeleteDroppedObject(player, items);
                        player.Sync.CurrentNearbyItems.Remove(items);
                    }
                }
                if (player.Position.Distance(items.Position) < RenderDistance && items.UID == -1)
                {
                    if (!player.Sync.CurrentNearbyItems.Contains(items))
                    {
                        _Globals_.Inventory.Inventory.CreateDroppedObject(player, items);
                        player.Sync.CurrentNearbyItems.Add(items);
                    }
                }
                else if (player.Sync.CurrentNearbyItems.Contains(items))
                {
                    _Globals_.Inventory.Inventory.DeleteDroppedObject(player, items);
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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        private static void SyncObjects(VnXPlayer playerClass)
        {
            try
            {
                foreach (ObjectModel obj in ObjectList.ToList())
                {
                    if (playerClass.Position.Distance(obj.Position) <= RenderDistance && obj.Dimension == playerClass.Dimension)
                    {
                        if (obj.VisibleOnlyFor == playerClass || obj.VisibleOnlyFor == null)
                        {
                            if (!playerClass.Sync.CurrentObjs.Contains(obj))
                            {
                                playerClass.Sync.CurrentObjs.Add(obj);
                                VenoX.TriggerClientEvent(playerClass, "Sync:LoadObjs", obj.ID, obj.Parent, obj.Hash, obj.Position, obj.Rotation, obj.HashNeeded);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentObjs.Contains(obj))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveObjByID", obj.ID);
                        playerClass.Sync.CurrentObjs.Remove(obj);
                    }
                }
            }
            catch { }
        }

        // TextLabel Sync
        private static async void SyncTextLabels(VnXPlayer playerClass)
        {
            try
            {
                foreach (LabelModel labels in LabelList.ToList())
                {
                    if (playerClass.Position.Distance(new Vector3(labels.PosX, labels.PosY, labels.PosZ)) <= RenderDistance && labels.Dimension == playerClass.Dimension)
                    {
                        if (labels.VisibleOnlyFor == null || labels.VisibleOnlyFor == playerClass)
                        {
                            if (!playerClass.Sync.CurrentLabels.Contains(labels))
                            {
                                // Normal Sync.
                                if (!labels.Translate && !labels.IsHouseLabel) VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, labels.Text, labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                // House Sync.
                                else if (labels.IsHouseLabel) VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, await _Gamemodes_.Reallife.house.House.GetHouseLabelText(null, (_Language_.Main.Languages)playerClass.Language, labels.HouseLabelId), labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                // Normal Translated Sync.
                                else VenoX.TriggerClientEvent(playerClass, "Sync:LoadTextLabels", labels.ID, await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)playerClass.Language, labels.Text), labels.PosX, labels.PosY, labels.PosZ, labels.Font, labels.ColorR, labels.ColorG, labels.ColorB, labels.ColorA, labels.Dimension, labels.Range);
                                playerClass.Sync.CurrentLabels.Add(labels);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentLabels.Contains(labels))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveLabelByID", labels.ID);
                        playerClass.Sync.CurrentLabels.Remove(labels);
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
                foreach (MarkerModel marker in MarkerList.ToList())
                {
                    if (playerClass.Position.Distance(marker.Position) <= RenderDistance && marker.Dimension == playerClass.Dimension)
                    {
                        if (marker.VisibleOnlyFor == null || marker.VisibleOnlyFor == playerClass)
                        {
                            if (!playerClass.Sync.CurrentMarker.Contains(marker))
                            {
                                playerClass.Sync.CurrentMarker.Add(marker);
                                VenoX.TriggerClientEvent(playerClass, "Sync:LoadMarkers", marker.ID, marker.Type, marker.Position.X, marker.Position.Y, marker.Position.Z, marker.Scale.X, marker.Scale.Y, marker.Scale.Z, marker.Color[0], marker.Color[1], marker.Color[2], marker.Color[3]);
                            }
                        }
                    }
                    else if (playerClass.Sync.CurrentMarker.Contains(marker))
                    {
                        VenoX.TriggerClientEvent(playerClass, "Sync:RemoveMarkerByID", marker.ID);
                        playerClass.Sync.CurrentMarker.Remove(marker);
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
                    VenoX.TriggerClientEvent(playerClass, "NPC:Create", npcClass.Name, npcClass.Position, npcClass.Rotation.Z);
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
                        if (playerClass is null || !playerClass.Exists || playerClass.Gamemode == (int)_Preload_.Preload.Gamemodes.SevenTowers) continue;
                        SyncTextLabels(playerClass);
                        SyncMarker(playerClass);
                        SyncObjects(playerClass);
                        SyncNearbyDroppedItems(playerClass);
                        if (NextEntityUpdateTick <= DateTime.Now)
                        {
                            SyncNearbyPlayers(playerClass);
                            NextEntityUpdateTick = DateTime.Now.AddMinutes(EntityUpdateInterval);
                        }
                    }
                    NextSyncTick = DateTime.Now.AddMilliseconds(UpdateInterval);
                }

            }
            catch { }
        }

        public static void ForceSyncUpdate()
        {
            try
            {
                NextSyncTick = DateTime.Now;
            }
            catch { }
        }
        public static void ForceClientSyncUpdate(VnXPlayer player)
        {
            try
            {
                SyncTextLabels(player);
                SyncMarker(player);
                SyncObjects(player);
            }
            catch { }
        }
    }
}
