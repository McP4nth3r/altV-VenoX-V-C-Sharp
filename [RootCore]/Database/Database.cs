using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using MySql.Data.MySqlClient;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.gangwar.v2;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Preload_;
using VenoXV._Preload_.Character_Creator;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Inventory = VenoXV._Globals_.Inventory.Inventory;
using Main = VenoXV._Preload_.Character_Creator.Main;
using VehicleModel = VenoXV.Models.VehicleModel;

namespace VenoXV.Database
{
    public class Database : IScript
    {

        private static string _connectionString;

        public static async void OnResourceStart()
        {
            // Set the encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            const string host = "185.240.243.29";
            const string user = "VenoXV_Security";
            const string pass = "0Ux1k^x8k30vDx2*1g0dOt9@";
            const string db = "VenoXV_Security";
            _connectionString = "SERVER=" + host + "; DATABASE=" + db + "; UID=" + user + "; PASSWORD=" + pass + "; SSLMODE=none;";
            GangwarManager.DatabaseConnectionCreated = true;
            await Task.Run(async () =>
            {
                await AltAsync.Do(() =>
                {
                    Admin.PlayerBans = LoadPlayerBans();
                    Debug.OutputDebugString(Admin.PlayerBans.Count + " Bans wurden geladen...");
                    //Load Accounts
                    Register.AccountList = LoadAllAccounts();
                    Debug.OutputDebugString(Register.AccountList.Count + " Accounts wurden geladen...");

                    //Char-Creator Accounts loading.
                    Main.CharacterSkins = LoadAllCharacterSkins();

                    // House loading
                    House.LoadDatabaseHouses();

                    // Tunning loading
                    _Gamemodes_.Reallife.Globals.Main.TunningList = LoadAllTunning();

                    // IVehicle loading
                    LoadAllVehicles();

                    // Item loading
                    Inventory.DatabaseItems = LoadAllItems();

                    // Clothes loading
                    _Gamemodes_.Reallife.Globals.Main.ClothesList = LoadAllClothes();

                    // Tattoos loading
                    _Gamemodes_.Reallife.Globals.Main.TattooList = LoadAllTattoos();

                    _Gamemodes_.Reallife.Globals.Main.FactionAllroundList = LoadAllFactionDatas();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Database Connection = OK.");
                    Console.ResetColor();
                });
            });
        }


