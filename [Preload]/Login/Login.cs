using AltV.Net;
using AltV.Net.Data;
using System;
using System.Security.Cryptography;
using System.Text;
using VenoXV._Admin_;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

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
        public static bool LoginAccount(string Nickname, string Password)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == Nickname.ToLower())
                {
                    if (accClass.Password == Password)
                        return true;
                }
            }
            return false;
        }
        public static bool ChangeAccountPW(string Nickname, string Password)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == Nickname.ToLower())
                {
                    accClass.Password = Password;
                    return true;
                }
            }
            return false;
        }
        public static AccountModel GetAccountModel(string Nickname, string Password)
        {
            foreach (AccountModel accClass in Register.Register.AccountList)
            {
                if (accClass.Name.ToLower() == Nickname.ToLower())
                {
                    if (accClass.Password == Password)
                    {
                        return accClass;
                    }
                }
            }
            return null;
        }

        public static void ShowBanWindow(VnXPlayer player)
        {
            try
            {
                BanModel BanClass = Admin.GetClientBanModel(player);
                Core.Debug.OutputDebugString("Function called because " + player.Name + " is banned");
                if (BanClass is null) return;
                if (BanClass.BanType == "Permaban") VenoX.TriggerClientEvent(player, "BanWindow:Create", BanClass.Name, "Permanently", BanClass.Reason);
                else VenoX.TriggerClientEvent(player, "BanWindow:Create", BanClass.Name, BanClass.BannedTill.ToString(), BanClass.Reason);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [ClientEvent("LoginAccount")]
        public static void LoginAccountEvent(VnXPlayer player, string Nickname, string Password)
        {
            try
            {
                if (Admin.IsClientBanned(player)) { ShowBanWindow(player); return; }
                AccountModel accClass;
                if (!LoginAccount(Nickname, Sha256(Password))) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Wrong Username/Password"); return; }
                accClass = GetAccountModel(Nickname, Sha256(Password));
                if (accClass == null) return;
                Database.LoadCharacterInformationById(player, accClass.UID);
                if (!Character_Creator.Main.PlayerHaveSkin(player))
                {
                    VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                    VenoX.TriggerClientEvent(player, "CharCreator:Start", player.Sex);
                    player.Playing = true;
                    _Gamemodes_.Reallife.anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                    player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                    Register.Register.ChangeCharacterSexEvent(player, player.Sex);
                    return;
                }
                if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
                VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                Preload.ShowPreloadList(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
