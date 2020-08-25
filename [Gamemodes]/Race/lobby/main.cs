using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<VnXPlayer> RacePlayersFinished = new List<VnXPlayer>();
        public static DateTime TIME_TO_JOIN = DateTime.Now;
        public static DateTime RACE_NEXT_ROUND_WILL_START = DateTime.Now;
        public static DateTime RACE_STARTED = DateTime.Now;
        public static DateTime RACE_WILL_END = DateTime.Now;
        public static MapModel LastMap = new MapModel();
        public static MapModel CurrentMap;
        public static string RACE_FIRST_WINNER = String.Empty;
        public static string RACE_SECOND_WINNER = String.Empty;
        public static string RACE_THIRD_WINNER = String.Empty;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void DeleteEverything()
        {
            try
            {
                if (CurrentMap != null) { foreach (SpawnModel spawn in CurrentMap.PlayerSpawnPoints.ToList()) { if (spawn.Spawned) spawn.Spawned = false; } }
                foreach (VehicleModel vehClass in RaceVehicles.ToList()) { if (vehClass != null) { vehClass.Remove(); } }
                foreach (VnXPlayer racePlayers in VenoXV.Globals.Main.RacePlayers.ToList())
                {
                    if (racePlayers.Race.LastMarker != null) { RageAPI.RemoveMarker(racePlayers.Race.LastMarker); racePlayers.Race.LastMarker = null; }
                    if (racePlayers.Race.LastColShapeModel != null) { RageAPI.RemoveColShape(racePlayers.Race.LastColShapeModel); racePlayers.Race.LastColShapeModel = null; }
                    racePlayers.Race.IsRacing = false;
                }
                RaceVehicles.Clear();
                RacePlayersFinished.Clear();
                RACE_FIRST_WINNER = String.Empty;
                RACE_SECOND_WINNER = String.Empty;
                RACE_THIRD_WINNER = String.Empty;
            }
            catch (Exception ex) { Debug.CatchExceptions("DeleteEverything", ex); }
        }

        private static void InitializePlayerDatas()
        {
            try
            {
                foreach (VnXPlayer player in VenoXV.Globals.Main.RacePlayers.ToList())
                {
                    if (!player.Race.IsRacing)
                    {
                        Vector3 Spawnpoint = new Vector3();
                        Vector3 Rotation = new Vector3();
                        foreach (SpawnModel spawn in CurrentMap.PlayerSpawnPoints.ToList())
                        {
                            if (!spawn.Spawned && !player.Race.IsRacing)
                            {
                                Spawnpoint = spawn.Position;
                                Rotation = spawn.Rotation;
                                spawn.Spawned = true;
                                player.Race.IsRacing = true;
                            }
                        }
                        player.SpawnPlayer(Spawnpoint);
                        player.Dimension = 0;
                        double leftTime = (DateTime.Now - DateTime.Now.AddMinutes(RACE_ROUND_MINUTES)).TotalSeconds * -1;
                        Alt.Server.TriggerClientEvent(player, "Race:StartTimer", leftTime, 3);
                        VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(CurrentMap.PlayerVehicleHash, Spawnpoint, Rotation);
                        Alt.Server.TriggerClientEvent(player, "Vehicle:DisableEngineToggle", false); // Disable Auto-TurnOn for Vehicle.
                        vehicle.Frozen = false;
                        vehicle.EngineOn = true;
                        player.Race.CurrentMarker = 0;
                        vehicle.Race.Owner = player;
                        RaceVehicles.Add(vehicle);
                        player.WarpIntoVehicle(vehicle, -1);
                        SyncPlayerPlaceInRound();
                        CreateRaceMarker(player);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("InitializePlayerDatas", ex); }
        }
        public static void OnColshapeHit(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == player.Race.LastColShapeModel && player.IsInVehicle)
                {
                    CreateRaceMarker(player);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnColshapeHit", ex); }
        }

        public static void SendRaceMessage(string text)
        {
            foreach (VnXPlayer players in VenoXV.Globals.Main.RacePlayers.ToList())
            {
                players.SendTranslatedChatMessage(text);
            }
        }
        public static void SyncPlayerPlaceInRound()
        {

            int counter = 0;
            foreach (VnXPlayer player in VenoXV.Globals.Main.RacePlayers.ToList())
            {
                player.Emit("Race:ClearPlayerList", player.Username);
                foreach (VnXPlayer players in VenoXV.Globals.Main.RacePlayers.OrderBy(p => p.Race.CurrentMarker).Reverse())
                {
                    counter++;
                    players.Race.RoundPlace = counter;
                    player.Emit("Race:FillPlayerList", players.Username);
                }
            }
        }

        public static void OnClientRaceFinish(VnXPlayer player)
        {
            try
            {
                if (RACE_FIRST_WINNER == String.Empty)
                {
                    RACE_FIRST_WINNER = player.Username;
                }
                else if (RACE_SECOND_WINNER == String.Empty)
                {
                    RACE_SECOND_WINNER = player.Username;
                }
                else if (RACE_THIRD_WINNER == String.Empty)
                {
                    RACE_THIRD_WINNER = player.Username;
                }
                player.Vehicle.EngineOn = false;
                player.Freeze = true;
                player.Race.IsRacing = false;
                SendRaceMessage(RageAPI.GetHexColorcode(0, 200, 255) + player.Username + RageAPI.GetHexColorcode(255, 255, 255) + " hat das Rennen beendet!");
                RacePlayersFinished.Add(player);
                if (RacePlayersFinished.Count == VenoXV.Globals.Main.RacePlayers.Count)
                {
                    SendRaceMessage(RageAPI.GetHexColorcode(0, 200, 255) + " ~~~~~~~~~~~~~~~~~~~~ ");
                    SendRaceMessage(RageAPI.GetHexColorcode(255, 255, 255) + " [Race] : Gewinner - 1 :  " + RACE_FIRST_WINNER);
                    SendRaceMessage(RageAPI.GetHexColorcode(255, 255, 255) + " [Race] : Gewinner - 2 :  " + RACE_SECOND_WINNER);
                    SendRaceMessage(RageAPI.GetHexColorcode(255, 255, 255) + " [Race] : Gewinner - 3 :  " + RACE_THIRD_WINNER);
                    SendRaceMessage(RageAPI.GetHexColorcode(0, 200, 255) + " ~~~~~~~~~~~~~~~~~~~~ ");
                    StopRound();
                }
            }
            catch { }
        }

        public static void CreateRaceMarker(VnXPlayer player)
        {
            try
            {
                // Sync Stuff
                SyncPlayerPlaceInRound();
                // Delete everything
                if (player.Race.LastMarker != null) { RageAPI.RemoveMarker(player.Race.LastMarker); player.Race.LastMarker = null; }
                if (player.Race.LastColShapeModel != null) { RageAPI.RemoveColShape(player.Race.LastColShapeModel); player.Race.LastColShapeModel = null; }
                if (player.Race.CurrentMarker == CurrentMap.RaceCheckpoints.Count) { OnClientRaceFinish(player); return; }
                // Create New stuff
                Vector3 newPos = new Vector3(CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].X, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].Y, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].Z + 0.5f);
                player.Race.LastMarker = RageAPI.CreateMarker(4, newPos, new Vector3(5, 5, 5), new int[] { 0, 200, 255, 255 }, player);
                player.Race.LastColShapeModel = RageAPI.CreateColShapeSphere(newPos, 4);
                // Draw Waypoint & give player stuff.
                player.DrawWaypoint(newPos.X, newPos.Y);
                player.Race.CurrentMarker += 1;
                player.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateRaceMarker", ex); }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public static void StartNewRound()
        {
            try
            {
                DeleteEverything();
                GetNewMap();
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

        private static void PutPlayerInRound(VnXPlayer player)
        {
            try
            {
                if (!CanPlayerJoin() || VenoXV.Globals.Main.RacePlayers.Count >= 2)
                {
                    player.SetPosition = new Vector3(CurrentMap.PlayerSpawnPoints[0].Position.X, CurrentMap.PlayerSpawnPoints[0].Position.Y, CurrentMap.PlayerSpawnPoints[0].Position.Z - 30f);
                    Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + " Es läuft eine runde bereits... bitte gedulde dich!");
                    return;
                }
                StartNewRound();
            }
            catch (Exception ex) { Debug.CatchExceptions("PutPlayerInRound", ex); }
        }
        public static void OnSelectedRaceGM(VnXPlayer player)
        {
            try
            {
                PutPlayerInRound(player);
                Globals.Functions.SendRaceRoundMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat die Race runde betreten.");
            }
            catch (Exception ex) { Debug.CatchExceptions("OnSelectedRaceGM", ex); }
        }
        public static void StopRound()
        {
            try
            {
                RACE_ROUND_IS_RUNNING = false;
                RACE_WILL_END = DateTime.Now;
            }
            catch { }
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
