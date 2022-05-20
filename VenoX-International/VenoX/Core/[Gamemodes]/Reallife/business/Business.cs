using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using Newtonsoft.Json;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.business
{
    public class Business : IScript
    {
        public static List<BusinessModel> BusinessList;

        private static int GetClothesProductsPrice(int id, int sex, int type, int slot)
        {
            try
            {
                int productsPrice = 10000;
                foreach (BusinessClothesModel clothesModel in Constants.BusinessClothesList.Where(clothesModel => clothesModel.Type == type && (clothesModel.Sex == sex || Constants.SexNone == clothesModel.Sex) && clothesModel.BodyPart == slot && clothesModel.ClothesId == id))
                {
                    productsPrice = clothesModel.Products;
                    break;
                }
                return productsPrice;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return 10000; }
        }

        private static List<BusinessClothesModel> GetBusinessClothesFromSlotType(int sex, int type, int slot)
        {
            try
            {
                List<BusinessClothesModel> businessClothesList = new List<BusinessClothesModel>();
                foreach (BusinessClothesModel clothes in Constants.BusinessClothesList)
                {
                    if (clothes.Type == type && (clothes.Sex == sex || Constants.SexNone == clothes.Sex) && clothes.BodyPart == slot)
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
                    _RootCore_.VenoX.TriggerClientEvent(player, "showTypeClothes", JsonConvert.SerializeObject(clothesList));
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("clothesItemSelected")]
        public void ClothesItemSelectedEvent(VnXPlayer player, string clothesJson)
        {
            try
            {
                ClothesModel clothesModel = (ClothesModel)JsonConvert.DeserializeObject(clothesJson);
                int sex = player.Sex;
                int products = GetClothesProductsPrice(clothesModel.Id, sex, clothesModel.Type, clothesModel.Slot);
                int price = (products * 1);

                int playerMoney = player.Reallife.Money;

                if (playerMoney >= price)
                {
                    int playerId = player.CharacterId;

                    player.Reallife.Money -= price;

                    Main.UndressClothes(playerId, clothesModel.Type, clothesModel.Slot);

                    clothesModel.Player = playerId;
                    clothesModel.Dressed = true;

                    clothesModel.Id = Database.AddClothes(clothesModel);
                    Main.ClothesList.Add(clothesModel);
                    //NAPI.Chat.SendChatMessageToPlayer(player, "Transaktion in Höhe von !{0,200,200} " + price + "$ !{255,255,255}abgeschlossen!");
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Info, "Transaktion in Höhe von " + price + "$ abgeschlossen!");
                    //vnx_stored_files.logfile.WriteLogs("clothes", player.Name + " hat " + " TYPE : " + clothesModel.type + " | Slot : " + clothesModel.slot + " gekauft für " + price + " $");
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du hast nicht genug Geld!");
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("dressEquipedClothes")]
        public void DressEquipedClothesEvent(VnXPlayer player, int type, int slot)
        {
            try
            {
                int playerId = player.CharacterId;
                ClothesModel clothes = Main.GetDressedClothesInSlot(playerId, type, slot);

                if (clothes != null)
                {
                    if (type == 0)
                    {
                        RageApi.SetClothes(player, slot, clothes.Drawable, clothes.Texture);
                    }
                    else
                    {
                        RageApi.SetAccessories(player, slot, clothes.Drawable, clothes.Texture);
                    }
                }
                else
                {
                    if (type == 0)
                    {
                        RageApi.SetClothes(player, slot, 0, 0);
                    }
                    else
                    {
                        RageApi.SetAccessories(player, slot, 255, 255);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

    }
}
