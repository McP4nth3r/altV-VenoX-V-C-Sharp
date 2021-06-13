using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._Gamemodes_.Zombie.Assets;
using VenoXV._Globals_;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Tactics.lobby;

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
            Main.OnResourceStart();
            //Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            //Console.WriteLine("Stopped");
        }
    }
    public class Preload : IScript
    {
        public const string CurrentVersion = "2.1.2";
        public enum Gamemodes
        {
            Reallife = 0,
            Zombies = 1,
            Tactics = 2,
            Race = 3,
            SevenTowers = 4,
            Derby = 5,
            Shooter = 7
        }

        public static void ShowPreloadList(VnXPlayer player)
        {
            try { VenoX.TriggerClientEvent(player, "preload_gm_list"); }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [AsyncClientEvent("Preload:SelectLanguage")]
        public static async void OnSelectedClientLanguage(VnXPlayer player, string languagePair)
        {
            try
            {
                player.Language = (int)_Language_.Main.GetLanguageByPair(languagePair);
                _Notifications_.Main.DrawNotification(player, type: _Notifications_.Main.Types.Info, await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Du hast deine Sprache erfolgreich geändert!"));
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("leave", aliases: new[] { "home", "lobby", "hub" })]
        public static void ShowGamemodeSelection(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle) player.WarpOutOfVehicle();
                player.RemoveAllPlayerWeapons();
                GetAllPlayersInAllGamemodes(player);
                player.Dimension = 9000 + player.Id;
                Main.OnPlayerDisconnected(player, "lobby-leave");
                Load.UnloadGamemodeWindows(player, (Gamemodes)player.Gamemode);
                ShowPreloadList(player);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("Preload:SelectGamemode")]
        public static void Load_selected_gm_server(VnXPlayer player, int value, string countrycode)
        {
            try
            {
                if (player == null) return;
                player.Dimension = player.Id;
                _Language_.Main.Languages language = (_Language_.Main.Languages)player.Language;
                if (countrycode != "" && value == (int)Gamemodes.Reallife)
                {
                    language = _Language_.Main.GetLanguageByPair(countrycode);
                    player.Language = (int)language;
                    Debug.OutputDebugString("You joined lobby ~ " + language + " | " + countrycode);
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Info, "Welcome to VenoX!");
                }
                VenoX.TriggerClientEvent(player, "Gameversion:Update", CurrentVersion);
                player.Gamemode = value;
                Load.LoadGamemodeWindows(player, (Gamemodes)value);
                if (!Main.AllPlayers.Contains(player)) Main.AllPlayers.Add(player);
                player.RemoveAllPlayerWeapons();
                switch (value)
                {
                    case (int)Gamemodes.Reallife:
                        if (!Main.ReallifePlayers.Contains(player)) Main.ReallifePlayers.Add(player);
                        Reallife.register_login.Login.OnSelectedReallifeGM(player);
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Reallife");
                        break;
                    case (int)Gamemodes.Zombies:
                        if (!Main.ZombiePlayers.Contains(player)) Main.ZombiePlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Zombie.World.Main.OnSelectedZombieGM(player);
                        // _Maps_.Main.LoadMap(player, _Maps_.Main.ZOMBIES_MAP);
                        VenoX.TriggerClientEvent(player, "Load_Zombie_GM");
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Zombies");
                        break;
                    case (int)Gamemodes.Tactics:
                        if (!Main.TacticsPlayers.Contains(player)) Main.TacticsPlayers.Add(player);
                        int lobby = Int32.Parse(countrycode);
                        Debug.OutputDebugString("Lobby : " + lobby);
                        Pointer.OnSelectedTacticLobby(player, lobby);
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Tactics");
                        break;
                    case (int)Gamemodes.Race:
                        if (!Main.RacePlayers.Contains(player)) Main.RacePlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Race.Lobby.Main.OnSelectedRaceGM(player);
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Race");
                        break;
                    case (int)Gamemodes.SevenTowers:
                        if (!Main.SevenTowersPlayers.Contains(player)) Main.SevenTowersPlayers.Add(player);
                        _Gamemodes_.SevenTowers.Main.JoinedSevenTowers(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Seven-Towers");
                        break;
                    case (int)Gamemodes.Derby:
                        if (!Main.DerbyPlayers.Contains(player)) Main.DerbyPlayers.Add(player);
                        _Gamemodes_.Derby.Lobby.Main.OnPlayerJoin(player);
                        VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Derby");
                        break;
                    case (int)Gamemodes.Shooter:
                        if (!Main.DerbyPlayers.Contains(player)) Main.ShooterPlayers.Add(player);
                        _Gamemodes_.Shooter.Lobby.Lobby.OnPlayerConnect(player);
                        break;
                    default:
                        Debug.OutputDebugString("PRELOAD ERROR : COULDN'T FIND SPECIFIC GAMEMODE! " + value);
                        break;
                }
                player.Playing = true;
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }



        public static void GetAllPlayersInAllGamemodes(VnXPlayer player)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "LoadPreloadUserInfo", VenoX.GetAllPlayers().ToList().Count, 1000, Main.ReallifePlayers.Count, Main.ReallifeMaxPlayers, Main.TacticsPlayers.Count, Main.TacticsMaxPlayers, Main.ZombiePlayers.Count, Main.ZombiesMaxPlayers, Main.RacePlayers.Count, Main.RaceMaxPlayers, Main.SevenTowersPlayers.Count, Main.SeventowersMaxPlayers);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [ServerEvent("GlobalSystems:PlayerReady")]
        public void PlayerConnect(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                Loading.Main.ShowLoadingScreen(player);
                GetAllPlayersInAllGamemodes(player);
                ZombieAssets.LoadZombieEntityData(player);
                _Maps_.Main.LoadMap(player, _Maps_.Main.ShooterMap);
                Sync.SyncDateTime(player);
                Sync.SyncWeather(player);
                /*_Maps_.Main.LoadMap(player, _Maps_.Main.NOOBSPAWN_MAP);
                _Maps_.Main.LoadMap(player, _Maps_.Main.DERBY1_MAP);
                _Maps_.Main.LoadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                _Maps_.Main.LoadMap(player, _Maps_.Main.LSPD_MAP);#
                */
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [VenoXRemoteEvent("Preload:FinishedPrivacyPolicy")]
        public static void FinishedPrivacyPolicy(VnXPlayer player)
        {
            player.FinishedPrivacyPolicy = true;
        }

        public static DateTime PreloadCheck = DateTime.Now;
        public static void OnUpdate()
        {
            try
            {
                var loadingPlayers = Alt.GetAllPlayers().ToList().Where(x => !((VnXPlayer)x).Loading && ((VnXPlayer)x).FinishedPrivacyPolicy);
                foreach (VnXPlayer players in loadingPlayers)
                {
                    //Core.Debug.OutputDebugString("Event-Count : " + players.PreloadEvents.ToList().Count);
                    var @event = players.PreloadEvents.ToList().OrderBy(x => x.EventName).FirstOrDefault(x => !x.Send);
                    if (@event is null) continue;
                    //Core.Debug.OutputDebugString("Called Event : " + Event.EventName + " | " + Event.EventText);
                    VenoX.TriggerClientEvent(players, "Preload:UpdateDownloadState", @event.EventText);
                    VenoX.TriggerClientEvent(players, @event.EventName, @event.EventArgs);
                    players.PreloadEvents.Remove(@event);
                    if (players.PreloadEvents.ToList().Count <= 0)
                    {
                        players.Loading = false;
                        VenoX.TriggerClientEvent(players, "LoadingScreen:ShowPreload", false);
                        VenoX.TriggerClientEvent(players, "showLoginWindow", "Willkommen auf VenoX", Reallife.register_login.Login.GetCurrentChangelogs());
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}