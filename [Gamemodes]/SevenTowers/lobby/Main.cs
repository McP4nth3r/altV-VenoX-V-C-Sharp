using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.SevenTowers.maps.main;
using VenoXV._Gamemodes_.SevenTowers.model;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.SevenTowers
{
    public class Main
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS 
        public static int SeventowersRoundMinute = 15;                        // Zeit in Sekunden.    
        public static int SeventowersSpecialVehicleChance = 100;             // Zeit in Sekunden.    
        public static int SeventowersRoundStartAfterLoading = 5;            // Zeit in Sekunden.
        public static int SeventowersVehicleCooldown = 3;                     // Zeit in Sekunden. < -- Cooldown für neues Auto
        public static int SeventowersRoundJointime = 5;                       // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).
        public static int SeventowersDim = _Globals_.Main.SeventowersDimension;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas
        public static bool SeventowersRoundIsRunning;
        public static List<VnXPlayer> CurrentlyInRound = new List<VnXPlayer>();
        public static List<VehicleModel> SevenTowersVehicles = new List<VehicleModel>();
        public static List<ColShapeModel> ColShapeModelList = new List<ColShapeModel>();
        public static IColShape CurrentColShape;
        public static List<MarkerModel> MarkerModelList = new List<MarkerModel>();
        public static DateTime SeventowersRoundEnd = DateTime.Now;
        public static DateTime SeventowersRoundWillStart = DateTime.Now;
        public static DateTime SeventowersRoundJointimeTillStart = DateTime.Now;
        public static List<SpawnModel> SevenTowerSpawns = Spawns.SpawnCoords;
        public static string CurrentWinner = "-";

        public static readonly List<Vector3> SevenTowersCheckPoints = new List<Vector3>
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
            new Vector3(164.14944f, -5700.158f, 85.12012f)
        };

        public static readonly List<AltV.Net.Enums.VehicleModel> SpecialvehicleHashes = new List<AltV.Net.Enums.VehicleModel> // CONSTANT 7TOWERS VEHICLES
        {
            AltV.Net.Enums.VehicleModel.Hunter,
            AltV.Net.Enums.VehicleModel.Rhino,
            AltV.Net.Enums.VehicleModel.Hydra
        };

        public static readonly List<AltV.Net.Enums.VehicleModel> VehicleHashes = new List<AltV.Net.Enums.VehicleModel> // CONSTANT 7TOWERS VEHICLES
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
            AltV.Net.Enums.VehicleModel.Mower,
            AltV.Net.Enums.VehicleModel.TowTruck,
            AltV.Net.Enums.VehicleModel.Tractor2,
            AltV.Net.Enums.VehicleModel.Forklift,
            AltV.Net.Enums.VehicleModel.Huntley,
            AltV.Net.Enums.VehicleModel.Pounder,
            AltV.Net.Enums.VehicleModel.Asterope,
            AltV.Net.Enums.VehicleModel.Hauler,
            AltV.Net.Enums.VehicleModel.Maverick,
            AltV.Net.Enums.VehicleModel.Shamal,
            AltV.Net.Enums.VehicleModel.Zentorno,
            AltV.Net.Enums.VehicleModel.Riot,
            AltV.Net.Enums.VehicleModel.Insurgent,
            AltV.Net.Enums.VehicleModel.Cheetah,
            AltV.Net.Enums.VehicleModel.Schafter5
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
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void InitializePlayerData(VnXPlayer player)
        {
            try
            {
                player.SevenTowers.Spawned = false;
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }

        }

        public static bool CanPlayerJoin()
        {
            try
            {
                if (SeventowersRoundIsRunning && SeventowersRoundJointimeTillStart >= DateTime.Now)
                    return true;
                return false;
            }
            catch { return false; }
        }

        public static void PutPlayerSpectate(VnXPlayer player)
        {
            try
            {
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Du bist nun zuschauer!");
                player.SevenTowers.IsSpectator = true;
                VenoX.TriggerClientEvent(player, "SevenTowers:PutPlayerIntoSpectatorMode");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void CreateNewHitMarker()
        {
            try
            {
                foreach (MarkerModel marker in MarkerModelList.ToList()) RageApi.RemoveMarker(marker);
                foreach (ColShapeModel col in ColShapeModelList.ToList()) RageApi.RemoveColShape(col);

                MarkerModelList.Clear();
                ColShapeModelList.Clear();

                Random random = new Random();
                int randomPosition = random.Next(0, SevenTowersCheckPoints.Count);
                Vector3 position = SevenTowersCheckPoints[randomPosition];
                MarkerModelList.Add(RageApi.CreateMarker(1, new Vector3(position.X, position.Y, position.Z - 0.5f), new Vector3(6, 6, 6), new[] { 0, 200, 255, 255 }, null, SeventowersDim));
                ColShapeModel newCol = RageApi.CreateColShapeSphere(position, 5, SeventowersDim);
                ColShapeModelList.Add(newCol);
                CurrentColShape = newCol;
                foreach (VnXPlayer players in _Globals_.Main.SevenTowersPlayers.ToList()) Sync.ForceClientSyncUpdate(players);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void StartNewRound()
        {
            try
            {
                CreateNewHitMarker();
                SeventowersRoundIsRunning = true;
                SeventowersRoundEnd = DateTime.Now.AddMinutes(SeventowersRoundMinute);
                SeventowersRoundJointimeTillStart = DateTime.Now.AddSeconds(SeventowersRoundJointime);
                foreach (VehicleModel veh in SevenTowersVehicles.ToList())
                {
                    //Alt.RemoveVehicle(veh);
                    RageApi.DeleteVehicleThreadSafe(veh);
                    SevenTowersVehicles.Remove(veh);
                }
                CurrentlyInRound.Clear();
                foreach (SpawnModel spawns in SevenTowerSpawns.ToList()) spawns.Spawned = false;
                foreach (VnXPlayer player in _Globals_.Main.SevenTowersPlayers.ToList())
                {
                    InitializePlayerData(player);
                    SpawnPlayerInRound(player);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }
        public static async void EndRound()
        {
            try
            {
                SeventowersRoundIsRunning = false;
                SeventowersRoundWillStart = DateTime.Now.AddSeconds(SeventowersRoundStartAfterLoading);
                foreach (VnXPlayer player in _Globals_.Main.SevenTowersPlayers.ToList())
                {
                    if (CurrentlyInRound.Count == 1)
                    {
                        foreach (VnXPlayer winner in CurrentlyInRound.ToList())
                        {
                            if (winner.SevenTowers.Spawned)
                            {
                                if (_Globals_.Main.SevenTowersPlayers.ToList().Count > 1) winner.SevenTowers.Wins += 1;
                                CurrentWinner = winner.Username;
                                TakePlayerFromRound(player);
                            }
                        }
                    }
                    string translatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "gewinnt die Runde.");
                    VenoX.TriggerClientEvent(player, "SevenTowers:ShowWinner", CurrentWinner, translatedText, 5000);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void SpawnPlayerInRound(VnXPlayer player)
        {
            try
            {
                List<SpawnModel> currentAvailableSpawns = new List<SpawnModel>();
                foreach (SpawnModel spawns in SevenTowerSpawns.ToList())
                    if (!spawns.Spawned) currentAvailableSpawns.Add(spawns); // if Spawn isn't used.

                if (!player.SevenTowers.Spawned && !CurrentlyInRound.Contains(player))
                {
                    if (player.SevenTowers.IsSpectator) { VenoX.TriggerClientEvent(player, "SevenTowers:RemovePlayerFromSpectatorMode"); player.SevenTowers.IsSpectator = false; }
                    Random random = new Random();
                    int randomSpawnNumb = random.Next(0, currentAvailableSpawns.Count);
                    SpawnModel spawns = currentAvailableSpawns[randomSpawnNumb];
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Blista, new Vector3(spawns.Position.X, spawns.Position.Y, spawns.Position.Z + 0.5f), spawns.Rotation);
                    player.SpawnPlayer(spawns.Position);
                    player.Dimension = SeventowersDim;
                    vehicle.Dimension = SeventowersDim;
                    player.SevenTowers.SpawnedTime = DateTime.Now.AddSeconds(2);
                    vehicle.EngineOn = true;
                    player.Freeze = true;
                    vehicle.Frozen = false;
                    player.SevenTowers.Spawned = true;
                    player.WarpIntoVehicle(vehicle, -1);
                    SevenTowersVehicles.Add(vehicle);
                    vehicle.Kms = 0;
                    vehicle.Gas = 100;
                    spawns.Spawned = true;
                    CurrentlyInRound.Add(player);
                    player.SetPlayerVisible(true);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }
        public static async void PutPlayerInRound(VnXPlayer player)
        {
            try
            {

                foreach (VnXPlayer players in _Globals_.Main.SevenTowersPlayers.ToList())
                {
                    string joinedLobbytext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)players.Language, " hat die SevenTowers Lobby betreten!");
                    players.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + player.Username + RageApi.GetHexColorcode(255, 255, 255) + " " + joinedLobbytext);
                }
                InitializePlayerData(player);
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "~ ~ ~ ~ 7 TOWERS ~ ~ ~ ~ ");
                SpawnPlayerInRound(player);
                player.SetPlayerVisible(true);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void JoinedSevenTowers(VnXPlayer player)
        {
            try
            {
                // will spawn player near map.
                player.Freeze = true;
                player.SetPosition = new Vector3(210.13187f, -5742.5933f, 120.78833f);
                if (_Globals_.Main.SevenTowersPlayers.Count <= 1) { StartNewRound(); return; }
                if (CanPlayerJoin()) PutPlayerInRound(player);
                else PutPlayerSpectate(player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void OnColShapeHit(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == CurrentColShape)
                {
                    if (player.IsInVehicle && player.SevenTowers.LastVehicleGot < DateTime.Now)
                    {
                        player.SevenTowers.SpawnedTime = DateTime.Now.AddSeconds(SeventowersVehicleCooldown);
                        VehicleModel vehicleClass = (VehicleModel)player.Vehicle;
                        if (vehicleClass != null && vehicleClass.Exists) vehicleClass.Remove();
                        SevenTowersVehicles.Remove(vehicleClass);
                        //RageAPI.DeleteVehicleThreadSafe(vehicleClass);
                        AltV.Net.Enums.VehicleModel vehicleHash = AltV.Net.Enums.VehicleModel.Fbi;
                        int specialVehicleChance = GetRandomNumber(0, SeventowersSpecialVehicleChance);
                        //Debug.OutputDebugString("SpecialVehicleChance : " + SpecialVehicleChance);
                        if (specialVehicleChance == SeventowersSpecialVehicleChance)
                            vehicleHash = SpecialvehicleHashes[GetRandomNumber(0, SpecialvehicleHashes.Count)];
                        else
                            vehicleHash = VehicleHashes[GetRandomNumber(0, VehicleHashes.Count)];

                        VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(vehicleHash, new Vector3(player.Position.X, player.Position.Y, player.Position.Z + 0.5f), player.Rotation);
                        vehicle.Dimension = SeventowersDim;
                        player.WarpIntoVehicle(vehicle, -1);
                        SevenTowersVehicles.Add(vehicle);
                        vehicle.EngineOn = true;
                        vehicle.Frozen = false;
                        CreateNewHitMarker();
                        player.SevenTowers.LastVehicleGot = DateTime.Now.AddSeconds(SeventowersVehicleCooldown);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void TakePlayerFromRound(VnXPlayer playerClass)
        {
            try
            {
                if (CurrentlyInRound.Contains(playerClass)) CurrentlyInRound.Remove(playerClass);
                if (playerClass.SevenTowers.Spawned)
                {
                    if (playerClass.IsInVehicle) RageApi.DeleteVehicleThreadSafe((VehicleModel)playerClass.Vehicle);
                    playerClass.SetPosition = new Vector3(playerClass.Position.X, playerClass.Position.Y, playerClass.Position.Z + 110);
                    playerClass.DespawnPlayer();
                    playerClass.SetPlayerVisible(false);
                    playerClass.SevenTowers.Spawned = false;
                    playerClass.Freeze = true;
                    if (CurrentlyInRound.Count <= 1) { EndRound(); return; }
                    PutPlayerSpectate(playerClass);
                }
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }

        public static void PlayerLeaveVehicle(VehicleModel vehicle, VnXPlayer playerClass)
        {
            try
            {
                if (playerClass.SevenTowers.Spawned && playerClass.SevenTowers.SpawnedTime <= DateTime.Now)
                    TakePlayerFromRound(playerClass);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnUpdate()
        {
            try
            {
                if (_Globals_.Main.SevenTowersPlayers.Count <= 0) return;

                if (SeventowersRoundEnd <= DateTime.Now && SeventowersRoundIsRunning)
                {
                    foreach (VnXPlayer playerClass in _Globals_.Main.SevenTowersPlayers.ToList()) TakePlayerFromRound(playerClass);
                    EndRound();
                }
                else switch (SeventowersRoundIsRunning)
                {
                    case false when SeventowersRoundWillStart <= DateTime.Now:
                        StartNewRound();
                        break;
                    case true when SeventowersRoundWillStart <= DateTime.Now:
                    {
                        foreach (var playerClass in _Globals_.Main.SevenTowersPlayers.ToList().Where(playerClass => playerClass.Position.Z <= 0 && playerClass.SevenTowers.Spawned))
                            TakePlayerFromRound(playerClass);
                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
