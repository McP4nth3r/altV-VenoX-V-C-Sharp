using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

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
        public const string CURRENT_VERSION = "1.5.0";
        public enum Gamemodes
        {
            Reallife = 0,
            Zombies = 1,
            Tactics = 2,
            Race = 3,
            SevenTowers = 4,
        };

        public static void ShowPreloadList(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "preload_gm_list");
        }

        [Command("leave")]
        public static void ShowGamemodeSelection(Client player)
        {
            try
            {
                player.Dimension = player.Id;
                VenoXV.Globals.Main.OnPlayerDisconnected(player, "lobby-leave");
                Load.UnloadGamemodeWindows(player, (Gamemodes)player.Gamemode);
                ShowPreloadList(player);
            }
            catch { }
        }
        [Command("home")]
        public static void ShowGamemodeSelectionHome(Client player)
        {
            try { ShowGamemodeSelection(player); }
            catch { }
        }
        [Command("lobby")]
        public static void ShowGamemodeSelectionLobby(Client player)
        {
            try { ShowGamemodeSelection(player); }
            catch { }
        }
        [Command("hub")]
        public static void ShowGamemodeSelectionHub(Client player)
        {
            try { ShowGamemodeSelection(player); }
            catch { }
        }

        [ClientEvent("Load_selected_gm_server")]
        public static void Load_selected_gm_server(Client player, int value)
        {
            try
            {
                player.Dimension = player.Id;
                Alt.Server.TriggerClientEvent(player, "Gameversion:Update", CURRENT_VERSION);
                player.Gamemode = value;
                Load.LoadGamemodeWindows(player, (Gamemodes)value);
                player.Language = (int)_Language_.Main.Languages.German;
                switch (value)
                {
                    case (int)Gamemodes.Reallife:
                        if (!Globals.Main.ReallifePlayers.Contains(player)) { Globals.Main.ReallifePlayers.Add(player); }
                        _Gamemodes_.Reallife.register_login.Login.OnSelectedReallifeGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Reallife");
                        break;
                    case (int)Gamemodes.Zombies:
                        if (!Globals.Main.ZombiePlayers.Contains(player)) { Globals.Main.ZombiePlayers.Add(player); }
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Zombie.World.Main.OnSelectedZombieGM(player);
                        _Maps_.Main.LoadMap(player, _Maps_.Main.ZOMBIES_MAP);
                        Alt.Server.TriggerClientEvent(player, "Load_Zombie_GM");
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Zombies");
                        break;
                    case (int)Gamemodes.Tactics:
                        player.Language = (int)_Language_.Main.Languages.France;
                        if (!Globals.Main.TacticsPlayers.Contains(player)) { Globals.Main.TacticsPlayers.Add(player); }
                        _Gamemodes_.Tactics.Lobby.Main.OnSelectedTacticsGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Tactics");
                        break;
                    case (int)Gamemodes.Race:
                        if (!Globals.Main.RacePlayers.Contains(player)) { Globals.Main.RacePlayers.Add(player); }
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.Race.Lobby.Main.OnSelectedRaceGM(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Race");
                        break;
                    case (int)Gamemodes.SevenTowers:
                        if (!Globals.Main.SevenTowersPlayers.Contains(player)) { Globals.Main.SevenTowersPlayers.Add(player); }
                        Character_Creator.Main.LoadCharacterSkin(player);
                        _Gamemodes_.SevenTowers.Main.JoinedSevenTowers(player);
                        Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Seven-Towers");
                        break;
                    default:
                        Debug.OutputDebugString("PRELOAD ERROR : COULDN'T FIND SPECIFIC GAMEMODE! " + value);
                        break;
                }
                player.Playing = true;
            }
            catch { }
        }



        public static void GetAllPlayersInAllGamemodes(Client player)
        {
            try
            {
                int ZombiePlayers = 0;
                int ReallifePlayers = 0;
                int TacticsPlayers = 0;
                foreach (Client players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == Globals.EntityData.GAMEMODE_REALLIFE) { ReallifePlayers += 1; }
                    else if (players.vnxGetElementData<string>(Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == Globals.EntityData.GAMEMODE_TACTICS) { TacticsPlayers += 1; }
                    else if (players.vnxGetElementData<string>(Globals.EntityData.PLAYER_CURRENT_GAMEMODE) == Globals.EntityData.GAMEMODE_ZOMBIE) { ZombiePlayers += 1; }
                }
                Alt.Server.TriggerClientEvent(player, "LoadPreloadUserInfo", ZombiePlayers + " Online.", ReallifePlayers + " Online.", TacticsPlayers + " Online.");
            }
            catch { }
        }


        [ServerEvent("GlobalSystems:PlayerReady")]
        public void PlayerConnect(Client player)
        {
            try
            {
                Loading.Main.ShowLoadingScreen(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerConnect", ex); }
        }
    }
}