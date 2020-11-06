﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._Admin_;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Preload_;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.admin.Commands
{
    public class AdminLVL_3 : IScript
    {
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////


        [Command("goto", true)]
        public void TpCommand(VnXPlayer player, string target_name)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                // We get the player from the input string
                if (target != null)
                {
                    // Change player's position and dimension
                    //AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    player.SetPosition = target.Position;
                    player.Dimension = target.Dimension;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast dich zu " + RageAPI.GetHexColorcode(0, 200, 255) + target.Username + " " + RageAPI.GetHexColorcode(255, 255, 255) + "teleportiert!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VnX]" + player.Username + " " + RageAPI.GetHexColorcode(255, 255, 255) + "hat sich zu dir teleportiert!");
                    logfile.WriteLogs("admin", player.Username + " hat sich zu " + target.Username + " geportet!");
                }
                else
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255, 255, 255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("gethere", true)]
        public void BringCommand(VnXPlayer player, string target_name)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                if (target != null)
                {
                    // Change target's position and dimension
                    //AntiCheat_Allround.SetTimeOutTeleport(target, 2000);
                    target.SetPosition = player.Position;
                    target.Dimension = player.Dimension;
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + target.Username + " " + RageAPI.GetHexColorcode(255, 255, 255) + " zu dir teleportiert!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VnX]" + player.Username + " " + RageAPI.GetHexColorcode(255, 255, 255) + "hat dich zu ihm teleportiert!");
                    logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " zu sich geportet!");
                }
                else
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255, 255, 255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("charakter")]
        public void CharacterCommand(VnXPlayer player, string action, string target_name, string amount)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
                {
                    // We check whether the player is connected
                    if (target != null && target.Playing == true)
                    {
                        if (int.TryParse(amount, out int value) == true)
                        {
                            string message = string.Empty;
                            switch (action.ToLower())
                            {
                                case "bank":
                                    if (player.AdminRank > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.Reallife.Bank = value;
                                        player.SendTranslatedChatMessage("~g~Du hast das Bankgeld von " + target.Username + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat das Bankgeld von " + target.Username + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.AdminRank > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.Reallife.Money = value;
                                        player.SendTranslatedChatMessage("~g~Du hast das Bargeld von " + target.Username + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat dein Bargeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat das Bargeld von " + target.Username + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "dimension":
                                    if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
                                    {
                                        target.Dimension = value;
                                        player.SendTranslatedChatMessage("~g~Du hast " + target.Username + " Dimension auf " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat deine Dimension auf :  " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat " + target.Username + " in die Dimension " + value + " verschoben!");

                                    }
                                    break;

                                default:
                                    break;
                            }
                        }

                    }
                    else
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "SPIELER NICHT GEFUNDEN");
                    }

                }
            }
            catch { }
        }

        [Command("getdim")]
        public static void GetAdminDimension(VnXPlayer player, string target_name)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                player.SendTranslatedChatMessage(target.Username + " hat dimension : " + target.Dimension);
            }
        }

        [Command("lobbykick")]
        public static void KickTargetFromLobby(VnXPlayer player, string target_name)
        {
            VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) return;
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER) Preload.ShowGamemodeSelection(target);
        }

        [Command("revive")]
        public void ReviveCommand(VnXPlayer player, string target_name)
        {
            VnXPlayer Target = RageAPI.GetPlayerFromName(target_name);
            if (Target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                if (Target != null)
                {
                    if (Target.Dead == 1)
                    {
                        //AntiCheat_Allround.SetTimeOutHealth(Target, 1000);
                        Target.SpawnPlayer(Target.Position);
                        Target.vnxSetStreamSharedElementData(EntityData.PLAYER_KILLED, 0);
                        player.SendTranslatedChatMessage("~g~Du hast " + Target.Username + " wiederbelebt.");
                        Target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat dich wiederbelebt.");
                        logfile.WriteLogs("admin", player.Username + " hat " + Target.Username + " wiederbelebt!");
                        VenoX.TriggerClientEvent(Target, "destroyKrankenhausTimer");
                        VenoX.TriggerClientEvent(Target, "VnX_DestroyIPlayerSideTimer_KH");
                        foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
                        {
                            if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                                VenoX.TriggerClientEvent(medics, "Destroy_MedicBlips", Target.Username);
                        }
                    }
                }
            }
        }



        [Command("prison")]
        public void JailCommand(VnXPlayer player, string target, int zeit, string grund)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
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
                            int PrisonTime = Database.GetCharakterPrisonTime(SpielerName);
                            Database.UpdatePlayerPrisonTime(UID, PrisonTime + zeit, grund, player.Username, DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerToPrison(UID, SpielerName, zeit, grund, player.Username, DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            //AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                            targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
                            anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                            targetplayer.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME, zeit);
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
                }
            }
            catch { }
        }

        [Command("spec")]
        public void ReconCommand(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
                {
                    //anzeigen.Usefull.VnX.SpectatePlayer(player, target, 0);
                    Admin.sendAdminInformation(player.Username + " spectatet grade " + target.Username + "!");
                }
            }
            catch { }
        }

        [Command("specoff")]
        public void RecoffCommand(VnXPlayer player)
        {
            if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
            {
                //anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                Admin.sendAdminInformation(player.Username + " hat aufgehört " + player.Username + " zu spectaten!");
            }
        }

        [Command("timeban")]
        public void timeban_player(VnXPlayer player, string target_name, int zeit, params string[] grundArray)
        {
            try
            {
                string grund = string.Join(" ", grundArray);
                if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
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
                                    HardwareIdExHash =
                                    accClass.HardwareIdExhash,
                                    DiscordID = "",
                                    IP = "",
                                    SocialClubId = accClass.SocialID,
                                    BanCreated = DateTime.Now,
                                    BannedTill = DateTime.Now.AddHours(zeit),
                                    BanType = "Timeban"
                                };
                                Admin.PlayerBans.Add(banClass);
                                Database.AddPlayerTimeBan(accClass.UID, accClass.Name, accClass.HardwareId, accClass.HardwareIdExhash, accClass.SocialID, "", "", grund, player.Username, zeit);
                                logfile.WriteLogs("admin", player.Username + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
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
                            BannedTill = DateTime.Now.AddHours(zeit),
                            BanType = "Timeban"
                        };
                        Admin.PlayerBans.Add(banClass);
                        Database.AddPlayerTimeBan(target.UID, target.Username, target.HardwareIdHash.ToString(), target.HardwareIdExHash.ToString(), target.SocialClubId.ToString(), target.Ip, target.Discord.ID, grund, player.Username, zeit);
                        logfile.WriteLogs("admin", player.Username + " banned " + target.Username + " permanently! Reason : " + grund);
                        RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " banned " + target.Username + " for " + zeit + " Hours! Reason : " + grund);
                        target.Kick(grund);
                        //RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                    }
                }
            }
            catch { }
        }


    }
}
