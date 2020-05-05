using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.SevenTowers.globals;

namespace VenoXV.SevenTowers.Lobby
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
        public static List<IPlayer> SevenTowersPlayers = new List<IPlayer>();
        public static List<IVehicle> SevenTowersVehicles = new List<IVehicle>();
        public static DateTime SEVENTOWERS_ROUND_END;
        public static DateTime SEVENTOWERS_ROUND_WILL_START;
        public static DateTime SEVENTOWERS_ROUND_JOINTIME_TILL_START;
        public static Dictionary<Position, bool> SevenTowerSpawns;
        public static int VEHICLE_LIST_MAX = 0;


        public static List<Position> SPAWNPOINT_COORDS = new List<Position> // CONSTANT 7TOWERS SPAWNS
        {
            new Position(75.20439f, -5802.7383f, 85.524536f),
            new Position(90.65934f,-5784.0264f,85.524536f),
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
                SevenTowerSpawns = new Dictionary<Position, bool>();
                foreach (Position pos in SPAWNPOINT_COORDS) { SevenTowerSpawns.Add(pos, false); }
                foreach (AltV.Net.Enums.VehicleModel vehicles in VEHICLE_HASHES) { VEHICLE_LIST_MAX++; }
            }
            catch { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void InitializePlayerData(PlayerModel player)
        {
            try
            {
                player.vnxSetElementData(EntityData.PLAYER_SPAWNED, false);
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

        public static void PutPlayerSpectate(PlayerModel player)
        {
            player.SendChatMessage("Du bist zuschauer!");
        }

        public static void StartNewRound()
        {
            try
            {
                foreach (PlayerModel player in SevenTowersPlayers)
                {
                    InitializePlayerData(player);
                    SpawnPlayerInRound(player);
                    SEVENTOWERS_ROUND_JOINTIME_TILL_START = DateTime.Now.AddSeconds(SEVENTOWERS_ROUND_JOINTIME);
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
                foreach (PlayerModel player in SevenTowersPlayers)
                {
                    //if (player.IsInVehicle) { Reallife.dxLibary.VnX.SetIVehicleElementFrozen(player.Vehicle, player, true); return; }
                    //Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("EndRound", ex);
            }
        }

        public static void SpawnPlayerInRound(PlayerModel player)
        {
            try
            {
                foreach (var Spawns in SevenTowerSpawns.ToList())
                {
                    if (!Spawns.Value && !player.vnxGetElementData<bool>(EntityData.PLAYER_SPAWNED)) // Wenn Spawn nicht Belegt
                    {
                        IVehicle vehicle = Alt.CreateVehicle(VEHICLE_HASHES[GetRandomNumber(0, VEHICLE_LIST_MAX)], Spawns.Key, new Rotation(0, 0, 0));
                        player.position = Spawns.Key;

                        player.vnxSetElementData(EntityData.PLAYER_SPAWNED, true);
                        player.WarpIntoVehicle<bool>(vehicle, -1);
                        SevenTowersVehicles.Add(vehicle);
                        SevenTowerSpawns.Remove(Spawns.Key);
                        SevenTowerSpawns.Add(Spawns.Key, true);
                        vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                        vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("SpawnPlayerInRound", ex);
            }
        }
        public static void PutPlayerInRound(PlayerModel player)
        {
            try
            {
                InitializePlayerData(player);
                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "~ ~ ~ ~ 7 TOWERS ~ ~ ~ ~ ");
                SpawnPlayerInRound(player);
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions("PutPlayerInRound", ex);
            }
        }


        public static void JoinedSevenTowers(PlayerModel player)
        {
            try
            {
                SevenTowersPlayers.Add(player);
                if (SevenTowersPlayers.Count <= 1) { StartNewRound(); return; }
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
    }
}
