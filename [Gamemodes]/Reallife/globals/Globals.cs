using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.jobs.Bus;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
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

        public static VehicleModel GetClosestIVehicle(VnXPlayer player, float distance = 3.5f)
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
                if (VenoXV.Globals.Main.ReallifePlayers.ToList().Count <= 0) return;
                gangwar.Allround.OnUpdate();
                Fun.Allround.OnUpdate();
                environment.NPC.NPC.OnUpdate();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                Environment.Gzone.Zone.OnPlayerExitColShapeModel(shape, player);
            }
            catch { }
        }

        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (Allround.OnPlayerEnterColShapeModel(shape, player)) return;
                if (factions.State.Allround.OnStateColShapeHit(shape, player)) return;
                if (CarShop.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Clothes.Clothes.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Environment.ammunation.Ammunation.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Rathaus.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Environment.Gzone.Zone.OnPlayerEnterColShapeModel(shape, player)) return;
                if (events.Christmas.Weihnachtsmarkt.Weihnachtsmarkt.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Rathaus.OnColShapeHit(shape, player)) return;
                if (Factions.LSPD.Arrest.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Emergency.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Fraktionskassen.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Fun.Allround.OnClientEnterColShape(shape, player)) return;
                if (gangwar.Allround.OnPlayerEnterColShapeModel(shape, player)) return;
                if (jobs.Allround.OnColShapeHit(shape, player)) return;
                if (Vehicles.Verleih.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Vehicles.PaynSpray.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Vehicles.Tuning.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Vehicles.Vehicles.OnPlayerEnterColShapeModel(shape, player)) return;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        private static void DeleteVehicleThreadSafe()
        {
            try
            {
                //int i = 0;
                foreach (VehicleModel vehClass in VenoXV.Globals.Main.AllVehicles.ToList())
                {
                    if (VenoXV.Globals.Main.AllVehicles.ToList().Contains(vehClass) && vehClass.MarkedForDelete)
                    {
                        //Debug.OutputDebugString("DeleteVehicleThreadSafe : " + i++);
                        VenoXV.Globals.Main.AllVehicles.Remove(vehClass);
                        vehClass.Remove();
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private static void DeleteColShapesThreadSafe()
        {
            try
            {
                //int i = 0;
                foreach (ColShapeModel colShape in Sync.ColShapeList.ToList())
                {
                    if (Sync.ColShapeList.Contains(colShape) && colShape.MarkedForDelete)
                    {
                        //Debug.OutputDebugString("DeleteColShapesThreadSafe : " + i++);
                        Sync.ColShapeList.Remove(colShape);
                        Alt.RemoveColShape(colShape);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void SyncWeather(VnXPlayer player)
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
                        weather = GetRandomWeather(0, 2);
                        switch (weather)
                        {
                            case 0:
                                weather = 0;
                                break;
                            case 1:
                                weather = 8;
                                break;
                            case 2:
                                weather = 9;
                                break;
                            case 3:
                                weather = 3;
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

        public static void OnMinuteSpentReallifeGM(VnXPlayer player)
        {
            try
            {
                if (player.Playing)
                {
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
                    if (player.Reallife.Hunger > 0) player.Reallife.Hunger -= 1;
                    if (player.Reallife.Hunger <= 20) player.Health -= 5;

                    if (player.Reallife.Knastzeit == 5) player.SendTranslatedChatMessage("Du bist noch 5 Minuten im Knast");
                    if (player.Reallife.Knastzeit > 0)
                    {
                        player.Reallife.Knastzeit -= 1;
                        if (player.Reallife.Knastzeit == 0)
                        {
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Language;
                            player.Reallife.Kaution = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }

        }

        public static void OnMinuteSpentTacticGM(VnXPlayer player)
        {
            try
            {
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnMinuteSpentZombieGM(VnXPlayer player)
        {
            try
            {

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SyncDatabaseItems(VnXPlayer player)
        {
            try
            {
                foreach (ItemModel item in _Globals_.Inventory.Inventory.DatabaseItems.ToList())
                    Database.UpdateItem(item);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        private static int CurrentHour = 15;
        public static void OnMinuteSpent(object unused)
        {
            try
            {
                if (CurrentHour < 23) CurrentHour++;
                else CurrentHour = 0;
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 55) RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in 5 Minuten!");
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59) RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in einer Minute!");
                foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList())
                {
                    int played = player.Played;
                    if (played > 0 && played % 60 == 0) GeneratePlayerPayday(player);
                    player.Played += 1;
                    SyncDatabaseItems(player);
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

                    AccountModel accClass = Register.AccountList.ToList().FirstOrDefault(x => x.UID == player.UID);
                    string langpair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                    if (accClass is not null && accClass.Language != langpair)
                        Database.UpdatePlayerLanguage(accClass.UID, langpair);

                    SavePlayerDatas(player);
                    DateTime CurrentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CurrentHour, 0, 0);
                    player.SetDateTime(CurrentDateTime);
                    SyncWeather(player);
                }
                Fun.Aktionen.Shoprob.Shoprob.OnMinuteSpend();
                SaveVehicleDatas();
                DeleteVehicleThreadSafe();
                DeleteColShapesThreadSafe();
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpent = OK!");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void SavePlayerDatas(VnXPlayer player)
        {
            try
            {
                Database.SaveCharacterInformation(player);
            }
            catch { }
        }

        public static void SaveVehicleDatas()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    if (Vehicle.Owner != null)
                    {
                        if (Vehicle.IsTestVehicle != true && Vehicle.Faction == 0 && Vehicle.NotSave != false && Vehicle.Dimension == 0)
                        {
                            // Add IVehicle into the list
                            IVehicleList.Add(Vehicle);
                        }
                    }
                }
                Database.SaveAllIVehicles(IVehicleList);
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }
        //



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
        public static void Store_Delayed_ElementData_INT(VnXPlayer player, string elementdata, int value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.vnxSetStreamSharedElementData(elementdata, value);
            }
            catch { }
        }

        [ClientEvent("Store_Delayed_Element_Data_STRING")]
        public static void Store_Delayed_ElementData_INT(VnXPlayer player, string elementdata, string value)
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
        public static void Store_Delayed_ElementData_BOOL(VnXPlayer player, string elementdata, bool value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.vnxSetElementData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch { }
        }

        public static async void GeneratePlayerPayday(VnXPlayer player)
        {
            try
            {
                int total = 0;
                int bank = player.Reallife.Bank;
                int playerRank = player.Reallife.FactionRank;
                int playerFaction = player.Reallife.Faction;
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                VnXPlayer VipL = Database.GetPlayerVIP(player, player.UID);

                if (player.Reallife.Wanteds > 0) { player.Reallife.Wanteds -= 1; }
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
                string Gehalt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Gehalt");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Gehalt + " : " + RageAPI.GetHexColorcode(255, 255, 255) + total + " $");


                int gwboni = 0;
                foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.IDOwner == player.Reallife.Faction)
                    {
                        gwboni += 250;
                    }
                }

                total += gwboni;

                string GwBoni = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "GW - Boni");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + GwBoni + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +gwboni + " $");

                int bankInterest = (int)Math.Round(bank * 0.001);
                total += bankInterest;
                if (bankInterest > 0)
                {
                    string Bankzinsen = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Bankzinsen");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Bankzinsen + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +bankInterest + " $");
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
                            string Immobiliensteuer = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Immobiliensteuer : ");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Immobiliensteuer + " : " + RageAPI.GetHexColorcode(255, 255, 255) + house.name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if (house.id == player.Reallife.HouseRent)
                        {
                            string Miete = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Miete");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Miete + " : " + house.name + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +house.rental + "$");
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
                string VIP = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "VIP Bonus");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + VIP + ": " + RageAPI.GetHexColorcode(255, 255, 255) + VIPBONI + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendChatMessage(Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                string EinnahmenGesamt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Einnahmen insgesamt");
                player.SendChatMessage(Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 200, 255) + " " + EinnahmenGesamt + " :" + RageAPI.GetHexColorcode(255, 255, 255) + +total + " $");

                if (total < 0)
                {
                    player.Reallife.Bank -= Math.Abs(total);
                }
                else
                {
                    player.Reallife.Bank += Math.Abs(total);

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






        public static ItemModel GetPlayerItemModelFromHash(VnXPlayer player, string hash)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in player.Inventory.Items)
                {
                    if (item.UID == player.UID && item.Hash == hash)
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
                Club.RussianClub.OnResourceStart();
                Bus.OnResourceStart();

                // 0,105,145 <----- Dunkler Rgba Code Blau !
                // 0,150,200 <----- Dunkler Rgba Code Mittelmäßig Helles Blau!
                // 0,200,255 <----- Dunkler Rgba Code Extrem Helles Blau!
                // 40,40,40,0.8 <----- Grau Rgba Code !
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        public static void OnPlayerDisconnected(VnXPlayer player, string type, string reason)
        {
            try
            {
                gangwar.Allround.OnPlayerDisconnected(player, type, reason);
                Fun.Aktionen.Shoprob.Shoprob.OnPlayerDisconnected(player, type, reason);
                anzeigen.Inventar.Main.OnPlayerDisconnect(player, type, reason);
                jobs.Allround.OnPlayerDisconnect(player);
                if (player.Playing == true)
                {
                    foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                    {
                        if (Vehicle.Owner == player.Username && Vehicle.Faction == Constants.FACTION_NONE)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                            if (Vehicle.Passenger.Count > 0)
                            {
                                foreach (VnXPlayer players in Vehicle.Passenger.ToList())
                                {
                                    if (players is not null && players.Exists)
                                    {
                                        player.WarpOutOfVehicle();
                                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Language;
                                    }
                                }
                            }
                        }
                    }
                    SavePlayerDatas(player);
                }
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }


        [AsyncClientEvent("checkPlayerEventKey")]
        public async Task CheckPlayerEventKeyEvent(VnXPlayer player)
        {
            try
            {
                if (player.Playing == true && player.Gamemode == (int)Preload.Gamemodes.Reallife)
                {
                    if (Allround.IsNearFactionTeleporter(player)) return;
                    // Check if the player's in any interior
                    foreach (InteriorModel interior in Constants.INTERIOR_LIST)
                    {
                        if (player.Position.Distance(interior.entrancePosition) < 1.5f)
                        {
                            player.SetPosition = interior.exitPosition;
                            return;
                        }
                        else if (player.Position.Distance(interior.exitPosition) < 1.5f)
                        {
                            player.SetPosition = interior.entrancePosition;
                            return;
                        }
                    }

                    // Check if the player's close to an ATM
                    for (int i = 0; i < Constants.ATM_LIST.Count; i++)
                    {
                        if (player.Position.Distance(Constants.ATM_LIST[i]) <= 1.5f)
                        {
                            VenoX.TriggerClientEvent(player, "showATM", player.Reallife.Bank, await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge Folgen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"));
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
                                    player.Reallife.HouseIPL = house.ipl;
                                    player.Reallife.HouseEntered = house.id;
                                }
                                return;
                            }
                            else if (player.Reallife.HouseEntered == house.id)
                            {
                                Position exitPosition = House.GetHouseExitPoint(house.ipl);
                                if (player.Position.Distance(exitPosition) < 2.5f)
                                {
                                    if (!House.HasPlayerHouseKeys(player, house) && house.locked)
                                    {
                                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Das Haus ist abgeschlossen!");
                                    }
                                    player.SetPosition = house.position;
                                    player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Language;
                                    player.Reallife.HouseEntered = 0;

                                    /*foreach (Client target in VenoX.GetAllPlayers().ToList())
                                    {
                                        if (target.Playing && target.vnxGetElementData(EntityData.PLAYER_IPL) && target != player)
                                        {
                                            if (target.vnxGetElementData(EntityData.PLAYER_IPL) == house.ipl)
                                            {
                                                return;
                                            }
                                        }
                                    }
                                    //NAPI.World.RemoveIpl(house.ipl);*/

                                }
                                return;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        [ClientEvent("reset_drug_state")]
        public static void ResetDrugState(VnXPlayer player, int drug)
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
    }
}
