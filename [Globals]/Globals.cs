using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.gangwar;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._Gamemodes_.Tactics.environment;
using VenoXV._Gamemodes_.Tactics.weapons;
using VenoXV._Gamemodes_.Zombie.Globals;
using VenoXV._Preload_;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.gangwar;

namespace VenoXV._Globals_
{
    public class Main : IScript
    {
        // Settings
        public static int ReallifeMaxPlayers = 1000;
        public static int TacticsMaxPlayers = 20;
        public static int RaceMaxPlayers = 5;
        public static int SeventowersMaxPlayers = 20;
        public static int ZombiesMaxPlayers = 200;

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
        public const int TacticsDimension = 20;
        public const int TacticsDimensionAlpha = TacticsDimension + 1;
        public const int TacticsDimensionBeta = TacticsDimension + 2;
        public const int TacticsDimensionGamma = TacticsDimension + 3;
        public const int TacticsDimensionDelta = TacticsDimension + 4;

        // Reallife Dimensions : 
        public const int ReallifeDimension = 10; // Standard
        public const int ReallifeDimensionEn = ReallifeDimension + (int)_Language_.Main.Languages.English;
        public const int ReallifeDimensionRu = ReallifeDimension + (int)_Language_.Main.Languages.Russian;
        public const int ReallifeDimensionEs = ReallifeDimension + (int)_Language_.Main.Languages.Spanish;
        public const int ReallifeDimensionDe = ReallifeDimension + (int)_Language_.Main.Languages.German;

        // Other GM Dimensions : 
        public const int RaceDimension = 0;
        public const int SeventowersDimension = 4;
        public const int ZombiesDimension = 5;
        public const int ShooterDimension = 6;

        // Timer : 
        public static Timer MinuteTimer;
        public static Timer OnTickTimer;
        public static Timer ScoreboardTimer;

