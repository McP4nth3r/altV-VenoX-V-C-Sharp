﻿using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.events.Christmas.Weihnachtsmarkt
{
    public class Weihnachtsmarkt : IScript
    {
        public static ColShapeModel Adventskalender_Col = RageAPI.CreateColShapeSphere(new Position(213.1452f, -923.5319f, 30.69199f), 1.5f);
        //Marker Adventskalender_Marker = //ToDo Create Marker NAPI.Marker.CreateMarker(0, Adventskalender_Col.position, new Position(0, 0, 0), new Position(0, 0, 0), 2, new Rgba(0, 150, 200), true, 0);
        public static ColShapeModel Markt_Col = RageAPI.CreateColShapeSphere(new Position(192.4393f, -910.426f, 30.6932f), 1.5f);

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != Markt_Col || shape != Adventskalender_Col) return false;
                if (shape == Markt_Col)
                {
                    //VenoX.TriggerClientEvent(player, "CreateChristmasMarketWindow");
                }
                else if (shape == Adventskalender_Col)
                {
                    //VenoX.TriggerClientEvent(player, "CreateAdventskalenderWindow");
                }
                return true;
            }
            catch { return false; }
        }



        /*public static void GivePlayerPresent(Client player, int Day)
        {
            try
            {
                if (Day == 8)
                {
                    Database.SetVIPStats((int)player.UID, "Bronze", 3);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_BRONZE + RageAPI.GetHexColorcode(255, 255, 255) + " für 3 Tage bekommen!");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (Day == 9)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_TANKSTELLENSNACK);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        Snack.position = new Position(0.0f, 0.0f, 0.0f);
                        Snack.hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                        Snack.ownerIdentifier = player.UID;
                        Snack.ITEM_ART = "NUTZ_ITEM";
                        Snack.objectHandle = null;

                        Snack.id = Database.AddNewItem(Snack);
                        _Globals_.Inventory.Inventory.Add(Snack);
                    }
                    else
                    {
                        Snack.amount += 50;
                        Database.UpdateItem(Snack);
                    }
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 50" + RageAPI.GetHexColorcode(255, 255, 255) + " Tankstellen - Snacks");
                }
                else if (Day == 10)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 5000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 5.000$");
                }
                else if (Day == 11)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 12500);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 12)
                {

                }
                else if (Day == 13)
                {
                    Database.SetVIPStats((int)player.UID, "Gold", 3);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_GOLD + RageAPI.GetHexColorcode(255, 255, 255) + " für 3 Tage bekommen!");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (Day == 14)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_HEISSESCHOKOLADE);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        Snack.position = new Position(0.0f, 0.0f, 0.0f);
                        Snack.hash = Constants.ITEM_HASH_HEISSESCHOKOLADE;
                        Snack.ownerIdentifier = player.UID;
                        Snack.ITEM_ART = "NUTZ_ITEM";
                        Snack.objectHandle = null;

                        Snack.id = Database.AddNewItem(Snack);
                        _Globals_.Inventory.Inventory.Add(Snack);
                    }
                    else
                    {
                        Snack.amount += 50;
                        Database.UpdateItem(Snack);
                    }
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 50x " + RageAPI.GetHexColorcode(255, 255, 255) + "Heiße - Schokolade");
                }
                else if (Day == 15)
                {
                    Database.SetVIPStats((int)player.UID, "TOP DONATOR", 2);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_TOP_DONATOR + RageAPI.GetHexColorcode(255, 255, 255) + " für 2 Tage bekommen!");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else if (Day == 16)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 12500);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 19)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 15000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 15.000$");
                }
                else if (Day == 20)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 5000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 5.000$ + 10 Schneebälle");
                    Globals.player.Inventory.GiveItem(Constants.ITEM_HASH_SNOWBALL, ItemType.Gun, 10, true);
                }
                else if (Day == 21)
                {
                    VehicleModel IVehicle = new VehicleModel();
                    // Basic data for IVehicle creation
                    IVehicle.model = "sanchez";
                    IVehicle.faction = Constants.FACTION_ADMIN;
                    IVehicle.position = player.Position;
                    IVehicle.rotation = player.Rotation;
                    IVehicle.dimension = player.Dimension;
                    IVehicle.RgbaType = Constants.VEHICLE_Rgba_TYPE_CUSTOM;
                    IVehicle.firstRgba = 0 + "," + 200 + "," + 255;
                    IVehicle.secondRgba = 255 + "," + 255 + "," + 255;
                    IVehicle.pearlescent = 0;
                    IVehicle.owner = player.Username;
                    IVehicle.plate = string.Empty;
                    IVehicle.price = 0;
                    IVehicle.parking = 0;
                    IVehicle.parked = 0;
                    IVehicle.gas = 50.0f;
                    IVehicle.kms = 0.0f;

                    // Create the IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann eine " + RageAPI.GetHexColorcode(0, 200, 255) + " Sanchez :).");
                }
                else if (Day == 21)
                {
                    Reallife.Globals.player.Inventory.GiveItem(Constants.ITEM_HASH_MP5, ItemType.Gun, 300, false);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann eine " + RageAPI.GetHexColorcode(0, 200, 255) + " Mp5 :).");
                }
                else if (Day == 22)
                {
                    Reallife.Globals.player.Inventory.GiveItem(Constants.ITEM_HASH_MP5, ItemType.Gun, 300, false);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 75000);
                    Database.SetVIPStats((int)player.UID, "TOP DONATOR", 7);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_TOP_DONATOR + RageAPI.GetHexColorcode(255, 255, 255) + " für 7 Tage bekommen!");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Heute ist Solids Geburtstag :D Gönn dir ruhig mal auf sein nacken 75.000$ + 7 Tage TOP Donator ;).");
                }
                else if (Day == 23)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 25000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 25.000$");
                }
                else if (Day == 24)
                {
                    VehicleModel IVehicle = new VehicleModel();
                    // Basic data for IVehicle creation
                    IVehicle.model = "sanchez";
                    IVehicle.faction = Constants.FACTION_ADMIN;
                    IVehicle.position = player.Position;
                    IVehicle.rotation = player.Rotation;
                    IVehicle.dimension = player.Dimension;
                    IVehicle.RgbaType = Constants.VEHICLE_Rgba_TYPE_CUSTOM;
                    IVehicle.firstRgba = 0 + "," + 200 + "," + 255;
                    IVehicle.secondRgba = 255 + "," + 255 + "," + 255;
                    IVehicle.pearlescent = 0;
                    IVehicle.owner = player.Username;
                    IVehicle.plate = string.Empty;
                    IVehicle.price = 0;
                    IVehicle.parking = 0;
                    IVehicle.parked = 0;
                    IVehicle.gas = 50.0f;
                    IVehicle.kms = 0.0f;

                    // Create the IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann einen NAGEL NEUEN COMET! Gönn dir! Frohe Weihnachten " + RageAPI.GetHexColorcode(0, 200, 255) + " VenoX " + RageAPI.GetHexColorcode(200, 0, 0) + "<3");

                }
                player.vnxSetElementData(EntityData.PLAYER_ADVENTSKALENEDER, Day);
            }
            catch { }
        }
        */


        //[AltV.Net.ClientEvent("OnAdventskalenderClickServer")]
        public static void OnAdventskalenderClick(VnXPlayer player, int value)
        {
            try
            {
                if (DateTime.Now.Day == value && DateTime.Now.Month == 12)
                {
                    if (player.Reallife.Adventskalender != DateTime.Now.Day)
                    {
                        //GivePlayerPresent(player, value);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits das heutige Türchen geöffnet.");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Wir haben nicht den " + value + ". Dezember!");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("OnChristmasMarketClickServer")]
        public static void OnChristmasMarketClickServer(VnXPlayer player, int v)
        {
            try
            {
                if (v == 1)
                {
                    if (player.Reallife.Money < 12)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // Schockolade
                    player.Inventory.GiveItem(Constants.ITEM_HASH_SCHOKOLADE, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 12);
                }
                else if (v == 2)
                {
                    if (player.Reallife.Money < 17)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // Cookies
                    player.Inventory.GiveItem(Constants.ITEM_HASH_COOKIES, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 17);
                }
                else if (v == 3)
                {
                    if (player.Reallife.Money < 34)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // Lebkuchen
                    player.Inventory.GiveItem(Constants.ITEM_HASH_LEBKUCHENMAENNCHEN, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 34);
                }
                else if (v == 4)
                {
                    if (player.Reallife.Money < 60)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // sparerips
                    player.Inventory.GiveItem(Constants.ITEM_HASH_SPARERIPS, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 60);
                }
                else if (v == 5)
                {
                    if (player.Reallife.Money < 15)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // gluehwein
                    player.Inventory.GiveItem(Constants.ITEM_HASH_GLUEHWEIN, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 15);
                }
                else if (v == 6)
                {
                    if (player.Reallife.Money < 6)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // milk
                    player.Inventory.GiveItem(Constants.ITEM_HASH_MILCH, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 6);
                }
                else if (v == 7)
                {
                    if (player.Reallife.Money < 12)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    // hotchocolate
                    player.Inventory.GiveItem(Constants.ITEM_HASH_HEISSESCHOKOLADE, ItemType.Useable, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 12);
                }
                else if (v == 8)
                {
                    if (player.Reallife.Money < 75)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.Inventory.GiveItem(Constants.ITEM_HASH_SNOWBALL, ItemType.Gun, 1, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 75);
                    //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GET225);
                }
            }
            catch { }
        }

    }
}
