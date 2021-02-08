using AltV.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class Business : IScript
    {
        public static List<BusinessModel> businessList;
        public static int GetClothesProductsPrice(int id, int sex, int type, int slot)
        {
            try
            {
                int productsPrice = 10000;
                foreach (BusinessClothesModel clothesModel in Constants.BUSINESS_CLOTHES_LIST)
                {
                    if (clothesModel.type == type && (clothesModel.sex == sex || Constants.SEX_NONE == clothesModel.sex) && clothesModel.bodyPart == slot && clothesModel.clothesId == id)
                    {
                        productsPrice = clothesModel.products;
                        break;
                    }
                }
                return productsPrice;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return 10000; }
        }
        public static List<BusinessClothesModel> GetBusinessClothesFromSlotType(int sex, int type, int slot)
        {
            try
            {
                List<BusinessClothesModel> businessClothesList = new List<BusinessClothesModel>();
                foreach (BusinessClothesModel clothes in Constants.BUSINESS_CLOTHES_LIST)
                {
                    if (clothes.type == type && (clothes.sex == sex || Constants.SEX_NONE == clothes.sex) && clothes.bodyPart == slot)
                    {
                        businessClothesList.Add(clothes);
                    }
                }
                return businessClothesList;
            }
            catch { return null; }
        }

        [VenoXRemoteEvent("getClothesByType")]
        public void GetClothesByTypeEvent(VnXPlayer player, int type, int slot)
        {
            try
            {
                int sex = player.Sex;
                List<BusinessClothesModel> clothesList = GetBusinessClothesFromSlotType(sex, type, slot);
                if (clothesList.Count > 0)
                {
                    VenoX.TriggerClientEvent(player, "showTypeClothes", JsonConvert.SerializeObject(clothesList));
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("clothesItemSelected")]
        public void ClothesItemSelectedEvent(VnXPlayer player, string clothesJson)
        {
            try
            {
                ClothesModel clothesModel = (ClothesModel)JsonConvert.DeserializeObject(clothesJson);
                int sex = player.Sex;
                int products = GetClothesProductsPrice(clothesModel.id, sex, clothesModel.type, clothesModel.slot);
                int price = (products * 1);

                int playerMoney = player.Reallife.Money;

                if (playerMoney >= price)
                {
                    int playerId = player.UID;

                    player.Reallife.Money -= price;

                    Main.UndressClothes(playerId, clothesModel.type, clothesModel.slot);

                    clothesModel.player = playerId;
                    clothesModel.dressed = true;

                    clothesModel.id = Database.AddClothes(clothesModel);
                    Main.clothesList.Add(clothesModel);
                    //NAPI.Chat.SendChatMessageToPlayer(player, "Transaktion in Höhe von !{0,200,200} " + price + "$ !{255,255,255}abgeschlossen!");
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Transaktion in Höhe von " + price + "$ abgeschlossen!");
                    //vnx_stored_files.logfile.WriteLogs("clothes", player.Name + " hat " + " TYPE : " + clothesModel.type + " | Slot : " + clothesModel.slot + " gekauft für " + price + " $");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("dressEquipedClothes")]
        public void DressEquipedClothesEvent(VnXPlayer player, int type, int slot)
        {
            try
            {
                int playerId = player.UID;
                ClothesModel clothes = Globals.Main.GetDressedClothesInSlot(playerId, type, slot);

                if (clothes != null)
                {
                    if (type == 0)
                    {
                        Core.RageAPI.SetClothes(player, slot, clothes.drawable, clothes.texture);
                    }
                    else
                    {
                        Core.RageAPI.SetAccessories(player, slot, clothes.drawable, clothes.texture);
                    }
                }
                else
                {
                    if (type == 0)
                    {
                        Core.RageAPI.SetClothes(player, slot, 0, 0);
                    }
                    else
                    {
                        Core.RageAPI.SetAccessories(player, slot, 255, 255);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

    }
}
