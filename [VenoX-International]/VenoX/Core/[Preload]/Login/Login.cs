using System;
using System.Security.Cryptography;
using System.Text;
using AltV.Net;
using AltV.Net.Data;
using Microsoft.VisualBasic;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._Notifications_;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV.Core;
using VenoXV.Models;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoXV._Preload_.Login
{
    public class Login : IScript
    {
        public static string Sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
        public static bool LoginAccount(string nickname, string password, bool bcrypt)
        {
            try
            {
                foreach (AccountModel accClass in Register.Register.AccountList)
                {
                    if (accClass.Name.ToLower() == nickname.ToLower())
                    {
                        if (bcrypt)
                        {
                            if (BCrypt.Net.BCrypt.Verify(password, accClass.Password))
                                return true;
                        }

                        if (accClass.Password == password)
                            return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
        public static bool ChangeAccountPw(string nickname, string password)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == nickname.ToLower())
                {
                    accClass.Password = password;
                    return true;
                }
            }
            return false;
        }
        public static AccountModel GetAccountModel(string nickname, string password, bool bcrypt = false)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == nickname.ToLower())
                {
                    if (bcrypt)
                        if (BCrypt.Net.BCrypt.Verify(password, accClass.Password))
                            return accClass;

                    if (accClass.Password == password)
                        return accClass;
                }
            }
            return null;
        }

        public static void ShowBanWindow(VnXPlayer player)
        {
            try
            {
                BanModel banClass = Admin.GetClientBanModel(player);
                Debug.OutputDebugString("Function called because " + player.Name + " is banned");
                if (banClass is null) return;
                if (banClass.BanType == "Permaban") VenoX.TriggerClientEvent(player, "BanWindow:Create", banClass.Name, "Permanently", banClass.Reason);
                else VenoX.TriggerClientEvent(player, "BanWindow:Create", banClass.Name, banClass.BannedTill.ToString(), banClass.Reason);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("LoginAccount")]
        public static void LoginAccountEvent(VnXPlayer player, string nickname, string password)
        {
            try
            {
                if (Admin.IsClientBanned(player)) { ShowBanWindow(player); return; }
                AccountModel accClass;

                if (!LoginAccount(nickname, Sha256(password), false) && !LoginAccount(nickname, password, true)) { Main.DrawNotification(player, Main.Types.Error, "Wrong Username/Password"); return; }

                if (LoginAccount(nickname, Sha256(password), false)) player.LoggedInWithShaPassword = true;

                if (player.LoggedInWithShaPassword) accClass = GetAccountModel(nickname, Sha256(password));
                else accClass = GetAccountModel(nickname, password, true);

                if (accClass == null) return;
                player.Language = (int)_Language_.Main.GetLanguageByPair(accClass.Language);
                Database.Database.LoadCharacterInformationById(player, accClass.Uid);
                if (!Character_Creator.Main.PlayerHaveSkin(player))
                {
                    VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                    VenoX.TriggerClientEvent(player, "CharCreator:Start", player.Sex);
                    player.Playing = true;
                    VnX.PutPlayerInRandomDim(player);
                    player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                    Register.Register.ChangeCharacterSexEvent(player, player.Sex);
                    return;
                }
                //if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
                VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                Preload.ShowPreloadList(player);
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
                        Debug.OutputDebugString("Updated PW to " + hashedPassword);
                        Database.Database.ChangeUserPasswort(nickname, hashedPassword);
                        Program.ChangeUserPasswort(nickname, hashedPasswordWoltlab);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
