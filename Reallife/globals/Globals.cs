using AltV.Net.Elements.Entities;
using VenoXV.Reallife.model;
using VenoXV.Reallife.house;
using VenoXV.Reallife.business;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.jobs;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System;
using VenoXV.Reallife.Core;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.database;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Data;
using Newtonsoft.Json;

namespace VenoXV.Reallife.Globals
{
    public class Main : IScript
    {
        public static List<ClothesModel> clothesList;
        public static List<TattooModel> tattooList;
        public static List<ItemModel> itemList;
        public static List<TunningModel> tunningList;
        public static List<LabelModel> LabelList = new List<LabelModel>();
        public static Timer minuteTimer;
        public static Timer OnTickTimer;
        public static Timer ScoreboardTimer;
        public const string CURRENT_VERSION = "1.1.2";



        public static Position GetHouseIplExit(string ipl)
        {
            try
            {
                Position position = new Position(0,0,0);
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

        public static IVehicle GetClosestIVehicle(IPlayer player, float distance = 3.5f)
        {
            try
            {
                IVehicle Vehicle = null;
                foreach (IVehicle veh in Alt.GetAllVehicles())
                {
                    Position vehPos = veh.Position;
                    float distanceIVehicleToPlayer = player.Position.Distance(vehPos);

                    if (distanceIVehicleToPlayer < distance && player.Dimension == veh.Dimension)
                    {
                        distance = distanceIVehicleToPlayer;
                        Vehicle = veh;
                    }
                }
                return Vehicle;
            }
            catch { return null; }
        }

        public static int GetTotalSeconds()
        {
            return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }



        public static int WEATHER_COUNTER = 0;
        public static int WEATHER_CURRENT = 13; // Aktuelles Wetter
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
        }

        public static void OnPlayerExitIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                Environment.Gzone.Zone.OnPlayerExitIColShape(shape, player);
            }
            catch { }
        }

        public static void OnPlayerEnterIColShape(IColShape shape, IEntity entity)
        {
            try
            {
                IPlayer player = entity as IPlayer;
                CarShop.OnPlayerEnterIColShape(shape, player);
                Clothes.Clothes.OnPlayerEnterIColShape(shape, player);
                Environment.ammunation.ammunation.OnPlayerEnterIColShape(shape, player);
                Environment.Rathaus.Führerschein.Führerschein.OnPlayerEnterIColShape(shape, player);
                Environment.Rathaus.Führerschein.LKW_Führerschein.OnPlayerEnterIColShape(shape, player);
                Environment.Rathaus.Führerschein.Motorrad_Führerschein.OnPlayerEnterIColShape(shape, player);
                Environment.Rathaus.Rathaus.OnPlayerEnterIColShape(shape, player);
                Environment.Gzone.Zone.OnPlayerEnterIColShape(shape, player);
                events.Christmas.Weihnachtsmarkt.Weihnachtsmarkt.OnPlayerEnterIColShape(shape, player);
                factions.LSPD.Arrest.OnPlayerEnterIColShape(shape, player);
                Emergency.OnPlayerEnterIColShape(shape, player);
                factions.Allround.OnPlayerEnterIColShape(shape, player);
                factions.fraktionskassen.OnPlayerEnterIColShape(shape, player);
                factions.Fraktionswaffenlager.OnPlayerEnterIColShape(shape, player);
                Fun.Aktionen.Kokain.KokainSell.OnPlayerEnterIColShape(shape, player);
                Fun.Kokaintruck.OnPlayerEnterIColShape(shape, player);
                Fun.Aktionen.SWT.Marker_WT.OnPlayerEnterIColShape(shape, player);
                Fun.Aktionen.Shoprob.Shoprob.OnPlayerEnterIColShape(shape, player);
                gangwar.Allround.OnPlayerEnterIColShape(shape, player);
                JoB_Allround.OnPlayerEnterIColShape(shape, player);
                jobs.Job.OnPlayerEnterIColShape(shape, player);
                Vehicles.paynspray.OnPlayerEnterIColShape(shape, player);
                Vehicles.Tunning.OnPlayerEnterIColShape(shape, player);
                Vehicles.Vehicles.OnPlayerEnterIColShape(shape, player);
                Vehicles.Verleih.OnPlayerEnterIColShape(shape, player);
            }
            catch { }
        }




