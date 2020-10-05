using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus.Führerschein
{
    public class Führerschein : IScript
    {

        public static List<Vector3> Pruefungs_Marker = new List<Vector3>
        {
            // Abgabe Punkte
            new Vector3(-553.3192f, -284.272f, 34.71513f),
            new Vector3(-616.0615f, -320.3712f, 34.32068f),
            new Vector3(-652.6398f, -291.0599f, 35.05244f),
            new Vector3(-726.1739f, -162.1203f, 36.64123f),

            new Vector3(-704.1146f, -80.22077f, 37.45689f),
            new Vector3(-591.7507f, -65.3283f, 41.35535f),
            new Vector3(-555.3825f, -23.12537f, 43.35316f),
            new Vector3(-540.0305f, 112.0313f, 62.56907f),

            new Vector3(-242.8949f, 253.4586f, 91.57272f),
            new Vector3(337.9337f, 135.856f, 102.7196f),
            new Vector3(488.3473f, 86.60764f, 96.20463f),
            new Vector3(670.3608f, 17.58427f, 84.00008f),
            new Vector3(778.3371f, -42.99527f, 80.26731f),
            new Vector3(833.7127f, -8.16668f, 79.89689f),

            new Vector3(1013.954f, 201.9682f, 80.46493f),
            new Vector3(1148.694f, 373.2312f, 90.93845f),
            new Vector3(1104.117f, 420.4642f, 91.02691f),
            new Vector3(1071.502f, 402.1885f, 90.85067f),
            new Vector3(935.7899f, 245.3598f, 79.45423f),
            new Vector3(636.2907f, -209.8139f, 43.78365f),
            new Vector3(509.472f, -357.3975f, 43.03544f),


            new Vector3(298.5442f, -481.2065f, 33.48673f),
            new Vector3(27.65054f, -492.879f, 33.68499f),
            new Vector3(-197.4325f, -479.1166f, 26.78382f),
            new Vector3(-409.9282f, -726.3702f, 36.77649f),
            new Vector3(-404.5771f, -753.1098f, 36.69979f),


            new Vector3(-394.0048f, -643.9979f, 36.43237f),
            new Vector3(-420.4034f, -489.9556f, 33.11342f),
            new Vector3(-609.6374f, -475.6149f, 34.29855f),
            new Vector3(-621.5166f, -395.9995f, 34.33317f),
            new Vector3(-566.845f, -304.6837f, 34.7716f),
            new Vector3(-578.0786f, -248.7701f, 35.37435f),
        };



        public static void Start_Führerschein(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Autofuehrerschein == 1)
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!");
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOSCHEIN);
                    return;
                }
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;
                VehicleModel vehClass = Rathaus.CreateDrivingSchoolVehicle(player, AltV.Net.Enums.VehicleModel.Intruder, new Vector3(-530.3539f, -269.4501f, 35.22854f), new Vector3(0, 0, 130), dim);
                vehClass.Reallife.DrivingSchoolLicense = Rathaus.DRIVINGSCHOOL_LICENSE_CAR;
                vehClass.PrimaryColorRgb = new Rgba(0, 105, 145, 255);
                vehClass.SecondaryColorRgb = new Rgba(255, 255, 255, 255);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Drücke X und H, um Licht oder Motor ein- oder aus zu schalten!");
                Alt.Server.TriggerClientEvent(player, "destroyRathausWindow");
                VnX.SetDelayedData(player, new string[] { "PLAYER_DRIVINGSCHOOL", "true", "bool", "1400" });

                // Prüfung starten mit Marker nr. 1
                player.Reallife.DrivingSchool.MarkerStage = 0;
                Rathaus.CreateDrivingSchoolMarker(player, 611, Pruefungs_Marker[0], 3, new int[] { 255, 255, 255, 255 });
            }
            catch { }
        }



        public static void TriggerToNextPruefungsMarker(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.DrivingSchool.MarkerStage == Pruefungs_Marker.Count)
                {
                    player.Reallife.DrivingSchool.MarkerStage = 0;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    player.Reallife.Autofuehrerschein = 1;
                    player.Reallife.Money -= 10500;
                    player.vnxSetSharedElementData("PLAYER_DRIVINGSCHOOL", false);
                    RageAPI.DeleteVehicleThreadSafe((VehicleModel)player.Vehicle);
                    //player.Vehicle.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOSCHEIN);
                    return;
                }
                else
                {
                    player.Reallife.DrivingSchool.MarkerStage += 1;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Checkpoint erreicht!");
                    int Abgegeben = player.Reallife.DrivingSchool.MarkerStage;
                    Position Destination = Pruefungs_Marker[Abgegeben];
                    Rathaus.CreateDrivingSchoolMarker(player, 611, Destination, 3, new int[] { 0, 200, 255, 255 });
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }



        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    Rathaus.DestroyDrivingSchoolMarker(player);
                    TriggerToNextPruefungsMarker(player);
                }
                else { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Fahrzeug!"); }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        //[ServerEvent(Event.PlayerExitIVehicle)]
        public void OnPlayerExitIVehicle(VehicleModel Vehicle, VnXPlayer player, byte seat)
        {
            try
            {
                if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.Username && player.vnxGetElementData<int>("Marker_Pruefung") >= 0 && player.vnxGetSharedData<bool>("PLAYER_DRIVINGSCHOOL") == true && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "AUTO")
                {
                    //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.vnxSetElementData("Marker_Pruefung", 0);
                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                    dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Fahrprüfung Abgebrochen!");
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    Alt.Server.TriggerClientEvent(player, "Destroy_Rathaus_License_Ped");
                    player.vnxSetElementData("PRUEFUNGS_NAME", false);
                    RageAPI.DeleteVehicleThreadSafe(Vehicle);
                }
            }
            catch { }
        }
    }
}
