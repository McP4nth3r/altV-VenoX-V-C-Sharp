using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_.Register
{
    public class Register : IScript
    {

        public static List<AccountModel> AccountList;

        public static bool PlayerHaveAlreadyAccount(VnXPlayer playerClass)
        {
            bool state = false;
            foreach (AccountModel accClass in AccountList)
            {
                if (playerClass.HardwareIdHash.ToString() == accClass.HardwareId || playerClass.HardwareIdExHash.ToString() == accClass.HardwareIdExhash || playerClass.SocialClubId.ToString() == accClass.SocialID)
                {
                    state = true;
                }
            }
            return state;
        }

        public static bool FoundAccountbyName(string Name)
        {
            foreach (AccountModel accClass in AccountList)
            {
                if (accClass.Name.ToLower() == Name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public static void ChangeCharacterSexEvent(VnXPlayer player, int sex)
        {
            try
            {
                player.SetPlayerSkin(sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
                VenoX.TriggerClientEvent(player, "Player:DefaultComponentVariation");
                /*player.SetClothes(11, 15, 0);
                player.SetClothes(3, 15, 0);
                player.SetClothes(8, 15, 0);*/
                player.Sex = sex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.StackTrace);
            }
        }

        [ClientEvent("Account:Register")]
        public static void OnRegisterCall(VnXPlayer player, string nickname, string email, string password, string passwordwdh, int geschlecht, bool evalid)
        {
            try
            {
                if (nickname.Length < 1 || email.Length < 1 || password.Length < 1 || passwordwdh.Length < 1) return;
                if (PlayerHaveAlreadyAccount(player)) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits einen Account!"); return; }
                if (FoundAccountbyName(nickname)) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Nickname ist bereits vergeben!"); return; }
                if (password != passwordwdh) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Passwörter sind nicht identisch!"); return; }
                if (nickname.Contains(" ")) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Leerzeichen sind nicht erlaubt!"); return; }
                if (!evalid) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Ungültige E-Mail!"); }
                int sex = 0;
                string geschlechtalsstring = "Männlich";
                if (geschlecht == 1) { sex = 1; geschlechtalsstring = "Weiblich"; }
                Database.RegisterAccount(nickname, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), player.HardwareIdExHash.ToString(), email, password, geschlechtalsstring, 0);
                int UID = Database.GetPlayerUID(nickname);
                player.Username = nickname;
                player.UID = UID;
                player.Sex = sex;
                Database.CreateCharacter(player, player.UID);
                VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                VenoX.TriggerClientEvent(player, "CharCreator:Start", sex);
                player.Visible = false;
                player.Playing = true;
                _Gamemodes_.Reallife.anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                ChangeCharacterSexEvent(player, sex);
                AccountModel account = new AccountModel
                {
                    UID = player.UID,
                    HardwareId = player.HardwareIdHash.ToString(),
                    HardwareIdExhash = player.HardwareIdExHash.ToString(),
                    Name = nickname,
                    Password = Login.Login.Sha256(password),
                    SocialID = player.SocialClubId.ToString()
                };
                AccountList.Add(account);
                Program.CreateForumUser(player, nickname, email, password);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
