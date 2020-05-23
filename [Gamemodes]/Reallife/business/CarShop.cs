﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class CarShop : IScript
    {
        public static IColShape carShopTextLabel; // Eig Text label!


        private int GetClosestCarShop(Client player, float distance = 2.0f)
        {
            try
            {
                int carShop = -1;
                if (player.Position.Distance(carShopTextLabel.Position) < distance)
                {
                    carShop = 0;
                }
                return carShop;
            }
            catch { return 0; }
        }

        public static List<CarShopVehicleModel> GetIVehicleListInCarShop(int carShop)
        {
            try
            {
                // Get all the IVehicles in the list
                return Constants.CARSHOP_VEHICLE_LIST.Where(IVehicle => IVehicle.carShop == carShop).ToList();
            }
            catch { return null; }
        }

        private int GetIVehiclePrice(AltV.Net.Enums.VehicleModel VehicleModel)
        {
            try
            {
                int price = 0;
                foreach (CarShopVehicleModel IVehicle in Constants.CARSHOP_VEHICLE_LIST)
                {
                    if (IVehicle.hash == VehicleModel)
                    {
                        price = IVehicle.price;
                        break;
                    }
                }
                return price;
            }
            catch { return 0; }
        }

        private string GetVehicleModel(AltV.Net.Enums.VehicleModel VehicleModel)
        {
            try
            {
                string model = string.Empty;
                foreach (CarShopVehicleModel IVehicle in Constants.CARSHOP_VEHICLE_LIST)
                {
                    if (IVehicle.hash == VehicleModel)
                    {
                        model = IVehicle.model;
                        break;
                    }
                }
                return model;
            }
            catch { return ""; }
        }

        private bool SpawnPurchasedIVehicle(Client player, List<Position> spawns, AltV.Net.Enums.VehicleModel VehicleModel, int IVehiclePrice, string firstRgba, string secondRgba)
        {
            try
            {
                for (int i = 0; i < spawns.Count;)
                {
                    // Basic data for IVehicle creation
                    VehicleModel vehmodel = new VehicleModel();
                    vehmodel.model = VehicleModel.ToString();
                    vehmodel.plate = string.Empty;
                    vehmodel.position = spawns[i];
                    vehmodel.rotation = new Rotation(0.0f, 0.0f, 0.0f);
                    vehmodel.owner = player.Username;
                    vehmodel.RgbaType = Constants.VEHICLE_Rgba_TYPE_CUSTOM;
                    vehmodel.firstRgba = firstRgba;
                    vehmodel.secondRgba = secondRgba;
                    vehmodel.pearlescent = 0;
                    vehmodel.price = IVehiclePrice;
                    vehmodel.parking = 0;
                    vehmodel.parked = 0;
                    vehmodel.engine = 0;
                    vehmodel.locked = 0;
                    vehmodel.gas = 100;
                    vehmodel.kms = 0.0f;

                    // Creating the purchased IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, vehmodel, false);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void OnResourceStart()
        {
            // Car dealer creation
            Core.RageAPI.CreateTextLabel("VENOX CARSHOP", new Position(-56.88f, -1097.12f, 26.52f), 10.0f, 0.5f, 4, new int[] { 255, 255, 255, 255 });
            RageAPI.CreateBlip("Autohändler", new Vector3(-56.88f, -1097.12f, 26.52f), 225, 0, false);
            // Motorcycle dealer creation
            /*motorbikeShopTextLabel = //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("/" + "CSHOP", new Position(286.76f, -1148.36f, 29.29f), 10.0f, 0.5f, 4, new Rgba(255, 255, 153));
            //TextLabel motorbikeShopSubTextLabel = //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel(Messages.GEN_CATALOG_HELP, new Position(286.76f, -1148.36f, 29.19f), 10.0f, 0.5f, 4, new Rgba(255, 255, 255));
            Blip motorbikeShopBlip = NAPI.Blip.CreateBlip(new Position(286.76f, -1148.36f, 29.29f));
            motorbikeShopBlip.Name = "Motorrad händler";
            motorbikeShopBlip.Sprite = 226;

            // Boat dealer creation
            shipShopTextLabel = //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel("/" + "CSHOP", new Position(-711.6249f, -1299.427f, 5.41f), 10.0f, 0.5f, 4, new Rgba(255, 255, 153));
            //TextLabel shipShopSubTextLabel = //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel(Messages.GEN_CATALOG_HELP, new Position(-711.6249f, -1299.427f, 5.31f), 10.0f, 0.5f, 4, new Rgba(255, 255, 255));
            Blip shipShopBlip = NAPI.Blip.CreateBlip(new Position(-711.6249f, -1299.427f, 5.41f));
            shipShopBlip.Name = "Boot Händler";
            shipShopBlip.Sprite = 455;*/


        }


        public static IColShape CARSHOP = Alt.CreateColShapeSphere(new Position(-56.88f, -1097.12f, 26.52f), 2.25f);

        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape == CARSHOP)
                {
                    List<CarShopVehicleModel> carList = GetIVehicleListInCarShop(0);

                    // Getting the speed for each IVehicle in the list
                    foreach (CarShopVehicleModel carShopVehicle in carList)
                    {
                        AltV.Net.Enums.VehicleModel VehicleModel = (AltV.Net.Enums.VehicleModel)uint.Parse(carShopVehicle.model);


                        // carShopIVehicle.speed = (int)Math.Round(NAPI.Vehicle.GetIVehicleMaxSpeed(VehicleModel) * 3.6f);
                    }

                    // We show the catalog
                    player.vnxSetStreamSharedElementData("HideHUD", 1);
                    player.Emit("showIVehicleCatalog", JsonConvert.SerializeObject(carList), 0);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("purchaseIVehicle")]
        public void PurchaseIVehicleEvent(Client player, string hash, string firstRgba, string secondRgba)
        {
            try
            {
                int carShop = GetClosestCarShop(player);
                AltV.Net.Enums.VehicleModel VehicleModel = (AltV.Net.Enums.VehicleModel)uint.Parse(hash);
                int IVehiclePrice = GetIVehiclePrice(VehicleModel);

                if (IVehiclePrice > 0 && player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) >= IVehiclePrice)
                {
                    switch (carShop)
                    {
                        case 0:
                            // Create a new car
                            SpawnPurchasedIVehicle(player, Constants.CARSHOP_SPAWNS, VehicleModel, IVehiclePrice, firstRgba, secondRgba);
                            player.vnxSetStreamSharedElementData("HideHUD", 0);
                            break;
                        case 1:
                            // Create a new motorcycle
                            SpawnPurchasedIVehicle(player, Constants.BIKESHOP_SPAWNS, VehicleModel, IVehiclePrice, firstRgba, secondRgba);
                            break;
                        case 2:
                            // Create a new ship
                            SpawnPurchasedIVehicle(player, Constants.SHIP_SPAWNS, VehicleModel, IVehiclePrice, firstRgba, secondRgba);
                            break;
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld auf der Bank!");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("testIVehicle")]
        public void TestIVehicleEvent(Client player, string hash, string firstRgba, string secondRgba)
        {
            try
            {
                if (player.vnxGetElementData<bool>("FAHRZEUG_AM_TESTEN") == true)
                {
                    foreach (IVehicle veh in Alt.GetAllVehicles())
                    {
                        if (veh.vnxGetElementData<bool>("FAHRZEUG_AM_TESTEN") == true && veh.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.Username)
                        {
                            player.vnxSetElementData("FAHRZEUG_AM_TESTEN", false);
                            veh.Remove();
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(225, 0, 0) + "[VenoX Motorsport Shop] :  " + RageAPI.GetHexColorcode(255, 255, 255) + "Dein Altes Test - Fahrzeug wurde abgegeben!");
                            Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.SetPosition = new Position(-51.54087f, -1076.941f, 26.94754f);
                            player.Dimension = 0;
                        }
                    }
                }
                IVehicle Vehicle = null;
                AltV.Net.Enums.VehicleModel VehicleModel = (AltV.Net.Enums.VehicleModel)uint.Parse(hash);

                switch (GetClosestCarShop(player))
                {
                    case 0:
                        Vehicle = Alt.CreateVehicle(VehicleModel, new Position(-51.54087f, -1076.941f, 26.94754f), new Rotation(0, 0, 75.0f));
                        string[] firstRgba1 = firstRgba.Split(',');
                        string[] secondRgba1 = secondRgba.Split(',');

                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba1[0])), Convert.ToByte(int.Parse(firstRgba1[1])), Convert.ToByte(int.Parse(firstRgba1[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba1[0])), Convert.ToByte(int.Parse(secondRgba1[1])), Convert.ToByte(int.Parse(secondRgba1[2])), 255);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ID, 500);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER, player.Username);

                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);
                        Vehicle.vnxSetStreamSharedElementData("TEST_FAHRZEUG", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "FAHRZEUG_AM_TESTEN", true, 1500);


                        break;
                    case 1:
                        Vehicle = Alt.CreateVehicle(VehicleModel, new Position(307.0036f, -1162.707f, 29.29191f), new Rotation(0, 0, 180.0f));
                        string[] firstRgba2 = firstRgba.Split(',');
                        string[] secondRgba2 = secondRgba.Split(',');
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba2[0])), Convert.ToByte(int.Parse(firstRgba2[1])), Convert.ToByte(int.Parse(firstRgba2[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba2[0])), Convert.ToByte(int.Parse(firstRgba2[1])), Convert.ToByte(int.Parse(firstRgba2[2])), 255);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ID, 500);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER, player.Username);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);

                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                        Vehicle.vnxSetStreamSharedElementData("TEST_FAHRZEUG", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "FAHRZEUG_AM_TESTEN", true, 1500);
                        break;
                    case 2:
                        Vehicle = Alt.CreateVehicle(VehicleModel, new Position(-717.3467f, -1319.792f, -0.42f), new Rotation(0, 0, 180.0f));
                        string[] firstRgba3 = firstRgba.Split(',');
                        string[] secondRgba3 = secondRgba.Split(',');
                        Vehicle.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba3[0])), Convert.ToByte(int.Parse(firstRgba3[1])), Convert.ToByte(int.Parse(firstRgba3[2])), 255);
                        Vehicle.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba3[0])), Convert.ToByte(int.Parse(secondRgba3[1])), Convert.ToByte(int.Parse(secondRgba3[2])), 255);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ID, 500);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER, player.Username);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);

                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                        Vehicle.vnxSetStreamSharedElementData("TEST_FAHRZEUG", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "FAHRZEUG_AM_TESTEN", true, 1500);
                        break;
                }

                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_TESTING, true);
                Vehicle.Dimension = 1200;
                player.Dimension = 1200;
                player.vnxSetElementData(EntityData.PLAYER_TESTING_VEHICLE, Vehicle);
                //player.SetIntoIVehicle(IVehicle, (int)IVehicleSeat.Driver);
                Vehicle.EngineOn = true;
                player.vnxSetStreamSharedElementData("HideHUD", 0);
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("showhudagain")]
        public void ShowHUDAgain(Client player)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 0);
        }
    }
}
