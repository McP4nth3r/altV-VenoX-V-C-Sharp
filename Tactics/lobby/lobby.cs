using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.Core;
using VenoXV.Tactics.globals;
namespace VenoXV.Tactics.Lobby
{
    public class Main : IScript
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // SETTINGS

        public static int TACTIC_ROUND_MINUTE = 3; // Zeit in Minuten.
        public static int TACTIC_ROUND_START_AFTER_LOADING = 5; // Zeit in Sekunden.
        public static int TACTIC_ROUND_JOINTIME = 5; // Zeit in Sekunden. < -- Die zeit zum Joinen nach Rundenstart ( 5 Sek. Standart ).
        public static int TACTIC_MIN_PLAYER_TEAM = 1; // WV Spieler pro Team minimum notwendig sind.


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Saved Datas.

        //public IPlayer[] TACTICS_PLAYERS_IN_LOBBY { get; set; }
        public static bool TACTICMANAGER__ROUND_ISRUNNING;
        public static DateTime TACTICMANAGER_ROUND_CURRENTTIME;
        public static DateTime TACTICMANAGER_ROUND_TIMETOJOIN;
        public static DateTime TACTICMANAGER_ROUND_START_AFTER_LOADING;
        public static bool TACTICMANAGER_ROUND_JOIN_ALLOWED;
        public static int MEMBER_COUNT_COPS = 0;
        public static int MEMBER_COUNT_BFAC = 0;       
        public static int MEMBER_COUNT_MAX_COPS = 0;
        public static int MEMBER_COUNT_MAX_BFAC = 0;
        public static int RandomRound = 0;


        public static List<Position> TACTICS_TEAM_COPS = new List<Position> // Good Factions :3
        {
            new Position(3052.326f, -4654.027f, 15.26142f),
            new Position(3045.766f, -4655.521f, 15.2623f),
            new Position(3036.987f, -4658.588f, 15.26142f),
            new Position(3029.982f, -4657.58f, 15.26163f),
        };

        public static List<Position> TACTICS_TEAM_BFAC = new List<Position> // Bad Factions
        {
            new Position(3077.715f, -4795.332f, 15.2613f),
            new Position(3090.292f, -4791.002f, 15.26161f),
            new Position(3097.125f, -4786.874f, 15.26162f),
            new Position(3090.783f, -4792.346f, 15.26162f),
        };
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void InitializePlayerData(IPlayer player)
        {
            player.SetData(EntityData.PLAYER_JOINED_TACTICS, true);
            player.SetData(EntityData.PLAYER_DAMAGE_DONE, 0);
            player.SetData(EntityData.PLAYER_KILLED_PLAYERS, 0);
            player.SetData(EntityData.PLAYER_LEFT_ROUND, false);
            player.SetData(EntityData.PLAYER_DISCONNECTED_ROUND, false);
            player.SetData(EntityData.PLAYER_IS_DEAD, false);
            player.SetData(EntityData.PLAYER_SPAWNED_TACTICS, false);
            player.SetData(EntityData.PLAYER_CURRENT_TEAM, "NULL");
            player.Emit("LoadTacticUI");
        }

        public static bool IsTacticRoundRunning()
        {
            // Sendet dem Spieler die Antwort ob eine Tactic Lobby am laufen ist.
            if (TACTICMANAGER__ROUND_ISRUNNING) { return true; }
            else { return false; }
        }

        public static void CreateRandomRound()
        {
            try
            {
                Random random = new Random();
                RandomRound = random.Next(0, 10);
            }
            catch { }
        }

