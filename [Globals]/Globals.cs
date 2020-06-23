using AltV.Net;
using AltV.Net.Elements.Entities;
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
                    case (int)Preload.Gamemodes.Reallife:
                        ReallifePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Tactics:
                        TacticsPlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Zombies:
                        ZombiePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Race:
                        RacePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.SevenTowers:
                        SevenTowersPlayers.Remove(player);
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
                if (!(entity is Client player)) return;
                if (state) { _Gamemodes_.Reallife.Globals.Main.OnPlayerEnterColShapeModel(shape, player); }
                else { _Gamemodes_.Reallife.Globals.Main.OnPlayerExitColShapeModel(shape, player); }
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(Client player, Client killer, uint reason)
        {
            try
            {
                player.DespawnPlayer();
                switch (player.Gamemode)
                {
                    case (int)_Preload_.Preload.Gamemodes.Tactics:

                        if (killer == null) { killer = player.vnxGetElementData<Client>("VenoX:LastDamaged"); }
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
                    case (int)_Preload_.Preload.Gamemodes.Reallife:
                        {
                            if (killer == null || Functions.IstargetInSameLobby(player, killer))
                            {
                                _Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                            }
                        }
                        return;
                    default:
                        Core.Debug.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        Core.RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                        return;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnDeath", ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(Client player, Client killer)
        {
            try
            {
                Alt.Server.TriggerClientEvent(player, "Globals:ShowBloodScreen");
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
                _Gamemodes_.SevenTowers.Main.OnUpdate();
                _Gamemodes_.Zombie.Globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnUpdate", ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnected(Client player, string reason)
        {
            try
            {
                VenoXV.Globals.Main.RemovePlayerFromGamemodeList(player);
                string type = string.Empty;
                _Gamemodes_.Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                _Gamemodes_.Tactics.Globals.Main.OnPlayerDisconnect(player, type, reason);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerDisconnect", ex); }
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

        [ClientEvent("Discord:Auth")]
        public static void LoadDiscordInformations(Client player, bool IsOpen, string Id, string Name, string Avatar, string Discriminator)
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
