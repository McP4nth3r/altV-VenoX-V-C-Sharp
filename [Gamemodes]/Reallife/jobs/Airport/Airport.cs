using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs.Airport
{
    public class Airport : IScript
    {

        public static void OnJobMarkerHit(Client player)
        {

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
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Dodo, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    jobs.Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);
                }
                else if (stage == 2)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(0, Abgabepunkte_Airport_LVLONE.Count)];
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Shamal, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    jobs.Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);

                }
                else if (stage == 3)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(0, Abgabepunkte_Airport_LVLONE.Count)];
                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Jet, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    jobs.Allround.CreateJobMarker(player, 611, Destination, 7, new int[] { 0, 200, 255, 200 });
                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;
                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.NotSave = true;
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                    player.WarpIntoVehicle(Airportjob_Plane, -1);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartAirportJob", ex); }
        }
    }
}