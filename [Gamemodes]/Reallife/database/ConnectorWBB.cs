using AltV.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenoXV.Reallife.Woltlab
{
    public class Program : IScript
    {
        public static async Task CreateForumUser(string name, string email, string Password)
        {
            string connString = $"server=51.38.127.227; database=forum_vnx; uid=forum_vnx; pwd=U91a$xt5U91a$xt5U91a$xt5U91a$xt5U91a$xt5";
            using (var connection = new MySqlConnection(connString))
            {
                await connection.OpenAsync();
                var transaction = await connection.BeginTransactionAsync();

                bool hasError = false;
                try
                {
                    long userId = await AddUser(name, email, Password, languageID: 1, rankID: 3, userOnlineGroupID: 3, connection);
                    await AddUserOptions(userId, connection);
                    await AddUserToGroup(userId, groupId: 1, connection);
                    await AddUserToGroup(userId, groupId: 3, connection);
                    await AddUserToLanguage(userId, languageId: 1, connection);
                }
                catch (Exception ex)
                {
                    hasError = true;
                    Console.WriteLine("Exception: " + ex.GetBaseException());
                }
                finally
                {
                    if (hasError)
                        transaction.Rollback();
                    else
                        transaction.Commit();
                }
            }
        }

        private static async Task<long> AddUser(string username, string email, string password, int languageID, int rankID, int userOnlineGroupID, MySqlConnection connection)
        {
            string salt = GetRandomSalt();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
            string timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO wcf1_user(`username`, `email`, `password`, `languageID`, `registrationDate`, `lastActivityTime`, `rankID`, `userOnlineGroupID`)" +
                " VALUES (@username, @email, @password, @languageID, @registrationDate, @lastActivityTime, @rankID, @userOnlineGroupID)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@languageID", languageID);
            cmd.Parameters.AddWithValue("@registrationDate", timestamp);
            cmd.Parameters.AddWithValue("@lastActivityTime", timestamp);
            cmd.Parameters.AddWithValue("@rankID", rankID);
            cmd.Parameters.AddWithValue("@userOnlineGroupID", userOnlineGroupID);

            await cmd.ExecuteNonQueryAsync();

            long userId = cmd.LastInsertedId;
            cmd.Dispose();

            return userId;
        }

        private static async Task AddUserOptions(long userId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT optionID, defaultValue FROM wcf1_user_option";
            var reader = await cmd.ExecuteReaderAsync();
            List<(string, string)> optionsWithDefaultValue = new List<(string, string)>();
            while (await reader.ReadAsync())
            {
                optionsWithDefaultValue.Add(("userOption" + Convert.ToInt32(reader["optionID"]), Convert.ToString(reader["defaultValue"])));
            }
            cmd.Dispose();

            cmd = connection.CreateCommand();

            string columnNames = string.Join("`,`", optionsWithDefaultValue.Select(o => o.Item1));
            string atColumnNames = string.Join(", @", optionsWithDefaultValue.Select(o => o.Item1));

            cmd.CommandText = $"INSERT INTO wcf1_user_option_value(`userID`, `{columnNames}`)" +
                $" VALUES ({userId}, @{atColumnNames})";

            foreach (var optionEntry in optionsWithDefaultValue)
            {
                cmd.Parameters.AddWithValue($"@{optionEntry.Item1}", optionEntry.Item2);
            }

            await cmd.ExecuteNonQueryAsync();
            cmd.Dispose();
        }

        private static async Task AddUserToGroup(long userId, int groupId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO wcf1_user_to_group(`userID`, `groupID`) VALUES (@userId, @groupId)";
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@groupId", groupId);

            await cmd.ExecuteNonQueryAsync();
            cmd.Dispose();
        }

        private static async Task AddUserToLanguage(long userId, int languageId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO wcf1_user_to_language(`userID`, `languageID`) VALUES (@userId, @languageID)";
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@languageID", languageId);

            await cmd.ExecuteNonQueryAsync();
            cmd.Dispose();
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
