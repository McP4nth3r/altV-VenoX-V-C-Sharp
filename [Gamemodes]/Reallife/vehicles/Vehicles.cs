using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Vehicles : IScript
    {
        public static string INFO_VEHICLE_TURNED_ON = "Motor Angeschaltet!";
        public static string INFO_VEHICLE_TURNED_OFF = "Motor Ausgeschaltet!";

        public static void OnResourceStart()
        {
            try
            {
                //int counter = 0;
                foreach (Position Tankstellen in Constants.AUTO_ZAPF_LIST)
                {
                    ColShapeModel TankstellenCol = RageAPI.CreateColShapeSphere(Tankstellen, 2);
                    TankstellenCol.Entity.vnxSetElementData("TANKSTELLEN_COL", true);
                    /*Console.WriteLine("Tankstelle [" + counter + "] wurde erstellt! Pos : " + Tankstellen);
                    counter++;*/
                }
                foreach (Vector3 Tankstellen in Constants.AUTO_ZAPF_LIST_BLIPS)
                {
                    RageAPI.CreateBlip("Tankstelle", Tankstellen, 361, 3, true);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("Load_VEHICLE_Storage_Datas")]
        public void EnterAsPassenger(VnXPlayer player)
        {
            try
            {
                VehicleModel vehicle = Main.GetClosestIVehicle(player);
                if (vehicle == null)
                {
                    return;
                }
                Alt.Server.TriggerClientEvent(player, "VEHICLE_Data_Storage_load", vehicle);
                player.SendTranslatedChatMessage("IVehicle Name " + vehicle.Model.ToString());
            }
            catch { }
        }
        //[AltV.Net.ClientEvent("showresult_clicked")]
        public void showResult_Clicked(VnXPlayer player, IVehicle Objekt)
        {
            player.SendTranslatedChatMessage("Dein Objekt ist : " + Objekt);
        }

        /*[Command("fpark")]
        public static void FactionCarPark(PlayerModel player)
        {
            int facId = player.Reallife.Faction;
            if (facId > 0)
            {
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_FACTION_RANK) != 5)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Seit wann bist du Leader deiner Fraktion?");
                    return;
                }

                // Obtain occupied IVehicle
                IVehicle veh = (VehicleModel)player.Vehicle;
                if (veh != null)
                {
                    VehicleModel IVehicle = new VehicleModel();
                    if (veh.GetSharedData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION) == facId)
                    {
                        IVehicle.position = veh.position;
                        IVehicle.rotation = veh.Rotation;
                        IVehicle.id = veh.GetSharedData<int>(VenoXV.Globals.EntityData.VEHICLE_ID);

                        veh.vnxSetSharedData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER), IVehicle.position);
                        veh.vnxSetSharedData(VenoXV.Globals.EntityData.VEHICLE_ROTATION, IVehicle.rotation);

                        // Update the IVehicle's position into the database
                        Database.UpdateIVehiclePosition(IVehicle);
                        player.SendTranslatedChatMessage( "~g~Du hast das Fahrzeug umgeparkt.", true);
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört deiner Fraktion!", true);
                    }
                }
            }
        }*/

        public static VehicleModel GetVehicleById(int VehicleId)
        {
            try
            {
                VehicleModel Vehicle = null;

                foreach (VehicleModel veh in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    if (veh.ID == VehicleId)
                    {
                        Vehicle = veh;
                        break;
                    }
                }

                return Vehicle;
            }
            catch { return null; }
        }



        [Command("frespawn")]
        public void Factioncarrespawn(VnXPlayer player)
        {
            try
            {
                int fraktionsID = player.Reallife.Faction;
                if (fraktionsID > 0)
                {
                    foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                    {
                        if (Vehicle.Faction == fraktionsID && Vehicle.Driver == null)
                        {
                            Vehicle.Position = Vehicle.SpawnCoord;
                            Vehicle.Rotation = Vehicle.SpawnRot;
                            Vehicle.Kms = 0;
                            Vehicle.Gas = 100;
                            Vehicle.Frozen = true;
                            Vehicle.Repair();
                        }
                        foreach (VnXPlayer passenger in Vehicle.Passenger.ToList()) { passenger.WarpOutOfVehicle(); }
                    }
                    Faction.CreateFactionInformation(fraktionsID, player.Username + " hat die Fraktion´s Fahrzeuge Respawned!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Du bist in keiner Fraktion !");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("frespawn", ex); }
        }



        [Command("sellcarto")]
        public static void SellCarTo(VnXPlayer player, string target_name, int FahrzeugID, int Preis)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                VehicleModel Vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (Vehicle.Owner == player.Username)
                    {
                        if (Preis > 0)
                        {
                            // Sell cAr
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " bietet dir ein " + Vehicle.Model.ToString().ToLower() + "(" + Vehicle.ID + ") für " + Preis + " $ an!");
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Nutze /buycar ID um das Fahrzeug zu kaufen!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Du hast " + target.Username + " deinen " + Vehicle.Model.ToString().ToLower() + " für " + Preis + " $ angeboten!");
                            target.vnxSetStreamSharedElementData(FahrzeugID.ToString(), Preis);
                        }
                    }
                    else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Das Fahrzeug gehört dir nicht!"); }
                }
            }
            catch { }
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
            catch { }
        }
        */


        public static void OnPlayerEnterColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>("TANKSTELLEN_COL") == true)
                {
                    int kostenWindow = 0;
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        if (vehicle.NPC) { return; }
                        float Gas = vehicle.Gas;
                        float kostenberechnung = 100f - Gas;
                        kostenWindow = (int)kostenberechnung * 15;
                        vehicle.Frozen = true;
                        /*RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + Gas);
                        RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + kostenberechnung);
                        RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.Username + " hat :" + kostenWindow);*/
                    }
                    Alt.Server.TriggerClientEvent(player, "createGasWindow", kostenWindow);
                }
            }
            catch
            {
            }
        }


        [ClientEvent("Buy_Snack_Server")]
        public void Give_Snack_Func(VnXPlayer player)
        {
            if (player.Reallife.Money >= 6)
            {
                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GAS_SNACK);
                player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 6);
                player.SendTranslatedChatMessage("Du hast einen Tankstellen " + RageAPI.GetHexColorcode(0, 200, 255) + " Snack " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft.");
                ItemModel Snack = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_TANKSTELLENSNACK);
                if (Snack == null) // Kanister
                {
                    Snack = new ItemModel();
                    Snack.amount = Snack.amount + 1;
                    Snack.dimension = 0;
                    Snack.position = new Position(0.0f, 0.0f, 0.0f);
                    Snack.hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                    Snack.ownerIdentifier = player.UID;
                    Snack.ITEM_ART = "NUTZ_ITEM";
                    Snack.objectHandle = null;

                    // Add the item into the database
                    Snack.id = Database.AddNewItem(Snack);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Snack);
                }
                else
                {
                    if (Snack.amount == 150)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast die Maximale anzahl an Snack´s schon erreicht!");
                        return;
                    }
                    Snack.amount = Snack.amount + 1;
                    // Update the amount into the database
                    Database.UpdateItem(Snack);
                }
            }
            else
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
            }
        }


        [ClientEvent("Buy_Kanister_Server")]
        public void Give_Kanister_Func(VnXPlayer player)
        {
            if (player.Reallife.Money >= 450)
            {
                ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_BENZINKANNISTER);
                if (Kanister == null) // Kanister
                {
                    Kanister = new ItemModel();
                    Kanister.amount = Kanister.amount + 1;
                    Kanister.dimension = 0;
                    Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                    Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                    Kanister.ownerIdentifier = player.UID;
                    Kanister.ITEM_ART = "NUTZ_ITEM";
                    Kanister.objectHandle = null;

                    // Add the item into the database
                    Kanister.id = Database.AddNewItem(Kanister);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 450);
                    player.SendTranslatedChatMessage("Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " Benzinkannister " + RageAPI.GetHexColorcode(255, 255, 255) + "erworben.");
                }
                else
                {
                    if (Kanister.amount == 10)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast die Maximale anzahl an Kannister schon erreicht!");
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 450);
                        player.SendTranslatedChatMessage("Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " Benzinkannister " + RageAPI.GetHexColorcode(255, 255, 255) + "erworben.");
                        return;
                    }
                    Kanister.amount = Kanister.amount + 1;
                    // Update the amount into the database
                    Database.UpdateItem(Kanister);
                }
                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GET100K);

            }
            else
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
            }
        }

        [ClientEvent("Close_Gas_Window")]
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
            catch { }
        }


        [ClientEvent("Fill_Car_Done")]
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
            catch { }
        }

        [AltV.Net.ClientEvent("Fill_Car")]
        public void Fill_Gas_Car(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    float Gas = vehicle.Gas;
                    float kostenberechnung = 100f - Gas;
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
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - kosten);

                    Alt.Server.TriggerClientEvent(player, "Fill_Car_Accepted", 100, 2000);
                    Alt.Server.TriggerClientEvent(player, "destroyGasWindow");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch { }
        }


        [ClientEvent("Fill_Gas_Liter")]
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
                            Alt.Server.TriggerClientEvent(player, "Fill_Car_Accepted", 100, 2000);
                            Alt.Server.TriggerClientEvent(player, "destroyGasWindow");
                            return;
                        }
                        else
                        {
                            player.Reallife.Money -= kosten;
                            Alt.Server.TriggerClientEvent(player, "Fill_Car_Accepted", vehicle.Gas + value, 2000);
                            Alt.Server.TriggerClientEvent(player, "destroyGasWindow");
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch { }
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
                    //int moneyLeft = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - vehModel.Price;
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOKAUFEN);
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Fahrzeug erfolgreich gekauft! Dein Fahrzeug findest du auf unseren Parkplatz.");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Vergiss nicht dein Fahrzeug umzuparken! nutze /car um dein Fahrzeug zu verwalten.");
                    //player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_BANK, moneyLeft);
                }
            }
            catch { }
        }


        public static bool IsModVehicleName(string Name)
        {
            if (Name == "rmodamgc63" || Name == "rmodm4" || Name == "polamggtr" || Name == "pol718" || Name == "S63w222" || Name == "Lumma750" || Name == "rmodm4")
            {
                return true;
            }
            return false;
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }


        public const float LSPD_CAR_3 = 1.0f;
        public const string GETRIEBE_HANDLING = "FINITIALDRIVEFORCE";
        public const string REIFEN_REIBUNG_HANDLING = "FTRACTIONCURVEMAX"; // Reifenoberflächenreibung
        public const string POLICE3_VEH = "police3";
        //  Alt.Server.TriggerClientEvent(player,"SetIVehicleHandling", IVehicle, GETRIEBE_HANDLING, 30); // FÜRS DRIFT EVENT :D 


        public static float Verbrauch = 0;

        [ClientEvent("Tacho:CalculateTank")]
        public static void CalculateVehicleTank(VnXPlayer player, float speed)
        {
            try
            {
                if (player.Gamemode != (int)_Preload_.Preload.Gamemodes.Reallife) { return; }
                if (player.IsInVehicle)
                {
                    VehicleModel vehClass = (VehicleModel)player.Vehicle;
                    if (player.Vehicle.EngineOn)
                    {
                        float gas = vehClass.Gas;
                        if (gas <= 0)
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Achtung Tank ist leer!");
                            if (gas <= 0)
                            {
                                vehClass.Gas = 0;
                            }
                            vehClass.EngineOn = false;
                            return;
                        }
                        else if (gas == 10)
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Achtung! Tank ist fast leer!");
                        }
                        if (speed <= 10)
                        {
                            Verbrauch = 0.1f;
                        }
                        else
                        {
                            Verbrauch = speed / 100;
                        }
                        vehClass.Gas -= Verbrauch;
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CalculateVehicleTank", ex); }
        }
        public static void Tank(VnXPlayer player, float distance, bool state, VehicleModel vehicle)
        {
            try
            {
                var State = state;
                if (State)
                {
                    int rest = (Convert.ToInt32(distance) * 3);
                    int tank = Convert.ToInt32(vehicle.Gas);
                    int newtank = (tank - rest);
                    if (newtank < 0)
                    {
                        vehicle.EngineOn = false;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Achtung Tank ist leer!");
                        vehicle.Gas = 0;
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else if (newtank < 16 && newtank > 14)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Achtung Tank bald leer!");
                        vehicle.Gas = newtank;
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else
                    {
                        vehicle.Gas = newtank;
                    }

                }
                else
                {
                    vehicle.Gas = 20;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Tank", ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public static void OnPlayerEnterVehicle(VehicleModel Vehicle, VnXPlayer player, byte seat)
        {
            try
            {
                Vehicle.Passenger.Add(player);
                if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife && Vehicle.Driver != player) { Alt.Server.TriggerClientEvent(player, "OnPlayerEnterVehicle", 2500); }
                if (Vehicle.Driver == player)
                {
                    if (Vehicle.Godmode)
                    {
                        Vehicle.Godmode = false;
                    }
                }
                if (Vehicle.Driver == player && player.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    //Alt.Server.TriggerClientEvent(player, "Vehicle:DisableEngineToggle", true); // Disable Auto-TurnOn for Vehicle.
                    Vehicle.Frozen = false;

                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Drücke X um den Motor zu starten.");

                    if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                    {
                        if (player.Reallife.Faction == Constants.FACTION_NONE)
                        {
                            player.WarpOutOfVehicle();
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keiner Fraktion!");
                            return;
                        }
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true)
                    {
                        float kmss = Vehicle.Kms;
                        float gass = Vehicle.Gas;
                        Vehicle.Gas = gass;
                        Vehicle.Kms = kmss;
                        return;
                    }
                    int vehFaction = Vehicle.Faction;

                    if (vehFaction > 0)
                    {
                        int playerFaction = player.Reallife.Faction;

                        if (Allround.isStateIVehicle(Vehicle))
                        {
                            if (player.Reallife.OnDuty != 1)
                            {
                                if (Allround.isStateFaction(player))
                                {
                                    // player.WarpOutOfVehicle();
                                    player.WarpOutOfVehicle();
                                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Polizist im Dienst!");
                                    return;
                                }
                            }
                        }
                        else if (Allround.isBadIVehicle(Vehicle))
                        {
                            if (player.Reallife.OnDutyBad != 1)
                            {
                                if (Allround.isBadFaction(player))
                                {
                                    player.WarpOutOfVehicle();
                                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keinen Gang-Skin an!");
                                    return;
                                }
                            }
                        }
                        else if (Allround.isNeutralIVehicle(Vehicle))
                        {
                            if (player.Reallife.OnDutyNeutral != 1)
                            {
                                if (Allround.isNeutralFaction(player))
                                {
                                    player.WarpOutOfVehicle();
                                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keinen Fraktion´s-Skin an!");
                                    return;
                                }
                            }
                        }

                        if (vehFaction > 0 && playerFaction != vehFaction)
                        {
                            player.WarpOutOfVehicle();
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Mitglied dieser Fraktion!");
                            return;
                        }
                        Vehicle.Frozen = false;
                        if (player.Reallife.Autofuehrerschein == 0)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Du hast keinen Führerschein... <br>Pass auf das du nicht erwischt wirst!");
                        }
                    }
                    float kms = Vehicle.Kms;
                    float gas = Vehicle.Gas;
                    Vehicle.Gas = gas;
                    Vehicle.Kms = kms;
                    Alt.Server.TriggerClientEvent(player, "initializeSpeedometer", kms, gas, Vehicle.EngineOn);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerEnterVehicle", ex); }
        }
        [ClientEvent("OnPlayerEnterVehicleCall")]
        public static void OnPlayerEnterVehicleCall(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    OnPlayerEnterVehicle((VehicleModel)player.Vehicle, player, 0);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerEnterVehicleCall", ex); }
        }


        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public static void OnPlayerExitIVehicle(VehicleModel Vehicle, VnXPlayer player, byte seat)
        {
            try
            {
                Vehicle.Passenger.Remove(player);
                if (Vehicle.Driver == player)
                {
                    if (!Vehicle.Godmode)
                    {
                        Vehicle.Godmode = true;
                    }
                }
                jobs.Allround.OnPlayerLeaveVehicle(Vehicle, player, seat);
                SevenTowers.Main.PlayerLeaveVehicle(Vehicle, player);
            }
            catch (Exception ex) { Debug.CatchExceptions("OnPlayerExitVehicle", ex); }
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
            catch { }
        }

        [ClientEvent("engineOnEventKey")]
        public void EngineOnEventKeyEvent(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel Vehicle = (VehicleModel)player.Vehicle;
                    if (Vehicle.Testing == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        return;
                    }
                    else if (!Vehicle.Testing)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Das Fahrzeug hat nicht mehr genug Benzin - du kannst an einer Tankstelle einen Reservekannister erwerben!");
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        return;
                    }
                    if (Vehicle.Owner == "GANGWAR")
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        return;
                    }
                    if (Vehicle.Rented == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        return;
                    }
                    if (Vehicle.Job == player.vnxGetElementData<string>(EntityData.PLAYER_JOB))
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        return;
                    }
                    // Get player's faction and job
                    int playerFaction = player.Reallife.Faction;
                    int VehicleFaction = Vehicle.Faction;

                    if (Vehicle.Owner != player.Username && VehicleFaction != player.Reallife.Faction)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Schlüssel für dieses Fahrzeug!");
                    }
                    else
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("engineOnEventKey", ex); }
        }

        //[AltV.Net.ClientEvent("saveIVehicleConsumes")]
        public void SaveIVehicleConsumesEvent(VnXPlayer player, VehicleModel Vehicle, float kms, float gas)
        {
            try
            {
                // Update kms and gas
                Vehicle.Kms = kms;
                Vehicle.Gas = gas;
            }
            catch { }
        }

    }
}