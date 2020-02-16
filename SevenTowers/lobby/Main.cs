using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.SevenTowers.globals;

namespace VenoXV.SevenTowers.Lobby
{
    public class Main : IScript
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        // SETTINGS 
        public static int   SEVENTOWERS_ROUND_MINUTE = 3;                       // Zeit in Sekunden.
        public static int   SEVENTOWERS_ROUND_START_AFTER_LOADING = 5;          // Zeit in Sekunden.
        public static int   SEVENTOWERS_ROUND_JOINTIME = 5;                     // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas
        public static bool SEVENTOWERS_ROUND_IS_RUNNING = false;
        public static List<IPlayer> SevenTowersPlayers;
        public static List<IPlayer> SevenTowersVehicles;
        public static DateTime SEVENTOWERS_ROUND_END;
        public static DateTime SEVENTOWERS_ROUND_WILL_START;
        public static Dictionary<Position, bool> SevenTowerSpawns;
        public static int VEHICLE_LIST_MAX = 0;


        public static List<Position> SPAWNPOINT_COORDS = new List<Position> // CONSTANT 7TOWERS SPAWNS
        {
            new Position(75.20439f, -5802.7383f, 85.524536f),
            new Position(90.65934f,-5784.0264f,85.524536f),
        };


        public static List<AltV.Net.Enums.VehicleModel> VEHICLE_HASHES = new List<AltV.Net.Enums.VehicleModel> // CONSTANT 7TOWERS SPAWNS
        {
            AltV.Net.Enums.VehicleModel.Adder,
            AltV.Net.Enums.VehicleModel.Sultan,
            AltV.Net.Enums.VehicleModel.Bmx,
            AltV.Net.Enums.VehicleModel.Bus,
            AltV.Net.Enums.VehicleModel.Raiden,
            AltV.Net.Enums.VehicleModel.Turismo2,
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
                SevenTowerSpawns = new Dictionary<Position, bool>();
                foreach (Position pos in SPAWNPOINT_COORDS) { SevenTowerSpawns.Add(pos, false); }
                foreach (AltV.Net.Enums.VehicleModel vehicles in VEHICLE_HASHES) { VEHICLE_LIST_MAX++; }
            }
            catch { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void InitializePlayerData(IPlayer player)
        {
            try
            {
                player.SetData(EntityData.PLAYER_SPAWNED, false);
            }
            catch (Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("InitializePlayerData", ex);
            }

        }

        public static bool CanPlayerJoin()
        {
            if(SEVENTOWERS_ROUND_IS_RUNNING || SEVENTOWERS_ROUND_END > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public static void PutPlayerSpectate(IPlayer player)
        {

        }
        
        public static void StartNewRound()
        {
            try
            {
                foreach (IPlayer player in SevenTowersPlayers)
                {
                    InitializePlayerData(player);
                    SpawnPlayerInRound(player);
                    SEVENTOWERS_ROUND_IS_RUNNING = true;
                }
            }
            catch (Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("StartNewRound", ex);
            }
        }
        public static void EndRound()
        {
            try
            {
                foreach (IPlayer player in SevenTowersPlayers)
                {
                    if (player.IsInVehicle) { Reallife.dxLibary.VnX.SetIVehicleElementFrozen(player.Vehicle, player, true); return; }
                    Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    SEVENTOWERS_ROUND_IS_RUNNING = false;
                }
            }
            catch (Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("EndRound", ex);
            }
        }

        public static void SpawnPlayerInRound(IPlayer player)
        {
            try
            {
                foreach (var Spawns in SevenTowerSpawns)
                {
                    if (!Spawns.Value && !player.vnxGetElementData<bool>(EntityData.PLAYER_SPAWNED)) // Wenn Spawn nicht Belegt
                    {
                        IVehicle vehicle = Alt.CreateVehicle(VEHICLE_HASHES[GetRandomNumber(0, VEHICLE_LIST_MAX)], Spawns.Key, new Rotation(0, 0, 0));
                        player.Position = Spawns.Key;
                        player.SetData(EntityData.PLAYER_SPAWNED, true);
                        player.WarpIntoVehicle<bool>(vehicle, -1);
                    }
                }
            }
            catch (Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("SpawnPlayerInRound", ex);
            }
        }
        public static void PutPlayerInRound(IPlayer player)
        {
            try {
                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "~ ~ ~ ~ 7 TOWERS ~ ~ ~ ~ ");
                SpawnPlayerInRound(player);
            }
            catch (Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("PutPlayerInRound", ex);
            }
        }


        public static void JoinedSevenTowers(IPlayer player)
        {
            try
            {
                InitializePlayerData(player);
                SevenTowersPlayers.Add(player);
                if (CanPlayerJoin()) { PutPlayerInRound(player); }
                else { PutPlayerSpectate(player); }
            }
            catch(Exception ex)
            {
                Reallife.Core.Debug.CatchExceptions("JoinedSevenTowers", ex);
            }
        }

        public static void OnUpdate()
        {
            if (SEVENTOWERS_ROUND_END <= DateTime.Now)
            {
                EndRound();
                SEVENTOWERS_ROUND_WILL_START = DateTime.Now.AddMinutes(SEVENTOWERS_ROUND_START_AFTER_LOADING);
            }

            if (!SEVENTOWERS_ROUND_IS_RUNNING && SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
            {
                if (SevenTowersPlayers.Count > 0)
                {
                    StartNewRound();
                    SEVENTOWERS_ROUND_END = DateTime.Now.AddMinutes(SEVENTOWERS_ROUND_MINUTE);
                }
            }
        }
    }
}
