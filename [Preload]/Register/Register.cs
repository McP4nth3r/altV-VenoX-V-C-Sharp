using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_.Register
{
    public class Register : IScript
    {

        public static List<AccountModel> AccountList;

        public static bool PlayerHaveAlreadyAccount(Client playerClass)
        {
            bool state = false;
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

        public static void ChangeCharacterSexEvent(Client player, int sex)
        {
            try
            {
                player.SetPlayerSkin(sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
                player.SetClothes(11, 15, 0);
                player.SetClothes(3, 15, 0);
                player.SetClothes(8, 15, 0);
                player.Sex = sex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.StackTrace);
            }
        }

        [ClientEvent("Account:Register")]
        public static void OnRegisterCall(Client player, string nickname, string email, string password, string passwordwdh, string geschlecht, bool evalid)
        {
            try
            {
                if (nickname.Length < 1 || email.Length < 1 || password.Length < 1 || passwordwdh.Length < 1) { return; }
                if (PlayerHaveAlreadyAccount(player)) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Nickname ist bereits vergeben!"); return; }
                if (FoundAccountbyName(nickname)) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Nickname ist bereits vergeben!"); return; }
                if (password != passwordwdh) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Passwörter sind nicht identisch!"); return; }
                if (!evalid) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ungültige E-Mail!"); }

                int sex = 0;
                string geschlechtalsstring = "Männlich";
                if (geschlecht == "1") { sex = 1; geschlechtalsstring = "Weiblich"; }
                Core.Debug.OutputDebugString("SEX" + geschlecht);
                Database.RegisterAccount(nickname, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), player.HardwareIdExHash.ToString(), email, password, geschlechtalsstring);
                Database.CreateCharacter(player, player.UID);
                _ = Program.CreateForumUser(nickname, email, password);
                player.Emit("DestroyLoginWindow");
                player.Emit("CharCreator:Start", sex);
                player.Playing = true;
                player.Username = nickname;
                _Gamemodes_.Reallife.anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                player.SpawnPlayer(new Position(402.778f, -998.9758f, -99));
                ChangeCharacterSexEvent(player, sex);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("RegisterAccount", ex); }
        }
    }
}
