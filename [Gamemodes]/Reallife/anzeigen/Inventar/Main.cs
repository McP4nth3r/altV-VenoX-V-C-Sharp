using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public static void LoadPlayerItems(Client player)
        {
            try
            {
                foreach (ItemModel items in CurrentOfflineItemList)
                {
                    if (items.ownerIdentifier == player?.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID))
                    {
                        CurrentOnlineItemList.Add(items);
                    }
                }
                List<InventoryModel> inventory = GetPlayerInventory(player);
                player?.Emit("Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch { }
        }
        public static void UnloadPlayerItems(Client player)
        {
            try
            {
                foreach (ItemModel items in CurrentOnlineItemList)
                {
                    if (items.ownerIdentifier == player?.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID))
                    {
                        CurrentOnlineItemList.Remove(items);
                    }
                }
            }
            catch { }
        }
        public static void RemoveAllItems(Client player)
        {
            try
            {
                UnloadPlayerItems(player);
                player.Emit("Inventory:RemoveAll");
            }
            catch { }
        }
        public static List<InventoryModel> GetPlayerInventory(Client player)
        {
            try
            {
                List<InventoryModel> inventory = new List<InventoryModel>();
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
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
        public static void OnPlayerDisconnect(Client player, string type, string reason) { UnloadPlayerItems(player); }
        public static void OnPlayerConnect(Client player) { LoadPlayerItems(player); }

        [ClientEvent("Inventory:Use")]
        public static void OnInventoryUseButtonClicked(Client player, string ClickedHash)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                foreach (ItemModel item in CurrentOnlineItemList)
                {
                    if (item.ownerIdentifier == playerId)
                    {
                        if (item.hash == ClickedHash)
                        {
                            UseItem(player, ClickedHash);
                        }
                    }
                }
            }
            catch { }
        }


        public static void UseItem(Client player, string ItemHash)
        {
            switch (ItemHash)
            {
                case Constants.ITEM_HASH_BENZINKANNISTER:
                    break;
                case Constants.ITEM_HASH_KOKS:
                    break;
                default:
                    player.SendTranslatedChatMessage("Dein ItemHash : " + ItemHash);
                    break;
            }
        }
    }
}
