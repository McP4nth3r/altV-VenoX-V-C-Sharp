using AltV.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.anzeigen.Inventar
{
    public class Main : IScript
    {
        public static List<ItemModel> CurrentOnlineItemList = new List<ItemModel>(); // Alle Items von Spieler die grade Online sind.
        public static List<ItemModel> CurrentOfflineItemList = new List<ItemModel>(); // Alle Items von Spieler die grade Offline sind.
        public static void LoadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in CurrentOfflineItemList.ToList())
                {
                    if (items.ownerIdentifier == player.UID)
                    {
                        CurrentOfflineItemList.Remove(items);
                        CurrentOnlineItemList.Add(items);
                    }
                }
                List<InventoryModel> inventory = GetPlayerInventory(player);
                Alt.Server.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch { }
        }
        public static void UnloadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in CurrentOnlineItemList.ToList())
                {
                    if (items.ownerIdentifier == player.UID)
                    {
                        CurrentOnlineItemList.Remove(items);
                        CurrentOfflineItemList.Add(items);
                    }
                }
            }
            catch { }
        }
        public static void RemoveAllItems(VnXPlayer player)
        {
            try
            {
                UnloadPlayerItems(player);
                Alt.Server.TriggerClientEvent(player, "Inventory:RemoveAll");
            }
            catch { }
        }
        public static List<InventoryModel> GetPlayerInventory(VnXPlayer player)
        {
            try
            {
                List<InventoryModel> inventory = new List<InventoryModel>();
                int playerId = player.UID;
                foreach (ItemModel item in CurrentOnlineItemList.ToList())
                {
                    if (item.ownerIdentifier == playerId)
                    {
                        InventoryModel inventoryItem = new InventoryModel
                        {
                            id = item.id,
                            hash = item.hash,
                            amount = item.amount,
                            ITEM_ART = item.ITEM_ART
                        };
                        inventory.Add(inventoryItem);
                    }
                }
                return inventory;
            }
            catch { return new List<InventoryModel>(); }
        }
        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason) { try { UnloadPlayerItems(player); } catch { } }
        public static void OnPlayerConnect(VnXPlayer player) { try { LoadPlayerItems(player); } catch { } }

        [ClientEvent("Inventory:Use")]
        public static void OnInventoryUseButtonClicked(VnXPlayer player, string ClickedHash)
        {
            try
            {
                int playerId = player.UID;
                foreach (ItemModel item in CurrentOnlineItemList.ToList())
                {
                    if (item.ownerIdentifier == playerId)
                    {
                        if (item.hash == ClickedHash)
                        {
                            UseItem(player, item);
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnInventoryButtonUse", ex); }
        }

        public static void UseItem(VnXPlayer player, ItemModel item)
        {
            try
            {
                switch (item.hash)
                {
                    case Constants.ITEM_HASH_TANKSTELLENSNACK:
                        player.Reallife.Hunger += 10;
                        item.amount -= 1;
                        break;
                    case Constants.ITEM_HASH_BENZINKANNISTER:
                        break;
                    case Constants.ITEM_HASH_KOKS:
                        break;
                    default:
                        player.SendTranslatedChatMessage("Dein ItemHash : " + item.hash);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("UseItem", ex); }
        }
    }
}
