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
                // Populate the head

                /*HeadBlend headBlend = new HeadBlend();
                
                headBlend.ShapeFirst = Convert.ToByte(skinModel.firstHeadShape);
                headBlend.ShapeSecond = Convert.ToByte(skinModel.secondHeadShape);
                headBlend.SkinFirst = Convert.ToByte(skinModel.firstSkinTone);
                headBlend.SkinSecond = Convert.ToByte(skinModel.secondSkinTone);
                headBlend.ShapeMix = skinModel.headMix;
                headBlend.SkinMix = skinModel.skinMix;

                // Get the hair and eyes Rgbas
                byte eyeRgba = Convert.ToByte(skinModel.eyesRgba);
                byte hairRgba = Convert.ToByte(skinModel.firstHairRgba);
                byte hightlightRgba = Convert.ToByte(skinModel.secondHairRgba);

                // Add the face features
                float[] faceFeatures = new float[]
                {
                skinModel.noseWidth, skinModel.noseHeight, skinModel.noseLength, skinModel.noseBridge, skinModel.noseTip, skinModel.noseShift, skinModel.browHeight,
                skinModel.browWidth, skinModel.cheekboneHeight, skinModel.cheekboneWidth, skinModel.cheeksWidth, skinModel.eyes, skinModel.lips, skinModel.jawWidth,
                skinModel.jawHeight, skinModel.chinLength, skinModel.chinPosition, skinModel.chinWidth, skinModel.chinShape, skinModel.neckWidth
                };

                // Populate the head overlays
                Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>();

                for (int i = 0; i < Constants.MAX_HEAD_OVERLAYS; i++)
                {
                    // Get the overlay model and Rgba
                    int[] overlayData = GetOverlayData(skinModel, i);

                    // Create the overlay
                    HeadOverlay headOverlay = new HeadOverlay();
                    headOverlay.Index = Convert.ToByte(overlayData[0]);
                    headOverlay.Rgba = Convert.ToByte(overlayData[1]);
                    headOverlay.SecondaryRgba = 0;
                    headOverlay.Opacity = 1.0f;

                    // Add the overlay
                    headOverlays[i] = headOverlay;
                }

                // Update the character's skin
                player.SetCustomization(sex == Constants.SEX_MALE, headBlend, eyeRgba, hairRgba, hightlightRgba, faceFeatures, headOverlays, new Decoration[] { });
                //ToDo Sie Clientseitig Laden! : player.SetClothes(2, skinModel.hairModel, 0);*/
                Core.RageAPI.SetClothes(player, 2, skinModel.hairModel, 0);

            }
            catch { }
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

        private static int[] GetOverlayData(SkinModel skinModel, int index)
        {
            try
            {
                int[] overlayData = new int[2];

                switch (index)
                {
                    case 0:
                        overlayData[0] = skinModel.blemishesModel;
                        overlayData[1] = 0;
                        break;
                    case 1:
                        overlayData[0] = skinModel.beardModel;
                        overlayData[1] = skinModel.beardRgba;
                        break;
                    case 2:
                        overlayData[0] = skinModel.eyebrowsModel;
                        overlayData[1] = skinModel.eyebrowsRgba;
                        break;
                    case 3:
                        overlayData[0] = skinModel.ageingModel;
                        overlayData[1] = 0;
                        break;
                    case 4:
                        overlayData[0] = skinModel.makeupModel;
                        overlayData[1] = 0;
                        break;
                    case 5:
                        overlayData[0] = skinModel.blushModel;
                        overlayData[1] = skinModel.blushRgba;
                        break;
                    case 6:
                        overlayData[0] = skinModel.complexionModel;
                        overlayData[1] = 0;
                        break;
                    case 7:
                        overlayData[0] = skinModel.sundamageModel;
                        overlayData[1] = 0;
                        break;
                    case 8:
                        overlayData[0] = skinModel.lipstickModel;
                        overlayData[1] = skinModel.lipstickRgba;
                        break;
                    case 9:
                        overlayData[0] = skinModel.frecklesModel;
                        overlayData[1] = 0;
                        break;
                    case 10:
                        overlayData[0] = skinModel.chestModel;
                        overlayData[1] = skinModel.chestRgba;
                        break;
                }

                return overlayData;
            }
            catch { return null; }
        }
    }
}