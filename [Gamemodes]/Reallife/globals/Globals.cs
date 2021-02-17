using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.Club;
using VenoXV._Gamemodes_.Reallife.Environment.ammunation;
using VenoXV._Gamemodes_.Reallife.Environment.Gzone;
using VenoXV._Gamemodes_.Reallife.Environment.Rathaus;
using VenoXV._Gamemodes_.Reallife.events.Christmas.Weihnachtsmarkt;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Factions.LSPD;
using VenoXV._Gamemodes_.Reallife.Fun.Aktionen.Shoprob;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.jobs.Bus;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.premium.vnxcase;
using VenoXV._Gamemodes_.Reallife.Vehicles;
using VenoXV._Preload_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Allround = VenoXV._Gamemodes_.Reallife.gangwar.Allround;
using Inventory = VenoXV._Globals_.Inventory.Inventory;

namespace VenoXV._Gamemodes_.Reallife.Globals
{
    public class Main : IScript
    {
        public static List<ClothesModel> ClothesList;
        public static List<TattooModel> TattooList;
        public static List<TunningModel> TunningList;
        public static List<FactionAllroundModel> FactionAllroundList;
        public static Position GetHouseIplExit(string ipl)
        {
            try
            {
                Position position = new Position(0, 0, 0);
                foreach (var iplModel in Constants.HouseIplList.Where(iplModel => iplModel.Ipl == ipl))
                {
                    position = iplModel.Position;
                    break;
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
                foreach (VehicleModel veh in _Globals_.Main.ReallifeVehicles.ToList())
                {
                    Position vehPos = veh.Position;
                    float distanceIVehicleToPlayer = player.Position.Distance(vehPos);

                    if (!(distanceIVehicleToPlayer < distance) || player.Dimension != veh.Dimension) continue;
                    distance = distanceIVehicleToPlayer;
                    vehicle = veh;
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
                if (_Globals_.Main.ReallifePlayers.ToList().Count <= 0) return;
                Allround.OnUpdate();
                VenoXV.Reallife.Fun.Aktionen.Allround.OnUpdate();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerExitColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                Zone.OnPlayerExitColShapeModel(shape, player);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (Factions.Allround.OnPlayerEnterColShapeModel(shape, player)) return;
                if (factions.State.Allround.OnStateColShapeHit(shape, player)) return;
                if (CarShop.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Clothes.Clothes.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Ammunation.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Rathaus.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Zone.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Weihnachtsmarkt.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Rathaus.OnColShapeHit(shape, player)) return;
                if (Arrest.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Emergency.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Fraktionskassen.OnPlayerEnterColShapeModel(shape, player)) return;
                if (VenoXV.Reallife.Fun.Aktionen.Allround.OnClientEnterColShape(shape, player)) return;
                if (Allround.OnPlayerEnterColShapeModel(shape, player)) return;
                if (jobs.Allround.OnColShapeHit(shape, player)) return;
                if (Verleih.OnPlayerEnterColShapeModel(shape, player)) return;
                if (PaynSpray.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Tuning.OnPlayerEnterColShapeModel(shape, player)) return;
                if (Vehicles.Vehicles.OnPlayerEnterColShapeModel(shape, player)) return;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                            break;
                        case 10:
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du bekommst hunger... Besorg dir was zu Essen!");
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du bekommst hunger... Besorg dir was zu Essen!");
                            break;
                    }
                    if (player.Reallife.Hunger > 0) player.Reallife.Hunger -= 1;
                    if (player.Reallife.Hunger <= 20) player.Health -= 5;

                    if (player.Reallife.JailTime == 5) player.SendTranslatedChatMessage("Du bist noch 5 Minuten im Knast");
                    if (player.Reallife.JailTime > 0)
                    {
                        player.Reallife.JailTime -= 1;
                        if (player.Reallife.JailTime == 0)
                        {
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                            player.Reallife.Bail = 0;
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
                foreach (ItemModel item in Inventory.DatabaseItems.ToList())
                    Database.Database.UpdateItem(item);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static bool CheckBadElementDatas(string elementdata)
        {
            return elementdata switch
            {
                _Globals_.EntityData.PlayerMoney => true,
                EntityData.PlayerAdminRank => true,
                _ => false,
            };
        }

        [VenoXRemoteEvent("Store_Delayed_Element_Data_INT")]
        public static void Store_Delayed_ElementData_INT(VnXPlayer player, string elementdata, int value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.VnxSetStreamSharedElementData(elementdata, value);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("Store_Delayed_Element_Data_STRING")]
        public static void Store_Delayed_ElementData_INT(VnXPlayer player, string elementdata, string value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.VnxSetElementData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("Store_Delayed_Element_Data_BOOL")]
        public static void Store_Delayed_ElementData_BOOL(VnXPlayer player, string elementdata, bool value)
        {
            try
            {
                if (CheckBadElementDatas(elementdata)) { return; }
                player.VnxSetElementData(elementdata, value);
                player.SetSyncedMetaData(elementdata, value);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }




        public static TunningModel GetIVehicleTuningBySlot()
        {
            try
            {
                TunningModel tuning = null;
                foreach (TunningModel tuningslot in TunningList)
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
                Shoprob.OnMinuteSpend();

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static ItemModel GetPlayerItemModelFromHash(VnXPlayer player, string hash)
        {
            try
            {
                ItemModel itemModel = null;
                foreach (ItemModel item in player.Inventory.Items)
                {
                    if (item.Uid == player.UID && item.Hash == hash)
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
                return ClothesList.Where(c => c.Player == playerId).ToList();
            }
            catch { return null; }
        }

        public static ClothesModel GetDressedClothesInSlot(int playerId, int type, int slot)
        {
            try
            {
                // Get the clothes in the selected slot
                return ClothesList.FirstOrDefault(c => c.Player == playerId && c.Type == type && c.Slot == slot && c.Dressed);
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
                    foreach (BusinessClothesModel businessClothes in Constants.BusinessClothesList)
                    {
                        if (businessClothes.ClothesId == clothes.Drawable && businessClothes.BodyPart == clothes.Slot && businessClothes.Type == clothes.Type)
                        {
                            clothesNames.Add(businessClothes.Description);
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
                foreach (ClothesModel clothes in ClothesList)
                {
                    if (clothes.Player == playerId && clothes.Type == type && clothes.Slot == slot && clothes.Dressed)
                    {
                        clothes.Dressed = false;

                        // Update the clothes' state
                        Database.Database.UpdateClothes(clothes);

                        break;
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        public static void OnResourceStart()
        {
            try
            {

                //*///////////////////////////////////// BASIC LOADING ///////////////////////////////////////////////////*//

                foreach (InteriorModel interior in Constants.InteriorList)
                {
                    if (interior.BlipId > 0)
                    {
                        RageApi.CreateBlip(interior.BlipName, interior.EntrancePosition, interior.BlipId, interior.BlipRgba, true);
                    }

                    if (interior.CaptionMessage != string.Empty)
                    {
                        //interior.textLabel = //ToDo: ClientSide erstellen NAPI.
                        RageApi.CreateTextLabel(interior.CaptionMessage, interior.EntrancePosition, 20.0f, 0.75f, 4, new[] { interior.LabelRgbaR, interior.LabelRgbaG, interior.LabelRgbaB, 255 }, 0);
                    }
                }


                //*///////////////////////////////////// OTHER STUFF LOADING ///////////////////////////////////////////////////*//

                CarShop.OnResourceStart();
                Clothes.Clothes.OnResourceStart();
                Ammunation.OnResourceStart();
                Factions.Allround.OnResourceStart(); // Label - Faction Loading !
                Fraktionskassen.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                VenoXV.Reallife.Fun.Aktionen.Allround.OnResourceStart(); // GangKassen & ColShapeModels Loading !
                VenoXCases.OnResourceStart();
                PaynSpray.OnResourceStart();
                Tuning.OnResourceStart();
                Verleih.OnResourceStart();
                Vehicles.Vehicles.OnResourceStart();
                Allround.OnResourceStart();
                RussianClub.OnResourceStart();
                Bus.OnResourceStart();

                // 0,105,145 <----- Dunkler Rgba Code Blau !
                // 0,150,200 <----- Dunkler Rgba Code Mittelmäßig Helles Blau!
                // 0,200,255 <----- Dunkler Rgba Code Extrem Helles Blau!
                // 40,40,40,0.8 <----- Grau Rgba Code !
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void OnPlayerDisconnected(VnXPlayer player, string type, string reason)
        {
            try
            {
                Allround.OnPlayerDisconnected(player, type, reason);
                Shoprob.OnPlayerDisconnected(player, type, reason);
                anzeigen.Inventar.Main.OnPlayerDisconnect(player, type, reason);
                jobs.Allround.OnPlayerDisconnect(player);
                if (player.Playing)
                {
                    foreach (VehicleModel vehicle in _Globals_.Main.ReallifeVehicles.ToList())
                    {
                        if (vehicle.Owner == player.Username && vehicle.Faction == Constants.FactionNone)
                        {
                            vehicle.Dimension = Constants.VehicleOfflineDim;
                            if (vehicle.Passenger.Count > 0)
                            {
                                foreach (VnXPlayer players in vehicle.Passenger.ToList())
                                {
                                    if (players is not null && players.Exists)
                                    {
                                        player.WarpOutOfVehicle();
                                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
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
                Debug.CatchExceptions(ex);
            }
        }


        [AsyncClientEvent("checkPlayerEventKey")]
        public async Task CheckPlayerEventKeyEvent(VnXPlayer player)
        {
            try
            {
                if (player.Playing && player.Gamemode == (int)Preload.Gamemodes.Reallife)
                {
                    if (Factions.Allround.IsNearFactionTeleporter(player)) return;
                    // Check if the player's in any interior
                    foreach (InteriorModel interior in Constants.InteriorList)
                    {
                        if (player.Position.Distance(interior.EntrancePosition) < 1.5f)
                        {
                            player.SetPosition = interior.ExitPosition;
                            return;
                        }

                        if (player.Position.Distance(interior.ExitPosition) < 1.5f)
                        {
                            player.SetPosition = interior.EntrancePosition;
                            return;
                        }
                    }

                    // Check if the player's close to an ATM
                    for (int i = 0; i < Constants.AtmList.Count; i++)
                    {
                        if (player.Position.Distance(Constants.AtmList[i]) <= 1.5f)
                        {
                            VenoX.TriggerClientEvent(player, "showATM", player.Reallife.Bank, await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Kontoauszüge Folgen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"), await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Überweisen"));
                            return;
                        }
                    }


                    // Check if the player's in any house
                    if (House.HouseList != null)
                    {
                        foreach (HouseModel house in House.HouseList)
                        {
                            if (player.Position.Distance(house.Position) <= 1.5f && player.Dimension == house.Dimension)
                            {
                                //AntiCheat_Allround.SetTimeOutTeleport(player, 8000);
                                if (!House.HasPlayerHouseKeys(player, house) && house.Locked)
                                {
                                    player.SendTranslatedChatMessage(Constants.RgbaError + "Das Haus ist abgeschlossen!");
                                }
                                else
                                {
                                    player.SetPosition = GetHouseIplExit(house.Ipl);
                                    player.Dimension = house.Id;
                                    player.Reallife.HouseIpl = house.Ipl;
                                    player.Reallife.HouseEntered = house.Id;
                                }
                                return;
                            }

                            if (player.Reallife.HouseEntered == house.Id)
                            {
                                Position exitPosition = House.GetHouseExitPoint(house.Ipl);
                                if (player.Position.Distance(exitPosition) < 2.5f)
                                {
                                    if (!House.HasPlayerHouseKeys(player, house) && house.Locked)
                                    {
                                        player.SendTranslatedChatMessage(Constants.RgbaError + "Das Haus ist abgeschlossen!");
                                    }
                                    player.SetPosition = house.Position;
                                    player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
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
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("reset_drug_state")]
        public static void ResetDrugState(VnXPlayer player, int drug)
        {
            try
            {
                if (drug == 1)
                {
                    player.VnxSetElementData(EntityData.PlayerKoksModusAktiv, false);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
