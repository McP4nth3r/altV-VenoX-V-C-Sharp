using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.jobs.Bus;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_;
using VenoXV._RootCore_;
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
                foreach (VehicleModel veh in VenoXV._Globals_.Main.ReallifeVehicles.ToList())
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


        public static void OnUpdate()
        {
            try
            {
                if (VenoXV._Globals_.Main.ReallifePlayers.ToList().Count <= 0) return;
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
                            player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
                            player.Reallife.Kaution = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                    }
                }
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


        public static bool CheckBadElementDatas(string elementdata)
        {
            return elementdata switch
            {
                VenoXV._Globals_.EntityData.PLAYER_MONEY => true,
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




        public static void OnMinuteSpend()
        {
            try
            {
                Fun.Aktionen.Shoprob.Shoprob.OnMinuteSpend();

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
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
                    foreach (VehicleModel Vehicle in VenoXV._Globals_.Main.ReallifeVehicles.ToList())
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
                                        player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
                                    }
                                }
                            }
                        }
                    }
                    _Globals_.Main.SavePlayerDatas(player);
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
                                    player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
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
