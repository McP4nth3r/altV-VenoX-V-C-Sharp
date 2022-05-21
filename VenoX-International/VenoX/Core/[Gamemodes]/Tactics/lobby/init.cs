using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Tactics.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using EntityData = VenoX.Core._Gamemodes_.Tactics.globals.EntityData;
using VehicleModel = VenoX.Core._RootCore_.Models.VehicleModel;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.ServerToClient.VnX;

namespace VenoX.Core._Gamemodes_.Tactics.lobby
{
    public class Round
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS

        public int TacticRoundMinute = 3; // Zeit in Minuten.
        public int TacticRoundStartAfterLoading = 5; // Zeit in Sekunden.
        public int TacticRoundJointime = 5; // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).
        public int TacticMinPlayerTeam = 1; // WV Spieler pro Team minimum notwendig sind.
        public int TacticPlayerDimension = Initialize.TacticsDimension;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas.

        //public IPlayer[] TACTICS_PLAYERS_IN_LOBBY { get; set; }
        public bool TacticmanagerRoundIsrunning;
        public DateTime TacticmanagerRoundCurrenttime = DateTime.Now;
        public DateTime TacticmanagerRoundTimetojoin = DateTime.Now;
        public DateTime TacticmanagerRoundStartAfterLoading = DateTime.Now;
        public bool TacticmanagerRoundJoinAllowed;
        public int MemberCountCops;
        public int MemberCountBfac;
        public int MemberCountMaxCops;
        public int MemberCountMaxBfac;
        public int RandomRound;
        public List<IVehicle> TacticVehicleList = new List<IVehicle>();
        public RoundModel LastMap = new RoundModel();
        public RoundModel CurrentMap;

        ////////////////////////////////////////////////////////////////////////////////////////////////////


