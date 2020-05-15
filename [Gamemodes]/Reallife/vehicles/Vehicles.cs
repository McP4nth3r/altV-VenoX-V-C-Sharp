using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Vehicles : IScript
    {
        private static Dictionary<int, Timer> gasTimerList = new Dictionary<int, Timer>();
        private static Dictionary<int, Timer> IVehicleRespawnTimerList = new Dictionary<int, Timer>();
        public static string INFO_VEHICLE_TURNED_ON = "Motor Angeschaltet!";
        public static string INFO_VEHICLE_TURNED_OFF = "Motor Ausgeschaltet!";
        public static void LoadDatabaseVehicles()
        {
            List<VehicleModel> IVehicleList = Database.LoadAllVehicles();
            foreach (VehicleModel vehModel in IVehicleList)
            {
                // Create the IVehicle ingame
                CreateIngameVehicle(vehModel);
            }
        }

        public static void OnResourceStart()
        {
            try
            {
                //int counter = 0;
                foreach (Position Tankstellen in Constants.AUTO_ZAPF_LIST)
                {
                    IColShape TankstellenCol = Alt.CreateColShapeSphere(Tankstellen, 2);
                    TankstellenCol.vnxSetElementData("TANKSTELLEN_COL", true);
                    /*Console.WriteLine("Tankstelle [" + counter + "] wurde erstellt! Pos : " + Tankstellen);
                    counter++;*/
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("Load_VEHICLE_Storage_Datas")]
        public void EnterAsPassenger(Client player)
        {
            try
            {
                IVehicle Vehicle = Main.GetClosestIVehicle(player);
                if (Vehicle == null)
                {
                    return;
                }
                player.Emit("VEHICLE_Data_Storage_load", Vehicle);
                player.SendTranslatedChatMessage("IVehicle Name " + Vehicle.Model.ToString());
            }
            catch { }
        }
        //[AltV.Net.ClientEvent("showresult_clicked")]
        public void showResult_Clicked(Client player, IVehicle Objekt)
        {
            player.SendTranslatedChatMessage("Dein Objekt ist : " + Objekt);
        }

        /*[Command("fpark")]
        public static void FactionCarPark(PlayerModel player)
        {
            int facId = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
            if (facId > 0)
            {
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_RANK) != 5)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Seit wann bist du Leader deiner Fraktion?");
                    return;
                }

                // Obtain occupied IVehicle
                IVehicle veh = player.Vehicle;
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

        public static IVehicle GetVehicleById(int VehicleId)
        {
            try
            {
                IVehicle Vehicle = null;

                foreach (IVehicle veh in Alt.GetAllVehicles())
                {
                    if (veh.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID) == VehicleId)
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
        public void Factioncarrespawn(Client player)
        {
            try
            {
                int fraktionsID = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                if (fraktionsID > 0)
                {
                    //player.Emit("respawn_mod_IVehicles_c");
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION) == fraktionsID)
                        {
                            Vehicle.Position = Vehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_POSITION);
                            Vehicle.Rotation = Vehicle.vnxGetElementData<Rotation>(VenoXV.Globals.EntityData.VEHICLE_ROTATION);
                            Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                            Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                            Vehicle.vnxSetStreamSharedElementData("VEHICLE_HEALTH_SERVER", 1000);
                            dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, true);
                            Core.Debug.OutputDebugString("FACTION CAR : RESPAWNED!");
                            Core.Debug.OutputDebugString("Position CAR :" + Vehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_POSITION));
                            Core.Debug.OutputDebugString("Position CAR :" + Vehicle.vnxGetElementData<Rotation>(VenoXV.Globals.EntityData.VEHICLE_ROTATION));
                        }
                    }
                    factions.Faction.CreateFactionInformation(fraktionsID, player.GetVnXName() + " hat die Fraktion´s Fahrzeuge Respawned!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Du bist in keiner Fraktion !");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("frespawn", ex); }
        }



        [Command("sellcarto")]
        public static void SellCarTo(Client player, string target_name, int FahrzeugID, int Preis)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                IVehicle Vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName())
                    {
                        if (Preis > 0)
                        {
                            // Sell cAr
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName() + " bietet dir ein " + Vehicle.Model.ToString().ToLower() + "(" + Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID) + ") für " + Preis + " $ an!");
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Nutze /buycar ID um das Fahrzeug zu kaufen!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Du hast " + target.GetVnXName() + " deinen " + Vehicle.Model.ToString().ToLower() + " für " + Preis + " $ angeboten!");
                            target.vnxSetStreamSharedElementData(FahrzeugID.ToString(), Preis);
                        }
                    }
                    else { dxLibary.VnX.DrawNotification(player, "error", "Das Fahrzeug gehört dir nicht!"); }
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
                IVehicle Vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (player.vnxGetElementData<int>(FahrzeugID.ToString()) != null)
                    {
                        string target_name = RageAPI.GetPlayerFromName(Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER));
                        if(target != null)
                        {
                            if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= player.vnxGetElementData<string>(FahrzeugID.ToString()))
                            {
                                if (Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID) == FahrzeugID)
                                {
                                    Vehicle.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER,player.GetVnXName());
                                    vehicle.vnxSetSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER,player.GetVnXName());
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast das Fahrzeug von " + target.GetVnXName() + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
                                   target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast dein Fahrzeug " + Vehicle.Model.ToString() + " an " +player.GetVnXName() + " für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ verkauft!");
                                    player.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - player.vnxGetElementData(FahrzeugID.ToString()));
                                    Target.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + player.vnxGetElementData(FahrzeugID.ToString()));
                                    player.vnxSetElementData(FahrzeugID.ToString(), null);
                                    vnx_stored_files.logfile.WriteLogs("IVehicle",player.GetVnXName() + " hat das Fahrzeug von " + target.GetVnXName() + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
                                }
                            }
                            else { dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!"); }
                        }
                        else { dxLibary.VnX.DrawNotification(player, "error", "Spieler ist nicht Online!"); }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Anfrage bekommen für die Fahrzeug ID " + FahrzeugID);
                    }
                }
            }
            catch { }
        }
        */


        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>("TANKSTELLEN_COL") == true)
                {
                    int kostenWindow = 0;
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        float Gas = Vehicle.vnxGetSharedData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                        float kostenberechnung = 100f - Gas;
                        kostenWindow = (int)kostenberechnung * 15;
                        dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, true);
                        /*RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName() + " hat :" + Gas);
                        RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName() + " hat :" + kostenberechnung);
                        RageAPI.SendTranslatedChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName() + " hat :" + kostenWindow);*/
                    }
                    player.Emit("createGasWindow", kostenWindow);
                }
            }
            catch
            {
            }
        }


        //[AltV.Net.ClientEvent("Buy_Snack_Server")]
        public void Give_Snack_Func(Client player)
        {
            if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 6)
            {
                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GAS_SNACK);
                player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 6);
                player.SendTranslatedChatMessage("Du hast einen Tankstellen " + RageAPI.GetHexColorcode(0, 200, 255) + " Snack " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft.");
                ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_TANKSTELLENSNACK);
                if (Snack == null) // Kanister
                {
                    Snack = new ItemModel();
                    Snack.amount = Snack.amount + 1;
                    Snack.dimension = 0;
                    Snack.position = new Position(0.0f, 0.0f, 0.0f);
                    Snack.hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                    Snack.ownerIdentifier = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
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
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast die Maximale anzahl an Snack´s schon erreicht!");
                        return;
                    }
                    Snack.amount = Snack.amount + 1;
                    // Update the amount into the database
                    Database.UpdateItem(Snack);
                }
            }
            else
            {
                dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
            }
        }


        //[AltV.Net.ClientEvent("Buy_Kanister_Server")]
        public void Give_Kanister_Func(Client player)
        {
            if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 450)
            {
                ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                if (Kanister == null) // Kanister
                {
                    Kanister = new ItemModel();
                    Kanister.amount = Kanister.amount + 1;
                    Kanister.dimension = 0;
                    Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                    Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                    Kanister.ownerIdentifier = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                    Kanister.ITEM_ART = "NUTZ_ITEM";
                    Kanister.objectHandle = null;

                    // Add the item into the database
                    Kanister.id = Database.AddNewItem(Kanister);
                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(Kanister);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 450);
                    player.SendTranslatedChatMessage("Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " Benzinkannister " + RageAPI.GetHexColorcode(255, 255, 255) + "erworben.");
                }
                else
                {
                    if (Kanister.amount == 10)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast die Maximale anzahl an Kannister schon erreicht!");
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 450);
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
                dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
            }
        }

        //[AltV.Net.ClientEvent("Close_Gas_Window")]
        public void Close_Gas_Window(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("Fill_Car_Done")]
        public static void FilLCar_Done(Client player, int value)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, value);
                    dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Fill_Car")]
        public void Fill_Gas_Car(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    float Gas = Vehicle.vnxGetSharedData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                    float kostenberechnung = 100f - Gas;
                    int kosten = (int)kostenberechnung * 15;
                    if (kosten == 0)
                    {
                        dxLibary.VnX.DrawNotification(player, "info", "Du musst noch nicht Tanken.");
                        return;
                    }
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < kosten)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - kosten);

                    player.Emit("Fill_Car_Accepted", 100, 2000);
                    player.Emit("destroyGasWindow");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("Fill_Gas_Liter")]
        public void Fill_Car_Liter(Client player, int value)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    if (value > 0)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        int kosten = value * 15;
                        if (kosten == 0)
                        {
                            dxLibary.VnX.DrawNotification(player, "info", "Du musst noch nicht Tanken.");
                            return;
                        }
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < kosten)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                            return;
                        }


                        if (value >= 100)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 1500);
                            player.Emit("Fill_Car_Accepted", 100, 2000);
                            player.Emit("destroyGasWindow");
                            return;
                        }
                        else
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - kosten);
                            player.Emit("Fill_Car_Accepted", Vehicle.vnxGetSharedData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS) + value, 2000);
                            player.Emit("destroyGasWindow");
                        }
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du sitzt in keinem Fahrzeug!");
                }
            }
            catch { }
        }
        public static void CreateVehicle(Client player, VehicleModel vehModel, bool adminCreated)
        {
            try
            {
                // Add the IVehicle to the database
                vehModel.id = Database.AddNewIVehicle(vehModel);

                // Create the IVehicle ingame
                CreateIngameVehicle(vehModel);

                if (!adminCreated)
                {
                    int moneyLeft = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - vehModel.price;
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOKAUFEN);
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Fahrzeug erfolgreich gekauft! Dein Fahrzeug findest du auf unseren Parkplatz.");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Vergiss nicht dein Fahrzeug umzuparken! nutze /car um dein Fahrzeug zu verwalten.");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_BANK, moneyLeft);
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



        private static void CreateIngameVehicle(VehicleModel vehModel)
        {
            try
            {
                IVehicle Vehicle = null;
                string[] firstRgba = vehModel.firstRgba.Split(',');
                string[] secondRgba = vehModel.secondRgba.Split(',');
                Vehicle = Alt.CreateVehicle((AltV.Net.Enums.VehicleModel)Alt.Hash(vehModel.model), vehModel.position, vehModel.rotation);
                if (Vehicle == null) { return; }
                Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                Vehicle.NumberplateText = vehModel.plate == string.Empty ? "LS " + (1000 + vehModel.id) : vehModel.plate;
                Vehicle.EngineOn = false;
                Vehicle.Dimension = vehModel.dimension;
                Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);

                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ID, vehModel.id);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MODEL, vehModel.model);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_POSITION, vehModel.position);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ROTATION, vehModel.rotation);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_DIMENSION, vehModel.dimension);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_Rgba_TYPE, vehModel.RgbaType);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_FIRST_Rgba, vehModel.firstRgba);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_SECOND_Rgba, vehModel.secondRgba);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PEARLESCENT_Rgba, vehModel.pearlescent);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_FACTION, vehModel.faction);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PLATE, vehModel.plate);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER, vehModel.owner);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PRICE, vehModel.price);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PARKING, vehModel.parking);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PARKED, vehModel.parked);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MODDED, false); // Alles nicht gemoddete Fahrzeuge aus der DB!
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_FROZEN, true);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GODMODE, true);
                Vehicle.vnxSetStreamSharedElementData("VEHICLE_HEALTH_SERVER", 1000);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, vehModel.gas);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, vehModel.kms);


                // Set IVehicle's tunning
                Tunning.AddTunningToIVehicle(Vehicle);
                Vehicle.ManualEngineControl = false;
                if (vehModel.faction > Constants.FACTION_NONE)
                {
                    Vehicle.LockState = AltV.Net.Enums.VehicleLockState.Unlocked;
                    //ToDo Fix it Vehicle.LockState = false;
                    //ToDo Fix it                     Vehicle.Lock
                }
                else
                {
                    Vehicle.LockState = AltV.Net.Enums.VehicleLockState.Locked;
                    //ToDo Fix it                     Vehicle.Locked = true;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateIngameVehicle", ex); }
        }



        //[AltV.Net.ClientEvent("UpdateTacho_Server")]
        public void UpdateTacho_Server(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    float kms = Vehicle.vnxGetSharedData<float>("VEHICLE_KMSPLAYER");
                    float gas = Vehicle.vnxGetSharedData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, gas);
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, kms);
                }
            }
            catch { }
        }


        public const float LSPD_CAR_3 = 1.0f;
        public const string GETRIEBE_HANDLING = "FINITIALDRIVEFORCE";
        public const string REIFEN_REIBUNG_HANDLING = "FTRACTIONCURVEMAX"; // Reifenoberflächenreibung
        public const string POLICE3_VEH = "police3";
        //  player.Emit("SetIVehicleHandling", IVehicle, GETRIEBE_HANDLING, 30); // FÜRS DRIFT EVENT :D 


        public static float Verbrauch = 0;

        [ClientEvent("Tacho:CalculateTank")]
        public static void CalculateVehicleTank(Client player, float speed)
        {
            try
            {
                if (player.vnxGetElementData<string>(VenoXV.Globals.EntityData.PLAYER_CURRENT_GAMEMODE) != VenoXV.Globals.EntityData.GAMEMODE_REALLIFE) { return; }
                if (player.IsInVehicle)
                {
                    if (player.Vehicle.EngineOn)
                    {
                        float gas = player.Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                        if (gas <= 0)
                        {
                            player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Achtung Tank ist leer!");
                            if (gas < 0)
                            {
                                player.Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 0);
                            }
                            return;
                        }
                        else if (gas <= 10)
                        {
                            player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(200, 200, 0) + "Achtung! Tank ist fast leer!");
                        }
                        if (speed <= 10)
                        {
                            Verbrauch = 0.1f;
                        }
                        else
                        {
                            Verbrauch = speed / 100;
                        }
                        player.Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, gas - Verbrauch);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CalculateVehicleTank", ex); }
        }
        public static void Tank(Client player, float distance, bool state, IVehicle vehicle)
        {
            try
            {
                var State = state;
                if (State)
                {
                    int rest = (Convert.ToInt32(distance) * 3);
                    int tank = Convert.ToInt32(vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS));
                    int newtank = (tank - rest);
                    if (newtank < 0)
                    {
                        vehicle.EngineOn = false;
                        dxLibary.VnX.DrawNotification(player, "error", "Achtung Tank ist leer!");
                        vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 0);
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else if (newtank < 16 && newtank > 14)
                    {
                        dxLibary.VnX.DrawNotification(player, "warning", "Achtung Tank bald leer!");
                        vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, newtank);
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else
                    {
                        vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, newtank);
                    }

                }
                else
                {
                    vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 20);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Tank", ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public void OnPlayerEnterVehicle(IVehicle Vehicle, Client player, byte seat)
        {
            try
            {
                if (Vehicle.Driver == player)
                {
                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_MOTOR) == true)
                    {
                        Vehicle.EngineOn = true;
                    }
                    else
                    {
                        Vehicle.EngineOn = false;
                    }
                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_GODMODE) == true)
                    {
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GODMODE, false);
                        foreach (Client players in VenoXV.Globals.Main.ReallifePlayers)
                        {
                            players.Emit("Vehicle:Godmode", Vehicle, false);
                        }
                    }
                    Vehicle.SetStreamSyncedMetaData(VenoXV.Globals.EntityData.VEHICLE_FROZEN, false);
                    dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);


                    dxLibary.VnX.DrawNotification(player, "info", "Drücke K um den Motor zu starten.");

                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_TESTING) == true)
                    {
                        if (player.vnxGetElementData<bool>(EntityData.PLAYER_TESTING_VEHICLE) == true)
                        {
                            /*IVehicle testingIVehicle = player.vnxGetElementData<bool>(EntityData.PLAYER_TESTING_VEHICLE);
                            if (Vehicle != testingIVehicle)
                            {
                                player.WarpOutOfVehicle<bool>();
                                return;
                            }*/
                        }
                        else
                        {
                            player.WarpOutOfVehicle<bool>();
                            return;
                        }
                    }
                    else
                    {
                        if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                            {
                                player.WarpOutOfVehicle<bool>();
                                dxLibary.VnX.DrawNotification(player, "error", "Du bist in keiner Fraktion!");
                                return;
                            }
                            return;
                        }
                        if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true)
                        {
                            float kmss = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_KMS);
                            float gass = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                            Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, gass);
                            Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, kmss);
                            return;
                        }
                        int vehFaction = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION);

                        if (vehFaction > 0)
                        {
                            int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);

                            if (factions.Allround.isStateIVehicle(Vehicle))
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) != 1)
                                {
                                    if (factions.Allround.isStateFaction(player))
                                    {
                                        // player.WarpOutOfVehicle<bool>();
                                        player.WarpOutOfVehicle<bool>();
                                        dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Polizist im Dienst!");
                                        return;
                                    }
                                }
                            }
                            else if (factions.Allround.isBadIVehicle(Vehicle))
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY_BAD) != 1)
                                {
                                    if (factions.Allround.isBadFaction(player))
                                    {
                                        // player.WarpOutOfVehicle<bool>();
                                        player.WarpOutOfVehicle<bool>();
                                        dxLibary.VnX.DrawNotification(player, "error", "Du hast keinen Gang-Skin an!");
                                        return;
                                    }
                                }
                            }
                            else if (factions.Allround.isNeutralIVehicle(Vehicle))
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY_NEUTRAL) != 1)
                                {
                                    if (factions.Allround.isNeutralFaction(player))
                                    {
                                        // player.WarpOutOfVehicle<bool>();
                                        player.WarpOutOfVehicle<bool>();
                                        dxLibary.VnX.DrawNotification(player, "error", "Du hast keinen Fraktion´s-Skin an!");
                                        return;
                                    }
                                }
                            }

                            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == Constants.ADMINLVL_NONE && vehFaction == Constants.FACTION_ADMIN)
                            {
                                player.WarpOutOfVehicle<bool>();
                                dxLibary.VnX.DrawNotification(player, "error", "Du bist kein teil des Admin - Teams!");
                                return;
                            }
                            else if (vehFaction > 0 && playerFaction != vehFaction && vehFaction != Constants.FACTION_ADMIN)
                            {
                                player.WarpOutOfVehicle<bool>();
                                dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Mitglied dieser Fraktion!");
                                return;
                            }
                            dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_FÜHRERSCHEIN) == 0)
                            {
                                dxLibary.VnX.DrawNotification(player, "warning", "Du hast keinen Führerschein... <br>Pass auf das du nicht erwischt wirst!");
                            }
                        }
                    }

                    float kms = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_KMS);
                    float gas = Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS);
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, gas);
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, kms);
                    player.Emit("initializeSpeedometer", kms, gas, Vehicle.EngineOn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION IVehicles_OnPlayerEnterIVehicle] " + ex.Message);
                Console.WriteLine("[EXCEPTION IVehicles_OnPlayerEnterIVehicle] " + ex.StackTrace);
            }
        }

        ////[ServerEvent(Event.PlayerExitIVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, Client player, byte seat)
        {
            try
            {
                if (player.vnxGetElementData<bool>("FAHRZEUG_AM_TESTEN") == true && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName())
                {
                    player.vnxSetElementData("FAHRZEUG_AM_TESTEN", false);
                    player.Dimension = 0;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(225, 0, 0) + "[VenoX Motorsport Shop]" + RageAPI.GetHexColorcode(255, 255, 255) + "Dein Altes Test - Fahrzeug wurde abgegeben!");

                    Vehicle.Remove();
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    player.SetPosition = new Position(-51.54087f, -1076.941f, 26.94754f);
                    player.Dimension = 0;
                    return;
                }
                if (player.vnxGetElementData<bool>("InTuningGarage") == true)
                {
                    Tunning.CloseTunningWindow(player);
                }
                player.Emit("resetSpeedometer", Vehicle);
            }
            catch { }
        }

        /*//[ServerEvent(Event.IVehicleDeath)]
        public void OnIVehicleDeath(IVehicle Vehicle)
        {
            int IVehicleId = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID);
            Timer IVehicleRespawnTimer = new Timer(OnIVehicleDeathTimer, IVehicle, 7500, Timeout.Infinite);
            IVehicleRespawnTimerList.Add(IVehicleId, IVehicleRespawnTimer);
        }
        */
        //[AltV.Net.ClientEvent("stopPlayerCar")]
        public void StopPlayerCarEvent(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    // Turn the engine off
                    Vehicle.EngineOn = false;
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("engineOnEventKey")]
        public void EngineOnEventKeyEvent(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_TESTING) == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<float>(VenoXV.Globals.EntityData.VEHICLE_GAS) <= 0)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Das Fahrzeug hat nicht mehr genug Benzin - du kannst an einer Tankstelle einen Reservekannister erwerben!");
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == "GANGWAR")
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_RENTED) == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == player.vnxGetElementData<string>(EntityData.PLAYER_JOB))
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    // Get player's faction and job
                    int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                    int VehicleFaction = Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION);


                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == Constants.ADMINLVL_NONE && VehicleFaction == Constants.FACTION_ADMIN)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Admin!");
                    }
                    else if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) != player.GetVnXName() && VehicleFaction != player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) && VehicleFaction != Constants.FACTION_ADMIN)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Schlüssel für dieses Fahrzeug!");
                    }
                    else
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendTranslatedChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                    }
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("saveIVehicleConsumes")]
        public void SaveIVehicleConsumesEvent(Client player, IVehicle Vehicle, float kms, float gas)
        {
            try
            {
                // Update kms and gas
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, kms);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, gas);
            }
            catch { }
        }



        /*
        [Command(Messages.COM_HOOD)]
        public void HoodCommand(PlayerModel player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0
            {
                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
            }
            else
            {
                IVehicle Vehicle = Main.GetClosestIVehicle(player, 3.75f);
                if (Vehicle != null)
                {
                    if (HasPlayerIVehicleKeys(player, IVehicle) == false && player.vnxGetElementData<string>(EntityData.PLAYER_JOB) != Constants.JOB_MECHANIC)
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NOT_CAR_KEYS);
                    }
                    else if (IVehicle.IsDoorOpen(Constants.VEHICLE_HOOD) == false)
                    {
                        IVehicle.OpenDoor(Constants.VEHICLE_HOOD);
                        player.SendTranslatedChatMessage(Constants.Rgba_INFO + Messages.INF_HOOD_OPENED);
                    }
                    else
                    {
                        IVehicle.CloseDoor(Constants.VEHICLE_HOOD);
                        player.SendTranslatedChatMessage(Constants.Rgba_INFO + Messages.INF_HOOD_CLOSED);
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_IVehicleS_NEAR);
                }
            }
        }
        */
















    }
}