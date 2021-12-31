using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.jobs;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Gamemodes_.Reallife.jobs.Airport
{
    public class Airport : IScript
    {
        private const int MoneyStage1 = 85;
        private const int MoneyStage2 = 265;
        private const int MoneyStage3 = 425;
        private static readonly Vector3 AirportHomeSpawn = new Vector3(-1037.645f, -2737.8f, 20.16929f);
        public static void OnJobMarkerHit(VnXPlayer player)
        {
            try
            {
                if (!player.IsInVehicle) { return; }
                switch (player.Reallife.JobStage)
                {
                    case 1:
                        player.Reallife.Money += MoneyStage1;
                        player.SendTranslatedChatMessage("You received " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage1 + " $.");
                        break;
                    case 2:
                        player.Reallife.Money += MoneyStage2;
                        player.SendTranslatedChatMessage("You received " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage2 + " $.");
                        break;
                    case 3:
                        player.Reallife.Money += MoneyStage3;
                        player.SendTranslatedChatMessage("You received " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage3 + " $.");
                        break;
                }
                Allround.DestroyJobMarker(player);
                RageApi.DeleteVehicleThreadSafe((VehicleModel)player.Vehicle);
                player.SetPosition = AirportHomeSpawn;
                player.Reallife.JobStage = 0;
                player.Reallife.AirportJobLevel += 1;
                player.Dimension = Main.ReallifeDimension + player.Language;
            }
            catch (Exception ex) { VenoXV.Core.Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerExitVehicle(VehicleModel vehClass, VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job != Constants.JobAirport || player.Reallife.JobStage <= 0) return;
                RageApi.DeleteVehicleThreadSafe(vehClass);
                Allround.DestroyJobMarker(player);
                player.SetPosition = AirportHomeSpawn;
                player.Reallife.JobStage = 0;
                player.Dimension = Main.ReallifeDimension + player.Language;
                VenoXV.Core.Debug.OutputDebugString("JobStage 2: " + player.Reallife.JobStage);
            }
            catch (Exception ex) { VenoXV.Core.Debug.CatchExceptions(ex); }
        }

        // Transporter Punkte
        public static List<Position> DeliveryPointsAirportLvlOne = new List<Position>
        {
            // Abgabe Punkte
            new Position(1365.956f, 3159.371f, 41.21765f),
            new Position(2011.004f, 4751.968f, 41.86453f),
        };

        //  /coord -1037.697 -1397.189 5
        public static void Airport_job_start(VnXPlayer player, int stage)
        {
            try
            {
                switch (stage)
                {
                    case 1:
                    {
                        int randomjobdim = VnX.GetRandomNumber(1, 99999);
                        VenoXV._Notifications_.Main.DrawNotification(player, VenoXV._Notifications_.Main.Types.Info, "Fly to the drop-off point!");
                        Random random = new Random();
                        Position destination = DeliveryPointsAirportLvlOne[random.Next(0, DeliveryPointsAirportLvlOne.Count)];
                        player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                        VehicleModel airportjobPlane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Dodo, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                        player.Dimension = randomjobdim;
                        airportjobPlane.Dimension = randomjobdim;
                        Allround.CreateJobMarker(player, 611, destination, 7, new[] { 0, 200, 255, 200 });
                        airportjobPlane.EngineOn = true;
                        airportjobPlane.Owner = player.Username;
                        airportjobPlane.Kms = 0;
                        airportjobPlane.Gas = 100;
                        airportjobPlane.Job = Constants.JobAirport;
                        airportjobPlane.NotSave = true;
                        player.WarpIntoVehicle(airportjobPlane, -1);
                        player.Reallife.JobStage = stage;
                        break;
                    }
                    case 2 when player.Reallife.AirportJobLevel <= 50:
                        VenoXV._Notifications_.Main.DrawNotification(player, VenoXV._Notifications_.Main.Types.Error, "You need at least job level 50!"); return;
                    case 2:
                    {
                        int randomjobdim = VnX.GetRandomNumber(1, 99999);
                        VenoXV._Notifications_.Main.DrawNotification(player, VenoXV._Notifications_.Main.Types.Info, "Fly to the drop-off point!");
                        Random random = new Random();
                        Position destination = DeliveryPointsAirportLvlOne[random.Next(0, DeliveryPointsAirportLvlOne.Count)];
                        player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                        VehicleModel airportjobPlane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Shamal, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                        player.Dimension = randomjobdim;
                        airportjobPlane.Dimension = randomjobdim;
                        Allround.CreateJobMarker(player, 611, destination, 7, new[] { 0, 200, 255, 200 });
                        airportjobPlane.EngineOn = true;
                        airportjobPlane.Owner = player.Username;
                        airportjobPlane.Kms = 0;
                        airportjobPlane.Gas = 100;
                        airportjobPlane.Job = Constants.JobAirport;
                        airportjobPlane.NotSave = true;
                        player.WarpIntoVehicle(airportjobPlane, -1);
                        player.Reallife.JobStage = stage;
                        break;
                    }
                    case 3:
                    {
                        int randomjobdim = VnX.GetRandomNumber(1, 99999);
                        VenoXV._Notifications_.Main.DrawNotification(player, VenoXV._Notifications_.Main.Types.Info, "Fly to the drop-off point!");
                        Random random = new Random();
                        Position destination = DeliveryPointsAirportLvlOne[random.Next(0, DeliveryPointsAirportLvlOne.Count)];
                        player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                        VehicleModel airportjobPlane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Jet, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                        player.Dimension = randomjobdim;
                        airportjobPlane.Dimension = randomjobdim;
                        Allround.CreateJobMarker(player, 611, destination, 7, new[] { 0, 200, 255, 200 });
                        airportjobPlane.EngineOn = true;
                        airportjobPlane.Owner = player.Username;
                        airportjobPlane.Kms = 0;
                        airportjobPlane.Gas = 100;
                        airportjobPlane.Job = Constants.JobAirport;
                        airportjobPlane.NotSave = true;
                        player.WarpIntoVehicle(airportjobPlane, -1);
                        player.Reallife.JobStage = stage;
                        break;
                    }
                }
            }
            catch (Exception ex) { VenoXV.Core.Debug.CatchExceptions(ex); }
        }
    }
}