        public static void RemovePlayerFromGamemodeList(VnXPlayer player)
        {
            try
            {
                if (player == null) { Debug.OutputDebugString("Player got Removed?! "); return; }
                int gamemode = player.Gamemode;
                if (AllPlayers.Contains(player)) AllPlayers.Remove(player);
                switch (gamemode)
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [Command("getuserinfo")]
        public static void GetUserInfo(VnXPlayer player, int id)
        {
            switch (id)
            {
                case (int)Preload.Gamemodes.Reallife:
                    Debug.OutputDebugString(id + " : " + ReallifePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Tactics:
                    Debug.OutputDebugString(id + " : " + TacticsPlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Zombies:
                    Debug.OutputDebugString(id + " : " + ZombiePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Race:
                    Debug.OutputDebugString(id + " : " + RacePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.SevenTowers:
                    Debug.OutputDebugString(id + " : " + SevenTowersPlayers.Count);
                    break;
                default:
                    Debug.OutputDebugString(id + " : " + 0);
                    break;
            }
        }


        public static void OnResourceStart()
        {
            try
            {
                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                Database.Database.OnResourceStart();
                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                _Gamemodes_.Reallife.Globals.Main.OnResourceStart();
                _Gamemodes_.Tactics.Globals.Main.OnResourceStart();
                _Gamemodes_.SevenTowers.Main.OnResourceStart();
                _Language_.Main.OnResourceStart();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VenoX V." + Preload.CurrentVersion + " Loaded!");
                foreach (ColShapeModel col in Sync.ColShapeList.ToList())
                {
                    RageApi.CreateMarker(0, col.Position, new Vector3(col.Radius, col.Radius, col.Radius), new[] { 175, 0, 0, 200 }, null, col.Dimension);
                }


                MinuteTimer = new Timer(OnMinuteSpent, null, 60000, 60000); // Payday Generation und alles was nach einer Minute passiert!
                OnTickTimer = new Timer(OnUpdate, null, 50, 50); // Tick/OnUpdateEvent
                ScoreboardTimer = new Timer(Scoreboard.Scoreboard.Fill_Playerlist, null, 7000, 7000); // Scoreboard Updater.

                //VenoXV._Gamemodes_.Reallife.Woltlab.Program.CreateForumUser(null, "DimaIsABratan", "123321", "123321");
                Program.OnResourceStart();

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
                    Debug.OutputDebugString("-- Entered ColShape --");
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
                    if (entity is VnXPlayer entityK) killer = entityK;
                    switch (player.Gamemode)
                    {
                        case (int)Preload.Gamemodes.Tactics:
                            if (killer is null)
                            {
                                VnXPlayer newKiller = player.VnxGetElementData<VnXPlayer>("VenoX:LastDamaged");
                                if (newKiller is null) killer = player;
                                else killer = newKiller;
                            }
                            Death.OnPlayerDeath(player, killer);
                            return;
                        case (int)Preload.Gamemodes.Reallife:
                            if (killer == null || Functions.IstargetInSameLobby(player, killer))
                            {
                                _Gamemodes_.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                                Allround.OnPlayerDeath(player, killer, reason);
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
                            RageApi.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                            return;
                    }
                });
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(VnXPlayer player, VnXPlayer killer, float damage = 0)
        {
            try
            {
                player.VnxSetStreamSharedElementData("PLAYER_HEALTH", player.Health);
                player.VnxSetStreamSharedElementData("PLAYER_ARMOR", player.Armor);
                VenoX.TriggerClientEvent(killer, "Globals:PlayHitsound");
                player.VnxSetElementData("VenoX:LastDamaged", killer);
                Combat.OnTacticsDamage(player, killer, damage);
                Allround.ProcessDamage(player, killer, damage);
                Logfile.WriteLogs("playerdmg", player?.Username + " hat " + killer?.Username + " angehitted!| DMG : " + damage);
            }
            catch { }
        }

        [ServerEvent("GlobalSystems:OnVehicleSyncDamage")]
        public void OnPlayerVehicleDamage(VnXPlayer player, VehicleModel vehicle, float damage = 0)
        {
            try
            {
                if (vehicle.Godmode) return;
                VenoX.TriggerClientEvent(player, "Globals:PlayHitsound");
                player.VnxSetElementData("VenoX:LastDamagedVehicle", vehicle);
                Debug.OutputDebugString(player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! DMG : " + damage);
                string driverName = "niemand";
                if (vehicle.Driver != null)
                {
                    VnXPlayer driver = (VnXPlayer)vehicle.Driver;
                    driverName = driver.Username;
                }
                Logfile.WriteLogs("vehdmg", player.Username + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! | Fahrer falls vorhanden : " + driverName + " | DMG : " + damage);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                Preload.OnUpdate();
                _Gamemodes_.Reallife.Globals.Main.OnUpdate();
                _Gamemodes_.Tactics.Globals.Main.OnUpdate();
                _Gamemodes_.Race.Globals.Main.OnUpdate();
                _Gamemodes_.SevenTowers.Main.OnUpdate();
                _Gamemodes_.Zombie.Globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
                Events.OnPlayerDisconnect(player);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(VnXPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try
            {
                source.VnxSetStreamSharedElementData("PLAYER_HEALTH", source.Health);
                source.VnxSetStreamSharedElementData("PLAYER_ARMOR", source.Armor);
                VenoX.TriggerClientEvent(source, "Globals:ShowBloodScreen");
            }
            catch { }
        }

        [VenoXRemoteEvent("Discord:Auth")]
        public static void LoadDiscordInformations(VnXPlayer player, bool isOpen, string id, string name, string avatar, string discriminator)
        {
            try
            {
                Debug.OutputDebugString(player.Username + " | UID " + player.UID + " | " + isOpen + " | " + id + " | " + name + " | " + avatar + " | " + discriminator);
                player.Discord.Id = id;
                player.Discord.IsOpen = isOpen;
                player.Discord.Name = name;
                player.Discord.Avatar = avatar;
                player.Discord.Discriminator = discriminator;
                Database.Database.UpdateDiscordInformations(player.Username, player.Discord.Id, player.Discord.Avatar);
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
                player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                VnXPlayer vipL = Database.Database.GetPlayerVip(player, player.UID);

                if (player.Reallife.WantedStars > 0) { player.Reallife.WantedStars -= 1; }
                if (playerFaction > 0)
                {
                    foreach (FactionModel faction in _Gamemodes_.Reallife.Globals.Constants.FactionRankList)
                    {
                        if (faction.Faction == playerFaction && faction.Rank == playerRank)
                        {
                            total += faction.Salary;
                            break;
                        }
                    }
                }
                string gehalt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Gehalt");
                player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + gehalt + " : " + RageApi.GetHexColorcode(255, 255, 255) + total + " $");


                /*int gwBonus = 0;
                foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.IDOwner == player.Reallife.Faction)
                    {
                        gwBonus += 250;
                    }
                }

                total += gwBonus;

                string gwBonusText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "GW - Boni");
                player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + gwBonusText + " : " + RageApi.GetHexColorcode(255, 255, 255) + gwBonus + " $");
                */
                int bankInterest = (int)Math.Round(bank * 0.001);
                total += bankInterest;
                if (bankInterest > 0)
                {
                    string bankinterest = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Bankzinsen");
                    player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + bankinterest + " : " + RageApi.GetHexColorcode(255, 255, 255) + +bankInterest + " $");
                }

                foreach (VehicleModel vehicle in ReallifeVehicles.ToList())
                {
                    if (vehicle.Owner != player.Username || vehicle.NotSave == true) continue;
                    int vehicleTaxes = (int)Math.Round(vehicle.Price * _Gamemodes_.Reallife.Globals.Constants.TaxesIVehicle);
                    if (vipL.VipTill > DateTime.Now)
                    {
                        string paket = vipL.VipPaket;
                        vehicleTaxes = paket switch
                        {
                            "Silber" => (int) Math.Round(vehicleTaxes *
                                                         _Gamemodes_.Reallife.Globals.Constants
                                                             .VipBoniAutosteuerSilver),
                            "Gold" => (int) Math.Round(vehicleTaxes *
                                                       _Gamemodes_.Reallife.Globals.Constants
                                                           .VipBoniAutosteuerGold),
                            "UltimateRed" => (int) Math.Round(vehicleTaxes *
                                                              _Gamemodes_.Reallife.Globals.Constants
                                                                  .VipBoniAutosteuerUltimatered),
                            "Platin" => (int) Math.Round(vehicleTaxes *
                                                         _Gamemodes_.Reallife.Globals.Constants
                                                             .VipBoniAutosteuerPlatin),
                            "TOP DONATOR" => (int) Math.Round(vehicleTaxes *
                                                              _Gamemodes_.Reallife.Globals.Constants
                                                                  .VipBoniAutosteuerTopdonator),
                            _ => vehicleTaxes
                        };
                    }

                    int vehicleId = vehicle.DatabaseId;
                    //string VehicleModel vehicle = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_MODEL);
                    //string IVehiclePlate = Vehicle.Plate == string.Empty ? "LS " + (1000 + IVehicleId) : Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_PLATE);
                    //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " VIP Fahrzeugsteuer Abzug : " + RageAPI.GetHexColorcode(255, 255, 255) + +IVehicleTaxes_ + "$");
                    //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Fahrzeugsteuer : " + RageAPI.GetHexColorcode(255, 255, 255) + VehicleModel + " (" + IVehiclePlate + "): - " + IVehicleTaxes + " $");
                    total -= vehicleTaxes;
                    total += vehicleTaxes;
                }
                if (House.HouseList != null)
                {
                    // House taxes
                    foreach (HouseModel house in House.HouseList)
                    {
                        if (house.Owner == player.Username)
                        {
                            int houseTaxes = (int)Math.Round(house.Price * _Gamemodes_.Reallife.Globals.Constants.TaxesHouse);
                            string immobiliensteuer = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Immobiliensteuer : ");
                            player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + immobiliensteuer + " : " + RageApi.GetHexColorcode(255, 255, 255) + house.Name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if (house.Id == player.Reallife.HouseRent)
                        {
                            string miete = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Miete");
                            player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + miete + " : " + house.Name + " : " + RageApi.GetHexColorcode(255, 255, 255) + +house.Rental + "$");
                            Database.Database.TransferMoneyToPlayer(house.Owner, house.Rental);
                            total -= house.Rental;
                        }
                    }
                }
                int vipboni = 0;
                if (vipL.VipTill > DateTime.Now)
                {
                    string paket = vipL.VipPaket;
                    switch (paket)
                    {
                        case "Bronze":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniBronze);
                            break;
                        case "Silber":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniSilber);
                            break;
                        case "Gold":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniGold);
                            break;
                        case "UltimateRed":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniRed);
                            break;
                        case "Platin":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniPlatin);
                            break;
                        case "TOP DONATOR":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.Globals.Constants.VipBoniTop);
                            break;
                    }
                }
                switch (vipboni)
                {
                    case > 0:
                        total += vipboni;
                        break;
                    case < 100:
                        total += 100;
                        break;
                }
                string vip = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "VIP Bonus");
                player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + vip + ": " + RageApi.GetHexColorcode(255, 255, 255) + vipboni + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendChatMessage(_Gamemodes_.Reallife.Globals.Constants.RgbaHelp + RageApi.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                string einnahmenGesamt = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Einnahmen insgesamt");
                player.SendChatMessage(_Gamemodes_.Reallife.Globals.Constants.RgbaHelp + RageApi.GetHexColorcode(0, 200, 255) + " " + einnahmenGesamt + " :" + RageApi.GetHexColorcode(255, 255, 255) + +total + " $");

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
                Debug.CatchExceptions(ex);
            }
        }
        public static void OnMinuteSpent(object unused)
        {
            try
            {

                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 55) RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Server neustart in 5 Minuten!");
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59) RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Server neustart in einer Minute!");
                foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList())
                {
                    int played = player.Played;
                    if (played > 0 && played % 60 == 0) GeneratePlayerPayday(player);
                    player.Played += 1;
                    //SyncDatabaseItems(player);
                    switch (player.Gamemode)
                    {
                        case (int)Preload.Gamemodes.Reallife:
                            _Gamemodes_.Reallife.Globals.Main.OnMinuteSpentReallifeGM(player);
                            break;
                    }

                    AccountModel accClass = Register.AccountList.ToList().FirstOrDefault(x => x.Uid == player.UID);
                    string langpair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                    if (accClass is not null && accClass.Language != langpair)
                        Database.Database.UpdatePlayerLanguage(accClass.Uid, langpair);

                    SavePlayerDatas(player);
                    Sync.SyncWeather(player);
                    Sync.SyncDateTime(player);
                }
                _Gamemodes_.Reallife.Globals.Main.OnMinuteSpend();
                SaveVehicleDatas();
                Sync.DeleteVehicleThreadSafe();
                Sync.DeleteColShapesThreadSafe();
                Debug.OutputDebugStringColored("OnMinuteSpend = [OK]", ConsoleColor.Green);
                //Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpend = OK!");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void SavePlayerDatas(VnXPlayer player)
        {
            try
            {
                Database.Database.SaveCharacterInformation(player);
            }
            catch { }
        }

        public static void SaveVehicleDatas()
        {
            try
            {
                List<VehicleModel> vehicleList = new List<VehicleModel>();

                foreach (VehicleModel vehicle in ReallifeVehicles.ToList())
                {
                    if (vehicle.Owner != null)
                    {
                        if (vehicle.IsTestVehicle != true && vehicle.Faction == 0 && vehicle.NotSave && vehicle.Dimension == 0)
                        {
                            // Add IVehicle into the list
                            vehicleList.Add(vehicle);
                        }
                    }
                }
                Database.Database.SaveAllIVehicles(vehicleList);
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }
        //
    }
}
