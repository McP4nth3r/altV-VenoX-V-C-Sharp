using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Preload_;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Main : IScript
    {
        // Settings
        public static int REALLIFE_MAX_PLAYERS = 1000;
        public static int TACTICS_MAX_PLAYERS = 20;
        public static int RACE_MAX_PLAYERS = 5;
        public static int SEVENTOWERS_MAX_PLAYERS = 20;
        public static int ZOMBIES_MAX_PLAYERS = 200;

        // Const 
        public static List<VnXPlayer> AllPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ReallifePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> TacticsPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ZombiePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> RacePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> SevenTowersPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> DerbyPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ShooterPlayers = new List<VnXPlayer>();
        public static List<VehicleModel> AllVehicles = new List<VehicleModel>();
        public static List<VehicleModel> ReallifeVehicles = new List<VehicleModel>();

        public const int RACE_DIMENSION = 0;
        public const int REALLIFE_DIMENSION = 1;
        public const int TACTICS_DIMENSION = 2;
        public const int SEVENTOWERS_DIMENSION = 4;
        public const int ZOMBIES_DIMENSION = 5;

        public static void RemovePlayerFromGamemodeList(VnXPlayer player)
        {
            try
            {
                if (player == null) { Debug.OutputDebugString("Player got Removed?! "); return; }
                int Gamemode = player.Gamemode;
                if (AllPlayers.Contains(player)) AllPlayers.Remove(player);
                switch (Gamemode)
                {
                    case (int)Preload.Gamemodes.Reallife:
                        if (ReallifePlayers.Contains(player)) ReallifePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Tactics:
                        if (TacticsPlayers.Contains(player)) TacticsPlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Zombies:
                        if (ZombiePlayers.Contains(player)) ZombiePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Race:
                        if (RacePlayers.Contains(player)) RacePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.SevenTowers:
                        if (SevenTowersPlayers.Contains(player)) SevenTowersPlayers.Remove(player);
                        break;
                    default:
                        Debug.OutputDebugString(player.Username + " Gamemode got Removed without getting Current GM : " + player.Gamemode);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [Command("getuserinfo")]
        public static void GetUserInfo(VnXPlayer player, int ID)
        {
            switch (ID)
            {
                case (int)Preload.Gamemodes.Reallife:
                    Core.Debug.OutputDebugString(ID + " : " + ReallifePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Tactics:
                    Core.Debug.OutputDebugString(ID + " : " + TacticsPlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Zombies:
                    Core.Debug.OutputDebugString(ID + " : " + ZombiePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Race:
                    Core.Debug.OutputDebugString(ID + " : " + RacePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.SevenTowers:
                    Core.Debug.OutputDebugString(ID + " : " + SevenTowersPlayers.Count);
                    break;
                default:
                    Core.Debug.OutputDebugString(ID + " : " + 0);
                    break;
            }
        }


        public static void OnResourceStart()
        {
            try
            {
                _Gamemodes_.Reallife.Globals.Main.OnResourceStart();
                _Gamemodes_.Tactics.Globals.Main.OnResourceStart();
                _Gamemodes_.SevenTowers.Main.OnResourceStart();
                _Language_.Main.OnResourceStart();
                Console.WriteLine("VenoX V." + Preload.CURRENT_VERSION + " Loaded!");
                Console.WriteLine(_Language_.Main.GetTranslatedTextAsync(_Language_.Main.Languages.English, "Hello Welt!"));

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        [AsyncScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(ColShapeModel shape = null, IEntity entity = null, bool state = false)
        {
            try
            {
                if (entity is not VnXPlayer player || shape is null || !shape.Exists) return;
                if (state)
                {
                    switch (player.Gamemode)
                    {
                        case (int)Preload.Gamemodes.Reallife:
                            _Gamemodes_.Reallife.Globals.Main.OnPlayerEnterColShapeModel(shape, player);
                            return;
                        case (int)Preload.Gamemodes.SevenTowers:
                            SevenTowers.globals.Main.OnColShapeHit(shape, player);
                            return;
                        case (int)Preload.Gamemodes.Race:
                            _Gamemodes_.Race.Lobby.Main.OnColshapeHit(shape, player);
                            return;
                    }
                }
                else _Gamemodes_.Reallife.Globals.Main.OnPlayerExitColShapeModel(shape, player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(VnXPlayer player, IEntity entity, uint reason)
        {
            try
            {
                player.DespawnPlayer();
                VnXPlayer killer = null;
                if (entity is VnXPlayer entity_k) killer = entity_k;
                switch (player.Gamemode)
                {
                    case (int)Preload.Gamemodes.Tactics:
                        if (killer is null)
                        {
                            VnXPlayer NewKiller = player.vnxGetElementData<VnXPlayer>("VenoX:LastDamaged");
                            if (NewKiller is null) killer = player;
                            else killer = NewKiller;
                        }
                        _Gamemodes_.Tactics.environment.Death.OnPlayerDeath(player, killer);
                        return;
                    case (int)Preload.Gamemodes.Reallife:
                        if (killer == null || Functions.IstargetInSameLobby(player, killer))
                        {
                            _Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                            _Gamemodes_.Reallife.gangwar.Allround.OnPlayerDeath(player, killer, reason);
                        }
                        return;
                    case (int)Preload.Gamemodes.SevenTowers:
                        _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                        return;
                    case (int)Preload.Gamemodes.Zombies:
                        _Gamemodes_.Zombie.World.Main.OnPlayerDeath(player);
                        return;
                    default:
                        Debug.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        return;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(VnXPlayer player, VnXPlayer killer, float Damage = 0)
        {
            try
            {
                player.vnxSetStreamSharedElementData("PLAYER_HEALTH", player.Health);
                player.vnxSetStreamSharedElementData("PLAYER_ARMOR", player.Armor);
                VenoX.TriggerClientEvent(killer, "Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamaged", killer);
                _Gamemodes_.Tactics.weapons.Combat.OnTacticsDamage(player, killer, Damage);
                _Gamemodes_.Reallife.gangwar.Allround.ProcessDamage(player, killer, Damage);
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("playerdmg", player?.Username + " hat " + killer?.Username + " angehitted!| DMG : " + Damage);
            }
            catch { }
        }

        [ServerEvent("GlobalSystems:OnVehicleSyncDamage")]
        public void OnPlayerVehicleDamage(VnXPlayer player, VehicleModel vehicle, float Damage = 0)
        {
            try
            {
                if (vehicle.Godmode) return;
                VenoX.TriggerClientEvent(player, "Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamagedVehicle", vehicle);
                Debug.OutputDebugString(player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! DMG : " + Damage);
                string DriverName = "niemand";
                if (vehicle.Driver != null)
                {
                    VnXPlayer _Driver = (VnXPlayer)vehicle.Driver;
                    DriverName = _Driver.Username;
                }
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("vehdmg", player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! | Fahrer falls vorhanden : " + DriverName + " | DMG : " + Damage);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                _Preload_.Preload.OnUpdate();
                _Gamemodes_.Reallife.Globals.Main.OnUpdate();
                _Gamemodes_.Tactics.Globals.Main.OnUpdate();
                _Gamemodes_.Race.Globals.Main.OnUpdate();
                _Gamemodes_.SevenTowers.Main.OnUpdate();
                _Gamemodes_.Zombie.Globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public static void OnPlayerDisconnected(VnXPlayer player, string reason)
        {
            try
            {
                RemovePlayerFromGamemodeList(player);
                string type = string.Empty;
                _Gamemodes_.Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                _Gamemodes_.Tactics.Globals.Main.OnPlayerDisconnect(player, type, reason);
                _Gamemodes_.Zombie.Globals.Events.OnPlayerDisconnect(player);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(VnXPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try
            {
                source.vnxSetStreamSharedElementData("PLAYER_HEALTH", source.Health);
                source.vnxSetStreamSharedElementData("PLAYER_ARMOR", source.Armor);
                VenoX.TriggerClientEvent(source, "Globals:ShowBloodScreen");
            }
            catch { }
        }

        [ClientEvent("Discord:Auth")]
        public static void LoadDiscordInformations(VnXPlayer player, bool IsOpen, string Id, string Name, string Avatar, string Discriminator)
        {
            try
            {
                Debug.OutputDebugString(player.Username + " | UID " + player.UID + " | " + IsOpen + " | " + Id + " | " + Name + " | " + Avatar + " | " + Discriminator);
                player.Discord.ID = Id;
                player.Discord.IsOpen = IsOpen;
                player.Discord.Name = Name;
                player.Discord.Avatar = Avatar;
                player.Discord.Discriminator = Discriminator;
                Database.UpdateDiscordInformations(player.Username, player.Discord.ID, player.Discord.Avatar);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
