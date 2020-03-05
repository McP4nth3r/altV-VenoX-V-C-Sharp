using AltV.Net.Elements.Entities;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using System.Collections.Generic;
using System.Linq;
using System;
using AltV.Net;
using VenoXV.Reallife.Core;

namespace VenoXV.Reallife.character
{
    public class Customization : IScript
    {
        public static void ApplyPlayerCustomization(IPlayer player, SkinModel skinModel, int sex)
        {
            try
            {
                Core.RageAPI.SetClothes(player, 2, skinModel.hairModel, 0);
                Core.RageAPI.SetCustomization(player, skinModel);
            }
            catch(Exception ex) { Core.Debug.CatchExceptions("ApplyPlayerCustomization", ex); }
        }

        public static void ApplyPlayerClothes(IPlayer player)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                foreach (ClothesModel clothes in Main.clothesList)
                {
                    if (clothes.player == playerId && clothes.dressed)
                    {
                        if (clothes.type == 0)
                        {
                            Core.RageAPI.SetClothes(player, clothes.slot, clothes.drawable, clothes.texture);
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            Core.RageAPI.SetAccessories(player, clothes.slot, clothes.drawable, clothes.texture);
                            // player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                        }
                    }
                }
            }
            catch { }
        }

        public static void ApplyPlayerTattoos(IPlayer player)
        {
            try
            {
                // Get the tattoos from the player
                /*int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
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