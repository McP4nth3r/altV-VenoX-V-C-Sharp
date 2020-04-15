//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV.Anti_Cheat;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.house;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.factions
{
    public class Spawn : IScript
    {

        //[AltV.Net.ClientEvent("SpawnPlayer_On_Spawnpoint")]
        public static void spawnplayer_on_spawnpoint(IPlayer player)
        {
            try
            {
                AntiCheat_Allround.SetTimeOutHealth(player, 1000);

                player.SpawnPlayer(player.Position);
                player.vnxSetElementData(EntityData.PLAYER_KILLED, 0);
                /*if (player.vnxGetElementData("EVENTINFOGOTVNX") != 1)
                {
                    player.SendChatMessage( "------------" + RageAPI.GetHexColorcode(0,200,255) + " EVENT INFORMATION" + RageAPI.GetHexColorcode(255,255,255) + "------------");
                    player.SendChatMessage( "Bis zum 23.09 - 10:00 Uhr gibt es " + RageAPI.GetHexColorcode(0,150,200) + "DREIFACHEN " + RageAPI.GetHexColorcode(255,255,255) + "PAYDAY.");
                    player.SendChatMessage( "Abgesehen davon gibt es " + RageAPI.GetHexColorcode(0,150,200) + "125.000$ " + RageAPI.GetHexColorcode(255,255,255) + " + FREE VIP UPGRADE bei unserem Quest System.");
                    player.SendChatMessage( "Du willst neue Freunde finden? Dann trete heute noch einer " + RageAPI.GetHexColorcode(0,150,200) + "Fraktion " + RageAPI.GetHexColorcode(255,255,255) + "bei!");
                    player.SendChatMessage( "------------" + RageAPI.GetHexColorcode(0,200,255) + " EVENT INFORMATION" + RageAPI.GetHexColorcode(255,255,255) + "------------");
                    player.vnxSetStreamSharedElementData( "EVENTINFOGOTVNX", 1);
                    Core.VnX.SetDelayedINTSharedData(player, "EVENTINFOGOTVNX", 0, 2000);
                }*/
                player.vnxSetStreamSharedElementData( EntityData.PLAYER_HUNGER, 100);
                AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                player.Emit("start_screen_fx", "RaceTurbo", 2000, false);
                dxLibary.VnX.CreateDiscordUpdate(player, "Spawnt auf VenoX", "VenoX - Reallife");
                player.Emit("VnX:ShowChat", true);
                /*if (player.vnxGetElementData<bool>("ACCOUNT_VORHANDEN") == false)
                {
                    player.Position = new Position(152.26f, -1004.47f, -99.00f);
                    return;
                }*/
                if (Database.FindCharakterPrison(player.GetVnXName<string>()))
                {
                    int PrisonTime = Database.GetCharakterPrisonTime(player.GetVnXName<string>());
                    string Grund = Database.GetCharakterPrisonReason(player.GetVnXName<string>());
                    string AdminVon = Database.GetCharakterPrisonAdminBy(player.GetVnXName<string>());
                    DateTime ErstelltAm = Database.GetCharakterPrisonErstelltAm(player.GetVnXName<string>());
                    if (PrisonTime > 0)
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Du bist noch " + PrisonTime + " Minuten im Prison!");
                        player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Grund : " + Grund);
                        player.vnxSetElementData(EntityData.PLAYER_PRISON_TIME, PrisonTime);
                        player.vnxSetElementData(EntityData.PLAYER_PRISON_GRUND, Grund);
                        player.vnxSetElementData(EntityData.PLAYER_PRISON_VONADMIN, AdminVon);
                        player.vnxSetElementData(EntityData.PLAYER_PRISON_ErstelltVon, ErstelltAm);
                        player.Dimension = 0;
                        player.Position = new Position(1651.441f, 2569.83f, 45.56486f);
                        anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                        return;
                    }
                }

                string viplevel = player.vnxGetElementData<string>(EntityData.PLAYER_VIP_LEVEL);


                if (viplevel == "Bronze")
                {
                    player.Armor = 100;
                }
                else if (viplevel == "Silber")
                {
                    player.Armor = 100;

                    ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                    if (Kanister == null) // Kanister
                    {
                        Kanister = new ItemModel();
                        Kanister.amount = 5;
                        Kanister.dimension = 0;
                        Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                        Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                        Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Kanister.ITEM_ART = "NUTZ_ITEM";
                        Kanister.objectHandle = null;

                        Kanister.id = Database.AddNewItem(Kanister);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    }
                    else
                    {
                        if (Kanister.amount + 5 > 10)
                        {
                            Kanister.amount = 10;
                        }
                        else
                        {
                            Kanister.amount = Kanister.amount + 5;
                        }
                        Database.UpdateItem(Kanister);
                    }
                }

                if (viplevel == "Gold")
                {
                    player.Armor = 100;

                    ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                    if (Kanister == null) // Kanister
                    {
                        Kanister = new ItemModel();
                        Kanister.amount = 10;
                        Kanister.dimension = 0;
                        Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                        Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                        Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Kanister.ITEM_ART = "NUTZ_ITEM";
                        Kanister.objectHandle = null;

                        Kanister.id = Database.AddNewItem(Kanister);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    }
                    else
                    {
                        Kanister.amount = 10;
                        Database.UpdateItem(Kanister);
                    }
                }


                if (viplevel == "UltimateRed")
                {
                    player.Armor = 100;

                    ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                    if (Kanister == null) // Kanister
                    {
                        Kanister = new ItemModel();
                        Kanister.amount = 10;
                        Kanister.dimension = 0;
                        Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                        Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                        Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Kanister.ITEM_ART = "NUTZ_ITEM";
                        Kanister.objectHandle = null;

                        Kanister.id = Database.AddNewItem(Kanister);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    }
                    else
                    {
                        Kanister.amount = 10;
                        Database.UpdateItem(Kanister);
                    }
                }


                if (viplevel == "Platin")
                {
                    player.Armor = 100;

                    ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_TANKSTELLENSNACK);
                    if (Kanister == null) // Kanister
                    {
                        Kanister = new ItemModel();
                        Kanister.amount = 10;
                        Kanister.dimension = 0;
                        Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                        Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                        Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Kanister.ITEM_ART = "NUTZ_ITEM";
                        Kanister.objectHandle = null;

                        Kanister.id = Database.AddNewItem(Kanister);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    }
                    else
                    {
                        Kanister.amount = 10;
                        Database.UpdateItem(Kanister);
                    }

                    if (Snack == null) // Snack
                    {
                        Snack = new ItemModel();
                        Snack.amount = 150;
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
                        Snack.amount = 150;
                        Database.UpdateItem(Snack);
                    }
                }
                if (viplevel == "TOP DONATOR")
                {

                    player.Armor = 100;

                    ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                    ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_TANKSTELLENSNACK);
                    if (Kanister == null) // Kanister
                    {
                        Kanister = new ItemModel();
                        Kanister.amount = 10;
                        Kanister.dimension = 0;
                        Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                        Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                        Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        Kanister.ITEM_ART = "NUTZ_ITEM";
                        Kanister.objectHandle = null;

                        Kanister.id = Database.AddNewItem(Kanister);
                        anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    }
                    else
                    {
                        Kanister.amount = 10;
                        Database.UpdateItem(Kanister);
                    }

                    if (Snack == null) // Snack
                    {
                        Snack = new ItemModel();
                        Snack.amount = 150;
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
                        Snack.amount = 150;
                        Database.UpdateItem(Snack);
                    }
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                {
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.Position = Constants.JAIL_SPAWNS[random.Next(3)];
                    player.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                    player.Emit("toggleHandcuffed", false);
                    return;
                }
                if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "noobspawn")
                {
                    // Noob Spawn
                    player.Position = new Position(-2286.745f, 356.3762f, 175.317f);
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Rathaus")
                {
                    player.Position = new Position(-533.1649f, -211.0938f, 37.64977f);
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Wuerfelpark")
                {
                    player.Position = new Position(180.3914f, -923.7885f, 30.68681f);
                }
                else
                {
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Basis")
                    {
                        //Dimension für Böse Fraktionen mit mehreren Gleichen interiors einstellen!.
                        if (Allround.isBadFaction(player))
                        {
                            player.Dimension = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                        }
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_POLICE)
                        {
                            //LSPD Spawn
                            player.Position = new Position(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_COSANOSTRA)
                        {
                            //Mafia Spawn
                            player.Position = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_YAKUZA)
                        {
                            player.Position = new Position(339.3727f, -997.0941f, -99.19626f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_TERRORCLOSED)
                        {
                            player.Position = new Position(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                        {
                            player.Position = new Position(-562.649f, -920.7836f, 23.87799f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_FBI)
                        {
                            player.Position = new Position(139.1606f, -762.1356f, 45.75201f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_MS13)
                        {
                            player.Position = new Position(-1283.504f, 432.7738f, 97.52215f);
                            player.Dimension = Constants.FACTION_MS13;
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_SAMCRO)
                        {
                            player.Position = new Position(982.0083f, -100.8747f, 74.84512f);
                            //player.Dimension = Constants.FACTION_SAMCRO;
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                        {
                            player.Dimension = Constants.FACTION_NONE;
                            player.Position = new Position(319.5905f, -560.0225f, 28.74378f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_BALLAS)
                        {
                            player.Position = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_GROVE)
                        {
                            player.Position = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "HOTELLS")
                    {

                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "HOTELLV")
                    {

                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "House")
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) > 0 || player.GetVnXName<string>() == house.owner)
                            {
                                AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                                player.Position = Main.GetHouseIplExit(house.ipl);
                                player.Dimension = house.id;
                                player.vnxSetElementData(EntityData.PLAYER_IPL, house.ipl);
                                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, house.id);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

    }
}
