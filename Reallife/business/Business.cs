using AltV.Net.Elements.Entities;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.character;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using VenoXV.Reallife.dxLibary;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using AltV.Net;
using VenoXV.Reallife.Core;
using Newtonsoft.Json;

namespace VenoXV.Reallife.business
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

        public static BusinessModel GetClosestBusiness(IPlayer player, float distance = 2.0f)
        {
            try
            {
                BusinessModel business = null;
                foreach (BusinessModel businessModel in businessList)
                {
                    if (player.Position.Distance(businessModel.position) < distance)
                    {
                        business = businessModel;
                        distance = player.Position.Distance(business.position);
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
                    if (businessItem.deIScription == itemName)
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

        public static string GetBusinessTypeIpl(int type)
        {
            try
            {
                string businessIpl = string.Empty;
                foreach (BusinessIplModel iplModel in Constants.BUSINESS_IPL_LIST)
                {
                    if (iplModel.type == type)
                    {
                        businessIpl = iplModel.ipl;
                        break;

                    }
                }
                return businessIpl;
            }
            catch { return ""; }
        }

        public static Position GetBusinessExitPoint(string ipl)
        {
            try
            {
                Position exit = new Position(0,0,0);
                foreach (BusinessIplModel businessIpl in Constants.BUSINESS_IPL_LIST)
                {
                    if (businessIpl.ipl == ipl)
                    {
                        exit = businessIpl.position;
                        break;
                    }
                }
                return exit;
            }
            catch { return new Position(0, 0, 0); }
        }

        public static bool HasPlayerBusinessKeys(IPlayer player, BusinessModel business)
        {
            try
            {
                return (player.GetVnXName<string>() == business.owner);
            }
            catch { return false; }

        }


        //[AltV.Net.ClientEvent("businessPurchaseMade")]
        public void BusinessPurchaseMadeEvent(IPlayer player, string itemName, int amount)
        {
            try
            {
                int businessId = player.vnxGetElementData<int>(EntityData.PLAYER_BUSINESS_ENTERED);
                BusinessModel business = GetBusinessById(businessId);
                BusinessItemModel businessItem = GetBusinessItemFromName(itemName);
                int hash = 0;
                int price = (int)Math.Round(businessItem.products * business.multiplier) * amount;
                int money = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);

                if (money < price)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                }
                else
                {
                    int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

                    // We look for the item in the inventory
                    ItemModel itemModel = Globals.Main.GetPlayerItemModelFromHash(playerId, businessItem.hash);
                    if (itemModel == null)
                    {
                        // We create the purchased item
                        itemModel = new ItemModel();
                        itemModel.hash = businessItem.hash;
                        if (businessItem.type == Constants.ITEM_TYPE_WEAPON)
                        {
                            itemModel.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                        }
                        else
                        {
                            itemModel.ownerEntity = int.TryParse(itemModel.hash, out hash) ? Constants.ITEM_ENTITY_PLAYER : Constants.ITEM_ENTITY_PLAYER;
                        }
                        itemModel.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        itemModel.amount = businessItem.uses * amount;
                        itemModel.position = new Position(0.0f, 0.0f, 0.0f);
                        itemModel.ITEM_ART = "Business";
                        itemModel.dimension = 0;
                        // Adding the item to the list and database
                        itemModel.id = Database.AddNewItem(itemModel);
                        Globals.Main.itemList.Add(itemModel);
                    }
                    else
                    {
                        if (int.TryParse(itemModel.hash, out hash) == true)
                        {
                            itemModel.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                        }
                        itemModel.amount += (businessItem.uses * amount);


                        // Update the item's amount
                        Database.UpdateItem(itemModel);
                    }


                    // We set the item into the hand variable
                    player.SetData(EntityData.PLAYER_RIGHT_HAND, itemModel.id);



                    // We substract the product and add funds to the business
                    if (business.owner != string.Empty)
                    {
                        business.funds += price;
                        business.products -= businessItem.products;

                        // Update the business
                        Database.UpdateBusiness(business);
                    }

                    player.SetData(EntityData.PLAYER_MONEY, money - price);
                    player.SendChatMessage("Transaktion in höhe von " + RageAPI.GetHexColorcode(0,200,255) + "  " + price + " $ " + RageAPI.GetHexColorcode(255,255,255) + "abgeschlossen!");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("getClothesByType")]
        public void GetClothesByTypeEvent(IPlayer player, int type, int slot)
        {
            try
            {
                int sex = player.vnxGetElementData<int>(EntityData.PLAYER_SEX);
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
        public void DressEquipedClothesEvent(IPlayer player, int type, int slot)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
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
        public void ClothesItemSelectedEvent(IPlayer player, string clothesJson)
        {
            try
            {
                /*ClothesModel clothesModel = NAPI.Util.FromJson<ClothesModel>(clothesJson);
                int sex = player.vnxGetElementData<int>(EntityData.PLAYER_SEX);
                int products = GetClothesProductsPrice(clothesModel.id, sex, clothesModel.type, clothesModel.slot);
                int price = (products * 1);

                int playerMoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);

                if (playerMoney >= price)
                {
                    int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);


                    player.SetData(EntityData.PLAYER_MONEY, playerMoney - price);

                    Main.UndressClothes(playerId, clothesModel.type, clothesModel.slot);

                    clothesModel.player = playerId;
                    clothesModel.dressed = true;

                    clothesModel.id = Database.AddClothes(clothesModel);
                    Main.clothesList.Add(clothesModel);

                    player.SendChatMessage( "Transaktion in Höhe von " + RageAPI.GetHexColorcode(0,200,200} " + price + "$ " + RageAPI.GetHexColorcode(255,255,255) + "abgeschlossen!");
                    dxLibary.VnX.DrawNotification(player, "info", "Transaktion in Höhe von " + price + "$ abgeschlossen!");
                    vnx_stored_files.logfile.WriteLogs("clothes",player.GetVnXName<string>() + " hat " + " TYPE : " + clothesModel.type + " | Slot : " + clothesModel.slot + " gekauft für " + price + " $");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                }*/
            }
            catch { }
        }
        
        //[AltV.Net.ClientEvent("loadCharacterClothes")]
        public void LoadCharacterClothesEvent(IPlayer player)
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
