using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
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
                                        target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_BANK, value);
                                        player.SendTranslatedChatMessage("~g~Du hast das Bankgeld von " + target.Username + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat das Bankgeld von " + target.Username + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.AdminRank > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, value);
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
                        Target.Emit("destroyKrankenhausTimer");
                        Target.Emit("VnX_DestroyIPlayerSideTimer_KH");
                        foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
                        {
                            if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                            {
                                medics.Emit("Destroy_MedicBlips", Target.Username);
                            }
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

        [Command("timeban")]
        public void timeban_player(VnXPlayer player, string target, int zeit, string grund)
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
                        string SpielerSerial = Database.GetAccountSpielerSerial(SocialClubId);
                        VnXPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId.ToString()))
                        {
                            Accountbans ban = Database.GetAccountbans(SocialClubId.ToString());
                            if (ban.banzeit > DateTime.Now)
                            {
                                Database.UpdatePlayerTimeBan(UID, grund, player.Username, ban.banzeit.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                            else
                            {
                                Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund, player.Username, DateTime.Now.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                        }
                        else
                        {
                            Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund, player.Username, DateTime.Now.AddHours(zeit), DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            targetplayer.Kick("~r~Grund : ~h~" + grund);
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

    }
}
