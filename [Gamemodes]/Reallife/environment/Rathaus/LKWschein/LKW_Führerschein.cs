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
    public class LKW_Führerschein : IScript
    {
        public static IColShape LKW_Führerschein_Abgabe_Marker { get; set; }

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



        public static void Start_LKW_Führerschein(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN) == 1)
                {
                    player.SendChatMessage(Constants.Rgba_ERROR + "Du hast bereits einen Führerschein!");
                    return;
                }
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.Dimension = dim;


                IVehicle PruefungsAuto = AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Mule3, new Position(-498.1969f, -256.5472f, 35.81237f), new Rotation(0, 0, 120f));
                PruefungsAuto.Dimension = dim;


                player.SendChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Um die praktische Prüfung abzuschließen, musst die die vorgegebene Strecke abfahren.");
                player.SendChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Beachte dabei jedoch, dass du nicht schneller als 120 km/h fahren darfst - sonst ist die Prüfung gelaufen!");
                player.SendChatMessage(RageAPI.GetHexColorcode(200, 200, 0) + "Drücke K und H, um Licht oder Motor ein- oder aus zu schalten!");

                player.Emit("destroyRathausWindow");
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, PruefungsAuto, -1);


                PruefungsAuto.EngineOn = !PruefungsAuto.EngineOn;
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_MODEL, "PruefungsAuto");
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_PLATE, "PruefungsAuto"); ;
                PruefungsAuto.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                PruefungsAuto.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                PruefungsAuto.NumberplateText = "VenoX";
                PruefungsAuto.vnxSetElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);
                PruefungsAuto.vnxSetElementData("PRUEFUNGS_AUTO", true);
                PruefungsAuto.vnxSetElementData("PRUEFUNGS_AUTO_BESITZER", player.GetVnXName());
                Core.VnX.SetDelayedData(player, new string[] { "Marker_Pruefung", "0", "string", "1400" });
                Core.VnX.SetDelayedData(player, new string[] { "PLAYER_DRIVINGSCHOOL", "true", "bool", "1400" });

                player.vnxSetElementData("PRUEFUNGS_NAME", "LKW");

                // Prüfung starten mit Marker nr. 1
                LKW_Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Pruefungs_Marker_LKW[1], 2f);
                LKW_Führerschein_Abgabe_Marker.Dimension = player.Dimension;
                dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Pruefungs_Marker_LKW[1], 611, 3, player.Dimension);
                dxLibary.VnX.DrawWaypoint(player, Pruefungs_Marker_LKW[1].X, Pruefungs_Marker_LKW[1].Y);
                LKW_Führerschein_Abgabe_Marker.vnxSetElementData("Name", player.GetVnXName());
            }
            catch
            {
            }
        }



        public static void TriggerToNextPruefungsMarker(PlayerModel player, int counter)
        {
            try
            {
                if (counter == 24)
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.vnxSetElementData("Marker_Pruefung", 0);
                    if (LKW_Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") == player.GetVnXName())
                    {
                        AltV.Net.Alt.RemoveColShape(LKW_Führerschein_Abgabe_Marker);
                    }
                    dxLibary.VnX.DrawNotification(player, "info", "Herzlichen Glückwunsch, du hast die Fahrprüfung bestanden!");
                    player.vnxSetElementData(EntityData.PLAYER_LKW_FÜHRERSCHEIN, 1);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 16750);
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.vnxSetElementData("PLAYER_DRIVINGSCHOOL", false);
                    player.Vehicle.Remove();
                    player.position = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    return;
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "info", "Checkpoint erreicht!");
                    int Abgegeben = player.vnxGetElementData<int>("Marker_Pruefung");
                    Position Destination = Pruefungs_Marker_LKW[Abgegeben + 1];
                    LKW_Führerschein_Abgabe_Marker = Alt.CreateColShapeSphere(Destination, 2f);
                    LKW_Führerschein_Abgabe_Marker.Dimension = player.Dimension;
                    LKW_Führerschein_Abgabe_Marker.vnxSetElementData("Name", player.GetVnXName());
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    dxLibary.VnX.DrawZielBlip(player, "Checkpoint [ Führerschein ]", Destination, 611, 3, player.Dimension);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION TriggerToNextPruefungsMarker] " + ex.Message);
                Console.WriteLine("[EXCEPTION TriggerToNextPruefungsMarker] " + ex.StackTrace);
            }
        }


        public static void OnPlayerEnterIColShape(IColShape shape, PlayerModel player)
        {
            try
            {
                if (shape.vnxGetElementData<string>("Name") != player.GetVnXName())
                {
                    return;
                }
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && player.vnxGetElementData<int>("Marker_Pruefung") != 31 && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.GetVnXName() && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "LKW")
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
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Fahrzeug!");
                }
            }
            catch
            {
            }
        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, PlayerModel player, byte seat)
        {
            try
            {
                if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_GODMODE) == false)
                {
                    Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GODMODE, true);
                    foreach (PlayerModel players in VenoXV.Globals.Main.ReallifePlayers)
                    {
                        players.Emit("Vehicle:Godmode", Vehicle, true);
                    }
                }
                if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true && Vehicle.vnxGetElementData<string>("PRUEFUNGS_AUTO_BESITZER") == player.GetVnXName() && player.vnxGetElementData<int>("Marker_Pruefung") >= 0 && player.vnxGetSharedData<bool>("PLAYER_DRIVINGSCHOOL") == true && player.vnxGetElementData<string>("PRUEFUNGS_NAME") == "LKW")
                {
                    player.vnxSetElementData("Marker_Pruefung", 0);
                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                    dxLibary.VnX.DrawWaypoint(player, player.position.X, player.position.Y);
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                    player.position = new Position(-542.6733f, -208.2215f, 37.64983f);
                    player.Dimension = 0;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Fahrprüfung Abgebrochen!");
                    player.SetSyncedMetaData("PLAYER_DRIVINGSCHOOL", false);
                    player.vnxSetElementData("PLAYER_DRIVINGSCHOOL", false);
                    player.Emit("Destroy_Rathaus_License_Ped");
                    player.vnxSetElementData("PRUEFUNGS_NAME", false);
                    Vehicle.Remove();
                    if (LKW_Führerschein_Abgabe_Marker != null && LKW_Führerschein_Abgabe_Marker.vnxGetElementData<string>("Name") == player.GetVnXName())
                    {
                        AltV.Net.Alt.RemoveColShape(LKW_Führerschein_Abgabe_Marker);
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
