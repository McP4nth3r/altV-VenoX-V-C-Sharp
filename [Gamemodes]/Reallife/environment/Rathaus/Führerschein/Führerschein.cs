using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.Rathaus.Führerschein
{
    public class Führerschein : IScript
    {
        public static IColShape Führerschein_Abgabe_Marker { get; set; }

        public static List<Position> Pruefungs_Marker = new List<Position>
        {
            // Abgabe Punkte
            new Position(-553.3192f, -284.272f, 34.71513f),
            new Position(-616.0615f, -320.3712f, 34.32068f),
            new Position(-652.6398f, -291.0599f, 35.05244f),
            new Position(-726.1739f, -162.1203f, 36.64123f),

            new Position(-704.1146f, -80.22077f, 37.45689f),
            new Position(-591.7507f, -65.3283f, 41.35535f),
            new Position(-555.3825f, -23.12537f, 43.35316f),
            new Position(-540.0305f, 112.0313f, 62.56907f),

            new Position(-242.8949f, 253.4586f, 91.57272f),
            new Position(337.9337f, 135.856f, 102.7196f),
            new Position(488.3473f, 86.60764f, 96.20463f),
            new Position(670.3608f, 17.58427f, 84.00008f),
            new Position(778.3371f, -42.99527f, 80.26731f),
            new Position(833.7127f, -8.16668f, 79.89689f),

            new Position(1013.954f, 201.9682f, 80.46493f),
            new Position(1148.694f, 373.2312f, 90.93845f),
            new Position(1104.117f, 420.4642f, 91.02691f),
            new Position(1071.502f, 402.1885f, 90.85067f),
            new Position(935.7899f, 245.3598f, 79.45423f),
            new Position(636.2907f, -209.8139f, 43.78365f),
            new Position(509.472f, -357.3975f, 43.03544f),


            new Position(298.5442f, -481.2065f, 33.48673f),
            new Position(27.65054f, -492.879f, 33.68499f),
            new Position(-197.4325f, -479.1166f, 26.78382f),
            new Position(-409.9282f, -726.3702f, 36.77649f),
            new Position(-404.5771f, -753.1098f, 36.69979f),


            new Position(-394.0048f, -643.9979f, 36.43237f),
            new Position(-420.4034f, -489.9556f, 33.11342f),
            new Position(-609.6374f, -475.6149f, 34.29855f),
            new Position(-621.5166f, -395.9995f, 34.33317f),
            new Position(-566.845f, -304.6837f, 34.7716f),
            new Position(-578.0786f, -248.7701f, 35.37435f),
        };



        public static void Start_Führerschein(Client player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FÜHRERSCHEIN) == 1)
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!");
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOSCHEIN);
                    return;
                }
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;


                IVehicle PruefungsAuto = AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Intruder, new Position(-530.3539f, -269.4501f, 35.22854f), new Rotation(0, 0, 130));
                PruefungsAuto.PrimaryColorRgb = new Rgba(0, 105, 145, 255);
                PruefungsAuto.SecondaryColorRgb = new Rgba(255, 255, 255, 255);
                PruefungsAuto.Dimension = dim;


                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Drücke K und H, um Licht oder Motor ein- oder aus zu schalten!");

                player.Emit("destroyRathausWindow");

                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);


                player.Emit("Create_Rathaus_License_Ped");

                PruefungsAuto.EngineOn = !PruefungsAuto.EngineOn;
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_MODEL, "PruefungsAuto");
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_PLATE, "PruefungsAuto"); ;
                PruefungsAuto.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                PruefungsAuto.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                PruefungsAuto.NumberplateText = "VenoX";
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);
                PruefungsAuto.vnxSetElementData("PRUEFUNGS_AUTO", true);
                PruefungsAuto.vnxSetElementData("PRUEFUNGS_AUTO_BESITZER", player.Username);

                Core.VnX.SetDelayedData(player, new string[] { "Marker_Pruefung", "0", "string", "1400" });
                Core.VnX.SetDelayedData(player, new string[] { "PLAYER_DRIVINGSCHOOL", "true", "bool", "1400" });


                player.vnxSetElementData("PRUEFUNGS_NAME", "AUTO");
                // Prüfung starten mit Marker nr. 1
                Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Pruefungs_Marker[1], 2f);
                Führerschein_Abgabe_Marker.Dimension = player.Dimension;
                dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Pruefungs_Marker[1], 611, 3, player.Dimension);
                dxLibary.VnX.DrawWaypoint(player, Pruefungs_Marker[1].X, Pruefungs_Marker[1].Y);
                Führerschein_Abgabe_Marker.vnxSetElementData("Name", player.Username);
            }
            catch
            {
            }
        }



        public static void TriggerToNextPruefungsMarker(Client player, int counter)
        {
            try
            {
                if (counter == 31)
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.vnxSetElementData("Marker_Pruefung", 0);
                    if (Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") == player.Username)
                    {
                        AltV.Net.Alt.RemoveColShape(Führerschein_Abgabe_Marker);
                    }
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    player.vnxSetElementData(EntityData.PLAYER_FÜHRERSCHEIN, 1);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 10500);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.Emit("Destroy_Rathaus_License_Ped");
                    player.Vehicle.Remove();
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_AUTOSCHEIN);
                    return;
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Checkpoint erreicht!");
                    int Abgegeben = player.vnxGetElementData<int>("Marker_Pruefung");
                    Position Destination = Pruefungs_Marker[Abgegeben + 1];
                    Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Destination, 2f);
                    Führerschein_Abgabe_Marker.Dimension = player.Dimension;
                    Führerschein_Abgabe_Marker.vnxSetElementData("Name", player.Username);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Destination, 611, 3, player.Dimension);
                }
            }
            catch
            {
            }
        }



        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<string>("Name") != player.Username)
                {
                    return;
                }
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && player.vnxGetElementData<int>("Marker_Pruefung") != 31 && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.Username && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "AUTO")
                    {
                        player.vnxSetElementData("Marker_Pruefung", player.vnxGetElementData<int>("Marker_Pruefung") + 1);
                        int counter = player.vnxGetElementData<int>("Marker_Pruefung");
                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                        AltV.Net.Alt.RemoveColShape(shape);
                        TriggerToNextPruefungsMarker(player, counter);
                        return;
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Fahrzeug!");
                }
            }
            catch
            {
            }
        }

        //[ServerEvent(Event.PlayerExitIVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, Client player, byte seat)
        {
            try
            {
                if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.Username && player.vnxGetElementData<int>("Marker_Pruefung") >= 0 && player.vnxGetSharedData<bool>("PLAYER_DRIVINGSCHOOL") == true && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "AUTO")
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.vnxSetElementData("Marker_Pruefung", 0);
                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                    dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                    player.SetPosition = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Fahrprüfung Abgebrochen!");
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.Emit("Destroy_Rathaus_License_Ped");
                    player.vnxSetElementData("PRUEFUNGS_NAME", false);
                    Vehicle.Remove();
                    if (Führerschein_Abgabe_Marker != null && Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") == player.Username)
                    {
                        AltV.Net.Alt.RemoveColShape(Führerschein_Abgabe_Marker);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
    }
}
