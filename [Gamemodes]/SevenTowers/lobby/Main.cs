using AltV.Net;
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
        public static DateTime SEVENTOWERS_ROUND_END = DateTime.Now;
        public static DateTime SEVENTOWERS_ROUND_WILL_START = DateTime.Now;
        public static DateTime SEVENTOWERS_ROUND_JOINTIME_TILL_START = DateTime.Now;
        public static List<SpawnModel> SevenTowerSpawns = maps.main.Spawns.SpawnCoords;
        public static string CURRENT_WINNER = "";

        public static readonly List<Vector3> SevenTowersCheckPoints = new List<Vector3>()
        {
            new Vector3(),

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
                    if (player.SevenTowers.Spawned == true && CurrentlyInRound.Count == 1)
                    {
                        CURRENT_WINNER = player.Username;
                        TakePlayerFromRound(player);
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
                    AltV.Net.Enums.VehicleModel vehicleHash = VEHICLE_HASHES[GetRandomNumber(0, VEHICLE_HASHES.Count)];
                    SpawnModel Spawns = CurrentAvailableSpawns[randomSpawnNumb];
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(vehicleHash, new Vector3(Spawns.Position.X, Spawns.Position.Y, Spawns.Position.Z + 0.5f), Spawns.Rotation);
                    player.SpawnPlayer(Spawns.Position);
                    player.Dimension = SEVENTOWERS_DIM;
                    vehicle.Dimension = SEVENTOWERS_DIM;
                    player.SevenTowers.SpawnedTime = DateTime.Now.AddSeconds(2);
                    player.Freeze = true;
                    vehicle.Frozen = true;
                    player.SevenTowers.Spawned = true;
                    player.WarpIntoVehicle(vehicle, -1);
                    SevenTowersVehicles.Add(vehicle);
                    vehicle.Kms = 0;
                    vehicle.Gas = 100;
                    Spawns.Spawned = true;
                    CurrentlyInRound.Add(player);
                }
                Core.Debug.OutputDebugString("SevenTowersPlayers : " + Globals.Main.SevenTowersPlayers.Count);
                Core.Debug.OutputDebugString("CurrentlyPlaying : " + CurrentlyInRound.Count);
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

        public static void TakePlayerFromRound(Client playerClass)
        {
            playerClass.SetPosition = new Vector3(playerClass.Position.X, playerClass.Position.Y, playerClass.Position.Z + 110);
            playerClass.DespawnPlayer();
            playerClass.SevenTowers.Spawned = false;
            if (playerClass.IsInVehicle)
            {
                playerClass.Vehicle.Remove();
                SevenTowersVehicles.Remove((VehicleModel)playerClass.Vehicle);
            }
            CurrentlyInRound.Remove(playerClass);
            if (CurrentlyInRound.Count == 1)
            {
                EndRound();
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
                    if (!SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
                    {
                        StartNewRound();
                    }
                    if (SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
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
