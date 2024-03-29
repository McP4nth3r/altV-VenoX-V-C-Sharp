﻿using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.register_login
{
    public class Customization : IScript
    {
        public static void ApplyPlayerClothes(VnXPlayer player)
        {
            try
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(8, 15, 0);
                List<int> equiped = new List<int>();
                foreach (ItemModel item in player.Inventory.Items.ToList())
                    if (item.Type == ItemType.Clothes && item.IsUsing && !equiped.Contains(item.ClothesSlot))
                    {
                        player.SetClothes(item.ClothesSlot, item.ClothesDrawable, item.ClothesTexture);
                        equiped.Add(item.ClothesSlot);
                    }

                if (!equiped.Contains(1)) player.SetClothes(1, 0, 0);
                if (!equiped.Contains(11)) player.SetClothes(11, 252, 0);
                if (!equiped.Contains(4)) player.SetClothes(4, 21, 0);
                if (!equiped.Contains(6)) player.SetClothes(6, 34, 0);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}