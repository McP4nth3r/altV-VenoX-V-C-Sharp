﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Main : IScript
    {
        public static List<IPlayer> ReallifePlayers = new List<IPlayer>();
        public static List<IPlayer> TacticsPlayers = new List<IPlayer>();
        public static List<IPlayer> ZombiePlayers = new List<IPlayer>();
        public static List<IPlayer> RacePlayers = new List<IPlayer>();


        public static void AddPlayerIntoGamemodeList(Client player, string Gamemode)
        {
            try
            {
                switch (Gamemode)
                {
                    case EntityData.GAMEMODE_REALLIFE:
                        ReallifePlayers.Add(player);
                        break;
                    case EntityData.GAMEMODE_TACTICS:
                        TacticsPlayers.Add(player);
                        break;
                    case EntityData.GAMEMODE_ZOMBIE:
                        ZombiePlayers.Add(player);
                        break;
                    case EntityData.GAMEMODE_RACE:
                        RacePlayers.Add(player);
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("AddPlayerIntoGamemodeList", ex); }
        }
        public static void RemovePlayerFromGamemodeList(Client player)
        {
            try
            {
                string Gamemode = player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE);
                switch (Gamemode)
                {
                    case EntityData.GAMEMODE_REALLIFE:
                        ReallifePlayers.Remove(player);
                        break;
                    case EntityData.GAMEMODE_TACTICS:
                        TacticsPlayers.Remove(player);
                        break;
                    case EntityData.GAMEMODE_ZOMBIE:
                        ZombiePlayers.Remove(player);
                        break;
                    case EntityData.GAMEMODE_RACE:
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
                Client player = entity as Client;
                if (player == null) return;
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
                if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS)
                {
                    if (killer == null) { killer = RageAPI.GetPlayerFromName(player.vnxGetElementData<string>(_Gamemodes_.Tactics.Globals.EntityData.PLAYER_LAST_DAMAGED_BY)); }
                    if (Functions.IstargetInSameLobby(player, killer))
                    {
                        _Gamemodes_.Tactics.environment.Death.OnPlayerDeath(player, killer);
                    }
                    else
                    {
                        Core.Debug.OutputDebugString("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.GetVnXName());
                        Core.RageAPI.SendTranslatedChatMessageToAll("[ERROR]: PLAYER NOT IN SAME LOBBY " + killer.GetVnXName());
                    }
                    return;
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_REALLIFE)
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

        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static void WeaponDamage(Client source, Client target, uint weapon, ushort damage, Position offset, AltV.Net.Data.BodyPart bodypart)
        {
            try
            {
                AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel)weapon;
                if (target != null && source != null)
                {
                    _Gamemodes_.Tactics.weapons.Combat.OnHittedEntity(source, target, weaponModel, bodypart);
                }
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