        public static void GivePlayerTacticWeapons(IPlayer player)
        {
            try
            {
                player.RemoveAllWeapons();
                if (RandomRound == 0)
                {
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.HeavyRevolver, 200);
                    player.SendChatMessage("[Tactics] : Only Revolver Modus!");
                }
                else if (RandomRound == 1)
                {
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 200);
                    player.SendChatMessage( "[Tactics] : Only SMG Modus!");
                }                
                else if (RandomRound == 3)
                {
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 200);
                    player.SendChatMessage( "[Tactics] : Only Shotgun Modus!");
                }                
                else if (RandomRound == 4)
                {
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SniperRifle, 200);
                    player.SendChatMessage( "[Tactics] : Only Sniper Modus!");
                }
                else
                {
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.HeavyRevolver, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CombatPDW, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AssaultRifle, 200);
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Musket, 200);
                }
            }
            catch { }
        }

        public static void SpawnPlayerOnPoint(IPlayer player, string Fac)
        {
            try
            {
                Random random = new Random();
                int randomzahl = random.Next(0, 3);
                if (Fac == EntityData.BFAC_NAME)
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                    Position Spawnpunkt = TACTICS_TEAM_BFAC[randomzahl];
                    player.Spawn(Spawnpunkt); player.Model = Alt.Hash("u_m_y_abner");
                    player.Dimension = 0;
                    player.SetData(EntityData.PLAYER_SPAWNED_TACTICS, true);
                    player.SetData(EntityData.PLAYER_CURRENT_TEAM, EntityData.BFAC_NAME);
                    GivePlayerTacticWeapons(player);
                    player.Health = 200;
                    player.Armor = 100;
                }
                else if (Fac == EntityData.COPS_NAME)
                {
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                    Position Spawnpunkt = TACTICS_TEAM_COPS[randomzahl];
                    player.Spawn(Spawnpunkt); player.Model = Alt.Hash("s_f_y_cop_01");
                    player.Dimension = 0;
                    player.SetData(EntityData.PLAYER_SPAWNED_TACTICS, true);
                    player.SetData(EntityData.PLAYER_CURRENT_TEAM, EntityData.COPS_NAME);
                    GivePlayerTacticWeapons(player);
                    player.Health = 200;
                    player.Armor = 100;
                }
                //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                Reallife. dxLibary.VnX.SetElementFrozen(player, false);
            }
            catch { }
        }


        public static void PutPlayerInTeam(IPlayer player)
        {
            try
            {
                // Wir Checken ob bereits eine Runde bereits läuft, falls nein dann setzen wir den Status auf True.
                if (!IsTacticRoundRunning()) { TACTICMANAGER__ROUND_ISRUNNING = true; }

                if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.COPS_NAME)
                {
                    if (MEMBER_COUNT_BFAC <= MEMBER_COUNT_COPS) // Wenn Böse Fraktionisten in der Unterzahl sind, dann Spieler in die BFAC tun.
                    {
                        MEMBER_COUNT_BFAC += 1;
                        MEMBER_COUNT_MAX_BFAC += 1;
                        InitializePlayerData(player);
                        SpawnPlayerOnPoint(player, EntityData.BFAC_NAME);
                    }
                    else
                    {
                        MEMBER_COUNT_COPS += 1;
                        MEMBER_COUNT_MAX_COPS += 1;
                        InitializePlayerData(player);
                        SpawnPlayerOnPoint(player, EntityData.COPS_NAME);
                    }
                }                
                else
                {
                    if (MEMBER_COUNT_COPS <= MEMBER_COUNT_BFAC) // Wenn Böse Fraktionisten in der Unterzahl sind, dann Spieler in die BFAC tun.
                    {
                        MEMBER_COUNT_COPS += 1;
                        MEMBER_COUNT_MAX_COPS += 1;
                        InitializePlayerData(player);
                        SpawnPlayerOnPoint(player, EntityData.COPS_NAME);
                    }
                    else
                    {
                        MEMBER_COUNT_BFAC += 1;
                        MEMBER_COUNT_MAX_BFAC += 1;
                        InitializePlayerData(player);
                        SpawnPlayerOnPoint(player, EntityData.BFAC_NAME);
                    }
                }
            }
            catch { }
        }


        public static void StartNewTacticRound()
        {
            try
            {
                TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now.AddMinutes(TACTIC_ROUND_MINUTE);
                TACTICMANAGER_ROUND_TIMETOJOIN = DateTime.Now.AddSeconds(TACTIC_ROUND_JOINTIME);
                MEMBER_COUNT_BFAC = 0;
                MEMBER_COUNT_COPS = 0;
                MEMBER_COUNT_MAX_BFAC = 0;
                MEMBER_COUNT_MAX_COPS = 0;
                CreateRandomRound();
                // To Do : wenn runde gestartet ist = nicht machen !
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        AntiCheat_Allround.SetTimeOutHealth(players, 3000);
                        players.SendChatMessage(RageAPI.GetHexColorcode(200,200,200) +"[VenoX - Tactics] : Eine neue Runde startet.");
                        players.Emit("LoadTacticUI");
                        PutPlayerInTeam(players);
                        SyncTime();
                        SyncPlayerStats();
                        SyncStats();
                    }
                }
            }
            catch { }
        }

        public static void OnPlayerDisconnect(IPlayer player, string type, string reason)
        {
            try
            {
                player.SetData(Reallife.Globals.EntityData.PLAYER_TACTIC_TODE, player.vnxGetElementData<int>(Reallife.Globals.EntityData.PLAYER_TACTIC_TODE) - 1);
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS && player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        players.SendChatMessage( RageAPI.GetHexColorcode(200,0,0) +player.Name + " ist Disconnected!");
                    }
                }
                if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.BFAC_NAME)
                {
                    Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                    if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                    {
                        Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
                        Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                        Lobby.Main.SyncEndTacticRound("Das L.S.P.D gewinnt die Runde.");
                        return;
                    }
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.COPS_NAME)
                {
                    Lobby.Main.MEMBER_COUNT_COPS -= 1;
                    if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                    {
                        Lobby.Main.TACTICMANAGER_ROUND_START_AFTER_LOADING = DateTime.Now.AddSeconds(Lobby.Main.TACTIC_ROUND_START_AFTER_LOADING);
                        Lobby.Main.TACTICMANAGER_ROUND_CURRENTTIME = DateTime.Now;
                        Lobby.Main.SyncEndTacticRound("Die Grove Street gewinnt die Runde.");
                        return;
                    }
                }
                Lobby.Main.SyncStats();
                Lobby.Main.SyncPlayerStats();
            }
            catch { }
        }



        public static void OnSelectedTacticsGM(IPlayer player)
        {
            try
            {
                AntiCheat_Allround.SetTimeOutHealth(player, 3000);
                AntiCheat_Allround.StartTimerTeleport(player);
                player.Emit("Tactics:LoadHUD");
                if (TACTICMANAGER__ROUND_ISRUNNING && TACTICMANAGER_ROUND_TIMETOJOIN < DateTime.Now)
                {
                    if (MEMBER_COUNT_MAX_BFAC == 0 || MEMBER_COUNT_MAX_COPS == 0)
                    {
                        player.Spawn(player.Position);
                        StartNewTacticRound();
                    }
                    else
                    {
                        // To Do : Cam event erstellen.
                        player.Spawn(new Position(player.Position.X, player.Position.Y, player.Position.Z + 70));
                        Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                        player.RemoveAllWeapons();
                        player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Es läuft bereits eine Runde... Bitte gedulde dich ein wenig...");
                    }
                }
                else
                {
                    StartNewTacticRound();
                }
            }
            catch { }
        }

        public static void SyncTime()
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        double leftTime = (DateTime.Now - TACTICMANAGER_ROUND_CURRENTTIME).TotalSeconds * -1;
                        players.Emit("Tactics:LoadTimer", (int)leftTime);
                    }
                }
            }
            catch { }
        }

        public static void SyncStats()
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        players.Emit("Tactics:UpdateMemberInfo", MEMBER_COUNT_MAX_COPS, MEMBER_COUNT_COPS, MEMBER_COUNT_MAX_BFAC, MEMBER_COUNT_BFAC);
                    }
                }
            }
            catch { }
        }

        public static void SyncPlayerStats()
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        players.Emit("Tactics:UpdatePlayerStats", players.vnxGetElementData<int>(EntityData.PLAYER_DAMAGE_DONE), players.vnxGetElementData<int>(EntityData.PLAYER_KILLED_PLAYERS));
                    }
                }
            }
            catch { }
        }
        public static void SyncEndTacticRound(string text)
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        players.Emit("Tactics:OnTacticEndRound", text);
                    }
                }
            }
            catch { }
        }


        public static void OnUpdate()
        {
            try
            {
                if (IsTacticRoundRunning() && TACTICMANAGER_ROUND_CURRENTTIME <= DateTime.Now)
                {
                    if (TACTICMANAGER_ROUND_START_AFTER_LOADING <= DateTime.Now)
                    {
                        TACTICMANAGER__ROUND_ISRUNNING = false;
                        // Reallife.Core.RageAPI.SendChatMessageToAll("RUNDE BEENDET.");
                        StartNewTacticRound();
                    }
                }
            }
            catch { }
        }
    }
}
