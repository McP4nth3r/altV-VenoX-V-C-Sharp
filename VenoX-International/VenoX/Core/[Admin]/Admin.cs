using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoX.Core._Gamemodes_.Reallife.factions;
using VenoX.Core._Gamemodes_.Reallife.gangwar.v2;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.house;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Gamemodes_.Reallife.vehicles;
using VenoX.Core._Preload_.Login;
using VenoX.Core._Preload_.Model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.Sync;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;
using Allround = VenoX.Core._Gamemodes_.Reallife.fun.Aktionen.Allround;
using EntityData = VenoX.Core._Globals_.EntityData;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;
using Main = VenoX.Core._Language_.Main;
using VehicleModel = VenoX.Core._RootCore_.Models.VehicleModel;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Admin_
{
    public class Admin : IScript
    {

        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands

        public static async void SendAdminNotification(string text)
        {
            foreach (VnXPlayer admin in _RootCore_.VenoX.GetAllPlayers().ToList().Where(admin => admin.AdminRank >= Constants.AdminlvlTsupporter))
            {
                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)admin.Language, text);
                admin.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 0, 0) + translatedtext);
            }
        }

        public static async void SendAdminInformation(string text)
        {
            try
            {
                foreach (VnXPlayer admin in _RootCore_.VenoX.GetAllPlayers().ToList().Where(admin => admin.AdminRank >= Constants.AdminlvlTsupporter))
                {
                    string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)admin.Language, text);
                    admin.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[Info] : " + RageApi.GetHexColorcode(255, 255, 255) + translatedtext);
                }
            }
            catch
            {
                // ignored
            }
        }

        public static bool HaveAdminRights(VnXPlayer player)
        {
            return player.AdminRank >= Constants.AdminlvlSupporter;
        }


        [Command("evalc")]
        public static void HideHudForPlayer(VnXPlayer player, string st)
        {
            _RootCore_.VenoX.TriggerClientEvent(player, "eval", st);
        }

        [Command("admins")]
        public static async void AdminsIngameCommand(VnXPlayer player)
        {
            try
            {
                //foreach (string target_namesingame in VenoX.GetAllPlayers().ToList())
                player.SendChatMessage("---------------------------------------------------------");
                player.SendTranslatedChatMessage("Folgende Admins sind grade Online : ");
                foreach (VnXPlayer targetsingame in _RootCore_.VenoX.GetAllPlayers().ToList().OrderBy(p => p.AdminRank).Reverse())
                {
                    if (targetsingame.AdminRank >= Constants.AdminlvlTsupporter)
                    {
                        switch (targetsingame.AdminRank)
                        {
                            case 7:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Projektleitung");
                                player.SendChatMessage("{B40000}[VnX]" + targetsingame.CharacterUsername + ", " + translatedtext);
                                break;
                            }
                            case 6:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Stellv.Projektleitung");
                                player.SendChatMessage("{EC0000}[VnX]" + targetsingame.CharacterUsername + ", " + translatedtext);
                                break;
                            }
                            case 5:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Administrator");
                                player.SendChatMessage("{E8AE00}[VnX]" + targetsingame.CharacterUsername + ", " + translatedtext);
                                break;
                            }
                            case 4:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Moderator");
                                player.SendChatMessage("{002DE0}[VnX]" + targetsingame.CharacterUsername + ", " + translatedtext);
                                break;
                            }
                            case 3:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Supporter");
                                player.SendChatMessage("{006600}[VnX]" + targetsingame.CharacterUsername + ", " + translatedtext);
                                break;
                            }
                            case 2:
                            {
                                string translatedtext = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)targetsingame.Language, "Ticket - Supporter");
                                player.SendChatMessage("{C800C8}" + $"{targetsingame.CharacterUsername}, " + translatedtext);
                                break;
                            }
                        }
                    }
                }
                player.SendChatMessage("---------------------------------------------------------");
            }
            catch
            {
                // ignored
            }
        }


        public static string GetRgbaedClantag(int adminlvl)
        {
            try
            {
                return adminlvl switch
                {
                    2 => "{C800C8}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    3 => "{006600}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    4 => "{002DE0}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    5 => "{E8AE00}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    6 => "{EC0000}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    7 => "{B40000}[VnX]" + RageApi.GetHexColorcode(255, 255, 255),
                    _ => "",
                };
            }
            catch { return ""; }

        }



        [Command("debugcef")]
        public static void CheckIfCEFExists(VnXPlayer player)
        {
            if (player.AdminRank < Constants.AdminlvlProjektleiter) return;
            _RootCore_.VenoX.TriggerClientEvent(player, "Lib:DebugCEFBrowser");
            ConsoleHandling.OutputDebugString("Lib:DebugCEFBrowser Called!");
        }






        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////

        [Command("clearchat")]
        public static void ClearChatForEveryone(VnXPlayer player)
        {
            if (player.AdminRank < Constants.AdminlvlModerator) return;
            for (int i = 0; i < 50; ++i)
            {
                RageApi.SendTranslatedChatMessageToAll(" ");
            }
            Logfile.WriteLogs("admin", player.CharacterUsername + " hat den Chat gecleared!");
        }

        [Command("clearc")]
        public static void ClearCForEveryone(VnXPlayer player)
        {
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            player.SendTranslatedChatMessage(".");
            for (int i = 0; i < 50; ++i)
            {
                RageApi.SendTranslatedChatMessageToAll(" ");
            }
            Logfile.WriteLogs("admin", player.CharacterUsername + " hat den Chat gecleared!");
        }


        [Command("adstate")]
        public static void SetAdState(VnXPlayer player, int werbung)
        {
            if (player.AdminRank < Constants.AdminlvlModerator) return;
            string state = RageApi.GetHexColorcode(0, 175, 0) + "angeschaltet!";
            switch (werbung)
            {
                case 0:
                    state = RageApi.GetHexColorcode(175, 0, 0) + "ausgeschaltet!";
                    break;
                case 1:
                    RageApi.SendTranslatedChatMessageToAll(Constants.RgbaAdminClantag + player.CharacterUsername + " hat das AD-System " + state);
                    break;
                default:
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Status muss 1 oder 0 sein!");
                    break;
            }
        }

        [Command("ochat", true)]
        public static void OchatCommand(VnXPlayer player, string message)
        {
            try
            {
                switch (player.AdminRank)
                {
                    case <= Constants.AdminlvlNone:
                        return;
                    case 7:
                        RageApi.SendTranslatedChatMessageToAll("(( {B40000}Projektleitung " + player.CharacterUsername + ": {FFFFFF}" + message + " )) ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Projektleitung " + player.CharacterUsername + ": " + message + " }} ");
                        break;
                    case 6:
                        RageApi.SendTranslatedChatMessageToAll("(( {EC0000}Stellv.Projektleitung " + player.CharacterUsername + ": {FFFFFF}" + message + " )) ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Stellv.Projektleitung " + player.CharacterUsername + ": " + message + " }} ");
                        break;
                    case 5:
                        RageApi.SendTranslatedChatMessageToAll("(( {E8AE00}Administrator " + player.CharacterUsername + ": {FFFFFF}" + message + " )) ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Administrator " + player.CharacterUsername + ": " + message + " }} ");
                        break;
                    case 4:
                        RageApi.SendTranslatedChatMessageToAll("(( {002DE0}Moderator " + player.CharacterUsername + ": {FFFFFF}" + message + " )) ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Moderator " + player.CharacterUsername + ": " + message + " }} ");
                        break;
                    case 3:
                        player.SendTranslatedChatMessage("{FF0000}Du bist nicht Befugt!");
                        Logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.CharacterUsername + " hat versucht in dem O - Chat zu schreiben! }} ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.CharacterUsername + " versuchte Nachricht : " + message + " }}");
                        break;
                    case 2:
                        player.SendTranslatedChatMessage("{FF0000}Du bist nicht Befugt!");
                        Logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.CharacterUsername + " hat versucht in dem O - Chat zu schreiben! }} ");
                        Logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.CharacterUsername + " versuchte Nachricht : " + message + " }}");
                        break;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("unprison")]
        public static void UnPrisonPlayer(VnXPlayer player, string target)
        {
            if (player.AdminRank < Constants.AdminlvlModerator) return;
            bool found = Database.FindCharacterByName(target);
            if (!found) return;
            string socialClubId = Database.GetCharacterSocialName(target);
            string spielerName = Database.GetAccountPlayerName(socialClubId);
            VnXPlayer targetplayer = RageApi.GetPlayerFromName(spielerName);
            int uid = Database.GetCharakterUid(spielerName);
            if (Database.FindCharakterPrison(spielerName))
            {
                Database.RemoveOldPrison(spielerName);
            }
            else
            {
                _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Der Spieler ist nicht im Prison!");
            }

            if (targetplayer == null) return;
            //AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
            targetplayer.Dimension = _Globals_.Initialize.ReallifeDimension + targetplayer.Language;
            targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
            VnX.RemoveAllWeapons(targetplayer);
            targetplayer.VnxSetElementData(EntityData.PlayerPrisonTime, 0);
            targetplayer.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
            Spawn.SpawnPlayerOnSpawnpoint(targetplayer);

        }

        public static List<BanModel> PlayerBans = new List<BanModel>();
        public static bool IsClientBanned(VnXPlayer target)
        {
            try
            {
                foreach (BanModel banClass in PlayerBans.ToList())
                {
                    if (banClass.BannedTill < DateTime.Now && banClass.BanType == "Timeban")
                    {
                        Database.RemoveOldBan(banClass.Uid);
                        PlayerBans.Remove(banClass);
                        continue;
                    }
                    if (banClass.Name == target.CharacterUsername) return true;
                    if (banClass.HardwareId == target.HardwareIdHash.ToString() && banClass.HardwareId.Length > 1) return true;
                    if (banClass.HardwareIdExHash == target.HardwareIdExHash.ToString() && banClass.HardwareIdExHash.Length > 1) return true;
                    if (banClass.DiscordId == target.Discord.Id && banClass.DiscordId.Length > 1) return true;
                    if (banClass.Ip == target.Ip && banClass.Ip.Length > 1) return true;
                    if (banClass.SocialClubId == target.SocialClubId.ToString() && banClass.SocialClubId.Length > 1) return true;
                }
                return false;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }
        public static BanModel GetClientBanModel(VnXPlayer player)
        {
            try
            {
                foreach (BanModel banClass in PlayerBans)
                {
                    if (banClass.Name == player.CharacterUsername) return banClass;
                    if (banClass.HardwareId == player.HardwareIdHash.ToString() && banClass.HardwareId.Length > 1) return banClass;
                    if (banClass.HardwareIdExHash == player.HardwareIdExHash.ToString() && banClass.HardwareIdExHash.Length > 1) return banClass;
                    if (banClass.DiscordId == player.Discord.Id && banClass.DiscordId.Length > 1) return banClass;
                    if (banClass.Ip == player.Ip && banClass.Ip.Length > 1) return banClass;
                    if (banClass.SocialClubId == player.SocialClubId.ToString() && banClass.SocialClubId.Length > 1) return banClass;
                    /*
                    Debug.OutputDebugString("BanClass.Name : " + BanClass.Name + " | " + player.Username);
                    Debug.OutputDebugString("BanClass.HardwareId : " + BanClass.HardwareId + " | " + player.HardwareIdHash);
                    Debug.OutputDebugString("BanClass.HardwareIdExHash : " + BanClass.HardwareIdExHash + " | " + player.HardwareIdExHash);
                    Debug.OutputDebugString("BanClass.DiscordID : " + BanClass.DiscordID + " | " + player.Discord.ID);
                    Debug.OutputDebugString("BanClass.IP : " + BanClass.IP + " | " + player.Ip);
                    Debug.OutputDebugString("BanClass.SocialClubId : " + BanClass.SocialClubId + " | " + player.SocialClubId);*/
                }
                return null;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return null; }
        }
        [Command("permaban")]
        public static void permaban_player(VnXPlayer player, string targetName, params string[] grundArray)
        {
            try
            {
                /*string grund = string.Join(" ", grundArray);
                if (player.AdminRank >= Constants.AdminlvlModerator)
                {
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    if (target is null)
                    {
                        foreach (DatabaseAccount accClass in global::VenoX.Data.Database.Constants.Accounts)
                        {
                            if (accClass.Username.ToLower() != targetName.ToLower()) continue;
                            BanModel banClass = new BanModel
                            {
                                Uid = accClass.Uid,
                                Name = accClass.Name,
                                HardwareId = accClass.HardwareId,
                                HardwareIdExHash = accClass.HardwareIdExhash,
                                DiscordId = "",
                                Ip = "",
                                SocialClubId = accClass.SocialId,
                                BanCreated = DateTime.Now,
                                BannedTill = DateTime.Now,
                                BanType = "Permaban"
                            };
                            PlayerBans.Add(banClass);
                            Database.Database.AddPlayerPermaBan(accClass.Uid, accClass.Name, accClass.HardwareId, accClass.HardwareIdExhash, accClass.SocialId, "", "", grund, player.CharacterUsername);
                            Logfile.WriteLogs("admin", player.CharacterUsername + " banned " + accClass.Name + " permanently! Reason : " + grund);
                            RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " banned " + accClass.Name + " permanently! Reason : " + grund);
                            return;
                        }
                    }
                    else
                    {
                        BanModel banClass = new BanModel
                        {
                            Uid = target.CharacterId,
                            Name = target.Name,
                            HardwareId = target.HardwareIdHash.ToString(),
                            HardwareIdExHash = target.HardwareIdExHash.ToString(),
                            DiscordId = target.Discord.Id,
                            Ip = target.Ip,
                            SocialClubId = target.SocialClubId.ToString(),
                            BanCreated = DateTime.Now,
                            BannedTill = DateTime.Now,
                            BanType = "Permaban"
                        };
                        PlayerBans.Add(banClass);
                        Database.Database.AddPlayerPermaBan(target.CharacterId, target.CharacterUsername, target.HardwareIdHash.ToString(), target.HardwareIdExHash.ToString(), target.SocialClubId.ToString(), target.Ip, target.Discord.Id, grund, player.CharacterUsername);
                        Logfile.WriteLogs("admin", player.CharacterUsername + " banned " + target.CharacterUsername + " permanently! Reason : " + grund);
                        RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " banned " + target.CharacterUsername + " permanently! Reason : " + grund);
                        target.Kick(grund);
                        //RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                    }
                }*/
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }



        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////



        [Command("updateinventar")]
        public static void UpdateTargetInventar(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            List<ItemModel> inventory = _Gamemodes_.Reallife.anzeigen.Inventar.Main.GetPlayerInventory(target);
            _RootCore_.VenoX.TriggerClientEvent(target, "Inventory:Update", JsonConvert.SerializeObject(inventory));
        }

        [Command("clearinventar")]
        public static void ClearTargetPlayerInventar(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    int targetId = target.CharacterId;
                    if (targetId > 0)
                    {
                        foreach (ItemModel item in Inventory.DatabaseItems.ToList())
                        {
                            if (item.Uid == targetId)
                            {
                                Inventory.DatabaseItems.Remove(item);
                            }
                        }
                        player.Inventory.Items.Clear();
                        Database.RemoveAllItems(targetId);
                    }
                    player.SendChatMessage("Du hast das Inventar von " + target.CharacterUsername + " geleert!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.Message);
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.StackTrace);
            }
        }

        public const string ItemArtWaffe = "Waffe";
        public const string ItemArtDrogen = "Drogen";
        public const string ItemArtNutzItem = "NUTZ_ITEM";
        public const string ItemArtMagazin = "Magazin";
        public const string ItemArtFallschirm = "Fallschirm";
        public const string ItemArtBusiness = "Business";
        [Command("giveitem")]
        public static void GiveAdminWeapons(VnXPlayer player, string hash, int itemArt, int itemAmount, string weightstring)
        {
            float weight = float.Parse(weightstring);
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                player.Inventory.GiveItem(hash, (ItemType)itemArt, itemAmount, true, weight: weight);
            }
        }

        [Command("coord")]
        public void CoordCommand(VnXPlayer player, float posX, float posY, float posZ)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                //AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                player.SetPosition = new Position(posX, posY, posZ);
                player.VnxSetElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerHouseEntered, 0);
                player.VnxSetElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerBusinessEntered, 0);
            }
        }

        [Command("sstate")]
        public static void SetSocialStatePlayer(VnXPlayer player, string targetName, string value)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                target.Reallife.SocialState = value;
                SendAdminNotification(player.CharacterUsername + " hat " + target.CharacterUsername + " Sozialen Status geändert zu " + value + ".");
                Logfile.WriteLogs("admin", player.CharacterUsername + " hat " + target.CharacterUsername + " sozialen status auf " + value + " geändert!");
            }
        }


        [Command("triggersound")]
        public static void TriggerSoundEffect(VnXPlayer player, string targetName, string soundName, string soundSetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                _RootCore_.VenoX.TriggerClientEvent(target, "VnX_Play_Sound", soundName, soundSetName);
            }
        }

        [Command("triggermp3")]
        public static void Triggeraudio(VnXPlayer player, string targetName, string audioclass)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                _RootCore_.VenoX.TriggerClientEvent(target, "load_audio_table_vnx", audioclass);
            }
        }

        [Command("triggerfx")]
        public static void Triggerfx(VnXPlayer player, string targetName, string effect, int duration, bool loop)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                _RootCore_.VenoX.TriggerClientEvent(target, "start_screen_fx", effect, duration, loop);
            }
        }

        [Command("stopfx")]
        public static void StopfxAdmin(VnXPlayer player, string targetName, string effect)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                _RootCore_.VenoX.TriggerClientEvent(target, "stop_screen_fx", effect);
            }
        }

        [Command("setpremium")]
        public static void GivePremiumToPlayer(VnXPlayer player, string targetName, int paketNr, int tage)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                switch (paketNr)
                {
                    case 0:
                        Database.SetVipStats(target.CharacterId, "Abgelaufen", 0);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "-");
                        break;
                    case 1:
                        Database.SetVipStats(target.CharacterId, "Bronze", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "Bronze");
                        break;
                    case 2:
                        Database.SetVipStats(target.CharacterId, "Silber", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "Silber");
                        break;
                    case 3:
                        Database.SetVipStats(target.CharacterId, "Gold", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "Gold");
                        break;
                    case 4:
                        Database.SetVipStats(target.CharacterId, "UltimateRed", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "UltimateRed");
                        break;
                    case 5:
                        Database.SetVipStats(target.CharacterId, "Platin", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "Platin");
                        break;
                    case 6:
                        Database.SetVipStats(target.CharacterId, "TOP DONATOR", tage);
                        SendAdminNotification(player.CharacterUsername + " hat das VIP Level von " + target.CharacterUsername + " auf " + paketNr + " geändert! (" + tage + " Tage)");
                        target.VnxSetElementData(EntityData.PlayerVipLevel, "TOP DONATOR");
                        break;
                    default:
                        player.SendTranslatedChatMessage("Ungültige Paket Nummer! ( 0 - 6 )");
                        break;
                }
            }
        }


        [Command("weather")]
        public void WeatherCommand(VnXPlayer player, int weather)
        {
            if (player.AdminRank >= Constants.AdminlvlModerator)
            {
                if (weather < 0 || weather > 14) return;

                //NAPI.World.SetWeather((Weather)weather);
                foreach (VnXPlayer players in _RootCore_.VenoX.GetAllPlayers().ToList())
                {
                    players.SetWeather((WeatherType)weather);
                }
                RageApi.SendTranslatedChatMessageToAll(Constants.RgbaAdminClantag + player.CharacterUsername + " hat das Wetter zu " + weather + " gewechselt!");
                Sync.WeatherCurrent = weather;
                Sync.WeatherCounter = 0;
            }
        }


        [Command("unban")]
        public static async void UnbanPlayerByName(VnXPlayer player, string targetName)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    foreach (BanModel accClass in PlayerBans.ToList())
                    {
                        if (accClass.Name.ToLower() == targetName.ToLower())
                        {
                            foreach (VnXPlayer players in _RootCore_.VenoX.GetAllPlayers().ToList())
                            {
                                string translatedText = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)players.Language, "wurde entbannt.");
                                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + accClass.Name + " " + translatedText);
                                Database.RemoveOldBan(accClass.Uid);
                                Logfile.WriteLogs("admin", player.CharacterUsername + " unbanned " + accClass.Name + "!");
                                PlayerBans.Remove(accClass);
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }


        [Command("vehicle")]
        public static void VehicleCommand(VnXPlayer player, int vehicleid, string action)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    VehicleModel vehicle = Vehicles.GetVehicleById(vehicleid);
                    switch (action)
                    {
                        case "despawn":
                            vehicle.Dimension = Constants.VehicleOfflineDim;
                            player.SendTranslatedChatMessage("Erfolgreich despawned!");
                            break;
                        case "test":
                        {
                            VehicleModel veh = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.T20, player.Position, player.Rotation);
                            veh.ManualEngineControl = false;
                            veh.Faction = player.Reallife.Faction;
                            veh.Dimension = player.Dimension;
                            player.WarpIntoVehicle(veh, -1);
                            veh.EngineOn = true;
                            break;
                        }
                        case "gethere":
                            vehicle.Position = player.Position;
                            player.SendTranslatedChatMessage("Fahrzeug Erfolgreich geholt!");
                            break;
                        case "goto":
                            player.SetPosition = vehicle.Position;
                            player.SendTranslatedChatMessage("Fahrzeug Erfolgreich hingegangen!");
                            break;
                    }
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Das Fahrzeug exestiert nicht!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("crespawnarea")]
        public static void DespawnAllIVehiclesInArea(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    foreach (VehicleModel vehicle in Enumerable.ToList<VehicleModel>(_Globals_.Initialize.ReallifeVehicles))
                    {
                        if (vehicle.Position.Distance(player.Position) < 20 && vehicle.Faction <= Constants.FactionNone)
                        {
                            vehicle.Dimension = Constants.VehicleOfflineDim;
                        }
                    }
                    SendAdminInformation(player.CharacterUsername + " hat alle Fahrzeuge in seiner Nähe despawned!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }



        [Command("resetaktion")]
        public static async void AdminResetAktion(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    Allround.DestroyTargetMarker();
                    Allround.ActionCooldownDateTime = DateTime.Now;
                    Allround.ActionRunning = false;
                    foreach (VnXPlayer otherPlayers in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ReallifePlayers))
                    {
                        string translatedText = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)otherPlayers.Language, "hat den Aktions-Timer zurückgesetzt!");
                        otherPlayers.SendChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "[Reallife] : " + player.CharacterUsername + " " + translatedText);
                    }
                }
                else  _Globals_.Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Error, "Du bist nicht Befugt!");
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }


        [Command("createhouse")]
        public static async void CreateNewHausmarker(VnXPlayer player, string name, int preis, int interior)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                HouseModel house = House.GetClosestHouse(player);

                string houseLabel = string.Empty;
                house = new HouseModel();
                house.Ipl = Constants.HouseIplList[interior].Ipl;
                house.Name = name;
                house.Position = player.Position;
                house.Dimension = player.Dimension;
                house.Price = preis;
                house.Owner = string.Empty;
                house.Status = Constants.HouseStateBuyable;
                house.Tenants = 2;
                house.Rental = 0;
                house.Locked = true;
                // Add a new house
                house.Id = Database.AddHouse(house);
                RageApi.CreateTextLabel(await House.GetHouseLabelText(house), house.Position, 35.0f, 0.75f, 4, new[] { 255, 255, 255, 255 }, player.Dimension);
                House.HouseList.Add(house);

                SendAdminInformation(player.CharacterUsername + " hat einen Hausmarker erstellt! " + RageApi.GetHexColorcode(0, 200, 255) + " [" + RageApi.GetHexColorcode(255, 255, 255) + +house.Id + RageApi.GetHexColorcode(0, 200, 255) + " ]" + "[" + RageApi.GetHexColorcode(255, 255, 255) + +preis + RageApi.GetHexColorcode(0, 200, 255) + "  $]" + "[" + RageApi.GetHexColorcode(255, 255, 255) + +interior + RageApi.GetHexColorcode(0, 200, 255) + " ]");
                Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "] hat einen Hausmarker erstellt! [ID : " + house.Id + "]" + "[ PREIS : " + preis + " $]" + "[INTERIOR : " + interior + "]");

            }
            else
            {
                player.SendTranslatedChatMessage(Constants.RgbaError + "Du bist nicht Befugt!");
            }
        }

        [Command("removehouse")]
        public void DeleteHausmarker(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                HouseModel house = House.GetClosestHouse(player);
                //house.houseLabel.Remove();
                Database.DeleteHouse(house.Id);
                House.HouseList.Remove(house);
                SendAdminInformation(player.CharacterUsername + " hat einen Hausmarker gelöscht! " + RageApi.GetHexColorcode(0, 200, 255) + " [" + RageApi.GetHexColorcode(255, 255, 255) + +house.Id + "]");
                Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "] hat einen Hausmarker Gelöscht! ID : " + house.Id);
            }
            else
            {
                player.SendTranslatedChatMessage(Constants.RgbaError + "Du bist nicht Befugt!");
            }
        }


        [Command("makeleader")]
        public static void MakeLeader_AdminFunc(VnXPlayer player, string targetName, int faction)
        {
            try
            {
                if (player.AdminRank < Constants.AdminlvlAdministrator) return;
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                if (faction is < 0 or > 13)
                {
                    _Globals_.Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Error, "Fraktions ID nur zwischen 0-13 möglich!");
                    return;
                }

                
                Task.Run(async() =>
                {
                    string[] completedString = new[]
                    {
                        player.CharacterUsername,
                        "has made",
                        target.CharacterUsername,
                        "the leader of the faction ID " + faction + "."
                    };
                    
                    /* Custom Notification */
                    foreach (VnXPlayer admin in _RootCore_.VenoX.GetAllPlayers().ToList().Where(admin => admin.AdminRank >= Constants.AdminlvlTsupporter))
                    {
                        string translatedString = completedString[0];
                        translatedString += await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) admin.Language, completedString[1]);
                        translatedString += completedString[2];
                        translatedString += await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) admin.Language, completedString[3]);
                        admin.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 0, 0) + translatedString);
                    }
                    Logfile.WriteLogs("admin", completedString[0] + completedString[1] + completedString[2] + completedString[3]);

                });

                string factionTargetMsg = RageApi.GetHexColorcode(0, 200, 255);
                factionTargetMsg += faction switch
                {
                    0 => "You've just been made a civilian.",
                    1 => "You have just been appointed Chief of Police! For more information, open the help menu!",
                    2 => "You are now the Don of the La Cosa Nostra from Venox City - For more information, open the help menu!",
                    3 => "You are now the leader of the Yakuza of Venox City - For more information, open the help menu!",
                    4 => "[LOCKED ] For more information, open the help menu!",
                    5 => "You are now the editor-in-chief of Venox City News - For more information, open the help menu!",
                    6 => "You are now the director of the Federal Investigation Bureau - For more information, open the help menu!",
                    7 => "You are now the boss of the Venox City Narcos - For more information, open the help menu!",
                    8 => "You are now the Commander of the Venox U.S. Army - For more information, open the help menu!",
                    9 => "You are now the president of SAMCRO Redwoods Originals - For more information, open the help menu!",
                    10 => "You are now the leader of Venox Medic's - For more information, open the help menu!",
                    11 => "You are now the leader of the Venox City Mechanics - For more information, open the help menu!",
                    12 => "You are now the banger of the Venox City Ballas - For more information open the help menu!",
                    13 => "You are now the leader of Venox City Grove Street - For more information, open the help menu!",
                    // ReSharper disable once UnreachableSwitchArmDueToIntegerAnalysis - Rider Bug.
                    _ => "ERROR"
                };

                target.SendTranslatedChatMessage(factionTargetMsg);
                target.Reallife.Faction = faction;
                target.Reallife.FactionRank = 5;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("setrank")]
        public void SetUserRank(VnXPlayer player, string targetName, int rank)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (target.Reallife.Faction == Constants.FactionNone)
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Der Spieler " + target.CharacterUsername + " ist in keiner Fraktion!");
                }
                if (rank > 5 || rank < 0)
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Fraktions Rang nur zwischen 0-5 möglich!");
                }
                else
                {
                    target.Reallife.FactionRank = rank;
                    target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.CharacterUsername + " hat deinen Fraktion´s rang auf " + rank + " geändert!");
                    SendAdminNotification(player.CharacterUsername + " hat " + target.CharacterUsername + " Franktion´s Rang auf " + rank + " geändert!");
                    Logfile.WriteLogs("admin", player.CharacterUsername + " hat " + target.CharacterUsername + " Franktion´s Rang auf " + rank + " geändert!");
                }
            }
        }



        [Command("giveweapon", true)]
        public static void GiveAdminWeapons(VnXPlayer player, string weapon)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                switch (weapon)
                {
                    case "mp5":
                        player.Inventory.GiveItem(Constants.ItemHashMp5, ItemType.Gun, 200, true);
                        break;
                    case "m4":
                        player.Inventory.GiveItem(Constants.ItemHashKarabiner, ItemType.Gun, 200, true);
                        break;
                }
                Logfile.WriteLogs("admin", player.CharacterUsername + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
                SendAdminNotification(player.CharacterUsername + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
            }
        }

        [Command("changepw")]
        public static void ChangeUserPasswort(VnXPlayer player, string name, string passwort)
        {
            if (player.AdminRank < Constants.AdminlvlAdministrator) return;
            bool exestiert = Database.FindCharacterByName(name);
            if (exestiert)
            {
                string salt = Program.GetRandomSalt();
                string byCryptedPasswordWoltlab = BCrypt.Net.BCrypt.HashPassword(BCrypt.Net.BCrypt.HashPassword(passwort, salt), salt);
                string byCryptedPassword = BCrypt.Net.BCrypt.HashPassword(passwort);
                if (Login.ChangeAccountPw(name, byCryptedPassword))
                {
                    Database.ChangeUserPasswort(name, byCryptedPassword);
                    Program.ChangeUserPasswort(name, byCryptedPasswordWoltlab);
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Passwort von " + name + " geändert.");
                }
            }
            else _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Es wurde kein Spieler mit dem Namen " + name + " gefunden!");
        }



        [Command("gotogw")]
        public static void Teleport2Tk(VnXPlayer player, string name)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                foreach (GangwarArea area in _Gamemodes_.Reallife.gangwar.Allround.GangwarManager.GangwarAreas)
                {
                    if (area.Name == name)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 1000);
                        player.SendChatMessage("[GW] Teleported to '" + area.Name + "'.");
                        player.SetPosition = area.Tk;
                        player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                    }
                }

            }
        }

        [Command("stopgw")]
        public static void StopGangwar(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                _Gamemodes_.Reallife.gangwar.Allround.GangwarManager.StopCurrentGangwar();
                RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + "Der laufende Gangwar wurde gestoppt!");
            }
        }

        [Command("getgw")]
        public static void GetInfo(VnXPlayer player, string name)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                GangwarArea area = _Gamemodes_.Reallife.gangwar.Allround.GangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.Inform(player);
                }
            }
        }

        [Command("setgwowner")]
        public static void SetGangwarOwner(VnXPlayer player, string name, int factionId)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                GangwarArea area = _Gamemodes_.Reallife.gangwar.Allround.GangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.SetOwner(factionId);
                }
            }
        }


        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        [Command("vnxgetelementdata")]
        public static void GetElementDataAdmin(VnXPlayer player, string targetName, string element)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlStellvp)
            {
                player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + target.VnxGetElementData<object>(element));
                player.SendTranslatedChatMessage(target.CharacterUsername);
            }
        }

        [Command("vnxvehgetelementdata")]
        public static void GetElementDataAdmin(VnXPlayer player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlStellvp)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        // player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("vnxvehgetshareddata")]
        public static void GetSharedElementDataAdmin(VnXPlayer player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlStellvp)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        // player.SendTranslatedChatMessage("[VnXGetSharedData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }



        [Command("hauschange")]
        public void ChangeHausData(VnXPlayer player, string element, int value)
        {
            string e = element.ToLower();
            if (player.Reallife.Faction > Constants.AdminlvlStellvp)
            {
                HouseModel house = House.GetClosestHouse(player);
                if (house == null)
                {
                    player.SendTranslatedChatMessage(Constants.RgbaError + "Du bist an keinem Haus!");
                    return;
                }

                switch (e)
                {
                    case "interior":
                    {
                        if (value >= 0 && value < Constants.HouseIplList.Count)
                        {
                            house.Ipl = Constants.HouseIplList[value].Ipl;

                            Database.UpdateHouse(house);
                            SendAdminInformation(player.CharacterUsername + " hat den Hausmarker " + RageApi.GetHexColorcode(0, 200, 255) + " [ID : " + house.Id + "] " + RageApi.GetHexColorcode(255, 255, 255) + "Interior zu " + value + " geändert! ");
                            Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "]" + " hat den Hausmarker [ID: " + house.Id + "] Interior zu " + value + " geändert! ");
                        }

                        break;
                    }
                    case "preis":
                        house.Price = value;
                        house.Status = Constants.HouseStateBuyable;
                        //house.houseLabel.Text = House.GetHouseLabelText(house);

                        Database.UpdateHouse(house);
                        SendAdminInformation(player.CharacterUsername + " hat den Hausmarker " + RageApi.GetHexColorcode(0, 200, 255) + " [ID : " + house.Id + "] " + RageApi.GetHexColorcode(255, 255, 255) + "Preis zu " + value + " geändert! ");
                        Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "]" + " hat den Hausmarker [ID: " + house.Id + "] Preis zu " + value + " geändert! ");
                        break;
                }
            }
        }


        [Command("sethunger")]
        public static void SetPlayerAdminHunger(VnXPlayer player, string targetName, int value)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlStellvp)
            {
                target.VnxSetStreamSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerHunger, value);
                player.SendTranslatedChatMessage("Du hast" + target.CharacterUsername + " Hunger Level auf : " + value + " gesetzt!");
            }
        }

        [Command("createforumuser")]
        public static void CreateForumUser_Admin_CMD(VnXPlayer player, string name, string email, string passwort)
        {
            if (player.AdminRank >= Constants.AdminlvlStellvp)
            {
                //Program.CreateForumUser(null, Name, email, passwort);
                player.SendTranslatedChatMessage("Du hast einen Forum account namens : " + name + " erstellt!");
            }
        }

        /*[Command("healp")]
        public static void HealPlayerForSomeReason(PlayerModel player, string target_name, string value, int valuea)
        {
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                if (value == "armor")
                {
                    target.SetArmor =  valuea;
                }
                else if (value == "health")
                {
                    //AntiCheat_Allround.SetTimeOutHealth(target, 1000);
                    target.SetHealth =  valuea;
                }
                Core.VnX.UpdateHUDArmorHealth(target);
            }
        }*/


        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////
        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////
        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////
        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////
        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////
        /////////////////////////////////////////////////USELESS OTHER STUFF/////////////////////////////////////////////////





        [Command("askin")]
        public static void ChangeSkin(VnXPlayer player, int slot, int drawable, int texture)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                player.SetClothes(slot, drawable, texture);
            }
        }

        [Command("aprop")]
        public static void ChangeProp(VnXPlayer player, int slot, int drawable, int texture)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                //ToDo Sie Clientseitig Laden! :NAPI.Player.SetPlayerAccessory(player, slot, drawable, texture);
            }
        }

        [Command("changecar")]
        public static void ChangeCarModel(VnXPlayer player, string modelName)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                // Obtain occupied IVehicle
                VehicleModel veh = (VehicleModel)player.Vehicle;
                if (veh != null)
                {
                    // Update the IVehicle's position into the database
                    Database.UpdateIVehicleSingleString("model", modelName, veh.DatabaseId);
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du hast das Fahrzeug geändert zu : " + modelName);
                }
            }
        }

        [Command("vehupdate")]
        public static void ChangeCarPosition(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.AdminlvlTsupporter)
            {
                if (!player.IsInVehicle) { player.SendTranslatedChatMessage("Du bist in keinem Fahrzeug!"); return; }
                VehicleModel veh = (VehicleModel)player.Vehicle;
                veh.SpawnCoord = veh.Position;
                veh.SpawnRot = veh.Rotation;
                Database.SaveIVehicle(veh);
                player.SendChatMessage("Vehicle Saved!");
            }
        }

        [Command("createobj")]
        public static void CreateObj(VnXPlayer player, string objName)
        {
            if (player.AdminRank >= Constants.AdminlvlProjektleiter)
            {
                _RootCore_.VenoX.TriggerEventForAll("Sync:LoadMap", "Custom", objName, new Vector3(player.Position.X, player.Position.Y, player.Position.Y - 0.3f), 0, 0, 0, 0, 2, player.Rotation, true, true);
                ConsoleHandling.OutputDebugString("CMD-Executed!");
            }
        }

        public static Vector3 BulletPos1 = new Vector3(0, 0, 0);
        public static Vector3 BulletPos2 = new Vector3(0, 0, 0);
        [Command("bulletpos")]
        public static void CreateBulletPos(VnXPlayer player)
        {
            if (BulletPos1 == new Vector3(0, 0, 0))
            {
                BulletPos1 = player.Position;
                player.SendChatMessage("DEBUG : Setted Bullet Pos1!");
            }
            else if (BulletPos2 == new Vector3(0, 0, 0))
            {
                BulletPos2 = player.Position;
                player.SendChatMessage("DEBUG : Setted Bullet Pos2!");
            }
        }
        [Command("resetbulletpos")]
        public static void ResetBulletCoords(VnXPlayer player)
        {
            BulletPos1 = new Vector3(0, 0, 0);
            BulletPos2 = new Vector3(0, 0, 0);
        }

        [Command("createbullet")]
        public static void Createbullet(VnXPlayer player, string targetName, int damage, string weaponHash, bool audible, bool invisible, int speed)
        {
            if (player.AdminRank >= Constants.AdminlvlProjektleiter)
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                player.GivePlayerWeapon(WeaponModel.RPG, 20);
                _RootCore_.VenoX.TriggerEventForAll("Admin:ShootTest", BulletPos1, BulletPos2, damage, weaponHash, player, audible, invisible, speed);
                ConsoleHandling.OutputDebugString("CMD-Executed!");
            }
        }


        [Command("createvehicle")]
        public static void CreateAdminVehicle(VnXPlayer player, string model, int faction, bool save, int r = 255, int g = 255, int b = 255, int r2 = 255, int g2 = 255, int b2 = 255)
        {
            if (player.AdminRank >= Constants.AdminlvlAdministrator)
            {
                VehicleModel vehClass = (VehicleModel)Alt.CreateVehicle(Alt.Hash(model), player.Position, player.Rotation);
                vehClass.Name = model;
                vehClass.FirstColor = r + "," + g + "," + b;
                vehClass.SecondColor = r2 + "," + g2 + "," + b2;
                vehClass.Owner = Faction.GetFactionNameById(faction);
                vehClass.Plate = Faction.GetFactionNameById(faction);
                vehClass.Gas = 100;
                vehClass.Kms = 0;
                vehClass.Faction = faction;
                vehClass.Frozen = false;
                vehClass.Dimension = player.Dimension;
                vehClass.EngineOn = true;
                if (save) { Database.AddNewIVehicle(vehClass); }
            }
        }


        /* [Command("createtestcar")]
         public static void CreateCar(PlayerModel player, string VehicleModel)
         {
             try
             {
                 if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                 {
                     anzeigen.Usefull.VnX.CreateRandomIVehicle(player, NAPI.Util.IVehicleNameToModel(VehicleModel), new Position(player.position.X + 2, player.position.Y, player.position.Z), 0, new Rgba(255, 255, 255), new Rgba(255, 255, 255), true, false, Constants.JOB_NONE, "TESTCAR");
                 }
             }
             catch(Exception ex){Core.ExceptionHandling.CatchExceptions(ex);}
         }*/

        // DrugsMichaelAliensFightIn == Sollten wir verwenden für drogen system ^^
    }
}
