using AltV.Net;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using VenoXV.Core;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.anzeigen.Inventar
{
    public class Main : IScript
    {

        public static List<ItemModel> CurrentOnlineItemList = new List<ItemModel>(); // Alle Items von Spieler die grade Online sind.

        public static List<ItemModel> CurrentOfflineItemList = new List<ItemModel>(); // Alle Items von Spieler die grade Offline sind.


        public static void LoadPlayerItems(IPlayer player)
        {
            try
            {
                foreach (ItemModel items in CurrentOfflineItemList)
                {
                    if (items.ownerIdentifier == player?.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID))
                    {
                        CurrentOnlineItemList.Add(items);
                    }
                }
                List<InventoryModel> inventory = GetPlayerInventory(player);
                player?.Emit("Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch { }
        }

        public static void UnloadPlayerItems(IPlayer player)
        {
            try
            {
                foreach (ItemModel items in CurrentOnlineItemList)
                {
                    if (items.ownerIdentifier == player?.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID))
                    {
                        CurrentOnlineItemList.Remove(items);
                    }
                }
            }
            catch { }
        }
        public static void RemoveAllItems(IPlayer player)
        {
            try
            {
                UnloadPlayerItems(player);
                player.Emit("Inventory:RemoveAll");
            }
            catch { }
        }
        public static List<InventoryModel> GetPlayerInventory(IPlayer player)
        {
            try
            {
                List<InventoryModel> inventory = new List<InventoryModel>();
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                foreach (ItemModel item in CurrentOnlineItemList)
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
        public static void OnPlayerDisconnect(IPlayer player, string type, string reason) { UnloadPlayerItems(player); }
        public static void OnPlayerConnect(IPlayer player) { LoadPlayerItems(player); }
    }
}
