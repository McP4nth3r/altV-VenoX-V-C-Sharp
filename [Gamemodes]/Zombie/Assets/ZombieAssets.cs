using System;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_.Character_Creator;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Zombie.Assets
{
    public class ZombieAssets
    {
        private static void LoadZombieClothesByIndex(VnXPlayer player, int index)
        {
            try
            {
                int Slot1Drawable = 0;
                int Slot1Texture = 0;

                int Slot2Drawable = 0;
                int Slot2Texture = 0;

                int Slot3Drawable = 0;
                int Slot3Texture = 0;

                int Slot4Drawable = 0;
                int Slot4Texture = 0;

                int Slot5Drawable = 0;
                int Slot5Texture = 0;

                int Slot6Drawable = 0;
                int Slot6Texture = 0;

                int Slot7Drawable = 0;
                int Slot7Texture = 0;

                int Slot8Drawable = 0;
                int Slot8Texture = 0;

                int Slot9Drawable = 0;
                int Slot9Texture = 0;

                int Slot10Drawable = 0;
                int Slot10Texture = 0;

                int Slot11Drawable = 0;
                int Slot11Texture = 0;
                foreach (ClothesModel clothes in Reallife.Globals.Main.clothesList.ToList())
                {
                    if (clothes.player == index && clothes.dressed && clothes.type == 0)
                    {
                        switch (clothes.slot)
                        {
                            case 1:
                                Slot1Drawable = clothes.drawable;
                                Slot1Texture = clothes.texture;
                                break;
                            case 2:
                                Slot2Drawable = clothes.drawable;
                                Slot2Texture = clothes.texture;
                                break;
                            case 3:
                                Slot3Drawable = clothes.drawable;
                                Slot3Texture = clothes.texture;
                                break;
                            case 4:
                                Slot4Drawable = clothes.drawable;
                                Slot4Texture = clothes.texture;
                                break;
                            case 5:
                                Slot5Drawable = clothes.drawable;
                                Slot5Texture = clothes.texture;
                                break;
                            case 6:
                                Slot6Drawable = clothes.drawable;
                                Slot6Texture = clothes.texture;
                                break;
                            case 7:
                                Slot7Drawable = clothes.drawable;
                                Slot7Texture = clothes.texture;
                                break;
                            case 8:
                                Slot8Drawable = clothes.drawable;
                                Slot8Texture = clothes.texture;
                                break;
                            case 9:
                                Slot9Drawable = clothes.drawable;
                                Slot9Texture = clothes.texture;
                                break;
                            case 10:
                                Slot10Drawable = clothes.drawable;
                                Slot10Texture = clothes.texture;
                                break;
                            case 11:
                                Slot11Drawable = clothes.drawable;
                                Slot11Texture = clothes.texture;
                                break;
                        }
                    }
                }
                /*
                Core.Debug.OutputDebugString("ID1 : " + Slot1Drawable + " | " + Slot1Texture);
                Core.Debug.OutputDebugString("ID2 : " + Slot2Drawable + " | " + Slot2Texture);
                Core.Debug.OutputDebugString("ID3 : " + Slot3Drawable + " | " + Slot3Texture);
                Core.Debug.OutputDebugString("ID4 : " + Slot4Drawable + " | " + Slot4Texture);
                Core.Debug.OutputDebugString("ID5 : " + Slot5Drawable + " | " + Slot5Texture);
                Core.Debug.OutputDebugString("ID6 : " + Slot6Drawable + " | " + Slot6Texture);
                Core.Debug.OutputDebugString("ID7 : " + Slot7Drawable + " | " + Slot7Texture);
                Core.Debug.OutputDebugString("ID8 : " + Slot8Drawable + " | " + Slot8Texture);
                Core.Debug.OutputDebugString("ID9 : " + Slot9Drawable + " | " + Slot9Texture);
                Core.Debug.OutputDebugString("ID10 : " + Slot10Drawable + " | " + Slot10Texture);
                Core.Debug.OutputDebugString("ID11 : " + Slot11Drawable + " | " + Slot11Texture);
                */
                VenoX.TriggerClientEvent(player, "Zombies:LoadEntityClassClothes", index,
                    Slot1Drawable, Slot1Texture,
                    Slot2Drawable, Slot2Texture,
                    Slot3Drawable, Slot3Texture,
                    Slot4Drawable, Slot4Texture,
                    Slot5Drawable, Slot5Texture,
                    Slot6Drawable, Slot6Texture,
                    Slot7Drawable, Slot7Texture,
                    Slot8Drawable, Slot8Texture,
                    Slot9Drawable, Slot9Texture,
                    Slot10Drawable, Slot10Texture,
                    Slot11Drawable, Slot11Texture);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        private static void LoadZombieAccessoriesByIndex(VnXPlayer player, int index)
        {
            try
            {
                int Slot1Drawable = 0;
                int Slot1Texture = 0;

                int Slot2Drawable = 0;
                int Slot2Texture = 0;

                int Slot3Drawable = 0;
                int Slot3Texture = 0;

                int Slot4Drawable = 0;
                int Slot4Texture = 0;

                int Slot5Drawable = 0;
                int Slot5Texture = 0;

                int Slot6Drawable = 0;
                int Slot6Texture = 0;

                int Slot7Drawable = 0;
                int Slot7Texture = 0;

                int Slot8Drawable = 0;
                int Slot8Texture = 0;

                int Slot9Drawable = 0;
                int Slot9Texture = 0;

                int Slot10Drawable = 0;
                int Slot10Texture = 0;

                int Slot11Drawable = 0;
                int Slot11Texture = 0;
                foreach (ClothesModel clothes in Reallife.Globals.Main.clothesList.ToList())
                {
                    if (clothes.player == index && clothes.dressed && clothes.type != 0)
                    {
                        switch (clothes.slot)
                        {
                            case 1:
                                Slot1Drawable = clothes.drawable;
                                Slot1Texture = clothes.texture;
                                break;
                            case 2:
                                Slot2Drawable = clothes.drawable;
                                Slot2Texture = clothes.texture;
                                break;
                            case 3:
                                Slot3Drawable = clothes.drawable;
                                Slot3Texture = clothes.texture;
                                break;
                            case 4:
                                Slot4Drawable = clothes.drawable;
                                Slot4Texture = clothes.texture;
                                break;
                            case 5:
                                Slot5Drawable = clothes.drawable;
                                Slot5Texture = clothes.texture;
                                break;
                            case 6:
                                Slot6Drawable = clothes.drawable;
                                Slot6Texture = clothes.texture;
                                break;
                            case 7:
                                Slot7Drawable = clothes.drawable;
                                Slot7Texture = clothes.texture;
                                break;
                            case 8:
                                Slot8Drawable = clothes.drawable;
                                Slot8Texture = clothes.texture;
                                break;
                            case 9:
                                Slot9Drawable = clothes.drawable;
                                Slot9Texture = clothes.texture;
                                break;
                            case 10:
                                Slot10Drawable = clothes.drawable;
                                Slot10Texture = clothes.texture;
                                break;
                            case 11:
                                Slot11Drawable = clothes.drawable;
                                Slot11Texture = clothes.texture;
                                break;
                        }
                    }
                }
                /*Core.Debug.OutputDebugString("ID1 : " + Slot1Drawable + " | " + Slot1Texture);
                Core.Debug.OutputDebugString("ID2 : " + Slot2Drawable + " | " + Slot2Texture);
                Core.Debug.OutputDebugString("ID3 : " + Slot3Drawable + " | " + Slot3Texture);
                Core.Debug.OutputDebugString("ID4 : " + Slot4Drawable + " | " + Slot4Texture);
                Core.Debug.OutputDebugString("ID5 : " + Slot5Drawable + " | " + Slot5Texture);
                Core.Debug.OutputDebugString("ID6 : " + Slot6Drawable + " | " + Slot6Texture);
                Core.Debug.OutputDebugString("ID7 : " + Slot7Drawable + " | " + Slot7Texture);
                Core.Debug.OutputDebugString("ID8 : " + Slot8Drawable + " | " + Slot8Texture);
                Core.Debug.OutputDebugString("ID9 : " + Slot9Drawable + " | " + Slot9Texture);
                Core.Debug.OutputDebugString("ID10 : " + Slot10Drawable + " | " + Slot10Texture);
                Core.Debug.OutputDebugString("ID11 : " + Slot11Drawable + " | " + Slot11Texture);*/
                VenoX.TriggerClientEvent(player, "Zombies:LoadEntityClassAccessories", index,
                    Slot1Drawable, Slot1Texture,
                    Slot2Drawable, Slot2Texture,
                    Slot3Drawable, Slot3Texture,
                    Slot4Drawable, Slot4Texture,
                    Slot5Drawable, Slot5Texture,
                    Slot6Drawable, Slot6Texture,
                    Slot7Drawable, Slot7Texture,
                    Slot8Drawable, Slot8Texture,
                    Slot9Drawable, Slot9Texture,
                    Slot10Drawable, Slot10Texture,
                    Slot11Drawable, Slot11Texture);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void LoadZombieEntityData(VnXPlayer player)
        {
            try
            {
                foreach (CharacterModel EntityClass in _Preload_.Character_Creator.Main.CharacterSkins.ToList())
                {
                    VenoX.TriggerClientEvent(player, "Zombies:LoadEntityClass", EntityClass.UID, EntityClass.FaceFeatures, EntityClass.HeadBlendData, EntityClass.HeadOverlays);
                    LoadZombieClothesByIndex(player, EntityClass.UID);
                    LoadZombieAccessoriesByIndex(player, EntityClass.UID);
                    //Core.Debug.OutputDebugString("Index : " + EntityClass.UID);
                }
                //Core.Debug.OutputDebugString("Count Value : " + _Preload_.Character_Creator.Main.CharacterSkins.Count);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
