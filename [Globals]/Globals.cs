using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;

namespace VenoXV._Globals_
{
    public class Main : IScript
    {
        // Settings
        public static int REALLIFE_MAX_PLAYERS = 1000;
        public static int TACTICS_MAX_PLAYERS = 20;
        public static int RACE_MAX_PLAYERS = 5;
        public static int SEVENTOWERS_MAX_PLAYERS = 20;
        public static int ZOMBIES_MAX_PLAYERS = 200;

        // Const 
        public static List<VnXPlayer> AllPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ReallifePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> TacticsPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ZombiePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> RacePlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> SevenTowersPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> DerbyPlayers = new List<VnXPlayer>();
        public static List<VnXPlayer> ShooterPlayers = new List<VnXPlayer>();
        public static List<VehicleModel> AllVehicles = new List<VehicleModel>();
        public static List<VehicleModel> ReallifeVehicles = new List<VehicleModel>();

        // Tactics Dimensions : 
        public const int TACTICS_DIMENSION = 20;
        public const int TACTICS_DIMENSION_ALPHA = TACTICS_DIMENSION + 1;
        public const int TACTICS_DIMENSION_BETA = TACTICS_DIMENSION + 2;
        public const int TACTICS_DIMENSION_GAMMA = TACTICS_DIMENSION + 3;
        public const int TACTICS_DIMENSION_DELTA = TACTICS_DIMENSION + 4;

        // Reallife Dimensions : 
        public const int REALLIFE_DIMENSION = 10; // Standard
        public const int REALLIFE_DIMENSION_EN = REALLIFE_DIMENSION + (int)_Language_.Main.Languages.English;
        public const int REALLIFE_DIMENSION_RU = REALLIFE_DIMENSION + (int)_Language_.Main.Languages.Russian;
        public const int REALLIFE_DIMENSION_ES = REALLIFE_DIMENSION + (int)_Language_.Main.Languages.Spanish;
        public const int REALLIFE_DIMENSION_DE = REALLIFE_DIMENSION + (int)_Language_.Main.Languages.German;

        // Other GM Dimensions : 
        public const int RACE_DIMENSION = 0;
        public const int SEVENTOWERS_DIMENSION = 4;
        public const int ZOMBIES_DIMENSION = 5;
        public const int SHOOTER_DIMENSION = 6;

        // Timer : 
        public static Timer minuteTimer;
        public static Timer OnTickTimer;
        public static Timer ScoreboardTimer;

