﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.jobs;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Anti_Cheat;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Globals
{
    public class Main : IScript
    {
        public static List<ClothesModel> clothesList;
        public static List<TattooModel> tattooList;
        public static List<TunningModel> tunningList;
        public static List<FactionAllroundModel> FactionAllroundList;
        public static Timer minuteTimer;
        public static Timer OnTickTimer;
        public static Timer ScoreboardTimer;
        public static Position GetHouseIplExit(string ipl)
        {
            try
            {
                Position position = new Position(0, 0, 0);
                foreach (HouseIplModel iplModel in Constants.HOUSE_IPL_LIST)
                {
                    if (iplModel.ipl == ipl)
                    {
                        position = iplModel.position;
                        break;
                    }
                }
                return position;
            }
            catch { return new Position(0, 0, 0); }
        }

        public static VehicleModel GetClosestIVehicle(Client player, float distance = 3.5f)
        {
            try
            {
                VehicleModel vehicle = null;
                foreach (VehicleModel veh in Alt.GetAllVehicles())
                {
                    Position vehPos = veh.Position;
                    float distanceIVehicleToPlayer = player.Position.Distance(vehPos);

                    if (distanceIVehicleToPlayer < distance && player.Dimension == veh.Dimension)
                    {
                        distance = distanceIVehicleToPlayer;
                        vehicle = veh;
                    }
                }
                return vehicle;
            }
            catch { return null; }
        }

        public static int GetTotalSeconds()
        {
            return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }



        public static int WEATHER_COUNTER = 0;
        public static int WEATHER_CURRENT = 0; // Aktuelles Wetter
        public static int GetRandomWeather(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }

        public static void OnUpdate()
        {
            gangwar.Allround.OnUpdate();
            Fun.Aktionen.Shoprob.Shoprob.OnUpdate();
            environment.Weed.Main.OnUpdate();
            environment.NPC.NPC.OnUpdate();
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, Client player)
        {
            try
            {
                Environment.Gzone.Zone.OnPlayerExitColShapeModel(shape, player);
            }
            catch { }
        }

        public static void OnPlayerEnterColShapeModel(IColShape shape, IEntity entity)
        {
            try
            {
                if (entity is Client player)   //We Check if the Entity is the player.
                {
                    CarShop.OnPlayerEnterColShapeModel(shape, player);
                    Clothes.Clothes.OnPlayerEnterColShapeModel(shape, player);
                    Environment.ammunation.Ammunation.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Rathaus.Führerschein.Führerschein.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Rathaus.Führerschein.LKW_Führerschein.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Rathaus.Führerschein.Motorrad_Führerschein.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Rathaus.Rathaus.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Gzone.Zone.OnPlayerEnterColShapeModel(shape, player);
                    events.Christmas.Weihnachtsmarkt.Weihnachtsmarkt.OnPlayerEnterColShapeModel(shape, player);
                    Factions.LSPD.Arrest.OnPlayerEnterColShapeModel(shape, player);
                    Emergency.OnPlayerEnterColShapeModel(shape, player);
                    Allround.OnPlayerEnterColShapeModel(shape, player);
                    fraktionskassen.OnPlayerEnterColShapeModel(shape, player);
                    Fraktionswaffenlager.OnPlayerEnterColShapeModel(shape, player);
                    Fun.Aktionen.Kokain.KokainSell.OnPlayerEnterColShapeModel(shape, player);
                    Fun.Kokaintruck.OnPlayerEnterColShapeModel(shape, player);
                    Fun.Aktionen.SWT.Marker_WT.OnPlayerEnterColShapeModel(shape, player);
                    Fun.Aktionen.Shoprob.Shoprob.OnPlayerEnterColShapeModel(shape, player);
                    gangwar.Allround.OnPlayerEnterColShapeModel(shape, player);
                    JoB_Allround.OnPlayerEnterColShapeModel(shape, player);
                    Job.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.Verleih.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.PaynSpray.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.Tunning.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.Vehicles.OnPlayerEnterColShapeModel(shape, player);
                }
                Core.Debug.OutputDebugString("Entity : " + entity);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerEnterColShape", ex); }
        }




        public static void SyncWeather(Client player)
        {
            try
            {
                if (WEATHER_COUNTER >= 60)
                {
                    int weather = 0;
                    if (WEATHER_CURRENT == 9)
                    {
                        weather = 0;
                    }
                    else
                    {
                        //weather = 13;
                        weather = GetRandomWeather(0, 3);
                        if (weather == 0)
                        {
                            weather = 0;
                        }
                        else if (weather == 1)
                        {
                            weather = 1;
                        }
                        else if (weather == 2)
                        {
                            weather = 9;
                        }
                    }
                    WEATHER_COUNTER = 0;
                    WEATHER_CURRENT = weather;

                    player.SetWeather((AltV.Net.Enums.WeatherType)WEATHER_CURRENT);
                }
                else if (WEATHER_COUNTER < 60)
                {
                    player.SetWeather((AltV.Net.Enums.WeatherType)WEATHER_CURRENT);
                    WEATHER_COUNTER += 1;
                }
                if (Fun.Allround.AktionsTimer <= DateTime.Now)
                {
                    Fun.Allround.ChangeAktionsState(false);
                }
            }
            catch { }
        }

        public static void OnMinuteSpentReallifeGM(Client player)
        {
            try
            {
                if (player.Playing)
                {
                    int played = player.Played;
                    if (played > 0 && played % 60 == 0)
                    {

                        // Generate the payday
                        GeneratePlayerPayday(player);
                    }
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PLAYED, played + 1);

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) > 0)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) - 1);

                    }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) == 30)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) == 10)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                    }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) <= 20)
                    {
                        player.Health -= 5;
                    }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) == 5)
                    {
                        player.SendTranslatedChatMessage("Du bist noch 5 Minuten im Knast");
                    }


                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                    {
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) - 1);
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) == 0)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = 0;
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KAUTION, 0);
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        }
                    }
                    anzeigen.Usefull.VnX.SavePlayerDatas(player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnMinuteSpentReallifeGM] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnMinuteSpentReallifeGM] " + ex.StackTrace);
            }
        }

        public static void OnMinuteSpentTacticGM(Client player)
        {
            try
            {
                int played = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED);
                if (played > 0 && played % 60 == 0)
                {
                    GeneratePlayerPayday(player);
                }
                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PLAYED, played + 1);

                anzeigen.Usefull.VnX.SavePlayerDatas(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.StackTrace);
            }
        }

        public static void OnMinuteSpentZombieGM(Client player)
        {
            try
            {
                int played = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED);
                if (played > 0 && played % 60 == 0)
                {
                    GeneratePlayerPayday(player);
                }
                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PLAYED, played + 1);


                anzeigen.Usefull.VnX.SavePlayerDatas(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.StackTrace);
            }
        }

        public static void OnMinuteSpent(object unused)
        {
            try
            {
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 55)
                {
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in 5 Minuten!");
                }
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59)
                {
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in einer Minute!");
                }
                foreach (Client player in Alt.GetAllPlayers())
                {
                    if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                    {
                        OnMinuteSpentReallifeGM(player);
                    }
                    if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Tactics)
                    {
                        OnMinuteSpentTacticGM(player);
                    }
                    if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Zombies)
                    {
                        OnMinuteSpentZombieGM(player);
                    }
                    player.SetDateTime(DateTime.Now);
                    SyncWeather(player);
                }
                Fun.Aktionen.Shoprob.Shoprob.OnMinuteSpend();
                anzeigen.Usefull.VnX.SaveIVehicleDatas();
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpent = OK!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION Global_OnMinuteSpent] " + ex.Message);
                Console.WriteLine("[EXCEPTION Global_OnMinuteSpent] " + ex.StackTrace);
            }
        }

        public static bool CheckBadElementDatas(string elementdata)
        {
            return elementdata switch
            {
                VenoXV.Globals.EntityData.PLAYER_MONEY => true,
                EntityData.PLAYER_ADMIN_RANK => true,
                _ => false,
            };
        }

        [ClientEvent("Store_Delayed_Element_Data_INT")]
        public static void Store_Delayed_ElementData_INT(Client player, string elementdata, int value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.vnxSetStreamSharedElementData(elementdata, value);
            }
            catch { }
        }

        [ClientEvent("Store_Delayed_Element_Data_STRING")]
        public static void Store_Delayed_ElementData_INT(Client player, string elementdata, string value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.vnxSetElementData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch { }
        }

        [ClientEvent("Store_Delayed_Element_Data_BOOL")]
        public static void Store_Delayed_ElementData_BOOL(Client player, string elementdata, bool value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.vnxSetElementData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch { }
        }

        public static void GeneratePlayerPayday(Client player)
        {
            try
            {
                int total = 0;
                int bank = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK);
                int playerRank = player.Reallife.FactionRank;
                int playerFaction = player.Reallife.Faction;
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                Client VipL = Database.GetPlayerVIP(player, (int)player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));

                if (player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 0)
                {
                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) - 1);
                }
                if (playerFaction > 0)
                {
                    foreach (FactionModel faction in Constants.FACTION_RANK_LIST)
                    {
                        if (faction.faction == playerFaction && faction.rank == playerRank)
                        {
                            total += faction.salary;
                            break;
                        }
                    }
                }
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Gehalt : " + RageAPI.GetHexColorcode(255, 255, 255) + +total + " $");


                int gwboni = 0;
                foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.IDOwner == player.Reallife.Faction)
                    {
                        gwboni += 250;
                    }
                }

                total += gwboni;

                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " GW-Boni : " + RageAPI.GetHexColorcode(255, 255, 255) + +gwboni + " $");

                int bankInterest = (int)Math.Round(bank * 0.001);
                total += bankInterest;
                if (bankInterest > 0)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Bankzinsen : " + RageAPI.GetHexColorcode(255, 255, 255) + +bankInterest + " $");
                }

                foreach (VehicleModel Vehicle in Alt.GetAllVehicles())
                {
                    AltV.Net.Enums.VehicleModel IVehicleHass = (AltV.Net.Enums.VehicleModel)Vehicle.Model;
                    if (Vehicle.Owner == player.Username && Vehicle.Save != true)
                    {

                        int IVehicleTaxes = (int)Math.Round((int)Vehicle.Price * Constants.TAXES_IVehicle);
                        int IVehicleTaxes_ = 0;
                        if (VipL.Vip_BisZum > DateTime.Now)
                        {
                            string Paket = VipL.Vip_Paket;
                            if (Paket == "Silber")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * Constants.VIP_BONI_AUTOSTEUER_SILVER);
                            }
                            else if (Paket == "Gold")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * Constants.VIP_BONI_AUTOSTEUER_GOLD);
                            }
                            else if (Paket == "UltimateRed")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * Constants.VIP_BONI_AUTOSTEUER_ULTIMATERED);
                            }
                            else if (Paket == "Platin")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * Constants.VIP_BONI_AUTOSTEUER_PLATIN);
                            }
                            else if (Paket == "TOP DONATOR")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * Constants.VIP_BONI_AUTOSTEUER_TOPDONATOR);
                            }
                        }

                        int IVehicleId = Vehicle.ID;
                        //string VehicleModel vehicle = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_MODEL);
                        //string IVehiclePlate = Vehicle.Plate == string.Empty ? "LS " + (1000 + IVehicleId) : Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_PLATE);
                        //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " VIP Fahrzeugsteuer Abzug : " + RageAPI.GetHexColorcode(255, 255, 255) + +IVehicleTaxes_ + "$");
                        //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Fahrzeugsteuer : " + RageAPI.GetHexColorcode(255, 255, 255) + VehicleModel + " (" + IVehiclePlate + "): - " + IVehicleTaxes + " $");
                        total -= IVehicleTaxes;
                        total += IVehicleTaxes_;
                    }
                }
                if (House.houseList != null)
                {
                    // House taxes
                    foreach (HouseModel house in House.houseList)
                    {
                        if (house.owner == player.Username)
                        {
                            int houseTaxes = (int)Math.Round((int)house.price * Constants.TAXES_HOUSE);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Immobiliensteuer :  " + RageAPI.GetHexColorcode(255, 255, 255) + house.name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if (house.id == player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE))
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Miete " + house.name + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +house.rental + "$");
                            Database.TransferMoneyToPlayer(house.owner, house.rental);
                            total -= house.rental;
                        }
                    }
                }
                int VIPBONI = 0;
                if (VipL.Vip_BisZum > DateTime.Now)
                {
                    string Paket = VipL.Vip_Paket;
                    if (Paket == "Bronze")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_BRONZE);
                    }
                    else if (Paket == "Silber")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_SILBER);
                    }
                    else if (Paket == "Gold")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_GOLD);
                    }
                    else if (Paket == "UltimateRed")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_RED);
                    }
                    else if (Paket == "Platin")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_PLATIN);
                    }
                    else if (Paket == "TOP DONATOR")
                    {
                        VIPBONI = (int)Math.Round(total * Constants.VIP_BONI_TOP);
                    }
                }
                if (VIPBONI > 0)
                {
                    total += VIPBONI;
                }
                else if (VIPBONI < 100)
                {
                    total += 100;
                }
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " VIP Bonus : " + RageAPI.GetHexColorcode(255, 255, 255) + +VIPBONI + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendTranslatedChatMessage(Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                player.SendTranslatedChatMessage(Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 200, 255) + " Einnahmen insgesamt : " + RageAPI.GetHexColorcode(255, 255, 255) + +total + " $");

                if (total < 0)
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_BANK, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - Math.Abs(total));
                }
                else
                {
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_BANK, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) + total);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION GeneratePlayerPayday] " + ex.Message);
                Console.WriteLine("[EXCEPTION GeneratePlayerPayday] " + ex.StackTrace);
            }
        }


        public static TunningModel GetIVehicleTuningBySlot()
        {
            try
            {
                TunningModel tuning = null;
                foreach (TunningModel tuningslot in tunningList)
                {
                    //if (tuningslot.slot != tuningslotpara && tuningslot.ownerIdentifier == playerId && item.hash == hash)
                    //{
                    tuning = tuningslot;
                    //break;
                    //}
                }
                return tuning;
            }
            catch { return null; }
        }






        public static ItemModel GetPlayerItemModelFromHash(int playerId, string hash)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in anzeigen.Inventar.Main.CurrentOnlineItemList)
                {
                    if (item.ownerIdentifier == playerId && item.hash == hash)
                    {
                        itemModel = item;
                        break;
                    }
                }
                return itemModel;
            }
            catch { return null; }
        }




        public static List<ClothesModel> GetPlayerClothes(int playerId)
        {
            try
            {
                // Get a list with the player's clothes
                return clothesList.Where(c => c.player == playerId).ToList();
            }
            catch { return null; }
        }

        public static ClothesModel GetDressedClothesInSlot(int playerId, int type, int slot)
        {
            try
            {
                // Get the clothes in the selected slot
                return clothesList.FirstOrDefault(c => c.player == playerId && c.type == type && c.slot == slot && c.dressed);
            }
            catch { return null; }
        }

        public static List<string> GetClothesNames(List<ClothesModel> clothesList)
        {
            try
            {
                List<string> clothesNames = new List<string>();
                foreach (ClothesModel clothes in clothesList)
                {
                    foreach (BusinessClothesModel businessClothes in Constants.BUSINESS_CLOTHES_LIST)
                    {
                        if (businessClothes.clothesId == clothes.drawable && businessClothes.bodyPart == clothes.slot && businessClothes.type == clothes.type)
                        {
                            clothesNames.Add(businessClothes.description);
                            break;
                        }
                    }
                }
                return clothesNames;
            }
            catch { return null; }
        }

        public static void UndressClothes(int playerId, int type, int slot)
        {
            try
            {
                foreach (ClothesModel clothes in clothesList)
                {
                    if (clothes.player == playerId && clothes.type == type && clothes.slot == slot && clothes.dressed)
                    {
                        clothes.dressed = false;

                        // Update the clothes' state
                        Database.UpdateClothes(clothes);

                        break;
                    }
                }
            }
            catch { }
        }


        public static void OnResourceStart()
        {
            try
            {

                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//

                // IMMER ALS ERSTES VERBINDEN & STARTEN!!!
                Database.OnResourceStart();
                // IMMER ALS ERSTES VERBINDEN & STARTEN!!!


                //*///////////////////////////////////// BASIC LOADING ///////////////////////////////////////////////////*//
                // Interior Loading
                //ToDo: Requesting Offices NAPI.World.RequestIpl ("ex_dt1_02_office_02b");
                //ToDo: Requesting Offices NAPI.World.RequestIpl ("FINBANK");
                // Avoid player's respawn
                //NAPI.Server.SetAutoRespawnAfterDeath(false);
                //NAPI.Server.SetAutoSpawnOnConnect(false);
                // Disable global server chat
                //NAPI.Server.SetGlobalServerChat(false);
                // Interior list Loading ( Example : LSPD, Hospital Interior etc.)

                foreach (InteriorModel interior in Constants.INTERIOR_LIST)
                {
                    if (interior.blipId > 0)
                    {
                        Core.RageAPI.CreateBlip(interior.blipName, interior.entrancePosition, interior.blipId, interior.BlipRgba, true);
                    }

                    if (interior.captionMessage != string.Empty)
                    {
                        //interior.textLabel = //ToDo: ClientSide erstellen NAPI.
                        Core.RageAPI.CreateTextLabel(interior.captionMessage, interior.entrancePosition, 20.0f, 0.75f, 4, new int[] { interior.labelRgbaR, interior.labelRgbaG, interior.labelRgbaB, 255 }, 0);
                    }
                }

                minuteTimer = new Timer(OnMinuteSpent, null, 60000, 60000); // Payday Generation und alles was nach einer Minute passiert!
                OnTickTimer = new Timer(VenoXV.Globals.Main.OnUpdate, null, 50, 50); // Tick/OnUpdateEvent
                ScoreboardTimer = new Timer(_Globals_.Scoreboard.Scoreboard.Fill_Playerlist, null, 7000, 7000); // Scoreboard Updater.


                //*///////////////////////////////////// OTHER STUFF LOADING ///////////////////////////////////////////////////*//

                CarShop.OnResourceStart();
                Clothes.Clothes.OnResourceStart();
                Environment.ammunation.Ammunation.OnResourceStart();
                Factions.Allround.OnResourceStart(); // Label - Faction Loading !
                fraktionskassen.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                Fun.Allround.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                Job.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                premium.vnxcase.VenoXCases.OnResourceStart();
                Vehicles.PaynSpray.OnResourceStart();
                Vehicles.Tunning.OnResourceStart();
                Vehicles.Verleih.OnResourceStart();
                Vehicles.Vehicles.OnResourceStart();
                gangwar.Allround.OnResourceStart();
                weapons.Combat.OnResourceStart();
                Club.RussianClub.OnResourceStart();

                // 0,105,145 <----- Dunkler Rgba Code Blau !
                // 0,150,200 <----- Dunkler Rgba Code Mittelmäßig Helles Blau!
                // 0,200,255 <----- Dunkler Rgba Code Extrem Helles Blau!
                // 40,40,40,0.8 <----- Grau Rgba Code !
            }
            catch { }
        }


        public static void OnPlayerDisconnected(Client player, string type, string reason)
        {
            try
            {
                gangwar.Allround.OnPlayerDisconnected(player, type, reason);
                Fun.Aktionen.Shoprob.Shoprob.OnPlayerDisconnected(player, type, reason);
                anzeigen.Inventar.Main.OnPlayerDisconnect(player, type, reason);
                VenoXV.Globals.Main.RemovePlayerFromGamemodeList(player);
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    foreach (VehicleModel Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.Owner == player.Username && Vehicle.Faction == Constants.FACTION_NONE)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                            /* ToDo : Fix if (Vehicle.Occupants.Count > 0)
                             {
                                 var playersInCar = NAPI.Vehicle.GetIVehicleOccupants(Vehicle);
                                 var Player = Vehicle.Get
                                 foreach (var spielerimauto in playersInCar)
                                 {
                                     spielerimauto.WarpOutOfIVehicle();
                                     spielerimauto.Dimension = 0;
                                 }

                             }*/
                        }
                        // JOB 
                        if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_IN_JOB) == true)
                        {
                            if (
                            //LieferrantenJobIVehicle
                            Vehicle.Job == Constants.JOB_CITY_TRANSPORT && Vehicle.Owner == player.Username
                            //Airport ToDo
                            || Vehicle.Job == Constants.JOB_AIRPORT && Vehicle.Owner == player.Username
                            || Vehicle.Job == Constants.JOB_BUS && Vehicle.Owner == player.Username
                            )
                            {
                                if (Vehicle != null)
                                {
                                    Vehicle.Dimension = Constants.VEHICLE_JOB_OFFLINE_DIM;
                                }
                                if (JoB_Allround.JobAbgabeMarker != null)
                                {
                                    if (JoB_Allround.JobAbgabeMarker.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) == player.Username)
                                    {
                                        RageAPI.RemoveColShape(JoB_Allround.JobAbgabeMarker);
                                    }
                                }
                            }
                        }
                        else if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.Owner == player.Username)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_JOB_OFFLINE_DIM;
                        }

                    }
                    foreach (Client players in Alt.GetAllPlayers())
                    {
                        if (players.Dimension == Constants.VEHICLE_OFFLINE_DIM)
                        {
                            players.Dimension = 0;
                        }
                    }

                    anzeigen.Usefull.VnX.SavePlayerDatas(player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION Global_OnPlayerDisconnected] " + ex.Message);
                Console.WriteLine("[EXCEPTION Global_OnPlayerDisconnected] " + ex.StackTrace);
            }
        }


        //[AltV.Net.ClientEvent("checkPlayerEventKey")]
        [ClientEvent("checkPlayerEventKey")]
        public void CheckPlayerEventKeyEvent(Client player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {

                    if (Allround.IsNearFactionTeleporter(player))
                    {
                        return;
                    }
                    // Check if the player's in any interior
                    foreach (InteriorModel interior in Constants.INTERIOR_LIST)
                    {
                        if (player.Position.Distance(interior.entrancePosition) < 1.5f)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                            player.SetPosition = interior.exitPosition;
                            return;
                        }
                        else if (player.Position.Distance(interior.exitPosition) < 1.5f)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                            player.SetPosition = interior.entrancePosition;
                            return;
                        }
                    }

                    // Check if the player's close to an ATM
                    for (int i = 0; i < Constants.ATM_LIST.Count; i++)
                    {
                        if (player.Position.Distance(Constants.ATM_LIST[i]) <= 1.5f)
                        {
                            Alt.Server.TriggerClientEvent(player, "showATM", player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK), "Kontoauszüge", "Kontoauszüge", "Kontoauszüge Folgen", "Überweisen", "Überweisen", "Überweisen");
                            return;
                        }
                    }


                    // Check if the player's in any house
                    if (House.houseList != null)
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (player.Position.Distance(house.position) <= 1.5f && player.Dimension == house.Dimension)
                            {
                                AntiCheat_Allround.SetTimeOutTeleport(player, 8000);
                                if (!House.HasPlayerHouseKeys(player, house) && house.locked)
                                {
                                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Das Haus ist abgeschlossen!");
                                }
                                else
                                {

                                    player.SetPosition = GetHouseIplExit(house.ipl);
                                    player.Dimension = house.id;

                                    player.vnxSetElementData(EntityData.PLAYER_IPL, house.ipl);
                                    player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, house.id);
                                }
                                return;
                            }
                            else if (player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED) == house.id)
                            {
                                AntiCheat_Allround.SetTimeOutTeleport(player, 1250);
                                Position exitPosition = House.GetHouseExitPoint(house.ipl);
                                if (player.Position.Distance(exitPosition) < 2.5f)
                                {
                                    /*if (!House.HasPlayerHouseKeys(player, house) && house.locked)
                                    {
                                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Das Haus ist abgeschlossen!");
                                    }*/
                                    player.SetPosition = house.position;
                                    player.Dimension = 0;
                                    player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                                    /*
                                    foreach (Client target in Alt.GetAllPlayers())
                                    {
                                        if (target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) && target.vnxGetElementData(EntityData.PLAYER_IPL) && target != player)
                                        {
                                            if (target.vnxGetElementData(EntityData.PLAYER_IPL) == house.ipl)
                                            {
                                                return;
                                            }
                                        }
                                    }*/
                                    //NAPI.World.RemoveIpl(house.ipl);

                                }
                                return;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("reset_drug_state")]
        public static void ResetDrugState(Client player, int drug)
        {
            try
            {
                if (drug == 1)
                {
                    player.vnxSetElementData(EntityData.PLAYER_KOKS_MODUS_AKTIV, false);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("getPlayerTattoos")]
        public void GetPlayerTattoosEvent(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                int targetId = target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                List<TattooModel> playerTattooList = tattooList.Where(t => t.player == targetId).ToList();
                Alt.Server.TriggerClientEvent(player, "updatePlayerTattoos", JsonConvert.SerializeObject(playerTattooList), target);
            }
            catch { }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Der Spieler der Definiert wird.</param>
        /// <param name="ItemHash">Item - Hash in Constants.cs</param>
        /// <param name="ItemArt">Waffe, Magazin,Fallschirm, Business, NUTZ_ITEM, Drogen</param>
        /// <param name="ItemAmount">Item Anzahl! Sollte der Spieler das Item besitzen , so wird es Addiert!</param>
        public static void GivePlayerItem(Client player, string ItemHash, string ItemArt, int ItemAmount, bool AddierenFallsVorhanden)
        {
            try
            {
                int playerId = player.UID;
                if (playerId > 0)
                {
                    ItemModel Item = Main.GetPlayerItemModelFromHash(playerId, ItemHash);
                    {
                        if (Item == null)
                        {
                            Item = new ItemModel
                            {
                                amount = ItemAmount,
                                dimension = 0,
                                position = new Position(0.0f, 0.0f, 0.0f),
                                hash = ItemHash,
                                ownerIdentifier = playerId,
                                ITEM_ART = ItemArt,
                                objectHandle = null
                            };
                            Item.id = Database.AddNewItem(Item);
                            anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Item);
                        }
                        else
                        {
                            if (AddierenFallsVorhanden)
                            {
                                Item.amount += ItemAmount;
                                Database.UpdateItem(Item);
                            }
                            else
                            {
                                Item.amount = ItemAmount;
                                Database.UpdateItem(Item);
                            }
                        }
                    }
                    if (ItemArt == Constants.ITEM_ART_WAFFE)
                    {
                        AltV.Net.Enums.WeaponModel weapon = AltV.Net.Enums.WeaponModel.Fist;
                        switch (ItemHash)
                        {
                            case Constants.ITEM_HASH_SNOWBALL:
                                weapon = AltV.Net.Enums.WeaponModel.Snowballs;
                                break;
                            case Constants.ITEM_HASH_HAMMER:
                                weapon = AltV.Net.Enums.WeaponModel.Hammer;
                                break;
                            case Constants.ITEM_HASH_NIGHTSTICK:
                                weapon = AltV.Net.Enums.WeaponModel.Nightstick;
                                break;
                            case Constants.ITEM_HASH_BASEBALL:
                                weapon = AltV.Net.Enums.WeaponModel.BaseballBat;
                                break;
                            case Constants.ITEM_HASH_SWITCHBLADE:
                                weapon = AltV.Net.Enums.WeaponModel.Switchblade;
                                break;
                            case Constants.ITEM_HASH_BROKENBOTTLE:
                                weapon = AltV.Net.Enums.WeaponModel.BrokenBottle;
                                break;
                            case Constants.ITEM_HASH_TAZER:
                                weapon = AltV.Net.Enums.WeaponModel.StunGun;
                                break;
                            case Constants.ITEM_HASH_VINTAGEPISTOL:
                                weapon = AltV.Net.Enums.WeaponModel.VintagePistol;
                                break;
                            case Constants.ITEM_HASH_PISTOLE:
                                weapon = AltV.Net.Enums.WeaponModel.Pistol;
                                break;
                            case Constants.ITEM_HASH_REVOLVER:
                                weapon = AltV.Net.Enums.WeaponModel.HeavyRevolver;
                                break;
                            case Constants.ITEM_HASH_PISTOLE50:
                                weapon = AltV.Net.Enums.WeaponModel.Pistol50;
                                break;
                            case Constants.ITEM_HASH_SHOTGUN:
                                weapon = AltV.Net.Enums.WeaponModel.PumpShotgun;
                                break;
                            case Constants.ITEM_HASH_MINISMG:
                                weapon = AltV.Net.Enums.WeaponModel.MiniSMG;
                                break;
                            case Constants.ITEM_HASH_MP5:
                                weapon = AltV.Net.Enums.WeaponModel.SMG;
                                break;
                            case Constants.ITEM_HASH_PDW:
                                weapon = AltV.Net.Enums.WeaponModel.CombatPDW;
                                break;
                            case Constants.ITEM_HASH_KARABINER:
                                weapon = AltV.Net.Enums.WeaponModel.CarbineRifle;
                                break;
                            case Constants.ITEM_HASH_ADVANCEDRIFLE:
                                weapon = AltV.Net.Enums.WeaponModel.AdvancedRifle;
                                break;
                            case Constants.ITEM_HASH_AK47:
                                weapon = AltV.Net.Enums.WeaponModel.AssaultRifle;
                                break;
                            case Constants.ITEM_HASH_RIFLE:
                                weapon = AltV.Net.Enums.WeaponModel.Musket;
                                break;
                            case Constants.ITEM_HASH_SNIPERRIFLE:
                                weapon = AltV.Net.Enums.WeaponModel.SniperRifle;
                                break;
                        }

                        if (weapon != AltV.Net.Enums.WeaponModel.Fist)
                        {
                            // Wir geben dem Spieler seine Waffe :P
                            RageAPI.GivePlayerWeapon(player, weapon, ItemAmount);
                        }
                    }
                    else if (ItemArt == Constants.ITEM_ART_MAGAZIN)
                    {
                        ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                        ItemModel Pistol = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                        ItemModel Pistol50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                        ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                        if (Vintage != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.VintagePistol, Item.amount);
                        }
                        else if (Pistol != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol, Item.amount);
                        }
                        else if (Pistol50 != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol50, Item.amount);
                        }
                        else if (Revolver != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.HeavyRevolver, Item.amount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION GivePlayerItem] " + ex.Message);
                Console.WriteLine("[EXCEPTION GivePlayerItem] " + ex.StackTrace);
            }
        }

        /*
        [Command("inventory")]
        public void InventoryCommand(PlayerModel player)
        {
            if (GetPlayerInventoryTotal(player) > 0)
            {
                List<InventoryModel> inventory = GetPlayerInventory(player);
                Alt.Server.TriggerClientEvent(player,"showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
            }
            else
            {
                //player.SendTranslatedChatMessage(Constants.Rgba_ERROR + ErrRes.no_items_inventory);
            }
        }*/





        /* [Command("klamotten")]
         public void ComplementCommand(PlayerModel player, string type, string action)
         {
             ClothesModel clothes = null;
             int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);

             if (action.ToLower() == "tragen" || action.ToLower() == "Anziehen")
             {
                 string action_tragen = "tragen";
                 string action_ausziehen = "ausziehen";
                 switch (type.ToLower())
                 {
                     case "masken":
                         clothes = GetDressedClothesInSlot(playerId, 0, Constants.CLOTHES_MASK);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.CLOTHES_MASK && c.type == 0).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_MASK_BOUGHT);
                                 }
                                 else
                                 {
                                     //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_MASK_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_MASK_EQUIPED);
                             }
                             else
                             {
                                 //ToDo Sie Clientseitig Laden! : player.SetClothes(Constants.CLOTHES_MASK, 0, 0);
                                 UndressClothes(playerId, 0, Constants.CLOTHES_MASK);
                             }
                         }
                         break;
                     case Messages.ARG_BAG:
                         clothes = GetDressedClothesInSlot(playerId, 0, Constants.CLOTHES_BAGS);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.CLOTHES_BAGS && c.type == 0).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_BAG_BOUGHT);
                                 }
                                 else
                                 {
                                     //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_BAG_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_BAG_EQUIPED);
                             }
                             else
                             {
                                 //ToDo Sie Clientseitig Laden! : player.SetClothes(Constants.CLOTHES_BAGS, 0, 0);
                                 UndressClothes(playerId, 0, Constants.CLOTHES_BAGS);
                             }
                         }
                         break;
                     case Messages.ARG_ACCESSORY:
                         clothes = GetDressedClothesInSlot(playerId, 0, Constants.CLOTHES_ACCESSORIES);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.CLOTHES_ACCESSORIES && c.type == 0).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_ACCESSORY_BOUGHT);
                                 }
                                 else
                                 {
                                     //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_ACCESSORY_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_ACCESSORY_EQUIPED);
                             }
                             else
                             {
                                 //ToDo Sie Clientseitig Laden! : player.SetClothes(Constants.CLOTHES_ACCESSORIES, 0, 0);
                                 UndressClothes(playerId, 0, Constants.CLOTHES_ACCESSORIES);
                             }
                         }
                         break;
                     case Messages.ARG_HAT:
                         clothes = GetDressedClothesInSlot(playerId, 1, Constants.ACCESSORY_HATS);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.ACCESSORY_HATS && c.type == 1).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_HAT_BOUGHT);
                                 }
                                 else
                                 {
                                     player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_HAT_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_HAT_EQUIPED);
                             }
                             else
                             {
                                 if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_HATS, 57, 0);
                                 }
                                 else
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_HATS, 8, 0);
                                 }
                                 UndressClothes(playerId, 1, Constants.ACCESSORY_HATS);
                             }
                         }
                         break;
                     case Messages.ARG_GLASSES:
                         clothes = GetDressedClothesInSlot(playerId, 1, Constants.ACCESSORY_GLASSES);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.ACCESSORY_GLASSES && c.type == 1).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_GLASSES_BOUGHT);
                                 }
                                 else
                                 {
                                     player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_GLASSES_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_GLASSES_EQUIPED);
                             }
                             else
                             {
                                 if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_GLASSES, 5, 0);
                                 }
                                 else
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_GLASSES, 0, 0);
                                 }
                                 UndressClothes(playerId, 1, Constants.ACCESSORY_GLASSES);
                             }
                         }
                         break;
                     case Messages.ARG_EARRINGS:
                         clothes = GetDressedClothesInSlot(playerId, 1, Constants.ACCESSORY_EARS);
                         if (action.ToLower() == Messages.ARG_WEAR)
                         {
                             if (clothes == null)
                             {
                                 clothes = GetPlayerClothes(playerId).Where(c => c.slot == Constants.ACCESSORY_EARS && c.type == 1).First();
                                 if (clothes == null)
                                 {
                                     player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_EAR_BOUGHT);
                                 }
                                 else
                                 {
                                     player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                 }
                             }
                             else
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_EAR_EQUIPED);
                             }
                         }
                         else
                         {
                             if (clothes == null)
                             {
                                 player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_EAR_EQUIPED);
                             }
                             else
                             {
                                 if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_EARS, 12, 0);
                                 }
                                 else
                                 {
                                     player.SetAccessories(Constants.ACCESSORY_EARS, 3, 0);
                                 }
                                 UndressClothes(playerId, 1, Constants.ACCESSORY_EARS);
                             }
                         }
                         break;
                     default:
                         player.SendTranslatedChatMessage(Constants.Rgba_HELP + Messages.GEN_COMPLEMENT_COMMAND);
                         break;
                 }
             }
             else
             {
                 player.SendTranslatedChatMessage(Constants.Rgba_HELP + Messages.GEN_COMPLEMENT_COMMAND);
             }
         }*/
    }
}
