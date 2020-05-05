using AltV.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class Business : IScript
    {
        public static List<BusinessModel> businessList;


        public static BusinessModel GetBusinessById(int businessId)
        {
            try
            {
                BusinessModel business = null;
                foreach (BusinessModel businessModel in businessList)
                {
                    if (businessModel.id == businessId)
                    {
                        business = businessModel;
                        break;
                    }
                }
                return business;
            }
            catch { return null; }
        }

        public static BusinessModel GetClosestBusiness(PlayerModel player, float distance = 2.0f)
        {
            try
            {
                BusinessModel business = null;
                foreach (BusinessModel businessModel in businessList)
                {
                    if (player.position.Distance(businessModel.position) < distance)
                    {
                        business = businessModel;
                        distance = player.position.Distance(business.position);
                    }
                }
                return business;
            }
            catch { return null; }
        }

        public static List<BusinessItemModel> GetBusinessSoldItems(int business)
        {
            try
            {
                List<BusinessItemModel> businessItems = new List<BusinessItemModel>();
                foreach (BusinessItemModel businessItem in Constants.BUSINESS_ITEM_LIST)
                {
                    if (businessItem.business == business)
                    {
                        businessItems.Add(businessItem);
                    }
                }
                return businessItems;
            }
            catch { return null; }
        }

        public static BusinessItemModel GetBusinessItemFromName(string itemName)
        {
            try
            {
                BusinessItemModel item = null;
                foreach (BusinessItemModel businessItem in Constants.BUSINESS_ITEM_LIST)
                {
                    if (businessItem.description == itemName)
                    {

                        item = businessItem;
                        break;
                    }
                }
                return item;
            }
            catch { return null; }
        }

        public static BusinessItemModel GetBusinessItemFromHash(string itemHash)
        {
            try
            {
                BusinessItemModel item = null;
                foreach (BusinessItemModel businessItem in Constants.BUSINESS_ITEM_LIST)
                {
                    if (businessItem.hash == itemHash)
                    {
                        item = businessItem;
                        break;
                    }
                }
                return item;
            }
            catch { return null; }
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
            catch { return 10000; }
        }


        //[AltV.Net.ClientEvent("getClothesByType")]
        public void GetClothesByTypeEvent(PlayerModel player, int type, int slot)
        {
            try
            {
                int sex = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX);
                List<BusinessClothesModel> clothesList = GetBusinessClothesFromSlotType(sex, type, slot);
                if (clothesList.Count > 0)
                {
                    //BusinessModel business = GetBusinessById(player.vnxGetElementData<int>(EntityData.PLAYER_BUSINESS_ENTERED));
                    player.Emit("showTypeClothes", JsonConvert.SerializeObject(clothesList));
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("dressEquipedClothes")]
        public void DressEquipedClothesEvent(PlayerModel player, int type, int slot)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                ClothesModel clothes = Globals.Main.GetDressedClothesInSlot(playerId, type, slot);

                if (clothes != null)
                {
                    if (type == 0)
                    {
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(slot, clothes.drawable, clothes.texture);
                    }
                    else
                    {
                        //player.SetAccessories(slot, clothes.drawable, clothes.texture);
                    }
                }
                else
                {
                    if (type == 0)
                    {
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(slot, 0, 0);
                    }
                    else
                    {
                        //player.SetAccessories(slot, 255, 255);
                    }
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("clothesItemSelected")]
        public void ClothesItemSelectedEvent(PlayerModel player, string clothesJson)
        {
            try
            {
                /*ClothesModel clothesModel = NAPI.Util.FromJson<ClothesModel>(clothesJson);
                int sex = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX);
                int products = GetClothesProductsPrice(clothesModel.id, sex, clothesModel.type, clothesModel.slot);
                int price = (products * 1);

                int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);

                if (playerMoney >= price)
                {
                    int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);


                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - price);

                    Main.UndressClothes(playerId, clothesModel.type, clothesModel.slot);

                    clothesModel.player = playerId;
                    clothesModel.dressed = true;

                    clothesModel.id = Database.AddClothes(clothesModel);
                    Main.clothesList.Add(clothesModel);

                    player.SendChatMessage( "Transaktion in Höhe von " + RageAPI.GetHexColorcode(0,200,200} " + price + "$ " + RageAPI.GetHexColorcode(255,255,255) + "abgeschlossen!");
                    dxLibary.VnX.DrawNotification(player, "info", "Transaktion in Höhe von " + price + "$ abgeschlossen!");
                    vnx_stored_files.logfile.WriteLogs("clothes",player.GetVnXName() + " hat " + " TYPE : " + clothesModel.type + " | Slot : " + clothesModel.slot + " gekauft für " + price + " $");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                }*/
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("loadCharacterClothes")]
        public void LoadCharacterClothesEvent(PlayerModel player)
        {
            try
            {
                // Generate player's clothes
                Customization.ApplyPlayerClothes(player);
            }
            catch { }
        }
    }
}
