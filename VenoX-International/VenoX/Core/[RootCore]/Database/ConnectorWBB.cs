using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using MySql.Data.MySqlClient;
using VenoX.Core._RootCore_.Sync.WBB_Sync.models;
using VenoX.Data.Database.Models;
using VenoX.Debug;
using AccountModel = VenoX.Core._RootCore_.Sync.WBB_Sync.models.AccountModel;

namespace VenoX.Core._RootCore_.Database
{
    public class Program : IScript
    {


        private static readonly string _connection = "server=127.0.0.1; database=VenoX_Forum; uid=VenoX_Forum; pwd=P82i05ol*G59q0t~t0yS1?54e3k";
        //private static string oldDb = $"server=5.180.66.158; database=TestDB; uid=TestDB; pwd=irh4Q*47";
        
        //variables
        public static List<UserOptionModel> UserOptions = new List<UserOptionModel>();
        public static List<UserGroupsModel> UserGroups = new List<UserGroupsModel>();
        public static List<UserLanguageModel> UserLanguages = new List<UserLanguageModel>();
        public static List<AccountModel> DatabaseAccounts = new List<AccountModel>();
        private static List<(string, string)> _optionsWithDefaultValue;

        public static void RefreshForumDb()
        {
            UserOptions = LoadUserOptions();
            UserGroups = LoadUserGroups();
            UserLanguages = LoadUserLanguages();
            DatabaseAccounts = LoadDatabaseAccounts();
            ConsoleHandling.OutputDebugString("Loaded User - Options [" + UserOptions.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Groups [" + UserGroups.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Languages [" + UserLanguages.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Accounts [" + DatabaseAccounts.Count + "]");

            foreach (AccountModel acc in DatabaseAccounts.ToList())
            {
                UserOptionModel optionClass = UserOptions.FirstOrDefault(x => x.Uid == acc.Uid);
                if (optionClass is null) AddUserOptions(acc.Uid);
                UserGroupsModel groupClass = UserGroups.FirstOrDefault(x => x.Uid == acc.Uid);
                if (groupClass is null) AddUserToGroup(acc.Uid, 3);
                UserLanguageModel languageClass = UserLanguages.FirstOrDefault(x => x.Uid == acc.Uid);
                if (languageClass is null) AddUserToLanguage(acc.Uid, 1);
            }
            ConsoleHandling.OutputDebugString("------------------------------------------------------");
            ConsoleHandling.OutputDebugString("Loaded User - Options [" + UserOptions.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Groups [" + UserGroups.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Languages [" + UserLanguages.Count + "]");
            ConsoleHandling.OutputDebugString("Loaded User - Accounts [" + DatabaseAccounts.Count + "]");
        }

        // Load assets for accounts
        public static List<UserOptionModel> LoadUserOptions()
        {
            try
            {
                List<UserOptionModel> accList = new List<UserOptionModel>();
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_option_value";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int uid = reader.GetInt32("userID");
                        if (UserOptions.FirstOrDefault(x => x.Uid == uid) != null) continue;
                        accList.Add(new UserOptionModel { Uid = uid });
                    }
                }
                return accList;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<UserOptionModel>(); }
        }
        public static List<UserGroupsModel> LoadUserGroups()
        {
            try
            {
                List<UserGroupsModel> accList = new List<UserGroupsModel>();
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_to_group";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int uid = reader.GetInt32("userID");
                        if (UserGroups.FirstOrDefault(x => x.Uid == uid) != null) continue;
                        accList.Add(new UserGroupsModel { Uid = uid });
                    }
                }
                return accList;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<UserGroupsModel>(); }
        }
        public static List<UserLanguageModel> LoadUserLanguages()
        {
            try
            {
                List<UserLanguageModel> accList = new List<UserLanguageModel>();
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_to_language";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int uid = reader.GetInt32("userID");
                        if (UserLanguages.FirstOrDefault(x => x.Uid == uid) != null) continue;
                        accList.Add(new UserLanguageModel { Uid = uid });
                    }
                }
                return accList;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<UserLanguageModel>(); }
        }


        // Load Database Accounts 
        public static List<AccountModel> LoadDatabaseAccounts()
        {
            try
            {
                List<AccountModel> accList = new List<AccountModel>();
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int uid = reader.GetInt32("userID");
                        if (DatabaseAccounts.FirstOrDefault(x => x.Uid == uid) != null) continue;
                        AccountModel accClass = new AccountModel
                        {
                            Uid = reader.GetInt32("userID"),
                            Username = reader.GetString("Username"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("Password")
                        };
                        accList.Add(accClass);
                    }
                }
                return accList;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<AccountModel>(); }
        }
        private static List<(string, string)> GetUserOptions()
        {
            try
            {
                _optionsWithDefaultValue = new List<(string, string)>();
                //Connection
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT optionID, defaultValue FROM wcf1_user_option";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _optionsWithDefaultValue.Add(("userOption" + Convert.ToInt32(reader["optionID"]), Convert.ToString(reader["defaultValue"])));
                }
                //Core.Debug.OutputDebugString("User Options Loaded - " + optionsWithDefaultValue.Count);
                return _optionsWithDefaultValue;
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
                return new List<(string, string)>();
            }
        }
        // On Resource Start
        public static async void OnResourceStart()
        {
            try
            {
                GetUserOptions();
                RefreshForumDb();
                await Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    foreach (DatabaseAccount accClass in from accClass in global::VenoX.Data.Database.Constants.Accounts.ToList() let acc = DatabaseAccounts.FirstOrDefault(x => x.Uid == accClass.UID) where acc is null select accClass)
                    {
                        await CreateForumUser(accClass.UID, accClass.Username, accClass.Email, accClass.Password);
                    }
                });

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }



        // Create Accounts
        public static async Task CreateForumUser(int uid, string name, string email, string password)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (DatabaseAccounts.FirstOrDefault(x => x.Username == name) is not null) return;
                    int userId = AddUser(uid, name, email, password, languageId: 1, rankId: 3, userOnlineGroupId: 3);
                    SyncAccountInformation(uid);
                });
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
            }
        }
        public static void SyncAccountInformation(int id)
        {
            try
            {
                AddUserOptions(id);
                AddUserToGroup(id, groupId: 3);
                AddUserToLanguage(id, languageId: 2);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        // SQL 
        private static int AddUser(int uid, string username, string email, string password, int languageId, int rankId, int userOnlineGroupId)
        {
            try
            {
                //Password Hash
                string salt = GetRandomSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
                string timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                //Connection
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO wcf1_user(`userID`, `username`, `email`, `password`, `languageID`, `registrationDate`, `lastActivityTime`, `rankID`, `userOnlineGroupID`) VALUES (@userID, @username, @email, @password, @languageID, @registrationDate, @lastActivityTime, @rankID, @userOnlineGroupID)";
                command.Parameters.AddWithValue("@userID", uid);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", hashedPassword);
                command.Parameters.AddWithValue("@languageID", languageId);
                command.Parameters.AddWithValue("@registrationDate", timestamp);
                command.Parameters.AddWithValue("@lastActivityTime", timestamp);
                command.Parameters.AddWithValue("@rankID", null);
                command.Parameters.AddWithValue("@userOnlineGroupID", userOnlineGroupId);
                int lastUid = (int)command.LastInsertedId;
                command.ExecuteNonQuery();
                //connection.Close();
                return lastUid;
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchExceptions(ex);
                return -1;
            }
        }
        private static void AddUserOptions(int userId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_option_value(`userID`, `userOption16`) VALUES (@userID, @userOption16)";
                command.Parameters.AddWithValue("@userID", userId);
                command.Parameters.AddWithValue("@userOption16", "Europe/Berlin");
                command.ExecuteNonQuery();
                connection.Close();
                UserOptions.Add(new UserOptionModel { Uid = userId });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }

        }
        public static void AddUserToGroup(int userId, int groupId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_group(`userID`, `groupID`) VALUES (@userId, @groupId)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@groupId", groupId);
                command.ExecuteNonQuery();
                connection.Close();
                UserGroups.Add(new UserGroupsModel { Uid = userId });

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static void AddUserToLanguage(int userId, int languageId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_language(`userID`, `languageID`) VALUES (@userId, @languageID)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@languageID", languageId);
                command.ExecuteNonQuery();
                connection.Close();
                UserLanguages.Add(new UserLanguageModel { Uid = userId });

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void ChangeUserPasswort(string username, string password)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE wcf1_user SET Password = @Password WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        #region Salt 
        private static readonly string _blowfishCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789./";
        private static readonly Random _rnd = new Random();

        public static string GetRandomSalt()
        {
            string salt = "$2a$08$";
            for (int i = 0; i < 22; ++i)
            {
                var rnd = _rnd.Next(_blowfishCharacters.Length);
                salt += _blowfishCharacters[rnd];
            }
            return salt;
        }
        #endregion
    }
}
