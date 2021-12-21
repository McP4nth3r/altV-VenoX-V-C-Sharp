using System;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.model;
using EntityData = VenoXV._Globals_.EntityData;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.events.Christmas.Weihnachtsmarkt
{
    public class Weihnachtsmarkt : IScript
    {
        public static ColShapeModel AdventskalenderCol = RageApi.CreateColShapeSphere(new Position(213.1452f, -923.5319f, 30.69199f), 1.5f);
        //Marker Adventskalender_Marker = //ToDo Create Marker NAPI.Marker.CreateMarker(0, Adventskalender_Col.position, new Position(0, 0, 0), new Position(0, 0, 0), 2, new Rgba(0, 150, 200), true, 0);
        public static ColShapeModel MarktCol = RageApi.CreateColShapeSphere(new Position(192.4393f, -910.426f, 30.6932f), 1.5f);

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != MarktCol || shape != AdventskalenderCol) return false;
                if (shape == MarktCol)
                {
                    //VenoX.TriggerClientEvent(player, "CreateChristmasMarketWindow");
                }
                else if (shape == AdventskalenderCol)
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
                    player.vnxSetElementData(Core.Globals.EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (Day == 9)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_TANKSTELLENSNACK);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.Dimension = Core.Globals.Main.REALLIFE_DIMENSION;
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
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 5000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 5.000$");
                }
                else if (Day == 11)
                {
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 12500);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 12)
                {

                }
                else if (Day == 13)
                {
                    Database.SetVIPStats((int)player.UID, "Gold", 3);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_GOLD + RageAPI.GetHexColorcode(255, 255, 255) + " für 3 Tage bekommen!");
                    player.vnxSetElementData(Core.Globals.EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (Day == 14)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_HEISSESCHOKOLADE);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.Dimension = Core.Globals.Main.REALLIFE_DIMENSION;
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
                    player.vnxSetElementData(Core.Globals.EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else if (Day == 16)
                {
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 12500);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 19)
                {
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 15000);
                    player.SendTranslatedChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 15.000$");
                }
                else if (Day == 20)
                {
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 5000);
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
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 75000);
                    Database.SetVIPStats((int)player.UID, "TOP DONATOR", 7);
                    player.SendTranslatedChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_TOP_DONATOR + RageAPI.GetHexColorcode(255, 255, 255) + " für 7 Tage bekommen!");
                    player.vnxSetElementData(Core.Globals.EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Heute ist Solids Geburtstag :D Gönn dir ruhig mal auf sein nacken 75.000$ + 7 Tage TOP Donator ;).");
                }
                else if (Day == 23)
                {
                    player.vnxSetStreamSharedElementData(Core.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + 25000);
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
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        */


        //[AltV.Net.ClientEvent("OnAdventskalenderClickServer")]
        public static void OnAdventskalenderClick(VnXPlayer player, int value)
        {
            try
            {
                if (DateTime.Now.Day == value && DateTime.Now.Month == 12)
                {
                    if (player.Reallife.AdventCalender != DateTime.Now.Day)
                    {
                        //GivePlayerPresent(player, value);
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du hast bereits das heutige Türchen geöffnet.");
                    }
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Wir haben nicht den " + value + ". Dezember!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("OnChristmasMarketClickServer")]
        public static void OnChristmasMarketClickServer(VnXPlayer player, int v)
        {
            try
            {
                switch (v)
                {
                    case 1 when player.Reallife.Money < 12:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // Schockolade
                    case 1:
                        player.Inventory.GiveItem(Constants.ItemHashSchokolade, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 12);
                        break;
                    case 2 when player.Reallife.Money < 17:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // Cookies
                    case 2:
                        player.Inventory.GiveItem(Constants.ItemHashCookies, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 17);
                        break;
                    case 3 when player.Reallife.Money < 34:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // Lebkuchen
                    case 3:
                        player.Inventory.GiveItem(Constants.ItemHashLebkuchenmaennchen, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 34);
                        break;
                    case 4 when player.Reallife.Money < 60:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // sparerips
                    case 4:
                        player.Inventory.GiveItem(Constants.ItemHashSparerips, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 60);
                        break;
                    case 5 when player.Reallife.Money < 15:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // gluehwein
                    case 5:
                        player.Inventory.GiveItem(Constants.ItemHashGluehwein, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 15);
                        break;
                    case 6 when player.Reallife.Money < 6:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // milk
                    case 6:
                        player.Inventory.GiveItem(Constants.ItemHashMilch, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 6);
                        break;
                    case 7 when player.Reallife.Money < 12:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    // hotchocolate
                    case 7:
                        player.Inventory.GiveItem(Constants.ItemHashHeisseschokolade, ItemType.Useable, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 12);
                        break;
                    case 8 when player.Reallife.Money < 75:
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GET225);
                    case 8:
                        player.Inventory.GiveItem(Constants.ItemHashSnowball, ItemType.Gun, 1, true);
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 75);
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
