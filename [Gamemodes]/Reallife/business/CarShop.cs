using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
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
        public static ColShapeModel carShopTextLabel; // Eig Text label!


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

        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == CARSHOP.Entity)
                {
                    List<CarShopVehicleModel> carList = GetIVehicleListInCarShop(0);

                    // Getting the speed for each IVehicle in the list
                    foreach (CarShopVehicleModel carShopVehicle in carList)
                    {
                        AltV.Net.Enums.VehicleModel vehicle = (AltV.Net.Enums.VehicleModel)uint.Parse(carShopVehicle.model);


                        // carShopIVehicle.speed = (int)Math.Round(NAPI.Vehicle.GetIVehicleMaxSpeed(VehicleModel) * 3.6f);
                    }

                    // We show the catalog
                    player.vnxSetStreamSharedElementData("HideHUD", 1);
                    player.Emit("showIVehicleCatalog", JsonConvert.SerializeObject(carList), 0);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("showhudagain")]
        public void ShowHUDAgain(Client player)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 0);
        }
    }
}
