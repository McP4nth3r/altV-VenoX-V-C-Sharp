﻿using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Race.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Race.Lobby
{
    public class Main : IScript
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Settings
        public const int RACE_JOIN_TIME = 5; // Time in MS to join a started round.
        public const int RACE_ROUND_MINUTES = 5; // Time in Minutes - Round Minute Times
        public const int RACE_ROUND_WILL_START_IN = 5; // Time in Seconds - Round will start after it ended

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////+

        // Const
        public static bool RACE_ROUND_IS_RUNNING = false;
        public const string RACE_COL = "RACE_COL";
        public static List<VehicleModel> RaceVehicles = new List<VehicleModel>();
        public static DateTime TIME_TO_JOIN = DateTime.Now;
        public static DateTime RACE_NEXT_ROUND_WILL_START = DateTime.Now;
        public static DateTime RACE_STARTED = DateTime.Now;
        public static DateTime RACE_WILL_END = DateTime.Now;
        public static MapModel LastMap = new MapModel();
        public static MapModel CurrentMap;
        public static List<Client> PlayerModelList;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void DeleteEverything()
        {
            try
            {
                foreach (VehicleModel vehClass in RaceVehicles) { if (vehClass != null) { vehClass.Remove(); } }
                foreach (Client racePlayers in VenoXV.Globals.Main.RacePlayers)
                {
                    if (racePlayers.Race.LastMarker != null) { RageAPI.RemoveMarker(racePlayers.Race.LastMarker); racePlayers.Race.LastMarker = null; }
                    if (racePlayers.Race.LastColShapeModel != null) { RageAPI.RemoveColShape(racePlayers.Race.LastColShapeModel); racePlayers.Race.LastColShapeModel = null; }
                }
                RaceVehicles.Clear();
            }
            catch (Exception ex) { Debug.CatchExceptions("DeleteEverything", ex); }
        }

        private static void InitializePlayerDatas()
        {
            try
            {
                foreach (Client player in VenoXV.Globals.Main.RacePlayers)
                {
                    Vector3 Spawnpoint = CurrentMap.PlayerSpawnPoints[0];
                    Vector3 Rotation = CurrentMap.PlayerRotation;
                    player.SpawnPlayer(Spawnpoint);
                    player.Dimension = 0;
                    double leftTime = (DateTime.Now - DateTime.Now.AddMinutes(RACE_ROUND_MINUTES)).TotalSeconds * -1;
                    Alt.Server.TriggerClientEvent(player, "Race:StartTimer", leftTime);
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(CurrentMap.PlayerVehicleHash, Spawnpoint, Rotation);
                    Alt.Server.TriggerClientEvent(player, "Vehicle:DisableEngineToggle", false); // Disable Auto-TurnOn for Vehicle.
                    vehicle.Frozen = false;
                    vehicle.EngineOn = true;
                    player.Race.CurrentMarker = 0;
                    vehicle.Race.Owner = player;
                    RaceVehicles.Add(vehicle);
                    player.WarpIntoVehicle(vehicle, -1);
                    CreateRaceMarker(player);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("InitializePlayerDatas", ex); }
        }
        public static void OnColshapeHit(IColShape shape, Client player)
        {
            try
            {
                if (shape == player.Race.LastColShapeModel.Entity)
                {
                    CreateRaceMarker(player);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnColshapeHit", ex); }
        }


        public static void CreateRaceMarker(Client player)
        {
            try
            {
                if (player.Race.LastMarker != null) { RageAPI.RemoveMarker(player.Race.LastMarker); player.Race.LastMarker = null; }
                if (player.Race.LastColShapeModel != null) { RageAPI.RemoveColShape(player.Race.LastColShapeModel); player.Race.LastColShapeModel = null; }
                if (player.Race.CurrentMarker == CurrentMap.RaceCheckpoints.Count) { player.SendTranslatedChatMessage("Rennen beendet!"); return; }
                player.Race.LastMarker = RageAPI.CreateMarker(0, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker], new Vector3(3, 3, 3), new int[] { 0, 200, 255, 255 });
                player.Race.LastColShapeModel = RageAPI.CreateColShapeSphere(CurrentMap.RaceCheckpoints[player.Race.CurrentMarker], 3);
                player.DrawWaypoint(CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].X, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].Y);
                player.Race.LastColShapeModel.Entity.vnxSetElementData("IsRaceMarker", true);
                player.Race.CurrentMarker += 1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateRaceMarker", ex); }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public static void StartNewRound()
        {
            try
            {
                GetNewMap();
                DeleteEverything();
                InitializePlayerDatas();
                RACE_ROUND_IS_RUNNING = true;
                RACE_STARTED = DateTime.Now;
                RACE_WILL_END = DateTime.Now.AddMinutes(RACE_ROUND_MINUTES);
                TIME_TO_JOIN = DateTime.Now.AddSeconds(RACE_JOIN_TIME);
            }
            catch (Exception ex) { Debug.CatchExceptions("StartNewRaceRound", ex); }
        }
        private static void GetNewMap()
        {
            try
            {
                Random random = new Random();
                int RandomMap = random.Next(0, maps.Main.RaceMaps.Count); // Count Spawnpoints
                CurrentMap = maps.Main.RaceMaps[RandomMap];
                if (LastMap == CurrentMap) { GetNewMap(); return; }
                LastMap = CurrentMap;
            }
            catch (Exception ex) { Debug.CatchExceptions("GetNewMap", ex); }
        }

        public static bool CanPlayerJoin()
        {
            try
            {
                if (RACE_ROUND_IS_RUNNING && TIME_TO_JOIN <= DateTime.Now)
                {
                    return true;
                }
                else if (RACE_ROUND_IS_RUNNING || RACE_WILL_END > DateTime.Now)
                {
                    return false;
                }
                return true;
            }
            catch { return false; }
        }

        private static void PutPlayerInRound(Client player)
        {
            try
            {
                if (!CanPlayerJoin() || VenoXV.Globals.Main.RacePlayers.Count >= 2)
                {
                    player.SetPosition = new Vector3(CurrentMap.PlayerSpawnPoints[^1].X, CurrentMap.PlayerSpawnPoints[^1].Y, CurrentMap.PlayerSpawnPoints[^1].Z - 30f);
                    Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + " Es läuft eine runde bereits... bitte gedulde dich!");
                    return;
                }
                StartNewRound();
            }
            catch (Exception ex) { Debug.CatchExceptions("PutPlayerInRound", ex); }
        }
        public static void OnSelectedRaceGM(Client player)
        {
            try
            {
                PutPlayerInRound(player);
                Globals.Functions.SendRaceRoundMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat die Race runde betreten.");
            }
            catch (Exception ex) { Debug.CatchExceptions("OnSelectedRaceGM", ex); }
        }
        public static void OnUpdate()
        {
            try
            {
                if (VenoXV.Globals.Main.RacePlayers.Count == 0) return;
                if (RACE_ROUND_IS_RUNNING && RACE_WILL_END <= DateTime.Now)
                {
                    RACE_NEXT_ROUND_WILL_START = DateTime.Now.AddSeconds(RACE_ROUND_WILL_START_IN);
                    RACE_ROUND_IS_RUNNING = false;
                }
                if (!RACE_ROUND_IS_RUNNING && RACE_NEXT_ROUND_WILL_START <= DateTime.Now)
                {
                    StartNewRound();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("OnUpdateRace", ex); }
        }
    }
}
