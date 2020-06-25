using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.SevenTowers.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.SevenTowers
{
    public class Main
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS 
        public static int SEVENTOWERS_ROUND_MINUTE = 3;                       // Zeit in Sekunden.
        public static int SEVENTOWERS_ROUND_START_AFTER_LOADING = 5;          // Zeit in Sekunden.
        public static int SEVENTOWERS_ROUND_JOINTIME = 5;                     // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).
        public static int SEVENTOWERS_DIM = 60;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas
        public static bool SEVENTOWERS_ROUND_IS_RUNNING = false;
        public static List<Client> CurrentlyInRound = new List<Client>();
        public static List<VehicleModel> SevenTowersVehicles = new List<VehicleModel>();
        public static List<ColShapeModel> ColShapeModelList = new List<ColShapeModel>();
        public static IColShape CurrentColShape;
        public static List<MarkerModel> MarkerModelList = new List<MarkerModel>();
        public static DateTime SEVENTOWERS_ROUND_END = DateTime.Now;
        public static DateTime SEVENTOWERS_ROUND_WILL_START = DateTime.Now;
        public static DateTime SEVENTOWERS_ROUND_JOINTIME_TILL_START = DateTime.Now;
        public static List<SpawnModel> SevenTowerSpawns = maps.main.Spawns.SpawnCoords;
        public static string CURRENT_WINNER = "ERROR";

        public static readonly List<Vector3> SevenTowersCheckPoints = new List<Vector3>()
        {
            new Vector3(210.13187f, -5742.5933f, 86.78833f),
            new Vector3(188.84836f, -5790.923f, 86.78833f),
            new Vector3(94.32527f, -5778.725f, 85.12012f),
            new Vector3(75.24396f, -5757.5737f, 85.12012f),
            new Vector3(86.58462f, -5854.826f, 79.86304f),
            new Vector3(127.56923f, -5833.53f, 79.86304f),
            new Vector3(30.13187f, -5812.9844f, 76.86377f),
            new Vector3(39.916485f, -5875.8066f, 76.86377f),
            new Vector3(16.312088f, -5734.312f, 98.98755f),
            new Vector3(6.435165f, -5706.712f, 98.98755f),
            new Vector3(90.184616f, -5645.222f, 93.140625f),
            new Vector3(94.12747f, -5676.0527f, 93.140625f),
            new Vector3(156.14505f, -5670.066f, 85.12012f),
            new Vector3(164.14944f, -5700.158f, 85.12012f),

        };


        public static readonly List<AltV.Net.Enums.VehicleModel> VEHICLE_HASHES = new List<AltV.Net.Enums.VehicleModel> // CONSTANT 7TOWERS VEHICLES
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
            AltV.Net.Enums.VehicleModel.Asea,
            AltV.Net.Enums.VehicleModel.Stretch,
            AltV.Net.Enums.VehicleModel.Manchez,
            AltV.Net.Enums.VehicleModel.Stratum,
            AltV.Net.Enums.VehicleModel.Felon,
            AltV.Net.Enums.VehicleModel.Brioso,
            AltV.Net.Enums.VehicleModel.Dominator,
            AltV.Net.Enums.VehicleModel.Biff,
            AltV.Net.Enums.VehicleModel.BfInjection,
            AltV.Net.Enums.VehicleModel.Cavalcade2,
            AltV.Net.Enums.VehicleModel.Alpha,
            AltV.Net.Enums.VehicleModel.Bison,
            AltV.Net.Enums.VehicleModel.Stockade,
            AltV.Net.Enums.VehicleModel.Barracks2,
            AltV.Net.Enums.VehicleModel.Hakuchou,
            AltV.Net.Enums.VehicleModel.Asea,
            AltV.Net.Enums.VehicleModel.Taxi,
            AltV.Net.Enums.VehicleModel.Ambulance,
            AltV.Net.Enums.VehicleModel.FireTruck,
            AltV.Net.Enums.VehicleModel.Patriot2,
            AltV.Net.Enums.VehicleModel.Pcj,
            AltV.Net.Enums.VehicleModel.Caddy,
            AltV.Net.Enums.VehicleModel.Hunter,
            AltV.Net.Enums.VehicleModel.Mower,
            AltV.Net.Enums.VehicleModel.TowTruck,
            AltV.Net.Enums.VehicleModel.Tractor2,
            AltV.Net.Enums.VehicleModel.Forklift,
            AltV.Net.Enums.VehicleModel.Huntley,
            AltV.Net.Enums.VehicleModel.Pounder,
            AltV.Net.Enums.VehicleModel.Asterope,
            AltV.Net.Enums.VehicleModel.Hauler,
            AltV.Net.Enums.VehicleModel.Maverick,
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

        public static void CreateNewHitMarker()
        {
            foreach (MarkerModel marker in MarkerModelList.ToList())
            {
                RageAPI.RemoveMarker(marker);
            }
            foreach (ColShapeModel col in ColShapeModelList.ToList())
            {
                RageAPI.RemoveColShape(col);
            }
            MarkerModelList.Clear();
            ColShapeModelList.Clear();

            Random random = new Random();
            int RandomPosition = random.Next(0, SevenTowersCheckPoints.Count);
            Vector3 Position = SevenTowersCheckPoints[RandomPosition];
            MarkerModelList.Add(RageAPI.CreateMarker(1, new Vector3(Position.X, Position.Y, Position.Z - 0.5f), new Vector3(6, 6, 6), new int[] { 0, 200, 255, 255 }, null, SEVENTOWERS_DIM));
            ColShapeModel newCol = RageAPI.CreateColShapeSphere(Position, 5, SEVENTOWERS_DIM);
            ColShapeModelList.Add(newCol);
            CurrentColShape = newCol.Entity;
        }

        public static void StartNewRound()
        {
            try
            {
                CreateNewHitMarker();
                SEVENTOWERS_ROUND_IS_RUNNING = true;
                SEVENTOWERS_ROUND_END = DateTime.Now.AddMinutes(SEVENTOWERS_ROUND_MINUTE);
                SEVENTOWERS_ROUND_JOINTIME_TILL_START = DateTime.Now.AddSeconds(SEVENTOWERS_ROUND_JOINTIME);
                foreach (VehicleModel veh in SevenTowersVehicles.ToList())
                {
                    Alt.RemoveVehicle(veh);
                    SevenTowersVehicles.Remove(veh);
                }
                CurrentlyInRound.Clear();
                foreach (SpawnModel Spawns in SevenTowerSpawns.ToList())
                {
                    Spawns.Spawned = false;
                }
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
                SEVENTOWERS_ROUND_IS_RUNNING = false;
                SEVENTOWERS_ROUND_WILL_START = DateTime.Now.AddSeconds(SEVENTOWERS_ROUND_START_AFTER_LOADING);
                foreach (Client player in Globals.Main.SevenTowersPlayers)
                {
                    if (CurrentlyInRound.Count == 1)
                    {
                        foreach (Client winner in CurrentlyInRound.ToList())
                        {
                            if (winner.SevenTowers.Spawned == true)
                            {
                                CURRENT_WINNER = winner.Username;
                                TakePlayerFromRound(player);
                            }
                        }
                    }
                    Alt.Server.TriggerClientEvent(player, "SevenTowers:ShowWinner", CURRENT_WINNER, 5000);
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
                List<SpawnModel> CurrentAvailableSpawns = new List<SpawnModel>();
                foreach (SpawnModel Spawns in SevenTowerSpawns.ToList())
                {
                    if (!Spawns.Spawned) // Wenn Spawn nicht Belegt
                    {
                        CurrentAvailableSpawns.Add(Spawns);
                    }
                }
                if (!player.SevenTowers.Spawned && !CurrentlyInRound.Contains(player))
                {
                    Random random = new Random();
                    int randomSpawnNumb = random.Next(0, CurrentAvailableSpawns.Count);
                    SpawnModel Spawns = CurrentAvailableSpawns[randomSpawnNumb];
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Blista, new Vector3(Spawns.Position.X, Spawns.Position.Y, Spawns.Position.Z + 0.5f), Spawns.Rotation);
                    player.SpawnPlayer(Spawns.Position);
                    player.Dimension = SEVENTOWERS_DIM;
                    vehicle.Dimension = SEVENTOWERS_DIM;
                    player.SevenTowers.SpawnedTime = DateTime.Now.AddSeconds(2);
                    vehicle.EngineOn = true;
                    player.Freeze = true;
                    vehicle.Frozen = false;
                    player.SevenTowers.Spawned = true;
                    player.WarpIntoVehicle(vehicle, -1);
                    SevenTowersVehicles.Add(vehicle);
                    vehicle.Kms = 0;
                    vehicle.Gas = 100;
                    Spawns.Spawned = true;
                    CurrentlyInRound.Add(player);
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
                foreach (Client players in Globals.Main.SevenTowersPlayers)
                {
                    players.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(0, 200, 255) + player.Username + RageAPI.GetHexColorcode(255, 255, 255) + " hat die SevenTowers Lobby betreten!");
                }
                if (Globals.Main.SevenTowersPlayers.Count == 1)
                {
                    foreach (Client otherplayer in CurrentlyInRound)
                    {
                        TakePlayerFromRound(otherplayer);
                    }
                    EndRound();
                }
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
        public static void OnColShapeHit(IColShape shape, Client player)
        {
            if (shape == CurrentColShape)
            {
                player.SevenTowers.SpawnedTime = DateTime.Now.AddSeconds(2);
                if (player.IsInVehicle)
                {
                    SevenTowersVehicles.Remove((VehicleModel)player.Vehicle);
                    player.Vehicle.Remove();
                    AltV.Net.Enums.VehicleModel vehicleHash = VEHICLE_HASHES[GetRandomNumber(0, VEHICLE_HASHES.Count)];
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(vehicleHash, new Vector3(player.Position.X, player.Position.Y, player.Position.Z + 0.5f), player.Rotation);
                    vehicle.Dimension = SEVENTOWERS_DIM;
                    player.WarpIntoVehicle(vehicle, -1);
                    SevenTowersVehicles.Add(vehicle);
                    vehicle.EngineOn = true;
                    vehicle.Frozen = false;
                }
                CreateNewHitMarker();
            }
        }

        public static void TakePlayerFromRound(Client playerClass)
        {
            if (playerClass.SevenTowers.Spawned)
            {
                playerClass.SetPosition = new Vector3(playerClass.Position.X, playerClass.Position.Y, playerClass.Position.Z + 110);
                playerClass.DespawnPlayer();
                playerClass.SevenTowers.Spawned = false;
                CurrentlyInRound.Remove(playerClass);
                if (playerClass.IsInVehicle) { playerClass.Vehicle.Remove(); }
                if (CurrentlyInRound.Count == 1)
                {
                    EndRound();
                }
            }
        }
        public static void PlayerLeaveVehicle(VehicleModel vehicle, Client playerClass)
        {
            try
            {
                if (playerClass.SevenTowers.Spawned && playerClass.SevenTowers.SpawnedTime <= DateTime.Now)
                {
                    TakePlayerFromRound(playerClass);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerLeaveVehicle", ex); }
        }

        public static void OnUpdate()
        {
            try
            {
                if (Globals.Main.SevenTowersPlayers.Count > 0)
                {
                    if (SEVENTOWERS_ROUND_END <= DateTime.Now && SEVENTOWERS_ROUND_IS_RUNNING)
                    {
                        foreach (Client playerClass in Globals.Main.SevenTowersPlayers)
                        {
                            TakePlayerFromRound(playerClass);
                        }
                        EndRound();
                    }
                    else if (!SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
                    {
                        StartNewRound();
                    }
                    else if (SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
                    {
                        foreach (Client playerClass in Globals.Main.SevenTowersPlayers)
                        {
                            if (playerClass.Position.Z <= 0 && playerClass.SevenTowers.Spawned)
                            {
                                TakePlayerFromRound(playerClass);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnUpdateSevenTowers", ex); }
        }
    }
}
