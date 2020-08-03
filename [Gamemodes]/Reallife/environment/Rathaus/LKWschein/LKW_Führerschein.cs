using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus.Führerschein
{
    public class LKW_Führerschein : IScript
    {

        public static List<Position> Pruefungs_Marker_LKW = new List<Position>
        {
            // Abgabe Punkte
            new Position(-545.4007f, -286.5386f, 35.46856f),
            new Position(-536.5332f, -347.2885f, 35.28497f),
            new Position(-600.0044f, -370.682f, 35.13462f),
            new Position(-644.1394f, -454.5042f, 34.97767f),

            new Position(-789.2883f, -479.3642f, 26.25574f),
            new Position(-1220.948f, -686.9762f, 11.31333f),
            new Position(-1395.291f, -745.0354f, 10.77514f),
            new Position(-1662.745f, -699.4376f, 10.87358f),

            new Position(-1856.421f, -550.6827f, 11.22869f),

            new Position(-2150.035f, -348.0429f, 12.82741f),
            new Position(-2532.844f, -179.0973f, 19.28004f),
            new Position(-2782.801f, 37.91068f, 14.70067f),
            new Position(-3011.14f, 290.9281f, 14.79811f),
            new Position(-3069.404f, 761.915f, 20.43909f),
            new Position(-3085.081f, 1183.73f, 20.29876f),
            new Position(-2909.146f, 1310.666f, 49.28538f),


            new Position(-2675.084f, 1504.895f, 113.5792f),
            new Position(-2634.452f, 1212.456f, 153.553f),
            new Position(-2364.952f, 1025.831f, 195.3767f),
            new Position(-2106.276f, 952.9053f, 184.2681f),
            new Position(-1762.242f, 818.0464f, 140.8617f),


            new Position(-1935.902f, 657.4457f, 124.118f),
            new Position(-1970.813f, 387.6688f, 94.491f),
            new Position(-1580.838f, -162.0113f, 55.16488f),
            new Position(-1175.24f, -129.1211f, 39.5675f),
            new Position(-786.5172f, -122.0122f, 37.47324f),
            new Position(-565.7501f, -165.7733f, 37.68898f),
        };



        public static void Start_LKW_Führerschein(Client player)
        {
            try
            {
                if (player.Reallife.LKWfuehrerschein == 1)
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!");
                    return;
                }
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;
                Rathaus.CreateDrivingSchoolMarker(player, 611, Pruefungs_Marker_LKW[0], 3, new int[] { 0, 200, 255, 255 });
                VehicleModel PruefungsAuto = Rathaus.CreateDrivingSchoolVehicle(player, AltV.Net.Enums.VehicleModel.Mule3, new Position(-498.1969f, -256.5472f, 35.81237f), new Rotation(0, 0, 120f), dim);
                PruefungsAuto.Reallife.DrivingSchoolLicense = Rathaus.DRIVINGSCHOOL_LICENSE_LKW;

                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Drücke K und H, um Licht oder Motor ein- oder aus zu schalten!");

                Alt.Server.TriggerClientEvent(player, "destroyRathausWindow");
                player.Reallife.DrivingSchool.MarkerStage = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartLKWFührerschein", ex); }
        }



        public static void TriggerToNextPruefungsMarker(Client player)
        {
            try
            {
                if (player.Reallife.DrivingSchool.MarkerStage == Pruefungs_Marker_LKW.Count)
                {
                    player.Reallife.DrivingSchool.MarkerStage = 0;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    player.Reallife.LKWfuehrerschein = 1;
                    player.Reallife.Money -= 16750;
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.Vehicle.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    return;
                }
                else
                {
                    player.Reallife.DrivingSchool.MarkerStage += 1;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Checkpoint erreicht!");
                    Position Destination = Pruefungs_Marker_LKW[player.Reallife.DrivingSchool.MarkerStage];
                    Rathaus.CreateDrivingSchoolMarker(player, 611, Destination, 3, new int[] { 0, 200, 255, 255 });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION TriggerToNextPruefungsMarker] " + ex.Message);
                Console.WriteLine("[EXCEPTION TriggerToNextPruefungsMarker] " + ex.StackTrace);
            }
        }


        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    Rathaus.DestroyDrivingSchoolMarker(player);
                    TriggerToNextPruefungsMarker(player);
                    return;
                }
                else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Fahrzeug!"); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerEnterColShapeModel", ex); }
        }
    }
}
