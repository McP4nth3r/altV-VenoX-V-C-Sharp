using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.character
{
    public class Customization : IScript
    {
        public static void ApplyPlayerClothes(VnXPlayer player)
        {
            try
            {
                List<int> Equiped = new List<int>();
                foreach (ItemModel item in player.Inventory.Items.ToList())
                    if (item.Type == ItemType.Clothes && item.IsUsing && !Equiped.Contains(item.ClothesSlot))
                    {
                        player.SetClothes(item.ClothesSlot, item.ClothesDrawable, item.ClothesTexture);
                        Equiped.Add(item.ClothesSlot);
                    }
                player.SetClothes(8, 15, 0);
                if (!Equiped.Contains(1)) player.SetClothes(1, 0, 0);
                if (!Equiped.Contains(11)) player.SetClothes(11, 252, 0);
                if (!Equiped.Contains(4)) player.SetClothes(4, 21, 0);
                if (!Equiped.Contains(6)) player.SetClothes(6, 34, 0);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void ApplyPlayerTattoos(VnXPlayer player)
        {
            try
            {
                // Get the tattoos from the player
                /*int playerId = player.UID;
                List<TattooModel> playerTattoos = Main.tattooList.Where(t => t.player == playerId).ToList();

                foreach (TattooModel tattoo in playerTattoos)
                {
                    // Add each tattoo to the player
                    Decoration decoration = new Decoration();
                    decoration.Collection = NAPI.Util.GetHashKey(tattoo.library);
                    decoration.Overlay = NAPI.Util.GetHashKey(tattoo.hash);
                    player.SetDecoration(decoration);
                }*/
            }
            catch { }
        }
    }
}