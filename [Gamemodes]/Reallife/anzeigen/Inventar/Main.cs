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
        public static void LoadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in _Globals_.Inventory.Inventory.DatabaseItems.ToList())
                {
                    if (items.UID == player.UID)
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
                foreach (ItemModel items in _Globals_.Inventory.Inventory.DatabaseItems.ToList())
                {
                    if (items.UID == player.UID)
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
        public static void OnInventoryUseButtonClicked(VnXPlayer player, string ClickedHash)
        {
            try
            {
                ItemModel item = player.Inventory.Items.ToList().FirstOrDefault(x => x.UID == player.Id && (x.Hash + ".png") == ClickedHash);
                if (item is not null)
                    UseItem(player, item);
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
