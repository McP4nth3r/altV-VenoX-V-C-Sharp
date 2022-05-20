using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Race.lobby;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.Sync;
using VenoX.Debug;

namespace VenoX.Core._Preload_
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
            Initialize.OnResourceStart();
            //Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            //Console.WriteLine("Stopped");
        }
    }
    public class Preload : IScript
    {
        public const string CurrentVersion = "2.2.0";
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

        // Reallife Lobby Dict.
        public static readonly Dictionary<global::VenoX.Core._Language_.Constants.Languages, int> ReallifeLobbys = new Dictionary<global::VenoX.Core._Language_.Constants.Languages, int>()
        {
            { global::VenoX.Core._Language_.Constants.Languages.Russian, _Globals_.Initialize.ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.Russian },
            { global::VenoX.Core._Language_.Constants.Languages.German, _Globals_.Initialize.ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.German },
            { global::VenoX.Core._Language_.Constants.Languages.English, _Globals_.Initialize.ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.English },
            { global::VenoX.Core._Language_.Constants.Languages.Spanish, _Globals_.Initialize.ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.Spanish },
        };

        public static void ShowPreloadList(VnXPlayer player, bool state)
        {
            try {
                if (!Initialize.AllPlayers.Contains(player))
                {                    
                    if (player.IsInVehicle) player.WarpOutOfVehicle();
                    player.RemoveAllPlayerWeapons();
                    player.Dimension = 9000 + player.Id;
                    player.Gamemode = -1;
                    Initialize.AllPlayers.Add(player);
                }
                _RootCore_.VenoX.TriggerClientEvent(player, "Preload:ShowGamemodes", state);                
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [AsyncClientEvent("Preload:SelectLanguage")]
        public static async void OnSelectedClientLanguage(VnXPlayer player, string languagePair)
        {
            try
            {
                player.Language = (int)global::VenoX.Core._Language_.Main.GetLanguageByPair(languagePair);
                _Globals_.Notification.DrawNotification(player, type: _Globals_.Notification.Types.Info, await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Du hast deine Sprache erfolgreich geändert!"));
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
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
                Initialize.OnPlayerDisconnected(player, "lobby-leave");
                Load.UnloadGamemodeWindows(player, (Gamemodes)player.Gamemode);
                ShowPreloadList(player, true);
                player.Gamemode = -1;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("Preload:SelectGamemode")]
        public static void PreloadSelectGamemode(VnXPlayer player, int value, string countrycode, bool loadStuff)
        {
            try
            {
                if (player == null) return;
                if (player.PreloadEvents.Count > 0) return;
                player.Dimension = player.Id;
                ConsoleHandling.OutputDebugString("Your countrycode is : ~ " + countrycode + " | value : " + value + " | loadStuff : " + loadStuff);

                if (countrycode != "" && value == (int)Gamemodes.Reallife) {
                    global::VenoX.Core._Language_.Constants.Languages language = global::VenoX.Core._Language_.Main.GetLanguageByPair(countrycode);
                    player.Language = (int)language;
                    ConsoleHandling.OutputDebugString("You joined lobby ~ " + language + " | " + countrycode);
                    Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Info, "Welcome to VenoX!");
                }
                _RootCore_.VenoX.TriggerClientEvent(player, "Gameversion:Update", CurrentVersion);
                player.Gamemode = value;

                if (loadStuff)
                {
                    ShowPreloadList(player, false);
                    Load.LoadGamemodeSpecificData(player, (Gamemodes)value);
                    return;
                }
                player.RemoveAllPlayerWeapons();
                switch (value)
                {
                    case (int)Gamemodes.Reallife:
                        if (!Initialize.ReallifePlayers.Contains(player)) Initialize.ReallifePlayers.Add(player);
                        global::VenoX.Core._Gamemodes_.Reallife.register_login.Login.OnSelectedReallifeGM(player);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Reallife");
                        break;
                    case (int) Gamemodes.Zombies:
                        if (!Initialize.ZombiePlayers.Contains(player)) Initialize.ZombiePlayers.Add(player);
                        if (player.PreloadEvents.Count > 0) return;
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Zombie.World.Main.OnSelectedZombieGM(player); 
                        // _Maps_.Main.LoadMap(player, _Maps_.Main.ZOMBIES_MAP);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Load_Zombie_GM");
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Zombies");
                        break;
                    case (int)Gamemodes.Tactics:
                        if (!Initialize.TacticsPlayers.Contains(player)) Initialize.TacticsPlayers.Add(player); 
                        ConsoleHandling.OutputDebugString("countrycode : " + countrycode);
                        int lobby = int.Parse(countrycode);
                        ConsoleHandling.OutputDebugString("Lobby : " + lobby);
                        Pointer.OnSelectedTacticLobby(player, lobby);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Tactics");
                        break;
                    case (int)Gamemodes.Race:
                        if (!Initialize.RacePlayers.Contains(player)) Initialize.RacePlayers.Add(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        Main.OnSelectedRaceGM(player);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Race");
                        break;
                    case (int)Gamemodes.SevenTowers:
                        if (!Initialize.SevenTowersPlayers.Contains(player)) Initialize.SevenTowersPlayers.Add(player);
                        _Gamemodes_.SevenTowers.lobby.Main.JoinedSevenTowers(player);
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Seven-Towers");
                        break;
                    case (int)Gamemodes.Derby:
                        if (!Initialize.DerbyPlayers.Contains(player)) Initialize.DerbyPlayers.Add(player);
                        _Gamemodes_.Derby.Lobby.Main.OnPlayerJoin(player);
                        _RootCore_.VenoX.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Derby");
                        break;
                    case (int)Gamemodes.Shooter:
                        if (!Initialize.DerbyPlayers.Contains(player)) Initialize.ShooterPlayers.Add(player);
                        _Gamemodes_.Shooter.Lobby.Lobby.OnPlayerConnect(player);
                        break;
                    default:
                        ConsoleHandling.OutputDebugString("PRELOAD ERROR : COULDN'T FIND SPECIFIC GAMEMODE! " + value);
                        break;
                }
                player.Playing = true;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        private static void GetAllPlayersInAllGamemodes(VnXPlayer player)
        {
            try
            {
                _RootCore_.VenoX.TriggerClientEvent(player, "LoadPreloadUserInfo", _RootCore_.VenoX.GetAllPlayers().ToList().Count, 1000, Initialize.ReallifePlayers.Count, Initialize.ReallifeMaxPlayers, Initialize.TacticsPlayers.Count, Initialize.TacticsMaxPlayers, Initialize.ZombiePlayers.Count, Initialize.ZombiesMaxPlayers, Initialize.RacePlayers.Count, Initialize.RaceMaxPlayers, Initialize.SevenTowersPlayers.Count, Initialize.SeventowersMaxPlayers);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        [ServerEvent("GlobalSystems:PlayerReady")]
        public void PlayerConnect(VnXPlayer player)
        {
            try
            {
                player.RemoveAllPlayerWeapons();
                Loading.Main.ShowLoadingScreen(player);
                GetAllPlayersInAllGamemodes(player);
                _Maps_.Main.LoadMap(player, _Maps_.Main.ShooterMap);
                Sync.SyncDateTime(player);
                Sync.SyncWeather(player);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }


        [VenoXRemoteEvent("Preload:FinishedPrivacyPolicy")]
        public static void FinishedPrivacyPolicy(VnXPlayer player)
        {
            player.FinishedPrivacyPolicy = true;
            _RootCore_.VenoX.TriggerClientEvent(player, "showLoginWindow", "Willkommen auf VenoX", global::VenoX.Core._Gamemodes_.Reallife.register_login.Login.GetCurrentChangelogs());
            _RootCore_.VenoX.TriggerClientEvent(player, "LoadingScreen:ShowPreload", false);
        }

        public static DateTime PreloadCheck = DateTime.Now;
        public static void OnUpdate()
        {
            try
            {
                IEnumerable<VnXPlayer> loadingPlayers = _RootCore_.VenoX.GetAllPlayers().ToList().Where(x => x.FinishedPrivacyPolicy);
                foreach (VnXPlayer players in loadingPlayers)
                {
                    
                    //Core.Debug.OutputDebugString("Event-Count : " + players.PreloadEvents.ToList().Count);
                    LoadingModel @event = players.PreloadEvents.ToList().OrderBy(x => x.EventName).FirstOrDefault(x => !x.Send);
                    if (@event is null) continue;
                    //Core.Debug.OutputDebugString("Called Event : " + Event.EventName + " | " + Event.EventText);
                    _RootCore_.VenoX.TriggerClientEvent(players, "Preload:UpdateDownloadState", @event.EventText);
                    _RootCore_.VenoX.TriggerClientEvent(players, @event.EventName, @event.EventArgs);
                    players.PreloadEvents.Remove(@event);
                    //Debug.OutputDebugString(players.Username + " Sending Preload Update : " + players.PreloadEvents.Count + " | " + @event.EventName);
                    if (players.PreloadEvents.ToList().Count > 0) continue;
                    _RootCore_.VenoX.TriggerClientEvent(players, "LoadingScreen:ShowPreload", false);
                    //Debug.OutputDebugString(players.Username + "LoadingScreen:ShowPreload : false ");
                    if(players.Gamemode == -1) continue;
                    PreloadSelectGamemode(players, players.Gamemode, global::VenoX.Core._Language_.Main.GetClientLanguagePair((global::VenoX.Core._Language_.Constants.Languages)players.Language), false);
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}