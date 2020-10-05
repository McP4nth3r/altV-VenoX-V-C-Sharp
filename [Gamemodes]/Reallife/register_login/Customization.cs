using AltV.Net;
using System;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.character
{
    public class Customization : IScript
    {
        public static void ApplyPlayerClothes(VnXPlayer player)
        {
            try
            {
                int playerId = player.UID;
                foreach (ClothesModel clothes in Main.clothesList.ToList())
                {
                    if (clothes.player == playerId && clothes.dressed)
                    {
                        if (clothes.type == 0)
                        {
                            Core.RageAPI.SetClothes(player, clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            Core.RageAPI.SetAccessories(player, clothes.slot, clothes.drawable, clothes.texture);
                        }
                    }
                }
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