        private void GetNewMap()
        {
            try
            {
                Random random = new Random();
                int randomMap = random.Next(0, global::VenoX.Core._Gamemodes_.Tactics.maps.Main.TacticMaps.Count); // Count Spawnpoints
                CurrentMap = global::VenoX.Core._Gamemodes_.Tactics.maps.Main.TacticMaps[randomMap];
                if (LastMap == CurrentMap) { GetNewMap(); return; }
                LastMap = CurrentMap;
            }
            catch { CurrentMap = global::VenoX.Core._Gamemodes_.Tactics.maps.Main.TacticMaps[1]; }
        }
        private void InitializePlayerSavedData(VnXPlayer player)
        {   // ToDo : Load by Database.
            try
            {
                player.Tactics.CurrentStreak = 0;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        private async void InitializePlayerData(VnXPlayer player)
        {
            try
            {
                player.Tactics.Joined = true;
                player.Tactics.CurrentDamage = 0;
                player.Tactics.CurrentKills = 0;
                player.Tactics.IsDead = false;
                player.Tactics.Spawned = false;
                string teamAName = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, CurrentMap.TeamAName);
                string teamBName = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, CurrentMap.TeamBName);
                //string TEAM_A_NAME = CurrentMap.Team_A_Name;
                //string TEAM_B_NAME = CurrentMap.Team_B_Name;
                player.EmitLocked("LoadTacticUI", teamAName, teamBName, CurrentMap.TeamAColor[0], CurrentMap.TeamAColor[1], CurrentMap.TeamAColor[2], CurrentMap.TeamBColor[0], CurrentMap.TeamBColor[1], CurrentMap.TeamBColor[2]);
                player.SetPlayerVisible(true);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public bool IsTacticRoundRunning()
        {
            // Sendet dem Spieler die Antwort ob eine Tactic Lobby am laufen ist.
            if (TacticmanagerRoundIsrunning) return true;
            return false;
        }
        public void CreateRandomRound()
        {
            try
            {
                Random random = new Random();
                RandomRound = random.Next(0, 20);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void GivePlayerTacticWeapons(VnXPlayer player)
        {
            try
            {
                if (CurrentMap.CustomWeaponMap)
                {
                    foreach (WeaponModel weapon in CurrentMap.CustomWeapons)
                    {
                        player.GivePlayerWeapon(weapon, 400);
                    }
                    player.SendTranslatedChatMessage("[Tactics] : Only " + CurrentMap.CustomWeaponModeName + " Modus!");
                    return;
                }
                switch (RandomRound)
                {
                    case 0:
                        player.GivePlayerWeapon(WeaponModel.HeavyRevolver, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Revolver Modus!");
                        break;
                    case 1:
                        player.GivePlayerWeapon(WeaponModel.SMG, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only SMG Modus!");
                        break;
                    case 2:
                        player.GivePlayerWeapon(WeaponModel.PumpShotgun, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Shotgun Modus!");
                        break;
                    case 3:
                        player.GivePlayerWeapon(WeaponModel.SniperRifle, 800);
                        player.SendTranslatedChatMessage("[Tactics] : Only Sniper Modus!");
                        break;
                    case 4:
                        player.GivePlayerWeapon(WeaponModel.RPG, 800);
                        player.SetWeaponTintIndex(WeaponModel.RPG, 2);
                        player.SendTranslatedChatMessage("[Tactics] : Only RPG Modus!");
                        break;
                    case 5:
                        player.GivePlayerWeapon(WeaponModel.Minigun, 1000);
                        player.SetWeaponAmmo(WeaponModel.Minigun, 5000);
                        player.GivePlayerWeapon(WeaponModel.Switchblade, 1);
                        player.SendTranslatedChatMessage("[Tactics] : Only Minigun Modus!");
                        break;
                    default:
                        player.GivePlayerWeapon(WeaponModel.HeavyRevolver, 800);
                        player.GivePlayerWeapon(WeaponModel.PumpShotgun, 800);
                        player.GivePlayerWeapon(WeaponModel.SMG, 800);
                        player.GivePlayerWeapon(WeaponModel.CombatPDW, 800);
                        player.GivePlayerWeapon(WeaponModel.CarbineRifle, 800);
                        player.GivePlayerWeapon(WeaponModel.AssaultRifle, 800);
                        player.GivePlayerWeapon(WeaponModel.Musket, 800);
                        break;

                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void SpawnPlayerOnPoint(VnXPlayer player, string fac)
        {
            try
            {
                Random random = new Random();
                int randomspawnpoint = random.Next(0, CurrentMap.TeamASpawnpoints.Count); // Count Spawnpoints
                if (fac == EntityData.BfacName)
                {
                    Vector3 spawnpunkt = CurrentMap.TeamBSpawnpoints[randomspawnpoint];
                    player.SpawnPlayer(spawnpunkt);
                    player.SetPlayerSkin(Alt.Hash(CurrentMap.TeamBSkin));
                    player.Dimension = TacticPlayerDimension;
                    player.Tactics.Spawned = true;
                    player.Tactics.Team = EntityData.BfacName;
                    GivePlayerTacticWeapons(player);
                    player.SetHealth = 200;
                    player.SetArmor = 100;
                    player.DrawWaypoint(CurrentMap.TeamASpawnpoints[0].X, CurrentMap.TeamASpawnpoints[0].Y);
                }
                else if (fac == EntityData.CopsName)
                {
                    Vector3 spawnpunkt = CurrentMap.TeamASpawnpoints[randomspawnpoint];
                    player.SpawnPlayer(spawnpunkt); player.SetPlayerSkin(Alt.Hash(CurrentMap.TeamASkin));
                    player.Dimension = TacticPlayerDimension;
                    player.Tactics.Spawned = true;
                    player.Tactics.Team = EntityData.CopsName;
                    GivePlayerTacticWeapons(player);
                    player.SetHealth = 200;
                    player.SetArmor = 100;
                    player.DrawWaypoint(CurrentMap.TeamBSpawnpoints[0].X, CurrentMap.TeamBSpawnpoints[0].Y);
                }
                //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                VnX.SetElementFrozen(player, false);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        private void SpawnMapVehicles()
        {
            try
            {
                foreach (VehicleModel veh in TacticVehicleList.ToList())
                {
                    if (veh is not null && veh.Exists) RageApi.DeleteVehicleThreadSafe(veh);
                    TacticVehicleList.Clear();
                }
                foreach (MapVehicleModel vehClass in CurrentMap.CustomVehicles.ToList())
                {
                    VehicleModel vehicle = (VehicleModel)Alt.CreateVehicle(vehClass.VehicleHash, vehClass.VehiclePosition, vehClass.VehicleRotation);
                    vehicle.EngineOn = true;
                    vehicle.Frozen = false;
                    vehicle.Godmode = false;
                    vehicle.Dimension = TacticPlayerDimension;
                    TacticVehicleList.Add(vehicle);
                    ConsoleHandling.OutputDebugString("Created Tactics Vehicle with Dimension " + vehicle.Dimension + " | Model : " + vehClass.VehicleHash + " | Position : " + vehClass.VehiclePosition);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public void PutPlayerInTeam()
        {
            try
            {
                // Wir Checken ob bereits eine Runde bereits läuft, falls nein dann setzen wir den Status auf True.
                if (!IsTacticRoundRunning()) TacticmanagerRoundIsrunning = true;
                List<VnXPlayer> tacticsPlayerMixed = Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers);
                tacticsPlayerMixed.ShuffleList();
                string team = EntityData.CopsName;
                foreach (VnXPlayer p in tacticsPlayerMixed.ToList())
                {
                    if (team == EntityData.CopsName)
                    {
                        Alt.Emit("GlobalSystems:PlayerTeam", p, 0);
                        MemberCountBfac += 1;
                        MemberCountMaxBfac += 1;
                        SpawnPlayerOnPoint(p, EntityData.BfacName);
                        InitializePlayerData(p);
                        team = EntityData.BfacName;
                    }
                    else
                    {
                        Alt.Emit("GlobalSystems:PlayerTeam", p, 1);
                        MemberCountCops += 1;
                        MemberCountMaxCops += 1;
                        SpawnPlayerOnPoint(p, EntityData.CopsName);
                        InitializePlayerData(p);
                        team = EntityData.CopsName;
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public async void StartNewTacticRound()
        {
            try
            {
                GetNewMap();
                TacticmanagerRoundCurrenttime = DateTime.Now.AddMinutes(TacticRoundMinute);
                TacticmanagerRoundTimetojoin = DateTime.Now.AddSeconds(TacticRoundJointime);
                MemberCountBfac = 0;
                MemberCountCops = 0;
                MemberCountMaxBfac = 0;
                MemberCountMaxCops = 0;
                CreateRandomRound();
                SpawnMapVehicles();
                PutPlayerInTeam();
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    if (players is null || !players.Exists) continue;
                    string roundStartText = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)players.Language, "Eine neue Runde startet.");
                    string mapNameText = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)players.Language, CurrentMap.MapName);
                    lock (players)
                    {
                        players.SendChatMessage(RageApi.GetHexColorcode(200, 200, 200) + "[VenoX - Tactics] : " + roundStartText);
                        players.SendChatMessage(RageApi.GetHexColorcode(0, 105, 145) + "[Map] : " + RageApi.GetHexColorcode(200, 200, 200) + mapNameText);
                    }
                }
                SyncTime();
                SyncPlayerStats();
                SyncStats();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public async void OnPlayerDisconnect(VnXPlayer player, string type, string reason)
        {
            try
            {
                player.Tactics.Deaths -= 1;
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    string translatedtext = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)players.Language, "ist Disconnected!");
                    players.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " " + translatedtext);
                }
                if (player.Tactics.Team == EntityData.BfacName)
                {
                    MemberCountBfac -= 1;
                    if (MemberCountBfac <= 0)
                    {
                        TacticmanagerRoundStartAfterLoading = DateTime.Now.AddSeconds(TacticRoundStartAfterLoading);
                        TacticmanagerRoundCurrenttime = DateTime.Now;
                        SyncEndTacticRound("Das L.S.P.D gewinnt die Runde.");
                        return;
                    }
                }
                else if (player.Tactics.Team == EntityData.CopsName)
                {
                    MemberCountCops -= 1;
                    if (MemberCountCops <= 0)
                    {
                        TacticmanagerRoundStartAfterLoading = DateTime.Now.AddSeconds(TacticRoundStartAfterLoading);
                        TacticmanagerRoundCurrenttime = DateTime.Now;
                        SyncEndTacticRound("Die Grove Street gewinnt die Runde.");
                        return;
                    }
                }
                SyncStats();
                SyncPlayerStats();
                player.Tactics.CurrentLobby = null;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void OnSelectedTacticsGM(VnXPlayer player)
        {
            try
            {
                ////AntiCheat_Allround.SetTimeOutHealth(player, 3000);
                //AntiCheat_Allround.StartTimerTeleport(player);
                InitializePlayerSavedData(player);
                player.Tactics.Team = "NULL";
                if (TacticmanagerRoundIsrunning && TacticmanagerRoundTimetojoin < DateTime.Now)
                {
                    if (MemberCountMaxBfac == 0 || MemberCountMaxCops == 0)
                    {
                        StartNewTacticRound();
                    }
                    else
                    {
                        // To Do : Cam event erstellen.
                        player.DespawnPlayer();
                        player.Freeze = true;
                        player.RemoveAllPlayerWeapons();
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Es läuft bereits eine Runde... Bitte gedulde dich ein wenig...");
                    }
                }
                else
                {
                    StartNewTacticRound();
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void SyncTime()
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    if (players is null || !players.Exists) continue;
                    double leftTime = (DateTime.Now - TacticmanagerRoundCurrenttime).TotalSeconds * -1;
                    lock (players)
                        _RootCore_.VenoX.TriggerClientEvent(players, "Tactics:LoadTimer", (int)leftTime);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void SyncStats()
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    if (players is null || !players.Exists) continue;
                    lock (players)
                        _RootCore_.VenoX.TriggerClientEvent(players, "Tactics:UpdateMemberInfo", MemberCountMaxCops, MemberCountCops, MemberCountMaxBfac, MemberCountBfac);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void SyncPlayerStats()
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers))
                {
                    if (players is null || !players.Exists) continue;
                    lock (players)
                    {
                        float damageDone = players.Tactics.CurrentDamage;
                        int killsDone = players.Tactics.CurrentKills;
                        _RootCore_.VenoX.TriggerClientEvent(players, "Tactics:UpdatePlayerStats", damageDone, killsDone);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public async void SyncEndTacticRound(string text)
        {
            try
            {
                foreach (VnXPlayer players in Enumerable.ToList<VnXPlayer>(Initialize.TacticsPlayers).Where(players => players is not null && players.Exists))
                {
                    string translatedText = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)players.Language, text);
                    lock (players)
                    {
                        players.RemoveAllPlayerWeapons();
                        _RootCore_.VenoX.TriggerClientEvent(players, "Tactics:OnTacticEndRound", translatedText);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public void OnUpdate()
        {
            try
            {
                if (IsTacticRoundRunning() && TacticmanagerRoundCurrenttime <= DateTime.Now)
                {
                    if (TacticmanagerRoundStartAfterLoading <= DateTime.Now)
                    {
                        TacticmanagerRoundIsrunning = false;
                        // RageAPI.SendTranslatedChatMessageToAll("RUNDE BEENDET.");
                        StartNewTacticRound();
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}