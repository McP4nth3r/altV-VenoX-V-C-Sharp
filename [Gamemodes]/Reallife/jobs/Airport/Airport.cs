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
                    // Die punkte abfragen!
                    player.vnxSetElementData("JOB_STAGE_AIRPORT_STARTED", 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(1, 2)];
                    if (Destination != new Position(1365.956f, 3159.371f, 41.21765f) || Destination != new Position(2011.004f, 4751.968f, 41.86453f))
                    {
                        Destination = new Position(2011.004f, 4751.968f, 41.86453f);
                    }

                    JoB_Allround.JobAbgabeMarker = RageAPI.CreateColShapeSphere(Destination, 5.5f);
                    dxLibary.VnX.DrawCustomZielBlip(player, "Abgabe [ Airport Job]", Destination, 7, 611, 75, randomjobdim, 0, 150, 200, 255);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.Username);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);


                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Dodo, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Airportjob_Plane, -1);

                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;


                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.Save = true;
                    Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);

                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;


                }
                else if (stage == 2)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    // Die punkte abfragen!
                    player.vnxSetElementData("JOB_STAGE_AIRPORT_STARTED", 1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[random.Next(1, 2)];
                    if (Destination != new Position(1365.956f, 3159.371f, 41.21765f) || Destination != new Position(2011.004f, 4751.968f, 41.86453f))
                    {
                        Destination = new Position(2011.004f, 4751.968f, 41.86453f);
                    }

                    JoB_Allround.JobAbgabeMarker = RageAPI.CreateColShapeSphere(Destination, 5.5f);
                    dxLibary.VnX.DrawCustomZielBlip(player, "Abgabe [ Airport Job]", Destination, 7, 611, 75, randomjobdim, 0, 150, 200, 255);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.Username);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);


                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Shamal, new Position(-1354.069f, -3133.099f, 14.94444f), new Rotation(0, 0, 233));
                    //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Airportjob_Plane, -1);

                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;

                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.Save = true;
                    Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);
                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                }
                else if (stage == 3)
                {
                    int randomjobdim = anzeigen.Usefull.VnX.GetRandomNumber(1, 99999);
                    // Die punkte abfragen!
                    player.vnxSetElementData("JOB_STAGE_AIRPORT_STARTED", 0);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Flieg zum Abgabepunkt!");
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    Random random = new Random();
                    Position Destination = Abgabepunkte_Airport_LVLONE[0];

                    JoB_Allround.JobAbgabeMarker = RageAPI.CreateColShapeSphere(Destination, 7.5f);
                    dxLibary.VnX.DrawCustomZielBlip(player, "Abgabe [ Airport Job]", Destination, 14, 611, 75, randomjobdim, 0, 150, 200, 255);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.Username);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);


                    VehicleModel Airportjob_Plane = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Jet, new Position(-1354.069f, -3133.099f, 22.94444f), new Rotation(0, 0, 233));
                    //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Airportjob_Plane, -1);

                    Airportjob_Plane.EngineOn = true;
                    Airportjob_Plane.Owner = player.Username;

                    Airportjob_Plane.Kms = 0;
                    Airportjob_Plane.Gas = 100;
                    Airportjob_Plane.Job = Constants.JOB_AIRPORT;
                    Airportjob_Plane.Save = true;
                    Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);

                    player.Dimension = randomjobdim;
                    Airportjob_Plane.Dimension = randomjobdim;
                }
            }
            catch
            {
            }
        }



    }
}
