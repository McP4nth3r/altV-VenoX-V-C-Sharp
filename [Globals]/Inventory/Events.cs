using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.model;

namespace VenoXV._Globals_.Inventory
{
    public class Events : IScript
    {
        [AsyncClientEvent("Inventory:PickupItem")]
        public static async Task PickUpItem(VnXPlayer player, int id)
        {
            try
            {
                await Task.Run(() =>
                {
                    //Core.Debug.OutputDebugString("Called PickUp Item : " + Id);
                    ItemModel item = Inventory.DatabaseItems.FirstOrDefault(x => x.Id == id);
                    if (item is null || item.Uid > 0 || player is null || !player.Exists) return;
                    ItemModel playerItem = player.Inventory.Items.ToList().FirstOrDefault(x => x.Id == item.Id);
                    if (playerItem is not null) Database.Database.RemoveItem(item.Id);

                    foreach (VnXPlayer nearby in player.NearbyPlayers)
                        Inventory.DeleteDroppedObject(nearby, item);

                    item.Uid = player.UID;
                    item.Position = new Vector3(0, 0, 0);
                    item.Update();
                    Debug.OutputDebugString("Obj : " + id);
                    player.Inventory.GiveItem(item.Hash, item.Type, item.Amount, item.ClothesSlot <= 0, item.Dimension, item.Weight, false, id);

                    //Core.Debug.OutputDebugString("You picked up : " + item.Hash);
                });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [AsyncClientEvent("Inventory:DropItem")]
        public static async Task DropItem(VnXPlayer player, int id, int amount)
        {
            try
            {
                await Task.Run(() =>
                {
                    ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Id == id);
                    if (item is null || item.Uid == -1) return;
                    player.Inventory.Items.Remove(item);
                    Inventory.CreateDroppedObject(player, item);
                });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [AsyncClientEvent("Inventory:UseItem")]
        public static async Task UseItem(VnXPlayer player, int id)
        {
            try
            {
                await Task.Run(() =>
                {
                    ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Id == id);
                    if (item is null || item.Uid == -1) return;
                    if (item.ClothesSlot > 0 && item.Type == ItemType.Clothes)
                    {
                        ItemModel alreadyUsedItem = player.Inventory.Items.FirstOrDefault(x => x.IsUsing && x.ClothesSlot == item.ClothesSlot && x.Id != item.Id);
                        if (alreadyUsedItem is not null)
                            alreadyUsedItem.IsUsing = false;

                        item.IsUsing = !item.IsUsing;
                        Customization.ApplyPlayerClothes(player);
                    }
                });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
