using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.business;
using VenoXV.Reallife.vnx_stored_files;
using VenoXV.Reallife.database;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.house;
using VenoXV.Reallife.model;
using VenoXV.Reallife.Vehicles;
using VenoXV.Reallife.Woltlab;
using VenoXV.Reallife.register_login;
using VenoXV.Reallife.character;
using AltV.Net.Resources.Chat.Api;
using AltV.Net;
using AltV.Net.Data;
using VenoXV.Reallife.Core;

namespace VenoXV.Reallife.admin
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
            foreach (IPlayer admin in Alt.GetAllPlayers())
            {
                if (admin.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                {
                    admin.SendChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + text);
                }
            }
        }

        public static void sendAdminInformation(string text)
        {
            try
            {
                foreach (IPlayer admin in Alt.GetAllPlayers())
                {
                    if (admin.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        admin.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[Info] : " + RageAPI.GetHexColorcode(255,255,255) + text);
                    }
                }
            }
            catch
            {
            }
        }

        public static bool HaveAdminRights(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                return true;
            }
            return false;
        }

        [Command("admins")]
        public void AdminsIngameCommand(IPlayer player)
        {
            try
            {
                //foreach (IPlayer targetsingame in Alt.GetAllPlayers())
                player.SendChatMessage("---------------------------------------------------------");
                player.SendChatMessage("Folgende Admins sind grade Online : ");
                foreach (IPlayer targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK)))
                {
                    if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 7)
                        {
                            player.SendChatMessage("{B40000}[VnX]" + targetsingame.Name+ ", Projektleitung");
                        }
                        else if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 6)
                        {
                            player.SendChatMessage("{EC0000}[VnX]" + targetsingame.Name + ", Stellv.Projektleitung");
                        }
                        else if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 5)
                        {
                            player.SendChatMessage("{E8AE00}[VnX]" + targetsingame.Name + ", Administrator");
                        }
                        else if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 4)
                        {
                            player.SendChatMessage("{002DE0}[VnX]" + targetsingame.Name + ", Moderator");
                        }
                        else if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 3)
                        {
                            player.SendChatMessage("{006600}[VnX]" + targetsingame.Name + ", Supporter");
                        }
                        else if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 2)
                        {
                            player.SendChatMessage("{C800C8}" + $"{targetsingame.Name}, Ticket - Supporter");
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
                if(adminlvl == 2) { return "{C800C8}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
                else if(adminlvl == 3) { return "{006600}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
                else if(adminlvl == 4) { return "{002DE0}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
                else if(adminlvl == 5) { return "{E8AE00}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
                else if(adminlvl == 6) { return "{EC0000}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
                else if(adminlvl == 7) { return "{B40000}[VnX]" + RageAPI.GetHexColorcode(255,255,255); }
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
        public static void KickPlayer(IPlayer player, IPlayer target, string reason)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                {
                    Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + target.Name + " wurde von " +player.Name + " gekickt! Grund : " + reason);
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + target.SocialClubId + "][" + target.Name + "] gekickt! Grund : " + reason);
                    target.Kick("~r~Grund : ~h~" + reason);
                }
            }
            catch { }
        }

        [Command("achat",  true)]
        public void ACommand(IPlayer player, string message)
        {
            try
            {
                foreach (IPlayer targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK)))
                {
                    if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 7)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {B40000}Projektleitung " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Projektleitung " +player.Name + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 6)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {EC0000}Stellv.Projektleitung " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Stellv.Projektleitung " +player.Name + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 5)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {E8AE00}Administrator " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Administrator " +player.Name + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 4)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {002DE0}Moderator " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Moderator " +player.Name + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 3)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {006600}Supporter " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Supporter " +player.Name + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 2)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {C800C8}Ticket-Supporter " +player.Name + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " +player.Name + ": " + message + " }} ");
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

        [Command("aduty")]
        public static void GoADuty(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_ON_DUTY) != 1)
                    {
                        // Set Clothes
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(0, -1, -10);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(1, 0, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(2, -1, -1);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(3, 96, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(4, 77, 3);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(5, 0, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(6, 55, 3);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(7, 0, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(8, 15, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(9, 0, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(10, 0, 0);
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(11, 178, 3);
                        //ToDo Sie Clientseitig Laden! :NAPI.Player.SetPlayerAccessory(player, 0, 91, 3);
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_ADMIN_ON_DUTY, 1);

                        // Weapon Ban Fix 
                        player.RemoveAllWeapons();

                        Reallife.Core.RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG +player.Name + " ist nun Admin - Duty.");
                    }
                    else
                    {
                        // Remove 
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_ADMIN_ON_DUTY, 0);

                        // Restore old skin
                        int sqlid = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        PlayerModel character = Database.LoadCharacterInformationById(sqlid);
                        SkinModel skinModel = Database.GetCharacterSkin(sqlid);
                        if (character != null && character.realName != null)
                        {
                            //ToDo : Fix & find another Way! player.Name = character.realName;
                            player.SetData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                                                        player.Model = character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");
                            Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                            Customization.ApplyPlayerClothes(player);
                            Customization.ApplyPlayerTattoos(player);

                            // Weapon ban Fix
                            weapons.Weapons.GivePlayerWeaponItems(player);
                            Reallife.Core.RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG +player.Name + " ist nun nicht mehr im Admin - Duty.");

                        }
                    }
                }
                else { dxLibary.VnX.DrawNotification(player, "error", "Seit wann bist du ein VenoX Mitglied?"); }
            }
            catch { }
        }

        [Command("goto", true)]
        public void TpCommand(IPlayer player, IPlayer target)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                // We get the player from the input string
                if (target != null)
                {
                    // Change player's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    player.Position = target.Position;
                    player.Dimension = target.Dimension;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255,255,255) + "Du hast dich zu " + RageAPI.GetHexColorcode(0,200,255) + target.Name + " " + RageAPI.GetHexColorcode(255,255,255) + "teleportiert!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + "[VnX]" +player.Name + " " + RageAPI.GetHexColorcode(255,255,255) + "hat sich zu dir teleportiert!");
                    logfile.WriteLogs("admin",player.Name + " hat sich zu " + target.Name + " geportet!");
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200,0,0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255,255,255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("gethere",true)]
        public void BringCommand(IPlayer player, IPlayer target)
        {

            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                if (target != null)
                {
                    // Change target's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(target, 2000);
                    target.Position = player.Position;
                    target.Dimension = player.Dimension;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255,255,255) + "Du hast " + RageAPI.GetHexColorcode(0,200,255) + target.Name + " " + RageAPI.GetHexColorcode(255,255,255) + " zu dir teleportiert!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + "[VnX]" +player.Name + " " + RageAPI.GetHexColorcode(255,255,255) + "hat dich zu ihm teleportiert!");
                    logfile.WriteLogs("admin",player.Name + " hat " + target.Name + " zu sich geportet!");
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200,0,0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255,255,255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("charakter")]
        public void CharacterCommand(IPlayer player, string action, IPlayer target, string amount)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
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
                                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.SetData(EntityData.PLAYER_BANK, value);
                                        player.SendChatMessage("~g~Du hast das Bankgeld von " + target.Name + " auf : " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG +player.Name + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" +player.Name + " hat das Bankgeld von " + target.Name + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.SetData(EntityData.PLAYER_MONEY, value);
                                        player.SendChatMessage("~g~Du hast das Bargeld von " + target.Name + " auf : " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat dein Bargeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" +player.Name + " hat das Bargeld von " + target.Name + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "dimension":
                                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
                                    {
                                        target.Dimension = value;
                                        player.SendChatMessage("~g~Du hast " + target.Name + " Dimension auf " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat deine Dimension auf :  " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" +player.Name + " hat " + target.Name + " in die Dimension " + value + " verschoben!");

                                    }
                                    break;

                                default:
                                    break;
                            }
                        }

                    }
                    else
                    {
                        player.SendChatMessage(Constants.Rgba_ERROR + "SPIELER NICHT GEFUNDEN");
                    }
                }
            }
            catch { }
        }

        [Command("getdim")]
        public static void GetAdminDimension(IPlayer player, IPlayer target)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                player.SendChatMessage(target.Name + " hat dimension : " + target.Dimension);
            }
        }


        [Command("revive")]
        public void ReviveCommand(IPlayer player, IPlayer Target)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                if (Target != null)
                {
                    if (Target.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                    {
                        AntiCheat_Allround.SetTimeOutHealth(Target, 1000);
                        Target.Spawn(Target.Position);
                        Core.VnX.vnxSetSharedData(Target, EntityData.PLAYER_KILLED, 0);
                        player.SendChatMessage("~g~Du hast " + Target.Name + " wiederbelebt.");
                        Target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat dich wiederbelebt.");
                        logfile.WriteLogs("admin",player.Name + " hat " + Target.Name + " wiederbelebt!");
                        Target.Emit("destroyKrankenhausTimer");
                        Target.Emit("VnX_DestroyIPlayerSideTimer_KH");
                        foreach (IPlayer medics in Alt.GetAllPlayers())
                        {
                            if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                            {
                                medics.Emit("Destroy_MedicBlips", Target.Name);
                            }
                        }
                    }
                }
            }
        }



        [Command("prison")]
        public void JailCommand(IPlayer player, string target, int zeit, string grund)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        IPlayer targetplayer = Reallife.Core.RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);
                        if (Database.FindCharakterPrison(SpielerName))
                        {
                            int PrisonTime = Database.GetCharakterPrisonTime(SpielerName);
                            Database.UpdatePlayerPrisonTime(UID, PrisonTime + zeit, grund,player.Name, DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0)+ SpielerName + " wurde von [VnX]" +player.Name + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerToPrison(UID, SpielerName, zeit, grund,player.Name, DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + SpielerName +" wurde von [VnX]" +player.Name + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = 0;
                            targetplayer.Position = new Position(1651.441f, 2569.83f, 45.56486f);
                            anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                            targetplayer.SetData(EntityData.PLAYER_PRISON_TIME, zeit);
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht Befugt!");
                }
            }
            catch { }
        }

        [Command("timeban")]
        public void timeban_player(IPlayer player, string target, int zeit, string grund)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        string SpielerSerial = Database.GetAccountSpielerSerial(SocialClubId);
                        IPlayer targetplayer = Reallife.Core.RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId.ToString()))
                        {
                            Accountbans ban = Database.GetAccountbans(SocialClubId.ToString());
                            if (ban.banzeit > DateTime.Now)
                            {
                                Database.UpdatePlayerTimeBan(UID, grund,player.Name, ban.banzeit.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + SpielerName + " wurde von [VnX]" +player.Name + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                            else
                            {
                                Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund,player.Name, DateTime.Now.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0)+  SpielerName + " wurde von [VnX]" +player.Name + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                        }
                        else
                        {
                            Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund,player.Name, DateTime.Now.AddHours(zeit), DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + SpielerName + " wurde von [VnX]" + player.Name + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            targetplayer.Kick("~r~Grund : ~h~" + grund);
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht Befugt!");
                }
            }
            catch { }
        }



        [Command("spec")]
        public void ReconCommand(IPlayer player, IPlayer target)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
                {
                    anzeigen.Usefull.VnX.SpectatePlayer(player, target, 0);
                    sendAdminInformation(player.Name + " spectatet grade " + target.Name + "!");
                }
            }
            catch { }
        }

        [Command("specoff")]
        public void RecoffCommand(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
            {
                anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                sendAdminInformation(player.Name + " hat aufgehört " +player.Name + " zu spectaten!");
            }
        }


        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////MODERATOR/////////////////////////////////////////////////

        [Command("clearchat")]
        public static void ClearChatForEveryone(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                for (int i = 0; i < 100; ++i)
                {
                    Reallife.Core.RageAPI.SendChatMessageToAll(" ");
                }
                vnx_stored_files.logfile.WriteLogs("admin",player.Name + " hat den Chat gecleared!");
            }
        }

        [Command("adstate")]
        public static void SetAdState(IPlayer player, string Werbungjaodernein)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Werbungjaodernein = Werbungjaodernein.ToLower();
                string state =RageAPI.GetHexColorcode(0,175,0) + "angeschaltet!";
                if (Werbungjaodernein == "nein")
                {
                    state =RageAPI.GetHexColorcode(175,0,0) + "ausgeschaltet!";
                }
                else if (Werbungjaodernein == "ja")
                {
                    Reallife.Core.RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat das AD-System " + state);
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Status muss JA oder NEIN sein!");
                }
            }
        }

        [Command("ochat",  true)]
        public void OchatCommand(IPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_NONE)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 7)
                    {
                        Reallife.Core.RageAPI.SendChatMessageToAll("(( {B40000}Projektleitung " +player.Name + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Projektleitung " +player.Name + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 6)
                    {
                        Reallife.Core.RageAPI.SendChatMessageToAll("(( {EC0000}Stellv.Projektleitung " +player.Name + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Stellv.Projektleitung " +player.Name + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 5)
                    {
                        Reallife.Core.RageAPI.SendChatMessageToAll("(( {E8AE00}Administrator " +player.Name + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Administrator " +player.Name + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 4)
                    {
                        Reallife.Core.RageAPI.SendChatMessageToAll("(( {002DE0}Moderator " +player.Name + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Moderator " +player.Name + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 3)
                    {
                        player.SendChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " +player.Name + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " +player.Name + " versuchte Nachricht : " + message + " }}");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 2)
                    {
                        player.SendChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " +player.Name + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " +player.Name + " versuchte Nachricht : " + message + " }}");
                    }
                }
            }
            catch { }
        }

        [Command("unprison")]
        public static void UnPrisonPlayer(IPlayer player, string target)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                bool Found = Database.FindCharacterByName(target);
                if (Found)
                {
                    string SocialClubId = Database.GetCharakterSocialName(target);
                    string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                    IPlayer targetplayer = Reallife.Core.RageAPI.GetPlayerFromName(SpielerName);
                    int UID = Database.GetCharakterUID(SpielerName);
                    if (Database.FindCharakterPrison(SpielerName))
                    {
                        Database.RemoveOldPrison(SpielerName);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler ist nicht im Prison!");
                    }
                    if (targetplayer != null)
                    {
                        AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                        targetplayer.Dimension = 0;
                        targetplayer.Position = new Position(1651.441f, 2569.83f, 45.56486f);
                        anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                        targetplayer.SetData(EntityData.PLAYER_PRISON_TIME, 0);
                        targetplayer.SendChatMessage(RageAPI.GetHexColorcode(200,0,0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.spawnplayer_on_spawnpoint(targetplayer);
                    }
                }
            }

        }



        [Command("permaban",  true)]
        public void permaban_player(IPlayer player, string target, string grund)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        string SpielerSerial = Database.GetAccountSpielerSerial(SocialClubId);
                        IPlayer targetplayer = Reallife.Core.RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund,player.Name);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) +SpielerName + " wurde von [VnX]" +player.Name + " permanent gebannt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund,player.Name);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + SpielerName + " wurde von [VnX]" + player.Name + " permanent gebannt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            targetplayer.Kick("~r~Grund : ~h~" + grund);
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht Befugt!");
                }
            }
            catch { }
        }




        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////
        /////////////////////////////////////////////////ADMINISTRATOR/////////////////////////////////////////////////


        [Command("clearinventar")]
        public static void ClearTargetPlayerInventar(IPlayer player, IPlayer target)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    int targetId = target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                    if (targetId > 0)
                    {
                        foreach (ItemModel item in Main.itemList.ToList())
                        {
                            if (item.ownerIdentifier == targetId && item.ownerEntity == Constants.ITEM_ENTITY_PLAYER)
                            {
                                Main.itemList.Remove(item);
                            }
                        }
                        player.RemoveAllWeapons();
                        Database.RemoveAllItems(targetId);
                    }
                    player.SendChatMessage( "Du hast das Inventar von " + target.Name + " geleert!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.Message);
                Console.WriteLine("[EXCEPTION ClearTargetPlayerInventar] " + ex.StackTrace);
            }
        }

        [Command("coord")]
        public void CoordCommand(IPlayer player, float posX, float posY, float posZ)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                AntiCheat_Allround.SetTimeOutTeleport(player, 5000);
                player.Dimension = 0;
                player.Position = new Position(posX, posY, posZ);
                player.SetData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.SetData(EntityData.PLAYER_BUSINESS_ENTERED, 0);
            }
        }

        [Command("pos")]
        public void PosCommand(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                Console.WriteLine("Position : " + player.Position);
                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + "  Rot : " + RageAPI.GetHexColorcode(255,255,255) + player.Rotation);
                player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + "  POS X :" + player.Position + " | POS Y : " + player.Position.Y + " | POS Z : " + player.Position.Z);
            }
        }

        [Command("sstate")]
        public static void SetSocialStatePlayer(IPlayer player, IPlayer target, string element)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.SetData(EntityData.PLAYER_STATUS, element);
                target.SetSyncedMetaData(EntityData.PLAYER_STATUS, element);
                sendAdminNotification(player.Name + " hat " + target.Name + " Sozialen Status geändert zu " + element + ".");
                logfile.WriteLogs("admin",player.Name + " hat " + target.Name + " sozialen status auf " + element + " geändert!");
            }
        }


        [Command("triggersound")]
        public static void TriggerSoundEffect(IPlayer player, IPlayer target, string SoundName, string SoundSetName)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("VnX_Play_Sound", SoundName, SoundSetName);
            }
        }

        [Command("triggermp3")]
        public static void Triggeraudio(IPlayer player, IPlayer target, string audioclass)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("load_audio_table_vnx", audioclass);
            }
        }

        [Command("triggerfx")]
        public static void Triggerfx(IPlayer player, IPlayer target, string effect, int duration, bool loop)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("start_screen_fx", effect, duration, loop);
            }
        }

        [Command("stopfx")]
        public static void StopfxAdmin(IPlayer player, IPlayer target, string effect)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("stop_screen_fx", effect);
            }
        }

        [Command("setpremium")]
        public static void GivePremiumToPlayer(IPlayer player, IPlayer target, int PaketNr, int Tage)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (PaketNr == 0)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Abgelaufen", 0);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "-");
                }
                else if (PaketNr == 1)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Bronze", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (PaketNr == 2)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Silber", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "Silber");
                }
                else if (PaketNr == 3)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Gold", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (PaketNr == 4)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "UltimateRed", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "UltimateRed");
                }
                else if (PaketNr == 5)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Platin", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "Platin");
                }
                else if (PaketNr == 6)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "TOP DONATOR", Tage);
                    sendAdminNotification(player.Name + " hat das VIP Level von " + target.Name + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.SetData(EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else
                {
                    player.SendChatMessage( "Ungültige Paket Nummer! ( 0 - 6 )");
                }
            }
        }


        [Command("weather")]
        public void WeatherCommand(IPlayer player, int weather)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (weather < 0 || weather > 14)
                {

                }
                else
                {
                    //NAPI.World.SetWeather((Weather)weather);
                    Reallife.Core.RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat das Wetter zu " + weather + " gewechselt!");
                    Main.WEATHER_CURRENT = weather;
                    Main.WEATHER_COUNTER = 0;
                }
            }
        }


        [Command("unban")]
        public static void UnbanPlayerByName(IPlayer player, string target)
        {
            try
            {
                Database.RemoveOldBan(player.SocialClubId.ToString());
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    bool Found = Database.FindCharacterByName(target);
                    if (Found)
                    {
                        string SocialClubId = Database.GetCharakterSocialName(target);
                        string SpielerName = Database.GetAccountSpielerName(SocialClubId);
                        IPlayer targetplayer = Reallife.Core.RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);
                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) +SpielerName + " wurde entbannt.");
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat [" + SocialClubId + "][" + SpielerName + "] entbannt!");
                        }
                    }
                }
            }
            catch { }
        }

        [Command("vehicle")]
        public static void IVehicleCommand(IPlayer player, int IVehicleid, string action)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    IVehicle Vehicle = Vehicles.Vehicles.GetVehicleById(IVehicleid);
                    if(action == "despawn")
                    {
                        Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        player.SendChatMessage("Erfolgreich despawned!");
                    }
                    else if(action == "gethere")
                    {
                        Vehicle.Position = player.Position;
                        player.SendChatMessage("Fahrzeug Erfolgreich geholt!");
                    }                        
                    else if(action == "goto")
                    {
                        AntiCheat_Allround.SetTimeOutTeleport(player, 2500);
                        player.Position = Vehicle.Position;
                        player.SendChatMessage("Fahrzeug Erfolgreich hingegangen!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Das Fahrzeug exestiert nicht!");
                }
            }
            catch { }
        }

        [Command("crespawnarea")]
        public static void DespawnAllIVehiclesInArea(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        if (Vehicle.Position.Distance(player.Position) < 20 && Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION) <= Constants.FACTION_NONE)
                        {
                            Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        }
                    }
                    sendAdminInformation(player.Name + " hat alle Fahrzeuge in seiner Nähe despawned!");
                }
            }
            catch { }
        }



        [Command("resetaktion")]
        public static void AdminResetAktion(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
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
                    Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,200,200) + "[VnX]" +player.Name + " hat alle Aktionen Resettet!");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Es sind Aktionen bereits verfügbar!");
                }
            }
            else
            {
                dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht Befugt!");
            }
        }


        [Command("createhouse")]
        public void CreateNewHausmarker(IPlayer player, string name, int preis, int interior)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
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
                ////house.houseLabel = //ToDo: ClientSide erstellen NAPI.TextLabel.CreateTextLabel(House.GetHouseLabelText(house), house.position, 20.0f, 0.75f, 4, new Rgba(255, 255, 255));
                House.houseList.Add(house);

                sendAdminInformation(player.Name + " hat einen Hausmarker erstellt! " + RageAPI.GetHexColorcode(0,200,255) + " [" + RageAPI.GetHexColorcode(255,255,255) +  + house.id +RageAPI.GetHexColorcode(0,200,255) + " ]" + "[" + RageAPI.GetHexColorcode(255,255,255) +  + preis +RageAPI.GetHexColorcode(0,200,255) + "  $]" + "[" + RageAPI.GetHexColorcode(255,255,255) +  + interior +RageAPI.GetHexColorcode(0,200,255) + " ]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat einen Hausmarker erstellt! [ID : " + house.id + "]" + "[ PREIS : " + preis + " $]" + "[INTERIOR : " + interior + "]");

            }
            else
            {
                player.SendChatMessage( Constants.Rgba_ERROR + "Du bist nicht Befugt!");
            }
        }

        [Command("removehouse")]
        public void DeleteHausmarker(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                HouseModel house = House.GetClosestHouse(player);
                //house.houseLabel.Remove();
                Database.DeleteHouse(house.id);
                House.houseList.Remove(house);
                sendAdminInformation(player.Name + " hat einen Hausmarker gelöscht! " + RageAPI.GetHexColorcode(0,200,255) + " [" + RageAPI.GetHexColorcode(255,255,255) +  + house.id + "]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "] hat einen Hausmarker Gelöscht! ID : " + house.id);
            }
            else
            {
                player.SendChatMessage( Constants.Rgba_ERROR + "Du bist nicht Befugt!");
            }
        }


        [Command("makeleader")]
        public void MakeLeader_AdminFunc(IPlayer player, IPlayer target, int faction)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    if (faction > 13 || faction < 0)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Fraktions ID nur zwischen 0-13 möglich!");
                        return;
                    }
                    if (faction == 0)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du wurdest soeben zum Bürger gemacht.");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 1)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du wurdest soeben zum Chief of Police ernannt! Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 2)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun Don der La Cosa Nostra von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 3)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun Leader der Yakuza von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 4)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [GESPERRT ] Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 5)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Chefredakteur der Venox City News - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 6)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Direktor des Federal Investigation Bureau - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 7)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Boss der Venox City Vatos Locos - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 8)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Commander der Venox U.S Army - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 9)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der President der SAMCRO Redwoods Original´s - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 10)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Leader der Venox Medic's - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 11)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun der Leader von den Venox City Mechaniker - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 12)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + "Du bist nun der Banger der Venox City Ballas - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 13)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " Du bist nun Leader der Venox City Grove Street - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    Core.VnX.vnxSetSharedData(target, EntityData.PLAYER_FACTION, faction);
                    target.SetData(EntityData.PLAYER_RANK, 5);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    logfile.WriteLogs("admin",player.Name + " hat " + target.Name + " zum Leader von Fraktion " + faction + " gemacht!");
                }
            }
            catch
            {
            }
        }

        [Command("setrank")]
        public void setUserRank(IPlayer player, IPlayer target, int rank)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Der Spieler " + target.Name + " ist in keiner Fraktion!");
                }
                if (rank > 5 || rank < 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Fraktions Rang nur zwischen 0-5 möglich!");
                    return;
                }
                else
                {
                    target.SetData(EntityData.PLAYER_RANK, rank);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    target.SendChatMessage( Constants.Rgba_ADMIN_CLANTAG +player.Name + " hat deinen Fraktion´s rang auf " + rank + " geändert!");
                    sendAdminNotification(player.Name + " hat " + target.Name + " Franktion´s Rang auf " + rank + " geändert!");
                    logfile.WriteLogs("admin",player.Name + " hat " + target.Name + " Franktion´s Rang auf " + rank + " geändert!");
                }
            }
        }

        [Command("getIVehicleinfo",  true)]
        public static void GiveAdminWeapons(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if(player.Vehicle != null) 
                {
                    player.SendChatMessage("Info : " + player.Vehicle.Model);
                }
            }
        }


        [Command("giveweapon",  true)]
        public static void GiveAdminWeapons(IPlayer player, string weapon)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                if (weapon == "mp5")
                {
                    ItemModel Mp5 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MP5);
                    if (Mp5 == null)
                    {
                        Mp5 = new ItemModel();
                        Mp5.amount = 90;
                        Mp5.dimension = 0;
                        Mp5.position = new Position(0.0f, 0.0f, 0.0f);
                        Mp5.hash = Constants.ITEM_HASH_MP5;
                        Mp5.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                        Mp5.ownerIdentifier = playerId;
                        Mp5.ITEM_ART = "Waffe";
                        Mp5.objectHandle = null;
                        // Add the item into the database
                        Mp5.id = Database.AddNewItem(Mp5);
                        Main.itemList.Add(Mp5);
                    }
                    else
                    {
                        Mp5.amount = 90;
                        Database.UpdateItem(Mp5);
                    }
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 90);

                }
                else if (weapon == "m4")
                {
                    ItemModel M4A1 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KARABINER);
                    if (M4A1 == null)
                    {
                        M4A1 = new ItemModel();
                        M4A1.amount = 90;
                        M4A1.dimension = 0;
                        M4A1.position = new Position(0.0f, 0.0f, 0.0f);
                        M4A1.hash = Constants.ITEM_HASH_KARABINER;
                        M4A1.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                        M4A1.ownerIdentifier = playerId;
                        M4A1.ITEM_ART = "Waffe";
                        M4A1.objectHandle = null;
                        // Add the item into the database
                        M4A1.id = Database.AddNewItem(M4A1);
                        Main.itemList.Add(M4A1);
                    }
                    else
                    {
                        M4A1.amount = 90;
                        Database.UpdateItem(M4A1);
                    }
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 90);

                }
                else if(weapon == "schneeball")
                {
                    ItemModel Schneeball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNOWBALL);
                    if (Schneeball == null)
                    {
                        Schneeball = new ItemModel();
                        Schneeball.amount = 90;
                        Schneeball.dimension = 0;
                        Schneeball.position = new Position(0.0f, 0.0f, 0.0f);
                        Schneeball.hash = Constants.ITEM_HASH_SNOWBALL;
                        Schneeball.ownerEntity = Constants.ITEM_ENTITY_PLAYER;
                        Schneeball.ownerIdentifier = playerId;
                        Schneeball.ITEM_ART = "Waffe";
                        Schneeball.objectHandle = null;
                        // Add the item into the database
                        Schneeball.id = Database.AddNewItem(Schneeball);
                        Main.itemList.Add(Schneeball);
                    }
                    else
                    {
                        Schneeball.amount = 10;
                        Database.UpdateItem(Schneeball);
                    }
                    Reallife.Core.RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Snowballs, 10);
                }
                vnx_stored_files.logfile.WriteLogs("admin",player.Name + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
                Admin.sendAdminNotification(player.Name + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
            }
        }

        [Command("changepw")]
        public static void ChangeUserPasswort(IPlayer player, string name, string passwort)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                bool exestiert = Database.FindCharacterByName(name);
                if (exestiert)
                {
                    Database.ChangeUserPasswort(name, passwort);
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Es wurde kein Spieler mit dem Namen " + name + " gefunden!");
                }
            }
        }



        [Command("gotogw")]
        public static void Teleport2TK(IPlayer player, string name)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                foreach (var area in gangwar.Allround._gangwarManager.GangwarAreas)
                {
                    if (area.Name == name)
                    {
                        Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1000);
                        player.SendChatMessage("[GW] Teleported to '" + area.Name + "'.");
                        player.Position = area.TK;
                        player.Dimension = 0;
                    }
                }

            }
        }

        [Command("stopgw")]
        public static void StopGangwar(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                gangwar.Allround._gangwarManager.StopCurrentGangwar();
                Reallife.Core.RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + "Der laufende Gangwar wurde gestoppt!");
            }
        }

        [Command("getgw")]
        public static void GetInfo(IPlayer player, string name)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = gangwar.Allround._gangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.Inform(player);
                }
            }
        }

        [Command("setgwowner")]
        public static void SetGangwarOwner(IPlayer player, string name, int factionId)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                var area = gangwar.Allround._gangwarManager.GetAreaByName(name);
                if (area != null)
                {
                    area.SetOwner(factionId);
                }
            }
        }


        [Command("getserial")]
        public static void GetAdminSerial(IPlayer player, IPlayer target)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                player.SendChatMessage(RageAPI.GetHexColorcode(255,0,0) + target.Name + " hat serial : " + target.HardwareIdHash);
            }
        }



        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        [Command("vnxGetElementData")]
        public static void GetElementDataAdmin(IPlayer player, IPlayer target, string element)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
            {
               // player.SendChatMessage("[vnxGetElementData(" + element + ") = " + target.vnxGetElementData);
            }
        }

        [Command("vnxvehgetelementdata")]
        public static void GetElementDataAdmin(IPlayer player, string element)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                       // player.SendChatMessage("[vnxGetElementData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }

        [Command("vnxvehgetshareddata")]
        public static void GetSharedElementDataAdmin(IPlayer player, string element)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                       // player.SendChatMessage("[VnXGetSharedData(" + element + ") = " + Vehicle.vnxGetElementData(element));
                    }
                }
            }
            catch { }
        }



        [Command("hauschange")]
        public void ChangeHausData(IPlayer player, string element, int value)
        {
            string e = element.ToLower();
            if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) > Constants.ADMINLVL_STELLVP)
            {
                HouseModel house = House.GetClosestHouse(player);
                if (house == null)
                {
                    player.SendChatMessage( Constants.Rgba_ERROR + "Du bist an keinem Haus!");
                    return;
                }

                if (e == "interior")
                {
                    if (value >= 0 && value < Constants.HOUSE_IPL_LIST.Count)
                    {
                        house.ipl = Constants.HOUSE_IPL_LIST[value].ipl;

                        Database.UpdateHouse(house);
                        sendAdminInformation(player.Name + " hat den Hausmarker " + RageAPI.GetHexColorcode(0,200,255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255,255,255) + "Interior zu " + value + " geändert! ");
                        logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "]" + " hat den Hausmarker [ID: " + house.id + "] Interior zu " + value + " geändert! ");
                    }
                    else
                    {
                        //string message = string.Format(Messages.ERR_HOUSE_INTERIOR_MODIFY, Constants.HOUSE_IPL_LIST.Count - 1);
                        //player.SendChatMessage(Constants.Rgba_ERROR + message);
                    }
                }
                else if (e == "preis")
                {
                    house.price = value;
                    house.status = Constants.HOUSE_STATE_BUYABLE;
                    //house.houseLabel.Text = House.GetHouseLabelText(house);

                    Database.UpdateHouse(house);
                    sendAdminInformation(player.Name + " hat den Hausmarker " + RageAPI.GetHexColorcode(0,200,255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255,255,255) + "Preis zu " + value + " geändert! ");
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" +player.Name + "]" + " hat den Hausmarker [ID: " + house.id + "] Preis zu " + value + " geändert! ");
                }
            }
        }


        [Command("sethunger")]
        public static void SetPlayerAdminHunger(IPlayer player, IPlayer target, int value)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
            {
                Core.VnX.vnxSetSharedData(target, EntityData.PLAYER_HUNGER, value);
                player.SendChatMessage("Du hast" + target.Name + " Hunger Level auf : " + value + " gesetzt!");
            }
        }

        [Command("createforumuser")]
        public static void CreateForumUser_Admin_CMD(IPlayer player, string Name, string email, string passwort)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
            {
                _ = Program.CreateForumUser(Name, email, passwort);
                player.SendChatMessage("Du hast einen Forum account namens : " + Name + " erstellt!");
            }
        }

        /*[Command("healp")]
        public static void HealPlayerForSomeReason(IPlayer player, IPlayer target, string value, int valuea)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
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
        public static void ChangeSkin(IPlayer player, int slot, int drawable, int texture)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //ToDo Sie Clientseitig Laden! : player.SetClothes(slot, drawable, texture);
            }
        }

        [Command("aprop")]
        public static void ChangeProp(IPlayer player, int slot, int drawable, int texture)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                //ToDo Sie Clientseitig Laden! :NAPI.Player.SetPlayerAccessory(player, slot, drawable, texture);
            }
        }

        [Command("changecar")]
        public static void ChangeCarModel(IPlayer player, string modelName)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                // Obtain occupied IVehicle
                IVehicle veh = player.Vehicle;
                if (veh != null)
                {
                    // Update the IVehicle's position into the database
                    Database.UpdateIVehicleSingleString("model", modelName, veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast das Fahrzeug geändert zu : " + modelName);
                }
            }
        }

       /* [Command("createtestcar")]
        public static void CreateCar(IPlayer player, string VehicleModel)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    anzeigen.Usefull.VnX.CreateRandomIVehicle(player, NAPI.Util.IVehicleNameToModel(VehicleModel), new Position(player.Position.X + 2, player.Position.Y, player.Position.Z), 0, new Rgba(255, 255, 255), new Rgba(255, 255, 255), true, false, Constants.JOB_NONE, "TESTCAR");
                }
            }
            catch { }
        }*/

        [Command("createIVehicle")]
        public static void CreatePermanentIVehicle(IPlayer player, string VehicleModel, string IVehicleOwner, int FID, int R, int G, int B, int R2, int G2, int B2, int IVehiclePreis, float IVehicleLiter)
        {
            try
            {
                if(R > 255 || G > 255 || B > 255 || R2 > 255 || G2 > 255 || B2 > 255)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Primary & Sec. Rgba darf nicht über 255 sein!");
                    return;
                }
                else if(R < 0 || G < 0 || B < 0 || R2 < 0 || G2 < 0 || B2 < 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Primary & Sec. Rgba darf nicht unter 0 sein!");
                    return;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_MODERATOR)
                {
                    VehicleModel IVehicle = new VehicleModel();
                    // Basic data for IVehicle creation
                    IVehicle.model = VehicleModel;
                    IVehicle.faction = FID;
                    IVehicle.position = player.Position;
                    IVehicle.rotation = player.Rotation;
                    IVehicle.dimension = player.Dimension;
                    IVehicle.RgbaType = Constants.VEHICLE_Rgba_TYPE_CUSTOM;
                    IVehicle.firstRgba = R + "," + G +","+ B;
                    IVehicle.secondRgba = R2 + "," + G2 + "," + B2;
                    IVehicle.pearlescent = 0;
                    IVehicle.owner = IVehicleOwner;
                    IVehicle.plate = string.Empty;
                    IVehicle.price = IVehiclePreis;
                    IVehicle.parking = 0;
                    IVehicle.parked = 0;
                    IVehicle.gas = IVehicleLiter;
                    IVehicle.kms = 0.0f;

                    // Create the IVehicle
                   Vehicles.Vehicles.CreateVehicle(player, IVehicle, true);
                }
            }
            catch { }
        }




        // DrugsMichaelAliensFightIn == Sollten wir verwenden für drogen system ^^
    }
}
