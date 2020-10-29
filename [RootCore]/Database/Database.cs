﻿using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.gangwar.v2;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_.Character_Creator;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_.Models;

namespace VenoXV._RootCore_.Database
{
    public class Database : IScript
    {

        private static string connectionString;

        public static async void OnResourceStart()
        {
            // Set the encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string host = "5.180.66.146";
            string user = "VenoXV_Security";
            string pass = "0Ux1k^x8k30vDx2*1g0dOt9@";
            string db = "VenoXV_Security";
            connectionString = "SERVER=" + host + "; DATABASE=" + db + "; UID=" + user + "; PASSWORD=" + pass + "; SSLMODE=none;";
            GangwarManager.DatabaseConnectionCreated = true;
            await Task.Run(async () =>
            {
                await AltAsync.Do(() =>
                {
                    _Admin_.Admin.PlayerBans = LoadPlayerBans();
                    Core.Debug.OutputDebugString(_Admin_.Admin.PlayerBans.Count + " Bans wurden geladen...");
                    //Load Accounts
                    Register.AccountList = LoadAllAccounts();
                    Core.Debug.OutputDebugString(Register.AccountList.Count + " Accounts wurden geladen...");

                    //Char-Creator Accounts loading.
                    _Preload_.Character_Creator.Main.CharacterSkins = LoadAllCharacterSkins();

                    // House loading
                    House.LoadDatabaseHouses();

                    // Tunning loading
                    _Gamemodes_.Reallife.Globals.Main.tunningList = LoadAllTunning();

                    // IVehicle loading
                    LoadAllVehicles();


                    // Item loading
                    //Inventory.LoadDatabaseItems();
                    _Gamemodes_.Reallife.anzeigen.Inventar.Main.CurrentOfflineItemList = LoadAllItems();

                    // Clothes loading
                    _Gamemodes_.Reallife.Globals.Main.clothesList = LoadAllClothes();

                    // Tattoos loading
                    _Gamemodes_.Reallife.Globals.Main.tattooList = LoadAllTattoos();

                    _Gamemodes_.Reallife.Globals.Main.FactionAllroundList = LoadAllFactionDatas();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Database Connection = OK.");
                    Console.ResetColor();
                });
            });
        }