        public static void SyncWeather(IPlayer player)
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

        public static void OnMinuteSpentReallifeGM(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    int played = player.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                    if (played > 0 && played % 60 == 0)
                    {

                        // Generate the payday
                        GeneratePlayerPayday(player);
                    }
                    player.SetData(EntityData.PLAYER_PLAYED, played + 1);

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) > 0)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) - 1);

                    }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) == 30)
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode( 200,0,0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                        dxLibary.VnX.DrawNotification(player, "warning", "Du bekommst hunger... Besorg dir was zu Essen!");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) == 10)
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode( 200,0,0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                        dxLibary.VnX.DrawNotification(player, "warning", "Du bekommst hunger... Besorg dir was zu Essen!");
                    }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) <= 20)
                    {
                        player.Health -= 5;
                    }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) == 5)
                    {
                        player.SendChatMessage("Du bist noch 5 Minuten im Knast");
                    }


                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                    {
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) - 1);
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) == 0)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.Position = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = 0;
                            Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_KAUTION, 0);
                            player.SendChatMessage( "{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
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

        public static void OnMinuteSpentTacticGM(IPlayer player)
        {
            try
            {
                int played = player.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                if (played > 0 && played % 60 == 0)
                {
                    GeneratePlayerPayday(player);
                }
                player.SetData(EntityData.PLAYER_PLAYED, played + 1);

                anzeigen.Usefull.VnX.SavePlayerDatas(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnMinuteSpentTacticGM] " + ex.StackTrace);
            }
        }        
        
        public static void OnMinuteSpentZombieGM(IPlayer player)
        {
            try
            {
                int played = player.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                if (played > 0 && played % 60 == 0)
                {
                    GeneratePlayerPayday(player);
                }
                player.SetData(EntityData.PLAYER_PLAYED, played + 1);


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
                    Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + "Server neustart in 5 Minuten!");
                }
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59)
                {
                    Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + "Server neustart in einer Minute!");
                }
                foreach (IPlayer player in Alt.GetAllPlayers())
                {
                    if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_REALLIFE)
                    {
                        OnMinuteSpentReallifeGM(player);
                    }                   
                    else if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        OnMinuteSpentTacticGM(player);
                    }                    
                    else if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_ZOMBIE)
                    {
                        OnMinuteSpentZombieGM(player);
                    }
                    SyncWeather(player);
                }
                Fun.Aktionen.Shoprob.Shoprob.OnMinuteSpend();
                anzeigen.Usefull.VnX.SaveIVehicleDatas();
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpent = OK!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[EXCEPTION Global_OnMinuteSpent] " + ex.Message);
                Console.WriteLine("[EXCEPTION Global_OnMinuteSpent] " + ex.StackTrace);
            }
        }



        //[AltV.Net.ClientEvent("Store_Delayed_Element_Data_INT")]
        public static void Store_Delayed_ElementData_INT(IPlayer player, string elementdata, int value)
        {
            try
            {
                VnX.vnxSetSharedData(player, elementdata, value);
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Store_Delayed_Element_Data_STRING")]
        public static void Store_Delayed_ElementData_INT(IPlayer player, string elementdata, string value)
        {
            try
            {
                player.SetData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Store_Delayed_Element_Data_BOOL")]
        public static void Store_Delayed_ElementData_BOOL(IPlayer player, string elementdata, bool value)
        {
            try
            {
                player.SetData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch { }
        }

        public static void GeneratePlayerPayday(IPlayer player)
        {
            try
            {
                int total = 0;
                int bank = player.vnxGetElementData<int>(EntityData.PLAYER_BANK);
                int playerRank = player.vnxGetElementData<int>(EntityData.PLAYER_RANK);
                int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                player.SendChatMessage(RageAPI.GetHexColorcode(0,150,200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                PlayerModel VipL = Database.GetPlayerVIP((int)player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID));

                if (player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 0)
                {
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_WANTEDS, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) - 1);
                    anzeigen.Usefull.VnX.UpdateHUD(player);
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
                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Gehalt : " + RageAPI.GetHexColorcode(255,255,255) +  + total + " $");


                int gwboni = 0;
                foreach(var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if(area.IDOwner == player.vnxGetElementData<int>(EntityData.PLAYER_FACTION))
                    {
                        gwboni += 250;
                    }
                }

                total += gwboni;

                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " GW-Boni : " + RageAPI.GetHexColorcode(255,255,255) +  + gwboni + " $");

                int bankInterest = (int)Math.Round(bank * 0.001);
                total += bankInterest;
                if (bankInterest > 0)
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Bankzinsen : " + RageAPI.GetHexColorcode(255,255,255) +  + bankInterest + " $");
                }

                foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                {
                    AltV.Net.Enums.VehicleModel IVehicleHass = (AltV.Net.Enums.VehicleModel)Vehicle.Model;
                    if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>() && Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_NOT_SAVED) != true)
                    {

                        int IVehicleTaxes = (int)Math.Round((int)Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_PRICE) * Constants.TAXES_IVehicle);
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

                        int IVehicleId = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID);
                        string VehicleModel = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_MODEL);
                        string IVehiclePlate = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_PLATE) == string.Empty ? "LS " + (1000 + IVehicleId) : Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_PLATE);
                        player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " VIP Fahrzeugsteuer Abzug : " + RageAPI.GetHexColorcode(255,255,255) +  + IVehicleTaxes_ + "$");
                        player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Fahrzeugsteuer : " + RageAPI.GetHexColorcode(255,255,255) + VehicleModel + " (" + IVehiclePlate + "): - " + IVehicleTaxes + " $");
                        total -= IVehicleTaxes;
                        total += IVehicleTaxes_;
                    }
                }
                if (House.houseList != null)
                {
                    // House taxes
                    foreach (HouseModel house in House.houseList)
                    {
                        if (house.owner ==player.GetVnXName<string>())
                        {
                            int houseTaxes = (int)Math.Round((int)house.price * Constants.TAXES_HOUSE);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Immobiliensteuer :  " + RageAPI.GetHexColorcode(255,255,255) + house.name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if(house.id == player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE))
                        {
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Miete " + house.name + " : " + RageAPI.GetHexColorcode(255,255,255) +  + house.rental + "$");
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
                else if(VIPBONI < 100)
                {
                    total += 100;
                }
                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " VIP Bonus : " + RageAPI.GetHexColorcode(255,255,255) +  + VIPBONI + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendChatMessage(Constants.Rgba_HELP +RageAPI.GetHexColorcode(0,150,200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                player.SendChatMessage(Constants.Rgba_HELP +RageAPI.GetHexColorcode(0,200,255) + " Einnahmen insgesamt : " + RageAPI.GetHexColorcode(255,255,255) +  + total + " $");

                if (total < 0)
                {
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_BANK, player.vnxGetElementData<int>(EntityData.PLAYER_BANK) - Math.Abs(total));
                }
                else
                {
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_BANK, player.vnxGetElementData<int>(EntityData.PLAYER_BANK) + total);
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





        public static ItemModel GetItemModelFromId(int itemId)
        {
            try
            {
                ItemModel item = null;
                foreach (ItemModel itemModel in itemList)
                {
                    if (itemModel.id == itemId)
                    {
                        item = itemModel;
                        break;
                    }
                }
                return item;
            }
            catch { return null; }
        }

        public static ItemModel GetPlayerItemModelFromHash(int playerId, string hash)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in itemList)
                {
                    if (item.ownerEntity == Constants.ITEM_ENTITY_PLAYER && item.ownerIdentifier == playerId && item.hash == hash)
                    {
                        itemModel = item;
                        break;
                    }
                }
                return itemModel;
            }
            catch { return null; }
        }

        public static ItemModel GetClosestItem(IPlayer player)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in itemList)
                {
                    if (item.ownerEntity == Constants.ITEM_ENTITY_GROUND && player.Position.Distance(item.position) < 2.0f)
                    {
                        itemModel = item;
                        break;
                    }
                }
                return itemModel;
            }
            catch { return null; }
        }

        public static ItemModel GetClosestItemWithHash(IPlayer player, string hash)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in itemList)
                {
                    if (item.ownerEntity == Constants.ITEM_ENTITY_GROUND && item.hash == hash && player.Position.Distance(item.position) < 2.0f)
                    {
                        itemModel = item;
                        break;
                    }
                }
                return itemModel;
            }
            catch { return null; }
        }

        public static ItemModel GetItemInEntity(int entityId, string entity)
        {
            try
            {
                ItemModel item = null;
                foreach (ItemModel itemModel in itemList)
                {
                    if (itemModel.ownerEntity == entity && itemModel.ownerIdentifier == entityId)
                    {
                        item = itemModel;
                        break;
                    }
                }
                return item;
            }
            catch { return null; }
        }

        private void SubstractPlayerItems(ItemModel item, int amount = 1)
        {
            try
            {
                item.amount -= amount;
                if (item.amount == 0)
                {
                    // Remove the item from the database
                    Database.RemoveItem(item.id);
                        itemList.Remove(item);
                }
            }
            catch { }
        }





        public static int GetPlayerInventoryTotal(IPlayer player)
        {
            try {
                // Return the amount of items in the player's inventory
                return itemList.Count(item => item.ownerEntity == Constants.ITEM_ENTITY_PLAYER && player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID) == item.ownerIdentifier);
            }
            catch { return 0; }
        }

        private List<InventoryModel> GetPlayerInventory(IPlayer player)
        {
            try
            {

                List<InventoryModel> inventory = new List<InventoryModel>();
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                foreach (ItemModel item in itemList)
                {
                    if (item.ownerEntity == Constants.ITEM_ENTITY_PLAYER && item.ownerIdentifier == playerId)
                    {
                        BusinessItemModel businessItem = Business.GetBusinessItemFromHash(item.hash);
                        if (businessItem != null && businessItem.type != Constants.ITEM_TYPE_WEAPON && businessItem.deIScription != Constants.ITEM_NAME_PISTOLAMMO)
                        {
                            // Create the item into the inventory
                            InventoryModel inventoryItem = new InventoryModel();
                            {
                                inventoryItem.id = item.id;
                                inventoryItem.hash = item.hash;
                                inventoryItem.deIScription = businessItem.deIScription;
                                inventoryItem.type = businessItem.type;
                                inventoryItem.amount = item.amount;
                            }

                            // Add the item to the inventory
                            inventory.Add(inventoryItem);
                        }
                    }
                }

                return inventory;
            }
            catch
            {

            }
            return null;
        }

        //[AltV.Net.ClientEvent("Inventory_Server")]
        public void InventoryCommand(IPlayer player)
        {
            try
            {
                List<InventoryModel> inventory = GetPlayerInventory(player);
                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
            }
            catch {  }
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
                            clothesNames.Add(businessClothes.deIScription);
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
            catch {}
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

                /*foreach (InteriorModel interior in Constants.INTERIOR_LIST)
                {
                    if (interior.blipId > 0)
                    {
                        interior.blip = NAPI.Blip.CreateBlip(interior.entrancePosition);
                        interior.blip.Sprite = (uint)interior.blipId;
                        interior.blip.Name = interior.blipName;
                        interior.blip.ShortRange = true;
                        interior.blip.Rgba = interior.BlipRgba;
                    }

                    if (interior.captionMessage != string.Empty)
                    {
                        //interior.textLabel = //ToDo: ClientSide erstellen NAPI.
                        .CreateTextLabel(interior.captionMessage, interior.entrancePosition, 20.0f, 0.75f, 4, new Rgba(interior.labelRgbaR, interior.labelRgbaG, interior.labelRgbaB), false, 0);
                    }
                }*/

                minuteTimer = new Timer(OnMinuteSpent, null, 60000, 60000); // Payday Generation und alles was nach einer Minute passiert!
                OnTickTimer = new Timer(VenoXV.Globals.Globals.OnUpdate, null, 50, 50); // Tick/OnUpdateEvent
                ScoreboardTimer = new Timer(anzeigen.Scorebard.Scoreboard.Fill_Playerlist, null, 7000, 7000); // Scoreboard Updater.


                //*///////////////////////////////////// OTHER STUFF LOADING ///////////////////////////////////////////////////*//

                CarShop.OnResourceStart();
                Clothes.Clothes.OnResourceStart();
                Environment.ammunation.ammunation.OnResourceStart();
                factions.Allround.OnResourceStart(); // Label - Faction Loading !
                fraktionskassen.OnResourceStart(); // GangKassen & IColShapes Loading !
                Fun.Allround.OnResourceStart(); // GangKassen & IColShapes Loading !
                Job.OnResourceStart(); // GangKassen & IColShapes Loading !
                premium.vnxcase.VenoXCases.OnResourceStart();
                Vehicles.paynspray.OnResourceStart();
                Vehicles.Tunning.OnResourceStart();
                Vehicles.Verleih.OnResourceStart();
                Vehicles.Vehicles.OnResourceStart();
                gangwar.Allround.OnResourceStart();
                weapons.Combat.OnResourceStart();

                Console.WriteLine("VenoX V." + CURRENT_VERSION + " Loaded!");
                // 0,105,145 <----- Dunkler Rgba Code Blau !
                // 0,150,200 <----- Dunkler Rgba Code Mittelmäßig Helles Blau!
                // 0,200,255 <----- Dunkler Rgba Code Extrem Helles Blau!
                // 40,40,40,0.8 <----- Grau Rgba Code !

            }
            catch { }
        }


        public static void OnPlayerDisconnected(IPlayer player, string type, string reason)
        {
            try
            {
                gangwar.Allround.OnPlayerDisconnected(player, type, reason);
                Fun.Aktionen.Shoprob.Shoprob.OnPlayerDisconnected(player, type, reason);
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>() && Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION) == Constants.FACTION_NONE)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                            Core.VnX.VehiclevnxSetSharedData(Vehicle,EntityData.VEHICLE_DIMENSION, Constants.VEHICLE_OFFLINE_DIM);
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
                            Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>()
                            //Airport ToDo
                            ||Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>()
                            ||Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>()
                            )
                            {
                                if (Vehicle != null)
                                {
                                    Vehicle.Dimension = Constants.VEHICLE_JOB_OFFLINE_DIM;
                                }
                                if (JoB_Allround.JobAbgabeMarker != null)
                                {
                                    if (JoB_Allround.JobAbgabeMarker.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) ==player.GetVnXName<string>())
                                    {
                                        AltV.Net.Alt.RemoveColShape(JoB_Allround.JobAbgabeMarker);
                                    }
                                }
                            }
                        }
                        else if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                        {
                            Vehicle.Dimension = Constants.VEHICLE_JOB_OFFLINE_DIM;
                        }
                        
                    }
                    foreach (IPlayer players in Alt.GetAllPlayers())
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
        public void CheckPlayerEventKeyEvent(IPlayer player)
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
                            player.Position = interior.exitPosition;
                            return;
                        }
                        else if (player.Position.Distance(interior.exitPosition) < 1.5f)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                            player.Position = interior.entrancePosition;
                            return;
                        }
                    }

                    // Check if the player's close to an ATM
                    for (int i = 0; i < Constants.ATM_LIST.Count; i++)
                    {
                        if (player.Position.Distance(Constants.ATM_LIST[i]) <= 1.5f)
                        {
                            player.Emit("showATM", player.vnxGetElementData<int>(EntityData.PLAYER_BANK), "Kontoauszüge", "Kontoauszüge", "Kontoauszüge Folgen", "Überweisen", "Überweisen", "Überweisen");
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + "Das Haus ist abgeschlossen!");
                                }
                                else
                                {

                                    player.Position = GetHouseIplExit(house.ipl);
                                    player.Dimension = house.id;

                                    player.SetData(EntityData.PLAYER_IPL, house.ipl);
                                    player.SetData(EntityData.PLAYER_HOUSE_ENTERED, house.id);
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
                                        player.SendChatMessage(Constants.Rgba_ERROR + "Das Haus ist abgeschlossen!");
                                    }*/
                                    player.Position = house.position;
                                    player.Dimension = 0;
                                    player.SetData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                                    /*
                                    foreach (IPlayer target in Alt.GetAllPlayers())
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
        public static void ResetDrugState(IPlayer player, int drug)
        {
            try
            {
                if (drug == 1)
                {
                    player.SetData(EntityData.PLAYER_KOKS_MODUS_AKTIV, false);
                }
            }
            catch { }
        }
        //[AltV.Net.ClientEvent("processMenuAction")]
        public void ProcessMenuActionEvent(IPlayer player, int itemId, string action)
        {
            try
            {
                string message = string.Empty;
                ItemModel item = GetItemModelFromId(itemId);
                BusinessItemModel businessItem = Business.GetBusinessItemFromHash(item.hash);
                switch (action)
                {
                    case "Benutzen":
                        List<InventoryModel> inventory = GetPlayerInventory(player);
                        player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                        
                        if (player.vnxGetSharedData<bool>("PLAYER_GOT_HITTED") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                            return;
                        }
                        if (item.amount <= 0)
                        {
                            return;
                        }
                        else if (item.hash == Constants.ITEM_HASH_KOKS)
                        {
                            if (item.amount >= 3)
                            {
                                if (player.vnxGetElementData<bool>(EntityData.PLAYER_KOKS_MODUS_AKTIV) == false)
                                {
                                    player.SetData(EntityData.PLAYER_KOKS_MODUS_AKTIV, true);
                                    player.SendChatMessage(player.GetVnXName<string>() + " zieht eine Line Kokain");
                                    player.Emit("start_screen_fx", "DrugsDrivingIn", 0, false);
                                    player.Emit("fx_handler", 1, 30000, "DrugsDrivingIn", "DrugsDrivingOut");

                                    item.amount -= 3;
                                    if (item.amount <= 0)
                                    {
                                        Database.RemoveItem(item.id);
                                        itemList.Remove(item);
                                    }
                                    else
                                    {
                                        Database.UpdateItem(item);
                                    }
                                    player.Emit("destroyInventoryWindow");
                                }
                                else
                                {
                                    dxLibary.VnX.DrawNotification(player, "error", "Bitte warte bis dein Rausch zu ende ist...");
                                }
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du brauchst Mindestens 3g Kokain, damit du es Konsumieren kannst!");
                            }
                        }
                        else if (item.hash == Constants.ITEM_HASH_BENZINKANNISTER)
                        {
                            if (player.IsInVehicle)
                            {

                                IVehicle Vehicle = player.Vehicle;
                                float Gas = Vehicle.vnxGetSharedData<float>("VEHICLE_GAS_CLIENT");
                                float kostenberechnung = 100f - Gas;
                                int kosten = (int)kostenberechnung * 15;
                                if (kosten == 0)
                                {
                                    dxLibary.VnX.DrawNotification(player, "info", "Du musst noch nicht Tanken.");
                                    return;
                                }
                                else
                                {
                                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", Vehicle.vnxGetSharedData<float>("VEHICLE_GAS_CLIENT") + 15);
                                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Fahrzeug aufgefüllt!");
                                    item.amount -= 1;
                                    if (item.amount <= 0)
                                    {
                                        Database.RemoveItem(item.id);
                                        itemList.Remove(item);
                                        player.Emit("destroyInventoryWindow");
                                        inventory = GetPlayerInventory(player);
                                        player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                                    }
                                    else
                                    {
                                        // Update the amount into the database
                                        Database.UpdateItem(item);
                                    }
                                }
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Fahrzeug!");
                            }
                        }
                        else if(item.hash == Constants.ITEM_HASH_TANKSTELLENSNACK)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 10 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 10);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 10;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                    Database.RemoveItem(item.id);
                                    itemList.Remove(item);
                                    player.Emit("destroyInventoryWindow");
                                    inventory = GetPlayerInventory(player);
                                    player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                        }
                        else if(item.hash == Constants.ITEM_HASH_LEBKUCHENMAENNCHEN)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 10 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 10);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 10;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " isst einen Lebkuchen... ^_^");
                        }
                        else if(item.hash == Constants.ITEM_HASH_MILCH)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 10;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " trinkt eine Milch... O.o");
                        }
                        else if(item.hash == Constants.ITEM_HASH_COOKIES)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 10;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player," isst Cookies... ^__^ ^___^ ^__^");
                        }                    
                        else if(item.hash == Constants.ITEM_HASH_GLUEHWEIN)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 5);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 10;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " trinkt Glühwein... <3");
                        }                    
                        else if(item.hash == Constants.ITEM_HASH_SPARERIPS)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 25;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " isst Sparerips... O.O");
                        }                    
                        else if(item.hash == Constants.ITEM_HASH_SCHOKOLADE)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 25;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " isst eine Tafel Schokolade... O.o");
                        }                    
                        else if(item.hash == Constants.ITEM_HASH_HEISSESCHOKOLADE)
                        {
                            if (player.IsInVehicle)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist ausserhalb eines Fahrzeuges nur Möglich!");
                                return;
                            }
                            if (player.Health + 10 > 100)
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health = 100;
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25 > 100)
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                                }
                                else
                                {
                                    VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, player.vnxGetElementData<int>(EntityData.PLAYER_HUNGER) + 25);
                                }
                            }
                            else
                            {
                                AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                                player.Health += 25;
                            }
                            item.amount -= 1;
                            if (item.amount <= 0)
                            {
                                Database.RemoveItem(item.id);
                                itemList.Remove(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            else
                            {
                                // Update the amount into the database
                                Database.UpdateItem(item);
                                player.Emit("destroyInventoryWindow");
                                inventory = GetPlayerInventory(player);
                                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                            }
                            anzeigen.Usefull.VnX.SendMessageNearPlayers(player, " isst trinkt eine Heiße - Schokolade... <3 Mhmmm schmeckt das gut...");
                        }
                        break;
                    case "Weg werfen":
                        item.amount--;
                        /*
                        if (businessItem.deIScription == Constants.ITEM_NAME_PISTOLAMMO)
                        {
                            int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                            ItemModel PistolenMagazin = GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (PistolenMagazin != null)
                            {
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol, 0);
                            }
                        }*/
                        Database.RemoveItem(item.id);
                        itemList.Remove(item);
                        player.Emit("destroyInventoryWindow");
                        inventory = GetPlayerInventory(player);
                        player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);

                        player.SendChatMessage( "Du hast folgendes aus deinem Inventar geschmissen : " + RageAPI.GetHexColorcode(0,200,255) + "  " + businessItem.deIScription);
                        inventory = GetPlayerInventory(player);
                        player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
                        break;
                }
            }
            catch { }
        }

    

        //[AltV.Net.ClientEvent("getPlayerTattoos")]
        public void GetPlayerTattoosEvent(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                int targetId = target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                List<TattooModel> playerTattooList = tattooList.Where(t => t.player == targetId).ToList();
                player.Emit("updatePlayerTattoos", JsonConvert.SerializeObject(playerTattooList), target);
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
        public static void GivePlayerItem(IPlayer player, string ItemHash, string ItemArt, int ItemAmount, bool AddierenFallsVorhanden)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                if (playerId > 0)
                {
                    ItemModel Item = Main.GetPlayerItemModelFromHash(playerId, ItemHash);
                    {
                        if (Item == null)
                        {
                            Item = new ItemModel();
                            Item.amount = ItemAmount;
                            Item.dimension = 0;
                            Item.position = new Position(0.0f, 0.0f, 0.0f);
                            Item.hash = ItemHash;
                            Item.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                            Item.ownerIdentifier = playerId;
                            Item.ITEM_ART = ItemArt;
                            Item.objectHandle = null;
                            Item.id = Database.AddNewItem(Item);
                            Main.itemList.Add(Item);
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
                    if(ItemArt == Constants.ITEM_ART_WAFFE)
                    {
                        AltV.Net.Enums.WeaponModel weapon = AltV.Net.Enums.WeaponModel.Fist;
                        if(ItemHash == Constants.ITEM_HASH_SNOWBALL) { weapon = AltV.Net.Enums.WeaponModel.Snowballs; }
                        else if (ItemHash == Constants.ITEM_HASH_HAMMER) { weapon = AltV.Net.Enums.WeaponModel.Hammer; }
                        else if(ItemHash == Constants.ITEM_HASH_NIGHTSTICK) { weapon = AltV.Net.Enums.WeaponModel.Nightstick; }
                        else if(ItemHash == Constants.ITEM_HASH_BASEBALL) { weapon = AltV.Net.Enums.WeaponModel.BaseballBat; }
                        else if(ItemHash == Constants.ITEM_HASH_SWITCHBLADE) { weapon = AltV.Net.Enums.WeaponModel.Switchblade; }
                        else if(ItemHash == Constants.ITEM_HASH_BROKENBOTTLE) { weapon = AltV.Net.Enums.WeaponModel.BrokenBottle; }
                        else if(ItemHash == Constants.ITEM_HASH_TAZER) { weapon = AltV.Net.Enums.WeaponModel.StunGun; }
                        else if(ItemHash == Constants.ITEM_HASH_VINTAGEPISTOL) { weapon = AltV.Net.Enums.WeaponModel.VintagePistol; }
                        else if(ItemHash == Constants.ITEM_HASH_PISTOLE) { weapon = AltV.Net.Enums.WeaponModel.Pistol; }
                        else if(ItemHash == Constants.ITEM_HASH_REVOLVER) { weapon = AltV.Net.Enums.WeaponModel.HeavyRevolver; }
                        else if (ItemHash == Constants.ITEM_HASH_PISTOLE50) { weapon = AltV.Net.Enums.WeaponModel.Pistol50; }
                        else if (ItemHash == Constants.ITEM_HASH_SHOTGUN) { weapon = AltV.Net.Enums.WeaponModel.PumpShotgun; }
                        else if (ItemHash == Constants.ITEM_HASH_MINISMG) { weapon = AltV.Net.Enums.WeaponModel.MiniSMG; }
                        else if (ItemHash == Constants.ITEM_HASH_MP5) { weapon = AltV.Net.Enums.WeaponModel.SMG; }
                        else if (ItemHash == Constants.ITEM_HASH_PDW) { weapon = AltV.Net.Enums.WeaponModel.CombatPDW; }
                        else if (ItemHash == Constants.ITEM_HASH_KARABINER) { weapon = AltV.Net.Enums.WeaponModel.CarbineRifle; }
                        else if (ItemHash == Constants.ITEM_HASH_ADVANCEDRIFLE) { weapon = AltV.Net.Enums.WeaponModel.AdvancedRifle; }
                        else if (ItemHash == Constants.ITEM_HASH_AK47) { weapon = AltV.Net.Enums.WeaponModel.AssaultRifle; }
                        else if (ItemHash == Constants.ITEM_HASH_RIFLE) { weapon = AltV.Net.Enums.WeaponModel.Musket; }
                        else if (ItemHash == Constants.ITEM_HASH_SNIPERRIFLE) { weapon = AltV.Net.Enums.WeaponModel.SniperRifle; }
                        
                        if (weapon != AltV.Net.Enums.WeaponModel.Fist)
                        {
                            // Wir geben dem Spieler seine Waffe :P
                            Reallife.Core.RageAPI.GivePlayerWeapon(player, weapon, ItemAmount);
                        }
                    }
                    else if(ItemArt == Constants.ITEM_ART_MAGAZIN)
                    {
                        ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                        ItemModel Pistol = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                        ItemModel Pistol50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                        ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                        if (Vintage != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.VintagePistol, Item.amount);
                        }
                        else if(Pistol != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol, Item.amount);
                        }                            
                        else if(Pistol50 != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol50, Item.amount);
                        }                            
                        else if(Revolver != null)
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
        public void InventoryCommand(IPlayer player)
        {
            if (GetPlayerInventoryTotal(player) > 0)
            {
                List<InventoryModel> inventory = GetPlayerInventory(player);
                player.Emit("showPlayerInventory", JsonConvert.SerializeObject(inventory), Constants.INVENTORY_TARGET_SELF);
            }
            else
            {
                //player.SendChatMessage(Constants.Rgba_ERROR + ErrRes.no_items_inventory);
            }
        }*/

       
      
     

       /* [Command("klamotten")]
        public void ComplementCommand(IPlayer player, string type, string action)
        {
            ClothesModel clothes = null;
            int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_MASK_BOUGHT);
                                }
                                else
                                {
                                    //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_MASK_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_MASK_EQUIPED);
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_BAG_BOUGHT);
                                }
                                else
                                {
                                    //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_BAG_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_BAG_EQUIPED);
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_ACCESSORY_BOUGHT);
                                }
                                else
                                {
                                    //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_ACCESSORY_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_ACCESSORY_EQUIPED);
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_HAT_BOUGHT);
                                }
                                else
                                {
                                    player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_HAT_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_HAT_EQUIPED);
                            }
                            else
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_GLASSES_BOUGHT);
                                }
                                else
                                {
                                    player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_GLASSES_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_GLASSES_EQUIPED);
                            }
                            else
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
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
                                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_EAR_BOUGHT);
                                }
                                else
                                {
                                    player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                                }
                            }
                            else
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_EAR_EQUIPED);
                            }
                        }
                        else
                        {
                            if (clothes == null)
                            {
                                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_EAR_EQUIPED);
                            }
                            else
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_SEX) == Constants.SEX_FEMALE)
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
                        player.SendChatMessage(Constants.Rgba_HELP + Messages.GEN_COMPLEMENT_COMMAND);
                        break;
                }
            }
            else
            {
                player.SendChatMessage(Constants.Rgba_HELP + Messages.GEN_COMPLEMENT_COMMAND);
            }
        }*/
    }
}
