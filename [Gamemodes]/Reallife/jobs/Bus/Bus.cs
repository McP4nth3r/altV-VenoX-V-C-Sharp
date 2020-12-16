using AltV.Net;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs.Bus
{
    public class Bus : IScript
    {
        public static string BUSJOB_LEVEL = "BUSJOB_LEVEL";
        public static int BUSJOB_LEVEL_ONE_MONEY = 70;
        public static int BUSJOB_LEVEL_TWO_MONEY = 140;
        public static int BUSJOB_LEVEL_THREE_MONEY = 210;
        public static int BUSJOB_ROUND_BONUS = 350;
        public static int BUSJOB_FREEZE_TIME = 4000;
        // BusJob Punkte
        public static List<Vector3> AbgabepunkteLVLONE = new List<Vector3>
        {
            new Vector3(402.7597f, -669.9449f, 28.87156f),
            new Vector3(302.9639f, -768.7956f, 29.31038f),
            new Vector3(242.534f, -939.2287f, 29.2601f),
            new Vector3(359.3319f, -1067.105f, 29.5447f),
            new Vector3(897.1827f, -1010.566f, 33.59047f),
            new Vector3(1108.925f, -966.1584f, 46.56064f),
            new Vector3(1196.669f, -482.2346f, 65.89335f),
            new Vector3(974.1281f, -154.7098f, 73.54858f),
            new Vector3(663.8275f, -12.00813f, 83.75602f),
            new Vector3(491.0322f, -267.3286f, 47.25852f),
            new Vector3(409.1723f, -376.7289f, 46.92794f),
            new Vector3(239.2503f, -596.1932f, 42.80185f),
            new Vector3(114.1052f, -934.5211f, 29.78245f),
            new Vector3(-464.8549f, -825.6618f, 30.52075f),
            new Vector3(-625.824f, -708.9153f, 29.65393f),
            new Vector3(-617.0618f, -411.9111f, 34.76335f),
            new Vector3(-508.3139f, -287.5774f, 35.42538f),
            new Vector3(-362.8997f, -334.1208f, 31.55053f),
            new Vector3(-20.96489f, -274.9718f, 46.76252f),
            new Vector3(101.634f, -535.82f, 43.20762f),
            new Vector3(241.4493f, -862.4976f, 29.70812f),
            new Vector3(442.8245f, -683.4969f, 28.69056f),
        };

        public static void OnResourceStart()
        {
            try
            {
                // Erstellt für jede Koordinate in der Tabelle eine Bus - Station.
                foreach (Vector3 BusCoord in AbgabepunkteLVLONE)
                {

                    _Maps_.Model.MapModel mapClass = new _Maps_.Model.MapModel
                    {
                        MapName = "BusJob",
                        Position = new Vector3(BusCoord.X, BusCoord.Y, BusCoord.Z - 1),
                        Rotation = new Vector3(0, 0, 0),
                    };
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void StartBusJob(VnXPlayer player, int value)
        {
            try
            {   // Die punkte abfragen!
                switch (value)
                {
                    case 1:
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Bus, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JOB_BUS);
                        break;
                    case 2:
                        if (player.Reallife.BUSJOB_LEVEL < 50)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Erst ab Level 50 verfügbar!");
                            return;
                        }
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Airbus, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JOB_BUS);
                        break;
                    case 3:
                        if (player.Reallife.BUSJOB_LEVEL < 150)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Erst ab Level 150 verfügbar!");
                            return;
                        }
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Coach, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JOB_BUS);
                        break;
                }
                player.Reallife.JobMarker = 0;
                player.Reallife.JobStage = value;
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Mach VenoX Mobil!");
                player.vnxSetElementData(BUSJOB_LEVEL, 0);
                Vector3 Destination = AbgabepunkteLVLONE[0];
                Allround.CreateJobMarker(player, 480, Destination, 5, new int[] { 255, 255, 255, 255 });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnJobMarkerHit(VnXPlayer player)
        {
            try
            {
                if (!player.IsInVehicle) return;
                if (player.Reallife.JobMarker >= AbgabepunkteLVLONE.Count)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast eine Runde Erfolgreich absolviert :)");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Dein Bonus beträgt : " + BUSJOB_ROUND_BONUS + " $");
                    player.Reallife.Money += BUSJOB_ROUND_BONUS;
                    player.Reallife.JobMarker = 0;
                }
                else player.Reallife.JobMarker += 1;

                int JobMoney = 0;
                switch (player.Reallife.JobStage)
                {
                    case 1:
                        JobMoney = BUSJOB_LEVEL_ONE_MONEY;
                        break;
                    case 2:
                        JobMoney = BUSJOB_LEVEL_TWO_MONEY;
                        break;
                    case 3:
                        JobMoney = BUSJOB_LEVEL_THREE_MONEY;
                        break;
                }
                player.Reallife.BUSJOB_LEVEL += 1;
                player.Reallife.Money += JobMoney;
                Allround.DestroyJobMarker(player);
                Vector3 Destination = AbgabepunkteLVLONE[player.Reallife.JobMarker];
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                VenoX.TriggerClientEvent(player, "BusJob:CreateTimeout", BUSJOB_FREEZE_TIME);
                vehClass.Frozen = true;
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, JobMoney + " $");
                Allround.CreateJobMarker(player, 480, Destination, 5, new int[] { 255, 255, 255, 255 });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ClientEvent("BusJob:TimeoutDone")]
        public static void BusJobTimeOut(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehClass = (VehicleModel)player.Vehicle;
                    vehClass.Frozen = false;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnPlayerLeaveVehicle(VehicleModel vehClass, VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job != Constants.JOB_BUS || player.Reallife.JobStage <= 0) return;
                RageAPI.DeleteVehicleThreadSafe(vehClass);
                Allround.DestroyJobMarker(player);
                player.SetPosition = AbgabepunkteLVLONE[0];
                player.Reallife.JobStage = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
