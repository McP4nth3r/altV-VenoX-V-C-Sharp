using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Admin_
{
    public class Admin : IScript
    {

        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands

        public static async void sendAdminNotification(string text)
        {
            foreach (VnXPlayer admin in VenoX.GetAllPlayers().ToList())
            {
                if (admin.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                {
                    string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)admin.Language, text);
                    admin.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + Translatedtext);
                }
            }
        }

        public static async void sendAdminInformation(string text)
        {
            try
            {
                foreach (VnXPlayer admin in VenoX.GetAllPlayers().ToList())
                {
                    if (admin.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)admin.Language, text);
                        admin.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[Info] : " + RageAPI.GetHexColorcode(255, 255, 255) + Translatedtext);
                    }
                }
            }
            catch { }
        }

        public static bool HaveAdminRights(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                return true;
            }
            return false;
        }


        [Command("evalc")]
        public static void HideHUDForPlayer(VnXPlayer player, string st)
        {
            VenoX.TriggerClientEvent(player, "eval", st);
        }

        [Command("admins")]
        public async void AdminsIngameCommand(VnXPlayer player)
        {
            try
            {
                //foreach (string target_namesingame in VenoX.GetAllPlayers().ToList())
                player.SendChatMessage("---------------------------------------------------------");
                player.SendTranslatedChatMessage("Folgende Admins sind grade Online : ");
                foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers().ToList().OrderBy(p => p.AdminRank).Reverse())
                {
                    if (targetsingame.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (targetsingame.AdminRank == 7)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Projektleitung");
                            player.SendChatMessage("{B40000}[VnX]" + targetsingame.Username + ", " + Translatedtext);
                        }
                        else if (targetsingame.AdminRank == 6)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Stellv.Projektleitung");
                            player.SendChatMessage("{EC0000}[VnX]" + targetsingame.Username + ", " + Translatedtext);
                        }
                        else if (targetsingame.AdminRank == 5)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Administrator");
                            player.SendChatMessage("{E8AE00}[VnX]" + targetsingame.Username + ", " + Translatedtext);
                        }
                        else if (targetsingame.AdminRank == 4)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Moderator");
                            player.SendChatMessage("{002DE0}[VnX]" + targetsingame.Username + ", " + Translatedtext);
                        }
                        else if (targetsingame.AdminRank == 3)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Supporter");
                            player.SendChatMessage("{006600}[VnX]" + targetsingame.Username + ", " + Translatedtext);
                        }
                        else if (targetsingame.AdminRank == 2)
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)targetsingame.Language, "Ticket - Supporter");
                            player.SendChatMessage("{C800C8}" + $"{targetsingame.Username}, " + Translatedtext);
                        }
                    }
                }
                player.SendChatMessage("---------------------------------------------------------");
            }
            catch { }
        }


        public static string GetRgbaedClantag(int adminlvl)
        {
            try
            {
                return adminlvl switch
                {
                    2 => "{C800C8}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    3 => "{006600}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    4 => "{002DE0}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    5 => "{E8AE00}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    6 => "{EC0000}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    7 => "{B40000}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255),
                    _ => "",
                };
            }
            catch { return ""; }

        }











        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////

        [Command("clearchat")]
        public static void ClearChatForEveryone(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                for (int i = 0; i < 50; ++i)
                {
                    RageAPI.SendTranslatedChatMessageToAll(" ");
                }
                logfile.WriteLogs("admin", player.Username + " hat den Chat gecleared!");
            }
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
                RageAPI.SendTranslatedChatMessageToAll(" ");
            }
            logfile.WriteLogs("admin", player.Username + " hat den Chat gecleared!");
        }


        [Command("adstate")]
        public static void SetAdState(VnXPlayer player, int Werbung)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                string state = RageAPI.GetHexColorcode(0, 175, 0) + "angeschaltet!";
                if (Werbung == 0)
                {
                    state = RageAPI.GetHexColorcode(175, 0, 0) + "ausgeschaltet!";
                }
                else if (Werbung == 1)
                {
                    RageAPI.SendTranslatedChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat das AD-System " + state);
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Status muss 1 oder 0 sein!");
                }
            }
        }

        [Command("ochat", true)]
        public void OchatCommand(VnXPlayer player, string message)
        {
            try
            {
                if (player.AdminRank > Constants.ADMINLVL_NONE)
                {
                    if (player.AdminRank == 7)
                    {
                        RageAPI.SendTranslatedChatMessageToAll("(( {B40000}Projektleitung " + player.Username + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Projektleitung " + player.Username + ": " + message + " }} ");
                    }
                    else if (player.AdminRank == 6)
                    {
                        RageAPI.SendTranslatedChatMessageToAll("(( {EC0000}Stellv.Projektleitung " + player.Username + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Stellv.Projektleitung " + player.Username + ": " + message + " }} ");
                    }
                    else if (player.AdminRank == 5)
                    {
                        RageAPI.SendTranslatedChatMessageToAll("(( {E8AE00}Administrator " + player.Username + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Administrator " + player.Username + ": " + message + " }} ");
                    }
                    else if (player.AdminRank == 4)
                    {
                        RageAPI.SendTranslatedChatMessageToAll("(( {002DE0}Moderator " + player.Username + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Moderator " + player.Username + ": " + message + " }} ");
                    }
                    else if (player.AdminRank == 3)
                    {
                        player.SendTranslatedChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.Username + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.Username + " versuchte Nachricht : " + message + " }}");
                    }
                    else if (player.AdminRank == 2)
                    {
                        player.SendTranslatedChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.Username + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.Username + " versuchte Nachricht : " + message + " }}");
                    }
                }
            }
            catch { }
        }

        [Command("unprison")]
        public static void UnPrisonPlayer(VnXPlayer player, string target)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                bool Found = Database.FindCharacterByName(target);
                if (Found)
                {
                    string SocialClubId = Database.GetCharakterSocialName(target);
                    string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                    VnXPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                    int UID = Database.GetCharakterUID(SpielerName);
                    if (Database.FindCharakterPrison(SpielerName))
                    {
                        Database.RemoveOldPrison(SpielerName);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist nicht im Prison!");
                    }
                    if (targetplayer != null)
                    {
                        //AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                        targetplayer.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
                        _Gamemodes_.Reallife.anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                        targetplayer.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME, 0);
                        targetplayer.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.SpawnPlayerOnSpawnpoint(targetplayer);
                    }
                }
            }

        }
        public static List<BanModel> PlayerBans = new List<BanModel>();
        public static bool IsClientBanned(VnXPlayer target)
        {
            try
            {
                foreach (BanModel BanClass in PlayerBans.ToList())
                {
                    if (BanClass.BannedTill < DateTime.Now && BanClass.BanType == "Timeban")
                    {
                        Database.RemoveOldBan(BanClass.UID);
                        PlayerBans.Remove(BanClass);
                        continue;
                    }
                    if (BanClass.Name == target.Username) return true;
                    if (BanClass.HardwareId == target.HardwareIdHash.ToString() && BanClass.HardwareId.Length > 1) return true;
                    if (BanClass.HardwareIdExHash == target.HardwareIdExHash.ToString() && BanClass.HardwareIdExHash.Length > 1) return true;
                    if (BanClass.DiscordID == target.Discord.ID && BanClass.DiscordID.Length > 1) return true;
                    if (BanClass.IP == target.Ip && BanClass.IP.Length > 1) return true;
                    if (BanClass.SocialClubId == target.SocialClubId.ToString() && BanClass.SocialClubId.Length > 1) return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }
        public static BanModel GetClientBanModel(VnXPlayer player)
        {
            try
            {
                foreach (BanModel BanClass in PlayerBans)
                {
                    if (BanClass.Name == player.Username) return BanClass;
                    if (BanClass.HardwareId == player.HardwareIdHash.ToString() && BanClass.HardwareId.Length > 1) return BanClass;
                    if (BanClass.HardwareIdExHash == player.HardwareIdExHash.ToString() && BanClass.HardwareIdExHash.Length > 1) return BanClass;
                    if (BanClass.DiscordID == player.Discord.ID && BanClass.DiscordID.Length > 1) return BanClass;
                    if (BanClass.IP == player.Ip && BanClass.IP.Length > 1) return BanClass;
                    if (BanClass.SocialClubId == player.SocialClubId.ToString() && BanClass.SocialClubId.Length > 1) return BanClass;
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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
        [Command("permaban")]
        public static void permaban_player(VnXPlayer player, string target_name, params string[] grundArray)
        {
            try
            {
                string grund = string.Join(" ", grundArray);
                if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target is null)
                    {
                        foreach (AccountModel accClass in Register.AccountList)
                        {
                            if (accClass.Name.ToLower() == target_name.ToLower())
                            {
                                BanModel banClass = new BanModel
                                {
                                    UID = accClass.UID,
                                    Name = accClass.Name,
                                    HardwareId = accClass.HardwareId,
                                    HardwareIdExHash = accClass.HardwareIdExhash,
                                    DiscordID = "",
                                    IP = "",
                                    SocialClubId = accClass.SocialID,
                                    BanCreated = DateTime.Now,
                                    BannedTill = DateTime.Now,
                                    BanType = "Permaban"
                                };
                                PlayerBans.Add(banClass);
                                Database.AddPlayerPermaBan(accClass.UID, accClass.Name, accClass.HardwareId, accClass.HardwareIdExhash, accClass.SocialID, "", "", grund, player.Username);
                                logfile.WriteLogs("admin", player.Username + " banned " + accClass.Name + " permanently! Reason : " + grund);
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " banned " + accClass.Name + " permanently! Reason : " + grund);
                                return;
                            }
                        }
                    }
                    else
                    {
                        BanModel banClass = new BanModel
                        {
                            UID = target.UID,
                            Name = target.Name,
                            HardwareId = target.HardwareIdHash.ToString(),
                            HardwareIdExHash = target.HardwareIdExHash.ToString(),
                            DiscordID = target.Discord.ID,
                            IP = target.Ip,
                            SocialClubId = target.SocialClubId.ToString(),
                            BanCreated = DateTime.Now,
                            BannedTill = DateTime.Now,
                            BanType = "Permaban"
                        };
                        PlayerBans.Add(banClass);
                        Database.AddPlayerPermaBan(target.UID, target.Username, target.HardwareIdHash.ToString(), target.HardwareIdExHash.ToString(), target.SocialClubId.ToString(), target.Ip, target.Discord.ID, grund, player.Username);
                        logfile.WriteLogs("admin", player.Username + " banned " + target.Username + " permanently! Reason : " + grund);
                        RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " banned " + target.Username + " permanently! Reason : " + grund);
                        target.Kick(grund);
                        //RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }



        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////



        [Command("updateinventar")]
        public static void UpdateTargetInventar(VnXPlayer player, string target_name)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) return;
            List<ItemModel> inventory = _Gamemodes_.Reallife.anzeigen.Inventar.Main.GetPlayerInventory(target);
            VenoX.TriggerClientEvent(target, "Inventory:Update", JsonConvert.SerializeObject(inventory));
        }

        [Command("clearinventar")]
        public static void ClearTargetPlayerInventar(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) return;
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    int targetId = target.UID;
                    if (targetId > 0)
                    {
                        foreach (ItemModel item in _Gamemodes_.Reallife.anzeigen.Inventar.Main.CurrentOfflineItemList.ToList())
                        {
                            if (item.UID == targetId)
                            {
                                _Gamemodes_.Reallife.anzeigen.Inventar.Main.CurrentOfflineItemList.Remove(item);
                            }
                        }
                        player.Items.Clear();
                        Database.RemoveAllItems(targetId);
                    }
                    player.SendChatMessage("Du hast das Inventar von " + target.Username + " geleert!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.Message);
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.StackTrace);
            }
        }

        public const string ITEM_ART_WAFFE = "Waffe";
        public const string ITEM_ART_DROGEN = "Drogen";
        public const string ITEM_ART_NUTZ_ITEM = "NUTZ_ITEM";
        public const string ITEM_ART_MAGAZIN = "Magazin";
        public const string ITEM_ART_FALLSCHIRM = "Fallschirm";
        public const string ITEM_ART_BUSINESS = "Business";
        [Command("giveitem")]
        public static void GiveAdminWeapons(VnXPlayer player, string Hash, int ItemArt, int ItemAmount, string weightstring)
        {
            float weight = float.Parse(weightstring);
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                Main.GivePlayerItem(player, Hash, (ItemType)ItemArt, ItemAmount, true, Weight: weight);
            }
        }

        [Command("coord")]
        public void CoordCommand(VnXPlayer player, float posX, float posY, float posZ)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                player.SetPosition = new Position(posX, posY, posZ);
                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.vnxSetElementData(EntityData.PLAYER_BUSINESS_ENTERED, 0);
            }
        }

        [Command("sstate")]
        public static void SetSocialStatePlayer(VnXPlayer player, string target_name, string value)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) return;
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Reallife.SocialState = value;
                sendAdminNotification(player.Username + " hat " + target.Username + " Sozialen Status geändert zu " + value + ".");
                logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " sozialen status auf " + value + " geändert!");
            }
        }


        [Command("triggersound")]
        public static void TriggerSoundEffect(VnXPlayer player, string target_name, string SoundName, string SoundSetName)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VenoX.TriggerClientEvent(target, "VnX_Play_Sound", SoundName, SoundSetName);
            }
        }

        [Command("triggermp3")]
        public static void Triggeraudio(VnXPlayer player, string target_name, string audioclass)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VenoX.TriggerClientEvent(target, "load_audio_table_vnx", audioclass);
            }
        }

        [Command("triggerfx")]
        public static void Triggerfx(VnXPlayer player, string target_name, string effect, int duration, bool loop)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VenoX.TriggerClientEvent(target, "start_screen_fx", effect, duration, loop);
            }
        }

        [Command("stopfx")]
        public static void StopfxAdmin(VnXPlayer player, string target_name, string effect)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VenoX.TriggerClientEvent(target, "stop_screen_fx", effect);
            }
        }

        [Command("setpremium")]
        public static void GivePremiumToPlayer(VnXPlayer player, string target_name, int PaketNr, int Tage)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (PaketNr == 0)
                {
                    Database.SetVIPStats((int)target.UID, "Abgelaufen", 0);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                }
                else if (PaketNr == 1)
                {
                    Database.SetVIPStats((int)target.UID, "Bronze", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (PaketNr == 2)
                {
                    Database.SetVIPStats((int)target.UID, "Silber", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Silber");
                }
                else if (PaketNr == 3)
                {
                    Database.SetVIPStats((int)target.UID, "Gold", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (PaketNr == 4)
                {
                    Database.SetVIPStats((int)target.UID, "UltimateRed", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "UltimateRed");
                }
                else if (PaketNr == 5)
                {
                    Database.SetVIPStats((int)target.UID, "Platin", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Platin");
                }
                else if (PaketNr == 6)
                {
                    Database.SetVIPStats((int)target.UID, "TOP DONATOR", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else
                {
                    player.SendTranslatedChatMessage("Ungültige Paket Nummer! ( 0 - 6 )");
                }
            }
        }


        [Command("weather")]
        public void WeatherCommand(VnXPlayer player, int weather)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                if (weather < 0 || weather > 14) return;

                //NAPI.World.SetWeather((Weather)weather);
                foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                {
                    players.SetWeather((AltV.Net.Enums.WeatherType)weather);
                }
                RageAPI.SendTranslatedChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat das Wetter zu " + weather + " gewechselt!");
                Main.WEATHER_CURRENT = weather;
                Main.WEATHER_COUNTER = 0;
            }
        }


        [Command("unban")]
        public static async void UnbanPlayerByName(VnXPlayer player, string target_name)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    foreach (BanModel accClass in PlayerBans.ToList())
                    {
                        if (accClass.Name.ToLower() == target_name.ToLower())
                        {
                            foreach (VnXPlayer players in VenoX.GetAllPlayers().ToList())
                            {
                                string TranslatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)players.Language, "wurde entbannt.");
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + accClass.Name + " " + TranslatedText);
                                Database.RemoveOldBan(accClass.UID);
                                logfile.WriteLogs("admin", player.Username + " unbanned " + accClass.Name + "!");
                                PlayerBans.Remove(accClass);
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [Command("vehicle")]
        public static void IVehicleCommand(VnXPlayer player, int IVehicleid, string action)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    VehicleModel vehicle = _Gamemodes_.Reallife.Vehicles.Vehicles.GetVehicleById(IVehicleid);
                    if (action == "despawn")
                    {
                        vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        player.SendTranslatedChatMessage("Erfolgreich despawned!");
                    }
                    else if (action == "test")
                    {
                        VehicleModel veh = (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.T20, player.Position, player.Rotation);
                        veh.ManualEngineControl = false;
                        veh.Faction = player.Reallife.Faction;
                        veh.Dimension = player.Dimension;
                        player.WarpIntoVehicle(veh, -1);
                        veh.EngineOn = true;
                    }
                    else if (action == "gethere")
                    {
                        vehicle.Position = player.Position;
                        player.SendTranslatedChatMessage("Fahrzeug Erfolgreich geholt!");
                    }
                    else if (action == "goto")
                    {
                        player.SetPosition = vehicle.Position;
                        player.SendTranslatedChatMessage("Fahrzeug Erfolgreich hingegangen!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Das Fahrzeug exestiert nicht!");
                }
            }
            catch { }
        }

        [Command("crespawnarea")]
        public static void DespawnAllIVehiclesInArea(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                    {
                        if (Vehicle.Position.Distance(player.Position) < 20 && Vehicle.Faction <= Constants.FACTION_NONE)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        }
                    }
                    sendAdminInformation(player.Username + " hat alle Fahrzeuge in seiner Nähe despawned!");
                }
            }
            catch { }
        }



        [Command("resetaktion")]
        public static async void AdminResetAktion(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    _Gamemodes_.Reallife.Fun.Allround.DestroyTargetMarker();
                    _Gamemodes_.Reallife.Fun.Allround.ActionCooldown = DateTime.Now;
                    _Gamemodes_.Reallife.Fun.Allround.ActionRunning = false;
                    foreach (VnXPlayer otherp in VenoXV.Globals.Main.ReallifePlayers.ToList())
                    {
                        string TranslatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)otherp.Language, "hat den Aktions-Timer zurückgesetzt!");
                        otherp.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "[Reallife] : " + player.Username + " " + TranslatedText);
                    }
                }
                else _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        [Command("createhouse")]
        public static async void CreateNewHausmarker(VnXPlayer player, string name, int preis, int interior)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                HouseModel house = House.GetClosestHouse(player);

                string houseLabel = string.Empty;
                house = new HouseModel();
                house.ipl = Constants.HOUSE_IPL_LIST[interior].ipl;
                house.name = name;
                house.position = player.Position;
                house.Dimension = player.Dimension;
                house.price = preis;
                house.owner = string.Empty;
                house.status = Constants.HOUSE_STATE_BUYABLE;
                house.tenants = 2;
                house.rental = 0;
                house.locked = true;
                // Add a new house
                house.id = Database.AddHouse(house);
                RageAPI.CreateTextLabel(await House.GetHouseLabelText(house), house.position, 35.0f, 0.75f, 4, new int[] { 255, 255, 255, 255 }, Globals.Main.REALLIFE_DIMENSION, null, true);
                House.houseList.Add(house);

                sendAdminInformation(player.Username + " hat einen Hausmarker erstellt! " + RageAPI.GetHexColorcode(0, 200, 255) + " [" + RageAPI.GetHexColorcode(255, 255, 255) + +house.id + RageAPI.GetHexColorcode(0, 200, 255) + " ]" + "[" + RageAPI.GetHexColorcode(255, 255, 255) + +preis + RageAPI.GetHexColorcode(0, 200, 255) + "  $]" + "[" + RageAPI.GetHexColorcode(255, 255, 255) + +interior + RageAPI.GetHexColorcode(0, 200, 255) + " ]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat einen Hausmarker erstellt! [ID : " + house.id + "]" + "[ PREIS : " + preis + " $]" + "[INTERIOR : " + interior + "]");

            }
            else
            {
                player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du bist nicht Befugt!");
            }
        }

        [Command("removehouse")]
        public void DeleteHausmarker(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                HouseModel house = House.GetClosestHouse(player);
                //house.houseLabel.Remove();
                Database.DeleteHouse(house.id);
                House.houseList.Remove(house);
                sendAdminInformation(player.Username + " hat einen Hausmarker gelöscht! " + RageAPI.GetHexColorcode(0, 200, 255) + " [" + RageAPI.GetHexColorcode(255, 255, 255) + +house.id + "]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat einen Hausmarker Gelöscht! ID : " + house.id);
            }
            else
            {
                player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du bist nicht Befugt!");
            }
        }


        [Command("makeleader")]
        public void MakeLeader_AdminFunc(VnXPlayer player, string target_name, int faction)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    switch (faction)
                    {
                        case 0:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Bürger gemacht.");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 1:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Chief of Police ernannt! Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 2:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Don der La Cosa Nostra von Venox City - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 3:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Yakuza von Venox City - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 4:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [GESPERRT ] Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 5:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Chefredakteur der Venox City News - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 6:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Direktor des Federal Investigation Bureau - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 7:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Boss der Venox City Vatos Locos - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 8:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Commander der Venox U.S Army - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 9:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der President der SAMCRO Redwoods Original´s - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 10:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader der Venox Medic's - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 11:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader von den Venox City Mechaniker - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 12:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Du bist nun der Banger der Venox City Ballas - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        case 13:
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Venox City Grove Street - Für mehr Infos öffne das Hilfemenue!");
                            sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                            break;
                        default:
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Fraktions ID nur zwischen 0-13 möglich!");
                            break;


                    }
                    target.Reallife.Faction = faction;
                    target.Reallife.FactionRank = 5;
                    logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                }
            }
            catch { }
        }

        [Command("setrank")]
        public void setUserRank(VnXPlayer player, string target_name, int rank)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (target.Reallife.Faction == Constants.FACTION_NONE)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler " + target.Username + " ist in keiner Fraktion!");
                }
                if (rank > 5 || rank < 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Fraktions Rang nur zwischen 0-5 möglich!");
                    return;
                }
                else
                {
                    target.Reallife.FactionRank = rank;
                    target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat deinen Fraktion´s rang auf " + rank + " geändert!");
                    sendAdminNotification(player.Username + " hat " + target.Username + " Franktion´s Rang auf " + rank + " geändert!");
                    logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " Franktion´s Rang auf " + rank + " geändert!");
                }
            }
        }



        [Command("giveweapon", true)]
        public static void GiveAdminWeapons(VnXPlayer player, string weapon)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (weapon == "mp5")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_MP5, ItemType.Gun, 200, true);
                }
                else if (weapon == "m4")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_KARABINER, ItemType.Gun, 200, true);

                }
                _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("admin", player.Username + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
                Admin.sendAdminNotification(player.Username + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
            }
        }

        [Command("changepw")]
        public static void ChangeUserPasswort(VnXPlayer player, string name, string passwort)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                bool exestiert = Database.FindCharacterByName(name);
                if (exestiert)
                {
                    _Preload_.Login.Login.ChangeAccountPW(name, passwort);
                    Database.ChangeUserPasswort(name, passwort);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Passwort von " + name + " geändert.");
                }
                else _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Es wurde kein Spieler mit dem Namen " + name + " gefunden!");
            }
        }



        [Command("gotogw")]
        public static void Teleport2TK(VnXPlayer player, string name)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                foreach (var area in _Gamemodes_.Reallife.gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.Name == name)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 1000);
                        player.SendChatMessage("[GW] Teleported to '" + area.Name + "'.");
                        player.SetPosition = area.TK;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                    }
                }

            }
        }

        [Command("stopgw")]
        public static void StopGangwar(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                _Gamemodes_.Reallife.gangwar.Allround._gangwarManager.StopCurrentGangwar();
                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Der laufende Gangwar wurde gestoppt!");
            }
        }

        [Command("getgw")]
        public static void GetInfo(VnXPlayer player, string name)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = _Gamemodes_.Reallife.gangwar.Allround._gangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.Inform(player);
                }
            }
        }

        [Command("setgwowner")]
        public static void SetGangwarOwner(VnXPlayer player, string name, int factionId)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = _Gamemodes_.Reallife.gangwar.Allround._gangwarManager.GetAreaByName(name);
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
        public static void GetElementDataAdmin(VnXPlayer player, string target_name, string element)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + target.vnxGetElementData<object>(element));
                player.SendTranslatedChatMessage(target.Username);
            }
        }

        [Command("vnxvehgetelementdata")]
        public static void GetElementDataAdmin(VnXPlayer player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        // player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }

        [Command("vnxvehgetshareddata")]
        public static void GetSharedElementDataAdmin(VnXPlayer player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        // player.SendTranslatedChatMessage("[VnXGetSharedData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }



        [Command("hauschange")]
        public void ChangeHausData(VnXPlayer player, string element, int value)
        {
            string e = element.ToLower();
            if (player.Reallife.Faction > Constants.ADMINLVL_STELLVP)
            {
                HouseModel house = House.GetClosestHouse(player);
                if (house == null)
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du bist an keinem Haus!");
                    return;
                }

                if (e == "interior")
                {
                    if (value >= 0 && value < Constants.HOUSE_IPL_LIST.Count)
                    {
                        house.ipl = Constants.HOUSE_IPL_LIST[value].ipl;

                        Database.UpdateHouse(house);
                        sendAdminInformation(player.Username + " hat den Hausmarker " + RageAPI.GetHexColorcode(0, 200, 255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255, 255, 255) + "Interior zu " + value + " geändert! ");
                        logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "]" + " hat den Hausmarker [ID: " + house.id + "] Interior zu " + value + " geändert! ");
                    }
                    else
                    {
                        //string message = string.Format(Messages.ERR_HOUSE_INTERIOR_MODIFY, Constants.HOUSE_IPL_LIST.Count - 1);
                        //player.SendTranslatedChatMessage(Constants.Rgba_ERROR + message);
                    }
                }
                else if (e == "preis")
                {
                    house.price = value;
                    house.status = Constants.HOUSE_STATE_BUYABLE;
                    //house.houseLabel.Text = House.GetHouseLabelText(house);

                    Database.UpdateHouse(house);
                    sendAdminInformation(player.Username + " hat den Hausmarker " + RageAPI.GetHexColorcode(0, 200, 255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255, 255, 255) + "Preis zu " + value + " geändert! ");
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "]" + " hat den Hausmarker [ID: " + house.id + "] Preis zu " + value + " geändert! ");
                }
            }
        }


        [Command("sethunger")]
        public static void SetPlayerAdminHunger(VnXPlayer player, string target_name, int value)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                target.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, value);
                player.SendTranslatedChatMessage("Du hast" + target.Username + " Hunger Level auf : " + value + " gesetzt!");
            }
        }

        [Command("createforumuser")]
        public static void CreateForumUser_Admin_CMD(VnXPlayer player, string Name, string email, string passwort)
        {
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                Program.CreateForumUser(null, Name, email, passwort);
                player.SendTranslatedChatMessage("Du hast einen Forum account namens : " + Name + " erstellt!");
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
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                player.SetClothes(slot, drawable, texture);
            }
        }

        [Command("aprop")]
        public static void ChangeProp(VnXPlayer player, int slot, int drawable, int texture)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //ToDo Sie Clientseitig Laden! :NAPI.Player.SetPlayerAccessory(player, slot, drawable, texture);
            }
        }

        [Command("changecar")]
        public static void ChangeCarModel(VnXPlayer player, string modelName)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                // Obtain occupied IVehicle
                VehicleModel veh = (VehicleModel)player.Vehicle;
                if (veh != null)
                {
                    // Update the IVehicle's position into the database
                    Database.UpdateIVehicleSingleString("model", modelName, veh.ID);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast das Fahrzeug geändert zu : " + modelName);
                }
            }
        }

        [Command("vehupdate")]
        public static void ChangeCarPosition(VnXPlayer player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
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
        public static void CreateObj(VnXPlayer player, string ObjName)
        {
            if (player.AdminRank >= Constants.ADMINLVL_PROJEKTLEITER)
            {
                VenoX.TriggerEventForAll("Sync:LoadMap", "Custom", ObjName, new Vector3(player.Position.X, player.Position.Y, player.Position.Y - 0.3f), 0, 0, 0, 0, 2, player.Rotation, true, true);
                Debug.OutputDebugString("CMD-Executed!");
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
        public static void createbullet(VnXPlayer player, string target_name, int damage, string WeaponHash, bool audible, bool invisible, int speed)
        {
            if (player.AdminRank >= Constants.ADMINLVL_PROJEKTLEITER)
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) return;
                player.GivePlayerWeapon(AltV.Net.Enums.WeaponModel.RPG, 20);
                VenoX.TriggerEventForAll("Admin:ShootTest", BulletPos1, BulletPos2, damage, WeaponHash, player, audible, invisible, speed);
                Debug.OutputDebugString("CMD-Executed!");
            }
        }


        [Command("createvehicle")]
        public static void CreateAdminVehicle(VnXPlayer player, string Model, int Faction, bool Save, int R = 255, int G = 255, int B = 255, int R2 = 255, int G2 = 255, int B2 = 255)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                VehicleModel vehClass = (VehicleModel)Alt.CreateVehicle(Alt.Hash(Model), player.Position, player.Rotation);
                vehClass.Name = Model;
                vehClass.FirstColor = R + "," + G + "," + B;
                vehClass.SecondColor = R2 + "," + G2 + "," + B2;
                vehClass.Owner = _Gamemodes_.Reallife.factions.Faction.GetFactionNameById(Faction);
                vehClass.Plate = _Gamemodes_.Reallife.factions.Faction.GetFactionNameById(Faction);
                vehClass.Gas = 100;
                vehClass.Kms = 0;
                vehClass.Faction = Faction;
                vehClass.Frozen = false;
                vehClass.Dimension = player.Dimension;
                vehClass.EngineOn = true;
                if (Save) { Database.AddNewIVehicle(vehClass); }
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
             catch { }
         }*/

        // DrugsMichaelAliensFightIn == Sollten wir verwenden für drogen system ^^
    }
}
