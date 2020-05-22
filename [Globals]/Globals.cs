using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Main : IScript
    {
        public static List<Client> ReallifePlayers = new List<Client>();
        public static List<Client> TacticsPlayers = new List<Client>();
        public static List<Client> ZombiePlayers = new List<Client>();
        public static List<Client> RacePlayers = new List<Client>();
        public static List<Client> SevenTowersPlayers = new List<Client>();


        public static void RemovePlayerFromGamemodeList(Client player)
        {
            try
            {
                int Gamemode = player.Gamemode;
                switch (Gamemode)
                {
                    case (int)_Preload_.Preload.Gamemodes.Reallife:
                        ReallifePlayers.Remove(player);
                        break;
                    case (int)_Preload_.Preload.Gamemodes.Tactics:
                        TacticsPlayers.Remove(player);
                        break;
                    case (int)_Preload_.Preload.Gamemodes.Zombies:
                        ZombiePlayers.Remove(player);
                        break;
                    case (int)_Preload_.Preload.Gamemodes.Race:
                        RacePlayers.Remove(player);
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("RemovePlayerFromGamemodeList", ex); }
        }


        public static void OnResourceStart()
        {
            try
            {
                _Gamemodes_.Reallife.Globals.Main.OnResourceStart();
                _Gamemodes_.Tactics.Globals.Main.OnResourceStart();
                SevenTowers.Lobby.Main.OnResourceStart();
            }
            catch (Exception ex) { Debug.CatchExceptions("OnResourceStart", ex); }
        }



        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(IColShape shape, IEntity entity, bool state)
        {
            try
            {
                if (!(entity is Client player)) return;
                if (state) { _Gamemodes_.Reallife.Globals.Main.OnPlayerEnterIColShape(shape, player); }
                else { _Gamemodes_.Reallife.Globals.Main.OnPlayerExitIColShape(shape, player); }
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(Client player, Client killer, uint reason)
        {
            try
            {
                player.DespawnPlayer();
                if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Tactics)
                {
                    if (killer == null) { killer = player.vnxGetElementData<Client>("VenoX:LastDamaged"); }
                    if (Functions.IstargetInSameLobby(player, killer))
                    {
                        _Gamemodes_.Tactics.environment.Death.OnPlayerDeath(player, killer);
                    }
                    else
                    {
                        Core.Debug.OutputDebugString("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.Username);
                        Core.RageAPI.SendTranslatedChatMessageToAll("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.Username);
                    }
                    return;
                }
                else if (player.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    if (killer == null || Functions.IstargetInSameLobby(player, killer))
                    {
                        VenoXV._Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                    }
                }
                else
                {
                    Core.Debug.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE));
                    Core.RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE));
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnDeath", ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(Client player, Client killer)
        {
            try
            {
                player.Emit("Globals:ShowBloodScreen");
                killer.Emit("Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamaged", killer);
            }
            catch { }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                _Gamemodes_.Reallife.Globals.Main.OnUpdate();
                _Gamemodes_.Tactics.Globals.Main.OnUpdate();
                _Gamemodes_.Race.Globals.main.OnUpdate();
                Zombie.globals.Main.OnUpdate();
                //SevenTowers.globals.Main.OnUpdate();
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnected(Client player, string reason)
        {
            try
            {
                string type = string.Empty;
                _Gamemodes_.Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                _Gamemodes_.Tactics.Globals.Main.OnPlayerDisconnect(player, type, reason);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(IPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try
            {
                source?.Emit("Globals:ShowBloodScreen");
            }
            catch { }
        }


    }
}