        public static void RemovePlayerFromGamemodeList(VnXPlayer player)
        {
            try
            {
                if (player == null) { Debug.OutputDebugString("Player got Removed?! "); return; }
                int Gamemode = player.Gamemode;
                if (AllPlayers.Contains(player)) AllPlayers.Remove(player);
                switch (Gamemode)
                {
                    case (int)Preload.Gamemodes.Reallife:
                        if (ReallifePlayers.Contains(player)) ReallifePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Tactics:
                        if (TacticsPlayers.Contains(player)) TacticsPlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Zombies:
                        if (ZombiePlayers.Contains(player)) ZombiePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.Race:
                        if (RacePlayers.Contains(player)) RacePlayers.Remove(player);
                        break;
                    case (int)Preload.Gamemodes.SevenTowers:
                        if (SevenTowersPlayers.Contains(player)) SevenTowersPlayers.Remove(player);
                        break;
                    default:
                        Debug.OutputDebugString(player.Username + " Gamemode got Removed without getting Current GM : " + player.Gamemode);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [Command("getuserinfo")]
        public static void GetUserInfo(VnXPlayer player, int ID)
        {
            switch (ID)
            {
                case (int)Preload.Gamemodes.Reallife:
                    Core.Debug.OutputDebugString(ID + " : " + ReallifePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Tactics:
                    Core.Debug.OutputDebugString(ID + " : " + TacticsPlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Zombies:
                    Core.Debug.OutputDebugString(ID + " : " + ZombiePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Race:
                    Core.Debug.OutputDebugString(ID + " : " + RacePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.SevenTowers:
                    Core.Debug.OutputDebugString(ID + " : " + SevenTowersPlayers.Count);
                    break;
                default:
                    Core.Debug.OutputDebugString(ID + " : " + 0);
                    break;
            }
        }


        public static void OnResourceStart()
        {
            try
            {
                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                Database.OnResourceStart();
                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                _Gamemodes_.Reallife.Globals.Main.OnResourceStart();
                _Gamemodes_.Tactics.Globals.Main.OnResourceStart();
                _Gamemodes_.SevenTowers.Main.OnResourceStart();
                _Language_.Main.OnResourceStart();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VenoX V." + Preload.CURRENT_VERSION + " Loaded!");
                foreach (ColShapeModel col in Sync.ColShapeList.ToList())
                {
                    Core.RageAPI.CreateMarker(0, col.Position, new System.Numerics.Vector3(col.Radius, col.Radius, col.Radius), new int[] { 175, 0, 0, 200 }, null, col.Dimension);
                }


                minuteTimer = new Timer(OnMinuteSpent, null, 60000, 60000); // Payday Generation und alles was nach einer Minute passiert!
                OnTickTimer = new Timer(VenoXV._Globals_.Main.OnUpdate, null, 50, 50); // Tick/OnUpdateEvent
                ScoreboardTimer = new Timer(_Globals_.Scoreboard.Scoreboard.Fill_Playerlist, null, 7000, 7000); // Scoreboard Updater.

                //VenoXV._Gamemodes_.Reallife.Woltlab.Program.CreateForumUser(null, "DimaIsABratan", "123321", "123321");
                VenoXV._Gamemodes_.Reallife.Woltlab.Program.OnResourceStart();

                /*Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Starting VenoX Bot...");
                //await _Discord_.Startup.RunAsync();
                Console.ForegroundColor = ConsoleColor.Green;
                _Discord_.Modules.Notify.SendUpdateLog("BETA apply is now possible! [DEV]! ",
                    "@everyone VenoX V." + Preload.CURRENT_VERSION + " BETA apply is now possible!\n" +
                    "Applies are only valid in the #📝beta-apply channel!\n\n" +
                    "```" +
                    "Nickname : YourNickname.\n" +
                    "Registered : Yes or No.\n" +
                    "Already made experience in alt:V : Yes or No.\n```",
                    Discord.Color.Blue, null);

                Console.WriteLine("Started VenoX Bot.");
                */

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        [AsyncScriptEvent(ScriptEventType.ColShape)]
        public static async Task OnColShape(ColShapeModel shape = null, IEntity entity = null, bool state = false)
        {
            try
            {
                await Task.Run(() =>
                {
                    Core.Debug.OutputDebugString("-- Entered ColShape --");
                    //await AltAsync.Do(() =>
                    //{
                    if (entity is not VnXPlayer player || shape is null || !shape.Exists) return;
                    if (state)
                    {
                        switch (player.Gamemode)
                        {
                            case (int)Preload.Gamemodes.Reallife:
                                _Gamemodes_.Reallife.Globals.Main.OnPlayerEnterColShapeModel(shape, player);
                                return;
                            case (int)Preload.Gamemodes.SevenTowers:
                                SevenTowers.globals.Main.OnColShapeHit(shape, player);
                                return;
                            case (int)Preload.Gamemodes.Race:
                                _Gamemodes_.Race.Lobby.Main.OnColshapeHit(shape, player);
                                return;
                        }
                    }
                    else _Gamemodes_.Reallife.Globals.Main.OnPlayerExitColShapeModel(shape, player);
                    //});
                });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [AsyncScriptEvent(ScriptEventType.PlayerDead)]
        public static async Task OnPlayerDeath(VnXPlayer player, IEntity entity, uint reason)
        {
            try
            {
                await AltAsync.Do(() =>
                {
                    player.DespawnPlayer();
                    VnXPlayer killer = null;
                    if (entity is VnXPlayer entity_k) killer = entity_k;
                    switch (player.Gamemode)
                    {
                        case (int)Preload.Gamemodes.Tactics:
                            if (killer is null)
                            {
                                VnXPlayer NewKiller = player.vnxGetElementData<VnXPlayer>("VenoX:LastDamaged");
                                if (NewKiller is null) killer = player;
                                else killer = NewKiller;
                            }
                            _Gamemodes_.Tactics.environment.Death.OnPlayerDeath(player, killer);
                            return;
                        case (int)Preload.Gamemodes.Reallife:
                            if (killer == null || Functions.IstargetInSameLobby(player, killer))
                            {
                                _Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                                _Gamemodes_.Reallife.gangwar.Allround.OnPlayerDeath(player, killer, reason);
                            }
                            return;
                        case (int)Preload.Gamemodes.SevenTowers:
                            _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                            return;
                        case (int)Preload.Gamemodes.Zombies:
                            _Gamemodes_.Zombie.World.Main.OnPlayerDeath(player);
                            return;
                        default:
                            Debug.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                            RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                            return;
                    }
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(VnXPlayer player, VnXPlayer killer, float Damage = 0)
        {
            try
            {
                player.vnxSetStreamSharedElementData("PLAYER_HEALTH", player.Health);
                player.vnxSetStreamSharedElementData("PLAYER_ARMOR", player.Armor);
                VenoX.TriggerClientEvent(killer, "Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamaged", killer);
                _Gamemodes_.Tactics.weapons.Combat.OnTacticsDamage(player, killer, Damage);
                _Gamemodes_.Reallife.gangwar.Allround.ProcessDamage(player, killer, Damage);
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("playerdmg", player?.Username + " hat " + killer?.Username + " angehitted!| DMG : " + Damage);
            }
            catch { }
        }

        [ServerEvent("GlobalSystems:OnVehicleSyncDamage")]
        public void OnPlayerVehicleDamage(VnXPlayer player, VehicleModel vehicle, float Damage = 0)
        {
            try
            {
                if (vehicle.Godmode) return;
                VenoX.TriggerClientEvent(player, "Globals:PlayHitsound");
                player.vnxSetElementData("VenoX:LastDamagedVehicle", vehicle);
                Debug.OutputDebugString(player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! DMG : " + Damage);
                string DriverName = "niemand";
                if (vehicle.Driver != null)
                {
                    VnXPlayer _Driver = (VnXPlayer)vehicle.Driver;
                    DriverName = _Driver.Username;
                }
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("vehdmg", player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! | Fahrer falls vorhanden : " + DriverName + " | DMG : " + Damage);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                _Preload_.Preload.OnUpdate();
                _Gamemodes_.Reallife.Globals.Main.OnUpdate();
                _Gamemodes_.Tactics.Globals.Main.OnUpdate();
                _Gamemodes_.Race.Globals.Main.OnUpdate();
                _Gamemodes_.SevenTowers.Main.OnUpdate();
                _Gamemodes_.Zombie.Globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public static void OnPlayerDisconnected(VnXPlayer player, string reason)
        {
            try
            {
                RemovePlayerFromGamemodeList(player);
                string type = string.Empty;
                _Gamemodes_.Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                _Gamemodes_.Tactics.Globals.Main.OnPlayerDisconnect(player, type, reason);
                _Gamemodes_.Zombie.Globals.Events.OnPlayerDisconnect(player);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(VnXPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try
            {
                source.vnxSetStreamSharedElementData("PLAYER_HEALTH", source.Health);
                source.vnxSetStreamSharedElementData("PLAYER_ARMOR", source.Armor);
                VenoX.TriggerClientEvent(source, "Globals:ShowBloodScreen");
            }
            catch { }
        }

        [ClientEvent("Discord:Auth")]
        public static void LoadDiscordInformations(VnXPlayer player, bool IsOpen, string Id, string Name, string Avatar, string Discriminator)
        {
            try
            {
                Debug.OutputDebugString(player.Username + " | UID " + player.UID + " | " + IsOpen + " | " + Id + " | " + Name + " | " + Avatar + " | " + Discriminator);
                player.Discord.ID = Id;
                player.Discord.IsOpen = IsOpen;
                player.Discord.Name = Name;
                player.Discord.Avatar = Avatar;
                player.Discord.Discriminator = Discriminator;
                Database.UpdateDiscordInformations(player.Username, player.Discord.ID, player.Discord.Avatar);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static async void GeneratePlayerPayday(VnXPlayer player)
        {
            try
            {
                int total = 0;
                int bank = player.Reallife.Bank;
                int playerRank = player.Reallife.FactionRank;
                int playerFaction = player.Reallife.Faction;
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                VnXPlayer VipL = Database.GetPlayerVIP(player, player.UID);

                if (player.Reallife.Wanteds > 0) { player.Reallife.Wanteds -= 1; }
                if (playerFaction > 0)
                {
                    foreach (FactionModel faction in _Gamemodes_.Reallife.Globals.Constants.FACTION_RANK_LIST)
                    {
                        if (faction.faction == playerFaction && faction.rank == playerRank)
                        {
                            total += faction.salary;
                            break;
                        }
                    }
                }
                string Gehalt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Gehalt");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Gehalt + " : " + RageAPI.GetHexColorcode(255, 255, 255) + total + " $");


                int gwboni = 0;
                /*foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.IDOwner == player.Reallife.Faction)
                    {
                        gwboni += 250;
                    }
                }*/

                total += gwboni;

                string GwBoni = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "GW - Boni");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + GwBoni + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +gwboni + " $");

                int bankInterest = (int)Math.Round(bank * 0.001);
                total += bankInterest;
                if (bankInterest > 0)
                {
                    string Bankzinsen = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Bankzinsen");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Bankzinsen + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +bankInterest + " $");
                }

                foreach (VehicleModel Vehicle in VenoXV._Globals_.Main.ReallifeVehicles.ToList())
                {
                    AltV.Net.Enums.VehicleModel IVehicleHass = (AltV.Net.Enums.VehicleModel)Vehicle.Model;
                    if (Vehicle.Owner == player.Username && Vehicle.NotSave != true)
                    {

                        int IVehicleTaxes = (int)Math.Round((int)Vehicle.Price * _Gamemodes_.Reallife.Globals.Constants.TAXES_IVehicle);
                        int IVehicleTaxes_ = 0;
                        if (VipL.Vip_BisZum > DateTime.Now)
                        {
                            string Paket = VipL.Vip_Paket;
                            if (Paket == "Silber")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_AUTOSTEUER_SILVER);
                            }
                            else if (Paket == "Gold")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_AUTOSTEUER_GOLD);
                            }
                            else if (Paket == "UltimateRed")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_AUTOSTEUER_ULTIMATERED);
                            }
                            else if (Paket == "Platin")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_AUTOSTEUER_PLATIN);
                            }
                            else if (Paket == "TOP DONATOR")
                            {
                                IVehicleTaxes_ = (int)Math.Round(IVehicleTaxes * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_AUTOSTEUER_TOPDONATOR);
                            }
                        }

                        int IVehicleId = Vehicle.ID;
                        //string VehicleModel vehicle = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_MODEL);
                        //string IVehiclePlate = Vehicle.Plate == string.Empty ? "LS " + (1000 + IVehicleId) : Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_PLATE);
                        //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " VIP Fahrzeugsteuer Abzug : " + RageAPI.GetHexColorcode(255, 255, 255) + +IVehicleTaxes_ + "$");
                        //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Fahrzeugsteuer : " + RageAPI.GetHexColorcode(255, 255, 255) + VehicleModel + " (" + IVehiclePlate + "): - " + IVehicleTaxes + " $");
                        total -= IVehicleTaxes;
                        total += IVehicleTaxes_;
                    }
                }
                if (House.houseList != null)
                {
                    // House taxes
                    foreach (HouseModel house in House.houseList)
                    {
                        if (house.owner == player.Username)
                        {
                            int houseTaxes = (int)Math.Round((int)house.price * _Gamemodes_.Reallife.Globals.Constants.TAXES_HOUSE);
                            string Immobiliensteuer = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Immobiliensteuer : ");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Immobiliensteuer + " : " + RageAPI.GetHexColorcode(255, 255, 255) + house.name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if (house.id == player.Reallife.HouseRent)
                        {
                            string Miete = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Miete");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + Miete + " : " + house.name + " : " + RageAPI.GetHexColorcode(255, 255, 255) + +house.rental + "$");
                            Database.TransferMoneyToPlayer(house.owner, house.rental);
                            total -= house.rental;
                        }
                    }
                }
                int VIPBONI = 0;
                if (VipL.Vip_BisZum > DateTime.Now)
                {
                    string Paket = VipL.Vip_Paket;
                    if (Paket == "Bronze")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_BRONZE);
                    }
                    else if (Paket == "Silber")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_SILBER);
                    }
                    else if (Paket == "Gold")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_GOLD);
                    }
                    else if (Paket == "UltimateRed")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_RED);
                    }
                    else if (Paket == "Platin")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_PLATIN);
                    }
                    else if (Paket == "TOP DONATOR")
                    {
                        VIPBONI = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VIP_BONI_TOP);
                    }
                }
                if (VIPBONI > 0)
                {
                    total += VIPBONI;
                }
                else if (VIPBONI < 100)
                {
                    total += 100;
                }
                string VIP = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "VIP Bonus");
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " " + VIP + ": " + RageAPI.GetHexColorcode(255, 255, 255) + VIPBONI + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendChatMessage(_Gamemodes_.Reallife.Globals.Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                string EinnahmenGesamt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Einnahmen insgesamt");
                player.SendChatMessage(_Gamemodes_.Reallife.Globals.Constants.Rgba_HELP + RageAPI.GetHexColorcode(0, 200, 255) + " " + EinnahmenGesamt + " :" + RageAPI.GetHexColorcode(255, 255, 255) + +total + " $");

                if (total < 0)
                {
                    player.Reallife.Bank -= Math.Abs(total);
                }
                else
                {
                    player.Reallife.Bank += Math.Abs(total);

                }
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }
        public static void OnMinuteSpent(object unused)
        {
            try
            {

                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 55) RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in 5 Minuten!");
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59) RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Server neustart in einer Minute!");
                foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList())
                {
                    int played = player.Played;
                    if (played > 0 && played % 60 == 0) GeneratePlayerPayday(player);
                    player.Played += 1;
                    //SyncDatabaseItems(player);
                    switch (player.Gamemode)
                    {
                        case (int)_Preload_.Preload.Gamemodes.Reallife:
                            VenoXV._Gamemodes_.Reallife.Globals.Main.OnMinuteSpentReallifeGM(player);
                            break;
                    }

                    AccountModel accClass = Register.AccountList.ToList().FirstOrDefault(x => x.UID == player.UID);
                    string langpair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                    if (accClass is not null && accClass.Language != langpair)
                        Database.UpdatePlayerLanguage(accClass.UID, langpair);

                    SavePlayerDatas(player);
                    Sync.SyncWeather(player);
                    Sync.SyncDateTime(player);
                }
                _Gamemodes_.Reallife.Globals.Main.OnMinuteSpend();
                SaveVehicleDatas();
                Sync.DeleteVehicleThreadSafe();
                Sync.DeleteColShapesThreadSafe();
                Core.Debug.OutputDebugStringColored("OnMinuteSpend = [OK]", ConsoleColor.Green);
                //Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpend = OK!");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void SavePlayerDatas(VnXPlayer player)
        {
            try
            {
                Database.SaveCharacterInformation(player);
            }
            catch { }
        }

        public static void SaveVehicleDatas()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                foreach (VehicleModel Vehicle in VenoXV._Globals_.Main.ReallifeVehicles.ToList())
                {
                    if (Vehicle.Owner != null)
                    {
                        if (Vehicle.IsTestVehicle != true && Vehicle.Faction == 0 && Vehicle.NotSave != false && Vehicle.Dimension == 0)
                        {
                            // Add IVehicle into the list
                            IVehicleList.Add(Vehicle);
                        }
                    }
                }
                Database.SaveAllIVehicles(IVehicleList);
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }
        //
    }
}
