using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Globals_;
using VenoX.Core._Maps_.Models;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.jobs.Bus
{
    public class Bus : IScript
    {
        public static string BusjobLevel = "BUSJOB_LEVEL";
        public static int BusjobLevelOneMoney = 70;
        public static int BusjobLevelTwoMoney = 140;
        public static int BusjobLevelThreeMoney = 210;
        public static int BusjobRoundBonus = 350;
        public static int BusjobFreezeTime = 4000;
        // BusJob Punkte
        public static List<Vector3> AbgabepunkteLvlone = new List<Vector3>
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
                foreach (Vector3 busCoord in AbgabepunkteLvlone)
                {

                    MapModel mapClass = new MapModel
                    {
                        MapName = "BusJob",
                        Position = new Vector3(busCoord.X, busCoord.Y, busCoord.Z - 1),
                        Rotation = new Vector3(0, 0, 0),
                    };
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void StartBusJob(VnXPlayer player, int value)
        {
            try
            {   // Die punkte abfragen!
                switch (value)
                {
                    case 1:
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Bus, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JobBus);
                        break;
                    case 2:
                        if (player.Reallife.BusJobLevel < 50)
                        {
                            Notification.DrawNotification(player, Notification.Types.Info, "Erst ab Level 50 verfügbar!");
                            return;
                        }
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Airbus, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JobBus);
                        break;
                    case 3:
                        if (player.Reallife.BusJobLevel < 150)
                        {
                            Notification.DrawNotification(player, Notification.Types.Info, "Erst ab Level 150 verfügbar!");
                            return;
                        }
                        Allround.CreateJobVehicle(player, AltV.Net.Enums.VehicleModel.Coach, new Vector3(466.3002f, -595.9792f, 28.10545f), new Vector3(0, 0, 190), Constants.JobBus);
                        break;
                }
                player.Reallife.JobMarker = 0;
                player.Reallife.JobStage = value;
                Notification.DrawNotification(player, Notification.Types.Info, "Mach VenoX Mobil!");
                player.VnxSetElementData(BusjobLevel, 0);
                Vector3 destination = AbgabepunkteLvlone[0];
                Allround.CreateJobMarker(player, 480, destination, 5, new[] { 255, 255, 255, 255 });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void OnJobMarkerHit(VnXPlayer player)
        {
            try
            {
                if (!player.IsInVehicle) return;
                if (player.Reallife.JobMarker >= AbgabepunkteLvlone.Count)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast eine Runde Erfolgreich absolviert :)");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 0, 0) + "Dein Bonus beträgt : " + BusjobRoundBonus + " $");
                    player.Reallife.Money += BusjobRoundBonus;
                    player.Reallife.JobMarker = 0;
                }
                else player.Reallife.JobMarker += 1;

                int jobMoney = 0;
                switch (player.Reallife.JobStage)
                {
                    case 1:
                        jobMoney = BusjobLevelOneMoney;
                        break;
                    case 2:
                        jobMoney = BusjobLevelTwoMoney;
                        break;
                    case 3:
                        jobMoney = BusjobLevelThreeMoney;
                        break;
                }
                player.Reallife.BusJobLevel += 1;
                player.Reallife.Money += jobMoney;
                Allround.DestroyJobMarker(player);
                Vector3 destination = AbgabepunkteLvlone[player.Reallife.JobMarker];
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                _RootCore_.VenoX.TriggerClientEvent(player, "BusJob:CreateTimeout", BusjobFreezeTime);
                vehClass.Frozen = true;
                Notification.DrawNotification(player, Notification.Types.Info, jobMoney + " $");
                Allround.CreateJobMarker(player, 480, destination, 5, new[] { 255, 255, 255, 255 });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("BusJob:TimeoutDone")]
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
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void OnPlayerLeaveVehicle(VehicleModel vehClass, VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job != Constants.JobBus || player.Reallife.JobStage <= 0) return;
                RageApi.DeleteVehicleThreadSafe(vehClass);
                Allround.DestroyJobMarker(player);
                player.SetPosition = AbgabepunkteLvlone[0];
                player.Reallife.JobStage = 0;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
