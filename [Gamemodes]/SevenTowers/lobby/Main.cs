using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.SevenTowers.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.SevenTowers
{
    public class Main : IScript
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS 
        public static int SEVENTOWERS_ROUND_MINUTE = 3;                       // Zeit in Sekunden.
        public static int SEVENTOWERS_ROUND_START_AFTER_LOADING = 5;          // Zeit in Sekunden.
        public static int SEVENTOWERS_ROUND_JOINTIME = 5;                     // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas
        public static bool SEVENTOWERS_ROUND_IS_RUNNING = false;
        public static List<IVehicle> SevenTowersVehicles = new List<IVehicle>();
        public static DateTime SEVENTOWERS_ROUND_END;
        public static DateTime SEVENTOWERS_ROUND_WILL_START;
        public static DateTime SEVENTOWERS_ROUND_JOINTIME_TILL_START;
        public static List<SpawnModel> SevenTowerSpawns = new List<SpawnModel>();
        public static int VEHICLE_LIST_MAX = 0;


        public static List<Position> SPAWNPOINT_COORDS = new List<Position> // CONSTANT 7TOWERS SPAWNS
        {
            new Position(67.753845f, -5843.222f, 79.84619f),
            new Position(94.496704f, -5818.1406f, 85.13696f),
            new Position(168.1978f, -5832.0923f, 86.51868f),
            new Position(199.29231f, -5815.1606f, 86.51868f),
            new Position(197.74945f, -5720.123f, 87.1084f),
            new Position(190.97144f, -5687.8813f, 86.73767f),
            new Position(127.97802f, -5662.1934f, 87.765625f),
            new Position(52.87912f, -5683.5034f, 96.22412f),
            new Position(94.61539f, -5719.609f, 85.15381f),
        };


        public static List<AltV.Net.Enums.VehicleModel> VEHICLE_HASHES = new List<AltV.Net.Enums.VehicleModel> // CONSTANT 7TOWERS VEHICLES
        {
            AltV.Net.Enums.VehicleModel.Adder,
            AltV.Net.Enums.VehicleModel.Sultan,
            AltV.Net.Enums.VehicleModel.Bmx,
            AltV.Net.Enums.VehicleModel.Bus,
            AltV.Net.Enums.VehicleModel.Raiden,
            AltV.Net.Enums.VehicleModel.Turismo2,
            AltV.Net.Enums.VehicleModel.T20,
            AltV.Net.Enums.VehicleModel.SultanRs,
            AltV.Net.Enums.VehicleModel.F620,
            AltV.Net.Enums.VehicleModel.Police,
            AltV.Net.Enums.VehicleModel.Police3,
            AltV.Net.Enums.VehicleModel.Turismo2,
            AltV.Net.Enums.VehicleModel.Asea2,
        };

        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            int cevent = random.Next(min, max);
            return cevent;
        }
        public static void OnResourceStart()
        {
            try
            {
                foreach (Position pos in SPAWNPOINT_COORDS)
                {
                    SpawnModel spawnClass = new SpawnModel
                    {
                        Position = pos,
                        Spawned = false
                    };
                    SevenTowerSpawns.Add(spawnClass);
                }
                foreach (AltV.Net.Enums.VehicleModel vehicles in VEHICLE_HASHES) { VEHICLE_LIST_MAX++; }
            }
            catch { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void InitializePlayerData(Client player)
        {
            try
            {
                player.SevenTowers.Spawned = false;
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("InitializePlayerData", ex);
            }

        }

        public static bool CanPlayerJoin()
        {
            if (SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_JOINTIME_TILL_START <= DateTime.Now)
            {
                return true;
            }
            else if (SEVENTOWERS_ROUND_IS_RUNNING || SEVENTOWERS_ROUND_END > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public static void PutPlayerSpectate(Client player)
        {
            player.SendTranslatedChatMessage("Du bist zuschauer!");
        }

        public static void StartNewRound()
        {
            try
            {
                foreach (Client player in Globals.Main.SevenTowersPlayers)
                {
                    InitializePlayerData(player);
                    SpawnPlayerInRound(player);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("StartNewRound", ex);
            }
        }
        public static void EndRound()
        {
            try
            {
                foreach (IVehicle veh in SevenTowersVehicles)
                {
                    Alt.RemoveVehicle(veh);
                }
                foreach (Client player in Globals.Main.SevenTowersPlayers)
                {
                    //if (player.IsInVehicle) { Reallife.dxLibary.VnX.SetIVehicleElementFrozen((VehicleModel)player.Vehicle, player, true); return; }
                    //Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("EndRound", ex);
            }
        }

        public static void SpawnPlayerInRound(Client player)
        {
            try
            {
                foreach (SpawnModel Spawns in SevenTowerSpawns.ToList())
                {
                    if (!Spawns.Spawned && !player.SevenTowers.Spawned) // Wenn Spawn nicht Belegt
                    {
                        VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(VEHICLE_HASHES[GetRandomNumber(0, VEHICLE_LIST_MAX)], Spawns.Position, new Rotation(0, 0, 0));
                        player.SpawnPlayer(Spawns.Position);

                        player.SevenTowers.Spawned = true;
                        player.WarpIntoVehicle(vehicle, -1);
                        SevenTowersVehicles.Add(vehicle);
                        vehicle.Kms = 0;
                        vehicle.Gas = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("SpawnPlayerInRound", ex);
            }
        }
        public static void PutPlayerInRound(Client player)
        {
            try
            {
                InitializePlayerData(player);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "~ ~ ~ ~ 7 TOWERS ~ ~ ~ ~ ");
                SpawnPlayerInRound(player);
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("PutPlayerInRound", ex);
            }
        }


        public static void JoinedSevenTowers(Client player)
        {
            try
            {
                if (Globals.Main.SevenTowersPlayers.Count <= 1) { StartNewRound(); return; }
                if (CanPlayerJoin())
                {
                    PutPlayerInRound(player);
                }
                else
                {
                    PutPlayerSpectate(player);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("JoinedSevenTowers", ex);
            }
        }

        public static void OnUpdate()
        {
            try
            {
                if (SEVENTOWERS_ROUND_END <= DateTime.Now)
                {
                    EndRound();
                    SEVENTOWERS_ROUND_IS_RUNNING = false;
                    SEVENTOWERS_ROUND_WILL_START = DateTime.Now.AddSeconds(SEVENTOWERS_ROUND_START_AFTER_LOADING);
                }

                if (!SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
                {
                    if (Globals.Main.SevenTowersPlayers.Count > 0)
                    {
                        StartNewRound();
                        SEVENTOWERS_ROUND_IS_RUNNING = true;
                        SEVENTOWERS_ROUND_END = DateTime.Now.AddMinutes(SEVENTOWERS_ROUND_MINUTE);
                        SEVENTOWERS_ROUND_JOINTIME_TILL_START = DateTime.Now.AddSeconds(SEVENTOWERS_ROUND_JOINTIME);
                    }
                }
            }
            catch { }
        }
    }
}
