using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Race.Globals;
using VenoXV._Gamemodes_.Race.model;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Race.Lobby
{
    public class Main : IScript
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Settings
        public const int RaceJoinTime = 5; // Time in MS to join a started round.
        public const int RaceRoundMinutes = 5; // Time in Minutes - Round Minute Times
        public const int RaceRoundWillStartIn = 5; // Time in Seconds - Round will start after it ended

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////+

        // Const
        public static bool RaceRoundIsRunning;
        public const string RaceCol = "RACE_COL";
        public static List<VehicleModel> RaceVehicles = new List<VehicleModel>();
        public static List<VnXPlayer> RacePlayersFinished = new List<VnXPlayer>();
        public static DateTime TimeToJoin = DateTime.Now;
        public static DateTime RaceNextRoundWillStart = DateTime.Now;
        public static DateTime RaceStarted = DateTime.Now;
        public static DateTime RaceWillEnd = DateTime.Now;
        public static MapModel LastMap = new MapModel();
        public static MapModel CurrentMap;
        public static string RaceFirstWinner = String.Empty;
        public static string RaceSecondWinner = String.Empty;
        public static string RaceThirdWinner = String.Empty;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void DeleteEverything()
        {
            try
            {
                if (CurrentMap != null) { foreach (SpawnModel spawn in CurrentMap.PlayerSpawnPoints.ToList()) { if (spawn.Spawned) spawn.Spawned = false; } }
                foreach (VehicleModel vehClass in RaceVehicles.ToList()) { if (vehClass != null) { RageApi.DeleteVehicleThreadSafe(vehClass); } }
                foreach (VnXPlayer racePlayers in _Globals_.Main.RacePlayers.ToList())
                {
                    if (racePlayers.Race.LastMarker != null) { RageApi.RemoveMarker(racePlayers.Race.LastMarker); racePlayers.Race.LastMarker = null; }
                    if (racePlayers.Race.LastColShapeModel != null) { RageApi.RemoveColShape(racePlayers.Race.LastColShapeModel); racePlayers.Race.LastColShapeModel = null; }
                    racePlayers.Race.IsRacing = false;
                }
                RaceVehicles.Clear();
                RacePlayersFinished.Clear();
                RaceFirstWinner = String.Empty;
                RaceSecondWinner = String.Empty;
                RaceThirdWinner = String.Empty;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        private static void InitializePlayerDatas()
        {
            try
            {
                foreach (VnXPlayer player in _Globals_.Main.RacePlayers.ToList())
                {
                    if (!player.Race.IsRacing)
                    {
                        Vector3 spawnpoint = new Vector3();
                        Vector3 rotation = new Vector3();
                        foreach (SpawnModel spawn in CurrentMap.PlayerSpawnPoints.ToList())
                        {
                            if (!spawn.Spawned && !player.Race.IsRacing)
                            {
                                spawnpoint = spawn.Position;
                                rotation = spawn.Rotation;
                                spawn.Spawned = true;
                                player.Race.IsRacing = true;
                            }
                        }
                        player.SpawnPlayer(spawnpoint);
                        player.Dimension = _Globals_.Main.RaceDimension;
                        double leftTime = (DateTime.Now - DateTime.Now.AddMinutes(RaceRoundMinutes)).TotalSeconds * -1;
                        VenoX.TriggerClientEvent(player, "Race:StartTimer", leftTime, 3);
                        VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(CurrentMap.PlayerVehicleHash, spawnpoint, rotation);
                        VenoX.TriggerClientEvent(player, "Vehicle:DisableEngineToggle", false); // Disable Auto-TurnOn for Vehicle.
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void SendRaceMessage(string text)
        {
            try
            {
                foreach (VnXPlayer players in _Globals_.Main.RacePlayers.ToList())
                {
                    players.SendTranslatedChatMessage(text);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void SyncPlayerPlaceInRound()
        {
            try
            {
                int counter = 0;
                foreach (VnXPlayer player in _Globals_.Main.RacePlayers.ToList())
                {
                    VenoX.TriggerClientEvent(player, "Race:ClearPlayerList", player.Username);
                    foreach (VnXPlayer players in _Globals_.Main.RacePlayers.OrderBy(p => p.Race.CurrentMarker).Reverse())
                    {
                        counter++;
                        players.Race.RoundPlace = counter;
                        VenoX.TriggerClientEvent(player, "Race:FillPlayerList", players.Username);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static async void OnClientRaceFinish(VnXPlayer player)
        {
            try
            {
                if (RaceFirstWinner == String.Empty) RaceFirstWinner = player.Username;
                else if (RaceSecondWinner == String.Empty) RaceSecondWinner = player.Username;
                else if (RaceThirdWinner == String.Empty) RaceThirdWinner = player.Username;

                player.Vehicle.EngineOn = false;
                player.Freeze = true;
                player.Race.IsRacing = false;

                string translatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "hat das Rennen beendet!");
                foreach (VnXPlayer players in _Globals_.Main.RacePlayers.ToList())
                {
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + player.Username + RageApi.GetHexColorcode(255, 255, 255) + " " + translatedText);
                }
                RacePlayersFinished.Add(player);
                if (RacePlayersFinished.Count == _Globals_.Main.RacePlayers.Count)
                {
                    string translatedText1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, " [Race] : Gewinner - 1 :  ");
                    string translatedText2 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, " [Race] : Gewinner - 2 :  ");
                    string translatedText3 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, " [Race] : Gewinner - 3 :  ");
                    foreach (VnXPlayer players in _Globals_.Main.RacePlayers.ToList())
                    {
                        players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " ~~~~~~~~~~~~~~~~~~~~ ");
                        players.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + translatedText1 + " " + RaceFirstWinner);
                        players.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + translatedText2 + " " + RaceSecondWinner);
                        players.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + translatedText3 + " " + RaceThirdWinner);
                        players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " ~~~~~~~~~~~~~~~~~~~~ ");
                    }
                    StopRound();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void CreateRaceMarker(VnXPlayer player)
        {
            try
            {
                // Sync Stuff
                SyncPlayerPlaceInRound();
                // Delete everything
                if (player.Race.LastMarker != null) { RageApi.RemoveMarker(player.Race.LastMarker); player.Race.LastMarker = null; }
                if (player.Race.LastColShapeModel != null) { RageApi.RemoveColShape(player.Race.LastColShapeModel); player.Race.LastColShapeModel = null; }
                if (player.Race.CurrentMarker == CurrentMap.RaceCheckpoints.Count) { OnClientRaceFinish(player); return; }
                // Create New stuff
                Vector3 newPos = new Vector3(CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].X, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].Y, CurrentMap.RaceCheckpoints[player.Race.CurrentMarker].Z + 0.5f);
                player.Race.LastMarker = RageApi.CreateMarker(4, newPos, new Vector3(5, 5, 5), new[] { 0, 200, 255, 255 }, player, player.Dimension);
                player.Race.LastColShapeModel = RageApi.CreateColShapeSphere(newPos, 4, player.Dimension);
                // Draw Waypoint & give player stuff.
                player.DrawWaypoint(newPos.X, newPos.Y);
                player.Race.CurrentMarker += 1;
                VenoX.TriggerClientEvent(player, "start_screen_fx", "ExplosionJosh3", 0, false);
                Sync.ForceClientSyncUpdate(player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public static void StartNewRound()
        {
            try
            {
                DeleteEverything();
                GetNewMap();
                InitializePlayerDatas();
                RaceRoundIsRunning = true;
                RaceStarted = DateTime.Now;
                RaceWillEnd = DateTime.Now.AddMinutes(RaceRoundMinutes);
                TimeToJoin = DateTime.Now.AddSeconds(RaceJoinTime);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private static void GetNewMap()
        {
            try
            {
                Random random = new Random();
                int randomMap = random.Next(0, maps.Main.RaceMaps.Count); // Count Spawnpoints
                CurrentMap = maps.Main.RaceMaps[randomMap];
                if (LastMap == CurrentMap)
                {
                    GetNewMap();
                    return;
                }
                LastMap = CurrentMap;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static bool CanPlayerJoin()
        {
            try
            {
                if (RaceRoundIsRunning && TimeToJoin <= DateTime.Now)
                {
                    return true;
                }

                if (RaceRoundIsRunning || RaceWillEnd > DateTime.Now)
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
                if (!CanPlayerJoin() || _Globals_.Main.RacePlayers.Count >= 2)
                {
                    player.SetPosition = new Vector3(CurrentMap.PlayerSpawnPoints[0].Position.X, CurrentMap.PlayerSpawnPoints[0].Position.Y, CurrentMap.PlayerSpawnPoints[0].Position.Z - 30f);
                    VnX.SetElementFrozen(player, true);
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 125, 0) + " Es läuft eine runde bereits... bitte gedulde dich!");
                    return;
                }
                StartNewRound();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void OnSelectedRaceGM(VnXPlayer player)
        {
            try
            {
                PutPlayerInRound(player);
                Functions.SendRaceRoundMessage(RageApi.GetHexColorcode(0, 200, 0) + player.Username + " hat die Race runde betreten.");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void StopRound()
        {
            try
            {
                RaceRoundIsRunning = false;
                RaceWillEnd = DateTime.Now;
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.RacePlayers.Count == 0) return;
                if (RaceRoundIsRunning && RaceWillEnd <= DateTime.Now)
                {
                    RaceNextRoundWillStart = DateTime.Now.AddSeconds(RaceRoundWillStartIn);
                    RaceRoundIsRunning = false;
                }
                if (!RaceRoundIsRunning && RaceNextRoundWillStart <= DateTime.Now)
                {
                    StartNewRound();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
