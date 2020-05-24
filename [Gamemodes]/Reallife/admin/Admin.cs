using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Gamemodes_.Reallife.Woltlab;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Anti_Cheat;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.admin
{
    public class Admin : IScript
    {

        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands
        // Basic Data & User Commands

        public static void sendAdminNotification(string text)
        {
            foreach (Client admin in Alt.GetAllPlayers())
            {
                if (admin.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                {
                    admin.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + text);
                }
            }
        }

        public static void sendAdminInformation(string text)
        {
            try
            {
                foreach (Client admin in Alt.GetAllPlayers())
                {
                    if (admin.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        admin.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[Info] : " + RageAPI.GetHexColorcode(255, 255, 255) + text);
                    }
                }
            }
            catch
            {
            }
        }

        public static bool HaveAdminRights(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                return true;
            }
            return false;
        }


        [Command("admins")]
        public void AdminsIngameCommand(Client player)
        {
            try
            {
                //foreach (string target_namesingame in Alt.GetAllPlayers())
                player.SendTranslatedChatMessage("---------------------------------------------------------");
                player.SendTranslatedChatMessage("Folgende Admins sind grade Online : ");
                foreach (Client targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK)))
                {
                    if (targetsingame.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (targetsingame.AdminRank == 7)
                        {
                            player.SendTranslatedChatMessage("{B40000}[VnX]" + targetsingame.Username + ", Projektleitung");
                        }
                        else if (targetsingame.AdminRank == 6)
                        {
                            player.SendTranslatedChatMessage("{EC0000}[VnX]" + targetsingame.Username + ", Stellv.Projektleitung");
                        }
                        else if (targetsingame.AdminRank == 5)
                        {
                            player.SendTranslatedChatMessage("{E8AE00}[VnX]" + targetsingame.Username + ", Administrator");
                        }
                        else if (targetsingame.AdminRank == 4)
                        {
                            player.SendTranslatedChatMessage("{002DE0}[VnX]" + targetsingame.Username + ", Moderator");
                        }
                        else if (targetsingame.AdminRank == 3)
                        {
                            player.SendTranslatedChatMessage("{006600}[VnX]" + targetsingame.Username + ", Supporter");
                        }
                        else if (targetsingame.AdminRank == 2)
                        {
                            player.SendTranslatedChatMessage("{C800C8}" + $"{targetsingame.Username}, Ticket - Supporter");
                        }
                    }
                }
                player.SendTranslatedChatMessage("---------------------------------------------------------");
            }
            catch { }
        }


        public static string GetRgbaedClantag(int adminlvl)
        {
            try
            {
                if (adminlvl == 2) { return "{C800C8}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else if (adminlvl == 3) { return "{006600}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else if (adminlvl == 4) { return "{002DE0}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else if (adminlvl == 5) { return "{E8AE00}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else if (adminlvl == 6) { return "{EC0000}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else if (adminlvl == 7) { return "{B40000}[VnX]" + RageAPI.GetHexColorcode(255, 255, 255); }
                else { return ""; }
            }
            catch { return ""; }

        }



        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////
        /////////////////////////////////////////////////T-Supporter/////////////////////////////////////////////////

        [Command("kick", true)]
        public static void KickPlayer(Client player, string target_name, string reason)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                {
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + target.Username + " wurde von " + player.Username + " gekickt! Grund : " + reason);
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + target.SocialClubId + "][" + target.Username + "] gekickt! Grund : " + reason);
                    target.Kick("~r~Grund : ~h~" + reason);
                }
            }
            catch { }
        }

        [Command("achat", true)]
        public void ACommand(Client player, string message)
        {
            try
            {
                foreach (Client targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK)))
                {
                    if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (player.AdminRank == 7)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {B40000}Projektleitung " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Projektleitung " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 6)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {EC0000}Stellv.Projektleitung " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Stellv.Projektleitung " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 5)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {E8AE00}Administrator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 4)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {002DE0}Moderator " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 3)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {006600}Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.Username + ": " + message + " }} ");
                        }
                        else if (player.AdminRank == 2)
                        {
                            targetsingame.SendTranslatedChatMessage("{{ ACHAT {C800C8}Ticket-Supporter " + player.Username + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.Username + ": " + message + " }} ");
                        }
                    }
                }
            }
            catch { }
        }





        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////


        [Command("goto", true)]
        public void TpCommand(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                // We get the player from the input string
                if (target != null)
                {
                    // Change player's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
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
        public void BringCommand(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                if (target != null)
                {
                    // Change target's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(target, 2000);
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
        public void CharacterCommand(Client player, string action, string target_name, string amount)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
                {
                    // We check whether the player is connected
                    if (target != null && target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
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
        public static void GetAdminDimension(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                player.SendTranslatedChatMessage(target.Username + " hat dimension : " + target.Dimension);
            }
        }


        [Command("revive")]
        public void ReviveCommand(Client player, string target_name)
        {
            Client Target = RageAPI.GetPlayerFromName(target_name);
            if (Target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_SUPPORTER)
            {
                if (Target != null)
                {
                    if (Target.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                    {
                        AntiCheat_Allround.SetTimeOutHealth(Target, 1000);
                        Target.SpawnPlayer(Target.Position);
                        Target.vnxSetStreamSharedElementData(EntityData.PLAYER_KILLED, 0);
                        player.SendTranslatedChatMessage("~g~Du hast " + Target.Username + " wiederbelebt.");
                        Target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat dich wiederbelebt.");
                        logfile.WriteLogs("admin", player.Username + " hat " + Target.Username + " wiederbelebt!");
                        Target.Emit("destroyKrankenhausTimer");
                        Target.Emit("VnX_DestroyIPlayerSideTimer_KH");
                        foreach (Client medics in Alt.GetAllPlayers())
                        {
                            if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                            {
                                medics.Emit("Destroy_MedicBlips", Target.Username);
                            }
                        }
                    }
                }
            }
        }



        [Command("prison")]
        public void JailCommand(Client player, string target, int zeit, string grund)
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
                        Client targetplayer = RageAPI.GetPlayerFromName(SpielerName);
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
                            AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = 0;
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
        public void timeban_player(Client player, string target, int zeit, string grund)
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
                        Client targetplayer = RageAPI.GetPlayerFromName(SpielerName);
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
        public void ReconCommand(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
                {
                    //anzeigen.Usefull.VnX.SpectatePlayer(player, target, 0);
                    sendAdminInformation(player.Username + " spectatet grade " + target.Username + "!");
                }
            }
            catch { }
        }

        [Command("specoff")]
        public void RecoffCommand(Client player)
        {
            if (player.AdminRank > Constants.ADMINLVL_SUPPORTER)
            {
                //anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                sendAdminInformation(player.Username + " hat aufgehört " + player.Username + " zu spectaten!");
            }
        }


        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////

        [Command("clearchat")]
        public static void ClearChatForEveryone(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                for (int i = 0; i < 100; ++i)
                {
                    RageAPI.SendTranslatedChatMessageToAll(" ");
                }
                vnx_stored_files.logfile.WriteLogs("admin", player.Username + " hat den Chat gecleared!");
            }
        }

        [Command("adstate")]
        public static void SetAdState(Client player, int Werbung)
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
        public void OchatCommand(Client player, string message)
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
        public static void UnPrisonPlayer(Client player, string target)
        {
            if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
            {
                bool Found = Database.FindCharacterByName(target);
                if (Found)
                {
                    string SocialClubId = Database.GetCharakterSocialName(target);
                    string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                    Client targetplayer = RageAPI.GetPlayerFromName(SpielerName);
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
                        AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                        targetplayer.Dimension = 0;
                        targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
                        anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                        targetplayer.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME, 0);
                        targetplayer.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.spawnplayer_on_spawnpoint(targetplayer);
                    }
                }
            }

        }



        [Command("permaban", true)]
        public void permaban_player(Client player, string target, string grund)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_MODERATOR)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        string SpielerSerial = Database.GetAccountSpielerSerial(SocialClubId);
                        Client targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund, player.Username);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund, player.Username);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
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




        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////



        [Command("updateinventar")]
        public static void UpdateTargetInventar(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }

            List<InventoryModel> inventory = anzeigen.Inventar.Main.GetPlayerInventory(target);
            target.Emit("Inventory:Update", JsonConvert.SerializeObject(inventory));
        }

        [Command("clearinventar")]
        public static void ClearTargetPlayerInventar(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    int targetId = target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                    if (targetId > 0)
                    {
                        foreach (ItemModel item in anzeigen.Inventar.Main.CurrentOnlineItemList.ToList())
                        {
                            if (item.ownerIdentifier == targetId)
                            {
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(item);
                            }
                        }
                        player.RemoveAllPlayerWeapons();
                        Database.RemoveAllItems(targetId);
                    }
                    player.SendTranslatedChatMessage("Du hast das Inventar von " + target.Username + " geleert!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.Message);
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.StackTrace);
            }
        }

        [Command("coord")]
        public void CoordCommand(Client player, float posX, float posY, float posZ)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                player.Dimension = 0;
                player.SetPosition = new Position(posX, posY, posZ);
                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.vnxSetElementData(EntityData.PLAYER_BUSINESS_ENTERED, 0);
            }
        }

        [Command("pos")]
        public void PosCommand(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                Console.WriteLine("Position : " + player.Position);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "  Rot : " + RageAPI.GetHexColorcode(255, 255, 255) + player.Rotation);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "  POS X :" + player.Position.X + " | POS Y : " + player.Position.Y + " | POS Z : " + player.Position.Z);
            }
        }

        [Command("sstate")]
        public static void SetSocialStatePlayer(Client player, string target_name, string element)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_STATUS, element);
                target.SetStreamSyncedMetaData(VenoXV.Globals.EntityData.PLAYER_STATUS, element);
                sendAdminNotification(player.Username + " hat " + target.Username + " Sozialen Status geändert zu " + element + ".");
                logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " sozialen status auf " + element + " geändert!");
            }
        }


        [Command("triggersound")]
        public static void TriggerSoundEffect(Client player, string target_name, string SoundName, string SoundSetName)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("VnX_Play_Sound", SoundName, SoundSetName);
            }
        }

        [Command("triggermp3")]
        public static void Triggeraudio(Client player, string target_name, string audioclass)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("load_audio_table_vnx", audioclass);
            }
        }

        [Command("triggerfx")]
        public static void Triggerfx(Client player, string target_name, string effect, int duration, bool loop)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("start_screen_fx", effect, duration, loop);
            }
        }

        [Command("stopfx")]
        public static void StopfxAdmin(Client player, string target_name, string effect)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("stop_screen_fx", effect);
            }
        }

        [Command("setpremium")]
        public static void GivePremiumToPlayer(Client player, string target_name, int PaketNr, int Tage)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (PaketNr == 0)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "Abgelaufen", 0);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                }
                else if (PaketNr == 1)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "Bronze", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (PaketNr == 2)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "Silber", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Silber");
                }
                else if (PaketNr == 3)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "Gold", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (PaketNr == 4)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "UltimateRed", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "UltimateRed");
                }
                else if (PaketNr == 5)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "Platin", Tage);
                    sendAdminNotification(player.Username + " hat das VIP Level von " + target.Username + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "Platin");
                }
                else if (PaketNr == 6)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), "TOP DONATOR", Tage);
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
        public void WeatherCommand(Client player, int weather)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (weather < 0 || weather > 14)
                {

                }
                else
                {
                    //NAPI.World.SetWeather((Weather)weather);
                    foreach (Client players in Alt.GetAllPlayers())
                    {
                        players.SetWeather((AltV.Net.Enums.WeatherType)weather);
                    }
                    RageAPI.SendTranslatedChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat das Wetter zu " + weather + " gewechselt!");
                    Main.WEATHER_CURRENT = weather;
                    Main.WEATHER_COUNTER = 0;
                }
            }
        }


        [Command("unban")]
        public static void UnbanPlayerByName(Client player, string target)
        {
            try
            {
                Database.RemoveOldBan(player.SocialClubId.ToString());
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        int UID = Database.GetCharakterUID(SpielerName);
                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde entbannt.");
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.Username + "] hat [" + SocialClubId + "][" + SpielerName + "] entbannt!");
                        }
                    }
                }
            }
            catch { }
        }

        [Command("vehicle")]
        public static void IVehicleCommand(Client player, int IVehicleid, string action)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    IVehicle Vehicle = Vehicles.Vehicles.GetVehicleById(IVehicleid);
                    if (action == "despawn")
                    {
                        Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        player.SendTranslatedChatMessage("Erfolgreich despawned!");
                    }
                    else if (action == "gethere")
                    {
                        Vehicle.Position = player.Position;
                        player.SendTranslatedChatMessage("Fahrzeug Erfolgreich geholt!");
                    }
                    else if (action == "goto")
                    {
                        AntiCheat_Allround.SetTimeOutTeleport(player, 2500);
                        player.SetPosition = Vehicle.Position;
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
        public static void DespawnAllIVehiclesInArea(Client player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.Position.Distance(player.Position) < 20 && Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION) <= Constants.FACTION_NONE)
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
        public static void AdminResetAktion(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                DateTime AktionPossible = Fun.Allround.AktionsTimer;
                if (AktionPossible > DateTime.Now)
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                        {

                            Fun.Allround.ChangeAktionsTimer(DateTime.Now);
                            Fun.Allround.ChangeAktionsState(false);
                            Vehicle.Remove();
                        }
                    }
                    Fun.Allround.ChangeAktionsTimer(DateTime.Now);
                    Fun.Allround.ChangeAktionsState(false);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 200, 200) + "[VnX]" + player.Username + " hat alle Aktionen Resettet!");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Es sind Aktionen bereits verfügbar!");
                }
            }
            else
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
            }
        }


        [Command("createhouse")]
        public void CreateNewHausmarker(Client player, string name, int preis, int interior)
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
                Core.RageAPI.CreateTextLabel(House.GetHouseLabelText(house), house.position, 35.0f, 0.75f, 4, new int[] { 255, 255, 255, 255 });
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
        public void DeleteHausmarker(Client player)
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
        public void MakeLeader_AdminFunc(Client player, string target_name, int faction)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    Client target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (faction > 13 || faction < 0)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Fraktions ID nur zwischen 0-13 möglich!");
                        return;
                    }
                    if (faction == 0)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Bürger gemacht.");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 1)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Chief of Police ernannt! Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 2)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Don der La Cosa Nostra von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 3)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Yakuza von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 4)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [GESPERRT ] Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 5)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Chefredakteur der Venox City News - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 6)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Direktor des Federal Investigation Bureau - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 7)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Boss der Venox City Vatos Locos - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 8)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Commander der Venox U.S Army - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 9)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der President der SAMCRO Redwoods Original´s - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 10)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader der Venox Medic's - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 11)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader von den Venox City Mechaniker - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 12)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Du bist nun der Banger der Venox City Ballas - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 13)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Venox City Grove Street - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    target.vnxSetStreamSharedElementData(EntityData.PLAYER_FACTION, faction);
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_RANK, 5);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " zum Leader von Fraktion " + faction + " gemacht!");
                }
            }
            catch
            {
            }
        }

        [Command("setrank")]
        public void setUserRank(Client player, string target_name, int rank)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
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
                    target.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_RANK, rank);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    target.SendTranslatedChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.Username + " hat deinen Fraktion´s rang auf " + rank + " geändert!");
                    sendAdminNotification(player.Username + " hat " + target.Username + " Franktion´s Rang auf " + rank + " geändert!");
                    logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " Franktion´s Rang auf " + rank + " geändert!");
                }
            }
        }

        [Command("getIVehicleinfo", true)]
        public static void GiveAdminWeapons(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (player.Vehicle != null)
                {
                    player.SendTranslatedChatMessage("Info : " + player.Vehicle.Model);
                }
            }
        }


        [Command("giveweapon", true)]
        public static void GiveAdminWeapons(Client player, string weapon)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                if (weapon == "mp5")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_MP5, Constants.ITEM_ART_WAFFE, 200, true);
                }
                else if (weapon == "m4")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_KARABINER, Constants.ITEM_ART_WAFFE, 200, true);

                }
                vnx_stored_files.logfile.WriteLogs("admin", player.Username + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
                Admin.sendAdminNotification(player.Username + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
            }
        }

        [Command("changepw")]
        public static void ChangeUserPasswort(Client player, string name, string passwort)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                bool exestiert = Database.FindCharacterByName(name);
                if (exestiert)
                {
                    Database.ChangeUserPasswort(name, passwort);
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Es wurde kein Spieler mit dem Namen " + name + " gefunden!");
                }
            }
        }



        [Command("gotogw")]
        public static void Teleport2TK(Client player, string name)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.Name == name)
                    {
                        Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1000);
                        player.SendTranslatedChatMessage("[GW] Teleported to '" + area.Name + "'.");
                        player.SetPosition = area.TK;
                        player.Dimension = 0;
                    }
                }

            }
        }

        [Command("stopgw")]
        public static void StopGangwar(Client player)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                gangwar.Allround._gangwarManager.StopCurrentGangwar();
                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Der laufende Gangwar wurde gestoppt!");
            }
        }

        [Command("getgw")]
        public static void GetInfo(Client player, string name)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = gangwar.Allround._gangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.Inform(player);
                }
            }
        }

        [Command("setgwowner")]
        public static void SetGangwarOwner(Client player, string name, int factionId)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = gangwar.Allround._gangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.SetOwner(factionId);
                }
            }
        }


        [Command("getserial")]
        public static void GetAdminSerial(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + target.Username + " hat serial : " + target.HardwareIdHash);
            }
        }



        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        [Command("vnxgetelementdata")]
        public static void GetElementDataAdmin(Client player, string target_name, string element)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + target.vnxGetElementData<object>(element));
                player.SendTranslatedChatMessage(target.Username);
            }
        }

        [Command("vnxvehgetelementdata")]
        public static void GetElementDataAdmin(Client player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        // player.SendTranslatedChatMessage("[vnxGetElementData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }

        [Command("vnxvehgetshareddata")]
        public static void GetSharedElementDataAdmin(Client player, string element)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        // player.SendTranslatedChatMessage("[VnXGetSharedData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }



        [Command("hauschange")]
        public void ChangeHausData(Client player, string element, int value)
        {
            string e = element.ToLower();
            if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) > Constants.ADMINLVL_STELLVP)
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
        public static void SetPlayerAdminHunger(Client player, string target_name, int value)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                target.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, value);
                player.SendTranslatedChatMessage("Du hast" + target.Username + " Hunger Level auf : " + value + " gesetzt!");
            }
        }

        [Command("createforumuser")]
        public static void CreateForumUser_Admin_CMD(Client player, string Name, string email, string passwort)
        {
            if (player.AdminRank >= Constants.ADMINLVL_STELLVP)
            {
                _ = Program.CreateForumUser(Name, email, passwort);
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
                    target.Armor = valuea;
                }
                else if (value == "health")
                {
                    AntiCheat_Allround.SetTimeOutHealth(target, 1000);
                    target.Health = valuea;
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
        public static void ChangeSkin(Client player, int slot, int drawable, int texture)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //ToDo Sie Clientseitig Laden! : player.SetClothes(slot, drawable, texture);
            }
        }

        [Command("aprop")]
        public static void ChangeProp(Client player, int slot, int drawable, int texture)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //ToDo Sie Clientseitig Laden! :NAPI.Player.SetPlayerAccessory(player, slot, drawable, texture);
            }
        }

        [Command("changecar")]
        public static void ChangeCarModel(Client player, string modelName)
        {
            if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                // Obtain occupied IVehicle
                IVehicle veh = player.Vehicle;
                if (veh != null)
                {
                    // Update the IVehicle's position into the database
                    Database.UpdateIVehicleSingleString("model", modelName, veh.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID));
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast das Fahrzeug geändert zu : " + modelName);
                }
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

        [Command("giveweapons")]
        public static void GiveTestWeapons(Client player)
        {
            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.BullpupRifleMkII, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.BullpupRifleMkII, 2);

            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Pistol50, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.Pistol50, 3);

            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AssaultRifle, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.AssaultRifle, 2);
        }

        [Command("createvehicle")]
        public static void CreatePermanentIVehicle(Client player, string VehicleModel, string IVehicleOwner, int FID, int R, int G, int B, int R2, int G2, int B2, int IVehiclePreis, float IVehicleLiter)
        {
            try
            {
                if (R > 255 || G > 255 || B > 255 || R2 > 255 || G2 > 255 || B2 > 255)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Primary & Sec. Rgba darf nicht über 255 sein!");
                    return;
                }
                else if (R < 0 || G < 0 || B < 0 || R2 < 0 || G2 < 0 || B2 < 0)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Primary & Sec. Rgba darf nicht unter 0 sein!");
                    return;
                }
                if (player.AdminRank >= Constants.ADMINLVL_TSUPPORTER)
                {
                    VehicleModel IVehicle = new VehicleModel
                    {
                        // Basic data for IVehicle creation
                        model = VehicleModel,
                        faction = FID,
                        position = player.Position,
                        rotation = player.Rotation,
                        dimension = player.Dimension,
                        RgbaType = Constants.VEHICLE_Rgba_TYPE_CUSTOM,
                        firstRgba = R + "," + G + "," + B,
                        secondRgba = R2 + "," + G2 + "," + B2,
                        pearlescent = 0,
                        owner = IVehicleOwner,
                        plate = string.Empty,
                        price = IVehiclePreis,
                        parking = 0,
                        parked = 0,
                        gas = IVehicleLiter,
                        kms = 0.0f
                    };

                    // Create the IVehicle
                    Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("SpawnAdminVehicle", ex); }
        }


        // DrugsMichaelAliensFightIn == Sollten wir verwenden für drogen system ^^
    }
}
