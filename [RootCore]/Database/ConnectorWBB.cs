using AltV.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenoXV._RootCore_.Sync.WBB_Sync.models;

namespace VenoXV._Gamemodes_.Reallife.Woltlab
{
    public class Program : IScript
    {


        private static string Connection = $"server=5.180.66.158; database=forum_vnx; uid=forum_vnx; pwd=j_4w06xM#T4i4z5q@1Fgaj57";
        //private static string oldDb = $"server=5.180.66.158; database=TestDB; uid=TestDB; pwd=irh4Q*47";




        //variables
        public static List<UserOptionModel> UserOptions = new List<UserOptionModel>();
        public static List<UserGroupsModel> UserGroups = new List<UserGroupsModel>();
        public static List<UserLanguageModel> UserLanguages = new List<UserLanguageModel>();
        public static List<AccountModel> DatabaseAccounts = new List<AccountModel>();
        private static List<(string, string)> optionsWithDefaultValue;

        public static void RefreshForumDb()
        {
            UserOptions = LoadUserOptions();
            UserGroups = LoadUserGroups();
            UserLanguages = LoadUserLanguages();
            DatabaseAccounts = LoadDatabaseAccounts();
            Core.Debug.OutputDebugString("Loaded User - Options [" + UserOptions.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Groups [" + UserGroups.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Languages [" + UserLanguages.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Accounts [" + DatabaseAccounts.Count + "]");

            foreach (AccountModel acc in DatabaseAccounts.ToList())
            {
                UserOptionModel optionClass = UserOptions.FirstOrDefault(x => x.UID == acc.UID);
                if (optionClass is null) AddUserOptions(acc.UID);
                UserGroupsModel groupClass = UserGroups.FirstOrDefault(x => x.UID == acc.UID);
                if (groupClass is null) AddUserToGroup(acc.UID, 3);
                UserLanguageModel languageClass = UserLanguages.FirstOrDefault(x => x.UID == acc.UID);
                if (languageClass is null) AddUserToLanguage(acc.UID, 1);
            }
            Core.Debug.OutputDebugString("------------------------------------------------------");
            Core.Debug.OutputDebugString("Loaded User - Options [" + UserOptions.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Groups [" + UserGroups.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Languages [" + UserLanguages.Count + "]");
            Core.Debug.OutputDebugString("Loaded User - Accounts [" + DatabaseAccounts.Count + "]");
        }

        // Load assets for accounts
        public static List<UserOptionModel> LoadUserOptions()
        {
            try
            {
                List<UserOptionModel> accList = new List<UserOptionModel>();
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_option_value";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int UID = reader.GetInt32("userID");
                        if (UserOptions.FirstOrDefault(x => x.UID == UID) != null) continue;
                        accList.Add(new UserOptionModel { UID = UID });
                    }
                }
                return accList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<UserOptionModel>(); }
        }
        public static List<UserGroupsModel> LoadUserGroups()
        {
            try
            {
                List<UserGroupsModel> accList = new List<UserGroupsModel>();
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_to_group";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int UID = reader.GetInt32("userID");
                        if (UserGroups.FirstOrDefault(x => x.UID == UID) != null) continue;
                        accList.Add(new UserGroupsModel { UID = UID });
                    }
                }
                return accList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<UserGroupsModel>(); }
        }
        public static List<UserLanguageModel> LoadUserLanguages()
        {
            try
            {
                List<UserLanguageModel> accList = new List<UserLanguageModel>();
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user_to_language";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int UID = reader.GetInt32("userID");
                        if (UserLanguages.FirstOrDefault(x => x.UID == UID) != null) continue;
                        accList.Add(new UserLanguageModel { UID = UID });
                    }
                }
                return accList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<UserLanguageModel>(); }
        }


        // Load Database Accounts 
        public static List<AccountModel> LoadDatabaseAccounts()
        {
            try
            {
                List<AccountModel> accList = new List<AccountModel>();
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wcf1_user";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int UID = reader.GetInt32("userID");
                        if (DatabaseAccounts.FirstOrDefault(x => x.UID == UID) != null) continue;
                        AccountModel accClass = new AccountModel
                        {
                            UID = reader.GetInt32("userID"),
                            Username = reader.GetString("Username"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("Password")
                        };
                        accList.Add(accClass);
                    }
                }
                return accList;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<AccountModel>(); }
        }
        private static List<(string, string)> GetUserOptions()
        {
            try
            {
                optionsWithDefaultValue = new List<(string, string)>();
                //Connection
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT optionID, defaultValue FROM wcf1_user_option";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    optionsWithDefaultValue.Add(("userOption" + Convert.ToInt32(reader["optionID"]), Convert.ToString(reader["defaultValue"])));
                }
                //Core.Debug.OutputDebugString("User Options Loaded - " + optionsWithDefaultValue.Count);
                return optionsWithDefaultValue;
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
                return new List<(string, string)>();
            }
        }
        // On Resource Start
        public static void OnResourceStart()
        {
            try
            {
                GetUserOptions();
                RefreshForumDb();
                /* await Task.Run(async () =>
                 {
                     await Task.Delay(5000);
                     GetUserOptions();
                     RefreshForumDb();
                     foreach (var accClass in _Preload_.Register.Register.AccountList.ToList())
                     {
                         AccountModel acc = DatabaseAccounts.FirstOrDefault(x => x.UID == accClass.UID);
                         if (acc is null) CreateForumUser(accClass.UID, accClass.Name, accClass.Email, accClass.Password);
                     }
                 });
                */
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }



        // Create Accounts
        public static async void CreateForumUser(int UID, string name, string email, string Password)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (DatabaseAccounts.FirstOrDefault(x => x.Username == name) is not null) return;
                    int userId = AddUser(UID, name, email, Password, languageID: 1, rankID: 3, userOnlineGroupID: 3);
                    SyncAccountInformation(UID);
                });
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }
        public static void SyncAccountInformation(int Id)
        {
            try
            {
                AddUserOptions(Id);
                AddUserToGroup(Id, groupId: 3);
                AddUserToLanguage(Id, languageId: 2);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        // SQL 
        private static int AddUser(int UID, string username, string email, string password, int languageID, int rankID, int userOnlineGroupID)
        {
            try
            {
                //Password Hash
                string salt = GetRandomSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
                string timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                //Connection
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO wcf1_user(`userID`, `username`, `email`, `password`, `languageID`, `registrationDate`, `lastActivityTime`, `rankID`, `userOnlineGroupID`) VALUES (@userID, @username, @email, @password, @languageID, @registrationDate, @lastActivityTime, @rankID, @userOnlineGroupID)";
                command.Parameters.AddWithValue("@userID", UID);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", hashedPassword);
                command.Parameters.AddWithValue("@languageID", languageID);
                command.Parameters.AddWithValue("@registrationDate", timestamp);
                command.Parameters.AddWithValue("@lastActivityTime", timestamp);
                command.Parameters.AddWithValue("@rankID", null);
                command.Parameters.AddWithValue("@userOnlineGroupID", userOnlineGroupID);
                int LastUID = (int)command.LastInsertedId;
                command.ExecuteNonQuery();
                //connection.Close();
                return LastUID;
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
                return -1;
            }
        }
        private static void AddUserOptions(int userId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_option_value(`userID`, `userOption16`) VALUES (@userID, @userOption16)";
                command.Parameters.AddWithValue("@userID", userId);
                command.Parameters.AddWithValue("@userOption16", "Europe/Berlin");
                command.ExecuteNonQuery();
                connection.Close();
                UserOptions.Add(new UserOptionModel { UID = userId });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }

        }
        public static void AddUserToGroup(int userId, int groupId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_group(`userID`, `groupID`) VALUES (@userId, @groupId)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@groupId", groupId);
                command.ExecuteNonQuery();
                connection.Close();
                UserGroups.Add(new UserGroupsModel { UID = userId });

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void AddUserToLanguage(int userId, int languageId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_language(`userID`, `languageID`) VALUES (@userId, @languageID)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@languageID", languageId);
                command.ExecuteNonQuery();
                connection.Close();
                UserLanguages.Add(new UserLanguageModel { UID = userId });

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void ChangeUserPasswort(string Username, string password)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE wcf1_user SET Password = @Password WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        #region Salt 
        private static string _blowfishCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789./";
        private static Random _rnd = new Random();

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
