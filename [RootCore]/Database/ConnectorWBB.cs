using AltV.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync.WBB_Sync.models;

namespace VenoXV._Gamemodes_.Reallife.Woltlab
{
    public class Program : IScript
    {


        private static string connString = $"server=5.180.66.158; database=forum_vnx; uid=forum_vnx; pwd=j_4w06xM#T4i4z5q@1Fgaj57";
        private static List<(string, string)> optionsWithDefaultValue;


        public static List<AccountModel> DatabaseAccounts = new List<AccountModel>();

        public static void LoadDatabaseAccounts()
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(connString);
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
                        DatabaseAccounts.Add(accClass);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void SyncAccountInformation(int Id)
        {
            try
            {
                AddUserOptions(Id);
                AddUserToGroup(Id, groupId: 3);
                AddUserToLanguage(Id, languageId: 1);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static async void CreateForumUser(VnXPlayer playerClass, string name, string email, string Password)
        {
            try
            {
                await Task.Run(() =>
                {
                    int userId = AddUser(name, email, Password, languageID: 1, rankID: 3, userOnlineGroupID: 3);
                    LoadDatabaseAccounts();
                    SyncAccountInformation(DatabaseAccounts[DatabaseAccounts.Count].UID + 1);
                    //playerClass.Forum.UID = (int)userId;
                });
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
            }
        }

        public static void OnResourceStart()
        {
            GetUserOptions();

        }

        private static int AddUser(string username, string email, string password, int languageID, int rankID, int userOnlineGroupID)
        {
            try
            {
                //Password Hash
                string salt = GetRandomSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
                string timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                //Connection
                using MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO wcf1_user(`username`, `email`, `password`, `languageID`, `registrationDate`, `lastActivityTime`, `rankID`, `userOnlineGroupID`) VALUES (@username, @email, @password, @languageID, @registrationDate, @lastActivityTime, @rankID, @userOnlineGroupID)";
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


        private static List<(string, string)> GetUserOptions()
        {
            try
            {
                optionsWithDefaultValue = new List<(string, string)>();
                //Connection
                using MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT optionID, defaultValue FROM wcf1_user_option";
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    optionsWithDefaultValue.Add(("userOption" + Convert.ToInt32(reader["optionID"]), Convert.ToString(reader["defaultValue"])));
                }
                Core.Debug.OutputDebugString("User Options Loaded - " + optionsWithDefaultValue.Count);
                return optionsWithDefaultValue;
            }
            catch (Exception ex)
            {
                Core.Debug.CatchExceptions(ex);
                return new List<(string, string)>();
            }
        }

        private static void AddUserOptions(long userId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_option_value(`userID`, `userOption16`) VALUES (@userID, @userOption16)";
                command.Parameters.AddWithValue("@userID", userId);
                command.Parameters.AddWithValue("@userOption16", "Europe/Berlin");
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }

        }

        public static void AddUserToGroup(long userId, int groupId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_group(`userID`, `groupID`) VALUES (@userId, @groupId)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@groupId", groupId);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        public static void AddUserToLanguage(long userId, int languageId)
        {
            try
            {
                //Connection
                using MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO wcf1_user_to_language(`userID`, `languageID`) VALUES (@userId, @languageID)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@languageID", languageId);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        #region Salt 
        private static string _blowfishCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789./";
        private static Random _rnd = new Random();

        private static string GetRandomSalt()
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
