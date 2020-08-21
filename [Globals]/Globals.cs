using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Preload_;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Main : IScript
    {
        public static List<VnXPlayer> AllPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ReallifePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> TacticsPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ZombiePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> RacePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> SevenTowersPlayers = new List<VnXPlayer>();

        public static List<VehicleModel> ReallifeVehicles = new List<VehicleModel>();

        public static void RemovePlayerFromGamemodeList(VnXPlayer player)
        {
            try
            {
                if (player == null) { Debug.OutputDebugString("Player got Removed?! "); return; }
                int Gamemode = player.Gamemode;
                if (AllPlayers.Contains(player)) { AllPlayers.Remove(player); }
                switch (Gamemode)
                {
                    case (int)Preload.Gamemodes.Reallife:
                        if (ReallifePlayers.Contains(player)) { ReallifePlayers.Remove(player); }
                        break;
                    case (int)Preload.Gamemodes.Tactics:
                        if (TacticsPlayers.Contains(player)) { TacticsPlayers.Remove(player); }
                        break;
                    case (int)Preload.Gamemodes.Zombies:
                        if (ZombiePlayers.Contains(player)) { ZombiePlayers.Remove(player); }
                        break;
                    case (int)Preload.Gamemodes.Race:
                        if (RacePlayers.Contains(player)) { RacePlayers.Remove(player); }
                        break;
                    case (int)Preload.Gamemodes.SevenTowers:
                        if (SevenTowersPlayers.Contains(player)) { SevenTowersPlayers.Remove(player); }
                        break;
                    default:
                        Debug.OutputDebugString(player.Username + " Gamemode got Removed without getting Current GM : " + player.Gamemode);
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("RemovePlayerFromGamemodeList", ex); }
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
                Console.WriteLine("VenoX V." + Preload.CURRENT_VERSION + " Loaded!");
            }
            catch (Exception ex) { Debug.CatchExceptions("OnResourceStart", ex); }
        }



        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(IColShape shape, IEntity entity, bool state)
        {
            try
            {
                if (!(entity is VnXPlayer player)) return;
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
                else { _Gamemodes_.Reallife.Globals.Main.OnPlayerExitColShapeModel(shape, player); }
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(VnXPlayer player, IEntity entity, uint reason)
        {
            try
            {
                player.DespawnPlayer();
                VnXPlayer killer = null;
                if (entity is VnXPlayer entity_k)
                {
                    killer = entity_k;
                }
                switch (player.Gamemode)
                {
                    case (int)Preload.Gamemodes.Tactics:
                        if (killer == null) { killer = player.vnxGetElementData<VnXPlayer>("VenoX:LastDamaged"); }
                        if (Functions.IstargetInSameLobby(player, killer))
                        {
                            _Gamemodes_.Tactics.environment.Death.OnPlayerDeath(player, killer);
                        }
                        else
                        {
                            Debug.OutputDebugString("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.Username);
                            RageAPI.SendTranslatedChatMessageToAll("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.Username);
                        }
                        return;
                    case (int)Preload.Gamemodes.Reallife:
                        {
                            if (killer == null || Functions.IstargetInSameLobby(player, killer))
                            {
                                _Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                                _Gamemodes_.Reallife.gangwar.Allround.OnPlayerDeath(player, killer, reason);
                            }
                        }
                        return;
                    case (int)Preload.Gamemodes.SevenTowers:
                        {
                            _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                        }
                        return;
                    default:
                        Debug.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        return;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnDeath", ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(VnXPlayer player, VnXPlayer killer, float Damage = 0)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "Globals:ShowBloodScreen");
                killer.Emit("Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamaged", killer);
                _Gamemodes_.Tactics.weapons.Combat.OnTacticsDamage(player, killer, Damage);
            }
            catch { }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                _Gamemodes_.Reallife.Globals.Main.OnUpdate();
                _Gamemodes_.Tactics.Globals.Main.OnUpdate();
                _Gamemodes_.Race.Globals.Main.OnUpdate();
                _Gamemodes_.SevenTowers.Main.OnUpdate();
                _Gamemodes_.Zombie.Globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnUpdate", ex); }
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
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerDisconnect", ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(IPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try { source?.Emit("Globals:ShowBloodScreen"); }
            catch { }
        }

        [ClientEvent("Discord:Auth")]
        public static void LoadDiscordInformations(VnXPlayer player, bool IsOpen, string Id, string Name, string Avatar, string Discriminator)
        {
            try
            {
                Debug.OutputDebugString(player.Username + " | " + IsOpen + " | " + Id + " | " + Name + " | " + Avatar + " | " + Discriminator);
                player.Discord.ID = Id;
                player.Discord.IsOpen = IsOpen;
                player.Discord.Name = Name;
                player.Discord.Avatar = Avatar;
                player.Discord.Discriminator = Discriminator;
            }
            catch (Exception ex) { Debug.CatchExceptions("LoadDiscordInformations", ex); }
        }
    }
}
