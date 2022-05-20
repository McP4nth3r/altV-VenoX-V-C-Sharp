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
using VenoX.Core._Gamemodes_.Reallife.gangwar;
using VenoX.Core._Gamemodes_.Reallife.house;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Gamemodes_.Tactics.environment;
using VenoX.Core._Gamemodes_.Tactics.weapons;
using VenoX.Core._Gamemodes_.Zombie.globals;
using VenoX.Core._Preload_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.Sync;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Data.Database.Models;
using VenoX.Debug;

namespace VenoX.Core._Globals_
{
    public class Initialize : IScript
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
        public const int ReallifeDimensionEn = ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.English;
        public const int ReallifeDimensionRu = ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.Russian;
        public const int ReallifeDimensionEs = ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.Spanish;
        public const int ReallifeDimensionDe = ReallifeDimension + (int)global::VenoX.Core._Language_.Constants.Languages.German;

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
                if (player == null) { ConsoleHandling.OutputDebugString("Player got Removed?! "); return; }
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
                        ConsoleHandling.OutputDebugString(player.CharacterUsername + " Gamemode got Removed without getting Current GM : " + player.Gamemode);
                        break;
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [Command("getuserinfo")]
        public static void GetUserInfo(VnXPlayer player, int id)
        {
            switch (id)
            {
                case (int)Preload.Gamemodes.Reallife:
                    ConsoleHandling.OutputDebugString(id + " : " + ReallifePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Tactics:
                    ConsoleHandling.OutputDebugString(id + " : " + TacticsPlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Zombies:
                    ConsoleHandling.OutputDebugString(id + " : " + ZombiePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.Race:
                    ConsoleHandling.OutputDebugString(id + " : " + RacePlayers.Count);
                    break;
                case (int)Preload.Gamemodes.SevenTowers:
                    ConsoleHandling.OutputDebugString(id + " : " + SevenTowersPlayers.Count);
                    break;
                default:
                    ConsoleHandling.OutputDebugString(id + " : " + 0);
                    break;
            }
        }

        private static readonly List<string> LanguagePaths = new()
        {
            Alt.Server.Resource.Path + "/Languages/language-en.json",
            Alt.Server.Resource.Path + "/Languages/language-fr.json",
            Alt.Server.Resource.Path + "/Languages/language-pl.json",
            Alt.Server.Resource.Path + "/Languages/language-es.json",
            Alt.Server.Resource.Path + "/Languages/language-tr.json",
            Alt.Server.Resource.Path + "/Languages/language-ru.json",
            Alt.Server.Resource.Path + "/Languages/language-sv.json",
            Alt.Server.Resource.Path + "/Languages/language-sr.json",
            Alt.Server.Resource.Path + "/Languages/language-zh-cn.json",
            Alt.Server.Resource.Path + "/Languages/language-fa.json",
            Alt.Server.Resource.Path + "/Languages/language-it.json"
        };

        public static void OnResourceStart()
        {
            try
            {
                /*
                
                Debug.OutputDebugStringColored("[INFO @ READING LANGUAGE ENUM '"+ LanguagePaths.Count+"' - ENUM - COUNTED!]", ConsoleColor.Green);

                foreach(string path in LanguagePaths)
                    if (!File.Exists(path))
                    {
                        Debug.OutputDebugStringColored("[ERROR @ READING LANGUAGE FILE '" + path + "' - FILE DOESN'T EXIST!]", ConsoleColor.Red);
                        return;
                    }
                    else 
                        Debug.OutputDebugStringColored("[INFO @ READING LANGUAGE FILE '"+path+"' - FILE EXIST!]", ConsoleColor.Green);


                List<LanguageModel> testList = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(Alt.Server.Resource.Path + "/Languages/language-en.json"));
                if (testList is null)
                {
                    Debug.OutputDebugStringColored("[ERROR @ READING LANGUAGE FILE - FILE IS NULL!]", ConsoleColor.Red);
                    return;
                }
                Debug.OutputDebugStringColored("[INFO @ READING LIST '"+ testList.Count+"' - LANGUAGE CLASSES - COUNTED!]", ConsoleColor.Green);


                Dictionary<string, LanguageModel> LanguagePackEn = new Dictionary<string, LanguageModel>();
                
                foreach (LanguageModel languageClass in testList)
                    if (languageClass?.Text != null && languageClass.Text.Length >= 1 && !LanguagePackEn.ContainsKey(languageClass.Text))
                        if(LanguagePackEn is not null)
                            LanguagePackEn.Add(languageClass.Text, languageClass);
                        else
                            Debug.OutputDebugStringColored("[ERROR @ READING DICT '"+ LanguagePackEn+"' - IS NULL!]", ConsoleColor.Red);

                

                Debug.OutputDebugStringColored("[INFO @ READING DICT '"+ LanguagePackEn.Count+"' - LANGUAGE CLASSES - COUNTED!]", ConsoleColor.Green);
*/
                

                        //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                Database.OnResourceStart();
                //*///////////////////////////////////// SQL LOADING ///////////////////////////////////////////////////*//
                _Gamemodes_.Reallife.globals.Main.OnResourceStart();
                _Gamemodes_.Tactics.globals.Main.OnResourceStart();
                _Gamemodes_.SevenTowers.lobby.Main.OnResourceStart();
                global::VenoX.Core._Language_.Main.OnResourceStart();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VenoX V." + Preload.CurrentVersion + " Loaded!");
                foreach (ColShapeModel col in Sync.ColShapeList.ToList())
                {
                    RageApi.CreateMarker(0, col.Position, new Vector3(col.Radius, col.Radius, col.Radius), new[] { 175, 0, 0, 200 }, null, col.Dimension);
                }


                MinuteTimer = new Timer(OnMinuteSpent, null, 60000, 60000); // Payday Generation und alles was nach einer Minute passiert!
                OnTickTimer = new Timer(OnUpdate, null, 50, 50); // Tick/OnUpdateEvent
                ScoreboardTimer = new Timer(Scoreboard.Scoreboard.Fill_Playerlist, null, 7000, 7000); // Scoreboard Updater.

                //Core._Gamemodes_.Reallife.Woltlab.Program.CreateForumUser(null, "DimaIsABratan", "123321", "123321");
                Program.OnResourceStart();

                /*Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Starting VenoX Bot...");
                //await _Discord_.Startup.RunAsync();
                Console.ForegroundColor = ConsoleColor.Green;
                
                _Discord_.Modules.Notify.SendUpdateLog("BETA apply is now possible! [DEV]! ",
                    "@everyone VenoX V." + Preload.CurrentVersion + " BETA apply is now possible!\n" +
                    "Applies are only valid in the #📝beta-apply channel!\n\n" +
                    "```" +
                    "Nickname : YourNickname.\n" +
                    "Registered : Yes or No.\n" +
                    "Already made experience in alt:V : Yes or No.\n```",
                    Discord.Color.Blue, null);
                Console.WriteLine("Started VenoX Bot.");
                */

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }



        [AsyncScriptEvent(ScriptEventType.ColShape)]
        public static async Task OnColShape(ColShapeModel shape = null, IEntity entity = null, bool state = false)
        {
            try
            {
                await Task.Run(() =>
                {
                    ConsoleHandling.OutputDebugString("-- Entered ColShape --");
                    //await AltAsync.Do(() =>
                    //{
                    if (entity is not VnXPlayer player || shape is null || !shape.Exists) return;
                    if (state)
                    {
                        switch (player.Gamemode)
                        {
                            case (int)Preload.Gamemodes.Reallife:
                                _Gamemodes_.Reallife.globals.Main.OnPlayerEnterColShapeModel(shape, player);
                                return;
                            case (int)Preload.Gamemodes.SevenTowers:
                                _Gamemodes_.SevenTowers.globals.Main.OnColShapeHit(shape, player);
                                return;
                            case (int)Preload.Gamemodes.Race:
                                _Gamemodes_.Race.lobby.Main.OnColshapeHit(shape, player);
                                return;
                        }
                    }
                    else _Gamemodes_.Reallife.globals.Main.OnPlayerExitColShapeModel(shape, player);
                    //});
                });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
                                _Gamemodes_.Reallife.environment.Death.OnPlayerDeath(player, killer, reason);
                                Allround.OnPlayerDeath(player, killer, reason);
                            }
                            return;
                        case (int)Preload.Gamemodes.SevenTowers:
                            _Gamemodes_.SevenTowers.lobby.Main.TakePlayerFromRound(player);
                            return;
                        case (int)Preload.Gamemodes.Zombies:
                            _Gamemodes_.Zombie.World.Main.OnPlayerDeath(player);
                            return;
                        default:
                            ConsoleHandling.OutputDebugString("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                            RageApi.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN GAMEMODE " + player.Gamemode);
                            return;
                    }
                });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }


        [ServerEvent("GlobalSystems:OnPlayerSyncDamage")]
        public void OnPlayerSyncDamage(VnXPlayer player, VnXPlayer killer, float damage = 0)
        {
            try
            {
                player.VnxSetStreamSharedElementData("PLAYER_HEALTH", player.Health);
                player.VnxSetStreamSharedElementData("PLAYER_ARMOR", player.Armor);
                _RootCore_.VenoX.TriggerClientEvent(killer, "Globals:PlayHitsound");
                player.VnxSetElementData("VenoX:LastDamaged", killer);
                Combat.OnTacticsDamage(player, killer, damage);
                Allround.ProcessDamage(player, killer, damage);
                Logfile.WriteLogs("playerdmg", player?.CharacterUsername + " hat " + killer?.CharacterUsername + " angehitted!| DMG : " + damage);
            }
            catch { }
        }

        [ServerEvent("GlobalSystems:OnVehicleSyncDamage")]
        public void OnPlayerVehicleDamage(VnXPlayer player, VehicleModel vehicle, float damage = 0)
        {
            try
            {
                if (vehicle.Godmode) return;
                _RootCore_.VenoX.TriggerClientEvent(player, "Globals:PlayHitsound");
                player.VnxSetElementData("VenoX:LastDamagedVehicle", vehicle);
                ConsoleHandling.OutputDebugString(player.CharacterUsername + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! DMG : " + damage);
                string driverName = "niemand";
                if (vehicle.Driver != null)
                {
                    VnXPlayer driver = (VnXPlayer)vehicle.Driver;
                    driverName = driver.CharacterUsername;
                }
                Logfile.WriteLogs("vehdmg", player.CharacterUsername + " hat " + (AltV.Net.Enums.VehicleModel)vehicle.Model + " angehitted! | Fahrer falls vorhanden : " + driverName + " | DMG : " + damage);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void OnUpdate(object unused)
        {
            try
            {
                Preload.OnUpdate();
                _Gamemodes_.Reallife.globals.Main.OnUpdate();
                _Gamemodes_.Tactics.globals.Main.OnUpdate();
                _Gamemodes_.Race.globals.Main.OnUpdate();
                _Gamemodes_.SevenTowers.lobby.Main.OnUpdate();
                _Gamemodes_.Zombie.globals.Main.OnUpdate();
                Sync.OnSyncTick();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public static void OnPlayerDisconnected(VnXPlayer player, string reason)
        {
            try
            {
                RemovePlayerFromGamemodeList(player);
                string type = string.Empty;
                _Gamemodes_.Reallife.globals.Main.OnPlayerDisconnected(player, type, reason);
                _Gamemodes_.Tactics.globals.Main.OnPlayerDisconnect(player, type, reason);
                Events.OnPlayerDisconnect(player);
                _Gamemodes_.SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public static void PlayerDamage(VnXPlayer source, IPlayer attacker, uint weapon, ushort damage)
        {
            try
            {
                source.VnxSetStreamSharedElementData("PLAYER_HEALTH", source.Health);
                source.VnxSetStreamSharedElementData("PLAYER_ARMOR", source.Armor);
                _RootCore_.VenoX.TriggerClientEvent(source, "Globals:ShowBloodScreen");
            }
            catch { }
        }

        [VenoXRemoteEvent("Discord:Auth")]
        public static void LoadDiscordInformations(VnXPlayer player, bool isOpen, string id, string name, string avatar, string discriminator)
        {
            try
            {
                ConsoleHandling.OutputDebugString(player.CharacterUsername + " | UID " + player.CharacterId + " | " + isOpen + " | " + id + " | " + name + " | " + avatar + " | " + discriminator);
                player.Discord.Id = id;
                player.Discord.IsOpen = isOpen;
                player.Discord.Name = name;
                player.Discord.Avatar = avatar;
                player.Discord.Discriminator = discriminator;
                Database.UpdateDiscordInformations(player.CharacterUsername, player.Discord.Id, player.Discord.Avatar);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
                VnXPlayer vipL = Database.GetPlayerVip(player, player.CharacterId);

                if (player.Reallife.WantedStars > 0) { player.Reallife.WantedStars -= 1; }
                if (playerFaction > 0)
                {
                    foreach (FactionModel faction in _Gamemodes_.Reallife.globals.Constants.FactionRankList)
                    {
                        if (faction.Faction == playerFaction && faction.Rank == playerRank)
                        {
                            total += faction.Salary;
                            break;
                        }
                    }
                }
                string gehalt = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Gehalt");
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
                    string bankinterest = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Bankzinsen");
                    player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + bankinterest + " : " + RageApi.GetHexColorcode(255, 255, 255) + +bankInterest + " $");
                }

                foreach (VehicleModel vehicle in ReallifeVehicles.ToList())
                {
                    if (vehicle.Owner != player.CharacterUsername || vehicle.NotSave == true) continue;
                    int vehicleTaxes = (int)Math.Round(vehicle.Price * _Gamemodes_.Reallife.globals.Constants.TaxesIVehicle);
                    if (vipL.VipTill > DateTime.Now)
                    {
                        string paket = vipL.VipPaket;
                        vehicleTaxes = paket switch
                        {
                            "Silber" => (int) Math.Round(vehicleTaxes *
                                                         _Gamemodes_.Reallife.globals.Constants
                                                             .VipBoniAutosteuerSilver),
                            "Gold" => (int) Math.Round(vehicleTaxes *
                                                       _Gamemodes_.Reallife.globals.Constants
                                                           .VipBoniAutosteuerGold),
                            "UltimateRed" => (int) Math.Round(vehicleTaxes *
                                                              _Gamemodes_.Reallife.globals.Constants
                                                                  .VipBoniAutosteuerUltimatered),
                            "Platin" => (int) Math.Round(vehicleTaxes *
                                                         _Gamemodes_.Reallife.globals.Constants
                                                             .VipBoniAutosteuerPlatin),
                            "TOP DONATOR" => (int) Math.Round(vehicleTaxes *
                                                              _Gamemodes_.Reallife.globals.Constants
                                                                  .VipBoniAutosteuerTopdonator),
                            _ => vehicleTaxes
                        };
                    }

                    int vehicleId = vehicle.DatabaseId;
                    //string VehicleModel vehicle = Vehicle.vnxGetElementData<string>(Core.Globals.EntityData.VEHICLE_MODEL);
                    //string IVehiclePlate = Vehicle.Plate == string.Empty ? "LS " + (1000 + IVehicleId) : Vehicle.vnxGetElementData<string>(Core.Globals.EntityData.VEHICLE_PLATE);
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
                        if (house.Owner == player.CharacterUsername)
                        {
                            int houseTaxes = (int)Math.Round(house.Price * _Gamemodes_.Reallife.globals.Constants.TaxesHouse);
                            string immobiliensteuer = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Immobiliensteuer : ");
                            player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + immobiliensteuer + " : " + RageApi.GetHexColorcode(255, 255, 255) + house.Name + ": -" + houseTaxes + "$");
                            total -= houseTaxes;
                        }
                        if (house.Id == player.Reallife.HouseRent)
                        {
                            string miete = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Miete");
                            player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + miete + " : " + house.Name + " : " + RageApi.GetHexColorcode(255, 255, 255) + +house.Rental + "$");
                            Database.TransferMoneyToPlayer(house.Owner, house.Rental);
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
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniBronze);
                            break;
                        case "Silber":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniSilber);
                            break;
                        case "Gold":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniGold);
                            break;
                        case "UltimateRed":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniRed);
                            break;
                        case "Platin":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniPlatin);
                            break;
                        case "TOP DONATOR":
                            vipboni = (int)Math.Round(total * _Gamemodes_.Reallife.globals.Constants.VipBoniTop);
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
                string vip = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "VIP Bonus");
                player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " " + vip + ": " + RageApi.GetHexColorcode(255, 255, 255) + vipboni + "$");
                // EVENT !!
                //total = total * 4;  // 4FACHER PAYDAY.
                player.SendChatMessage(_Gamemodes_.Reallife.globals.Constants.RgbaHelp + RageApi.GetHexColorcode(0, 150, 200) + "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                string einnahmenGesamt = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "Einnahmen insgesamt");
                player.SendChatMessage(_Gamemodes_.Reallife.globals.Constants.RgbaHelp + RageApi.GetHexColorcode(0, 200, 255) + " " + einnahmenGesamt + " :" + RageApi.GetHexColorcode(255, 255, 255) + +total + " $");

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
                ExceptionHandling.CatchExceptions(ex);
            }
        }
        public static void OnMinuteSpent(object unused)
        {
            try
            {

                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 55) RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Server neustart in 5 Minuten!");
                if (DateTime.Now.Hour == 03 && DateTime.Now.Minute == 59) RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Server neustart in einer Minute!");
                foreach (VnXPlayer player in _RootCore_.VenoX.GetAllPlayers().ToList())
                {
                    int played = player.PlayTime;
                    if (played > 0 && played % 60 == 0) GeneratePlayerPayday(player);
                    player.PlayTime += 1;
                    //SyncDatabaseItems(player);
                    switch (player.Gamemode)
                    {
                        case (int)Preload.Gamemodes.Reallife:
                            _Gamemodes_.Reallife.globals.Main.OnMinuteSpentReallifeGM(player);
                            break;
                    }

                    DatabaseAccount accClass = global::VenoX.Data.Database.Constants.Accounts.ToList().FirstOrDefault(x => x.UID == player.CharacterId);
                    string langpair = global::VenoX.Core._Language_.Main.GetClientLanguagePair((global::VenoX.Core._Language_.Constants.Languages)player.Language);
                    if (accClass is not null && accClass.Language != langpair)
                        Database.UpdatePlayerLanguage(accClass.UID, langpair);

                    SavePlayerDatas(player);
                    Sync.SyncWeather(player);
                    Sync.SyncDateTime(player);
                }
                _Gamemodes_.Reallife.globals.Main.OnMinuteSpend();
                SaveVehicleDatas();
                Sync.DeleteVehicleThreadSafe();
                Sync.DeleteColShapesThreadSafe();
                ConsoleHandling.OutputDebugStringColored("OnMinuteSpend = [OK]", ConsoleColor.Green);
                //Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | OnMinuteSpend = OK!");
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
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
                Database.SaveAllIVehicles(vehicleList);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
            }
        }
        //
    }
}
