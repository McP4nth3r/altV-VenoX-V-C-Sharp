using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using System;
using VenoXV._Gamemodes_.Reallife.register_login;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Preload
{
    internal class VenoXResource : AsyncResource
    {
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new MyPlayerFactory();
        }
        public override void OnStart()
        {
            VenoXV.Globals.Main.OnResourceStart();
            //Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            //Console.WriteLine("Stopped");
        }
    }
    public class Preload : IScript
    {

        [ClientEvent("Load_selected_gm_server")]
        public static void Load_selected_gm_server(Client player, int value)
        {
            switch (value)
            {
                case 0:
                    player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_REALLIFE); //Reallife Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.German;
                    Login.OnSelectedReallifeGM(player);
                    Globals.Main.ReallifePlayers.Add(player);
                    player.Emit("Player:ChangeCurrentLobby", "Reallife");
                    break;
                case 1:
                    //if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    //{
                    Globals.Main.ZombiePlayers.Add(player);
                    player.Language = (int)_Language_.Main.Languages.English;
                    player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_ZOMBIE); //Tactics Gamemode Selected
                    Zombie.World.Main.OnSelectedZombieGM(player);
                    player.Emit("Load_Zombie_GM");
                    player.Emit("Player:ChangeCurrentLobby", "Zombies");
                    //}
                    break;
                case 2:
                    player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_TACTICS); //Tactics Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.English;
                    Globals.Main.TacticsPlayers.Add(player);
                    _Gamemodes_.Tactics.Lobby.Main.OnSelectedTacticsGM(player);
                    player.Emit("Player:ChangeCurrentLobby", "Tactics");
                    break;
                case 3:
                    player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_RACE);
                    player.Language = (int)_Language_.Main.Languages.English;
                    Globals.Main.RacePlayers.Add(player);
                    _Gamemodes_.Race.Lobby.Main.OnSelectedRaceGM(player);
                    player.Emit("Player:ChangeCurrentLobby", "Race");
                    break;
                case 4:
                    player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_SEVENTOWERS); //7-Towers Gamemode Selected
                    player.Language = (int)_Language_.Main.Languages.English;
                    SevenTowers.Lobby.Main.JoinedSevenTowers(player);
                    player.Emit("Player:ChangeCurrentLobby", "Seven-Towers");
                    break;
            }
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
                player.Emit("LoadPreloadUserInfo", ZombiePlayers + " Online.", ReallifePlayers + " Online.", TacticsPlayers + " Online.");
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void PlayerConnect(Client player, string reason)
        {
            try
            {
                player.Emit("showLoginWindow", "Willkommen auf VenoX", Login.GetCurrentChangelogs());
                //ShowLogin(player);
                Core.Debug.OutputDebugString("[CONNECTED] : " + player.GetVnXName() + " | SERIAL : " + player.HardwareIdHash + " | SOCIALCLUB : " + player.SocialClubId + " | IP : " + player.Ip);
                player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_NONE); // None Gamemode
                Login.CreateNewLogin_Cam(player, 0, 0);
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