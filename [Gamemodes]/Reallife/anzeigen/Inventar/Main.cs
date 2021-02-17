using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using Newtonsoft.Json;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Inventory = VenoXV._Globals_.Inventory.Inventory;

namespace VenoXV._Gamemodes_.Reallife.anzeigen.Inventar
{
    public class Main : IScript
    {
        public static void LoadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in Inventory.DatabaseItems.ToList())
                {
                    if (items.Uid == player.UID)
                    {
                        player.Inventory.Items.Add(items);
                    }
                }
                player.Inventory.Update();
            }
            catch { }
        }
        public static void UnloadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in Inventory.DatabaseItems.ToList())
                {
                    if (items.Uid == player.UID)
                    {
                        player.Inventory.Items.Add(items);
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
                return player.Inventory.Items;
            }
            catch { return new List<ItemModel>(); }
        }
        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason) { try { UnloadPlayerItems(player); } catch { } }
        public static void OnPlayerConnect(VnXPlayer player) { try { LoadPlayerItems(player); } catch { } }

        [VenoXRemoteEvent("Inventory:Use")]
        public static void OnInventoryUseButtonClicked(VnXPlayer player, string clickedHash)
        {
            try
            {
                ItemModel item = player.Inventory.Items.ToList().FirstOrDefault(x => x.Uid == player.Id && (x.Hash + ".png") == clickedHash);
                if (item is not null)
                    UseItem(player, item);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void UseItem(VnXPlayer player, ItemModel item)
        {
            try
            {
                switch (item.Hash)
                {
                    case Constants.ItemHashTankstellensnack:
                        if ((player.Reallife.Hunger + 10) > 100) { player.SendTranslatedChatMessage("Du bist satt."); return; }
                        player.Reallife.Hunger += 10;
                        item.Amount -= 1;
                        break;
                    case Constants.ItemHashBenzinkannister:
                        if (!player.IsInVehicle)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Du bist in keinem Fahrzeug!");
                            return;
                        }
                        VehicleModel vehicleClass = (VehicleModel)player.Vehicle;
                        if ((vehicleClass.Gas + 20) > 100)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Du musst noch nicht Tanken.");
                            return;
                        }
                        vehicleClass.Gas += 20;
                        item.Amount -= 1;
                        break;
                    case Constants.ItemHashKoks:
                        break;
                    default:
                        player.SendTranslatedChatMessage("Dein ItemHash : " + item.Hash);
                        break;
                }
                List<ItemModel> inventory = GetPlayerInventory(player);
                VenoX.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
