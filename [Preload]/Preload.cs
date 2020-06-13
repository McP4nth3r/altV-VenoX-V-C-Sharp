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

        [Command("leave")]
        public static void ShowGamemodeSelection(Client player)
        {
            try
            {
                player.Dimension = player.Id;
                Load.UnloadGamemodeWindows(player, (Gamemodes)player.Gamemode);
                Alt.Server.TriggerClientEvent(player, "preload_gm_list");
            }
            catch { }
        }


        [ClientEvent("Load_selected_gm_server")]
        public static void Load_selected_gm_server(Client player, int value)
        {
            player.Dimension = player.Id;
            Alt.Server.TriggerClientEvent(player, "Gameversion:Update", CURRENT_VERSION);
            switch (value)
            {
                case 0:
                    player.Gamemode = (int)Gamemodes.Reallife; //Reallife Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.German;
                    Load.LoadGamemodeWindows(player, (int)Gamemodes.Reallife);
                    Globals.Main.ReallifePlayers.Add(player);
                    _Gamemodes_.Reallife.register_login.Login.OnSelectedReallifeGM(player);
                    Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Reallife");
                    break;
                case 1:
                    Globals.Main.ZombiePlayers.Add(player);
                    player.Language = (int)_Language_.Main.Languages.English;
                    player.Gamemode = (int)Gamemodes.Zombies; //Zombies Gamemode Selected
                    //Load.LoadGamemodeWindows(player, (int)Gamemodes.Zombies);
                    _Gamemodes_.Zombie.World.Main.OnSelectedZombieGM(player);
                    Alt.Server.TriggerClientEvent(player, "Load_Zombie_GM");
                    Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Zombies");
                    break;
                case 2:
                    player.Gamemode = (int)Gamemodes.Tactics;//Tactics Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.German;
                    Globals.Main.TacticsPlayers.Add(player);
                    _Gamemodes_.Tactics.Lobby.Main.OnSelectedTacticsGM(player);
                    Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Tactics");
                    //Load.LoadGamemodeWindows(player, (int)Gamemodes.Tactics);
                    break;
                case 3:
                    player.Gamemode = (int)Gamemodes.Race;
                    player.Language = (int)_Language_.Main.Languages.English;
                    Globals.Main.RacePlayers.Add(player);
                    _Gamemodes_.Race.Lobby.Main.OnSelectedRaceGM(player);
                    //Load.LoadGamemodeWindows(player, (int)Gamemodes.Race);
                    Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Race");
                    break;
                case 4:
                    player.Gamemode = (int)Gamemodes.SevenTowers; //7-Towers Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.English;
                    Globals.Main.SevenTowersPlayers.Add(player);
                    _Gamemodes_.SevenTowers.Main.JoinedSevenTowers(player);
                    //Load.LoadGamemodeWindows(player, (int)Gamemodes.Seventowers);
                    Alt.Server.TriggerClientEvent(player, "Player:ChangeCurrentLobby", "Seven-Towers");
                    break;
                default:
                    Core.Debug.OutputDebugString("PRELOAD ERROR : COULDN'T FIND SPECIFIC GAMEMODE! " + value);
                    break;
            }
            player.Playing = true;
            Alt.Server.TriggerClientEvent(player, "Preload:LoadTickEvents", player.Gamemode);
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

        private static void LoadReallifeMaps(Client player)
        {
            _Maps_.Main.LoadMap(player, _Maps_.Main.LSPD_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.NOOBSPAWN_MAP);
            _Maps_.Main.LoadMap(player, _Maps_.Main.STADTHALLE_MAP);
        }
        private static void LoadSevenTowersMap(Client player)
        {
            _Maps_.Main.LoadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
        }
        [ServerEvent("GlobalSystems:PlayerReady")]
        public void PlayerConnect(Client player)
        {
            try
            {
                LoadSevenTowersMap(player);
                LoadReallifeMaps(player);
                Alt.Server.TriggerClientEvent(player, "showLoginWindow", "Willkommen auf VenoX", _Gamemodes_.Reallife.register_login.Login.GetCurrentChangelogs());
                player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_NONE); // None Gamemode
                _Gamemodes_.Reallife.register_login.Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerConnect", ex); }
        }


        [ClientEvent("TriggerClientsideVehicle")]
        public static void GetTriggeredVehicle(Client player, IVehicle veh)
        {
            try
            {
                Core.Debug.OutputDebugString(player.Name + " : Das Fahrzeug hast du bekommen : " + veh.PrimaryColorRgb.R);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("TriggerClientsideVehicle", ex); }
        }
    }
}