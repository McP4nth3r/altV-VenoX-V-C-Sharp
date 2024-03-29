﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AltV.Net;
using AltV.Net.Data;
using VenoX.Core._Admin_;
using VenoX.Core._Globals_;
using VenoX.Core._Preload_.Model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Data.Database;
using VenoX.Data.Database.Models;
using VenoX.Debug;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Preload_.Login
{
    public class Login : IScript
    {
        private static string Sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x2"));
        }

        private static bool LoginAccount(string nickname, string password, bool bcrypt)
        {
            try
            {
                foreach (DatabaseAccount accClass in global::VenoX.Data.Database.Constants.Accounts.Where(accClass => accClass.Username.ToLower() == nickname.ToLower()))
                {
                    if (bcrypt)
                    {
                        if (BCrypt.Net.BCrypt.Verify(password, accClass.Password))
                            return true;
                    }
                    if (accClass.Password == password)
                        return true;
                }
                return false;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }
        public static bool ChangeAccountPw(string nickname, string password)
        {
            foreach (DatabaseAccount accClass in global::VenoX.Data.Database.Constants.Accounts.Where(accClass => accClass.Username.ToLower() == nickname.ToLower()))
            {
                using VenoXContext db = new();
                accClass.Password = password;
                db.Accounts.Update(accClass);
                db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private static DatabaseAccount GetAccountModel(string nickname, string password, bool bcrypt = false)
        {
            foreach (DatabaseAccount accClass in global::VenoX.Data.Database.Constants.Accounts.Where(accClass => accClass.Username.ToLower() == nickname.ToLower()))
            {
                if (accClass.Username.ToLower() != nickname.ToLower()) continue;
                if (bcrypt)
                    if (BCrypt.Net.BCrypt.Verify(password, accClass.Password))
                        return accClass;
                
                if (accClass.Password == password)
                    return accClass;
            }
            return null;
        }

        private static void ShowBanWindow(VnXPlayer player)
        {
            try
            {
                BanModel banClass = Admin.GetClientBanModel(player);
                ConsoleHandling.OutputDebugString("Function called because " + player.Name + " is banned");
                if (banClass is null) return;
                if (banClass.BanType == "Permaban") _RootCore_.VenoX.TriggerClientEvent(player, "BanWindow:Create", banClass.Name, "Permanently", banClass.Reason);
                else _RootCore_.VenoX.TriggerClientEvent(player, "BanWindow:Create", banClass.Name, banClass.BannedTill.ToString(), banClass.Reason);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("LoginAccount")]
        public static void LoginAccountEvent(VnXPlayer player, string nickname, string password)
        {
            try
            {
                if (Admin.IsClientBanned(player)) { ShowBanWindow(player); return; }
                DatabaseAccount accClass;

                if (!LoginAccount(nickname, Sha256(password), false) && !LoginAccount(nickname, password, true)) { Notification.DrawNotification(player, Notification.Types.Error, "Wrong Username/Password"); return; }

                if (LoginAccount(nickname, Sha256(password), false)) player.LoggedInWithShaPassword = true;

                accClass = player.LoggedInWithShaPassword ? (DatabaseAccount) GetAccountModel(nickname, Sha256(password)) : (DatabaseAccount) GetAccountModel(nickname, password, true);

                if (accClass == null) return;
                player.Language = (int)global::VenoX.Core._Language_.Main.GetLanguageByPair(accClass.Language);
                Database.LoadCharacterInformationById(player, accClass.UID);
                if (!Character_Creator.Main.PlayerHaveSkin(player))
                {
                    _RootCore_.VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                    _RootCore_.VenoX.TriggerClientEvent(player, "CharCreator:Start", player.Sex);
                    player.Playing = true;
                    VnX.PutPlayerInRandomDim(player);
                    player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                    Register.Register.ChangeCharacterSexEvent(player, player.Sex);
                    return;
                }
                //if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
                _RootCore_.VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                Preload.ShowPreloadList(player, true);
                player.AdminRank = 7;
                // If Method is old-sha256 method : Update!
                if (player.LoggedInWithShaPassword)
                {
                    // Woltlab change
                    string salt = Program.GetRandomSalt();
                    string hashedPasswordWoltlab = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
                    //Normal Change.
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                    if (ChangeAccountPw(nickname, hashedPassword))
                    {
                        ConsoleHandling.OutputDebugString("Updated PW to " + hashedPassword);
                        Database.ChangeUserPasswort(nickname, hashedPassword);
                        Program.ChangeUserPasswort(nickname, hashedPasswordWoltlab);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
