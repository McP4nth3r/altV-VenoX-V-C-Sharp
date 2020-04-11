using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.jobs.Lieferrant
{
    public class Lieferrant : IScript
    {
        // Transporter Punkte
        public static List<Position> AbgabepunkteLVLONE = new List<Position>
        {
            // Abgabe Punkte
            new Position(-617.4387f,-732.4007f,27.87726f),
            new Position(120.4499f,-1113.966f,29.24264f),
            new Position(-653.3912f,-914.8967f,23.0f),
            new Position(-1555.804f,-469.8782f,35.77216f),
            new Position(-1214.005f,338.8955f,71.03339f),
            new Position(413.6921f,-2071.682f,21.50017f),
            new Position(-702.485f,-1141.201f,10.7823f),
            new Position(457.9148f,-943.7695f,28.24007f),
        };



        //  /coord -1037.697 -1397.189 5
        public static void lieferjob_first_start(IPlayer player)
        {
            try
            {
                // Die punkte abfragen!
                player.vnxSetElementData("JOB_STAGE_TRANSPORTER_STARTED", 1);
                dxLibary.VnX.DrawNotification(player, "info", "Beliefer die Firmen!");
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                Random random = new Random();
                Position Destination = AbgabepunkteLVLONE[random.Next(1, 8)];

                JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);

                //player.SendChatMessage("Die koordinaten sind : " + Destination);
                anzeigen.Usefull.VnX.CreateCarGhostMode(player, 255, 102, 7500);
                IVehicle Lieferjob_VEHICLE_1 = Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Rumpo2, new Position(859.674f, -2363.216f, 30), new Rotation(0, 0, 355));
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Lieferjob_VEHICLE_1, -1);
                Lieferjob_VEHICLE_1.EngineOn = true;
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_MODEL, "Rumpo2");
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_FACTION, 0);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_PLATE, "VenoX");
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_OWNER, player.GetVnXName<string>());
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_Rgba_TYPE, Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_FIRST_Rgba, "255,255,255");
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_SECOND_Rgba, "0,255,0");
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_PRICE, 0);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_PARKING, 0);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_PARKED, 0);

                Lieferjob_VEHICLE_1.vnxSetStreamSharedElementData("kms", 0);
                Lieferjob_VEHICLE_1.vnxSetStreamSharedElementData("gas", 100);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_JOB, Constants.JOB_CITY_TRANSPORT);
                Lieferjob_VEHICLE_1.vnxSetElementData(EntityData.VEHICLE_NOT_SAVED, true);

                dxLibary.VnX.SetIVehicleElementFrozen(Lieferjob_VEHICLE_1, player, false);
                Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);
            }
            catch
            {
            }
        }

        public static void TriggerToNextJobMarker(IPlayer player, int stage)
        {
            try
            {
                if (stage == 1)
                {
                    Random random = new Random();
                    Position Destination = AbgabepunkteLVLONE[random.Next(1, 8)];
                    JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                    dxLibary.VnX.DrawNotification(player, "info", "Checkpoint Erreicht! Jetzt zum Nächsten Marker!");
                    player.vnxSetElementData(EntityData.PLAYER_LIEFERJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL) + 1);

                    return;
                }
                else if (stage == 2)
                {
                    Random random = new Random();
                    Position Destination = AbgabepunkteLVLTWO[random.Next(1, 8)];
                    JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                    dxLibary.VnX.DrawNotification(player, "info", "Checkpoint Erreicht! Jetzt zum Nächsten Marker!");
                    player.vnxSetElementData(EntityData.PLAYER_LIEFERJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL) + 2);
                    return;
                }
                else if (stage == 3)
                {
                    Random random = new Random();
                    Position Destination = AbgabepunkteLVLTHREE[random.Next(1, 5)];
                    JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                    dxLibary.VnX.DrawNotification(player, "info", "Checkpoint Erreicht! Jetzt zum Nächsten Marker!");
                    player.vnxSetElementData(EntityData.PLAYER_LIEFERJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL) + 3);
                    return;
                }
            }
            catch
            {
            }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////STAGE 2/////////////////////////////////////////////////////

        // Transporter Punkte
        public static List<Position> AbgabepunkteLVLTWO = new List<Position>
        {
            // Abgabe Punkte
            new Position(985.9548f, -1922.442f, 30.75754f),
            new Position(832.5558f, -1373.897f, 25.75205f),
            new Position(93.65381f, 303.4833f, 109.6381f),
            new Position(-811.1f, -142.5149f, 38.19408f),
            new Position(1135.581f, -294.426f, 68.44021f),
            new Position(1180.683f, -1412.974f, 34.49144f),
            new Position(851.4983f, -1052.726f, 27.75022f),
            new Position(184.8367f, -1475.29f, 28.75455f),
        };


        //  /coord -1037.697 -1397.189 5
        public static void lieferjob_Second_start(IPlayer player)
        {
            try
            {
                // Die punkte abfragen!
                dxLibary.VnX.DrawNotification(player, "info", "Beliefer die Firmen!");
                player.vnxSetElementData("JOB_STAGE_TRANSPORTER_STARTED", 2);
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                Random random = new Random();
                Position Destination = AbgabepunkteLVLTWO[random.Next(1, 8)];

                JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);


                IVehicle Lieferjob_IVehicle = AltV.Net.Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Mule, new Position(832.9737f, -2361.342f, 30), new Rotation(0, 0, 355));
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Lieferjob_IVehicle, -1);
                anzeigen.Usefull.VnX.CreateCarGhostMode(player, 255, 102, 7500);
                //Lieferjob_Vehicle.EngineOn = true;
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_MODEL, "Mule");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_FACTION, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PLATE, "VenoX");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_OWNER, player.GetVnXName<string>());
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_Rgba_TYPE, Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_FIRST_Rgba, "255,255,255");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_SECOND_Rgba, "0,255,0");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PRICE, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PARKING, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PARKED, 0);

                Lieferjob_IVehicle.vnxSetStreamSharedElementData("kms", 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData("gas", 100);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_JOB, Constants.JOB_CITY_TRANSPORT);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_NOT_SAVED, true);

                Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);
            }
            catch
            {

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////STAGE 3/////////////////////////////////////////////////////

        // Transporter Punkte
        public static List<Position> AbgabepunkteLVLTHREE = new List<Position>
        {
            // Abgabe Punkte
            new Position(1220.867f, 1841.29f, 79.34234f),
            new Position(-1139.779f, 2663.431f, 17.98909f),
            new Position(-2550.635f, 2323.115f, 33.11806f),
            new Position(174.8f, 6626.516f, 31.31632f),
            new Position(3588.921f, 3763.998f, 29.5657f),
        };


        //  /coord -1037.697 -1397.189 5
        public static void lieferjob_THIRD_start(IPlayer player)
        {
            try
            {
                // Die punkte abfragen!
                dxLibary.VnX.DrawNotification(player, "info", "Beliefer die Firmen!");
                player.vnxSetElementData("JOB_STAGE_TRANSPORTER_STARTED", 3);
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
                Random random = new Random();
                Position Destination = AbgabepunkteLVLTHREE[random.Next(1, 5)];

                JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 2f);
                dxLibary.VnX.DrawZielBlip(player, "Abgabe [ Transporter Job]", Destination, 611, 75, 0);
                dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName<string>());
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);


                IVehicle Lieferjob_IVehicle = Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Pounder, new Position(897.5522f, -2363.071f, 30.72711f), new Rotation(0, 0, 270));
                //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, Lieferjob_IVehicle, -1);
                anzeigen.Usefull.VnX.CreateCarGhostMode(player, 255, 102, 7500);

                //Lieferjob_Vehicle.EngineOn = true;
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_MODEL, "Mule");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_FACTION, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PLATE, "VenoX");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_OWNER, player.GetVnXName<string>());
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_Rgba_TYPE, Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_FIRST_Rgba, "255,255,255");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_SECOND_Rgba, "0,255,0");
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PRICE, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PARKING, 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_PARKED, 0);

                Lieferjob_IVehicle.vnxSetStreamSharedElementData("kms", 0);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData("gas", 100);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_JOB, Constants.JOB_CITY_TRANSPORT);
                Lieferjob_IVehicle.vnxSetStreamSharedElementData(EntityData.VEHICLE_NOT_SAVED, true);

                Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);
            }
            catch
            {
            }
        }
    }
}
