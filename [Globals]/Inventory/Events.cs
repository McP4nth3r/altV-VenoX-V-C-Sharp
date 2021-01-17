using AltV.Net;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Inventory
{
    public class Events : IScript
    {

        [ClientEvent("Inventory:PickupItem")]
        public static void PickUpItem(VnXPlayer player, int Id)
        {
            ItemModel item = Inventory.DatabaseItems.FirstOrDefault(x => x.Id == Id);
            if (item is null || item.UID > 0) return;
            foreach (VnXPlayer nearby in player.NearbyPlayers)
                Inventory.DeleteDroppedObject(nearby, item);

            item.UID = player.UID;
            item.Position = new Vector3(0, 0, 0);
            item.Update();
            player.Inventory.Items.Add(item);
        }

        [ClientEvent("Inventory:DropItem")]
        public static void DropItem(VnXPlayer player, string Hash, int Amount)
        {
            try
            {
                ItemModel item = player.Inventory.Items.FirstOrDefault(x => x.Hash == Hash);
                if (item is null || item.UID == -1) return;
                Inventory.CreateDroppedObject(player, item);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