        public static FraktionsKassen GetFactionStats(int factionId)
        {
            try
            {
                FraktionsKassen fraktion = new FraktionsKassen();
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT FRAKTION_MONEY, FRAKTION_WEED, FRAKTION_MATS,FRAKTION_KOKAIN FROM fraktionskassen WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                    command.Parameters.AddWithValue("@FRAKTION_ID", factionId);
                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        fraktion.Weed = reader.GetInt32("FRAKTION_WEED");
                        fraktion.Koks = reader.GetInt32("FRAKTION_KOKAIN");
                        fraktion.Mats = reader.GetInt32("FRAKTION_MATS");
                        fraktion.Money = reader.GetInt32("FRAKTION_MONEY");
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

        public static void RefreshWaffenlager(WaffenlagerModel waffenlager)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM fraktionslager WHERE FID = @FID LIMIT 1";
                command.Parameters.AddWithValue("@FID", waffenlager.Faction);
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    waffenlager.WeaponKnuckle.Amount = reader.GetInt32("weapon_knuckle");
                    waffenlager.WeaponNightstick.Amount = reader.GetInt32("weapon_nightstick");
                    waffenlager.WeaponBaseball.Amount = reader.GetInt32("weapon_baseball");
                    waffenlager.WeaponTazer.Amount = reader.GetInt32("weapon_stungun");
                    waffenlager.WeaponPistol50.Amount = reader.GetInt32("weapon_pistol50");
                    waffenlager.WeaponPistol50Ammo.Amount = reader.GetInt32("weapon_pistol50_ammo");
                    waffenlager.WeaponRevolver.Amount = reader.GetInt32("weapon_revolver");
                    waffenlager.WeaponRevolverAmmo.Amount = reader.GetInt32("weapon_revolver_ammo");
                    waffenlager.WeaponPistol.Amount = reader.GetInt32("weapon_pistol");
                    waffenlager.WeaponPistolAmmo.Amount = reader.GetInt32("weapon_pistol_ammo");
                    waffenlager.WeaponCombatpdw.Amount = reader.GetInt32("weapon_combatpdw");
                    waffenlager.WeaponCombatpdwAmmo.Amount = reader.GetInt32("weapon_combatpdw_ammo");
                    waffenlager.WeaponMp5.Amount = reader.GetInt32("weapon_mp5");
                    waffenlager.WeaponMp5Ammo.Amount = reader.GetInt32("weapon_mp5_ammo");
                    waffenlager.WeaponPumpshotgun.Amount = reader.GetInt32("weapon_pumpshotgun");
                    waffenlager.WeaponPumpshotgunAmmo.Amount = reader.GetInt32("weapon_pumpshotgun_ammo");
                    waffenlager.WeaponAssaultrifle.Amount = reader.GetInt32("weapon_assaultrifle");
                    waffenlager.WeaponAssaultrifleAmmo.Amount = reader.GetInt32("weapon_assaultrifle_ammo");
                    waffenlager.WeaponAdvancedrifle.Amount = reader.GetInt32("weapon_advancedrifle");
                    waffenlager.WeaponAdvancedrifleAmmo.Amount = reader.GetInt32("weapon_advancedrifle_ammo");
                    waffenlager.WeaponRifle.Amount = reader.GetInt32("weapon_rifle");
                    waffenlager.WeaponRifleAmmo.Amount = reader.GetInt32("weapon_rifle_ammo");
                    waffenlager.WeaponCarbinerifle.Amount = reader.GetInt32("weapon_carbinerifle");
                    waffenlager.WeaponCarbinerifleAmmo.Amount = reader.GetInt32("weapon_carbinerifle_ammo");
                    waffenlager.WeaponGusenberg.Amount = reader.GetInt32("weapon_gusenberg");
                    waffenlager.WeaponGusenbergAmmo.Amount = reader.GetInt32("weapon_gusenberg_ammo");
                    waffenlager.WeaponSniperrifle.Amount = reader.GetInt32("weapon_sniperrifle");
                    waffenlager.WeaponSniperrifleAmmo.Amount = reader.GetInt32("weapon_sniperrifle_ammo");
                    waffenlager.WeaponRpg.Amount = reader.GetInt32("weapon_rpg");
                    waffenlager.WeaponRpgAmmo.Amount = reader.GetInt32("weapon_rpg_ammo");
                    waffenlager.WeaponMolotov.Amount = reader.GetInt32("weapon_molotov");
                    waffenlager.WeaponSmokegrenade.Amount = reader.GetInt32("weapon_smokegrenade");
                    waffenlager.WeaponBzgas.Amount = reader.GetInt32("weapon_bzgas");
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void SetFactionWeaponlager(int factionId, int weaponKnuckle, int weaponNightstick, int weaponBaseball, int weaponStungun, int weaponPistol, int weaponPistol50,
            int weaponRevolver, int weaponPumpshotgun, int weaponCombatpdw, int weaponMp5, int weaponAssaultrifle, int weaponCarbinerifle, int weaponAdvancedrifle,
            int weaponGusenberg, int weaponRifle, int weaponSniperrifle, int weaponRpg, int weaponBzgas, int weaponMolotov, int weaponSmokegrenade, int weaponPistolAmmo, int weaponPistol50Ammo, int weaponRevolverAmmo, int weaponPumpshotgunAmmo, int weaponCombatpdwAmmo, int weaponMp5Ammo, int weaponAssaultrifleAmmo,
            int weaponCarbinerifleAmmo, int weaponAdvancedrifleAmmo, int weaponGusenbergAmmo, int weaponRifleAmmo, int weaponSniperrifleAmmo, int weaponRpgAmmo)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE fraktionslager SET weapon_knuckle = @weapon_knuckle, weapon_nightstick = @weapon_nightstick, weapon_baseball = @weapon_baseball, weapon_stungun = @weapon_stungun, " +
                "weapon_pistol50 = @weapon_pistol50, weapon_pistol50_ammo = @weapon_pistol50_ammo, weapon_revolver = @weapon_revolver, weapon_revolver_ammo = @weapon_revolver_ammo, weapon_pistol = @weapon_pistol ,weapon_pistol_ammo = @weapon_pistol_ammo, weapon_mp5 = @weapon_mp5, weapon_mp5_ammo = @weapon_mp5_ammo, weapon_combatpdw = @weapon_combatpdw, weapon_combatpdw_ammo = @weapon_combatpdw_ammo, weapon_pumpshotgun = @weapon_pumpshotgun, weapon_pumpshotgun_ammo = @weapon_pumpshotgun_ammo, " +
                "weapon_assaultrifle = @weapon_assaultrifle, weapon_assaultrifle_ammo = @weapon_assaultrifle_ammo, weapon_carbinerifle = @weapon_carbinerifle,weapon_carbinerifle_ammo = @weapon_carbinerifle_ammo,  weapon_advancedrifle = @weapon_advancedrifle, weapon_advancedrifle_ammo = @weapon_advancedrifle_ammo, weapon_gusenberg = @weapon_gusenberg, weapon_gusenberg_ammo = @weapon_gusenberg_ammo, weapon_rifle = @weapon_rifle, weapon_rifle_ammo = @weapon_rifle_ammo, weapon_sniperrifle = @weapon_sniperrifle, weapon_sniperrifle_ammo = @weapon_sniperrifle_ammo,  " +
                "weapon_rpg = @weapon_rpg, weapon_rpg_ammo = @weapon_rpg_ammo, weapon_molotov = @weapon_molotov, weapon_smokegrenade = @weapon_smokegrenade, weapon_bzgas = @weapon_bzgas  " +
                "WHERE FID = @FID LIMIT 1";
                command.Parameters.AddWithValue("@FID", factionId);

                command.Parameters.AddWithValue("@weapon_knuckle", weaponKnuckle);
                command.Parameters.AddWithValue("@weapon_nightstick", weaponNightstick);
                command.Parameters.AddWithValue("@weapon_baseball", weaponBaseball);
                command.Parameters.AddWithValue("@weapon_stungun", weaponStungun);
                command.Parameters.AddWithValue("@weapon_pistol50", weaponPistol50);
                command.Parameters.AddWithValue("@weapon_pistol50_ammo", weaponPistol50Ammo);
                command.Parameters.AddWithValue("@weapon_revolver", weaponRevolver);
                command.Parameters.AddWithValue("@weapon_revolver_ammo", weaponRevolverAmmo);
                command.Parameters.AddWithValue("@weapon_pistol", weaponPistol);
                command.Parameters.AddWithValue("@weapon_pistol_ammo", weaponPistolAmmo);
                command.Parameters.AddWithValue("@weapon_mp5", weaponMp5);
                command.Parameters.AddWithValue("@weapon_mp5_ammo", weaponMp5Ammo);
                command.Parameters.AddWithValue("@weapon_combatpdw", weaponCombatpdw);
                command.Parameters.AddWithValue("@weapon_combatpdw_ammo", weaponCombatpdwAmmo);
                command.Parameters.AddWithValue("@weapon_pumpshotgun", weaponPumpshotgun);
                command.Parameters.AddWithValue("@weapon_pumpshotgun_ammo", weaponPumpshotgunAmmo);
                command.Parameters.AddWithValue("@weapon_assaultrifle", weaponAssaultrifle);
                command.Parameters.AddWithValue("@weapon_assaultrifle_ammo", weaponAssaultrifleAmmo);
                command.Parameters.AddWithValue("@weapon_carbinerifle", weaponCarbinerifle);
                command.Parameters.AddWithValue("@weapon_carbinerifle_ammo", weaponCarbinerifleAmmo);
                command.Parameters.AddWithValue("@weapon_advancedrifle", weaponAdvancedrifle);
                command.Parameters.AddWithValue("@weapon_advancedrifle_ammo", weaponAdvancedrifleAmmo);
                command.Parameters.AddWithValue("@weapon_gusenberg", weaponGusenberg);
                command.Parameters.AddWithValue("@weapon_gusenberg_ammo", weaponGusenbergAmmo);
                command.Parameters.AddWithValue("@weapon_rifle", weaponRifle);
                command.Parameters.AddWithValue("@weapon_rifle_ammo", weaponRifleAmmo);
                command.Parameters.AddWithValue("@weapon_sniperrifle", weaponSniperrifle);
                command.Parameters.AddWithValue("@weapon_sniperrifle_ammo", weaponSniperrifleAmmo);
                command.Parameters.AddWithValue("@weapon_rpg", weaponRpg);
                command.Parameters.AddWithValue("@weapon_rpg_ammo", weaponRpgAmmo);
                command.Parameters.AddWithValue("@weapon_molotov", weaponMolotov);
                command.Parameters.AddWithValue("@weapon_smokegrenade", weaponSmokegrenade);
                command.Parameters.AddWithValue("@weapon_bzgas", weaponBzgas);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SetFactionWeaponlager] " + ex.Message);
                Console.WriteLine("[EXCEPTION SetFactionWeaponlager] " + ex.StackTrace);
            }
        }

        public static void SetFactionStats(int factionId, int money, int weed, int koks, int mats)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                //command.CommandText = "INSERT INTO fraktionskassen FRAKTION_MONEY, FRAKTION_WEED, FRAKTION_MATS,FRAKTION_KOKAIN FROM fraktionskassen WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                command.CommandText = "UPDATE fraktionskassen SET FRAKTION_MONEY = @FRAKTION_MONEY, FRAKTION_WEED = @FRAKTION_WEED, FRAKTION_MATS = @FRAKTION_MATS, FRAKTION_KOKAIN = @FRAKTION_KOKAIN  WHERE FRAKTION_ID = @FRAKTION_ID LIMIT 1";
                command.Parameters.AddWithValue("@FRAKTION_ID", factionId);
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


