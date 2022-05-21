using System;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Data.Database;
using VenoX.Data.Database.Models;
using VenoX.Debug;
using Initialize = VenoX.Core._Globals_.Initialize;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Preload_.Register
{
    public class Register : IScript
    {
        private static bool PlayerHaveAlreadyAccount(VnXPlayer playerClass)
        {
            bool state = false;
            foreach (DatabaseAccount accClass in global::VenoX.Data.Database.Constants.Accounts)
            {
                if (playerClass.HardwareIdHash == accClass.HardwareId || playerClass.HardwareIdExHash == accClass.HardwareIdEx || playerClass.SocialClubId == accClass.SocialClubId)
                {
                    //state = true;
                }
            }
            return state;
        }

        private static bool FoundAccountbyName(string name)
        {
            return global::VenoX.Data.Database.Constants.Accounts.Any(accClass => accClass.Username.ToLower() == name.ToLower());
        }

        public static void ChangeCharacterSexEvent(VnXPlayer player, int sex)
        {
            try
            {
                player.SetPlayerSkin(sex == 0 ? (uint)PedModel.FreemodeMale01 : (uint)PedModel.FreemodeFemale01);
                _RootCore_.VenoX.TriggerClientEvent(player, "Player:DefaultComponentVariation");
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
                if (PlayerHaveAlreadyAccount(player)) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Du hast bereits einen Account!"); return; }
                if (FoundAccountbyName(nickname)) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Nickname ist bereits vergeben!"); return; }
                if (password != passwordwdh) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Passwörter sind nicht identisch!"); return; }
                if (nickname.Contains(" ")) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Leerzeichen sind nicht erlaubt!"); return; }
                if (!evalid) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Ungültige E-Mail!"); }
                int sex = 0;
                string geschlechtalsstring = "Männlich";
                if (geschlecht == 1) { sex = 1; geschlechtalsstring = "Weiblich"; }

                string byCryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                Database.RegisterAccount(nickname, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), player.HardwareIdExHash.ToString(), email, byCryptedPassword, geschlechtalsstring, 0);
                int uid = Database.GetPlayerUid(nickname);
                player.CharacterUsername = nickname;
                player.CharacterId = uid;
                player.Sex = sex;
                Database.CreateCharacter(player, player.CharacterId);
                _RootCore_.VenoX.TriggerClientEvent(player, "DestroyLoginWindow");
                _RootCore_.VenoX.TriggerClientEvent(player, "CharCreator:Start", sex);
                player.Visible = false;
                player.Playing = true;
                VnX.PutPlayerInRandomDim(player);
                player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                ChangeCharacterSexEvent(player, sex);
                DatabaseAccount account = new()
                {
                    UID = player.CharacterId,
                    HardwareId = player.HardwareIdHash,
                    HardwareIdEx = player.HardwareIdExHash,
                    Username = nickname,
                    Email = email,
                    Password = byCryptedPassword,
                    SocialClubId = player.SocialClubId,
                    Language = global::VenoX.Core._Language_.Main.GetClientLanguagePair(global::VenoX.Core._Language_.Constants.Languages.English),
                    Coins = 10,
                    RegisterDate = DateTime.Now
                };
                await using VenoXContext db = new();
                db.Accounts.Add(account);
                global::VenoX.Data.Database.Constants.Accounts.Add((account));
                await db.SaveChangesAsync();
                await Program.CreateForumUser(player.CharacterId, nickname, email, password);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
