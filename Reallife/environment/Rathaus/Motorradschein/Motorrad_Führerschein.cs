using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Core;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.Environment.Rathaus.Führerschein
{
    public class Motorrad_Führerschein : IScript
    {
        public static IColShape Motorrad_Führerschein_Abgabe_Marker { get; set; }

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



        public static void Start_Motorrad_Führerschein(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN) == 1)
                {
                    player.SendChatMessage( Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!");
                    return;
                }
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;


                IVehicle PruefungsAuto = AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Hakuchou, new Position(-530.3539f, -269.4501f, 35.22854f), new Rotation(0,0,120f));
                PruefungsAuto.Dimension = dim;


                player.SendChatMessage(RageAPI.GetHexColorcode(200,200,0) +"Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendChatMessage(RageAPI.GetHexColorcode(200,200,0) +"Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendChatMessage(RageAPI.GetHexColorcode(200,200,0) +"Drücke K und H, um Licht oder Motor ein- oder aus zu schalten!");

                player.Emit("destroyRathausWindow");
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);


                PruefungsAuto.EngineOn = !PruefungsAuto.EngineOn;
                PruefungsAuto.SetData(EntityData.VEHICLE_MODEL, "PruefungsAuto");
                PruefungsAuto.SetData(EntityData.VEHICLE_PLATE, "PruefungsAuto"); ;
                Core.VnX.VehiclevnxSetSharedData(PruefungsAuto, "kms", 0);
                Core.VnX.VehiclevnxSetSharedData(PruefungsAuto, "gas", 100);
                PruefungsAuto.NumberplateText = "VenoX";
                PruefungsAuto.SetData(EntityData.VEHICLE_NOT_SAVED, true);
                PruefungsAuto.SetData("PRUEFUNGS_AUTO", true);
                PruefungsAuto.SetData("PRUEFUNGS_AUTO_BESITZER",player.GetVnXName<string>());


                Core.VnX.SetDelayedData(player, new string[] { "Marker_Pruefung", "0", "string", "1400" });
                Core.VnX.SetDelayedData(player, new string[] { "PLAYER_DRIVINGSCHOOL", "true", "bool", "1400" });

                player.SetData("PRUEFUNGS_NAME", "BIKE");

                // Prüfung starten mit Marker nr. 1
                Motorrad_Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Pruefungs_Marker_Motorrad[1], 2f);
                Motorrad_Führerschein_Abgabe_Marker.Dimension = player.Dimension;
               dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Pruefungs_Marker_Motorrad[1], 611, 3, player.Dimension);
                dxLibary.VnX.DrawWaypoint(player, Pruefungs_Marker_Motorrad[1].X, Pruefungs_Marker_Motorrad[1].Y);
                Motorrad_Führerschein_Abgabe_Marker.SetData("Name",player.GetVnXName<string>());
            }
            catch
            {
            }
        }
        


        public static void TriggerToNextPruefungsMarker(IPlayer player, int counter)
        {
            try
            {
                if (counter == 31)
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.SetData("Marker_Pruefung", 0);
                    if (Motorrad_Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") ==player.GetVnXName<string>())
                    {
                        AltV.Net.Alt.RemoveColShape(Motorrad_Führerschein_Abgabe_Marker);
                    }
                    dxLibary.VnX.DrawNotification(player, "info", "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    player.SetData(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, 1);
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 8750);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.SetData("PLAYER_DRIVINGSCHOOL", false);
                    player.Vehicle.Remove();
                    player.Position = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    return;
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "info", "Checkpoint erreicht!");
                    int Abgegeben = player.vnxGetElementData<int>("Marker_Pruefung");
                    Position Destination = Pruefungs_Marker_Motorrad[Abgegeben + 1];
                    Motorrad_Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Destination, 2f);
                    Motorrad_Führerschein_Abgabe_Marker.Dimension = player.Dimension;
                    Motorrad_Führerschein_Abgabe_Marker.SetData("Name",player.GetVnXName<string>());
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                   dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Destination, 611, 3, player.Dimension);
                }
            }
            catch
            {
            }
        }


        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape.vnxGetElementData<string>("Name") !=player.GetVnXName<string>())
                {
                    return;
                }
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && player.vnxGetElementData<int>("Marker_Pruefung") != 31 && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") ==player.GetVnXName<string>() && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "BIKE")
                    {
                        player.SetData("Marker_Pruefung", player.vnxGetElementData<int>("Marker_Pruefung") + 1);
                        int counter = player.vnxGetElementData<int>("Marker_Pruefung");
                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                        AltV.Net.Alt.RemoveColShape(shape);
                        TriggerToNextPruefungsMarker(player, counter);
                        return;
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Fahrzeug!");
                }
            }
            catch
            {
            }
        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, IPlayer player, byte seat)
        {
            try
            {
                if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") ==player.GetVnXName<string>() && player.vnxGetElementData<int>("Marker_Pruefung") >= 0 && player.vnxGetSharedData<bool>("PLAYER_DRIVINGSCHOOL") == true && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "BIKE")
                {
                    player.SetData("Marker_Pruefung", 0);
                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                    dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.Position = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255,0,0)+ "Fahrprüfung Abgebrochen!");
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.SetData("PLAYER_DRIVINGSCHOOL", false);
                    player.Emit("Destroy_Rathaus_License_Ped");
                    player.SetData("PRUEFUNGS_NAME", false);
                    Vehicle.Remove();
                    if (Motorrad_Führerschein_Abgabe_Marker != null && Motorrad_Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") ==player.GetVnXName<string>())
                    {
                        AltV.Net.Alt.RemoveColShape(Motorrad_Führerschein_Abgabe_Marker);
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
