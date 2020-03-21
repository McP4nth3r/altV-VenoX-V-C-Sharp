using AltV.Net.Elements.Entities;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.business;
using VenoXV.Reallife.weapons;
using VenoXV.Reallife.chat;
using VenoXV.Reallife.jobs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;
using VenoXV.Reallife.dxLibary;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV.Reallife.Core;
using AltV.Net.Async;

namespace VenoXV.Reallife.Vehicles
{
    public class Vehicles : IScript
    {
        private static Dictionary<int, Timer> gasTimerList = new Dictionary<int, Timer>();
        private static Dictionary<int, Timer> IVehicleRespawnTimerList = new Dictionary<int, Timer>();
        public static string INFO_VEHICLE_TURNED_ON = "Motor Angeschaltet!";
        public static string INFO_VEHICLE_TURNED_OFF = "Motor Ausgeschaltet!";
        public void LoadDatabaseVehicles()
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
                    TankstellenCol.SetData("TANKSTELLEN_COL", true);
                    /*Console.WriteLine("Tankstelle [" + counter + "] wurde erstellt! Pos : " + Tankstellen);
                    counter++;*/
                }
            }
            catch { }
        } 


        //[AltV.Net.ClientEvent("Load_VEHICLE_Storage_Datas")]
        public void EnterAsPassenger(IPlayer player)
        {
            try
            {
                IVehicle Vehicle = Main.GetClosestIVehicle(player);
                if (Vehicle == null)
                {
                    return;
                }
                player.Emit("VEHICLE_Data_Storage_load", Vehicle);
                player.SendChatMessage("IVehicle Name " + Vehicle.Model.ToString());
            }
            catch { }
        }
        //[AltV.Net.ClientEvent("showresult_clicked")]
        public void showResult_Clicked(IPlayer player, IVehicle Objekt)
        {
            player.SendChatMessage("Dein Objekt ist : " + Objekt);
        }

        /*[Command("fpark")]
        public static void FactionCarPark(IPlayer player)
        {
            int facId = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
            if (facId > 0)
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_RANK) != 5)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Seit wann bist du Leader deiner Fraktion?");
                    return;
                }

                // Obtain occupied IVehicle
                IVehicle veh = player.Vehicle;
                if (veh != null)
                {
                    VehicleModel IVehicle = new VehicleModel();
                    if (veh.GetSharedData<int>(EntityData.VEHICLE_FACTION) == facId)
                    {
                        IVehicle.position = veh.Position;
                        IVehicle.rotation = veh.Rotation;
                        IVehicle.id = veh.GetSharedData<int>(EntityData.VEHICLE_ID);

                        veh.vnxSetSharedData<Position>(EntityData.VEHICLE_OWNER), IVehicle.position);
                        veh.vnxSetSharedData(EntityData.VEHICLE_ROTATION, IVehicle.rotation);

                        // Update the IVehicle's position into the database
                        Database.UpdateIVehiclePosition(IVehicle);
                        player.SendChatMessage( "~g~Du hast das Fahrzeug umgeparkt.", true);
                    }
                    else
                    {
                        player.SendChatMessage( "~r~Das Fahrzeug gehört deiner Fraktion!", true);
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
                    if (veh.vnxGetElementData<int>(EntityData.VEHICLE_ID) == VehicleId)
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
        public void Factioncarrespawn(IPlayer player)
        {
            try
            {
                int fraktionsID = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                if (fraktionsID > 0)
                {
                    //player.Emit("respawn_mod_IVehicles_c");
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION) == fraktionsID)
                        {
                            Rotation rot = Vehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION);
                            Vehicle.Position = Vehicle.vnxGetElementData<Position>(EntityData.VEHICLE_POSITION);
                            Vehicle.Rotation = new Rotation(rot.Roll, rot.Pitch, (float)(Math.PI * rot.Yaw / 180));
                            Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", 0);
                            Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", 100);
                            Core.VnX.VehiclevnxSetSharedData(Vehicle, "VEHICLE_HEALTH_SERVER", 1000);
                            dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, true);
                            Core.Debug.OutputDebugString("FACTION CAR : RESPAWNED!");
                            Core.Debug.OutputDebugString("Position CAR :" + Vehicle.vnxGetElementData<Position>(EntityData.VEHICLE_POSITION));
                            Core.Debug.OutputDebugString("Position CAR :" + Vehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION));
                        }
                    }
                    factions.Faction.CreateFactionInformation(fraktionsID,player.GetVnXName<string>() + " hat die Fraktion´s Fahrzeuge Respawned!");
                }
                else
                {
                    player.SendChatMessage( "Du bist in keiner Fraktion !");
                }
            }
            catch(Exception ex) { Core.Debug.CatchExceptions("frespawn", ex); }
        }
        


        [Command("sellcarto")]
        public static void SellCarTo(IPlayer player, string target_name, int FahrzeugID, int Preis)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if(target == null) { return; }
                IVehicle Vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                    {
                        if (Preis > 0)
                        {
                            // Sell cAr
                           target.SendChatMessage(RageAPI.GetHexColorcode(0,150,200) +player.GetVnXName<string>() + " bietet dir ein " + Vehicle.Model.ToString().ToLower() + "(" + Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID) + ") für " + Preis + " $ an!");
                           target.SendChatMessage(RageAPI.GetHexColorcode(0,150,200) + "Nutze /buycar ID um das Fahrzeug zu kaufen!");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,150,200) + "Du hast " + target.GetVnXName<string>() + " deinen " + Vehicle.Model.ToString().ToLower() + " für " + Preis + " $ angeboten!");
                            Core.VnX.vnxSetSharedData(target, FahrzeugID.ToString(), Preis);
                        }
                    }
                    else { dxLibary.VnX.DrawNotification(player, "error", "Das Fahrzeug gehört dir nicht!"); }
                }
            }
            catch { }
        }
        /*
        [Command("buycar")]
        public static void BuyCarTo(IPlayer player, int FahrzeugID)
        {
            try
            {
                IVehicle Vehicle = Vehicles.GetVehicleById(FahrzeugID);
                if (Vehicle != null)
                {
                    if (player.vnxGetElementData<int>(FahrzeugID.ToString()) != null)
                    {
                        string target_name = Reallife.Core.RageAPI.GetPlayerFromName(Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER));
                        if(target != null)
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= player.vnxGetElementData<string>(FahrzeugID.ToString()))
                            {
                                if (Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID) == FahrzeugID)
                                {
                                    Vehicle.SetData(EntityData.VEHICLE_OWNER,player.GetVnXName<string>());
                                    Vehicle.SetSyncedMetaData(EntityData.VEHICLE_OWNER,player.GetVnXName<string>());
                                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast das Fahrzeug von " + target.GetVnXName<string>() + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
                                   target.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Du hast dein Fahrzeug " + Vehicle.Model.ToString() + " an " +player.GetVnXName<string>() + " für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ verkauft!");
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - player.vnxGetElementData(FahrzeugID.ToString()));
                                    Core.VnX.vnxSetSharedData(target, EntityData.PLAYER_MONEY, target.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + player.vnxGetElementData(FahrzeugID.ToString()));
                                    player.SetData(FahrzeugID.ToString(), null);
                                    vnx_stored_files.logfile.WriteLogs("IVehicle",player.GetVnXName<string>() + " hat das Fahrzeug von " + target.GetVnXName<string>() + "(" + Vehicle.Model.ToString() + ") für " + player.vnxGetElementData(FahrzeugID.ToString()) + " $ gekauft!");
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


        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>("TANKSTELLEN_COL") == true)
                {
                    int kostenWindow = 0;
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        float Gas = Vehicle.vnxGetSharedData<float>("VEHICLE_GAS_CLIENT");
                        float kostenberechnung = 100f - Gas;
                        kostenWindow = (int)kostenberechnung * 15;
                        dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, true);
                        /*Reallife.Core.RageAPI.SendChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName<string>() + " hat :" + Gas);
                        Reallife.Core.RageAPI.SendChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName<string>() + " hat :" + kostenberechnung);
                        Reallife.Core.RageAPI.SendChatMessageToAll("[VnX - Debug Module 1.0]" +player.GetVnXName<string>() + " hat :" + kostenWindow);*/
                    }
                    player.Emit("createGasWindow", kostenWindow);
                }
            }
            catch
            {
            }
        }


        //[AltV.Net.ClientEvent("Buy_Snack_Server")]
        public void Give_Snack_Func(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 6)
            {
                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GAS_SNACK);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 6);
                player.SendChatMessage( "Du hast einen Tankstellen " + RageAPI.GetHexColorcode(0,200,255) + " Snack " + RageAPI.GetHexColorcode(255,255,255) + "gekauft.");
                ItemModel Snack = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_TANKSTELLENSNACK);
                if (Snack == null) // Kanister
                {
                    Snack = new ItemModel();
                    Snack.amount = Snack.amount + 1;
                    Snack.dimension = 0;
                    Snack.position = new Position(0.0f, 0.0f, 0.0f);
                    Snack.hash = Constants.ITEM_HASH_TANKSTELLENSNACK;
                    Snack.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                    Snack.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                    Snack.ITEM_ART = "NUTZ_ITEM";
                    Snack.objectHandle = null;

                        // Add the item into the database
                        Snack.id = Database.AddNewItem(Snack);
                        Main.itemList.Add(Snack);
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
        public void Give_Kanister_Func(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 450)
            {
                ItemModel Kanister = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_BENZINKANNISTER);
                if (Kanister == null) // Kanister
                {
                    Kanister = new ItemModel();
                    Kanister.amount = Kanister.amount + 1;
                    Kanister.dimension = 0;
                    Kanister.position = new Position(0.0f, 0.0f, 0.0f);
                    Kanister.hash = Constants.ITEM_HASH_BENZINKANNISTER;
                    Kanister.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                    Kanister.ownerIdentifier = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                    Kanister.ITEM_ART = "NUTZ_ITEM";
                    Kanister.objectHandle = null;

                    // Add the item into the database
                    Kanister.id = Database.AddNewItem(Kanister);
                    Main.itemList.Add(Kanister);
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 450);
                    player.SendChatMessage( "Du hast einen " + RageAPI.GetHexColorcode(0,200,255) + " Benzinkannister " + RageAPI.GetHexColorcode(255,255,255) + "erworben.");
                }
                else
                {
                    if (Kanister.amount == 10)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast die Maximale anzahl an Kannister schon erreicht!");
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 450);
                        player.SendChatMessage( "Du hast einen " + RageAPI.GetHexColorcode(0,200,255) + " Benzinkannister " + RageAPI.GetHexColorcode(255,255,255) + "erworben.");
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
        public void Close_Gas_Window(IPlayer player)
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
        public static void FilLCar_Done(IPlayer player, int value)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", value);
                    dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Fill_Car")]
        public void Fill_Gas_Car(IPlayer player)
        {
            try
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
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < kosten)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        return;
                    }
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - kosten);

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
        public void Fill_Car_Liter(IPlayer player, int value)
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
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) < kosten)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                            return;
                        }


                        if (value >= 100)
                        {
                            Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 1500);
                            player.Emit("Fill_Car_Accepted", 100, 2000);
                            player.Emit("destroyGasWindow");
                            return;
                        }
                        else
                        {
                            Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - kosten);
                            player.Emit("Fill_Car_Accepted", Vehicle.vnxGetSharedData<float>("VEHICLE_GAS_CLIENT") + value, 2000);
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
        public static void CreateVehicle(IPlayer player, VehicleModel vehModel, bool adminCreated)
        {
            try
            {
                // Add the IVehicle to the database
                vehModel.id = Database.AddNewIVehicle(vehModel);

                // Create the IVehicle ingame
                CreateIngameVehicle(vehModel);

                if (!adminCreated)
                {
                    int moneyLeft = player.vnxGetElementData<int>(EntityData.PLAYER_BANK) - vehModel.price;
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOKAUFEN);
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255,255,255) + "Fahrzeug erfolgreich gekauft! Dein Fahrzeug findest du auf unseren Parkplatz.");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [VenoX Motorsports] : " + RageAPI.GetHexColorcode(255,255,255) + "Vergiss nicht dein Fahrzeug umzuparken! nutze /car um dein Fahrzeug zu verwalten.");
                    player.SetData(EntityData.PLAYER_BANK, moneyLeft);
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
                if (vehModel.RgbaType == Constants.VEHICLE_Rgba_TYPE_PREDEFINED)
                {
                    string[] firstRgba = vehModel.firstRgba.Split(',');
                    string[] secondRgba = vehModel.secondRgba.Split(',');
                    if (IsModVehicleName(vehModel.model))
                    {
                        Vehicle = Alt.CreateVehicle((AltV.Net.Enums.VehicleModel)Alt.Hash(FirstCharToUpper(vehModel.model)), vehModel.position, vehModel.rotation);
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                    }
                    else
                    {
                        Vehicle = Alt.CreateVehicle((AltV.Net.Enums.VehicleModel)Alt.Hash(FirstCharToUpper(vehModel.model)), vehModel.position, vehModel.rotation);
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                    }
                }
                else
                {
                    string[] firstRgba = vehModel.firstRgba.Split(',');
                    string[] secondRgba = vehModel.secondRgba.Split(',');
                    if (IsModVehicleName(vehModel.model))
                    {
                        Rotation rot = vehModel.rotation;
                        Vehicle = Alt.CreateVehicle((AltV.Net.Enums.VehicleModel)Alt.Hash(FirstCharToUpper(vehModel.model)), vehModel.position, new Rotation(rot.Roll, rot.Pitch, (float)(Math.PI * rot.Yaw / 180)));
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                    }
                    else
                    {
                        Rotation rot = vehModel.rotation;
                        Vehicle = Alt.CreateVehicle((AltV.Net.Enums.VehicleModel)Alt.Hash(FirstCharToUpper(vehModel.model)), vehModel.position, new Rotation(rot.Roll, rot.Pitch, (float)(Math.PI * rot.Yaw / 180)));
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                    }
                    Vehicle.NumberplateText = vehModel.plate == string.Empty ? "LS " + (1000 + vehModel.id) : vehModel.plate;
                    Vehicle.EngineOn = false;
                    Vehicle.Dimension = vehModel.dimension;
                    Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                    Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                }

                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_ID, vehModel.id);
                Core.VnX.IVehicleSetSharedStringData(Vehicle,EntityData.VEHICLE_MODEL, vehModel.model);
                Core.VnX.IVehicleSetSharedPositionData(Vehicle,EntityData.VEHICLE_POSITION, vehModel.position);
                Vehicle.SetData(EntityData.VEHICLE_ROTATION, vehModel.rotation);
                Vehicle.SetSyncedMetaData(EntityData.VEHICLE_ROTATION, vehModel.rotation);
                Core.VnX.VehiclevnxSetSharedData(Vehicle,EntityData.VEHICLE_DIMENSION, vehModel.dimension);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_Rgba_TYPE, vehModel.RgbaType);
                Core.VnX.IVehicleSetSharedStringData(Vehicle,EntityData.VEHICLE_FIRST_Rgba, vehModel.firstRgba);
                Core.VnX.IVehicleSetSharedStringData(Vehicle,EntityData.VEHICLE_SECOND_Rgba, vehModel.secondRgba);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_PEARLESCENT_Rgba, vehModel.pearlescent);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_FACTION, vehModel.faction);
                Core.VnX.IVehicleSetSharedStringData(Vehicle,EntityData.VEHICLE_PLATE, vehModel.plate);
                Core.VnX.IVehicleSetSharedStringData(Vehicle,EntityData.VEHICLE_OWNER, vehModel.owner);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_PRICE, vehModel.price);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_PARKING, vehModel.parking);
                Core.VnX.IVehicleSetSharedINTData(Vehicle,EntityData.VEHICLE_PARKED, vehModel.parked);
                Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MODDED, false); // Alles nicht gemoddete Fahrzeuge aus der DB!
                Core.VnX.VehiclevnxSetSharedData(Vehicle, "VEHICLE_HEALTH_SERVER", 1000);
                Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", vehModel.gas);
                Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", vehModel.kms);
                // Set IVehicle's tunning
                Tunning.AddTunningToIVehicle(Vehicle);
                if(vehModel.faction > Constants.FACTION_NONE)
                {
                    //ToDo Fix it Vehicle.LockState = false;
                    //ToDo Fix it                     Vehicle.Lock
                }
                else
                {
                    //ToDo Fix it                     Vehicle.Locked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION CreateIngameVehicle] " + ex.Message);
                Console.WriteLine("[EXCEPTION CreateIngameVehicle] " + ex.StackTrace);
                Console.WriteLine(vehModel.firstRgba + " | " + vehModel.secondRgba);
            }
        }

       

        //[AltV.Net.ClientEvent("UpdateTacho_Server")]
        public void UpdateTacho_Server(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    float kms = Vehicle.vnxGetSharedData<float>("VEHICLE_KMSPLAYER");
                    float gas = Vehicle.vnxGetSharedData<float>("VEHICLE_GAS_CLIENT");
                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", gas);
                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", kms);
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
        public static void CalculateVehicleTank(IPlayer player, float speed)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    if (player.Vehicle.EngineOn)
                    {
                        float gas = player.Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_GAS);
                        if(gas <= 0)
                        {
                            player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Achtung Tank ist leer!");
                            if (gas < 0)
                            {
                                Core.VnX.VehiclevnxSetSharedData(player.Vehicle, "gas", 0);
                            }
                            return;
                        }
                        else if(gas <= 10)
                        {
                            player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 200, 0) + "Achtung! Tank ist fast leer!");
                        }
                        if (speed <= 10)
                        {
                            Verbrauch = 0.1f;
                        }
                        else
                        {
                            Verbrauch = speed / 100;
                        }
                        Core.VnX.VehiclevnxSetSharedData(player.Vehicle, "gas", gas - Verbrauch);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CalculateVehicleTank", ex); }
        }
        public static void Tank(IPlayer player, float distance, bool state, IVehicle vehicle)
        {
            try
            {
                var State = state;
                if (State)
                {
                    int rest = (Convert.ToInt32(distance) * 3);
                    int tank = Convert.ToInt32(vehicle.vnxGetElementData<float>("VEHICLE_GAS_CLIENT"));
                    int newtank = (tank - rest);
                    if (newtank < 0)
                    {
                        vehicle.EngineOn = false;
                        dxLibary.VnX.DrawNotification(player, "error", "Achtung Tank ist leer!");
                        vehicle.SetSyncedMetaData("VEHICLE_GAS_CLIENT", 0);
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else if (newtank < 16 && newtank > 14)
                    {
                        dxLibary.VnX.DrawNotification(player, "warning", "Achtung Tank bald leer!");
                        vehicle.SetSyncedMetaData("VEHICLE_GAS_CLIENT", newtank);
                        //player.call('Tacho_Benzin_Fix', [player]);
                    }
                    else
                    {
                        vehicle.SetSyncedMetaData("VEHICLE_GAS_CLIENT", newtank);
                    }

                }
                else
                {
                    vehicle.SetSyncedMetaData("VEHICLE_GAS_CLIENT", 20);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Tank", ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public void OnPlayerEnterVehicle(IVehicle Vehicle, IPlayer player, byte seat)
        {
            try
            {
                if (player.Seat == 0)
                {
                    if (Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_MOTOR) == true)
                    {
                        Vehicle.EngineOn = true;
                    }
                    else
                    {
                        Vehicle.EngineOn = false;
                    }

                    /*if(Vehicle.vnxGetElementData("VEHICLE_HEALTH_SERVER") == null)
                    {
                        Core.VnX.VehiclevnxSetSharedData(Vehicle,"VEHICLE_HEALTH_SERVER", 1000);
                    }
                    player.Emit("set_bodyhealth", (int)Vehicle.vnxGetElementData("VEHICLE_HEALTH_SERVER"));*/
                    dxLibary.VnX.DrawNotification(player, "info", "Drücke K um den Motor zu starten.");
                    /*AltV.Net.Enums.VehicleModel veh = NAPI.Util.IVehicleNameToModel(Vehicle.Model.ToString());
                    if (NAPI.Vehicle.GetIVehicleClass(veh) == 8)
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN) != 1)
                        {
                            player.WarpOutOfVehicle<bool>();
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast keinen Motorradschein");
                            return;
                        }
                    }*/
                    if (Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_TESTING) == true)
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
                            float kmss = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_KMS);
                            float gass = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_GAS);
                            Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", gass);
                            Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", kmss);
                            return;
                        }
                        int vehFaction = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);

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

                    float kms = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_KMS);
                    float gas = Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_GAS);
                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", gas);
                    Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", kms);
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
        public void OnPlayerExitIVehicle(IVehicle Vehicle, IPlayer player, byte seat)
        {
            try
            {
                if (player.vnxGetElementData<bool>("FAHRZEUG_AM_TESTEN") == true && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                {
                    player.SetData("FAHRZEUG_AM_TESTEN", false);
                    player.Dimension = 0;
                    player.SendChatMessage(RageAPI.GetHexColorcode(225,0,0) + "[VenoX Motorsport Shop]" + RageAPI.GetHexColorcode(255,255,255) + "Dein Altes Test - Fahrzeug wurde abgegeben!");

                    Vehicle.Remove();
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    player.Position = new Position(-51.54087f, -1076.941f, 26.94754f);
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
            int IVehicleId = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID);
            Timer IVehicleRespawnTimer = new Timer(OnIVehicleDeathTimer, IVehicle, 7500, Timeout.Infinite);
            IVehicleRespawnTimerList.Add(IVehicleId, IVehicleRespawnTimer);
        }
        */
        //[AltV.Net.ClientEvent("stopPlayerCar")]
        public void StopPlayerCarEvent(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    // Turn the engine off
                    Vehicle.EngineOn = false;
                    Core.VnX.IVehicleSetSharedBoolData(Vehicle, EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("engineOnEventKey")]
        public void EngineOnEventKeyEvent(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_TESTING) == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<float>(EntityData.VEHICLE_GAS) <= 0)
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Das Fahrzeug hat nicht mehr genug Benzin - du kannst an einer Tankstelle einen Reservekannister erwerben!");
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    if(Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == "GANGWAR")
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }                    
                    if(Vehicle.vnxGetElementData<bool>(EntityData.VEHICLE_RENTED) == true)
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }                    
                    if(Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == player.vnxGetElementData<string>(EntityData.PLAYER_JOB))
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                        Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                        return;
                    }
                    // Get player's faction and job
                    int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                    int VehicleFaction = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);
                    

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == Constants.ADMINLVL_NONE && VehicleFaction == Constants.FACTION_ADMIN)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Admin!");
                    }
                    else if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) !=player.GetVnXName<string>() && VehicleFaction != player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) && VehicleFaction != Constants.FACTION_ADMIN)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Schlüssel für dieses Fahrzeug!");
                    }
                    else
                    {
                        Vehicle.EngineOn = !Vehicle.EngineOn;
                        player.SendChatMessage(Vehicle.EngineOn ? INFO_VEHICLE_TURNED_ON : INFO_VEHICLE_TURNED_OFF);
                    }
                    Core.VnX.IVehicleSetSharedBoolData(Vehicle,EntityData.VEHICLE_MOTOR, Vehicle.EngineOn);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("saveIVehicleConsumes")]
        public void SaveIVehicleConsumesEvent(IPlayer player, IVehicle Vehicle, float kms, float gas)
        {
            try
            {
                // Update kms and gas
                Core.VnX.VehiclevnxSetSharedData(Vehicle, "kms", kms);
                Core.VnX.VehiclevnxSetSharedData(Vehicle, "gas", gas);
            }
            catch { }
        }



        /*
        [Command(Messages.COM_HOOD)]
        public void HoodCommand(IPlayer player)
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
                        player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NOT_CAR_KEYS);
                    }
                    else if (IVehicle.IsDoorOpen(Constants.VEHICLE_HOOD) == false)
                    {
                        IVehicle.OpenDoor(Constants.VEHICLE_HOOD);
                        player.SendChatMessage(Constants.Rgba_INFO + Messages.INF_HOOD_OPENED);
                    }
                    else
                    {
                        IVehicle.CloseDoor(Constants.VEHICLE_HOOD);
                        player.SendChatMessage(Constants.Rgba_INFO + Messages.INF_HOOD_CLOSED);
                    }
                }
                else
                {
                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_NO_IVehicleS_NEAR);
                }
            }
        }
        */
















    }
}