using AltV.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
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
                    if (items.UID == player.UID)
                    {
                        CurrentOfflineItemList.Remove(items);
                        CurrentOnlineItemList.Add(items);
                    }
                }
                List<ItemModel> inventory = GetPlayerInventory(player);
                VenoX.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch { }
        }
        public static void UnloadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in CurrentOnlineItemList.ToList())
                {
                    if (items.UID == player.UID)
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
                VenoX.TriggerClientEvent(player, "Inventory:RemoveAll");
            }
            catch { }
        }
        public static List<ItemModel> GetPlayerInventory(VnXPlayer player)
        {
            try
            {
                List<ItemModel> inventory = new List<ItemModel>();
                int playerId = player.UID;
                foreach (ItemModel item in CurrentOnlineItemList.ToList())
                    if (item.UID == playerId) inventory.Add(item);

                return inventory;
            }
            catch { return new List<ItemModel>(); }
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
                    if (item.UID == playerId)
                    {
                        if ((item.Hash + ".png") == ClickedHash)
                        {
                            UseItem(player, item);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void UseItem(VnXPlayer player, ItemModel item)
        {
            try
            {
                switch (item.Hash)
                {
                    case Constants.ITEM_HASH_TANKSTELLENSNACK:
                        if ((player.Reallife.Hunger + 10) > 100) { player.SendTranslatedChatMessage("Du bist satt."); return; }
                        player.Reallife.Hunger += 10;
                        item.Amount -= 1;
                        break;
                    case Constants.ITEM_HASH_BENZINKANNISTER:
                        if (!player.IsInVehicle)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Du bist in keinem Fahrzeug!");
                            return;
                        }
                        VehicleModel VehicleClass = (VehicleModel)player.Vehicle;
                        if ((VehicleClass.Gas + 20) > 100)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Du musst noch nicht Tanken.");
                            return;
                        }
                        VehicleClass.Gas += 20;
                        item.Amount -= 1;
                        break;
                    case Constants.ITEM_HASH_KOKS:
                        break;
                    default:
                        player.SendTranslatedChatMessage("Dein ItemHash : " + item.Hash);
                        break;
                }
                List<ItemModel> inventory = GetPlayerInventory(player);
                VenoX.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
