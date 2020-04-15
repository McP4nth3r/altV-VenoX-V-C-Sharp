using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Race.model;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Race.Lobby
{
    public class Main : IScript
    {
        // Settings
        public const int RACE_JOIN_TIME = 5; // Time in MS to join a started round.
        public const int RACE_ROUND_MINUTES = 3; // Time in Minutes - Round Minute Times
        public const int RACE_ROUND_WILL_START_IN = 5; // Time in Seconds - Round will start after it ended


        // Const
        public static bool RACE_ROUND_IS_RUNNING = false;
        public static int RACE_PLAYERS_IN_ROUND = 0;
        public static int RACE_PLAYERS_RACING = 0;
        public static List<VehicleModel> RaceVehicles = new List<VehicleModel>();
        public static DateTime TIME_TO_JOIN = DateTime.Now;
        public static DateTime RACE_NEXT_ROUND_WILL_START = DateTime.Now;
        public static DateTime RACE_STARTED = DateTime.Now;
        public static DateTime RACE_WILL_END = DateTime.Now;
        public static MapModel LastMap = new MapModel();
        public static MapModel CurrentMap;

        private static void DeleteAllRaceVehicles()
        {
            foreach (VehicleModel vehClass in RaceVehicles)
            {
                if (vehClass.vehicle.Exists) { vehClass.vehicle.Remove(); }
            }
            RaceVehicles = new List<VehicleModel>();
        }
        public static void StartNewRound()
        {
            try
            {
                Core.Debug.OutputDebugString("called");
                GetNewMap();
                DeleteAllRaceVehicles();
                RACE_PLAYERS_IN_ROUND = 0;
                RACE_PLAYERS_RACING = 0;
                int counter = 0;
                foreach (IPlayer player in VenoXV.Globals.Main.RacePlayers)
                {
                    if (counter > CurrentMap.PlayerSpawnPoints.Count) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 125, 0) + " Die Runde ist leider voll... bitte gedulde dich"); }
                    Vector3 Spawnpoint = CurrentMap.PlayerSpawnPoints[counter];
                    Vector3 Rotation = CurrentMap.PlayerRotation;
                    player.SpawnPlayer(Spawnpoint);
                    IVehicle vehicle = Alt.CreateVehicle(CurrentMap.PlayerVehicleHash, Spawnpoint, Rotation);
                    VehicleModel vehClass = new VehicleModel()
                    {
                        Vehicle_Hash = (AltV.Net.Enums.VehicleModel)CurrentMap.PlayerVehicleHash,
                        Vehicle_Owner = player.GetVnXName<string>(),
                        Vehicle_Position = Spawnpoint,
                        Vehicle_Rotation = CurrentMap.PlayerRotation,
                        vehicle = vehicle
                    };
                    RaceVehicles.Add(vehClass);
                    player.WarpIntoVehicle<bool>(vehicle, -1);
                    counter++;
                    RACE_PLAYERS_IN_ROUND++;
                    RACE_PLAYERS_RACING++;
                }
                RACE_ROUND_IS_RUNNING = true;
                RACE_STARTED = DateTime.Now;
                RACE_WILL_END = DateTime.Now.AddMinutes(RACE_ROUND_MINUTES);
                TIME_TO_JOIN = DateTime.Now.AddSeconds(RACE_JOIN_TIME);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartNewRaceRound", ex); }
        }
        private static int test = 0;
        private static void GetNewMap()
        {
            try
            {
                Debug.OutputDebugString("" + test);
                test++;
                Random random = new Random();
                int RandomMap = random.Next(0, maps.Main.RaceMaps.Count); // Count Spawnpoints
                CurrentMap = maps.Main.RaceMaps[RandomMap];
                if (LastMap == CurrentMap) { GetNewMap(); return; }
                LastMap = CurrentMap;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("GetNewMap", ex); }
        }
        private static void PutPlayerInRound(IPlayer player)
        {
            try
            {
                if (RACE_ROUND_IS_RUNNING && TIME_TO_JOIN <= DateTime.Now.AddSeconds(RACE_JOIN_TIME)) { Reallife.dxLibary.VnX.SetElementFrozen(player, true); player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 125, 0) + " Es läuft eine runde bereits... bitte gedulde dich!"); return; }
                StartNewRound();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PutPlayerInRound", ex); }
        }
        public static void OnSelectedRaceGM(IPlayer player)
        {
            try
            {
                //if (RACE_PLAYERS_JOINED == 1) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "[Race] : Momentan ist keiner in der Race-Lobby :(... Gedulde dich bis jemand joint..."); return; }
                PutPlayerInRound(player);
                Race.Globals.Functions.SendRaceRoundMessage(Core.RageAPI.GetHexColorcode(0, 200, 0) + player.GetVnXName<string>() + " hat die Race runde betreten.");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedRaceGM", ex); }
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
            catch (Exception ex) { Core.Debug.CatchExceptions("OnUpdateRace", ex); }
        }
    }
}
