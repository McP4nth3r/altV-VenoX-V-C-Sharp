using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using Newtonsoft.Json;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;

namespace VenoX.Core._Gamemodes_.Reallife.anzeigen.Inventar
{
    public class Main : IScript
    {
        public static void LoadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in Inventory.DatabaseItems.ToList())
                {
                    if (items.Uid == player.CharacterId)
                    {
                        player.Inventory.Items.Add(items);
                    }
                }
                player.Inventory.Update();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void UnloadPlayerItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel items in Inventory.DatabaseItems.ToList())
                {
                    if (items.Uid == player.CharacterId)
                    {
                        player.Inventory.Items.Add(items);
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static void RemoveAllItems(VnXPlayer player)
        {
            try
            {
                UnloadPlayerItems(player);
                _RootCore_.VenoX.TriggerClientEvent(player, "Inventory:RemoveAll");
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        public static List<ItemModel> GetPlayerInventory(VnXPlayer player)
        {
            try
            {
                return player.Inventory.Items;
            }
            catch { return new List<ItemModel>(); }
        }
        public static void OnPlayerDisconnect(VnXPlayer player, string type, string reason) { try { UnloadPlayerItems(player); } catch(Exception ex){ExceptionHandling.CatchExceptions(ex);} }
        public static void OnPlayerConnect(VnXPlayer player) { try { LoadPlayerItems(player); } catch(Exception ex){ExceptionHandling.CatchExceptions(ex);} }

        [VenoXRemoteEvent("Inventory:Use")]
        public static void OnInventoryUseButtonClicked(VnXPlayer player, string clickedHash)
        {
            try
            {
                ItemModel item = player.Inventory.Items.ToList().FirstOrDefault(x => x.Uid == player.Id && (x.Hash + ".png") == clickedHash);
                if (item is not null)
                    UseItem(player, item);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void UseItem(VnXPlayer player, ItemModel item)
        {
            try
            {
                switch (item.Hash)
                {
                    case Constants.ItemHashTankstellensnack:
                        if ((player.Reallife.Hunger + 10) > 100) { player.SendTranslatedChatMessage("You're full."); return; }
                        player.Reallife.Hunger += 10;
                        item.Amount -= 1;
                        break;
                    case Constants.ItemHashBenzinkannister:
                        if (!player.IsInVehicle)
                        {
                            Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Info, "You are not in any vehicle!");
                            return;
                        }
                        VehicleModel vehicleClass = (VehicleModel)player.Vehicle;
                        if ((vehicleClass.Gas + 20) > 100)
                        {
                            Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Info, "You don't have to refuel yet.");
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
                _RootCore_.VenoX.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
