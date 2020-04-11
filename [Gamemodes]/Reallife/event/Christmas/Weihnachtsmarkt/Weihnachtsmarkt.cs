using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.events.Christmas.Weihnachtsmarkt
{
    public class Weihnachtsmarkt : IScript
    {
        public static IColShape Adventskalender_Col = Alt.CreateColShapeSphere(new Position(213.1452f, -923.5319f, 30.69199f), 1.5f);
        //Marker Adventskalender_Marker = //ToDo Create Marker NAPI.Marker.CreateMarker(0, Adventskalender_Col.Position, new Position(0, 0, 0), new Position(0, 0, 0), 2, new Rgba(0, 150, 200), true, 0);
        public static IColShape Markt_Col = Alt.CreateColShapeSphere(new Position(192.4393f, -910.426f, 30.6932f), 1.5f);

        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == Markt_Col)
                {
                    player.Emit("CreateChristmasMarketWindow");
                }
                else if (shape == Adventskalender_Col)
                {
                    player.Emit("CreateAdventskalenderWindow");
                }
            }
            catch { }
        }



        public static void GivePlayerPresent(IPlayer player, int Day)
        {
            try
            {
                if (Day == 8)
                {
                    Database.SetVIPStats((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Bronze", 3);
                    player.SendChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_BRONZE + RageAPI.GetHexColorcode(255, 255, 255) + " für 3 Tage bekommen!");
                    player.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (Day == 9)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_TANKSTELLENSNACK);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.dimension = 0;
                        Snack.position = new Position(0.0f, 0.0f, 0.0f);
                        Snack.hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                        Snack.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Snack.ITEM_ART = "NUTZ_ITEM";
                        Snack.objectHandle = null;

                        Snack.id = Database.AddNewItem(Snack);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Snack);
                    }
                    else
                    {
                        Snack.amount += 50;
                        Database.UpdateItem(Snack);
                    }
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 50" + RageAPI.GetHexColorcode(255, 255, 255) + " Tankstellen - Snacks");
                }
                else if (Day == 10)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 5000);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 5.000$");
                }
                else if (Day == 11)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 12500);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 12)
                {

                }
                else if (Day == 13)
                {
                    Database.SetVIPStats((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Gold", 3);
                    player.SendChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_GOLD + RageAPI.GetHexColorcode(255, 255, 255) + " für 3 Tage bekommen!");
                    player.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (Day == 14)
                {
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_HEISSESCHOKOLADE);
                    if (Snack == null) // Kanister
                    {
                        Snack = new ItemModel();
                        Snack.amount = 50;
                        Snack.dimension = 0;
                        Snack.position = new Position(0.0f, 0.0f, 0.0f);
                        Snack.hash = Constants.ITEM_HASH_HEISSESCHOKOLADE;
                        Snack.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Snack.ITEM_ART = "NUTZ_ITEM";
                        Snack.objectHandle = null;

                        Snack.id = Database.AddNewItem(Snack);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Snack);
                    }
                    else
                    {
                        Snack.amount += 50;
                        Database.UpdateItem(Snack);
                    }
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 50x " + RageAPI.GetHexColorcode(255, 255, 255) + "Heiße - Schokolade");
                }
                else if (Day == 15)
                {
                    Database.SetVIPStats((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "TOP DONATOR", 2);
                    player.SendChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_TOP_DONATOR + RageAPI.GetHexColorcode(255, 255, 255) + " für 2 Tage bekommen!");
                    player.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else if (Day == 16)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 12500);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 12.500$");
                }
                else if (Day == 19)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 15000);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 15.000$");
                }
                else if (Day == 20)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 5000);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 5.000$ + 10 Schneebälle");
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SNOWBALL, Constants.ITEM_ART_WAFFE, 10, true);
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
                    IVehicle.owner = player.GetVnXName<string>();
                    IVehicle.plate = string.Empty;
                    IVehicle.price = 0;
                    IVehicle.parking = 0;
                    IVehicle.parked = 0;
                    IVehicle.gas = 50.0f;
                    IVehicle.kms = 0.0f;

                    // Create the IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann eine " + RageAPI.GetHexColorcode(0, 200, 255) + " Sanchez :).");
                }
                else if (Day == 21)
                {
                    Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MP5, Constants.ITEM_ART_WAFFE, 300, false);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann eine " + RageAPI.GetHexColorcode(0, 200, 255) + " Mp5 :).");
                }
                else if (Day == 22)
                {
                    Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MP5, Constants.ITEM_ART_WAFFE, 300, false);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 75000);
                    Database.SetVIPStats((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "TOP DONATOR", 7);
                    player.SendChatMessage("Du hast VIP - " + premium.viplevels.VIPLEVELS.VIP_TOP_DONATOR + RageAPI.GetHexColorcode(255, 255, 255) + " für 7 Tage bekommen!");
                    player.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Heute ist Solids Geburtstag :D Gönn dir ruhig mal auf sein nacken 75.000$ + 7 Tage TOP Donator ;).");
                }
                else if (Day == 23)
                {
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 25000);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann " + RageAPI.GetHexColorcode(0, 200, 255) + " 25.000$");
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
                    IVehicle.owner = player.GetVnXName<string>();
                    IVehicle.plate = string.Empty;
                    IVehicle.price = 0;
                    IVehicle.parking = 0;
                    IVehicle.parked = 0;
                    IVehicle.gas = 50.0f;
                    IVehicle.kms = 0.0f;

                    // Create the IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                    player.SendChatMessage("Heute schenkt dir der Weihnachtsmann einen NAGEL NEUEN COMET! Gönn dir! Frohe Weihnachten " + RageAPI.GetHexColorcode(0, 200, 255) + " VenoX " + RageAPI.GetHexColorcode(200, 0, 0) + "<3");

                }
                player.vnxSetElementData(EntityData.PLAYER_ADVENTSKALENEDER, Day);
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("OnAdventskalenderClickServer")]
        public static void OnAdventskalenderClick(IPlayer player, int value)
        {
            try
            {
                if (DateTime.Now.Day == value && DateTime.Now.Month == 12)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADVENTSKALENEDER) != DateTime.Now.Day)
                    {
                        GivePlayerPresent(player, value);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits das heutige Türchen geöffnet.");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Wir haben nicht den " + value + ". Dezember!");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("OnChristmasMarketClickServer")]
        public static void OnChristmasMarketClickServer(IPlayer player, int v)
        {
            try
            {
                if (v == 1)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 12)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // Schockolade
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SCHOKOLADE, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 12);
                }
                else if (v == 2)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 17)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // Cookies
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_COOKIES, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 17);
                }
                else if (v == 3)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 34)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // Lebkuchen
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_LEBKUCHENMAENNCHEN, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 34);
                }
                else if (v == 4)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 60)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // sparerips
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SPARERIPS, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 60);
                }
                else if (v == 5)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 15)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // gluehwein
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_GLUEHWEIN, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 15);
                }
                else if (v == 6)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 6)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // milk
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MILCH, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 6);
                }
                else if (v == 7)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 12)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    // hotchocolate
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_HEISSESCHOKOLADE, Constants.ITEM_ART_NUTZ_ITEM, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 12);
                }
                else if (v == 8)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < 75)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SNOWBALL, Constants.ITEM_ART_WAFFE, 1, true);
                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 75);
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GET225);
                }
            }
            catch { }
        }

    }
}