        public static void ChangeUserPasswort(string spielername, string password)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE spieler SET Passwort = @Passwort WHERE SpielerName = @SpielerName";
                command.Parameters.AddWithValue("@SpielerName", spielername);
                command.Parameters.AddWithValue("@Passwort", password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void UpdatePlayerLanguage(int uid, string language)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE spieler SET Language = @Language WHERE UID = @UID";
                command.Parameters.AddWithValue("@UID", uid);
                command.Parameters.AddWithValue("@Language", language);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        public static void UpdateDiscordInformations(string spielername, string discordId, string discordAvatar)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE spieler SET DiscordID = @DiscordID, DiscordAvatar = @DiscordAvatar WHERE SpielerName = @SpielerName";
                command.Parameters.AddWithValue("@Spielername", spielername);
                command.Parameters.AddWithValue("@DiscordID", discordId);
                command.Parameters.AddWithValue("@DiscordAvatar", discordAvatar);
                command.ExecuteNonQuery();
                Debug.OutputDebugString("Executed CMD with param : " + spielername + " | " + discordId + " | " + discordAvatar);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static int RegisterAccount(string nickname, string socialClub, string hardwareIdHash, string hardwareIdExHash, string email, string password, string geschlecht, int forumUid)
        {
            try
            {
                int registeredUid = -1;
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO spieler (SpielerName, SpielerSocial, HardwareIdHash, HardwareIdExHash, email, Passwort, Geschlecht, ForumUID) VALUES(@SpielerName, @SpielerSocial, @HardwareIdHash, @HardwareIdExHash, @email, @passwort, @Geschlecht, @ForumUID)";
                command.Parameters.AddWithValue("@SpielerName", nickname);
                command.Parameters.AddWithValue("@SpielerSocial", socialClub);
                command.Parameters.AddWithValue("@HardwareIdHash", hardwareIdHash);
                command.Parameters.AddWithValue("@HardwareIdExHash", hardwareIdExHash);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@passwort", password);
                command.Parameters.AddWithValue("@Geschlecht", geschlecht);
                command.Parameters.AddWithValue("@ForumUID", forumUid);
                registeredUid = (int)command.LastInsertedId;
                command.ExecuteNonQuery();
                return registeredUid;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return -1; }
        }

        public static void CreateCharacterSkin(int uid, string facefeatures, string headblends, string headoverlays)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO skins (UID, facefeatures, headblends, headoverlays) VALUES(@UID, @facefeatures, @headblends, @headoverlays)";
                command.Parameters.AddWithValue("@UID", uid);
                command.Parameters.AddWithValue("@facefeatures", facefeatures);
                command.Parameters.AddWithValue("@headblends", headblends);
                command.Parameters.AddWithValue("@headoverlays", headoverlays);
                command.ExecuteNonQuery();
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static int GetPlayerWhereFromList(string where)
        {
            try
            {
                int wherefrom = 0;
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                List<BanModel> playerBans = new List<BanModel>();
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ban";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        BanModel banEntry = new BanModel
                        {
                            Uid = reader.GetInt32("UID"),
                            Name = reader.GetString("Name"),
                            HardwareId = reader.GetString("HardwareId"),
                            HardwareIdExHash = reader.GetString("HardwareIdExHash"),
                            Ip = reader.GetString("IP"),
                            DiscordId = reader.GetString("DiscordID"),
                            Reason = reader.GetString("Reason"),
                            Admin = reader.GetString("Admin"),
                            BannedTill = reader.GetDateTime("BannedTill"),
                            BanCreated = reader.GetDateTime("BanDateCreated"),
                            BanType = reader.GetString("BanType")
                        };
                        playerBans.Add(banEntry);
                    }
                    else return new List<BanModel>();
                }
                return playerBans;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new List<BanModel>(); }
        }

        public static void SetPlayerWhereFromList(string where, int howmuch)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

        public static int CreateCharacter(VnXPlayer player, int uid)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO users (UID, SpielerName, sex) VALUES (@UID, @playerName, @playerSex)";
                    command.Parameters.AddWithValue("@playerName", player.Username);
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@playerSex", player.Sex);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION CreateCharacter] " + ex.Message);
                    Console.WriteLine("[EXCEPTION CreateCharacter] " + ex.StackTrace);
                }
            }

            return uid;
        }

        public static void LoadCharacterInformationById(VnXPlayer character, int characterId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
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
                    character.Reallife.LastPosition = new Vector3(posX, posY, posZ);
                    character.Reallife.SpawnLocation = reader.GetString("spawn");
                    character.Reallife.JailTime = reader.GetInt32("knastzeit");
                    character.Reallife.Faction = reader.GetInt32("faction");
                    character.Reallife.FactionCooldown = reader.GetDateTime("zivizeit");
                    //character.SetPosition = new Vector3(posX, posY, posZ);
                    character.Reallife.Money = reader.GetInt32("money");
                    character.Reallife.Bank = reader.GetInt32("bank");
                    character.Reallife.SocialState = reader.GetString("SocialState");
                    character.Sex = reader.GetInt32("sex");
                    character.Reallife.Job = reader.GetString("job");
                    character.Reallife.TruckerJobLevel = reader.GetInt32("LIEFERJOB_LEVEL");
                    character.Reallife.AirportJobLevel = reader.GetInt32("AIRPORTJOB_LEVEL");
                    character.Reallife.BusJobLevel = reader.GetInt32("BUSJOB_LEVEL");
                    character.Reallife.FactionRank = reader.GetInt32("rank");
                    character.Dead = reader.GetInt32("killed");
                    character.Reallife.HouseRent = reader.GetInt32("houseRent");
                    character.Reallife.HouseEntered = reader.GetInt32("houseEntered");
                    character.Reallife.BusinessEntered = reader.GetInt32("businessEntered");

                    character.Reallife.IDCard = reader.GetInt32("Personalausweis");
                    character.Reallife.DrivingLicense = reader.GetInt32("Autofuehrerschein");
                    character.Reallife.BikeDrivingLicense = reader.GetInt32("Motorradfuehrerschein");
                    character.Reallife.TruckDrivingLicense = reader.GetInt32("LKWfuehrerschein");
                    character.Reallife.HelicopterDrivingLicense = reader.GetInt32("Helikopterfuehrerschein");
                    character.Reallife.FlyLicenseA = reader.GetInt32("FlugscheinKlasseA");
                    character.Reallife.FlyLicenseB = reader.GetInt32("FlugscheinKlasseB");
                    character.Reallife.MotorBoatDrivingLicense = reader.GetInt32("Motorbootschein");
                    character.Reallife.FishingLicense = reader.GetInt32("Angelschein");
                    character.Reallife.WeaponLicense = reader.GetInt32("Waffenschein");

                    character.Played = reader.GetInt32("played");
                    character.Reallife.Quests = reader.GetInt32("quests");
                    character.Reallife.WantedStars = reader.GetInt32("wanteds");
                    character.Reallife.Bail = reader.GetInt32("kaution");
                    character.Reallife.Hud = reader.GetInt32("REALLIFE_HUD");

                    character.Settings.ShowAtm = reader.GetInt32("atm_anzeigen");
                    character.Settings.ShowHouse = reader.GetInt32("haus_anzeigen");
                    character.Settings.ShowSpeedometer = reader.GetInt32("tacho_anzeigen");
                    character.Settings.ShowQuests = reader.GetInt32("quest_anzeigen");
                    character.Settings.ShowReporter = reader.GetInt32("reporter_anzeigen");
                    character.Settings.ShowGlobalChat = reader.GetInt32("globalchat_anzeigen");

                    character.Tactics.Kills = reader.GetInt32("tactic_kills");
                    character.Tactics.Deaths = reader.GetInt32("tactic_tode");

                    character.Zombies.ZombieDeaths = reader.GetInt32("zombie_tode");
                    character.Zombies.ZombieKills = reader.GetInt32("zombie_kills");
                    character.Zombies.ZombiePlayerKills = reader.GetInt32("zombie_player_kills");
                    character.SevenTowers.Wins = reader.GetInt32("seventowers_wins");

                    character.Reallife.AdventCalender = reader.GetInt32("Adventskalender");
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        public static void SaveCharacterInformation(VnXPlayer player)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
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
                if (player.Gamemode == (int)Preload.Gamemodes.Reallife)
                    player.Reallife.LastPosition = player.Position;
                command.Parameters.AddWithValue("@rotation", player.Rotation.Yaw);
                command.Parameters.AddWithValue("@money", player.Reallife.Money);
                command.Parameters.AddWithValue("@bank", player.Reallife.Bank);
                command.Parameters.AddWithValue("@SocialState", player.Reallife.SocialState);
                command.Parameters.AddWithValue("@health", player.Health);
                command.Parameters.AddWithValue("@armor", player.Armor);
                command.Parameters.AddWithValue("@killed", player.Dead);
                command.Parameters.AddWithValue("@faction", player.Reallife.Faction);
                command.Parameters.AddWithValue("@zivizeit", player.Reallife.FactionCooldown);
                command.Parameters.AddWithValue("@job", player.Reallife.Job);
                command.Parameters.AddWithValue("@LIEFERJOB_LEVEL", player.Reallife.TruckerJobLevel);
                command.Parameters.AddWithValue("@AIRPORTJOB_LEVEL", player.Reallife.AirportJobLevel);
                command.Parameters.AddWithValue("@BUSJOB_LEVEL", player.Reallife.BusJobLevel);
                command.Parameters.AddWithValue("@rank", player.Reallife.FactionRank);
                command.Parameters.AddWithValue("@houseRent", player.Reallife.HouseRent);
                command.Parameters.AddWithValue("@houseEntered", player.Reallife.HouseEntered);
                command.Parameters.AddWithValue("@businessEntered", player.Reallife.BusinessEntered);

                command.Parameters.AddWithValue("@Personalausweis", player.Reallife.IDCard);
                command.Parameters.AddWithValue("@Autofuehrerschein", player.Reallife.DrivingLicense);
                command.Parameters.AddWithValue("@Motorradfuehrerschein", player.Reallife.BikeDrivingLicense);
                command.Parameters.AddWithValue("@LKWfuehrerschein", player.Reallife.TruckDrivingLicense);
                command.Parameters.AddWithValue("@Helikopterfuehrerschein", player.Reallife.HelicopterDrivingLicense);
                command.Parameters.AddWithValue("@FlugscheinKlasseA", player.Reallife.FlyLicenseA);
                command.Parameters.AddWithValue("@FlugscheinKlasseB", player.Reallife.FlyLicenseB);
                command.Parameters.AddWithValue("@Motorbootschein", player.Reallife.MotorBoatDrivingLicense);
                command.Parameters.AddWithValue("@Angelschein", player.Reallife.FishingLicense);
                command.Parameters.AddWithValue("@Waffenschein", player.Reallife.WeaponLicense);


                command.Parameters.AddWithValue("@played", player.Played);
                command.Parameters.AddWithValue("@playerId", player.UID);
                command.Parameters.AddWithValue("@spawn", player.Reallife.SpawnLocation);
                command.Parameters.AddWithValue("@quests", player.Reallife.Quests);
                command.Parameters.AddWithValue("@wanteds", player.Reallife.WantedStars);
                command.Parameters.AddWithValue("@knastzeit", player.Reallife.JailTime);
                command.Parameters.AddWithValue("@kaution", player.Reallife.Bail);
                command.Parameters.AddWithValue("@REALLIFE_HUD", player.Reallife.Hud);
                command.Parameters.AddWithValue("@atm_anzeigen", player.Settings.ShowAtm);
                command.Parameters.AddWithValue("@haus_anzeigen", player.Settings.ShowHouse);
                command.Parameters.AddWithValue("@tacho_anzeigen", player.Settings.ShowSpeedometer);
                command.Parameters.AddWithValue("@quest_anzeigen", player.Settings.ShowQuests);
                command.Parameters.AddWithValue("@reporter_anzeigen", player.Settings.ShowReporter);
                command.Parameters.AddWithValue("@globalchat_anzeigen", player.Settings.ShowGlobalChat);
                command.Parameters.AddWithValue("@tactic_kills", player.Tactics.Kills);
                command.Parameters.AddWithValue("@tactic_tode", player.Tactics.Deaths);
                command.Parameters.AddWithValue("@Adventskalender", player.Reallife.AdventCalender);
                command.Parameters.AddWithValue("@zombie_kills", player.Zombies.ZombieKills);
                command.Parameters.AddWithValue("@zombie_tode", player.Zombies.ZombieDeaths);
                command.Parameters.AddWithValue("@zombie_player_kills", player.Zombies.ZombiePlayerKills);
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

        public static bool FindAccountByHardwareIdHash(string hardwareIdHash)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE HardwareIdHash = @HardwareIdHash LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareIdHash", hardwareIdHash);

                    using MySqlDataReader reader = command.ExecuteReader();
                    found = reader.HasRows;
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindAccountByHardwareIdExHash(string hardwareIdExHash)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE HardwareIdExHash = @HardwareIdExHash LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareIdExHash", hardwareIdExHash);

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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

        public static bool FindCharacterByUid(int uid)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", uid);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static bool FindCharakterPrison(string spielerName)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static int GetCharakterPrisonTime(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonZeit FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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

        public static string GetCharakterPrisonReason(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonGrund FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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

        public static string GetCharakterPrisonAdminBy(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonVon FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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

        public static DateTime GetCharakterPrisonErstelltAm(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PrisonErstelltAm FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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


        public static bool FindCharacterBan(string spielerSocial)
        {
            try
            {
                bool found = false;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Bangrund, Admin, Banzeit, BanerstelltAm FROM ban WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", spielerSocial);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        found = reader.HasRows;
                    }
                }

                return found;
            }
            catch { return false; }
        }

        public static int GetCharakterUid(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM users WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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

        public static int GetPlayerUid(string spielerName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT UID FROM spieler WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32("UID");
                    }
                }
                return -1;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return -1; }
        }


        public static string GetAccountGeschlecht(string socialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Geschlecht FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", socialName);

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

        public static string GetAccountSpielerName(string socialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT SpielerName FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", socialName);

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
        public static string GetAccountSpielerSerial(string socialName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT serial FROM spieler WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", socialName);

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

        public static string GetAccountNameByHardwareId(string hardwareId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT HardwareId FROM spieler WHERE HardwareId = @HardwareId LIMIT 1";
                    command.Parameters.AddWithValue("@HardwareId", hardwareId);

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
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

        public static VnXPlayer GetPlayerVip(VnXPlayer spieler, int uid)
        {

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT VIP_Paket, VIP_BisZum, VIP_GekauftAm FROM spieler WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", uid);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            spieler.VipPaket = reader.GetString("VIP_Paket");
                            spieler.VipTill = reader.GetDateTime("VIP_BisZum");
                            spieler.VipBought = reader.GetDateTime("VIP_GekauftAm");
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

        public static void SetVipStats(int uid, string paket, int tage)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET VIP_Paket = @VIP_Paket, VIP_BisZum = @VIP_BisZum WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@VIP_Paket", paket);
                    command.Parameters.AddWithValue("@VIP_BisZum", DateTime.Now.AddDays(tage));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION SetVIPStats] " + ex.Message);
                    Console.WriteLine("[EXCEPTION SetVIPStats] " + ex.StackTrace);
                }
            }
        }

        public static void SetPlayerSerial(string spielerSocial, string serial)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET serial = @serial WHERE SpielerSocial = @SpielerSocial LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerSocial", spielerSocial);
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

        public static void SetPlayerSocialClubByUid(int uid, string spielerSocial)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE spieler SET SpielerSocial = @SpielerSocial WHERE UID = @UID LIMIT 1";
                    //command.CommandText = "UPDATE users SET socialName = @SpielerSocial WHERE UID = @UID";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@SpielerSocial", spielerSocial);

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
                Accountbans accountBans = new Accountbans();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                            accountBans.Banreason = reader.GetString("Bangrund");
                            accountBans.AdminBanned = reader.GetString("Admin");
                            accountBans.Banzeit = reader.GetDateTime("Banzeit");
                            accountBans.Banerstelltam = reader.GetDateTime("BanerstelltAm");
                            accountBans.Bantype = reader.GetString("Bantype");
                        }
                    }
                }
                return accountBans;
            }
            catch { return null; }
        }


        public static void RemoveOldBan(int uid)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM ban WHERE UID = @UID LIMIT 1";
                command.Parameters.AddWithValue("@UID", uid);

                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void RemoveOldPrison(string spielerName)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM prison WHERE SpielerName = @SpielerName LIMIT 1";
                    command.Parameters.AddWithValue("@SpielerName", spielerName);

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
                List<VehicleModel> vehicleList = new List<VehicleModel>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                        vehClass.DatabaseId = reader.GetInt32("id");
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
                            vehClass.Dimension = _Globals_.Main.ReallifeDimension;
                        }
                        else
                        {
                            vehClass.Dimension = Constants.VehicleOfflineDim;
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
                        vehClass.Npc = false;
                        if (vehClass.Faction > Constants.FactionNone)
                        {
                            vehClass.LockState = VehicleLockState.Unlocked;
                        }
                        else
                        {
                            vehClass.LockState = VehicleLockState.Locked;
                        }
                        _Globals_.Main.AllVehicles.Add(vehClass);
                        _Globals_.Main.ReallifeVehicles.Add(vehClass);
                    }
                }

                return vehicleList;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }


        public static List<GangwarModel> LoadAllGwAreas()
        {
            try
            {

                List<GangwarModel> gwList = new List<GangwarModel>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                                if (area.Aktiv == 1)
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


        public static int AddNewIVehicle(VehicleModel vehicle)
        {
            try
            {
                int vehId = 0;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO Vehicles (model, posX, posY, posZ, rotX, rotY, rotZ, FirstColor, SecondColor, dimension, faction, owner, plate, gas) ";
                        command.CommandText += "VALUES (@model, @posX, @posY, @posZ, @rotX, @rotY, @rotZ, @FirstColor, @SecondColor, @dimension, @faction, @owner, @plate, @gas)";
                        command.Parameters.AddWithValue("@model", vehicle.Name);
                        command.Parameters.AddWithValue("@posX", vehicle.Position.X);
                        command.Parameters.AddWithValue("@posY", vehicle.Position.Y);
                        command.Parameters.AddWithValue("@posZ", vehicle.Position.Z);
                        Vector3 rot = vehicle.Rotation;
                        command.Parameters.AddWithValue("@rotX", rot.X);
                        command.Parameters.AddWithValue("@rotY", rot.Y);
                        command.Parameters.AddWithValue("@rotZ", rot.Z);
                        command.Parameters.AddWithValue("@FirstColor", vehicle.FirstColor);
                        command.Parameters.AddWithValue("@SecondColor", vehicle.SecondColor);
                        command.Parameters.AddWithValue("@dimension", vehicle.Dimension);
                        command.Parameters.AddWithValue("@faction", vehicle.Faction);
                        command.Parameters.AddWithValue("@owner", vehicle.Owner);
                        command.Parameters.AddWithValue("@plate", vehicle.Plate);
                        command.Parameters.AddWithValue("@gas", vehicle.Gas);
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
            catch (Exception ex) { Debug.CatchExceptions(ex); return 99999; }
        }

        public static int AddNewAdminTicket(AdminTickets ticket)
        {

            int vehId = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO support (player, subject, message, state) ";
                    command.CommandText += "VALUES ( @playerName, @Betreff, @Frage, @Status)";
                    command.Parameters.AddWithValue("@playerName", ticket.PlayerName);
                    command.Parameters.AddWithValue("@Betreff", ticket.Betreff);
                    command.Parameters.AddWithValue("@Frage", "Spieler " + ticket.PlayerName + "[" + DateTime.Now + "]:" + ticket.Frage);
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


        public static void UpdateIVehicleSingleString(string table, string value, int vehicleId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE Vehicles SET " + table + " = @value WHERE id = @vehId LIMIT 1";
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@vehId", vehicleId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdateIVehicleSingleString] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdateIVehicleSingleString] " + ex.StackTrace);
                }
            }
        }

        public static void SaveIVehicle(VehicleModel vehicle)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE Vehicles SET posX = @posX, posY = @posY, posZ = @posZ, rotX = @rotX, rotY = @rotY, rotZ = @rotZ,";
                command.CommandText += "FirstColor = @FirstColor, SecondColor = @SecondColor, dimension = @dimension, ";
                command.CommandText += "faction = @faction, owner = @owner, plate = @plate, price = @price, ";
                command.CommandText += "gas = @gas, kms = @kms WHERE id = @vehId LIMIT 1";
                Vector3 rot = vehicle.Rotation;
                command.Parameters.AddWithValue("@posX", vehicle.Position.X);
                command.Parameters.AddWithValue("@posY", vehicle.Position.Y);
                command.Parameters.AddWithValue("@posZ", vehicle.Position.Z);
                command.Parameters.AddWithValue("@rotX", rot.X);
                command.Parameters.AddWithValue("@rotY", rot.Y);
                command.Parameters.AddWithValue("@rotZ", rot.Z);
                command.Parameters.AddWithValue("@FirstColor", vehicle.FirstColor);
                command.Parameters.AddWithValue("@SecondColor", vehicle.SecondColor);
                command.Parameters.AddWithValue("@dimension", vehicle.Dimension);
                command.Parameters.AddWithValue("@faction", vehicle.Faction);
                command.Parameters.AddWithValue("@owner", vehicle.Owner);
                command.Parameters.AddWithValue("@plate", vehicle.Plate);
                command.Parameters.AddWithValue("@price", vehicle.Price);
                command.Parameters.AddWithValue("@gas", vehicle.Gas);
                command.Parameters.AddWithValue("@kms", vehicle.Kms);
                command.Parameters.AddWithValue("@vehId", vehicle.DatabaseId);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveIVehicle] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveIVehicle] " + ex.StackTrace);
            }
        }

        public static void SaveAllIVehicles(List<VehicleModel> vehicleList)
        {

            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE Vehicles SET posX = @posX, posY = @posY, posZ = @posZ, rotX = @rotX, rotY = @rotY, rotZ = @rotZ,";
                command.CommandText += "FirstColor = @FirstColor, SecondColor = @SecondColor, dimension = @dimension, ";
                command.CommandText += "faction = @faction, owner = @owner, plate = @plate, price = @price, ";
                command.CommandText += "gas = @gas, kms = @kms WHERE id = @vehId LIMIT 1";

                foreach (VehicleModel vehicle in vehicleList)
                {
                    command.Parameters.Clear();

                    Vector3 rot = vehicle.SpawnRot;
                    command.Parameters.AddWithValue("@posX", vehicle.SpawnCoord.X);
                    command.Parameters.AddWithValue("@posY", vehicle.SpawnCoord.Y);
                    command.Parameters.AddWithValue("@posZ", vehicle.SpawnCoord.Z);
                    command.Parameters.AddWithValue("@rotX", rot.X);
                    command.Parameters.AddWithValue("@rotY", rot.Y);
                    command.Parameters.AddWithValue("@rotZ", rot.Z);
                    command.Parameters.AddWithValue("@FirstColor", vehicle.FirstColor);
                    command.Parameters.AddWithValue("@SecondColor", vehicle.SecondColor);
                    command.Parameters.AddWithValue("@dimension", vehicle.Dimension);
                    command.Parameters.AddWithValue("@faction", vehicle.Faction);
                    command.Parameters.AddWithValue("@owner", vehicle.Owner);
                    command.Parameters.AddWithValue("@plate", vehicle.Plate);
                    command.Parameters.AddWithValue("@price", vehicle.Price);
                    command.Parameters.AddWithValue("@gas", vehicle.Gas);
                    command.Parameters.AddWithValue("@kms", vehicle.Kms);
                    command.Parameters.AddWithValue("@vehId", vehicle.DatabaseId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SaveAllIVehicles] " + ex.Message);
                Console.WriteLine("[EXCEPTION SaveAllIVehicles] " + ex.StackTrace);
            }
        }

        public static void RemoveIVehicle(int vehicleId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM IVehicles WHERE id = @IVehicleId LIMIT 1";
                    command.Parameters.AddWithValue("@IVehicleId", vehicleId);

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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                                tunning.Id = reader.GetInt32("id");
                                tunning.Vehicle = reader.GetInt32("Vehicle");
                                tunning.Slot = reader.GetInt32("slot");
                                tunning.Component = reader.GetInt32("component");
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

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO tunning (IVehicle, slot, component) VALUES (@IVehicle, @slot, @component)";
                    command.Parameters.AddWithValue("@IVehicle", tunning.Vehicle);
                    command.Parameters.AddWithValue("@slot", tunning.Slot);
                    command.Parameters.AddWithValue("@component", tunning.Component);

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

        public static void RemoveTunning(int vehicleid, int slot)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM tunning WHERE IVehicle = @IVehicle AND slot = @slot LIMIT 1";
                    command.Parameters.AddWithValue("@IVehicle", vehicleid);
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM items";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        float posX = reader.GetFloat("posX");
                        float posY = reader.GetFloat("posY");
                        float posZ = reader.GetFloat("posZ");

                        item.Id = reader.GetInt32("id");
                        item.Uid = reader.GetInt32("uid");
                        item.Hash = reader.GetString("hash");
                        item.Amount = reader.GetInt32("amount");
                        item.Position = new Position(posX, posY, posZ);
                        item.Dimension = reader.GetInt32("dimension");
                        item.Weight = reader.GetFloat("weight");
                        item.Type = (ItemType)reader.GetInt32("type");

                        item.ClothesSlot = reader.GetInt32("ClotheSlot");
                        item.ClothesDrawable = reader.GetInt32("ClotheDrawable");
                        item.ClothesTexture = reader.GetInt32("ClotheTexture");
                        item.IsUsing = reader.GetBoolean("IsUsing");

                        itemList.Add(item);
                    }
                }

                return itemList;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new List<ItemModel>(); }
        }
        public static List<AccountModel> LoadAllAccounts()
        {
            try
            {
                List<AccountModel> accountList = new List<AccountModel>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM spieler";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AccountModel account = new AccountModel
                        {
                            Uid = reader.GetInt32("UID"),
                            HardwareId = reader.GetString("HardwareIdHash"),
                            HardwareIdExhash = reader.GetString("HardwareIdExHash"),
                            Name = reader.GetString("SpielerName"),
                            Email = reader.GetString("Email"),
                            Password = reader.GetString("Passwort"),
                            SocialId = reader.GetString("SpielerSocial")
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM skins";

                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CharacterModel ccharacter = new CharacterModel
                        {
                            Uid = reader.GetInt32("UID"),
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

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO `items` (`hash`, `UID`, `amount`, `posX`, `posY`, `posZ`, `Dimension`, `weight`, `type`, `IsUsing`)";
                    command.CommandText += " VALUES (@hash, @UID, @amount, @posX, @posY, @posZ, @Dimension, @weight, @type, @IsUsing)";
                    command.Parameters.AddWithValue("@hash", item.Hash);
                    command.Parameters.AddWithValue("@UID", item.Uid);
                    command.Parameters.AddWithValue("@amount", item.Amount);
                    command.Parameters.AddWithValue("@posX", item.Position.X);
                    command.Parameters.AddWithValue("@posY", item.Position.Y);
                    command.Parameters.AddWithValue("@posZ", item.Position.Z);
                    command.Parameters.AddWithValue("@dimension", item.Dimension);
                    command.Parameters.AddWithValue("@weight", item.Dimension);
                    command.Parameters.AddWithValue("@type", item.Type);
                    command.Parameters.AddWithValue("@IsUsing", item.IsUsing);

                    command.ExecuteNonQuery();
                    itemId = (int)command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    Debug.CatchExceptions(ex);
                }
            }

            return itemId;
        }

        public static void UpdateItem(ItemModel item)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE `items` SET `uid` = @uid, `amount` = @amount, ";
                command.CommandText += "`posX` = @posX, `posY` = @posY, `posZ` = @posZ, `dimension` = @dimension, `weight` = @weight, type = @type WHERE `id` = @id LIMIT 1";
                command.Parameters.AddWithValue("@UID", item.Uid);
                command.Parameters.AddWithValue("@amount", item.Amount);
                command.Parameters.AddWithValue("@posX", item.Position.X);
                command.Parameters.AddWithValue("@posY", item.Position.Y);
                command.Parameters.AddWithValue("@posZ", item.Position.Z);
                command.Parameters.AddWithValue("@dimension", item.Dimension);
                command.Parameters.AddWithValue("@weight", item.Weight);
                command.Parameters.AddWithValue("@type", item.Type);
                command.Parameters.AddWithValue("@id", item.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }

        public static void RemoveItem(int id)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
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
                Debug.CatchExceptions(ex);
            }
        }

        public static void RemoveAllItemsByType(int sqlid, ItemType itemArt)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM items WHERE type = @type AND UID = @UID";
                    command.Parameters.AddWithValue("@UID", sqlid);
                    command.Parameters.AddWithValue("@type", itemArt);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.CatchExceptions(ex);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void RemoveAllItems(int sqlid)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM items WHERE UID = @UID";
                command.Parameters.AddWithValue("@UID", sqlid);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }
        }


        public static List<BusinessModel> LoadAllBusiness()
        {
            try
            {
                List<BusinessModel> businessList = new List<BusinessModel>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                            business.Id = reader.GetInt32("id");
                            business.Type = reader.GetInt32("type");
                            business.Ipl = reader.GetString("ipl");
                            business.Name = reader.GetString("Name");
                            business.Position = new Position(posX, posY, posZ);
                            business.Dimension = reader.GetInt32("dimension");
                            business.Owner = reader.GetString("owner");
                            business.Multiplier = reader.GetFloat("multiplier");
                            business.Locked = reader.GetBoolean("locked");

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE business SET type = @type, ipl = @ipl, posX = @posX, posY = @posY, posZ = @posZ, dimension = @dimension, name = @name, ";
                    command.CommandText += "owner = @owner, funds = @funds, products = @products, multiplier = @multiplier, locked = @locked WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@type", business.Type);
                    command.Parameters.AddWithValue("@ipl", business.Ipl);
                    command.Parameters.AddWithValue("@posX", business.Position.X);
                    command.Parameters.AddWithValue("@posY", business.Position.Y);
                    command.Parameters.AddWithValue("@posZ", business.Position.Z);
                    command.Parameters.AddWithValue("@dimension", business.Dimension);
                    command.Parameters.AddWithValue("@name", business.Name);
                    command.Parameters.AddWithValue("@owner", business.Owner);
                    command.Parameters.AddWithValue("@funds", business.Funds);
                    command.Parameters.AddWithValue("@products", business.Products);
                    command.Parameters.AddWithValue("@multiplier", business.Multiplier);
                    command.Parameters.AddWithValue("@locked", business.Locked);
                    command.Parameters.AddWithValue("@id", business.Id);

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                        command.Parameters.AddWithValue("@type", business.Type);
                        command.Parameters.AddWithValue("@ipl", business.Ipl);
                        command.Parameters.AddWithValue("@posX", business.Position.X);
                        command.Parameters.AddWithValue("@posY", business.Position.Y);
                        command.Parameters.AddWithValue("@posZ", business.Position.Z);
                        command.Parameters.AddWithValue("@dimension", business.Dimension);
                        command.Parameters.AddWithValue("@name", business.Name);
                        command.Parameters.AddWithValue("@owner", business.Owner);
                        command.Parameters.AddWithValue("@funds", business.Funds);
                        command.Parameters.AddWithValue("@products", business.Products);
                        command.Parameters.AddWithValue("@multiplier", business.Multiplier);
                        command.Parameters.AddWithValue("@locked", business.Locked);
                        command.Parameters.AddWithValue("@id", business.Id);

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

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO business (type, ipl, posX, posY, posZ, dimension) VALUES (@type, @ipl, @posX, @posY, @posZ, @dimension)";
                    command.Parameters.AddWithValue("@type", business.Type);
                    command.Parameters.AddWithValue("@ipl", business.Ipl);
                    command.Parameters.AddWithValue("@posX", business.Position.X);
                    command.Parameters.AddWithValue("@posY", business.Position.Y);
                    command.Parameters.AddWithValue("@posZ", business.Position.Z);
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                        house.Id = reader.GetInt32("id");
                        house.Ipl = reader.GetString("ipl");
                        house.Name = reader.GetString("Name");
                        house.Position = new Position(posX, posY, posZ);
                        house.Dimension = reader.GetInt32("dimension");
                        house.Price = reader.GetInt32("price");
                        house.Owner = reader.GetString("owner");
                        house.Status = reader.GetInt32("status");
                        house.Tenants = reader.GetInt32("tenants");
                        house.Rental = reader.GetInt32("rental");
                        house.Locked = reader.GetBoolean("locked");

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

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO houses (ipl, posX, posY, posZ, dimension, name, price) VALUES (@ipl, @posX, @posY, @posZ, @dimension, @name, @preis)";
                    command.Parameters.AddWithValue("@ipl", house.Ipl);
                    command.Parameters.AddWithValue("@posX", house.Position.X);
                    command.Parameters.AddWithValue("@posY", house.Position.Y);
                    command.Parameters.AddWithValue("@posZ", house.Position.Z);
                    command.Parameters.AddWithValue("@dimension", house.Dimension);
                    command.Parameters.AddWithValue("@name", house.Name);
                    command.Parameters.AddWithValue("@preis", house.Price);

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE houses SET ipl = @ipl, posX = @posX, posY = @posY, posZ = @posZ, dimension = @dimension, name = @name, price = @price, ";
                    command.CommandText += "owner = @owner, status = @status, tenants = @tenants, rental = @rental, locked = @locked WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@ipl", house.Ipl);
                    command.Parameters.AddWithValue("@posX", house.Position.X);
                    command.Parameters.AddWithValue("@posY", house.Position.Y);
                    command.Parameters.AddWithValue("@posZ", house.Position.Z);
                    command.Parameters.AddWithValue("@dimension", house.Dimension);
                    command.Parameters.AddWithValue("@name", house.Name);
                    command.Parameters.AddWithValue("@price", house.Price);
                    command.Parameters.AddWithValue("@owner", house.Owner);
                    command.Parameters.AddWithValue("@status", house.Status);
                    command.Parameters.AddWithValue("@tenants", house.Tenants);
                    command.Parameters.AddWithValue("@rental", house.Rental);
                    command.Parameters.AddWithValue("@locked", house.Locked);
                    command.Parameters.AddWithValue("@id", house.Id);

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM clothes";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClothesModel clothes = new ClothesModel();
                            clothes.Id = reader.GetInt32("id");
                            clothes.Player = reader.GetInt32("player");
                            clothes.Type = reader.GetInt32("type");
                            clothes.Slot = reader.GetInt32("slot");
                            clothes.Drawable = reader.GetInt32("drawable");
                            clothes.Texture = reader.GetInt32("texture");
                            clothes.Dressed = reader.GetBoolean("dressed");

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

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO clothes (player, type, slot, drawable, texture, dressed) VALUES (@player, @type, @slot, @drawable, @texture, @dressed)";
                    command.Parameters.AddWithValue("@player", clothes.Player);
                    command.Parameters.AddWithValue("@type", clothes.Type);
                    command.Parameters.AddWithValue("@slot", clothes.Slot);
                    command.Parameters.AddWithValue("@drawable", clothes.Drawable);
                    command.Parameters.AddWithValue("@texture", clothes.Texture);
                    command.Parameters.AddWithValue("@dressed", clothes.Dressed);

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE clothes SET dressed = @dressed WHERE id = @id LIMIT 1";
                    command.Parameters.AddWithValue("@dressed", clothes.Dressed);
                    command.Parameters.AddWithValue("@id", clothes.Id);

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
                List<FactionAllroundModel> factionDataList = new List<FactionAllroundModel>();
                for (int i = 0; i <= 13; i++)
                {
                    foreach (WaffenlagerModel waffenLager in Fraktionswaffenlager.WaffenlagerList.ToList())
                    {
                        if (waffenLager.Faction == i)
                            RefreshWaffenlager(waffenLager);
                    }
                    FactionAllroundModel currentFaction = new FactionAllroundModel
                    {
                        Fid = i,
                        Kasse = GetFactionStats(i),
                        Waffenlager = Fraktionswaffenlager.GetWaffenlagerById(i)
                    };
                    Debug.OutputDebugString("[" + i + "] FactionDataList-Loaded!");
                }
                return factionDataList;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }

        }
        public static List<TattooModel> LoadAllTattoos()
        {
            try
            {
                List<TattooModel> tattooList = new List<TattooModel>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM tattoos";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TattooModel tattoo = new TattooModel();
                            tattoo.Player = reader.GetInt32("player");
                            tattoo.Slot = reader.GetInt32("zone");
                            tattoo.Library = reader.GetString("library");
                            tattoo.Hash = reader.GetString("hash");

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

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();

                        command.CommandText = "INSERT INTO tattoos (player, zone, library, hash) VALUES (@player, @zone, @library, @hash)";
                        command.Parameters.AddWithValue("@player", tattoo.Player);
                        command.Parameters.AddWithValue("@zone", tattoo.Slot);
                        command.Parameters.AddWithValue("@library", tattoo.Library);
                        command.Parameters.AddWithValue("@hash", tattoo.Hash);

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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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


        public static void AddPlayerToPrison(int uid, string spielerName, int prisonZeit, string prisonGrund, string admin, DateTime prisonErstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO prison (UID, SpielerName, PrisonZeit, PrisonGrund, PrisonVon, PrisonErstelltAm) VALUES (@UID, @SpielerName, @PrisonZeit, @PrisonGrund, @PrisonVon, @PrisonErstelltAm)";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@SpielerName", spielerName);
                    command.Parameters.AddWithValue("@PrisonZeit", prisonZeit);
                    command.Parameters.AddWithValue("@PrisonGrund", prisonGrund);
                    command.Parameters.AddWithValue("@PrisonVon", admin);
                    command.Parameters.AddWithValue("@PrisonErstelltAm", prisonErstelltAm);


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION AddPlayerToPrison] " + ex.Message);
                    Console.WriteLine("[EXCEPTION AddPlayerToPrison] " + ex.StackTrace);
                }
            }
        }


        public static void AddPlayerPermaBan(int uid, string username, string hardwareId, string hardwareIdExHash, string socialClubId, string ip, string discordId, string reason, string admin)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO ban (UID, Name, HardwareId, HardwareIdExHash, SocialClubId, IP, DiscordID, Reason, Admin, BannedTill, BanDateCreated, Bantype) VALUES (@UID, @Name, @HardwareId, @HardwareIdExHash, @SocialClubId, @IP, @DiscordID, @Reason, @Admin, @BannedTill, @BanDateCreated, @Bantype)";
                command.Parameters.AddWithValue("@UID", uid);
                command.Parameters.AddWithValue("@Name", username);
                command.Parameters.AddWithValue("@HardwareId", hardwareId);
                command.Parameters.AddWithValue("@HardwareIdExHash", hardwareIdExHash);
                command.Parameters.AddWithValue("@SocialClubId", socialClubId);
                command.Parameters.AddWithValue("@IP", ip);
                command.Parameters.AddWithValue("@DiscordID", discordId);
                command.Parameters.AddWithValue("@Reason", reason);
                command.Parameters.AddWithValue("@Admin", admin);
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

        public static void AddPlayerTimeBan(int uid, string username, string hardwareId, string hardwareIdExHash, string socialClubId, string ip, string discordId, string reason, string admin, int banHours)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO ban (UID, Name, HardwareId, HardwareIdExHash, SocialClubId, IP, DiscordID, Reason, Admin, BannedTill, BanDateCreated, Bantype) VALUES (@UID, @Name, @HardwareId, @HardwareIdExHash, @SocialClubId, @IP, @DiscordID, @Reason, @Admin, @BannedTill, @BanDateCreated, @Bantype)";
                command.Parameters.AddWithValue("@UID", uid);
                command.Parameters.AddWithValue("@Name", username);
                command.Parameters.AddWithValue("@HardwareId", hardwareId);
                command.Parameters.AddWithValue("@HardwareIdExHash", hardwareIdExHash);
                command.Parameters.AddWithValue("@SocialClubId", socialClubId);
                command.Parameters.AddWithValue("@IP", ip);
                command.Parameters.AddWithValue("@DiscordID", discordId);
                command.Parameters.AddWithValue("@Reason", reason);
                command.Parameters.AddWithValue("@Admin", admin);
                command.Parameters.AddWithValue("@BannedTill", DateTime.Now.AddHours(banHours));
                command.Parameters.AddWithValue("@BanDateCreated", DateTime.Now);
                command.Parameters.AddWithValue("@Bantype", "Timeban");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.Message);
                Console.WriteLine("[EXCEPTION AddPlayerTimeBan] " + ex.StackTrace);
            }
        }
        public static void AddPlayerTimeBan(int uid, string spielerSocial, string serial, string bangrund, string admin, DateTime banzeit, DateTime bannerstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO ban (UID, SpielerSocial, serial, Bangrund, Admin, Banzeit, BanerstelltAm, Bantype) VALUES (@UID, @SpielerSocial, @serial, @Bangrund, @Admin, @Banzeit, @BanerstelltAm, @Bantype)";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@SpielerSocial", spielerSocial);
                    command.Parameters.AddWithValue("@serial", serial);
                    command.Parameters.AddWithValue("@Bangrund", bangrund);
                    command.Parameters.AddWithValue("@Admin", admin);
                    command.Parameters.AddWithValue("@Banzeit", banzeit);
                    command.Parameters.AddWithValue("@BanerstelltAm", bannerstelltAm);
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
        public static void UpdatePlayerTimeBan(int uid, string bangrund, string admin, DateTime banzeit, DateTime bannerstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE ban SET Bangrund = @Bangrund, Admin = @Admin, Banzeit = @Banzeit, BannerstelltAm = @BannerstelltAm  WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@Bangrund", bangrund);
                    command.Parameters.AddWithValue("@Admin", admin);
                    command.Parameters.AddWithValue("@Banzeit", banzeit);
                    command.Parameters.AddWithValue("@BannerstelltAm", bannerstelltAm);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdatePlayerTimeBan] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdatePlayerTimeBan] " + ex.StackTrace);
                }
            }
        }

        public static void UpdatePlayerPrisonTime(int uid, int prisonZeit, string prisonGrund, string prisonVon, DateTime prisonErstelltAm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE prison SET PrisonZeit = @PrisonZeit, PrisonGrund = @PrisonGrund, PrisonVon = @PrisonVon, PrisonErstelltAm = @PrisonErstelltAm  WHERE UID = @UID LIMIT 1";
                    command.Parameters.AddWithValue("@UID", uid);
                    command.Parameters.AddWithValue("@PrisonZeit", prisonZeit);
                    command.Parameters.AddWithValue("@PrisonGrund", prisonGrund);
                    command.Parameters.AddWithValue("@PrisonVon", prisonVon);
                    command.Parameters.AddWithValue("@PrisonErstelltAm", prisonErstelltAm);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[EXCEPTION UpdatePlayerPrisonTime] " + ex.Message);
                    Console.WriteLine("[EXCEPTION UpdatePlayerPrisonTime] " + ex.StackTrace);
                }
            }
        }

        public static void UpdateGw(GangwarArea area)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE gangwar SET FID = @facId, cooldown = @areaCD WHERE gang_area = @areaName LIMIT 1";
                    command.Parameters.AddWithValue("@facId", area.IdOwner);
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

    class DatabaseImpl : Database
    {
    }
}