        public static Fraktions_Kassen GetFactionStats(int factionID)
        {
            try
            {
                Fraktions_Kassen fraktion = new Fraktions_Kassen();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT FRAKTION_MONEY, FRAKTION_WEED, FRAKTION_MATS,FRAKTION_KOKAIN FROM fraktionskassen WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                    command.Parameters.AddWithValue("@FRAKTION_ID", factionID);
                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        fraktion.weed = reader.GetInt32("FRAKTION_WEED");
                        fraktion.koks = reader.GetInt32("FRAKTION_KOKAIN");
                        fraktion.mats = reader.GetInt32("FRAKTION_MATS");
                        fraktion.money = reader.GetInt32("FRAKTION_MONEY");
                        /*fraktion.banreason = reader.GetString("banreason");
                        if (!reader.IsDBNull(1))
                        {
                            account.banzeit = reader.GetDateTime("banzeit");
                        }
                        */
                    }
                }
                return fraktion;
            }
            catch { return null; }
        }

        public static void RefreshWaffenlager(WaffenlagerModel _Waffenlager)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM fraktionslager WHERE FID = @FID LIMIT 1";
                command.Parameters.AddWithValue("@FID", _Waffenlager.Faction);
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    _Waffenlager.weapon_knuckle.Amount = reader.GetInt32("weapon_knuckle");
                    _Waffenlager.weapon_nightstick.Amount = reader.GetInt32("weapon_nightstick");
                    _Waffenlager.weapon_baseball.Amount = reader.GetInt32("weapon_baseball");
                    _Waffenlager.weapon_tazer.Amount = reader.GetInt32("weapon_stungun");
                    _Waffenlager.weapon_pistol50.Amount = reader.GetInt32("weapon_pistol50");
                    _Waffenlager.weapon_pistol50_ammo.Amount = reader.GetInt32("weapon_pistol50_ammo");
                    _Waffenlager.weapon_revolver.Amount = reader.GetInt32("weapon_revolver");
                    _Waffenlager.weapon_revolver_ammo.Amount = reader.GetInt32("weapon_revolver_ammo");
                    _Waffenlager.weapon_pistol.Amount = reader.GetInt32("weapon_pistol");
                    _Waffenlager.weapon_pistol_ammo.Amount = reader.GetInt32("weapon_pistol_ammo");
                    _Waffenlager.weapon_combatpdw.Amount = reader.GetInt32("weapon_combatpdw");
                    _Waffenlager.weapon_combatpdw_ammo.Amount = reader.GetInt32("weapon_combatpdw_ammo");
                    _Waffenlager.weapon_mp5.Amount = reader.GetInt32("weapon_mp5");
                    _Waffenlager.weapon_mp5_ammo.Amount = reader.GetInt32("weapon_mp5_ammo");
                    _Waffenlager.weapon_pumpshotgun.Amount = reader.GetInt32("weapon_pumpshotgun");
                    _Waffenlager.weapon_pumpshotgun_ammo.Amount = reader.GetInt32("weapon_pumpshotgun_ammo");
                    _Waffenlager.weapon_assaultrifle.Amount = reader.GetInt32("weapon_assaultrifle");
                    _Waffenlager.weapon_assaultrifle_ammo.Amount = reader.GetInt32("weapon_assaultrifle_ammo");
                    _Waffenlager.weapon_advancedrifle.Amount = reader.GetInt32("weapon_advancedrifle");
                    _Waffenlager.weapon_advancedrifle_ammo.Amount = reader.GetInt32("weapon_advancedrifle_ammo");
                    _Waffenlager.weapon_rifle.Amount = reader.GetInt32("weapon_rifle");
                    _Waffenlager.weapon_rifle_ammo.Amount = reader.GetInt32("weapon_rifle_ammo");
                    _Waffenlager.weapon_carbinerifle.Amount = reader.GetInt32("weapon_carbinerifle");
                    _Waffenlager.weapon_carbinerifle_ammo.Amount = reader.GetInt32("weapon_carbinerifle_ammo");
                    _Waffenlager.weapon_gusenberg.Amount = reader.GetInt32("weapon_gusenberg");
                    _Waffenlager.weapon_gusenberg_ammo.Amount = reader.GetInt32("weapon_gusenberg_ammo");
                    _Waffenlager.weapon_sniperrifle.Amount = reader.GetInt32("weapon_sniperrifle");
                    _Waffenlager.weapon_sniperrifle_ammo.Amount = reader.GetInt32("weapon_sniperrifle_ammo");
                    _Waffenlager.weapon_rpg.Amount = reader.GetInt32("weapon_rpg");
                    _Waffenlager.weapon_rpg_ammo.Amount = reader.GetInt32("weapon_rpg_ammo");
                    _Waffenlager.weapon_molotov.Amount = reader.GetInt32("weapon_molotov");
                    _Waffenlager.weapon_smokegrenade.Amount = reader.GetInt32("weapon_smokegrenade");
                    _Waffenlager.weapon_bzgas.Amount = reader.GetInt32("weapon_bzgas");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void SetFactionWeaponlager(int factionID, int weapon_knuckle, int weapon_nightstick, int weapon_baseball, int weapon_stungun, int weapon_pistol, int weapon_pistol50,
            int weapon_revolver, int weapon_pumpshotgun, int weapon_combatpdw, int weapon_mp5, int weapon_assaultrifle, int weapon_carbinerifle, int weapon_advancedrifle,
            int weapon_gusenberg, int weapon_rifle, int weapon_sniperrifle, int weapon_rpg, int weapon_bzgas, int weapon_molotov, int weapon_smokegrenade, int weapon_pistol_ammo, int weapon_pistol50_ammo, int weapon_revolver_ammo, int weapon_pumpshotgun_ammo, int weapon_combatpdw_ammo, int weapon_mp5_ammo, int weapon_assaultrifle_ammo,
            int weapon_carbinerifle_ammo, int weapon_advancedrifle_ammo, int weapon_gusenberg_ammo, int weapon_rifle_ammo, int weapon_sniperrifle_ammo, int weapon_rpg_ammo)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE fraktionslager SET weapon_knuckle = @weapon_knuckle, weapon_nightstick = @weapon_nightstick, weapon_baseball = @weapon_baseball, weapon_stungun = @weapon_stungun, " +
                "weapon_pistol50 = @weapon_pistol50, weapon_pistol50_ammo = @weapon_pistol50_ammo, weapon_revolver = @weapon_revolver, weapon_revolver_ammo = @weapon_revolver_ammo, weapon_pistol = @weapon_pistol ,weapon_pistol_ammo = @weapon_pistol_ammo, weapon_mp5 = @weapon_mp5, weapon_mp5_ammo = @weapon_mp5_ammo, weapon_combatpdw = @weapon_combatpdw, weapon_combatpdw_ammo = @weapon_combatpdw_ammo, weapon_pumpshotgun = @weapon_pumpshotgun, weapon_pumpshotgun_ammo = @weapon_pumpshotgun_ammo, " +
                "weapon_assaultrifle = @weapon_assaultrifle, weapon_assaultrifle_ammo = @weapon_assaultrifle_ammo, weapon_carbinerifle = @weapon_carbinerifle,weapon_carbinerifle_ammo = @weapon_carbinerifle_ammo,  weapon_advancedrifle = @weapon_advancedrifle, weapon_advancedrifle_ammo = @weapon_advancedrifle_ammo, weapon_gusenberg = @weapon_gusenberg, weapon_gusenberg_ammo = @weapon_gusenberg_ammo, weapon_rifle = @weapon_rifle, weapon_rifle_ammo = @weapon_rifle_ammo, weapon_sniperrifle = @weapon_sniperrifle, weapon_sniperrifle_ammo = @weapon_sniperrifle_ammo,  " +
                "weapon_rpg = @weapon_rpg, weapon_rpg_ammo = @weapon_rpg_ammo, weapon_molotov = @weapon_molotov, weapon_smokegrenade = @weapon_smokegrenade, weapon_bzgas = @weapon_bzgas  " +
                "WHERE FID = @FID LIMIT 1";
                command.Parameters.AddWithValue("@FID", factionID);

                command.Parameters.AddWithValue("@weapon_knuckle", weapon_knuckle);
                command.Parameters.AddWithValue("@weapon_nightstick", weapon_nightstick);
                command.Parameters.AddWithValue("@weapon_baseball", weapon_baseball);
                command.Parameters.AddWithValue("@weapon_stungun", weapon_stungun);
                command.Parameters.AddWithValue("@weapon_pistol50", weapon_pistol50);
                command.Parameters.AddWithValue("@weapon_pistol50_ammo", weapon_pistol50_ammo);
                command.Parameters.AddWithValue("@weapon_revolver", weapon_revolver);
                command.Parameters.AddWithValue("@weapon_revolver_ammo", weapon_revolver_ammo);
                command.Parameters.AddWithValue("@weapon_pistol", weapon_pistol);
                command.Parameters.AddWithValue("@weapon_pistol_ammo", weapon_pistol_ammo);
                command.Parameters.AddWithValue("@weapon_mp5", weapon_mp5);
                command.Parameters.AddWithValue("@weapon_mp5_ammo", weapon_mp5_ammo);
                command.Parameters.AddWithValue("@weapon_combatpdw", weapon_combatpdw);
                command.Parameters.AddWithValue("@weapon_combatpdw_ammo", weapon_combatpdw_ammo);
                command.Parameters.AddWithValue("@weapon_pumpshotgun", weapon_pumpshotgun);
                command.Parameters.AddWithValue("@weapon_pumpshotgun_ammo", weapon_pumpshotgun_ammo);
                command.Parameters.AddWithValue("@weapon_assaultrifle", weapon_assaultrifle);
                command.Parameters.AddWithValue("@weapon_assaultrifle_ammo", weapon_assaultrifle_ammo);
                command.Parameters.AddWithValue("@weapon_carbinerifle", weapon_carbinerifle);
                command.Parameters.AddWithValue("@weapon_carbinerifle_ammo", weapon_carbinerifle_ammo);
                command.Parameters.AddWithValue("@weapon_advancedrifle", weapon_advancedrifle);
                command.Parameters.AddWithValue("@weapon_advancedrifle_ammo", weapon_advancedrifle_ammo);
                command.Parameters.AddWithValue("@weapon_gusenberg", weapon_gusenberg);
                command.Parameters.AddWithValue("@weapon_gusenberg_ammo", weapon_gusenberg_ammo);
                command.Parameters.AddWithValue("@weapon_rifle", weapon_rifle);
                command.Parameters.AddWithValue("@weapon_rifle_ammo", weapon_rifle_ammo);
                command.Parameters.AddWithValue("@weapon_sniperrifle", weapon_sniperrifle);
                command.Parameters.AddWithValue("@weapon_sniperrifle_ammo", weapon_sniperrifle_ammo);
                command.Parameters.AddWithValue("@weapon_rpg", weapon_rpg);
                command.Parameters.AddWithValue("@weapon_rpg_ammo", weapon_rpg_ammo);
                command.Parameters.AddWithValue("@weapon_molotov", weapon_molotov);
                command.Parameters.AddWithValue("@weapon_smokegrenade", weapon_smokegrenade);
                command.Parameters.AddWithValue("@weapon_bzgas", weapon_bzgas);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SetFactionWeaponlager] " + ex.Message);
                Console.WriteLine("[EXCEPTION SetFactionWeaponlager] " + ex.StackTrace);
            }
        }

        public static void SetFactionStats(int factionID, int money, int weed, int koks, int mats)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                //command.CommandText = "INSERT INTO fraktionskassen FRAKTION_MONEY, FRAKTION_WEED, FRAKTION_MATS,FRAKTION_KOKAIN FROM fraktionskassen WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                command.CommandText = "UPDATE fraktionskassen SET FRAKTION_MONEY = @FRAKTION_MONEY, FRAKTION_WEED = @FRAKTION_WEED, FRAKTION_MATS = @FRAKTION_MATS, FRAKTION_KOKAIN = @FRAKTION_KOKAIN  WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                command.Parameters.AddWithValue("@FRAKTION_ID", factionID);
                command.Parameters.AddWithValue("@FRAKTION_MONEY", money);
                command.Parameters.AddWithValue("@FRAKTION_WEED", weed);
                command.Parameters.AddWithValue("@FRAKTION_MATS", mats);
                command.Parameters.AddWithValue("@FRAKTION_KOKAIN", koks);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SetFactionStats] " + ex.Message);
                Console.WriteLine("[EXCEPTION SetFactionStats] " + ex.StackTrace);
            }
        }

        public static bool LoginAccountByName(string name, string password)
        {
            try
            {
                bool login = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM spieler WHERE SpielerName = @SpielerName AND Passwort = SHA2(@Passwort, '256') LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", name);
                    command.Parameters.AddWithValue("@Passwort", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        login = reader.HasRows;
                    }
                }

                return login;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        public static void ChangeUserPasswort(string Spielername, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET Passwort = SHA2(@Passwort, '256') WHERE SpielerName = @SpielerName";
                    command.Parameters.AddWithValue("@SpielerName", Spielername);
                    command.Parameters.AddWithValue("@Passwort", password);
                    command.ExecuteNonQuery();
                }
            }
            catch { }
        }

        public static int RegisterAccount(string nickname, string SocialClub, string HardwareIdHash, string HardwareIdExHash, string email, string password, string geschlecht, int ForumUID)
        {
            try
            {
                int RegisteredUID = -1;
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO spieler (SpielerName, SpielerSocial, HardwareIdHash, HardwareIdExHash, email, Passwort, Geschlecht, ForumUID) VALUES(@SpielerName, @SpielerSocial, @HardwareIdHash, @HardwareIdExHash, @email, SHA2(@passwort, '256'), @Geschlecht, @ForumUID)";
                command.Parameters.AddWithValue("@SpielerName", nickname);
                command.Parameters.AddWithValue("@SpielerSocial", SocialClub);
                command.Parameters.AddWithValue("@HardwareIdHash", HardwareIdHash);
                command.Parameters.AddWithValue("@HardwareIdExHash", HardwareIdExHash);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@passwort", password);
                command.Parameters.AddWithValue("@Geschlecht", geschlecht);
                command.Parameters.AddWithValue("@ForumUID", ForumUID);
                RegisteredUID = (int)command.LastInsertedId;
                command.ExecuteNonQuery();
                return RegisteredUID;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return -1; }
        }

        public static void CreateCharacterSkin(int UID, string facefeatures, string headblends, string headoverlays)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO skins (UID, facefeatures, headblends, headoverlays) VALUES(@UID, @facefeatures, @headblends, @headoverlays)";
                command.Parameters.AddWithValue("@UID", UID);
                command.Parameters.AddWithValue("@facefeatures", facefeatures);
                command.Parameters.AddWithValue("@headblends", headblends);
                command.Parameters.AddWithValue("@headoverlays", headoverlays);
                command.ExecuteNonQuery();
            }
            catch { }
        }

        public static int GetPlayerWhereFromList(string where)
        {
            try
            {
                int wherefrom = 0;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM advertised WHERE ID = 0";
                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            wherefrom = reader.GetInt32(where);
                        }
                    }
                }
                return wherefrom;
            }
            catch { return 0; }
        }
        public static List<BanModel> LoadPlayerBans()
        {
            try
            {
                List<BanModel> PlayerBans = new List<BanModel>();
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ban";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        BanModel BanEntry = new BanModel
                        {
                            UID = reader.GetInt32("UID"),
                            Name = reader.GetString("Name"),
                            HardwareId = reader.GetString("HardwareId"),
                            HardwareIdExHash = reader.GetString("HardwareIdExHash"),
                            IP = reader.GetString("IP"),
                            DiscordID = reader.GetString("DiscordID").ToString(),
                            Reason = reader.GetString("Reason"),
                            Admin = reader.GetString("Admin"),
                            BannedTill = reader.GetDateTime("BannedTill"),
                            BanCreated = reader.GetDateTime("BanDateCreated"),
                            BanType = reader.GetString("BanType")
                        };
                        PlayerBans.Add(BanEntry);
                    }
                    else return new List<BanModel>();
                }
                return PlayerBans;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<BanModel>(); }
        }

        public static void SetPlayerWhereFromList(string where, int howmuch)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE advertised SET " + where + " = @Value LIMIT 1";
                    command.Parameters.AddWithValue("@Value", howmuch);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION SetPlayerWhereFromList] " + ex.Message);
                    Console.WriteLine("[EXCEPTION SetPlayerWhereFromList] " + ex.StackTrace);
                }
            }
        }

        public static int CreateCharacter(VnXPlayer player, int UID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO users (UID, SpielerName, sex) VALUES (@UID, @playerName, @playerSex)";
                    command.Parameters.AddWithValue("@playerName", player.Username);
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@playerSex", player.Sex);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION CreateCharacter] " + ex.Message);
                    Console.WriteLine("[EXCEPTION CreateCharacter] " + ex.StackTrace);
                }
            }

            return UID;
        }

        public static void LoadCharacterInformationById(VnXPlayer character, int characterId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE UID = @UID LIMIT 1";
                command.Parameters.AddWithValue("@UID", characterId);

                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    float posX = reader.GetFloat("posX");
                    float posY = reader.GetFloat("posY");
                    float posZ = reader.GetFloat("posZ");
                    float rot = reader.GetFloat("rotation");

                    character.UID = reader.GetInt32("UID");
                    character.Username = reader.GetString("SpielerName");
                    character.AdminRank = reader.GetInt32("adminRank");
                    character.Reallife.SpawnLocation = reader.GetString("spawn");
                    character.Reallife.Knastzeit = reader.GetInt32("knastzeit");
                    character.Reallife.Faction = reader.GetInt32("faction");
                    character.Reallife.Zivizeit = reader.GetDateTime("zivizeit");
                    //character.SetPosition = new Vector3(posX, posY, posZ);
                    character.Reallife.Money = reader.GetInt32("money");
                    character.Reallife.Bank = reader.GetInt32("bank");
                    character.Reallife.SocialState = reader.GetString("SocialState");
                    character.Sex = reader.GetInt32("sex");
                    character.Reallife.Job = reader.GetString("job");
                    character.Reallife.LIEFERJOB_LEVEL = reader.GetInt32("LIEFERJOB_LEVEL");
                    character.Reallife.AIRPORTJOB_LEVEL = reader.GetInt32("AIRPORTJOB_LEVEL");
                    character.Reallife.BUSJOB_LEVEL = reader.GetInt32("BUSJOB_LEVEL");
                    character.Reallife.FactionRank = reader.GetInt32("rank");
                    character.Dead = reader.GetInt32("killed");
                    character.Reallife.HouseRent = reader.GetInt32("houseRent");
                    character.Reallife.HouseEntered = reader.GetInt32("houseEntered");
                    character.Reallife.BusinessEntered = reader.GetInt32("businessEntered");

                    character.Reallife.Personalausweis = reader.GetInt32("Personalausweis");
                    character.Reallife.Autofuehrerschein = reader.GetInt32("Autofuehrerschein");
                    character.Reallife.Motorradfuehrerschein = reader.GetInt32("Motorradfuehrerschein");
                    character.Reallife.LKWfuehrerschein = reader.GetInt32("LKWfuehrerschein");
                    character.Reallife.Helikopterfuehrerschein = reader.GetInt32("Helikopterfuehrerschein");
                    character.Reallife.FlugscheinKlasseA = reader.GetInt32("FlugscheinKlasseA");
                    character.Reallife.FlugscheinKlasseB = reader.GetInt32("FlugscheinKlasseB");
                    character.Reallife.Motorbootschein = reader.GetInt32("Motorbootschein");
                    character.Reallife.Angelschein = reader.GetInt32("Angelschein");
                    character.Reallife.Waffenschein = reader.GetInt32("Waffenschein");

                    character.Played = reader.GetInt32("played");
                    character.Reallife.Quests = reader.GetInt32("quests");
                    character.Reallife.Wanteds = reader.GetInt32("wanteds");
                    character.Reallife.Kaution = reader.GetInt32("kaution");
                    character.Reallife.HUD = reader.GetInt32("REALLIFE_HUD");

                    character.Settings.ShowATM = reader.GetInt32("atm_anzeigen");
                    character.Settings.ShowHouse = reader.GetInt32("haus_anzeigen");
                    character.Settings.ShowSpeedo = reader.GetInt32("tacho_anzeigen");
                    character.Settings.ShowQuests = reader.GetInt32("quest_anzeigen");
                    character.Settings.ShowReporter = reader.GetInt32("reporter_anzeigen");
                    character.Settings.ShowGlobalChat = reader.GetInt32("globalchat_anzeigen");

                    character.Tactics.Kills = reader.GetInt32("tactic_kills");
                    character.Tactics.Deaths = reader.GetInt32("tactic_tode");

                    character.Zombies.Zombie_tode = reader.GetInt32("zombie_tode");
                    character.Zombies.Zombie_kills = reader.GetInt32("zombie_kills");
                    character.Zombies.Zombie_player_kills = reader.GetInt32("zombie_player_kills");
                    character.SevenTowers.Wins = reader.GetInt32("seventowers_wins");

                    character.Reallife.Adventskalender = reader.GetInt32("Adventskalender");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        public static void SaveCharacterInformation(VnXPlayer player)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE users SET posX = @posX, posY = @posY, posZ = @posZ, rotation = @rotation, money = @money, bank = @bank, SocialState = @SocialState, health = @health, armor = @armor, spawn  = @spawn, quests = @quests, wanteds = @wanteds, ";
                command.CommandText += "knastzeit = @knastzeit, kaution = @kaution, REALLIFE_HUD = @REALLIFE_HUD, atm_anzeigen = @atm_anzeigen, haus_anzeigen = @haus_anzeigen, tacho_anzeigen = @tacho_anzeigen, quest_anzeigen = @quest_anzeigen, reporter_anzeigen = @reporter_anzeigen, globalchat_anzeigen = @globalchat_anzeigen, killed = @killed,";
                command.CommandText += "faction = @faction, zivizeit = @zivizeit, job = @job, LIEFERJOB_LEVEL = @LIEFERJOB_LEVEL, AIRPORTJOB_LEVEL = @AIRPORTJOB_LEVEL, BUSJOB_LEVEL = @BUSJOB_LEVEL, rank = @rank, houseRent = @houseRent, ";
                command.CommandText += "houseEntered = @houseEntered, businessEntered = @businessEntered, Personalausweis = @Personalausweis, Autofuehrerschein = @Autofuehrerschein,";
                command.CommandText += "Motorradfuehrerschein = @Motorradfuehrerschein, LKWfuehrerschein = @LKWfuehrerschein, Helikopterfuehrerschein = @Helikopterfuehrerschein, FlugscheinKlasseA = @FlugscheinKlasseA, FlugscheinKlasseB = @FlugscheinKlasseB, Motorbootschein = @Motorbootschein, Angelschein = @Angelschein, Waffenschein = @Waffenschein,";
                command.CommandText += "tactic_kills = @tactic_kills, tactic_tode = @tactic_tode, Adventskalender = @Adventskalender, zombie_kills = @zombie_kills, zombie_tode = @zombie_tode, zombie_player_kills = @zombie_player_kills, seventowers_wins = @seventowers_wins, ";

                command.CommandText += "played = @played WHERE UID = @playerId LIMIT 1";
                command.Parameters.AddWithValue("@posX", player.Position.X);
                command.Parameters.AddWithValue("@posY", player.Position.Y);
                command.Parameters.AddWithValue("@posZ", player.Position.Z);
                command.Parameters.AddWithValue("@rotation", player.Rotation.Yaw);
                command.Parameters.AddWithValue("@money", player.Reallife.Money);
                command.Parameters.AddWithValue("@bank", player.Reallife.Bank);
                command.Parameters.AddWithValue("@SocialState", player.Reallife.SocialState);
                command.Parameters.AddWithValue("@health", player.Health);
                command.Parameters.AddWithValue("@armor", player.Armor);
                command.Parameters.AddWithValue("@killed", player.Dead);
                command.Parameters.AddWithValue("@faction", player.Reallife.Faction);
                command.Parameters.AddWithValue("@zivizeit", player.Reallife.Zivizeit);
                command.Parameters.AddWithValue("@job", player.Reallife.Job);
                command.Parameters.AddWithValue("@LIEFERJOB_LEVEL", player.Reallife.LIEFERJOB_LEVEL);
                command.Parameters.AddWithValue("@AIRPORTJOB_LEVEL", player.Reallife.AIRPORTJOB_LEVEL);
                command.Parameters.AddWithValue("@BUSJOB_LEVEL", player.Reallife.BUSJOB_LEVEL);
                command.Parameters.AddWithValue("@rank", player.Reallife.FactionRank);
                command.Parameters.AddWithValue("@houseRent", player.Reallife.HouseRent);
                command.Parameters.AddWithValue("@houseEntered", player.Reallife.HouseEntered);
                command.Parameters.AddWithValue("@businessEntered", player.Reallife.BusinessEntered);

                command.Parameters.AddWithValue("@Personalausweis", player.Reallife.Personalausweis);
                command.Parameters.AddWithValue("@Autofuehrerschein", player.Reallife.Autofuehrerschein);
                command.Parameters.AddWithValue("@Motorradfuehrerschein", player.Reallife.Motorradfuehrerschein);
                command.Parameters.AddWithValue("@LKWfuehrerschein", player.Reallife.LKWfuehrerschein);
                command.Parameters.AddWithValue("@Helikopterfuehrerschein", player.Reallife.Helikopterfuehrerschein);
                command.Parameters.AddWithValue("@FlugscheinKlasseA", player.Reallife.FlugscheinKlasseA);
                command.Parameters.AddWithValue("@FlugscheinKlasseB", player.Reallife.FlugscheinKlasseB);
                command.Parameters.AddWithValue("@Motorbootschein", player.Reallife.Motorbootschein);
                command.Parameters.AddWithValue("@Angelschein", player.Reallife.Angelschein);
                command.Parameters.AddWithValue("@Waffenschein", player.Reallife.Waffenschein);


                command.Parameters.AddWithValue("@played", player.Played);
                command.Parameters.AddWithValue("@playerId", player.UID);
                command.Parameters.AddWithValue("@spawn", player.Reallife.SpawnLocation);
                command.Parameters.AddWithValue("@quests", player.Reallife.Quests);
                command.Parameters.AddWithValue("@wanteds", player.Reallife.Wanteds);
                command.Parameters.AddWithValue("@knastzeit", player.Reallife.Knastzeit);
                command.Parameters.AddWithValue("@kaution", player.Reallife.Kaution);
                command.Parameters.AddWithValue("@REALLIFE_HUD", player.Reallife.HUD);
                command.Parameters.AddWithValue("@atm_anzeigen", player.Settings.ShowATM);
                command.Parameters.AddWithValue("@haus_anzeigen", player.Settings.ShowHouse);
                command.Parameters.AddWithValue("@tacho_anzeigen", player.Settings.ShowSpeedo);
                command.Parameters.AddWithValue("@quest_anzeigen", player.Settings.ShowQuests);
                command.Parameters.AddWithValue("@reporter_anzeigen", player.Settings.ShowReporter);
                command.Parameters.AddWithValue("@globalchat_anzeigen", player.Settings.ShowGlobalChat);
                command.Parameters.AddWithValue("@tactic_kills", player.Tactics.Kills);
                command.Parameters.AddWithValue("@tactic_tode", player.Tactics.Deaths);
                command.Parameters.AddWithValue("@Adventskalender", player.Reallife.Adventskalender);
                command.Parameters.AddWithValue("@zombie_kills", player.Zombies.Zombie_kills);
                command.Parameters.AddWithValue("@zombie_tode", player.Zombies.Zombie_tode);
                command.Parameters.AddWithValue("@zombie_player_kills", player.Zombies.Zombie_player_kills);
                command.Parameters.AddWithValue("@seventowers_wins", player.SevenTowers.Wins);



                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveCharacterInformation] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveCharacterInformation] " + ex.StackTrace);
            }
        }





        public static bool FindAccount(string name)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerSocial FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }
        public static bool FindAccountByName(string name)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerSocial FROM spieler WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindAccountByHardwareIdHash(string HardwareIdHash)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE HardwareIdHash = @HardwareIdHash LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareIdHash", HardwareIdHash);

                    using MySqlDataReader reader = command.ExecuteReader();
                    found = reader.HasRows;
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindAccountByHardwareIdExHash(string HardwareIdExHash)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE HardwareIdExHash = @HardwareIdExHash LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareIdExHash", HardwareIdExHash);

                    using MySqlDataReader reader = command.ExecuteReader();
                    found = reader.HasRows;
                }

                return found;
            }
            catch { return false; }
        }


        public static bool FindCharacter(string name)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE socialName = @socialName LIMIT 1";
                    command.Parameters.AddWithValue("@socialName", name);

                    using MySqlDataReader reader = command.ExecuteReader();
                    found = reader.HasRows;
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindCharacterName(string name)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerName FROM users WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindCharacterByUID(int UID)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", UID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindCharakterPrison(string SpielerName)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static int GetCharakterPrisonTime(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonZeit FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetInt32("PrisonZeit");
                        }
                    }
                }
                return 0;
            }
            catch { return 0; }
        }

        public static string GetCharakterPrisonReason(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonGrund FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("PrisonGrund");
                        }
                    }
                }
                return "ERROR | BITTE BEI EINEM ADMINISTRATOR ODER HÖHER MELDEN!";
            }
            catch { return "ERROR | BITTE BEI EINEM ADMINISTRATOR ODER HÖHER MELDEN!"; }
        }

        public static string GetCharakterPrisonAdminBy(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonVon FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("PrisonVon");
                        }
                    }
                }
                return "ERROR | BITTE BEI EINEM ADMINISTRATOR ODER HÖHER MELDEN!";
            }
            catch { return "ERROR | BITTE BEI EINEM ADMINISTRATOR ODER HÖHER MELDEN!"; }
        }

        public static DateTime GetCharakterPrisonErstelltAm(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonErstelltAm FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetDateTime("PrisonErstelltAm");
                        }
                    }
                }
                return DateTime.Now;
            }
            catch { return DateTime.Now; }
        }

        public static bool FindCharacterByName(string name)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }


        public static bool FindCharacterBan(string SpielerSocial)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Bangrund, Admin, Banzeit, BanerstelltAm FROM ban WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SpielerSocial);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static int GetCharakterUID(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetInt32("UID");
                        }
                    }
                }
                return -1;
            }
            catch { return -1; }
        }

        public static int GetPlayerUID(string SpielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM spieler WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32("UID");
                    }
                }
                return -1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return -1; }
        }


        public static string GetAccountGeschlecht(string SocialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Geschlecht FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SocialName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("Geschlecht");
                        }
                    }
                }
                return "Männlich";
            }
            catch
            {
                return "Männlich";
            }
        }

        public static string GetAccountSpielerName(string SocialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerName FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SocialName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("SpielerName");
                        }
                    }
                }
                return "ERROR";
            }
            catch { return "ERROR"; }
        }
        public static string GetAccountSpielerSerial(string SocialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SocialName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("serial");
                        }
                    }
                }
                return "ERROR";
            }
            catch { return "ERROR"; }
        }

        public static string GetAccountNameByHardwareId(string HardwareId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT HardwareId FROM spieler WHERE HardwareId = @HardwareId LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareId", HardwareId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("HardwareId");
                        }
                    }
                }
                return "ERROR";
            }
            catch { return "ERROR"; }
        }

        public static string GetCharakterSocialName(string spielername)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerSocial FROM spieler WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielername);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString("SpielerSocial");
                        }
                    }
                }
                return "ERROR";
            }
            catch { return "ERROR"; }
        }

        public static VnXPlayer GetPlayerVIP(VnXPlayer spieler, int UID)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT VIP_Paket, VIP_BisZum, VIP_GekauftAm FROM spieler WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", UID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            spieler.Vip_Paket = reader.GetString("VIP_Paket");
                            spieler.Vip_BisZum = reader.GetDateTime("VIP_BisZum");
                            spieler.Vip_GekauftAm = reader.GetDateTime("VIP_GekauftAm");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION GetPlayerVIP] " + ex.Message);
                    Console.WriteLine("[EXCEPTION GetPlayerVIP] " + ex.StackTrace);
                }
            }
            return spieler;
        }

        public static void SetVIPStats(int UID, string Paket, int Tage)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET VIP_Paket = @VIP_Paket, VIP_BisZum = @VIP_BisZum WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@VIP_Paket", Paket);
                    command.Parameters.AddWithValue("@VIP_BisZum", DateTime.Now.AddDays(Tage));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION SetVIPStats] " + ex.Message);
                    Console.WriteLine("[EXCEPTION SetVIPStats] " + ex.StackTrace);
                }
            }
        }

        public static void SetPlayerSerial(string SpielerSocial, string serial)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET serial = @serial WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SpielerSocial);
                    command.Parameters.AddWithValue("@serial", serial);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION SetPlayerSerial] " + ex.Message);
                    Console.WriteLine("[EXCEPTION SetPlayerSerial] " + ex.StackTrace);
                }
            }
        }

        public static void SetPlayerSocialClubByUID(int UID, string SpielerSocial)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET SpielerSocial = @SpielerSocial WHERE UID = @UID LIMIT 1";
                    //command.CommandText = "UPDATE users SET socialName = @SpielerSocial WHERE UID = @UID";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@SpielerSocial", SpielerSocial);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION SetPlayerSocialClubBySerial] " + ex.Message);
                    Console.WriteLine("[EXCEPTION SetPlayerSocialClubBySerial] " + ex.StackTrace);
                }
            }
        }

        public static Accountbans GetAccountbans(string socialName)
        {
            try
            {
                Accountbans AccountBans = new Accountbans();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Bangrund, Admin, Banzeit, BanerstelltAm, Bantype FROM ban WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", socialName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            AccountBans.banreason = reader.GetString("Bangrund");
                            AccountBans.AdminBanned = reader.GetString("Admin");
                            AccountBans.banzeit = reader.GetDateTime("Banzeit");
                            AccountBans.banerstelltam = reader.GetDateTime("BanerstelltAm");
                            AccountBans.Bantype = reader.GetString("Bantype");
                        }
                    }
                }
                return AccountBans;
            }
            catch { return null; }
        }
        public static Accountbans GetAccountbansBySerial(string serial)
        {
            try
            {
                Accountbans AccountBans = new Accountbans();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Bangrund, Admin, Banzeit, BanerstelltAm, Bantype FROM ban WHERE serial = @serial LIMIT 1";
                    command.Parameters.AddWithValue("@serial", serial);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            AccountBans.banreason = reader.GetString("Bangrund");
                            AccountBans.AdminBanned = reader.GetString("Admin");
                            AccountBans.banzeit = reader.GetDateTime("Banzeit");
                            AccountBans.banerstelltam = reader.GetDateTime("BanerstelltAm");
                            AccountBans.Bantype = reader.GetString("Bantype");
                        }
                    }
                }
                return AccountBans;
            }
            catch { return null; }
        }

        public static void RemoveOldBan(string SpielerSocial)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM ban WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", SpielerSocial);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveOldBan] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveOldBan] " + ex.StackTrace);
                }
            }
        }

        public static void RemoveOldBanBySerial(string serial)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM ban WHERE serial = @serial LIMIT 1";
                    command.Parameters.AddWithValue("@serial", serial);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveOldBanBySerial] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveOldBanBySerial] " + ex.StackTrace);
                }
            }
        }

        public static void RemoveOldPrison(string SpielerName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveOldPrison] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveOldPrison] " + ex.StackTrace);
                }
            }
        }


        public static List<VehicleModel> LoadAllVehicles()
        {
            try
            {
                List<VehicleModel> IVehicleList = new List<VehicleModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Vehicles";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        float posX = reader.GetFloat("posX");
                        float posY = reader.GetFloat("posY");
                        float posZ = reader.GetFloat("posZ");
                        float rotX = reader.GetFloat("rotX");
                        float rotY = reader.GetFloat("rotY");
                        float rotZ = reader.GetFloat("rotZ");
                        VehicleModel vehClass = (VehicleModel)Alt.CreateVehicle(Alt.Hash(reader.GetString("model")), new Vector3(posX, posY, posZ), new Vector3(rotX, rotY, rotZ));
                        vehClass.ID = reader.GetInt32("id");
                        vehClass.Name = reader.GetString("model");
                        vehClass.FirstColor = reader.GetString("firstColor");
                        vehClass.SecondColor = reader.GetString("secondColor");
                        vehClass.Owner = reader.GetString("owner");
                        vehClass.Plate = reader.GetString("plate");
                        vehClass.NumberplateText = reader.GetString("plate");
                        vehClass.Faction = reader.GetInt32("faction");
                        if (vehClass.Faction > 0)
                        {
                            //vehClass.Dimension = reader.GetInt32("dimension");
                            vehClass.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        }
                        else
                        {
                            vehClass.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        }
                        vehClass.Price = reader.GetInt32("price");
                        vehClass.Gas = reader.GetFloat("gas");
                        vehClass.Kms = reader.GetFloat("kms");
                        vehClass.Position = new Vector3(posX, posY, posZ);
                        vehClass.Rotation = new Vector3(rotX, rotY, rotZ);
                        vehClass.SpawnCoord = vehClass.Position;
                        vehClass.SpawnRot = vehClass.Rotation;
                        string[] firstRgba = vehClass.FirstColor.Split(',');
                        string[] secondRgba = vehClass.SecondColor.Split(',');
                        vehClass.PrimaryColorRgb = new Rgba(Convert.ToByte(int.Parse(firstRgba[0]).ToString()), Convert.ToByte(int.Parse(firstRgba[1])), Convert.ToByte(int.Parse(firstRgba[2])), 255);
                        vehClass.SecondaryColorRgb = new Rgba(Convert.ToByte(int.Parse(secondRgba[0])), Convert.ToByte(int.Parse(secondRgba[1])), Convert.ToByte(int.Parse(secondRgba[2])), 255);
                        vehClass.EngineOn = false;
                        vehClass.Frozen = true;
                        vehClass.Godmode = true;
                        vehClass.NPC = false;
                        if (vehClass.Faction > Constants.FACTION_NONE)
                        {
                            vehClass.LockState = AltV.Net.Enums.VehicleLockState.Unlocked;
                        }
                        else
                        {
                            vehClass.LockState = AltV.Net.Enums.VehicleLockState.Locked;
                        }
                        Globals.Main.AllVehicles.Add(vehClass);
                        Globals.Main.ReallifeVehicles.Add(vehClass);
                    }
                }

                return IVehicleList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }


        public static List<GangwarModel> LoadAllGWAreas()
        {
            try
            {

                List<GangwarModel> gwList = new List<GangwarModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM gangwar";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                GangwarModel area = new GangwarModel(reader);
                                if (area.aktiv == 1)
                                {
                                    gwList.Add(area);
                                }
                            }
                        }
                    }
                }

                return gwList;
            }
            catch { return new List<GangwarModel>(); }
        }


        public static int AddNewIVehicle(VehicleModel IVehicle)
        {
            try
            {
                int vehId = 0;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO Vehicles (model, posX, posY, posZ, rotX, rotY, rotZ, FirstColor, SecondColor, dimension, faction, owner, plate, gas) ";
                        command.CommandText += "VALUES (@model, @posX, @posY, @posZ, @rotX, @rotY, @rotZ, @FirstColor, @SecondColor, @dimension, @faction, @owner, @plate, @gas)";
                        command.Parameters.AddWithValue("@model", IVehicle.Name);
                        command.Parameters.AddWithValue("@posX", IVehicle.Position.X);
                        command.Parameters.AddWithValue("@posY", IVehicle.Position.Y);
                        command.Parameters.AddWithValue("@posZ", IVehicle.Position.Z);
                        Vector3 rot = IVehicle.Rotation;
                        command.Parameters.AddWithValue("@rotX", rot.X);
                        command.Parameters.AddWithValue("@rotY", rot.Y);
                        command.Parameters.AddWithValue("@rotZ", rot.Z);
                        command.Parameters.AddWithValue("@FirstColor", IVehicle.FirstColor);
                        command.Parameters.AddWithValue("@SecondColor", IVehicle.SecondColor);
                        command.Parameters.AddWithValue("@dimension", IVehicle.Dimension);
                        command.Parameters.AddWithValue("@faction", IVehicle.Faction);
                        command.Parameters.AddWithValue("@owner", IVehicle.Owner);
                        command.Parameters.AddWithValue("@plate", IVehicle.Plate);
                        command.Parameters.AddWithValue("@gas", IVehicle.Gas);
                        command.ExecuteNonQuery();
                        vehId = (int)command.LastInsertedId;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[EXCEPTION AddNewIVehicle] " + ex.Message);
                        Console.WriteLine("[EXCEPTION AddNewIVehicle] " + ex.StackTrace);
                    }
                }

                return vehId;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return 99999; }
        }

        public static int AddNewAdminTicket(AdminTickets ticket)
        {

            int vehId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO support (player, subject, message, state) ";
                    command.CommandText += "VALUES ( @playerName, @Betreff, @Frage, @Status)";
                    command.Parameters.AddWithValue("@playerName", ticket.playerName);
                    command.Parameters.AddWithValue("@Betreff", ticket.Betreff);
                    command.Parameters.AddWithValue("@Frage", "Spieler " + ticket.playerName + "[" + DateTime.Now + "]:" + ticket.Frage);
                    command.Parameters.AddWithValue("@Status", "open");


                    command.ExecuteNonQuery();
                    vehId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddNewAdminTicket] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddNewAdminTicket] " + ex.StackTrace);
                }
            }

            return vehId;
        }


        public static void UpdateIVehicleSingleString(string table, string value, int IVehicleId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE Vehicles SET " + table + " = @value WHERE id = @vehId LIMIT 1";
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@vehId", IVehicleId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateIVehicleSingleString] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateIVehicleSingleString] " + ex.StackTrace);
                }
            }
        }

        public static void SaveIVehicle(VehicleModel IVehicle)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE Vehicles SET posX = @posX, posY = @posY, posZ = @posZ, rotX = @rotX, rotY = @rotY, rotZ = @rotZ,";
                command.CommandText += "FirstColor = @FirstColor, SecondColor = @SecondColor, dimension = @dimension, ";
                command.CommandText += "faction = @faction, owner = @owner, plate = @plate, price = @price, ";
                command.CommandText += "gas = @gas, kms = @kms WHERE id = @vehId LIMIT 1";
                Vector3 rot = IVehicle.Rotation;
                command.Parameters.AddWithValue("@posX", IVehicle.Position.X);
                command.Parameters.AddWithValue("@posY", IVehicle.Position.Y);
                command.Parameters.AddWithValue("@posZ", IVehicle.Position.Z);
                command.Parameters.AddWithValue("@rotX", rot.X);
                command.Parameters.AddWithValue("@rotY", rot.Y);
                command.Parameters.AddWithValue("@rotZ", rot.Z);
                command.Parameters.AddWithValue("@FirstColor", IVehicle.FirstColor);
                command.Parameters.AddWithValue("@SecondColor", IVehicle.SecondColor);
                command.Parameters.AddWithValue("@dimension", IVehicle.Dimension);
                command.Parameters.AddWithValue("@faction", IVehicle.Faction);
                command.Parameters.AddWithValue("@owner", IVehicle.Owner);
                command.Parameters.AddWithValue("@plate", IVehicle.Plate);
                command.Parameters.AddWithValue("@price", IVehicle.Price);
                command.Parameters.AddWithValue("@gas", IVehicle.Gas);
                command.Parameters.AddWithValue("@kms", IVehicle.Kms);
                command.Parameters.AddWithValue("@vehId", IVehicle.ID);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveIVehicle] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveIVehicle] " + ex.StackTrace);
            }
        }

        public static void SaveAllIVehicles(List<VehicleModel> IVehicleList)
        {

            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE Vehicles SET posX = @posX, posY = @posY, posZ = @posZ, rotX = @rotX, rotY = @rotY, rotZ = @rotZ,";
                command.CommandText += "FirstColor = @FirstColor, SecondColor = @SecondColor, dimension = @dimension, ";
                command.CommandText += "faction = @faction, owner = @owner, plate = @plate, price = @price, ";
                command.CommandText += "gas = @gas, kms = @kms WHERE id = @vehId LIMIT 1";

                foreach (VehicleModel IVehicle in IVehicleList)
                {
                    command.Parameters.Clear();

                    Vector3 rot = IVehicle.SpawnRot;
                    command.Parameters.AddWithValue("@posX", IVehicle.SpawnCoord.X);
                    command.Parameters.AddWithValue("@posY", IVehicle.SpawnCoord.Y);
                    command.Parameters.AddWithValue("@posZ", IVehicle.SpawnCoord.Z);
                    command.Parameters.AddWithValue("@rotX", rot.X);
                    command.Parameters.AddWithValue("@rotY", rot.Y);
                    command.Parameters.AddWithValue("@rotZ", rot.Z);
                    command.Parameters.AddWithValue("@FirstColor", IVehicle.FirstColor);
                    command.Parameters.AddWithValue("@SecondColor", IVehicle.SecondColor);
                    command.Parameters.AddWithValue("@dimension", IVehicle.Dimension);
                    command.Parameters.AddWithValue("@faction", IVehicle.Faction);
                    command.Parameters.AddWithValue("@owner", IVehicle.Owner);
                    command.Parameters.AddWithValue("@plate", IVehicle.Plate);
                    command.Parameters.AddWithValue("@price", IVehicle.Price);
                    command.Parameters.AddWithValue("@gas", IVehicle.Gas);
                    command.Parameters.AddWithValue("@kms", IVehicle.Kms);
                    command.Parameters.AddWithValue("@vehId", IVehicle.ID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveAllIVehicles] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveAllIVehicles] " + ex.StackTrace);
            }
        }

        public static void RemoveIVehicle(int IVehicleId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM IVehicles WHERE id = @IVehicleId LIMIT 1";
                    command.Parameters.AddWithValue("@IVehicleId", IVehicleId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveIVehicle] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveIVehicle] " + ex.StackTrace);
                }
            }
        }


        public static List<TunningModel> LoadAllTunning()
        {
            try
            {
                List<TunningModel> tunningList = new List<TunningModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM tunning";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TunningModel tunning = new TunningModel();
                            {
                                tunning.id = reader.GetInt32("id");
                                tunning.IVehicle = reader.GetInt32("Vehicle");
                                tunning.slot = reader.GetInt32("slot");
                                tunning.component = reader.GetInt32("component");
                            }

                            tunningList.Add(tunning);
                        }
                    }
                }

                return tunningList;
            }
            catch { return null; }
        }

        public static int AddTunning(TunningModel tunning)
        {
            int tunningId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO tunning (IVehicle, slot, component) VALUES (@IVehicle, @slot, @component)";
                    command.Parameters.AddWithValue("@IVehicle", tunning.IVehicle);
                    command.Parameters.AddWithValue("@slot", tunning.slot);
                    command.Parameters.AddWithValue("@component", tunning.component);

                    command.ExecuteNonQuery();
                    tunningId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddTunning] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddTunning] " + ex.StackTrace);
                }
            }

            return tunningId;
        }

        public static void RemoveTunning(int IVehicleid, int slot)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM tunning WHERE IVehicle = @IVehicle AND slot = @slot LIMIT 1";
                    command.Parameters.AddWithValue("@IVehicle", IVehicleid);
                    command.Parameters.AddWithValue("@slot", slot);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveTunning] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveTunning] " + ex.StackTrace);
                }
            }
        }

        public static void TransferMoneyToPlayer(string name, int amount)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE users SET bank = bank + @amount WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", name);
                    command.Parameters.AddWithValue("@amount", amount);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION TransferMoneyToPlayer] " + ex.Message);
                    Console.WriteLine("[EXCEPTION TransferMoneyToPlayer] " + ex.StackTrace);
                }
            }
        }



        public static List<ItemModel> LoadAllItems()
        {
            try
            {
                List<ItemModel> itemList = new List<ItemModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM items";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemModel item = new ItemModel();
                            float posX = reader.GetFloat("posX");
                            float posY = reader.GetFloat("posY");
                            float posZ = reader.GetFloat("posZ");

                            item.id = reader.GetInt32("id");
                            item.hash = reader.GetString("hash");
                            item.ownerIdentifier = reader.GetInt32("ownerIdentifier");
                            item.amount = reader.GetInt32("amount");
                            item.position = new Position(posX, posY, posZ);
                            item.dimension = reader.GetInt32("dimension");
                            item.ITEM_ART = reader.GetString("ITEM_ART");

                            itemList.Add(item);
                        }
                    }
                }

                return itemList;
            }
            catch { return null; }
        }
        public static List<AccountModel> LoadAllAccounts()
        {
            try
            {
                List<AccountModel> accountList = new List<AccountModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM spieler";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AccountModel account = new AccountModel
                        {
                            UID = reader.GetInt32("UID"),
                            HardwareId = reader.GetString("HardwareIdHash"),
                            HardwareIdExhash = reader.GetString("HardwareIdExHash"),
                            Name = reader.GetString("SpielerName"),
                            Password = reader.GetString("Passwort"),
                            SocialID = reader.GetString("SpielerSocial")
                        };
                        accountList.Add(account);
                    }
                }
                return accountList;
            }
            catch { return null; }
        }
        public static List<CharacterModel> LoadAllCharacterSkins()
        {
            try
            {
                List<CharacterModel> characterList = new List<CharacterModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM skins";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CharacterModel ccharacter = new CharacterModel
                        {
                            UID = reader.GetInt32("UID"),
                            FaceFeatures = reader.GetString("facefeatures"),
                            HeadBlendData = reader.GetString("headblends"),
                            HeadOverlays = reader.GetString("headoverlays")
                        };
                        characterList.Add(ccharacter);
                    }
                }
                return characterList;
            }
            catch { return null; }
        }

        public static int AddNewItem(ItemModel item)
        {
            int itemId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO `items` (`hash`, `ownerIdentifier`, `amount`, `posX`, `posY`, `posZ`, `ITEM_ART`)";
                    command.CommandText += " VALUES (@hash, @ownerIdentifier, @amount, @posX, @posY, @posZ, @ITEM_ART)";
                    command.Parameters.AddWithValue("@hash", item.hash);
                    command.Parameters.AddWithValue("@ownerIdentifier", item.ownerIdentifier);
                    command.Parameters.AddWithValue("@amount", item.amount);
                    command.Parameters.AddWithValue("@posX", item.position.X);
                    command.Parameters.AddWithValue("@posY", item.position.Y);
                    command.Parameters.AddWithValue("@posZ", item.position.Z);
                    command.Parameters.AddWithValue("@ITEM_ART", item.ITEM_ART);

                    command.ExecuteNonQuery();
                    itemId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddNewItem] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddNewItem] " + ex.StackTrace);
                }
            }

            return itemId;
        }

        public static void UpdateItem(ItemModel item)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE `items` SET `ownerIdentifier` = @ownerIdentifier, `amount` = @amount, ";
                    command.CommandText += "`posX` = @posX, `posY` = @posY, `posZ` = @posZ, `dimension` = @dimension, ITEM_ART = @ITEM_ART WHERE `id` = @id LIMIT 1";
                    command.Parameters.AddWithValue("@ownerIdentifier", item.ownerIdentifier);
                    command.Parameters.AddWithValue("@amount", item.amount);
                    command.Parameters.AddWithValue("@posX", item.position.X);
                    command.Parameters.AddWithValue("@posY", item.position.Y);
                    command.Parameters.AddWithValue("@posZ", item.position.Z);
                    command.Parameters.AddWithValue("@dimension", item.dimension);
                    command.Parameters.AddWithValue("@ITEM_ART", item.ITEM_ART);
                    command.Parameters.AddWithValue("@id", item.id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateItem] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateItem] " + ex.StackTrace);
                }
            }
        }

        public static void RemoveItem(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM items WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveItem] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveItem] " + ex.StackTrace);
                }
            }
        }

        public static async void RemoveAllItemsByArt(int SQLID, string ItemArt)
        {
            try
            {
                await Task.Run(() =>
                {
                    using MySqlConnection connection = new MySqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();

                        command.CommandText = "DELETE FROM items WHERE ITEM_ART = @ITEM_ART AND ownerIdentifier = @ownerIdentifier";
                        command.Parameters.AddWithValue("@ownerIdentifier", SQLID);
                        command.Parameters.AddWithValue("@ITEM_ART", ItemArt);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[EXCEPTION RemoveAllItemsByArt] " + ex.Message);
                        Console.WriteLine("[EXCEPTION RemoveAllItemsByArt] " + ex.StackTrace);
                    }
                });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void RemoveAllItems(int SQLID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM items WHERE ownerIdentifier = @ownerIdentifier";
                    command.Parameters.AddWithValue("@ownerIdentifier", SQLID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION RemoveAllItems] " + ex.Message);
                    Console.WriteLine("[EXCEPTION RemoveAllItems] " + ex.StackTrace);
                }
            }
        }


        public static List<BusinessModel> LoadAllBusiness()
        {
            try
            {
                List<BusinessModel> businessList = new List<BusinessModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM business";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BusinessModel business = new BusinessModel();
                            float posX = reader.GetFloat("posX");
                            float posY = reader.GetFloat("posY");
                            float posZ = reader.GetFloat("posZ");

                            business.id = reader.GetInt32("id");
                            business.type = reader.GetInt32("type");
                            business.ipl = reader.GetString("ipl");
                            business.name = reader.GetString("Name");
                            business.position = new Position(posX, posY, posZ);
                            business.Dimension = reader.GetInt32("dimension");
                            business.owner = reader.GetString("owner");
                            business.multiplier = reader.GetFloat("multiplier");
                            business.locked = reader.GetBoolean("locked");

                            businessList.Add(business);
                        }
                    }
                }

                return businessList;
            }
            catch { return null; }
        }

        public static void UpdateBusiness(BusinessModel business)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE business SET type = @type, ipl = @ipl, posX = @posX, posY = @posY, posZ = @posZ, dimension = @dimension, name = @name, ";
                    command.CommandText += "owner = @owner, funds = @funds, products = @products, multiplier = @multiplier, locked = @locked WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@type", business.type);
                    command.Parameters.AddWithValue("@ipl", business.ipl);
                    command.Parameters.AddWithValue("@posX", business.position.X);
                    command.Parameters.AddWithValue("@posY", business.position.Y);
                    command.Parameters.AddWithValue("@posZ", business.position.Z);
                    command.Parameters.AddWithValue("@dimension", business.Dimension);
                    command.Parameters.AddWithValue("@name", business.name);
                    command.Parameters.AddWithValue("@owner", business.owner);
                    command.Parameters.AddWithValue("@funds", business.funds);
                    command.Parameters.AddWithValue("@products", business.products);
                    command.Parameters.AddWithValue("@multiplier", business.multiplier);
                    command.Parameters.AddWithValue("@locked", business.locked);
                    command.Parameters.AddWithValue("@id", business.id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateBusiness] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateBusiness] " + ex.StackTrace);
                }
            }
        }

        public static void UpdateAllBusiness(List<BusinessModel> businessList)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE business SET type = @type, ipl = @ipl, posX = @posX, posY = @posY, posZ = @posZ, dimension = @dimension, name = @name, ";
                    command.CommandText += "owner = @owner, funds = @funds, products = @products, multiplier = @multiplier, locked = @locked WHERE id = @id LIMIT 1";

                    foreach (BusinessModel business in businessList)
                    {
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@type", business.type);
                        command.Parameters.AddWithValue("@ipl", business.ipl);
                        command.Parameters.AddWithValue("@posX", business.position.X);
                        command.Parameters.AddWithValue("@posY", business.position.Y);
                        command.Parameters.AddWithValue("@posZ", business.position.Z);
                        command.Parameters.AddWithValue("@dimension", business.Dimension);
                        command.Parameters.AddWithValue("@name", business.name);
                        command.Parameters.AddWithValue("@owner", business.owner);
                        command.Parameters.AddWithValue("@funds", business.funds);
                        command.Parameters.AddWithValue("@products", business.products);
                        command.Parameters.AddWithValue("@multiplier", business.multiplier);
                        command.Parameters.AddWithValue("@locked", business.locked);
                        command.Parameters.AddWithValue("@id", business.id);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateAllBusiness] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateAllBusiness] " + ex.StackTrace);
                }
            }
        }

        public static int AddNewBusiness(BusinessModel business)
        {
            int businessId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO business (type, ipl, posX, posY, posZ, dimension) VALUES (@type, @ipl, @posX, @posY, @posZ, @dimension)";
                    command.Parameters.AddWithValue("@type", business.type);
                    command.Parameters.AddWithValue("@ipl", business.ipl);
                    command.Parameters.AddWithValue("@posX", business.position.X);
                    command.Parameters.AddWithValue("@posY", business.position.Y);
                    command.Parameters.AddWithValue("@posZ", business.position.Z);
                    command.Parameters.AddWithValue("@dimension", business.Dimension);

                    command.ExecuteNonQuery();
                    businessId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddNewBusiness] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddNewBusiness] " + ex.StackTrace);
                }
            }

            return businessId;
        }

        public static void DeleteBusiness(int businessId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM business WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@id", businessId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddNewBusiness] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddNewBusiness] " + ex.StackTrace);
                }
            }
        }

        public static List<HouseModel> LoadAllHouses()
        {
            try
            {
                List<HouseModel> houseList = new List<HouseModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM houses";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        HouseModel house = new HouseModel();
                        float posX = reader.GetFloat("posX");
                        float posY = reader.GetFloat("posY");
                        float posZ = reader.GetFloat("posZ");

                        house.id = reader.GetInt32("id");
                        house.ipl = reader.GetString("ipl");
                        house.name = reader.GetString("Name");
                        house.position = new Position(posX, posY, posZ);
                        house.Dimension = reader.GetInt32("dimension");
                        house.price = reader.GetInt32("price");
                        house.owner = reader.GetString("owner");
                        house.status = reader.GetInt32("status");
                        house.tenants = reader.GetInt32("tenants");
                        house.rental = reader.GetInt32("rental");
                        house.locked = reader.GetBoolean("locked");

                        houseList.Add(house);
                    }
                }

                return houseList;
            }
            catch { return null; }
        }

        public static int AddHouse(HouseModel house)
        {
            int houseId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO houses (ipl, posX, posY, posZ, dimension, name, price) VALUES (@ipl, @posX, @posY, @posZ, @dimension, @name, @preis)";
                    command.Parameters.AddWithValue("@ipl", house.ipl);
                    command.Parameters.AddWithValue("@posX", house.position.X);
                    command.Parameters.AddWithValue("@posY", house.position.Y);
                    command.Parameters.AddWithValue("@posZ", house.position.Z);
                    command.Parameters.AddWithValue("@dimension", house.Dimension);
                    command.Parameters.AddWithValue("@name", house.name);
                    command.Parameters.AddWithValue("@preis", house.price);

                    command.ExecuteNonQuery();
                    houseId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddHouse] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddHouse] " + ex.StackTrace);
                }
            }

            return houseId;
        }

        public static void UpdateHouse(HouseModel house)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE houses SET ipl = @ipl, posX = @posX, posY = @posY, posZ = @posZ, dimension = @dimension, name = @name, price = @price, ";
                    command.CommandText += "owner = @owner, status = @status, tenants = @tenants, rental = @rental, locked = @locked WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@ipl", house.ipl);
                    command.Parameters.AddWithValue("@posX", house.position.X);
                    command.Parameters.AddWithValue("@posY", house.position.Y);
                    command.Parameters.AddWithValue("@posZ", house.position.Z);
                    command.Parameters.AddWithValue("@dimension", house.Dimension);
                    command.Parameters.AddWithValue("@name", house.name);
                    command.Parameters.AddWithValue("@price", house.price);
                    command.Parameters.AddWithValue("@owner", house.owner);
                    command.Parameters.AddWithValue("@status", house.status);
                    command.Parameters.AddWithValue("@tenants", house.tenants);
                    command.Parameters.AddWithValue("@rental", house.rental);
                    command.Parameters.AddWithValue("@locked", house.locked);
                    command.Parameters.AddWithValue("@id", house.id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateHouse] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateHouse] " + ex.StackTrace);
                }
            }
        }

        public static void DeleteHouse(int houseId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM houses WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@id", houseId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION DeleteHouse] " + ex.Message);
                    Console.WriteLine("[EXCEPTION DeleteHouse] " + ex.StackTrace);
                }
            }
        }

        public static void KickTenantsOut(int houseId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE users SET houseRent = 0 where houseRent = @houseRent";
                    command.Parameters.AddWithValue("@houseRent", houseId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION KickTenantsOut] " + ex.Message);
                    Console.WriteLine("[EXCEPTION KickTenantsOut] " + ex.StackTrace);
                }
            }
        }

        public static List<ClothesModel> LoadAllClothes()
        {
            try
            {
                List<ClothesModel> clothesList = new List<ClothesModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM clothes";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClothesModel clothes = new ClothesModel();
                            clothes.id = reader.GetInt32("id");
                            clothes.player = reader.GetInt32("player");
                            clothes.type = reader.GetInt32("type");
                            clothes.slot = reader.GetInt32("slot");
                            clothes.drawable = reader.GetInt32("drawable");
                            clothes.texture = reader.GetInt32("texture");
                            clothes.dressed = reader.GetBoolean("dressed");

                            clothesList.Add(clothes);
                        }
                    }
                }

                return clothesList;
            }
            catch { return null; }
        }

        public static int AddClothes(ClothesModel clothes)
        {
            int clothesId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO clothes (player, type, slot, drawable, texture, dressed) VALUES (@player, @type, @slot, @drawable, @texture, @dressed)";
                    command.Parameters.AddWithValue("@player", clothes.player);
                    command.Parameters.AddWithValue("@type", clothes.type);
                    command.Parameters.AddWithValue("@slot", clothes.slot);
                    command.Parameters.AddWithValue("@drawable", clothes.drawable);
                    command.Parameters.AddWithValue("@texture", clothes.texture);
                    command.Parameters.AddWithValue("@dressed", clothes.dressed);

                    command.ExecuteNonQuery();

                    clothesId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddClothes] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddClothes] " + ex.StackTrace);
                }
            }

            return clothesId;
        }

        public static void UpdateClothes(ClothesModel clothes)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE clothes SET dressed = @dressed WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@dressed", clothes.dressed);
                    command.Parameters.AddWithValue("@id", clothes.id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateClothes] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateClothes] " + ex.StackTrace);
                }
            }
        }

        public static List<FactionAllroundModel> LoadAllFactionDatas()
        {
            try
            {
                List<FactionAllroundModel> FactionDataList = new List<FactionAllroundModel>();
                for (int i = 0; i <= 13; i++)
                {
                    foreach (WaffenlagerModel _WaffenLager in Fraktionswaffenlager.WaffenlagerList.ToList())
                    {
                        if (_WaffenLager.Faction == i)
                            RefreshWaffenlager(_WaffenLager);
                    }
                    FactionAllroundModel currentFaction = new FactionAllroundModel()
                    {
                        FID = i,
                        Kasse = GetFactionStats(i),
                        Waffenlager = Fraktionswaffenlager.GetWaffenlagerById(i)
                    };
                    Core.Debug.OutputDebugString("[" + i + "] FactionDataList-Loaded!");
                }
                return FactionDataList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }

        }
        public static List<TattooModel> LoadAllTattoos()
        {
            try
            {
                List<TattooModel> tattooList = new List<TattooModel>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM tattoos";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TattooModel tattoo = new TattooModel();
                            tattoo.player = reader.GetInt32("player");
                            tattoo.slot = reader.GetInt32("zone");
                            tattoo.library = reader.GetString("library");
                            tattoo.hash = reader.GetString("hash");

                            tattooList.Add(tattoo);
                        }
                    }
                }

                return tattooList;
            }
            catch { return null; }

        }

        public static bool AddTattoo(TattooModel tattoo)
        {
            try
            {
                bool inserted = false;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();

                        command.CommandText = "INSERT INTO tattoos (player, zone, library, hash) VALUES (@player, @zone, @library, @hash)";
                        command.Parameters.AddWithValue("@player", tattoo.player);
                        command.Parameters.AddWithValue("@zone", tattoo.slot);
                        command.Parameters.AddWithValue("@library", tattoo.library);
                        command.Parameters.AddWithValue("@hash", tattoo.hash);

                        command.ExecuteNonQuery();
                        inserted = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[EXCEPTION AddTattoo] " + ex.Message);
                        Console.WriteLine("[EXCEPTION AddTattoo] " + ex.StackTrace);
                    }
                }

                return inserted;
            }
            catch { return false; }
        }




        public static void AddAdminLog(string admin, string player, string action, int time, string reason)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO admin (source, target, action, time, reason, date) VALUES (@source, @target, @action, @time, @reason, NOW())";
                    command.Parameters.AddWithValue("@source", admin);
                    command.Parameters.AddWithValue("@target", player);
                    command.Parameters.AddWithValue("@action", action);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@reason", reason);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddAdminLog] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddAdminLog] " + ex.StackTrace);
                }
            }
        }

        public static void AddLicensedWeapon(int itemId, string buyer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO licensed (item, buyer, date) VALUES (@item, @buyer, NOW())";
                    command.Parameters.AddWithValue("@item", itemId);
                    command.Parameters.AddWithValue("@buyer", buyer);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddLicensedWeapon] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddLicensedWeapon] " + ex.StackTrace);
                }
            }
        }


        public static void AddPlayerToPrison(int UID, string SpielerName, int PrisonZeit, string PrisonGrund, string Admin, DateTime PrisonErstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO prison (UID, SpielerName, PrisonZeit, PrisonGrund, PrisonVon, PrisonErstelltAm) VALUES (@UID, @SpielerName, @PrisonZeit, @PrisonGrund, @PrisonVon, @PrisonErstelltAm)";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@SpielerName", SpielerName);
                    command.Parameters.AddWithValue("@PrisonZeit", PrisonZeit);
                    command.Parameters.AddWithValue("@PrisonGrund", PrisonGrund);
                    command.Parameters.AddWithValue("@PrisonVon", Admin);
                    command.Parameters.AddWithValue("@PrisonErstelltAm", PrisonErstelltAm);


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddPlayerToPrison] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddPlayerToPrison] " + ex.StackTrace);
                }
            }
        }


        public static void AddPlayerPermaBan(int UID, string Username, string HardwareId, string HardwareIdExHash, string SocialClubId, string IP, string DiscordID, string Reason, string Admin)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO ban (UID, Name, HardwareId, HardwareIdExHash, SocialClubId, IP, DiscordID, Reason, Admin, BannedTill, BanDateCreated, Bantype) VALUES (@UID, @Name, @HardwareId, @HardwareIdExHash, @SocialClubId, @IP, @DiscordID, @Reason, @Admin, @BannedTill, @BanDateCreated, @Bantype)";
                command.Parameters.AddWithValue("@UID", UID);
                command.Parameters.AddWithValue("@Name", Username);
                command.Parameters.AddWithValue("@HardwareId", HardwareId);
                command.Parameters.AddWithValue("@HardwareIdExHash", HardwareIdExHash);
                command.Parameters.AddWithValue("@SocialClubId", SocialClubId);
                command.Parameters.AddWithValue("@IP", IP);
                command.Parameters.AddWithValue("@DiscordID", DiscordID);
                command.Parameters.AddWithValue("@Reason", Reason);
                command.Parameters.AddWithValue("@Admin", Admin);
                command.Parameters.AddWithValue("@BannedTill", DateTime.Now);
                command.Parameters.AddWithValue("@BanDateCreated", DateTime.Now);
                command.Parameters.AddWithValue("@Bantype", "Permaban");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.Message);
                Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.StackTrace);
            }
        }
        public static void AddPlayerTimeBan(int UID, string SpielerSocial, string serial, string Bangrund, string Admin, DateTime Banzeit, DateTime BannerstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO ban (UID, SpielerSocial, serial, Bangrund, Admin, Banzeit, BanerstelltAm, Bantype) VALUES (@UID, @SpielerSocial, @serial, @Bangrund, @Admin, @Banzeit, @BanerstelltAm, @Bantype)";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@SpielerSocial", SpielerSocial);
                    command.Parameters.AddWithValue("@serial", serial);
                    command.Parameters.AddWithValue("@Bangrund", Bangrund);
                    command.Parameters.AddWithValue("@Admin", Admin);
                    command.Parameters.AddWithValue("@Banzeit", Banzeit);
                    command.Parameters.AddWithValue("@BanerstelltAm", BannerstelltAm);
                    command.Parameters.AddWithValue("@Bantype", "Timeban");


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.StackTrace);
                }
            }
        }
        public static void UpdatePlayerTimeBan(int UID, string Bangrund, string Admin, DateTime Banzeit, DateTime BannerstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE ban SET Bangrund = @Bangrund, Admin = @Admin, Banzeit = @Banzeit, BannerstelltAm = @BannerstelltAm  WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@Bangrund", Bangrund);
                    command.Parameters.AddWithValue("@Admin", Admin);
                    command.Parameters.AddWithValue("@Banzeit", Banzeit);
                    command.Parameters.AddWithValue("@BannerstelltAm", BannerstelltAm);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdatePlayerTimeBan] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdatePlayerTimeBan] " + ex.StackTrace);
                }
            }
        }

        public static void UpdatePlayerPrisonTime(int UID, int PrisonZeit, string PrisonGrund, string PrisonVon, DateTime PrisonErstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE prison SET PrisonZeit = @PrisonZeit, PrisonGrund = @PrisonGrund, PrisonVon = @PrisonVon, PrisonErstelltAm = @PrisonErstelltAm  WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@PrisonZeit", PrisonZeit);
                    command.Parameters.AddWithValue("@PrisonGrund", PrisonGrund);
                    command.Parameters.AddWithValue("@PrisonVon", PrisonVon);
                    command.Parameters.AddWithValue("@PrisonErstelltAm", PrisonErstelltAm);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdatePlayerPrisonTime] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdatePlayerPrisonTime] " + ex.StackTrace);
                }
            }
        }

        public static void UpdateGW(GangwarArea area)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE gangwar SET FID = @facId, cooldown = @areaCD WHERE gang_area = @areaName LIMIT 1";
                    command.Parameters.AddWithValue("@facId", area.IDOwner);
                    command.Parameters.AddWithValue("@areaCD", area.Cooldown);
                    command.Parameters.AddWithValue("@areaName", area.Name);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateGW] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateGW] " + ex.StackTrace);
                }
            }
        }

    }
}