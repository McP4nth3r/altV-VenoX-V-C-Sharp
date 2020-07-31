using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.jobs.Bus;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
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
                foreach (VehicleModel veh in VenoXV.Globals.Main.ReallifeVehicles.ToList())
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
            try
            {
                if (VenoXV.Globals.Main.ReallifePlayers.ToList().Count <= 0) { return; }
                gangwar.Allround.OnUpdate();
                Fun.Allround.OnUpdate();
                environment.NPC.NPC.OnUpdate();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnUpdate", ex); }
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
                if (shape == null || entity == null) { return; }
                if (entity is Client player)   //We Check if the Entity is the player.
                {
                    factions.State.Allround.OnStateColShapeHit(shape, player);
                    CarShop.OnPlayerEnterColShapeModel(shape, player);
                    Clothes.Clothes.OnPlayerEnterColShapeModel(shape, player);
                    Environment.ammunation.Ammunation.OnPlayerEnterColShapeModel(shape, player);
                    Rathaus.OnPlayerEnterColShapeModel(shape, player);
                    Environment.Gzone.Zone.OnPlayerEnterColShapeModel(shape, player);
                    events.Christmas.Weihnachtsmarkt.Weihnachtsmarkt.OnPlayerEnterColShapeModel(shape, player);
                    Rathaus.OnColShapeHit(shape, player);
                    Factions.LSPD.Arrest.OnPlayerEnterColShapeModel(shape, player);
                    Emergency.OnPlayerEnterColShapeModel(shape, player);
                    Fraktionskassen.OnPlayerEnterColShapeModel(shape, player);
                    Fraktionswaffenlager.OnPlayerEnterColShapeModel(shape, player);
                    Fun.Allround.OnClientEnterColShape(shape, player);
                    gangwar.Allround.OnPlayerEnterColShapeModel(shape, player);
                    jobs.Allround.OnColShapeHit(shape, player);
                    Vehicles.Verleih.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.PaynSpray.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.Tuning.OnPlayerEnterColShapeModel(shape, player);
                    Vehicles.Vehicles.OnPlayerEnterColShapeModel(shape, player);
                }
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
                        switch (weather)
                        {
                            case 0:
                                weather = 0;
                                break;
                            case 1:
                                weather = 1;
                                break;
                            case 2:
                                weather = 9;
                                break;
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
                    player.Played += 1;
                    switch (player.Reallife.Hunger)
                    {
                        case 30:
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                            break;
                        case 10:
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                            break;
                    }
                    if (player.Reallife.Hunger > 0) { player.Reallife.Hunger -= 1; }
                    if (player.Reallife.Hunger <= 20)
                    {
                        player.Health -= 5;
                    }

                    if (player.Reallife.Knastzeit == 5)
                    {
                        player.SendTranslatedChatMessage("Du bist noch 5 Minuten im Knast");
                    }
                    if (player.Reallife.Knastzeit > 0)
                    {
                        player.Reallife.Knastzeit -= 1;
                        if (player.Reallife.Knastzeit == 0)
                        {
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = 0;
                            player.Reallife.Kaution = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnMinuteSpentReallifeGM", ex); }

        }

        public static void OnMinuteSpentTacticGM(Client player)
        {
            try
            {
                int played = player.Played;
                if (played > 0 && played % 60 == 0)
                {
                    GeneratePlayerPayday(player);
                }
                player.Played += 1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnMinuteSpentTacticGM", ex); }
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
                player.Played += 1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnMinuteSpentZombieGM", ex); }
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
                foreach (Client player in Alt.GetAllPlayers().ToList())
                {
                    switch (player.Gamemode)
                    {
                        case (int)_Preload_.Preload.Gamemodes.Reallife:
                            OnMinuteSpentReallifeGM(player);
                            break;
                        case (int)_Preload_.Preload.Gamemodes.Tactics:
                            OnMinuteSpentTacticGM(player);
                            break;
                        case (int)_Preload_.Preload.Gamemodes.Zombies:
                            OnMinuteSpentZombieGM(player);
                            break;
                    }
                    anzeigen.Usefull.VnX.SavePlayerDatas(player);
                    player.SetDateTime(DateTime.Now);
                    SyncWeather(player);
                }
                Fun.Aktionen.Shoprob.Shoprob.OnMinuteSpend();
                anzeigen.Usefull.VnX.SaveIVehicleDatas();
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpent = OK!");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnMinuteSpent", ex); }
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

                foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    AltV.Net.Enums.VehicleModel IVehicleHass = (AltV.Net.Enums.VehicleModel)Vehicle.Model;
                    if (Vehicle.Owner == player.Username && Vehicle.NotSave != true)
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
                foreach (ItemModel item in anzeigen.Inventar.Main.CurrentOnlineItemList.ToList())
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
                Program.OnResourceStart();
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
                Allround.OnResourceStart(); // Label - Faction Loading !
                Fraktionskassen.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                Fun.Allround.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                premium.vnxcase.VenoXCases.OnResourceStart();
                Vehicles.PaynSpray.OnResourceStart();
                Vehicles.Tuning.OnResourceStart();
                Vehicles.Verleih.OnResourceStart();
                Vehicles.Vehicles.OnResourceStart();
                gangwar.Allround.OnResourceStart();
                weapons.Combat.OnResourceStart();
                Club.RussianClub.OnResourceStart();
                Bus.OnResourceStart();

                // 0,105,145 <----- Dunkler Rgba Code Blau !
                // 0,150,200 <----- Dunkler Rgba Code Mittelmäßig Helles Blau!
                // 0,200,255 <----- Dunkler Rgba Code Extrem Helles Blau!
                // 40,40,40,0.8 <----- Grau Rgba Code !
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnResourceStartReallife", ex); }
        }


        public static void OnPlayerDisconnected(Client player, string type, string reason)
        {
            try
            {
                gangwar.Allround.OnPlayerDisconnected(player, type, reason);
                Fun.Aktionen.Shoprob.Shoprob.OnPlayerDisconnected(player, type, reason);
                anzeigen.Inventar.Main.OnPlayerDisconnect(player, type, reason);
                VenoXV.Globals.Main.RemovePlayerFromGamemodeList(player);
                jobs.Allround.OnPlayerDisconnect(player);
                if (player.Playing == true)
                {
                    foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
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


        [ClientEvent("checkPlayerEventKey")]
        public void CheckPlayerEventKeyEvent(Client player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    if (Factions.Allround.IsNearFactionTeleporter(player))
                    {
                        return;
                    }
                    // Check if the player's in any interior
                    foreach (InteriorModel interior in Constants.INTERIOR_LIST)
                    {
                        if (player.Position.Distance(interior.entrancePosition) < 1.5f)
                        {
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                            player.SetPosition = interior.exitPosition;
                            return;
                        }
                        else if (player.Position.Distance(interior.exitPosition) < 1.5f)
                        {
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
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
                                //AntiCheat_Allround.SetTimeOutTeleport(player, 8000);
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
                                //AntiCheat_Allround.SetTimeOutTeleport(player, 1250);
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

    }
}
