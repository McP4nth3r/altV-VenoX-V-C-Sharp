using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._Gamemodes_.Reallife.admin;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._Globals_.EntityDatas;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {
        public static void InitializePlayerData(Client player)
        {
            // Spawn pos 2
            player.SpawnPlayer(player.Position);
            Position rotation = new Position(0.0f, 0.0f, 0.0f);
            player.SetPosition = new Position(152.26f, -1004.47f, -99.00f);
            player.Dimension = player.Id;
            player.Health = 100;
            player.Armor = 0;

            player.RemoveAllPlayerWeapons();
            player.SetVnXName("Random-Player");
            player.vnxSetElementData(Globals.EntityData.PLAYER_SEX, 0);
            player.vnxSetElementData(Globals.EntityData.PLAYER_MONEY, 0);
            player.vnxSetElementData(Globals.EntityData.PLAYER_BANK, 3500);
            player.vnxSetElementData(EntityData.PLAYER_NAME, string.Empty);
            player.vnxSetElementData(EntityData.PLAYER_HEALTH, 100);
            player.vnxSetElementData(EntityData.PLAYER_ARMOR, 0);
            player.vnxSetElementData(Globals.EntityData.PLAYER_VIP_LEVEL, "-");
            player.vnxSetElementData(Globals.EntityData.PLAYER_RANK, 0);

            player.vnxSetElementData(Globals.EntityData.PLAYER_PLAYED, 0);
            player.vnxSetStreamSharedElementData("settings_atm", "ja");
            player.vnxSetStreamSharedElementData("settings_haus", "ja");
            player.vnxSetStreamSharedElementData("settings_tacho", "ja");
            player.vnxSetStreamSharedElementData("settings_quest", "ja");
            player.vnxSetStreamSharedElementData("settings_reporter", "ja");
            player.vnxSetStreamSharedElementData("settings_globalchat", "ja");
            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_STATUS, "VenoX");
            player.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
        }

        public static void LoadPlayerData(Client player, Client character)
        {
            player.vnxSetElementData(Globals.EntityData.PLAYER_SEX, character.Sex);
            player.vnxSetElementData(EntityData.PLAYER_NAME, character.Username);
            player.vnxSetElementData(Globals.EntityData.PLAYER_RANK, character.Reallife.FactionRank);
            player.vnxSetElementData(Globals.EntityData.PLAYER_PLAYED, character.Played);
            player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_BANK, character.Reallife.Bank);
            player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_STATUS, character.Reallife.SocialState);
            player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_MONEY, character.Reallife.Money);
            player.vnxSetElementData(Globals.EntityData.PLAYER_SQL_ID, character.UID);
        }

        private static bool PlayerHaveAlreadyAccount(Client player)
        {
            try
            {
                if (Database.FindAccount(player.SocialClubId.ToString())) { Core.Debug.OutputDebugString("FOUND_ACCOUNT_SOCIALCLUB_ID"); return true; }
                if (Database.FindAccountByHardwareIdHash(player.HardwareIdHash.ToString())) { Core.Debug.OutputDebugString("FOUND_ACCOUNT_HARDWARE_ID"); return true; }
                if (Database.FindAccountByHardwareIdExHash(player.HardwareIdExHash.ToString())) { Core.Debug.OutputDebugString("FOUND_ACCOUNT_HARDWARE_ID_EX_HASH"); return true; }
                return false;
            }
            catch { return false; }
        }

        [ClientEvent("Account:Register")]
        public static void OnRegisterCall(Client player, string nickname, string email, string password, string passwordwdh, string geschlecht, bool evalid)
        {
            try
            {
                if (nickname.Length < 1 || email.Length < 1 || password.Length < 1 || passwordwdh.Length < 1) { return; }
                if (PlayerHaveAlreadyAccount(player))
                {
                    string PlayerName = Database.GetAccountNameByHardwareId(player.HardwareIdHash.ToString());
                    _Gamemodes_.Reallife.dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits einen Account! " + PlayerName);
                    return;
                }
                bool hasData = Database.FindCharacterName(nickname);
                if (hasData) { _Gamemodes_.Reallife.dxLibary.VnX.DrawNotification(player, "error", "Nickname ist bereits vergeben!"); return; }
                if (password != passwordwdh) { player.Emit("show_register_error", "1", "Passwörter sind nicht identisch!"); return; }
                if (!evalid) { player.Emit("show_register_error", "1", "Ungültige E-Mail!"); }

                string geschlechtalsstring = "Männlich";
                if (geschlecht == "1") { geschlechtalsstring = "Weiblich"; }

                //ToDo : Fix & find another Way! player.GetVnXName() = nickname;
                Database.RegisterAccount(nickname, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), player.HardwareIdExHash.ToString(), email, password, geschlechtalsstring);
                _ = Program.CreateForumUser(player.GetVnXName(), email, password);
                player.Emit("DestroyLoginWindow");
                player.Emit("CharCreator:Start", geschlecht);
                player.vnxSetStreamSharedElementData("PLAYER_LOGGED_IN", 1);

                _Gamemodes_.Reallife.anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                player.SpawnPlayer(new Position(402.778f, -996.9758f, -99));
                if (geschlecht == "1") { ChangeCharacterSexEvent(player, 1); player.SetPlayerSkin(Alt.Hash("mp_f_freemode_01")); }
                else { ChangeCharacterSexEvent(player, 0); player.SetPlayerSkin(Alt.Hash("mp_m_freemode_01")); }
                Database.SetVIPStats(Database.GetAccountUID(player.SocialClubId.ToString()), "Abgelaufen", 0);
                player.vnxSetElementData(Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                _Gamemodes_.Reallife.gangwar.Allround._gangwarManager.UpdateData(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("RegisterAccount", ex); }
        }


        public static void ChangeCharacterSexEvent(Client player, int sex)
        {
            try
            {
                // Set the model of the player
                //NAPI.Player.SetPlayerSkin(player, sex == 0 ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
                player.SetPlayerSkin(sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
                // Remove player's clothes
                player.SetClothes(11, 15, 0);
                player.SetClothes(3, 15, 0);
                player.SetClothes(8, 15, 0);

                // Save sex entity shared data
                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_SEX, sex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.StackTrace);
            }
        }

        [ClientEvent("loginAccount")]
        public void LoginAccountEvent(Client player, string username, string password)
        {
            try
            {
                bool login = Database.LoginAccountByName(username, password);
                if (login)
                {
                    player.SetVnXName(username);
                    if (username.ToLower() != player.GetVnXName().ToLower())
                    {
                        player.SendTranslatedChatMessage("Bitte änder in den Alt:V Einstellungen deinen Benutzernamen!");
                        player.Kick("Bitte änder in den Alt:V Einstellungen deinen Benutzernamen!");
                        return;
                    }
                    player.Emit("DestroyLoginWindow");
                    player.Emit("preload_gm_list");
                    VenoXV.Preload.Preload.GetAllPlayersInAllGamemodes(player);

                    bool hasDataName = Database.FindAccountByName(username);

                    if (hasDataName)
                    {
                        bool hasCharakter = Database.FindCharacterByUID(Database.GetAccountUIDByName(username));
                        if (hasCharakter)
                        {
                            int player_uid = Database.GetAccountUIDByName(username);
                            if (player_uid < 0)
                            {
                                return;
                            }
                            Client character = Database.LoadCharacterInformationById(player, player_uid);
                            SkinModel skinModel = Database.GetCharacterSkin(player_uid);
                            if (character != null && character.Username != null)
                            {
                                player.SpawnPlayer(player.Position);
                                player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_SKIN_MODEL, skinModel);
                                player.SetPlayerSkin(character.Sex == 0 ? Alt.Hash("mp_m_freemode_01") : Alt.Hash("mp_f_freemode_01"));
                                LoadPlayerData(player, character);
                                player.vnxSetStreamSharedElementData("HideHUD", 1);

                                _Gamemodes_.Reallife.anzeigen.Usefull.VnX.UpdateHUD(player);
                                Customization.ApplyPlayerClothes(player);
                                Customization.ApplyPlayerCustomization(player, skinModel, character.Sex);
                                Customization.ApplyPlayerTattoos(player);

                                foreach (var Tankstellen in _Gamemodes_.Reallife.Globals.Constants.AUTO_ZAPF_LIST_BLIPS)
                                {
                                    player.Emit("ShowTankstellenBlips", Tankstellen);
                                }
                            }
                            else
                            {
                                Admin.sendAdminNotification(player.GetVnXName() + " | " + player.SocialClubId.ToString() + " hat Probleme beim Einloggen! Schwerwiegender Fehler... Bitte bei Solid_Snake melden !");
                            }
                        }
                        else
                        {
                            player.Emit("LoadReallifeGamemodeRemote");
                            // //ToDo : Fix & find another Way! player.GetVnXName() = Database.GetAccountSpielerName(player.SocialClubId.ToString());
                            //player.Transparency = 255;
                            player.SetPlayerAlpha(255);
                            string Geschlecht = Database.GetAccountGeschlecht(player.SocialClubId.ToString());
                            int Geschlecht_ = 0;
                            if (Geschlecht == "Männlich")
                            {
                                Geschlecht_ = 0;
                            }
                            else
                            {
                                Geschlecht_ = 1;
                            }
                            ChangeCharacterSexEvent(player, Geschlecht_);
                            player.Emit("showCharacterCreationMenu");
                            player.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, Globals.EntityData.GAMEMODE_REALLIFE);
                        }
                        return;
                    }
                    return;

                }
                else
                {
                    player.Emit("showLoginError");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ShowLogin", ex); }
        }
    }
}
