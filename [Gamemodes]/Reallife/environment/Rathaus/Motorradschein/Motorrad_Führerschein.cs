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
    public class Motorrad_Führerschein : IScript
    {

        public static List<Position> Pruefungs_Marker_Motorrad = new List<Position>
        {
            // Abgabe Punkte
            new Position(-551.3809f, -283.5138f, 34.95578f),
            new Position(-611.8216f, -330.0212f, 34.66497f),
            new Position(-637.3196f, -404.4857f, 34.6342f),
            new Position(-639.4766f, -541.1515f, 34.37155f),

            new Position(-640.2631f, -637.3783f, 31.74466f),
            new Position(-640.093f, -810.9933f, 24.90793f),
            new Position(-525.366f, -840.6982f, 30f),
            new Position(-388.604f, -845.0259f, 31.14802f),

            new Position(-63.47833f, -943.2358f, 29.24098f),
            new Position(76.99503f, -995.1344f, 29.22859f),
            new Position(199.0866f, -1037.3f, 29.19356f),
            new Position(378.4436f, -1062.035f, 29f),
            new Position(395.0652f, -1116.167f, 29.20426f),
            new Position(235.1645f, -1128.164f, 29f),

            new Position(224.2253f, -1069.918f, 28.6899f),
            new Position(254.1409f, -967.3699f, 28.85343f),
            new Position(279.8127f, -881.8735f, 28.7211f),
            new Position(205.0972f, -819.3483f, 30.38632f),
            new Position(213.6046f, -721.8645f, 34.25427f),
            new Position(299.909f, -500.6701f, 42.86506f),
            new Position(313.2527f, -411.5337f, 44.6475f),


            new Position(209.769f, -344.5851f, 43.61891f),
            new Position(54.10761f, -286.3116f, 47.08262f),
            new Position(-83.24027f, -233.9258f, 44.40356f),
            new Position(-188.7244f, -190.9428f, 43.34349f),
            new Position(-310.0878f, -175.8952f, 39.06522f),


            new Position(-399.0732f, -209.6364f, 35.80101f),
            new Position(-440.7825f, -234.7732f, 35.60778f),
            new Position(-510.386f, -266.5325f, 35.11856f),
            new Position(-550.7675f, -283.9033f, 34.69683f),
            new Position(-574.4612f, -265.0121f, 35.00417f),
            new Position(-593.0808f, -223.2929f, 36.07925f),
        };



        public static void Start_Motorrad_Führerschein(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Motorradfuehrerschein == 1) { player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!"); return; }
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;

                VehicleModel PruefungsAuto = Rathaus.CreateDrivingSchoolVehicle(player, AltV.Net.Enums.VehicleModel.Hakuchou, new Position(-530.3539f, -269.4501f, 35.22854f), new Rotation(0, 0, 120f), dim, true);
                PruefungsAuto.Reallife.DrivingSchoolLicense = Rathaus.DRIVINGSCHOOL_LICENSE_BIKE;

                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Drücke X und H, um Licht oder Motor ein- oder aus zu schalten!");

                Alt.Server.TriggerClientEvent(player, "destroyRathausWindow");

                player.Reallife.DrivingSchool.MarkerStage = 0;
                Core.VnX.SetDelayedData(player, new string[] { "PLAYER_DRIVINGSCHOOL", "true", "bool", "1400" });
                Rathaus.CreateDrivingSchoolMarker(player, 611, Pruefungs_Marker_Motorrad[0], 3, new int[] { 0, 200, 255, 255 });
            }
            catch { }
        }



        public static void TriggerToNextPruefungsMarker(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.DrivingSchool.MarkerStage == Pruefungs_Marker_Motorrad.Count)
                {
                    player.Reallife.DrivingSchool.MarkerStage = 0;
                    player.Reallife.Motorradfuehrerschein = 1;
                    player.Reallife.Money -= 8750;
                    player.Vehicle.Remove();
                    player.vnxSetStreamSharedElementData("PLAYER_DRIVINGSCHOOL", false);
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    return;
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Checkpoint erreicht!");
                    player.Reallife.DrivingSchool.MarkerStage += 1;
                    int Abgegeben = player.Reallife.DrivingSchool.MarkerStage;
                    Position Destination = Pruefungs_Marker_Motorrad[Abgegeben];
                    Rathaus.CreateDrivingSchoolMarker(player, 611, Destination, 3, new int[] { 0, 200, 255, 255 });
                }
            }
            catch { }
        }


        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    Rathaus.DestroyDrivingSchoolMarker(player);
                    TriggerToNextPruefungsMarker(player);
                    return;
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Fahrzeug!");
                }
            }
            catch { }
        }

    }
}
