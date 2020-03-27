﻿using AltV.Net.Elements.Entities;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VenoXV.Reallife.vnx_stored_files;
using System;
using AltV.Net;
using AltV.Net.Data;
using VenoXV.Core;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;

namespace VenoXV.Reallife.house
{
    public class House : IScript
    {
        public static List<HouseModel> houseList;

        public void LoadDatabaseHouses()
        {
            houseList = Database.LoadAllHouses();
            foreach (HouseModel houseModel in houseList)
            {
                string houseLabelText = GetHouseLabelText(houseModel);
                RageAPI.CreateTextLabel(houseLabelText, houseModel.position, 20.0f, 0.75f, 4, new int[] { 255, 255, 255, 255 }, houseModel.Dimension);
                //ToDo: Requesting Offices NAPI.World.RequestIpl (houseModel.ipl);
            }
        }

        public static HouseModel GetHouseById(int id)
        {
            HouseModel house = null;
            foreach (HouseModel houseModel in houseList)
            {
                if (houseModel.id == id)
                {
                    house = houseModel;
                    break;
                }
            }
            return house;
        }

        public static HouseModel GetClosestHouse(IPlayer player, float distance = 1.5f)
        {
            HouseModel house = null;
            foreach (HouseModel houseModel in houseList)
            {
                if (player.Position.Distance(houseModel.position) < distance)
                {
                    house = houseModel;
                    distance = player.Position.Distance(houseModel.position);
                }
            }
            return house;
        }

        public static Position GetHouseExitPoint(string ipl)
        {
            try{
                Position exit = new Position(0,0,0);
                foreach (HouseIplModel houseIpl in Constants.HOUSE_IPL_LIST)
                {
                    if (houseIpl.ipl == ipl)
                    {
                        exit = houseIpl.position;
                        break;
                    }
                }
                return exit;
            }
            catch { return new Position(0, 0, 0); }
        }

        public static bool HasPlayerHouseKeys(IPlayer player, HouseModel house)
        {
            try
            {
                return (player.GetVnXName<string>() == house.owner || player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == house.id);
            }
            catch { return false; }
        }

        public static string GetHouseLabelText(HouseModel house)
        {
            try
            {
                string label = string.Empty;

                switch (house.status)
                {
                    case Constants.HOUSE_STATE_NONE:
                        label = "~b~" + house.name + "\n" + "~b~[ID] : + "+RageAPI.GetHexColorcode(255,255,255) + house.id + "\n" + "~b~Besitzer : " + RageAPI.GetHexColorcode(255,255,255)+ house.owner;
                        break;
                    case Constants.HOUSE_STATE_RENTABLE:
                        label = "~b~" + house.name + "\n" + "~b~[ID] : + "+RageAPI.GetHexColorcode(255,255,255)+ house.id + "\n" + "~b~Besitzer :" +RageAPI.GetHexColorcode(255,255,255) + house.owner + "\n" + "~b~Zu Vermieten" + "\n" + "~b~Preis : + "+RageAPI.GetHexColorcode(255,255,255)+ house.rental +" $";
                        //label = house.name + "\n" + Messages.GEN_STATE_RENT + "\n" + house.rental + "$";
                        break;
                    case Constants.HOUSE_STATE_BUYABLE:
                        label = "~b~" + house.name + "\n" + "~b~[ID] : + "+RageAPI.GetHexColorcode(255,255,255) + house.id + "\n" + "~b~Zu Verkaufen" + "\n" + "~b~Preis : " + RageAPI.GetHexColorcode(255,255,255) + house.price + " $";
                        break;
                }
                return label;
            }
            catch { return ""; }
        }

