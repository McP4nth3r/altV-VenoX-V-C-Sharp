﻿using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Tactics.Globals;
using VenoXV._Gamemodes_.Tactics.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.Lobby
{
    public class Main : IScript
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS

        public static int TACTIC_ROUND_MINUTE = 3; // Zeit in Minuten.
        public static int TACTIC_ROUND_START_AFTER_LOADING = 5; // Zeit in Sekunden.
        public static int TACTIC_ROUND_JOINTIME = 5; // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).
        public static int TACTIC_MIN_PLAYER_TEAM = 1; // WV Spieler pro Team minimum notwendig sind.
        public static int TACTIC_PLAYER_DIMENSION = 10;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas.

        //public IPlayer[] TACTICS_PLAYERS_IN_LOBBY { get; set; }
        public static bool TACTICMANAGER__ROUND_ISRUNNING;
        public static DateTime TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
        public static DateTime TACTICMANAGER_ROUND_TIMETOJOIN = DateTime.Now;
        public static DateTime TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now;
        public static bool TACTICMANAGER_ROUND_JOIN_ALLOWED;
        public static int MEMBER_COUNT_COPS = 0;
        public static int MEMBER_COUNT_BFAC = 0;
        public static int MEMBER_COUNT_MAX_COPS = 0;
        public static int MEMBER_COUNT_MAX_BFAC = 0;
        public static int RandomRound = 0;
        public static List<IVehicle> TacticVehicleList = new List<IVehicle>();
        public static RoundModel LastMap = new RoundModel();
        public static RoundModel CurrentMap;

        ////////////////////////////////////////////////////////////////////////////////////////////////////


        private static void GetNewMap()
        {
            try
            {
                Random random = new Random();
                int RandomMap = random.Next(0, maps.Main.TacticMaps.Count); // Count Spawnpoints
                CurrentMap = maps.Main.TacticMaps[RandomMap];
                if (LastMap == CurrentMap) { GetNewMap(); return; }
                LastMap = CurrentMap;
            }
            catch { CurrentMap = maps.Main.TacticMaps[1]; }
        }
        private static void InitializePlayerSavedData(Client player)
        {   // ToDo : Load by Database.
            try
            {
                player.Tactics.CurrentStreak = 0;
            }
            catch { }
        }
        private static void InitializePlayerData(Client player)
        {
            try
            {
                player.Tactics.Joined = true;
                player.Tactics.CurrentDamage = 0;
                player.Tactics.CurrentKills = 0;
                player.Tactics.IsDead = false;
                player.Tactics.Spawned = false;
                player.Emit("LoadTacticUI", CurrentMap.Team_A_Name, CurrentMap.Team_B_Name, CurrentMap.Team_A_Color[0], CurrentMap.Team_A_Color[1], CurrentMap.Team_A_Color[2], CurrentMap.Team_B_Color[0], CurrentMap.Team_B_Color[1], CurrentMap.Team_B_Color[2]);
                RageAPI.SetPlayerVisible(player, true);
            }
            catch { }
        }
        public static bool IsTacticRoundRunning()
        {
            // Sendet dem Spieler die Antwort ob eine Tactic Lobby am laufen ist.
            if (TACTICMANAGER__ROUND_ISRUNNING) { return true; }
            else { return false; }
        }
        public static void CreateRandomRound()
        {
            try
            {
                Random random = new Random();
                RandomRound = random.Next(0, 20);
            }
            catch { }
        }
        public static void GivePlayerTacticWeapons(Client player)
        {
            try
            {
                if (CurrentMap.Custom_Weapon_Map)
                {
                    foreach (AltV.Net.Enums.WeaponModel weapon in CurrentMap.Custom_Weapons)
                    {
                        RageAPI.GivePlayerWeapon(player, weapon, 400);
                    }
                    player.SendTranslatedChatMessage("[Tactics] : Only " + CurrentMap.Custom_Weapon_Mode_Name + " Modus!");
                    return;
                }
                switch (RandomRound)
                {
                    case 0:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.HeavyRevolver, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Revolver Modus!");
                        break;
                    case 1:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only SMG Modus!");
                        break;
                    case 2:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Shotgun Modus!");
                        break;
                    case 3:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SniperRifle, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Sniper Modus!");
                        break;
                    case 4:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.RPG, 800);
                        player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.RPG, 2);
                        player.SendTranslatedChatMessage("[Tactics] : Only RPG Modus!");
                        break;
                    case 5:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Minigun, 1000);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Minigun, 5000);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Switchblade, 1);
                        player.SendTranslatedChatMessage("[Tactics] : Only Minigun Modus!");
                        break;
                    default:
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.HeavyRevolver, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CombatPDW, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AssaultRifle, 800);
                        RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Musket, 800);
                        break;

                }
            }
            catch { }
        }
        public static void SpawnPlayerOnPoint(Client player, string Fac)
        {
            try
            {
                Random random = new Random();
                int randomspawnpoint = random.Next(0, CurrentMap.Team_A_Spawnpoints.Count); // Count Spawnpoints
                if (Fac == EntityData.BFAC_NAME)
                {
                    Vector3 Spawnpunkt = CurrentMap.Team_B_Spawnpoints[randomspawnpoint];
                    player.SpawnPlayer(Spawnpunkt);
                    player.SetPlayerSkin(Alt.Hash(CurrentMap.Team_B_Skin));
                    player.Dimension = TACTIC_PLAYER_DIMENSION;
                    player.Tactics.Spawned = true;
                    player.Tactics.Team = EntityData.BFAC_NAME;
                    GivePlayerTacticWeapons(player);
                    player.Health = 200;
                    player.Armor = 100;
                }
                else if (Fac == EntityData.COPS_NAME)
                {
                    Vector3 Spawnpunkt = CurrentMap.Team_A_Spawnpoints[randomspawnpoint];
                    player.SpawnPlayer(Spawnpunkt); player.SetPlayerSkin(Alt.Hash(CurrentMap.Team_A_Skin));
                    player.Dimension = TACTIC_PLAYER_DIMENSION;
                    player.Tactics.Spawned = true;
                    player.Tactics.Team = EntityData.COPS_NAME;
                    GivePlayerTacticWeapons(player);
                    player.Health = 200;
                    player.Armor = 100;
                }
                //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                Reallife.dxLibary.VnX.SetElementFrozen(player, false);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartnewTacticRound", ex); }
        }
        private static void SpawnMapVehicles()
        {
            foreach (IVehicle veh in TacticVehicleList) { if (veh != null) { veh.Remove(); } }
            TacticVehicleList = new List<IVehicle>();
            foreach (MapVehicleModel vehClass in CurrentMap.Custom_Vehicles)
            {
                VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(vehClass.Vehicle_Hash, vehClass.Vehicle_Position, vehClass.Vehicle_Rotation);
                vehicle.Dimension = TACTIC_PLAYER_DIMENSION;
                TacticVehicleList.Add(vehicle);
            }
        }
        public static void PutPlayerInTeam(Client player)
        {
            try
            {
                // Wir Checken ob bereits eine Runde bereits läuft, falls nein dann setzen wir den Status auf True.
                if (!IsTacticRoundRunning()) { TACTICMANAGER__ROUND_ISRUNNING = true; }

                if (player.Tactics.Team == EntityData.COPS_NAME)
                {
                    Alt.Emit("GlobalSystems:PlayerTeam", player, 0);
                    if (MEMBER_COUNT_BFAC <= MEMBER_COUNT_COPS) // Wenn Böse Fraktionisten in der Unterzahl sind, dann Spieler in die BFAC tun.
                    {
                        MEMBER_COUNT_BFAC += 1;
                        MEMBER_COUNT_MAX_BFAC += 1;
                        SpawnPlayerOnPoint(player, EntityData.BFAC_NAME);
                        InitializePlayerData(player);
                    }
                    else
                    {
                        MEMBER_COUNT_COPS += 1;
                        MEMBER_COUNT_MAX_COPS += 1;
                        SpawnPlayerOnPoint(player, EntityData.COPS_NAME);
                        InitializePlayerData(player);
                    }
                }
                else
                {
                    Alt.Emit("GlobalSystems:PlayerTeam", player, 1);
                    if (MEMBER_COUNT_COPS <= MEMBER_COUNT_BFAC) // Wenn Böse Fraktionisten in der Unterzahl sind, dann Spieler in die BFAC tun.
                    {
                        MEMBER_COUNT_COPS += 1;
                        MEMBER_COUNT_MAX_COPS += 1;
                        SpawnPlayerOnPoint(player, EntityData.COPS_NAME);
                        InitializePlayerData(player);
                    }
                    else
                    {
                        MEMBER_COUNT_BFAC += 1;
                        MEMBER_COUNT_MAX_BFAC += 1;
                        SpawnPlayerOnPoint(player, EntityData.BFAC_NAME);
                        InitializePlayerData(player);
                    }
                }
            }
            catch { }
        }
        public static void StartNewTacticRound()
        {
            try
            {
                GetNewMap();
                TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now.AddMinutes(TACTIC_ROUND_MINUTE);
                TACTICMANAGER_ROUND_TIMETOJOIN = DateTime.Now.AddSeconds(TACTIC_ROUND_JOINTIME);
                MEMBER_COUNT_BFAC = 0;
                MEMBER_COUNT_COPS = 0;
                MEMBER_COUNT_MAX_BFAC = 0;
                MEMBER_COUNT_MAX_COPS = 0;
                CreateRandomRound();
                SpawnMapVehicles();
                // To Do : wenn runde gestartet ist = nicht machen !
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 200, 200) + "[VenoX - Tactics] : Eine neue Runde startet.");
                    players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 105, 145) + "[Map] : " + RageAPI.GetHexColorcode(200, 200, 200) + CurrentMap.Map_Name);
                    //InitializePlayerData(players);
                    PutPlayerInTeam(players);
                    SyncTime();
                    SyncPlayerStats();
                    SyncStats();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartnewTacticRound", ex); }
        }
        public static void OnPlayerDisconnect(Client player, string type, string reason)
        {
            try
            {
                player.Tactics.Deaths -= 1;
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    players.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " ist Disconnected!");
                }
                if (player.Tactics.Team == EntityData.BFAC_NAME)
                {
                    Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                    if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                    {
                        Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
                        Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                        Lobby.Main.SyncEndTacticRound("Das L.S.P.D gewinnt die Runde.");
                        return;
                    }
                }
                else if (player.Tactics.Team == EntityData.COPS_NAME)
                {
                    Lobby.Main.MEMBER_COUNT_COPS -= 1;
                    if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                    {
                        Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
                        Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                        Lobby.Main.SyncEndTacticRound("Die Grove Street gewinnt die Runde.");
                        return;
                    }
                }
                Lobby.Main.SyncStats();
                Lobby.Main.SyncPlayerStats();
            }
            catch { }
        }
        public static void OnSelectedTacticsGM(Client player)
        {
            try
            {
                //AntiCheat_Allround.SetTimeOutHealth(player, 3000);
                //AntiCheat_Allround.StartTimerTeleport(player);
                InitializePlayerSavedData(player);
                player.Tactics.Team = "NULL";
                if (TACTICMANAGER__ROUND_ISRUNNING && TACTICMANAGER_ROUND_TIMETOJOIN < DateTime.Now)
                {
                    if (MEMBER_COUNT_MAX_BFAC == 0 || MEMBER_COUNT_MAX_COPS == 0)
                    {
                        StartNewTacticRound();
                    }
                    else
                    {
                        // To Do : Cam event erstellen.
                        player.DespawnPlayer();
                        _Gamemodes_.Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                        player.RemoveAllPlayerWeapons();
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Es läuft bereits eine Runde... Bitte gedulde dich ein wenig...");
                    }
                }
                else
                {
                    StartNewTacticRound();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedTacticsGM", ex); }
        }
        public static void SyncTime()
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    double leftTime = (DateTime.Now - TACTICMANAGER_ROUND_CURRENTTIME).TotalSeconds * -1;
                    players.Emit("Tactics:LoadTimer", (int)leftTime);
                }
            }
            catch { }
        }
        public static void SyncStats()
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    players.Emit("Tactics:UpdateMemberInfo", MEMBER_COUNT_MAX_COPS, MEMBER_COUNT_COPS, MEMBER_COUNT_MAX_BFAC, MEMBER_COUNT_BFAC);
                }
            }
            catch { }
        }
        public static void SyncPlayerStats()
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    float DamageDone = players.Tactics.CurrentDamage;
                    int KillsDone = players.Tactics.CurrentKills;
                    players.Emit("Tactics:UpdatePlayerStats", DamageDone, KillsDone);
                }
            }
            catch { }
        }
        public static void SyncEndTacticRound(string text)
        {
            try
            {
                foreach (Client players in VenoXV.Globals.Main.TacticsPlayers)
                {
                    players.RemoveAllPlayerWeapons();
                    players.Emit("Tactics:OnTacticEndRound", text);
                }
            }
            catch { }
        }
        public static void OnUpdate()
        {
            try
            {
                if (IsTacticRoundRunning() && TACTICMANAGER_ROUND_CURRENTTIME <= DateTime.Now)
                {
                    if (TACTICMANAGER_ROUND_START_AFTER_LOADING <= DateTime.Now)
                    {
                        TACTICMANAGER__ROUND_ISRUNNING = false;
                        // RageAPI.SendTranslatedChatMessageToAll("RUNDE BEENDET.");
                        StartNewTacticRound();
                    }
                }
            }
            catch { }
        }
    }
}
