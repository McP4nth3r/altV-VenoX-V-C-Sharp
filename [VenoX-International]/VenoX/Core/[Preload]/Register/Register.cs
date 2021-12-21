using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._Notifications_;
using VenoXV.Core;
using VenoXV.Models;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

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
                if (playerClass.HardwareIdHash.ToString() == accClass.HardwareId || playerClass.HardwareIdExHash.ToString() == accClass.HardwareIdExhash || playerClass.SocialClubId.ToString() == accClass.SocialId)
                {
                    //state = true;
                }
            }
            return state;
        }

        public static bool FoundAccountbyName(string name)
        {
            foreach (AccountModel accClass in AccountList)
            {
                if (accClass.Name.ToLower() == name.ToLower())
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
                player.SetPlayerSkin(sex == 0 ? (uint)PedModel.FreemodeMale01 : (uint)PedModel.FreemodeFemale01);
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

        [AsyncClientEvent("Account:Register")]
        public static async Task OnRegisterCall(VnXPlayer player, string nickname, string email, string password, string passwordwdh, int geschlecht, bool evalid)
        {
            try
            {

                if (nickname.Length < 1 || email.Length < 1 || password.Length < 1 || passwordwdh.Length < 1) return;
                if (PlayerHaveAlreadyAccount(player)) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Du hast bereits einen Account!"); return; }
                if (FoundAccountbyName(nickname)) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Nickname ist bereits vergeben!"); return; }
                if (password != passwordwdh) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Passwörter sind nicht identisch!"); return; }
                if (nickname.Contains(" ")) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Leerzeichen sind nicht erlaubt!"); return; }
                if (!evalid) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Ungültige E-Mail!"); }
                int sex = 0;
                string geschlechtalsstring = "Männlich";
                if (geschlecht == 1) { sex = 1; geschlechtalsstring = "Weiblich"; }

                string byCryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                Database.Database.RegisterAccount(nickname, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), player.HardwareIdExHash.ToString(), email, byCryptedPassword, geschlechtalsstring, 0);
                int uid = Database.Database.GetPlayerUid(nickname);
                player.Username = nickname;
                player.UID = uid;
                player.Sex = sex;
                Database.Database.CreateCharacter(player, player.UID);
                VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                VenoX.TriggerClientEvent(player, "CharCreator:Start", sex);
                player.Visible = false;
                player.Playing = true;
                VnX.PutPlayerInRandomDim(player);
                player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                ChangeCharacterSexEvent(player, sex);
                AccountModel account = new AccountModel
                {
                    Uid = player.UID,
                    HardwareId = player.HardwareIdHash.ToString(),
                    HardwareIdExhash = player.HardwareIdExHash.ToString(),
                    Name = nickname,
                    Email = email,
                    Password = byCryptedPassword,
                    SocialId = player.SocialClubId.ToString(),
                    Language = _Language_.Main.GetClientLanguagePair(_Language_.Main.Languages.English)
                };
                AccountList.Add(account);
                await Program.CreateForumUser(player.UID, nickname, email, password);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
