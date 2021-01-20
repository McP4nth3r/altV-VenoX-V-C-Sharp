using AltV.Net;
using AltV.Net.Async;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Inventory
{
    public class Events : IScript
    {

        [AsyncClientEvent("Inventory:PickupItem")]
        public static void PickUpItem(VnXPlayer player, int Id)
        {
            //Core.Debug.OutputDebugString("Called PickUp Item : " + Id);
            ItemModel item = Inventory.DatabaseItems.FirstOrDefault(x => x.Id == Id);
            if (item is null || item.UID > 0) return;
            ItemModel playeritem = player.Inventory.Items.FirstOrDefault(x => x.Hash == item.Hash);
            if (playeritem is not null) Database.RemoveItem(item.Id);

            foreach (VnXPlayer nearby in player.NearbyPlayers)
                Inventory.DeleteDroppedObject(nearby, item);

            item.UID = player.UID;
            item.Position = new Vector3(0, 0, 0);
            item.Update();
            player.Inventory.GiveItem(item.Hash, item.Type, item.Amount, true, item.Dimension, item.Weight);
            //Core.Debug.OutputDebugString("You picked up : " + item.Hash);
        }

        [ClientEvent("Inventory:DropItem")]
        public static void DropItem(VnXPlayer player, string Hash, int Amount)
        {
            try
            {
                ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Hash == Hash);
                if (item is null || item.UID == -1) return;
                player.Inventory.Items.Remove(item);
                Inventory.CreateDroppedObject(player, item);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
