using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs.Airport
{
    public class Airport : IScript
    {
        public const int MONEY_STAGE_1 = 85;
        public const int MONEY_STAGE_2 = 265;
        public const int MONEY_STAGE_3 = 425;
        public static Vector3 AIRPORT_HOME_SPAWN = new Vector3(-1037.645f, -2737.8f, 20.16929f);
        public static void OnJobMarkerHit(Client player)
        {
            try
            {
                if (!player.IsInVehicle) { return; }
                Allround.DestroyJobMarker(player);
                player.Vehicle.Remove();
                player.SetPosition = AIRPORT_HOME_SPAWN;
                player.Reallife.JobStage = 0;
                player.Dimension = 0;
                switch (player.Reallife.JobStage)
                {
                    case 1:
                        player.Reallife.Money += MONEY_STAGE_1;
                        player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + MONEY_STAGE_1 + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                    case 2:
                        player.Reallife.Money += MONEY_STAGE_2;
                        player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + MONEY_STAGE_2 + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                    case 3:
                        player.Reallife.Money += MONEY_STAGE_3;
                        player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + MONEY_STAGE_3 + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " Bekommen.");
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("OnJobMarkerHit", ex); }
        }

        public static void OnPlayerExitVehicle(VehicleModel vehClass, Client player)
        {
            try
            {
                if (player.Reallife.Job == Constants.JOB_AIRPORT && player.Reallife.JobStage > 0)
                {
                    player.WarpOutOfVehicle();
                    Allround.DestroyJobMarker(player);
                    vehClass.Remove();
                    player.SetPosition = AIRPORT_HOME_SPAWN;
                    player.Reallife.JobStage = 0;
                    player.Dimension = 0;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("OnPlayerExitVehicle", ex); }
        }

        // Transporter Punkte
        public static List<Position> Abgabepunkte_Airport_LVLONE = new List<Position>
        {
            // Abgabe Punkte
            new Position(1365.956f, 3159.371f, 41.21765f),
            new Position(2011.004f, 4751.968f, 41.86453f),
        };

        //  /coord -1037.697 -1397.189 5
        public static void Airport_job_start(Client player, int stage)
        {
            try
            {
                if (stage == 1)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(0, Abgabepunkte_Airport_LVLONE.Count)];
                    player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Dodo, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);
                    player.Reallife.JobStage = stage;
                }
                else if (stage == 2)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(0, Abgabepunkte_Airport_LVLONE.Count)];
                    player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Shamal, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);
                    player.Reallife.JobStage = stage;

                }
                else if (stage == 3)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(0, Abgabepunkte_Airport_LVLONE.Count)];
                    player.SetPosition = new Vector3(-1354.069f, -3133.099f, 14.94444f);
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Jet, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);
                    player.Reallife.JobStage = stage;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartAirportJob", ex); }
        }
    }
}