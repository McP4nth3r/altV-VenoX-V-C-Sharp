using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;
using VehicleModel = AltV.Net.Enums.VehicleModel;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class CarShop : IScript
    {
        public static ColShapeModel CarShopTextLabel; // Eig Text label!

        private int GetClosestCarShop(VnXPlayer player, float distance = 2.0f)
        {
            try
            {
                int carShop = -1;
                if (player.Position.Distance(CarShopTextLabel.CurrentPosition) < distance)
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
                return Constants.CarshopVehicleList.Where(vehicle => vehicle.CarShop == carShop).ToList();
            }
            catch { return null; }
        }

        private int GetIVehiclePrice(VehicleModel vehicleModel)
        {
            try
            {
                int price = 0;
                foreach (CarShopVehicleModel vehicle in Constants.CarshopVehicleList)
                {
                    if (vehicle.Hash == vehicleModel)
                    {
                        price = vehicle.Price;
                        break;
                    }
                }
                return price;
            }
            catch { return 0; }
        }

        private string GetVehicleModel(VehicleModel vehicleModel)
        {
            try
            {
                string model = string.Empty;
                foreach (CarShopVehicleModel vehicle in Constants.CarshopVehicleList)
                {
                    if (vehicle.Hash == vehicleModel)
                    {
                        model = vehicle.Model;
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
            RageApi.CreateTextLabel("VENOX CARSHOP", new Position(-56.88f, -1097.12f, 26.52f), 10.0f, 0.5f, 4, new[] { 255, 255, 255, 255 });
            RageApi.CreateBlip("Autohändler", new Vector3(-56.88f, -1097.12f, 26.52f), 225, 0, false);
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


        public static ColShapeModel Carshop = RageApi.CreateColShapeSphere(new Position(-56.88f, -1097.12f, 26.52f), 2.25f);
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != Carshop) return false;
                List<CarShopVehicleModel> carList = GetIVehicleListInCarShop(0);
                VenoX.TriggerClientEvent(player, "VehicleCatalog:Show");
                // Getting the speed for each IVehicle in the list
                foreach (CarShopVehicleModel carShopVehicle in carList)
                    VenoX.TriggerClientEvent(player, "VehicleCatalog:Fill", carShopVehicle.Type, carShopVehicle.Model, carShopVehicle.Price, carList.Count);

                return true;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }

        [VenoXRemoteEvent("CarShop:TestVehicle")]
        public static void TestVehicle(VnXPlayer player, string model, string firstColor, string secondColor)
        {
            try
            {
                foreach (Models.VehicleModel vehicleClass in Main.AllVehicles.ToList())
                {
                    if (vehicleClass.IsTestVehicle && vehicleClass.Owner == player.Username)
                        RageApi.DeleteVehicleThreadSafe(vehicleClass);
                }
                player.Dimension = (Main.ReallifeDimension + player.Language) + player.Id;
                VehicleModel vehicleModel = (VehicleModel)Alt.Hash(model);
                Console.WriteLine("vehicleModel : " + vehicleModel + " | firstColor : " + firstColor + " | secondColor : " + secondColor);
                string[] firstColor1 = firstColor.Split(',');
                string[] secondColor1 = secondColor.Split(',');
                Rgba color1 = new Rgba(byte.Parse(firstColor1[0]), byte.Parse(firstColor1[1]), byte.Parse(firstColor1[2]), 255);
                Rgba color2 = new Rgba(byte.Parse(secondColor1[0]), byte.Parse(secondColor1[1]), byte.Parse(secondColor1[2]), 255);

                Models.VehicleModel vehClass = (Models.VehicleModel)Alt.CreateVehicle(vehicleModel, new Vector3(-51.54087f, -1076.941f, 26.94754f), new Vector3(0, 0, 180f));
                vehClass.Name = "" + vehicleModel;
                vehClass.FirstColor = color1.R + "," + color1.G + "," + color1.B;
                vehClass.SecondColor = color2.R + "," + color2.G + "," + color2.B;
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
                foreach (CarShopVehicleModel vehicle in Constants.CarshopVehicleList)
                {
                    if ((uint)vehicle.Hash == vehicleHash)
                    {
                        price = vehicle.Price;
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
                if (player.Position.Distance(CarShopTextLabel.Position) < 2)
                {
                    carShop = 0;
                }
                return carShop;
            }
            catch { return 0; }
        }
        [VenoXRemoteEvent("CarShop:BuyVehicle")]
        public static void BuyVehicle(VnXPlayer player, string model, string firstColor, string secondColor)
        {
            try
            {
                foreach (Models.VehicleModel vehicleClass in Main.AllVehicles.ToList())
                {
                    if (vehicleClass.IsTestVehicle && vehicleClass.Owner == player.Username)
                        RageApi.DeleteVehicleThreadSafe(vehicleClass);
                }
                int carShop = GetClosestCarShop(player);
                VehicleModel vehicleModel = (VehicleModel)Alt.Hash(model);

                int vehiclePrice = GetVehiclePrice((uint)vehicleModel);
                if (vehiclePrice > 0 && player.Reallife.Bank >= vehiclePrice)
                {
                    switch (carShop)
                    {
                        case 0:
                            player.Dimension = Main.ReallifeDimension + player.Language;
                            // Create a new car
                            string[] firstColor1 = firstColor.Split(',');
                            string[] secondColor1 = secondColor.Split(',');
                            Rgba color1 = new Rgba(byte.Parse(firstColor1[0]), byte.Parse(firstColor1[1]), byte.Parse(firstColor1[2]), 255);
                            Rgba color2 = new Rgba(byte.Parse(secondColor1[0]), byte.Parse(secondColor1[1]), byte.Parse(secondColor1[2]), 255);

                            Models.VehicleModel vehClass = (Models.VehicleModel)Alt.CreateVehicle(vehicleModel, new Vector3(-51.54087f, -1076.941f, 26.94754f), new Vector3(0, 0, 180f));
                            vehClass.Name = "" + vehicleModel;
                            vehClass.FirstColor = color1.R + "," + color1.G + "," + color1.B;
                            vehClass.SecondColor = color2.R + "," + color2.G + "," + color2.B;
                            vehClass.PrimaryColorRgb = color1;
                            vehClass.SecondaryColorRgb = color2;
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
                            Database.Database.AddNewIVehicle(vehClass);
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

        public static void OnPlayerLeaveVehicle(Models.VehicleModel vehicle, VnXPlayer player)
        {
            try
            {
                if (vehicle.IsTestVehicle && vehicle.Owner == player.Username)
                {
                    RageApi.DeleteVehicleThreadSafe(vehicle);
                    player.Dimension = Main.ReallifeDimension + player.Language;
                }

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
