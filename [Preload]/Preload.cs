﻿using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Globals;

namespace VenoXV._Preload_
{
    internal class VenoXResource : AsyncResource
    {
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new MyPlayerFactory();
        }
        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new MyVehicleFactory();
        }
        public override IBaseObjectFactory<IColShape> GetColShapeFactory()
        {
            return new MyColShapeFactory();
        }
        public override void OnStart()
        {
            Globals.Main.OnResourceStart();
            //Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            //Console.WriteLine("Stopped");
        }
    }
    public class Preload : IScript
    {
        public const string CURRENT_VERSION = "2.0.1";
        public enum Gamemodes
        {
            Reallife = 0,
            Zombies = 1,
            Tactics = 2,
            Race = 3,
            SevenTowers = 4,
            Derby = 5,
        };

        public static void ShowPreloadList(VnXPlayer player)
        {
            try { Alt.Server.TriggerClientEvent(player, "preload_gm_list"); }
            catch { }
        }

        [AsyncClientEvent("Preload:SelectLanguage")]
        public static async void OnSelectedClientLanguage(VnXPlayer player, string LanguagePair)
        {
            try
            {
                player.Language = (int)_Language_.Main.GetLanguageByPair(LanguagePair);
                _Notifications_.Main.DrawNotification(player, type: _Notifications_.Main.Types.Info, await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Du hast deine Sprache erfolgreich geändert!"));
            }
            catch { }
        }

        [Command("leave", aliases: new string[] { "home", "lobby", "hub" })]
        public static void ShowGamemodeSelection(VnXPlayer player)
        {
            try
            {
                GetAllPlayersInAllGamemodes(player);
                player.Dimension = 9000 + player.Id;
                Main.OnPlayerDisconnected(player, "lobby-leave");
                Load.UnloadGamemodeWindows(player, (Gamemodes)player.Gamemode);
                ShowPreloadList(player);
            }
            catch { }
        }
        [ClientEvent("Load_selected_gm_server")]
        public static void Load_selected_gm_server(VnXPlayer player, int value)
        {
            try
            {
                if (player == null) return;
                player.Dimension = player.Id;
                Alt.Server.TriggerClientEvent(player, "Gameversion:Update", CURRENT_VERSION);
                player.Gamemode = value;
                Load.LoadGamemodeWindows(player, (Gamemodes)value);
                if (!Globals.Main.AllPlayers.Contains(player)) Globals.Main.AllPlayers.Add(player);
                player.RemoveAllPlayerWeapons();
                switch (value)
                {
                    case (int)Gamemodes.Reallife:
                        if (!Main.ReallifePlayers.Contains(player)) Globals.Main.ReallifePlayers.Add(player);
                        _Gamemodes_.Reallife.register_login.Login.OnSelectedReallifeGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Reallife");
                        break;
                    case (int)Gamemodes.Zombies:
                        if (!Main.ZombiePlayers.Contains(player)) Globals.Main.ZombiePlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Zombie.World.Main.OnSelectedZombieGM(player);
                        // _Maps_.Main.LoadMap(player, _Maps_.Main.ZOMBIES_MAP);
                        Alt.Server.TriggerClientEvent(player, "Load_Zombie_GM");
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Zombies");
                        break;
                    case (int)Gamemodes.Tactics:
                        if (!Main.TacticsPlayers.Contains(player)) Globals.Main.TacticsPlayers.Add(player);
                        _Gamemodes_.Tactics.Lobby.Main.OnSelectedTacticsGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Tactics");
                        break;
                    case (int)Gamemodes.Race:
                        if (!Main.RacePlayers.Contains(player)) Globals.Main.RacePlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Race.Lobby.Main.OnSelectedRaceGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Race");
                        break;
                    case (int)Gamemodes.SevenTowers:
                        if (!Main.SevenTowersPlayers.Contains(player)) Globals.Main.SevenTowersPlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.SevenTowers.Main.JoinedSevenTowers(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Seven-Towers");
                        break;
                    case (int)Gamemodes.Derby:
                        if (!Main.DerbyPlayers.Contains(player)) Globals.Main.DerbyPlayers.Add(player);
                        _Gamemodes_.Derby.Lobby.Main.OnPlayerJoin(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Derby");
                        break;
                    default:
                        Debug.OutputDebugString("PRELOAD ERROR : COULDN'T FIND SPECIFIC GAMEMODE! " + value);
                        break;
                }
                player.Playing = true;
            }
            catch { }
        }



        public static void GetAllPlayersInAllGamemodes(VnXPlayer player)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "LoadPreloadUserInfo", VenoX.GetAllPlayers().ToList().Count, 1000, Main.ReallifePlayers.Count, Main.REALLIFE_MAX_PLAYERS, Main.TacticsPlayers.Count, Main.TACTICS_MAX_PLAYERS, Main.ZombiePlayers.Count, Main.ZOMBIES_MAX_PLAYERS, Main.RacePlayers.Count, Main.RACE_MAX_PLAYERS, Main.SevenTowersPlayers.Count, Main.SEVENTOWERS_MAX_PLAYERS);
            }
            catch { }
        }


        [ServerEvent("GlobalSystems:PlayerReady")]
        public void PlayerConnect(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                Loading.Main.ShowLoadingScreen(player);
                GetAllPlayersInAllGamemodes(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}