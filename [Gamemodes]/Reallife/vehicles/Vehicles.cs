using System;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.business;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV._Preload_;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.factions;
using EntityData = VenoXV._Globals_.EntityData;
using Main = VenoXV._Globals_.Main;

namespace VenoXV.Reallife.vehicles
{
    public class Vehicles : IScript
    {
        public static string InfoVehicleTurnedOn = "Motor Angeschaltet!";
        public static string InfoVehicleTurnedOff = "Motor Ausgeschaltet!";

        public static void OnResourceStart()
        {
            try
            {
                //int counter = 0;
                foreach (var tankstellenCol in Constants.AutoZapfList.Select(tankstellen => RageApi.CreateColShapeSphere(tankstellen, 2)))
                {
                    tankstellenCol.VnxSetElementData("TANKSTELLEN_COL", true);
                }

                foreach (Vector3 tankstellen in Constants.AutoZapfListBlips)
                {
                    RageApi.CreateBlip("Tankstelle", tankstellen, 361, 3, true);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }



        public static VehicleModel GetVehicleById(int vehicleId)
        {
            try
            {
                foreach (VehicleModel veh in Main.ReallifeVehicles.ToList())
                {
                    if (veh.DatabaseId == vehicleId)
                    {
                        return veh;
                    }
                }
                return null;
            }
            catch { return null; }
        }



        [Command("frespawn")]
        public void Factioncarrespawn(VnXPlayer player)
        {
            try
            {
                int fraktionsId = player.Reallife.Faction;
                if (fraktionsId > 0)
                {
                    foreach (var vehicle in Main.ReallifeVehicles.ToList().Where(vehicle => vehicle.Faction == fraktionsId && vehicle.Driver == null && vehicle.Dimension == player.Dimension))
                    {
                        foreach (VnXPlayer passenger in vehicle.Passenger.ToList()) passenger?.WarpOutOfVehicle();
                        vehicle.Position = vehicle.SpawnCoord;
                        vehicle.Rotation = vehicle.SpawnRot;
                        vehicle.Kms = 0;
                        vehicle.Gas = 100;
                        vehicle.Frozen = true;
                        vehicle.Repair();
                    }
                    Faction.CreateFactionInformation(fraktionsId, player.Username + " hat die Fraktion´s Fahrzeuge Respawned!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Du bist in keiner Fraktion !");
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        [Command("sellcarto")]
        public static void SellCarTo(VnXPlayer player, string targetName, int fahrzeugId, int preis)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                VehicleModel vehicle = GetVehicleById(fahrzeugId);
                if (vehicle != null)
                {
                    if (vehicle.Owner == player.Username)
                    {
                        if (preis > 0)
                        {
                            // Sell cAr
                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + player.Username + " bietet dir ein " + vehicle.Model.ToString().ToLower() + "(" + vehicle.DatabaseId + ") für " + preis + " $ an!");
                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "Nutze /buycar ID um das Fahrzeug zu kaufen!");
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "Du hast " + target.Username + " deinen " + vehicle.Model.ToString().ToLower() + " für " + preis + " $ angeboten!");
                            target.VnxSetStreamSharedElementData(fahrzeugId.ToString(), preis);
                        }
                    }
                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Das Fahrzeug gehört dir nicht!"); }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        /*
        [Command("buycar")]
        public static void BuyCarTo(PlayerModel player, int FahrzeugID)
        {
            try
            {
                VehicleModel vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (player.vnxGetElementData<int>(FahrzeugID.ToString()) != null)
                    {
                        string target_name = RageAPI.GetPlayerFromName(Vehicle.Owner);
                        if(target != null)
                        {
                            if (player.Reallife.Money >= player.vnxGetElementData<string>(FahrzeugID.ToString()))
                            {
                                if (Vehicle.ID == FahrzeugID)
                                {
                                    Vehicle.Owner = player.Username);
                                    vehicle.vnxSetSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER,player.Username);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast das Fahrzeug von " + target.Username + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
                                   target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast dein Fahrzeug " + Vehicle.Model.ToString() + " an " +player.Username + " für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ verkauft!");
                                    player.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - player.vnxGetElementData(FahrzeugID.ToString()));
                                    Target.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, target.Reallife.Money + player.vnxGetElementData(FahrzeugID.ToString()));
                                    player.vnxSetElementData(FahrzeugID.ToString(), null);
                                    vnx_stored_files.logfile.WriteLogs("IVehicle",player.Username + " hat das Fahrzeug von " + target.Username + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
                                }
                            }
                            else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!"); }
                        }
                        else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Spieler ist nicht Online!"); }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Anfrage bekommen für die Fahrzeug ID " + FahrzeugID);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        */


        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape.VnxGetElementData<bool>("TANKSTELLEN_COL") != true) return false;

                int kostenWindow = 0;
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.Npc) { return true; }
                    float gas = vehicle.Gas;
                    float kostenberechnung = 100f - gas;
                    kostenWindow = (int)kostenberechnung * 15;
                    vehicle.Frozen = true;
                    /*RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + Gas);
                    RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + kostenberechnung);
                    RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + kostenWindow);*/
                }
                VenoX.TriggerClientEvent(player, "createGasWindow", kostenWindow);
                return true;
            }
            catch { return false; }
        }


        [VenoXRemoteEvent("Buy_Snack_Server")]
        public void Give_Snack_Func(VnXPlayer player)
        {
            /*
            if (player.Reallife.Money >= 6)
            {
                //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GAS_SNACK);
                if (Quests.QuestDict.ContainsKey(Quests.QUEST_GAS_SNACK))
                    Quests.OnQuestDone(player, Quests.QuestDict[Quests.QUEST_GAS_SNACK]);
                player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 6);
                player.SendTranslatedChatMessage("Du hast einen Tankstellen " + RageAPI.GetHexColorcode(0, 200, 255) + " Snack " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft.");
                ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_TANKSTELLENSNACK);
                if (Snack == null) // Kanister
                {
                    Snack = new ItemModel();
                    Snack.Amount += 1;
                    Snack.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                    Snack.Position = new Position(0.0f, 0.0f, 0.0f);
                    Snack.Hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                    Snack.UID = player.UID;
                    Snack.Type = "NUTZ_ITEM";

                    // Add the item into the database
                    Snack.Id = Database.AddNewItem(Snack);
                    _Globals_.Inventory.Inventory.Add(Snack);
                }
                else
                {
                    if (Snack.Amount == 150)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast die Maximale anzahl an Snack´s schon erreicht!");
                        return;
                    }
                    Snack.Amount = Snack.Amount + 1;
                    // Update the amount into the database
                    Database.UpdateItem(Snack);
                }
            }
            else
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
            }*/
        }


        [VenoXRemoteEvent("Buy_Kanister_Server")]
        public void Give_Kanister_Func(VnXPlayer player)
        {
            /*
            if (player.Reallife.Money >= 450)
            {
                ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_BENZINKANNISTER);
                if (Kanister == null) // Kanister
                {
                    Kanister = new ItemModel();
                    Kanister.Amount = Kanister.Amount + 1;
                    Kanister.Dimension = 1;
                    Kanister.Position = new Position(0.0f, 0.0f, 0.0f);
                    Kanister.Hash = Constants.ITEM_HASH_BENZINKANNISTER;
                    Kanister.UID = player.UID;
                    Kanister.Type = "NUTZ_ITEM";

                    // Add the item into the database
                    Kanister.Id = Database.AddNewItem(Kanister);
                    _Globals_.Inventory.Inventory.Add(Kanister);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 450);
                    player.SendTranslatedChatMessage("Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " Benzinkannister " + RageAPI.GetHexColorcode(255, 255, 255) + "erworben.");
                }
                else
                {
                    if (Kanister.Amount == 10)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast die Maximale anzahl an Kannister schon erreicht!");
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 450);
                        player.SendTranslatedChatMessage("Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " Benzinkannister " + RageAPI.GetHexColorcode(255, 255, 255) + "erworben.");
                        return;
                    }
                    Kanister.Amount = Kanister.Amount + 1;
                    // Update the amount into the database
                    Database.UpdateItem(Kanister);
                }
                //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GET100K);
                if (Quests.QuestDict.ContainsKey(Quests.QUEST_GET100K))
                    Quests.OnQuestDone(player, Quests.QuestDict[Quests.QUEST_GET100K]);

            }
            else
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
            }
            */
        }

        [VenoXRemoteEvent("Close_Gas_Window")]
        public void Close_Gas_Window(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    vehicle.Frozen = false;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("Fill_Car_Done")]
        public static void FilLCar_Done(VnXPlayer player, int value)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    vehicle.Gas = value;
                    vehicle.Frozen = false;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [ClientEvent("Fill_Car")]
        public void Fill_Gas_Car(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    float gas = vehicle.Gas;
                    float kostenberechnung = 100f - gas;
                    int kosten = (int)kostenberechnung * 15;
                    if (kosten == 0)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du musst noch nicht Tanken.");
                        return;
                    }
                    if (player.Reallife.Money < kosten)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        return;
                    }
                    player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - kosten);

                    VenoX.TriggerClientEvent(player, "Fill_Car_Accepted", 100, 2000);
                    VenoX.TriggerClientEvent(player, "destroyGasWindow");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("Fill_Gas_Liter")]
        public void Fill_Car_Liter(VnXPlayer player, int value)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    if (value > 0)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        int kosten = value * 15;
                        if (kosten == 0)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du musst noch nicht Tanken.");
                            return;
                        }
                        if (player.Reallife.Money < kosten)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }


                        if (value >= 100)
                        {
                            player.Reallife.Money -= 1500;
                            VenoX.TriggerClientEvent(player, "Fill_Car_Accepted", 100, 2000);
                            VenoX.TriggerClientEvent(player, "destroyGasWindow");
                        }
                        else
                        {
                            player.Reallife.Money -= kosten;
                            VenoX.TriggerClientEvent(player, "Fill_Car_Accepted", vehicle.Gas + value, 2000);
                            VenoX.TriggerClientEvent(player, "destroyGasWindow");
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void CreateVehicle(VnXPlayer player, bool adminCreated)
        {
            try
            {
                // Add the IVehicle to the database
                //vehModel.ID = Database.AddNewIVehicle(vehModel);

                // Create the IVehicle ingame
                //CreateIngameVehicle(vehModel);

                if (!adminCreated)
                {
                    if (Quests.QuestDict.ContainsKey(Quests.QuestAutokaufen))
                        Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestAutokaufen]);
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageApi.GetHexColorcode(255, 255, 255) + "Fahrzeug erfolgreich gekauft! Dein Fahrzeug findest du auf unseren Parkplatz.");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageApi.GetHexColorcode(255, 255, 255) + "Vergiss nicht dein Fahrzeug umzuparken! nutze /car um dein Fahrzeug zu verwalten.");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


       
        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }


        public const float LspdCar3 = 1.0f;
        public const string GetriebeHandling = "FINITIALDRIVEFORCE";
        public const string ReifenReibungHandling = "FTRACTIONCURVEMAX"; // Reifenoberflächenreibung
        public const string Police3Veh = "police3";
        //  VenoX.TriggerClientEvent(player,"SetIVehicleHandling", IVehicle, GETRIEBE_HANDLING, 30); // FÜRS DRIFT EVENT :D 


        [VenoXRemoteEvent("Tacho:CalculateTank")]
        public static void CalculateVehicleTank(VnXPlayer player, float speed)
        {
            try
            {
                if (player.Gamemode != (int)Preload.Gamemodes.Reallife) return;
                if (!player.IsInVehicle) return;
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                if (!player.Vehicle.EngineOn) return;
                float gas = vehClass.Gas;
                switch (gas)
                {
                    case <= 0:
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Achtung Tank ist leer!");
                        vehClass.Gas = 0;
                        vehClass.EngineOn = false;
                        return;
                    case 10:
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 200, 0) + "Achtung! Tank ist fast leer!");
                        break;
                }

                float verbrauch = 0;
                if (speed <= 10) verbrauch = 0.1f;
                else verbrauch = speed / 100;

                vehClass.Gas -= verbrauch;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void Tank(VnXPlayer player, float distance, bool state, VehicleModel vehicle)
        {
            try
            {
                if (state)
                {
                    int rest = (Convert.ToInt32(distance) * 3);
                    int tank = Convert.ToInt32(vehicle.Gas);
                    int newtank = (tank - rest);
                    switch (newtank)
                    {
                        case < 0:
                            vehicle.EngineOn = false;
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Achtung Tank ist leer!");
                            vehicle.Gas = 0;
                            //player.call('Tacho_Benzin_Fix', [player]);
                            break;
                        case < 16 and > 14:
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Achtung Tank bald leer!");
                            vehicle.Gas = newtank;
                            //player.call('Tacho_Benzin_Fix', [player]);
                            break;
                        default:
                            vehicle.Gas = newtank;
                            break;
                    }

                }
                else
                {
                    vehicle.Gas = 20;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public static void OnPlayerEnterVehicle(VehicleModel vehicle, VnXPlayer player, byte seat)
        {
            try
            {
                vehicle.Passenger.Add(player);
                if (player.Gamemode == (int)Preload.Gamemodes.Reallife && vehicle.Driver != player) VenoX.TriggerClientEvent(player, "OnPlayerEnterVehicle", 2500);
                if (vehicle.Driver == player)
                {
                    if (vehicle.Godmode)
                    {
                        vehicle.Godmode = false;
                    }
                }

                if (vehicle.Driver != player || player.Gamemode != (int) Preload.Gamemodes.Reallife) return;
                //VenoX.TriggerClientEvent(player, "Vehicle:DisableEngineToggle", true); // Disable Auto-TurnOn for Vehicle.
                vehicle.Frozen = false;

                _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Drücke X um den Motor zu starten.");

                if (vehicle.VnxGetElementData<bool>("AKTIONS_FAHRZEUG"))
                {
                    if (player.Reallife.Faction != Constants.FactionNone) return;
                    player.WarpOutOfVehicle();
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du bist in keiner Fraktion!");
                    return;
                    return;
                }
                if (vehicle.VnxGetElementData<bool>("PRUEFUNGS_AUTO"))
                {
                    float kmss = vehicle.Kms;
                    float gass = vehicle.Gas;
                    vehicle.Gas = gass;
                    vehicle.Kms = kmss;
                    return;
                }
                int vehFaction = vehicle.Faction;

                if (vehFaction > 0)
                {
                    int playerFaction = player.Reallife.Faction;

                    if (Allround.IsStateIVehicle(vehicle))
                    {
                        if (player.Reallife.OnDuty != 1)
                        {
                            if (Allround.IsStateFaction(player))
                            {
                                // player.WarpOutOfVehicle();
                                player.WarpOutOfVehicle();
                                _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Polizist im Dienst!");
                                return;
                            }
                        }
                    }
                    else if (Allround.IsBadIVehicle(vehicle))
                    {
                        if (player.Reallife.OnDutyBad != 1)
                        {
                            if (Allround.IsBadFaction(player))
                            {
                                player.WarpOutOfVehicle();
                                _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast keinen Gang-Skin an!");
                                return;
                            }
                        }
                    }
                    else if (Allround.IsNeutralIVehicle(vehicle))
                    {
                        if (player.Reallife.OnDutyNeutral != 1)
                        {
                            if (Allround.IsNeutralFaction(player))
                            {
                                player.WarpOutOfVehicle();
                                _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast keinen Fraktion´s-Skin an!");
                                return;
                            }
                        }
                    }

                    if (vehFaction > 0 && playerFaction != vehFaction)
                    {
                        player.WarpOutOfVehicle();
                        _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Mitglied dieser Fraktion!");
                        return;
                    }
                    vehicle.Frozen = false;
                    if (player.Reallife.DrivingLicense == 0)
                    {
                        _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Du hast keinen Führerschein... <br>Pass auf das du nicht erwischt wirst!");
                    }
                }
                float kms = vehicle.Kms;
                float gas = vehicle.Gas;
                vehicle.Gas = gas;
                vehicle.Kms = kms;
                VenoX.TriggerClientEvent(player, "initializeSpeedometer", kms, gas, vehicle.EngineOn);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        [VenoXRemoteEvent("OnPlayerEnterVehicleCall")]
        public static void OnPlayerEnterVehicleCall(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    OnPlayerEnterVehicle((VehicleModel)player.Vehicle, player, 0);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public static void OnPlayerExitIVehicle(VehicleModel vehicle, VnXPlayer player, byte seat)
        {
            try
            {
                if (player.Usefull.LastVehicleLeaveEventCall < DateTime.Now)
                {
                    vehicle.Passenger.Remove(player);
                    if (vehicle.Driver == player)
                    {
                        if (!vehicle.Godmode)
                        {
                            vehicle.Godmode = true;
                        }
                    }
                    _Gamemodes_.Reallife.jobs.Allround.OnPlayerLeaveVehicle(vehicle, player, seat);
                    _Gamemodes_.SevenTowers.Main.PlayerLeaveVehicle(vehicle, player);
                    player.Usefull.LastVehicleLeaveEventCall = DateTime.Now.AddSeconds(3);
                    CarShop.OnPlayerLeaveVehicle(vehicle, player);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        /*//[ServerEvent(Event.IVehicleDeath)]
        public void OnIVehicleDeath(VehicleModel)
                {
                    int IVehicleId = Vehicle.ID;
                    Timer IVehicleRespawnTimer = new Timer(OnIVehicleDeathTimer, IVehicle, 7500, Timeout.Infinite);
                    IVehicleRespawnTimerList.Add(IVehicleId, IVehicleRespawnTimer);
                }
                */
        //[AltV.Net.ClientEvent("stopPlayerCar")]
        public void StopPlayerCarEvent(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    // Turn the engine off
                    vehicle.EngineOn = false;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("engineOnEventKey")]
        public void EngineOnEventKeyEvent(VnXPlayer player)
        {
            try
            {
                if (!player.IsInVehicle) return;
                VehicleModel vehicle = (VehicleModel)player.Vehicle;
                if (vehicle.Gas <= 0)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Das Fahrzeug hat nicht mehr genug Benzin - du kannst an einer Tankstelle einen Reservekannister erwerben!");
                    return;
                }

                switch (vehicle.IsTestVehicle)
                {
                    case true:
                        vehicle.EngineOn = !vehicle.EngineOn;
                        return;
                }

                if (vehicle.VnxGetElementData<bool>("AKTIONS_FAHRZEUG"))
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                    return;
                }
                if (vehicle.VnxGetElementData<bool>("PRUEFUNGS_AUTO"))
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                    return;
                }
                if (vehicle.Owner == "GANGWAR")
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                    return;
                }
                if (vehicle.Rented)
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                    return;
                }
                if (vehicle.Job == player.VnxGetElementData<string>(_Gamemodes_.Reallife.Globals.EntityData.PlayerJob))
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                    return;
                }
                // Get player's faction and job
                int playerFaction = player.Reallife.Faction;
                int vehicleFaction = vehicle.Faction;

                if (vehicle.Owner != player.Username && vehicleFaction != player.Reallife.Faction)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Schlüssel für dieses Fahrzeug!");
                }
                else
                {
                    vehicle.EngineOn = !vehicle.EngineOn;
                    player.SendTranslatedChatMessage(vehicle.EngineOn ? InfoVehicleTurnedOn : InfoVehicleTurnedOff);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static AltV.Net.Enums.VehicleModel GetModVehicleHash(string modVehicle)
        {
            try
            {
                uint vehicleUint = Alt.Hash(modVehicle);
                AltV.Net.Enums.VehicleModel hash = (AltV.Net.Enums.VehicleModel)vehicleUint;
                return hash;
            }
            catch { return AltV.Net.Enums.VehicleModel.Asea; }
        }
        public static uint GetModVehicleHashByUint(uint @uint)
        {
            try
            {
                uint hash = (uint)AltV.Net.Enums.VehicleModel.Asea;
                uint vehicleUint = Alt.Hash("rmodamgc63");
                uint vehicleUint2 = Alt.Hash("rmodm4");
                uint vehicleUint3 = Alt.Hash("polamggtr");
                uint vehicleUint4 = Alt.Hash("pol718");
                uint vehicleUint5 = Alt.Hash("s63w222");
                uint vehicleUint6 = Alt.Hash("rs615");
                uint vehicleUint7 = Alt.Hash("rs5r");
                uint vehicleUint8 = Alt.Hash("fxxk");
                uint vehicleUint9 = Alt.Hash("lumma750");

                if (vehicleUint == @uint) { hash = (uint)GetModVehicleHash("rmodamgc63"); }
                else if (vehicleUint2 == @uint) { hash = (uint)GetModVehicleHash("rmodm4"); }
                else if (vehicleUint3 == @uint) { hash = (uint)GetModVehicleHash("polamggtr"); }
                else if (vehicleUint4 == @uint) { hash = (uint)GetModVehicleHash("pol718"); }
                else if (vehicleUint5 == @uint) { hash = (uint)GetModVehicleHash("s63w222"); }
                else if (vehicleUint6 == @uint) { hash = (uint)GetModVehicleHash("rs615"); }
                else if (vehicleUint7 == @uint) { hash = (uint)GetModVehicleHash("rs5r"); }
                else if (vehicleUint8 == @uint) { hash = (uint)GetModVehicleHash("fxxk"); }
                else if (vehicleUint9 == @uint) { hash = (uint)GetModVehicleHash("lumma750"); }
                else
                {
                    return hash;
                }
                return hash;
            }
            catch { return (uint)AltV.Net.Enums.VehicleModel.Asea; }
        }

    }
}