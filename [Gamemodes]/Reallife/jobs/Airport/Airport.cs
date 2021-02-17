using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoXV._Gamemodes_.Reallife.jobs.Airport
{
    public class Airport : IScript
    {
        public const int MoneyStage1 = 85;
        public const int MoneyStage2 = 265;
        public const int MoneyStage3 = 425;
        public static Vector3 AirportHomeSpawn = new Vector3(-1037.645f, -2737.8f, 20.16929f);
        public static void OnJobMarkerHit(VnXPlayer player)
        {
            try
            {
                if (!player.IsInVehicle) { return; }
                switch (player.Reallife.JobStage)
                {
                    case 1:
                        player.Reallife.Money += MoneyStage1;
                        player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage1 + " $" + RageApi.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                    case 2:
                        player.Reallife.Money += MoneyStage2;
                        player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage2 + " $" + RageApi.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                    case 3:
                        player.Reallife.Money += MoneyStage3;
                        player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + MoneyStage3 + " $" + RageApi.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                }
                Allround.DestroyJobMarker(player);
                RageApi.DeleteVehicleThreadSafe((VehicleModel)player.Vehicle);
                player.SetPosition = AirportHomeSpawn;
                player.Reallife.JobStage = 0;
                player.Reallife.AirportJobLevel += 1;
                player.Dimension = Main.ReallifeDimension + player.Language;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerExitVehicle(VehicleModel vehClass, VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job == Constants.JobAirport && player.Reallife.JobStage > 0)
                {
                    RageApi.DeleteVehicleThreadSafe(vehClass);
                    Allround.DestroyJobMarker(player);
                    player.SetPosition = AirportHomeSpawn;
                    player.Reallife.JobStage = 0;
                    player.Dimension = Main.ReallifeDimension + player.Language;
                    Debug.OutputDebugString("JobStage 2: " + player.Reallife.JobStage);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        // Transporter Punkte
        public static List<Position> AbgabepunkteAirportLvlone = new List<Position>
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
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                        Random random = new Random();
                        Position destination = AbgabepunkteAirportLvlone[random.Next(0, AbgabepunkteAirportLvlone.Count)];
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
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst mindestens Job-Level 50!"); return;
                    case 2:
                    {
                        int randomjobdim = VnX.GetRandomNumber(1, 99999);
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                        Random random = new Random();
                        Position destination = AbgabepunkteAirportLvlone[random.Next(0, AbgabepunkteAirportLvlone.Count)];
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
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                        Random random = new Random();
                        Position destination = AbgabepunkteAirportLvlone[random.Next(0, AbgabepunkteAirportLvlone.Count)];
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}