using AltV.Net;
using AltV.Net.Async;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Inventory
{
    public class Events : IScript
    {
        [AsyncClientEvent("Inventory:PickupItem")]
        public static async Task PickUpItem(VnXPlayer player, int Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    //Core.Debug.OutputDebugString("Called PickUp Item : " + Id);
                    ItemModel item = Inventory.DatabaseItems.FirstOrDefault(x => x.Id == Id);
                    if (item is null || item.UID > 0) return;
                    ItemModel playeritem = player.Inventory.Items.FirstOrDefault(x => x.Id == item.Id);
                    if (playeritem is not null) Database.RemoveItem(item.Id);

                    foreach (VnXPlayer nearby in player.NearbyPlayers)
                        Inventory.DeleteDroppedObject(nearby, item);

                    item.UID = player.UID;
                    item.Position = new Vector3(0, 0, 0);
                    item.Update();
                    Core.Debug.OutputDebugString("Obj : " + Id);
                    player.Inventory.GiveItem(item.Hash, item.Type, item.Amount, true, item.Dimension, item.Weight, false, Id);
                    //Core.Debug.OutputDebugString("You picked up : " + item.Hash);
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [AsyncClientEvent("Inventory:DropItem")]
        public static async Task DropItem(VnXPlayer player, int Id, int Amount)
        {
            try
            {
                await Task.Run(() =>
                {
                    ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Id == Id);
                    if (item is null || item.UID == -1) return;
                    player.Inventory.Items.Remove(item);
                    Inventory.CreateDroppedObject(player, item);
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [AsyncClientEvent("Inventory:UseItem")]
        public static async Task UseItem(VnXPlayer player, int ID)
        {
            try
            {
                await Task.Run(() =>
                {
                    ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Id == ID);
                    if (item is null || item.UID == -1) return;
                    if (item.ClothesSlot > 0 && item.Type == ItemType.Clothes)
                    {
                        ItemModel AlreadyUsedItem = player.Inventory.Items.FirstOrDefault(x => x.IsUsing && x.ClothesSlot == item.ClothesSlot && x.Id != item.Id);
                        if (AlreadyUsedItem is not null)
                            AlreadyUsedItem.IsUsing = false;

                        item.IsUsing = !item.IsUsing;
                        Customization.ApplyPlayerClothes(player);
                    }
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