        public static void BuyHouseS(IPlayer player, HouseModel house)
        {
            try
            {
                if (house.status == Constants.HOUSE_STATE_BUYABLE)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_BANK) >= house.price)
                    {
                        int bank = player.vnxGetElementData<int>(EntityData.PLAYER_BANK) - house.price;
                        string labelText = GetHouseLabelText(house);
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_BANK, bank);
                        logfile.WriteLogs("house",player.GetVnXName<string>() + " hat sich Haus ID " + house.id + " gekauft für " + house.price + " $ ");
                        house.status = Constants.HOUSE_STATE_NONE;
                        house.owner =player.GetVnXName<string>();
                        house.locked = true;
                        //house.houseLabel.Text = GetHouseLabelText(house);
                        // Update the house
                        Database.UpdateHouse(house);
                        player.SendChatMessage( RageAPI.GetHexColorcode(0,125,0) + "Glückwunsch,du hast das Haus gekauft!Für mehr Infos, öffne das Hilfemenü!");
                    }
                    else
                    {
                        player.SendChatMessage( Constants.Rgba_ERROR + "Du hast nicht genug Geld!");
                    }
                }
            }
            catch { }
        }


        [Command("buyhouse")]
        public void BuyHouseIPlayer(IPlayer player)
        {
            try
            {
                // Get all the houses
                foreach (HouseModel house in houseList)
                {
                    if(house.owner ==player.GetVnXName<string>())
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits ein Haus! nutze /sellhouse um es zu verkaufen!");
                        return;
                    }
                    if (player.Position.Distance(house.position) <= 1.5f && player.Dimension == house.Dimension)
                    {
                        BuyHouseS(player, house);
                        return;
                    }
                }
            }
            catch { }
        }

        /*[Command("sellhouse")]
        public static void SellHouseIPlayer(IPlayer player)
        {
            // Get all the houses
            foreach (HouseModel house in houseList)
            {
                if (house.owner ==player.GetVnXName<string>())
                {
                    if (player.vnxGetElementData("SELL_HOUSE_REQUESTED") == true)
                    {
                        int moneyget = house.price / 2;
                        player.SetData("SELL_HOUSE_REQUESTED", false);

                        house.owner = string.Empty;
                        house.status = Constants.HOUSE_STATE_BUYABLE;
                        house.tenants = 2;
                        house.rental = 0;
                        house.locked = true;
                        //house.houseLabel.Text = GetHouseLabelText(house);

                        Database.UpdateHouse(house);
                        player.SendChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Du hast dein Haus für " + moneyget + " verkauft!");
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + moneyget);
                        return;
                    }
                    else
                    {
                        int moneyget = house.price / 2;
                        player.SendChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Möchtest du dein Haus verkaufen für " + moneyget + " $ ?");
                        player.SendChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Bestätige dies mit /sellhouse.");
                        player.SetData("SELL_HOUSE_REQUESTED", true);
                    }
                }
            }
            
        }*/


        [Command("hlock")]
        public void HouseLockIPlayer(IPlayer player)
        {
            try
            {
                // Get all the houses
                foreach (HouseModel house in houseList)
                {
                    if (player.Position.Distance(house.position) <= 1.5f && player.Dimension == house.Dimension)
                    {
                        if(house.owner ==player.GetVnXName<string>())
                        {
                            string State = "Abgeschlossen!";
                            if(house.locked)
                            {
                                house.locked = false;
                                State = "Aufgeschlossen!";
                            }
                            else
                            {
                                house.locked = true;
                            }
                            player.SendChatMessage("Haus " + State);
                        }
                        return;
                    }
                }
            }
            catch { }
        }

        [Command("houseinfos")]
        public void GetHouseInfos(IPlayer player)
        {
            try
            {
                string status = "Aufgeschlossen";
                // Get all the houses
                foreach (HouseModel house in houseList)
                {
                    if (house.owner ==player.GetVnXName<string>())
                    {
                        if (house.locked == true) { status = "Abgeschlossen"; }
                        player.SendChatMessage( "__________________________________________");
                        player.SendChatMessage( "HAUS : " + house.name);
                        player.SendChatMessage( "HAUS ID : " + house.id);
                        player.SendChatMessage( "HAUS status : " + status);
                        player.SendChatMessage( "HAUS Miete  : " + house.rental + " $");
                        player.SendChatMessage( "__________________________________________");
                    }
                }
            }
            catch { }
        }




        //[AltV.Net.ClientEvent("getPlayerPurchasedClothes")]
        public void GetPlayerPurchasedClothesEvent(IPlayer player, int type, int slot)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                int sex = player.vnxGetElementData<int>(EntityData.PLAYER_SEX);

                List<ClothesModel> clothesList = Main.GetPlayerClothes(playerId).Where(c => c.type == type && c.slot == slot).ToList();

                if (clothesList.Count > 0)
                {
                    List<string> clothesNames = Main.GetClothesNames(clothesList);

                    // Show player's clothes
                    player.Emit("showPlayerClothes", JsonConvert.SerializeObject(clothesList), JsonConvert.SerializeObject(clothesNames));
                }
                else
                {
                    player.SendChatMessage(Constants.Rgba_ERROR + "Keine Klamotten im Klamottenschrank");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("wardrobeClothesItemSelected")]
        public void WardrobeClothesItemSelectedEvent(IPlayer player, int clothesId)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

                // Replace player clothes for the new ones
                foreach (ClothesModel clothes in Main.clothesList)
                {
                    if (clothes.id == clothesId)
                    {
                        clothes.dressed = true;
                        if (clothes.type == 0)
                        {
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            //player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                        }

                        // Update dressed clothes into database
                        Database.UpdateClothes(clothes);
                    }
                    else if (clothes.id != clothesId && clothes.dressed)
                    {
                        clothes.dressed = false;

                        // Update dressed clothes into database
                        Database.UpdateClothes(clothes);
                    }
                }
            }
            catch { }
        }


        [Command("setrent")]
        public void RentableCommand(IPlayer player, int amount = 0)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED) == 0)
            {
                dxLibary.VnX.DrawNotification(player, "error", "Dein Haus ist jetzt nicht mehr Mietbar!");
            }
            else
            {

                int houseId = player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED);
                HouseModel house = GetHouseById(houseId);
                if (house == null || house.owner !=player.GetVnXName<string>())
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Dir gehört kein Haus!");
                }
                else if (amount > 0)
                {
                    if (amount <= 5000)
                    {
                        house.rental = amount;
                        house.status = Constants.HOUSE_STATE_RENTABLE;
                        house.tenants = 2;

                        //house.houseLabel.Text = GetHouseLabelText(house);
                        Database.UpdateHouse(house);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Miete muss kleiner als 5000 sein!");
                    }

                }
                /*else if (house.status == Constants.HOUSE_STATE_RENTABLE)
                {
                    house.status = Constants.HOUSE_STATE_NONE;
                    house.tenants = 2;
                    //house.houseLabel.Text = GetHouseLabelText(house);
                    //Database.KickTenantsOut(house.id);
                    Database.UpdateHouse(house);
                }*/
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Miete muss größer als 0 sein!");
                }
            }
        }


        [Command("renthouse")]
        public void RentCommand(IPlayer player)
        {
            foreach (HouseModel house in houseList)
            {
                if (player.Position.Distance(house.position) <= 1.5 && player.Dimension == house.Dimension)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == 0)
                    {
                        if (house.status != Constants.HOUSE_STATE_RENTABLE)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Dieses Haus steht nicht zur Vermietung!");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < house.rental)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                        else
                        {
                            int money = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - house.rental;
                            player.SetData(EntityData.PLAYER_RENT_HOUSE, house.id);
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, money);
                            //house.tenants--;

                            /*if (house.tenants == 0)
                            {
                                house.status = Constants.HOUSE_STATE_NONE;
                                //house.houseLabel.Text = GetHouseLabelText(house);
                            }
                            Database.UpdateHouse(house);*/
                            dxLibary.VnX.DrawNotification(player, "info", "Du hast dich Erfolgreich Eingemietet!");
                        }
                        break;
                    }
                    /*else if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == house.id)
                    {
                        player.SetData(EntityData.PLAYER_RENT_HOUSE, 0);
                        house.tenants++;
                        Database.UpdateHouse(house);

                    }*/
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits eine Wohnung!");
                    }
                }
            }
        }


        [Command("unrenthouse")]

        public static void UnrentFromHaus(IPlayer player)
        {
            if(player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) <= 0)
            {
                player.SetData(EntityData.PLAYER_RENT_HOUSE, 0);
                //player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "DEBUG RENT");
            }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) != 0)
            {
                player.SetData(EntityData.PLAYER_RENT_HOUSE, 0);
                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast dich Erfolgreich ausgemietet!");
            //Database.KickTenantsOut(house.id);
            }
        }

    }
}
