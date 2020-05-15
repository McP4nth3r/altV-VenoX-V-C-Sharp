using AltV.Net;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.character
{
    public class Customization : IScript
    {
        public static void ApplyPlayerCustomization(Client player, SkinModel skinModel, int sex)
        {
            try
            {
                Core.RageAPI.SetClothes(player, 2, skinModel.hairModel, 0);
                Core.RageAPI.SetCustomization(player, skinModel);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ApplyPlayerCustomization", ex); }
        }

        public static void ApplyPlayerClothes(Client player)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
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
            catch (Exception ex) { Core.Debug.CatchExceptions("ApplyPlayerClothes", ex); }
        }

        public static void ApplyPlayerTattoos(Client player)
        {
            try
            {
                // Get the tattoos from the player
                /*int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
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