using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class CarShop : IScript
    {
        public static ColShapeModel carShopTextLabel; // Eig Text label!

        private int GetClosestCarShop(VnXPlayer player, float distance = 2.0f)
        {
            try
            {
                int carShop = -1;
                if (player.Position.Distance(carShopTextLabel.CurrentPosition) < distance)
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


        public static ColShapeModel CARSHOP = RageAPI.CreateColShapeSphere(new Position(-56.88f, -1097.12f, 26.52f), 2.25f);
        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == CARSHOP)
                {
                    List<CarShopVehicleModel> carList = GetIVehicleListInCarShop(0);
                    Alt.Server.TriggerClientEvent(player, "VehicleCatalog:Show");
                    // Getting the speed for each IVehicle in the list
                    foreach (CarShopVehicleModel carShopVehicle in carList)
                    {
                        Alt.Server.TriggerClientEvent(player, "VehicleCatalog:Fill", carShopVehicle.type, carShopVehicle.model, carShopVehicle.price, carList.Count);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ClientEvent("CarShop:TestVehicle")]
        public static void TestVehicle(VnXPlayer player, string Model, string firstColor, string secondColor)
        {
            try
            {
                foreach (VehicleModel vehicleClass in VenoXV.Globals.Main.AllVehicles.ToList())
                {
                    if (vehicleClass.IsTestVehicle && vehicleClass.Owner == player.Username)
                        Core.RageAPI.DeleteVehicleThreadSafe(vehicleClass);
                }
                player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Id;
                AltV.Net.Enums.VehicleModel vehicleModel = (AltV.Net.Enums.VehicleModel)Alt.Hash(Model);
                Console.WriteLine("vehicleModel : " + vehicleModel + " | firstColor : " + firstColor + " | secondColor : " + secondColor);
                string[] firstColor1 = firstColor.Split(',');
                string[] secondColor1 = secondColor.Split(',');
                Rgba Color1 = new Rgba(byte.Parse(firstColor1[0]), byte.Parse(firstColor1[1]), byte.Parse(firstColor1[2]), 255);
                Rgba Color2 = new Rgba(byte.Parse(secondColor1[0]), byte.Parse(secondColor1[1]), byte.Parse(secondColor1[2]), 255);

                VehicleModel vehClass = (VehicleModel)Alt.CreateVehicle(vehicleModel, new Vector3(-51.54087f, -1076.941f, 26.94754f), new Vector3(0, 0, 180f));
                vehClass.Name = "" + vehicleModel;
                vehClass.FirstColor = Color1.R + "," + Color1.G + "," + Color1.B;
                vehClass.SecondColor = Color2.R + "," + Color2.G + "," + Color2.B;
                vehClass.Owner = player.Username;
                vehClass.Plate = "TEST-VEHICLE";
                vehClass.Gas = 100;
                vehClass.Kms = 0;
                vehClass.Faction = 0;
                vehClass.Frozen = false;
                vehClass.Dimension = player.Dimension;
                vehClass.EngineOn = true;
                //Database.AddNewIVehicle(vehClass);
                vehClass.IsTestVehicle = true;
                player.Position = vehClass.Position;
                player.WarpIntoVehicle(vehClass, -1);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        private static int GetVehiclePrice(uint vehicleHash)
        {
            try
            {
                int price = 0;
                foreach (CarShopVehicleModel vehicle in Constants.CARSHOP_VEHICLE_LIST)
                {
                    if ((uint)vehicle.hash == vehicleHash)
                    {
                        price = vehicle.price;
                        break;
                    }
                }
                return price;
            }
            catch { return 0; }
        }

        private static int GetClosestCarShop(VnXPlayer player)
        {
            try
            {
                int carShop = 0;
                if (player.Position.Distance(carShopTextLabel.Position) < 2)
                {
                    carShop = 0;
                }
                return carShop;
            }
            catch { return 0; }
        }
        [ClientEvent("CarShop:BuyVehicle")]
        public static void BuyVehicle(VnXPlayer player, string Model, string firstColor, string secondColor)
        {
            try
            {
                foreach (VehicleModel vehicleClass in VenoXV.Globals.Main.AllVehicles.ToList())
                {
                    if (vehicleClass.IsTestVehicle && vehicleClass.Owner == player.Username)
                        RageAPI.DeleteVehicleThreadSafe(vehicleClass);
                }
                int carShop = GetClosestCarShop(player);
                AltV.Net.Enums.VehicleModel vehicleModel = (AltV.Net.Enums.VehicleModel)Alt.Hash(Model);

                int vehiclePrice = GetVehiclePrice((uint)vehicleModel);
                if (vehiclePrice > 0 && player.Reallife.Bank >= vehiclePrice)
                {
                    switch (carShop)
                    {
                        case 0:
                            player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                            // Create a new car
                            string[] firstColor1 = firstColor.Split(',');
                            string[] secondColor1 = secondColor.Split(',');
                            Rgba Color1 = new Rgba(byte.Parse(firstColor1[0]), byte.Parse(firstColor1[1]), byte.Parse(firstColor1[2]), 255);
                            Rgba Color2 = new Rgba(byte.Parse(secondColor1[0]), byte.Parse(secondColor1[1]), byte.Parse(secondColor1[2]), 255);

                            VehicleModel vehClass = (VehicleModel)Alt.CreateVehicle(vehicleModel, new Vector3(-51.54087f, -1076.941f, 26.94754f), new Vector3(0, 0, 180f));
                            vehClass.Name = "" + vehicleModel;
                            vehClass.FirstColor = Color1.R + "," + Color1.G + "," + Color1.B;
                            vehClass.SecondColor = Color2.R + "," + Color2.G + "," + Color2.B;
                            vehClass.PrimaryColorRgb = Color1;
                            vehClass.SecondaryColorRgb = Color2;
                            vehClass.Owner = player.Username;
                            vehClass.Plate = player.Username;
                            vehClass.Gas = 100;
                            vehClass.Kms = 0;
                            vehClass.Faction = 0;
                            vehClass.Frozen = false;
                            vehClass.Dimension = player.Dimension;
                            vehClass.EngineOn = true;
                            vehClass.IsTestVehicle = false;
                            vehClass.Price = vehiclePrice;
                            player.Position = vehClass.Position;
                            player.WarpIntoVehicle(vehClass, -1);
                            Database.AddNewIVehicle(vehClass);
                            player.Reallife.Bank -= vehiclePrice;
                            break;
                    }
                }
                else
                {
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld auf der Bank!");
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerLeaveVehicle(VehicleModel Vehicle, VnXPlayer player)
        {
            try
            {
                if (Vehicle.IsTestVehicle && Vehicle.Owner == player.Username)
                {
                    RageAPI.DeleteVehicleThreadSafe(Vehicle);
                    player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                }

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
