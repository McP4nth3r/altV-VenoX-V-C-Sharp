﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV.Anti_Cheat;
using VenoXV.Core;
using VenoXV.Reallife.character;
using VenoXV.Reallife.database;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.house;
using VenoXV.Reallife.model;
using VenoXV.Reallife.vnx_stored_files;
using VenoXV.Reallife.Woltlab;

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
                        admin.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[Info] : " + RageAPI.GetHexColorcode(255, 255, 255) + text);
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

        public static int TestCounter = 0;
        [Command("tpaltv")]
        public static void TeleportPlayerToBullshitCoords(IPlayer player)
        {
            foreach (IPlayer players in Alt.GetAllPlayers())
            {
                players.RemoveAllWeapons();
                switch (TestCounter)
                {
                    case 0:
                        players.Position = new Vector3(-1000.9978f, -3408.6858f, 13.828613f);
                        players.SetPlayerSkin(Alt.Hash("csb_mweather"));
                        players.Dimension = -10;
                        Alt.Server.TriggerClientEvent(players, "FreezePlayerPLAYER_VnX", true);
                        break;
                    case 1:
                        players.Position = new Vector3(473.44617f, 6596.136f, 24.713501f);
                        players.SetPlayerSkin(Alt.Hash("ig_claypain"));
                        Alt.Server.TriggerClientEvent(players, "FreezePlayerPLAYER_VnX", true);
                        players.Dimension = -10;
                        break;
                }
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.HeavyRevolver, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.PumpShotgun, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.SMG, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.CombatPDW, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.CarbineRifle, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.AssaultRifle, 800);
                RageAPI.GivePlayerWeapon(players, AltV.Net.Enums.WeaponModel.Musket, 800);
                players.Health = 200;
                players.Armor = 100;
                players.Emit("LoadTacticUI", "test", "Test2", 255, 255, 0, 200, 0, 200);
                players.Emit("Tactics:LoadTimer", (int)180);
                //float DamageDone = players.vnxGetElementData<float>(EntityData.PLAYER_DAMAGE_DONE);
                //int KillsDone = players.vnxGetElementData<int>(EntityData.PLAYER_KILLED_PLAYERS);
                //Debug.OutputDebugString("Damage Done : " + DamageDone); 
                //Debug.OutputDebugString("Kills Done : " + KillsDone); 
                //players.Emit("Tactics:UpdatePlayerStats", DamageDone, KillsDone);
                //SyncTime();
                //SyncPlayerStats();
                //SyncStats();
            }
            if (TestCounter == 0) { TestCounter++; }
            else { TestCounter--; }
        }

        [Command("admins")]
        public void AdminsIngameCommand(IPlayer player)
        {
            try
            {
                //foreach (string target_namesingame in Alt.GetAllPlayers())
                player.SendChatMessage("---------------------------------------------------------");
                player.SendChatMessage("Folgende Admins sind grade Online : ");
                foreach (IPlayer targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK)))
                {
                    string targetsname = Core.RageAPI.GetVnXName<bool>(targetsingame);
                    if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                    {
                        if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 7)
                        {
                            player.SendChatMessage("{B40000}[VnX]" + targetsingame.Name + ", Projektleitung");
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
        public static void KickPlayer(IPlayer player, string target_name, string reason)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
                {
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + target.GetVnXName<string>() + " wurde von " + player.GetVnXName<string>() + " gekickt! Grund : " + reason);
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + target.SocialClubId + "][" + target.GetVnXName<string>() + "] gekickt! Grund : " + reason);
                    target.Kick("~r~Grund : ~h~" + reason);
                }
            }
            catch { }
        }

        [Command("achat", true)]
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
                            targetsingame.SendChatMessage("{{ ACHAT {B40000}Projektleitung " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Projektleitung " + player.GetVnXName<string>() + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 6)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {EC0000}Stellv.Projektleitung " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Stellv.Projektleitung " + player.GetVnXName<string>() + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 5)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {E8AE00}Administrator " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Administrator " + player.GetVnXName<string>() + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 4)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {002DE0}Moderator " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Moderator " + player.GetVnXName<string>() + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 3)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {006600}Supporter " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Supporter " + player.GetVnXName<string>() + ": " + message + " }} ");
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 2)
                        {
                            targetsingame.SendChatMessage("{{ ACHAT {C800C8}Ticket-Supporter " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " }} ");
                            logfile.WriteLogs("admin", "{{ ACHAT Ticket-Supporter " + player.GetVnXName<string>() + ": " + message + " }} ");
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
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_ADMIN_ON_DUTY, 1);

                        // Weapon Ban Fix 
                        player.RemoveAllWeapons();

                        RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " ist nun Admin - Duty.");
                    }
                    else
                    {
                        // Remove 
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_ADMIN_ON_DUTY, 0);

                        // Restore old skin
                        int sqlid = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        PlayerModel character = Database.LoadCharacterInformationById(sqlid);
                        SkinModel skinModel = Database.GetCharacterSkin(sqlid);
                        if (character != null && character.realName != null)
                        {
                            //ToDo : Fix & find another Way! player.GetVnXName<string>() = character.realName;
                            player.vnxSetElementData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                            player.SpawnPlayer(player.Position);
                            player.SetPlayerSkin(character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01"));
                            Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                            Customization.ApplyPlayerClothes(player);
                            Customization.ApplyPlayerTattoos(player);

                            // Weapon ban Fix
                            weapons.Weapons.GivePlayerWeaponItems(player);
                            RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " ist nun nicht mehr im Admin - Duty.");

                        }
                    }
                }
                else { dxLibary.VnX.DrawNotification(player, "error", "Seit wann bist du ein VenoX Mitglied?"); }
            }
            catch { }
        }

        [Command("goto", true)]
        public void TpCommand(IPlayer player, string target_name)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                // We get the player from the input string
                if (target != null)
                {
                    // Change player's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                    player.Position = target.Position;
                    player.Dimension = target.Dimension;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast dich zu " + RageAPI.GetHexColorcode(0, 200, 255) + target.GetVnXName<string>() + " " + RageAPI.GetHexColorcode(255, 255, 255) + "teleportiert!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VnX]" + player.GetVnXName<string>() + " " + RageAPI.GetHexColorcode(255, 255, 255) + "hat sich zu dir teleportiert!");
                    logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat sich zu " + target.GetVnXName<string>() + " geportet!");
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255, 255, 255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("gethere", true)]
        public void BringCommand(IPlayer player, string target_name)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                if (target != null)
                {
                    // Change target's position and dimension
                    AntiCheat_Allround.SetTimeOutTeleport(target, 2000);
                    target.Position = player.Position;
                    target.Dimension = player.Dimension;
                    player.SendChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + target.GetVnXName<string>() + " " + RageAPI.GetHexColorcode(255, 255, 255) + " zu dir teleportiert!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VnX]" + player.GetVnXName<string>() + " " + RageAPI.GetHexColorcode(255, 255, 255) + "hat dich zu ihm teleportiert!");
                    logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zu sich geportet!");
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "[Admin - Info]" + RageAPI.GetHexColorcode(255, 255, 255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("charakter")]
        public void CharacterCommand(IPlayer player, string action, string target_name, string amount)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
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
                                        target.vnxSetElementData(EntityData.PLAYER_BANK, value);
                                        player.SendChatMessage("~g~Du hast das Bankgeld von " + target.GetVnXName<string>() + " auf : " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.GetVnXName<string>() + " hat das Bankgeld von " + target.GetVnXName<string>() + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_STELLVP)
                                    {
                                        target.vnxSetElementData(EntityData.PLAYER_MONEY, value);
                                        player.SendChatMessage("~g~Du hast das Bargeld von " + target.GetVnXName<string>() + " auf : " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat dein Bargeld auf : " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.GetVnXName<string>() + " hat das Bargeld von " + target.GetVnXName<string>() + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "dimension":
                                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
                                    {
                                        target.Dimension = value;
                                        player.SendChatMessage("~g~Du hast " + target.GetVnXName<string>() + " Dimension auf " + value + " gesetzt!");
                                        target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat deine Dimension auf :  " + value + " gesetzt!");
                                        logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " in die Dimension " + value + " verschoben!");

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
        public static void GetAdminDimension(IPlayer player, string target_name)
        {
            IPlayer target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                player.SendChatMessage(target.GetVnXName<string>() + " hat dimension : " + target.Dimension);
            }
        }


        [Command("revive")]
        public void ReviveCommand(IPlayer player, string target_name)
        {
            IPlayer Target = Core.RageAPI.GetPlayerFromName(target_name);
            if (Target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_SUPPORTER)
            {
                if (Target != null)
                {
                    if (Target.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                    {
                        AntiCheat_Allround.SetTimeOutHealth(Target, 1000);
                        Target.Spawn(Target.Position);
                        Target.vnxSetStreamSharedElementData(EntityData.PLAYER_KILLED, 0);
                        player.SendChatMessage("~g~Du hast " + Target.GetVnXName<string>() + " wiederbelebt.");
                        Target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat dich wiederbelebt.");
                        logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat " + Target.GetVnXName<string>() + " wiederbelebt!");
                        Target.Emit("destroyKrankenhausTimer");
                        Target.Emit("VnX_DestroyIPlayerSideTimer_KH");
                        foreach (IPlayer medics in Alt.GetAllPlayers())
                        {
                            if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                            {
                                medics.Emit("Destroy_MedicBlips", Target.GetVnXName<string>());
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
                        IPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);
                        if (Database.FindCharakterPrison(SpielerName))
                        {
                            int PrisonTime = Database.GetCharakterPrisonTime(SpielerName);
                            Database.UpdatePlayerPrisonTime(UID, PrisonTime + zeit, grund, player.GetVnXName<string>(), DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerToPrison(UID, SpielerName, zeit, grund, player.GetVnXName<string>(), DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = 0;
                            targetplayer.Position = new Position(1651.441f, 2569.83f, 45.56486f);
                            anzeigen.Usefull.VnX.RemoveAllWeapons(targetplayer);
                            targetplayer.vnxSetElementData(EntityData.PLAYER_PRISON_TIME, zeit);
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
                        IPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId.ToString()))
                        {
                            Accountbans ban = Database.GetAccountbans(SocialClubId.ToString());
                            if (ban.banzeit > DateTime.Now)
                            {
                                Database.UpdatePlayerTimeBan(UID, grund, player.GetVnXName<string>(), ban.banzeit.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                            else
                            {
                                Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund, player.GetVnXName<string>(), DateTime.Now.AddHours(zeit), DateTime.Now);
                                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " für " + zeit + " Stunden gebannt! Grund : " + grund);
                            }
                        }
                        else
                        {
                            Database.AddPlayerTimeBan(UID, SocialClubId, SpielerSerial, grund, player.GetVnXName<string>(), DateTime.Now.AddHours(zeit), DateTime.Now);
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] für " + zeit + " Stunden gebannt! Grund : " + grund);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " für " + zeit + " Stunden gebannt! Grund : " + grund);
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
        public void ReconCommand(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
                {
                    //anzeigen.Usefull.VnX.SpectatePlayer(player, target, 0);
                    sendAdminInformation(player.GetVnXName<string>() + " spectatet grade " + target.GetVnXName<string>() + "!");
                }
            }
            catch { }
        }

        [Command("specoff")]
        public void RecoffCommand(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_SUPPORTER)
            {
                //anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                sendAdminInformation(player.GetVnXName<string>() + " hat aufgehört " + player.GetVnXName<string>() + " zu spectaten!");
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
                    RageAPI.SendChatMessageToAll(" ");
                }
                vnx_stored_files.logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat den Chat gecleared!");
            }
        }

        [Command("adstate")]
        public static void SetAdState(IPlayer player, string Werbungjaodernein)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_MODERATOR)
            {
                Werbungjaodernein = Werbungjaodernein.ToLower();
                string state = RageAPI.GetHexColorcode(0, 175, 0) + "angeschaltet!";
                if (Werbungjaodernein == "nein")
                {
                    state = RageAPI.GetHexColorcode(175, 0, 0) + "ausgeschaltet!";
                }
                else if (Werbungjaodernein == "ja")
                {
                    RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat das AD-System " + state);
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Status muss JA oder NEIN sein!");
                }
            }
        }

        [Command("ochat", true)]
        public void OchatCommand(IPlayer player, string message)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) > Constants.ADMINLVL_NONE)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 7)
                    {
                        RageAPI.SendChatMessageToAll("(( {B40000}Projektleitung " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Projektleitung " + player.GetVnXName<string>() + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 6)
                    {
                        RageAPI.SendChatMessageToAll("(( {EC0000}Stellv.Projektleitung " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Stellv.Projektleitung " + player.GetVnXName<string>() + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 5)
                    {
                        RageAPI.SendChatMessageToAll("(( {E8AE00}Administrator " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Administrator " + player.GetVnXName<string>() + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 4)
                    {
                        RageAPI.SendChatMessageToAll("(( {002DE0}Moderator " + player.GetVnXName<string>() + ": {FFFFFF}" + message + " )) ");
                        logfile.WriteLogs("admin", "{{ OCHAT Moderator " + player.GetVnXName<string>() + ": " + message + " }} ");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 3)
                    {
                        player.SendChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.GetVnXName<string>() + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Supporter " + player.GetVnXName<string>() + " versuchte Nachricht : " + message + " }}");
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) == 2)
                    {
                        player.SendChatMessage("{FF0000}Du bist nicht Befugt!");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.GetVnXName<string>() + " hat versucht in dem O - Chat zu schreiben! }} ");
                        logfile.WriteLogs("admin", "{{ OCHAT Ticket - Supporter " + player.GetVnXName<string>() + " versuchte Nachricht : " + message + " }}");
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
                    IPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
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
                        targetplayer.vnxSetElementData(EntityData.PLAYER_PRISON_TIME, 0);
                        targetplayer.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nun aus dem Prison.... Verhalte dich in Zukunft besser!");
                        Spawn.spawnplayer_on_spawnpoint(targetplayer);
                    }
                }
            }

        }



        [Command("permaban", true)]
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
                        IPlayer targetplayer = RageAPI.GetPlayerFromName(SpielerName);
                        int UID = Database.GetCharakterUID(SpielerName);

                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund, player.GetVnXName<string>());
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " permanent gebannt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerPermaBan(UID, SocialClubId, SpielerSerial, grund, player.GetVnXName<string>());
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] permanent gebannt! Grund : " + grund);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.GetVnXName<string>() + " permanent gebannt! Grund : " + grund);
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



        [Command("updateinventar")]
        public static void UpdateTargetInventar(IPlayer player, string target_name)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }

            List<InventoryModel> inventory = Reallife.anzeigen.Inventar.Main.GetPlayerInventory(target);
            target.Emit("Inventory:Update", JsonConvert.SerializeObject(inventory));
        }

        [Command("clearinventar")]
        public static void ClearTargetPlayerInventar(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    int targetId = target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                    if (targetId > 0)
                    {
                        foreach (ItemModel item in anzeigen.Inventar.Main.CurrentOnlineItemList.ToList())
                        {
                            if (item.ownerIdentifier == targetId)
                            {
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(item);
                            }
                        }
                        player.RemoveAllWeapons();
                        Database.RemoveAllItems(targetId);
                    }
                    player.SendChatMessage("Du hast das Inventar von " + target.GetVnXName<string>() + " geleert!");
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
                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.vnxSetElementData(EntityData.PLAYER_BUSINESS_ENTERED, 0);
            }
        }

        [Command("pos")]
        public void PosCommand(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                Console.WriteLine("Position : " + player.Position);
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "  Rot : " + RageAPI.GetHexColorcode(255, 255, 255) + player.Rotation);
                player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "  POS X :" + player.Position.X + " | POS Y : " + player.Position.Y + " | POS Z : " + player.Position.Z);
            }
        }

        [Command("sstate")]
        public static void SetSocialStatePlayer(IPlayer player, string target_name, string element)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.vnxSetElementData(EntityData.PLAYER_STATUS, element);
                target.SetStreamSyncedMetaData(EntityData.PLAYER_STATUS, element);
                sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " Sozialen Status geändert zu " + element + ".");
                logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " sozialen status auf " + element + " geändert!");
            }
        }


        [Command("triggersound")]
        public static void TriggerSoundEffect(IPlayer player, string target_name, string SoundName, string SoundSetName)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("VnX_Play_Sound", SoundName, SoundSetName);
            }
        }

        [Command("triggermp3")]
        public static void Triggeraudio(IPlayer player, string target_name, string audioclass)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("load_audio_table_vnx", audioclass);
            }
        }

        [Command("triggerfx")]
        public static void Triggerfx(IPlayer player, string target_name, string effect, int duration, bool loop)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("start_screen_fx", effect, duration, loop);
            }
        }

        [Command("stopfx")]
        public static void StopfxAdmin(IPlayer player, string target_name, string effect)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                target.Emit("stop_screen_fx", effect);
            }
        }

        [Command("setpremium")]
        public static void GivePremiumToPlayer(IPlayer player, string target_name, int PaketNr, int Tage)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (PaketNr == 0)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Abgelaufen", 0);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "-");
                }
                else if (PaketNr == 1)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Bronze", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Bronze");
                }
                else if (PaketNr == 2)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Silber", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Silber");
                }
                else if (PaketNr == 3)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Gold", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Gold");
                }
                else if (PaketNr == 4)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "UltimateRed", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "UltimateRed");
                }
                else if (PaketNr == 5)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "Platin", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "Platin");
                }
                else if (PaketNr == 6)
                {
                    Database.SetVIPStats((int)target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), "TOP DONATOR", Tage);
                    sendAdminNotification(player.GetVnXName<string>() + " hat das VIP Level von " + target.GetVnXName<string>() + " auf " + PaketNr + " geändert! (" + Tage + " Tage)");
                    target.vnxSetElementData(EntityData.PLAYER_VIP_LEVEL, "TOP DONATOR");
                }
                else
                {
                    player.SendChatMessage("Ungültige Paket Nummer! ( 0 - 6 )");
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
                    foreach (IPlayer players in Alt.GetAllPlayers())
                    {
                        players.SetWeather((AltV.Net.Enums.WeatherType)weather);
                    }
                    RageAPI.SendChatMessageToAll(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat das Wetter zu " + weather + " gewechselt!");
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
                        int UID = Database.GetCharakterUID(SpielerName);
                        if (Database.FindCharacterBan(SocialClubId))
                        {
                            Database.RemoveOldBan(SocialClubId);
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde entbannt.");
                            logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat [" + SocialClubId + "][" + SpielerName + "] entbannt!");
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
                    if (action == "despawn")
                    {
                        Vehicle.Dimension = Constants.VEHICLE_OFFLINE_DIM;
                        player.SendChatMessage("Erfolgreich despawned!");
                    }
                    else if (action == "gethere")
                    {
                        Vehicle.Position = player.Position;
                        player.SendChatMessage("Fahrzeug Erfolgreich geholt!");
                    }
                    else if (action == "goto")
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
                    sendAdminInformation(player.GetVnXName<string>() + " hat alle Fahrzeuge in seiner Nähe despawned!");
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
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 200, 200) + "[VnX]" + player.GetVnXName<string>() + " hat alle Aktionen Resettet!");
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
                Core.RageAPI.CreateTextLabel(House.GetHouseLabelText(house), house.position, 35.0f, 0.75f, 4, new int[] { 255, 255, 255, 255 });
                House.houseList.Add(house);

                sendAdminInformation(player.GetVnXName<string>() + " hat einen Hausmarker erstellt! " + RageAPI.GetHexColorcode(0, 200, 255) + " [" + RageAPI.GetHexColorcode(255, 255, 255) + +house.id + RageAPI.GetHexColorcode(0, 200, 255) + " ]" + "[" + RageAPI.GetHexColorcode(255, 255, 255) + +preis + RageAPI.GetHexColorcode(0, 200, 255) + "  $]" + "[" + RageAPI.GetHexColorcode(255, 255, 255) + +interior + RageAPI.GetHexColorcode(0, 200, 255) + " ]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat einen Hausmarker erstellt! [ID : " + house.id + "]" + "[ PREIS : " + preis + " $]" + "[INTERIOR : " + interior + "]");

            }
            else
            {
                player.SendChatMessage(Constants.Rgba_ERROR + "Du bist nicht Befugt!");
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
                sendAdminInformation(player.GetVnXName<string>() + " hat einen Hausmarker gelöscht! " + RageAPI.GetHexColorcode(0, 200, 255) + " [" + RageAPI.GetHexColorcode(255, 255, 255) + +house.id + "]");
                logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "] hat einen Hausmarker Gelöscht! ID : " + house.id);
            }
            else
            {
                player.SendChatMessage(Constants.Rgba_ERROR + "Du bist nicht Befugt!");
            }
        }


        [Command("makeleader")]
        public void MakeLeader_AdminFunc(IPlayer player, string target_name, int faction)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (faction > 13 || faction < 0)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Fraktions ID nur zwischen 0-13 möglich!");
                        return;
                    }
                    if (faction == 0)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Bürger gemacht.");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 1)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du wurdest soeben zum Chief of Police ernannt! Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 2)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Don der La Cosa Nostra von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 3)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Yakuza von Venox City - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 4)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [GESPERRT ] Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 5)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Chefredakteur der Venox City News - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 6)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Direktor des Federal Investigation Bureau - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 7)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Boss der Venox City Vatos Locos - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 8)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Commander der Venox U.S Army - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 9)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der President der SAMCRO Redwoods Original´s - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 10)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader der Venox Medic's - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 11)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun der Leader von den Venox City Mechaniker - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 12)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Du bist nun der Banger der Venox City Ballas - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    else if (faction == 13)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Du bist nun Leader der Venox City Grove Street - Für mehr Infos öffne das Hilfemenue!");
                        sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                    }
                    target.vnxSetStreamSharedElementData(EntityData.PLAYER_FACTION, faction);
                    target.vnxSetElementData(EntityData.PLAYER_RANK, 5);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " zum Leader von Fraktion " + faction + " gemacht!");
                }
            }
            catch
            {
            }
        }

        [Command("setrank")]
        public void setUserRank(IPlayer player, string target_name, int rank)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Der Spieler " + target.GetVnXName<string>() + " ist in keiner Fraktion!");
                }
                if (rank > 5 || rank < 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Fraktions Rang nur zwischen 0-5 möglich!");
                    return;
                }
                else
                {
                    target.vnxSetElementData(EntityData.PLAYER_RANK, rank);
                    anzeigen.Usefull.VnX.OnFactionChange(target);
                    target.SendChatMessage(Constants.Rgba_ADMIN_CLANTAG + player.GetVnXName<string>() + " hat deinen Fraktion´s rang auf " + rank + " geändert!");
                    sendAdminNotification(player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " Franktion´s Rang auf " + rank + " geändert!");
                    logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " Franktion´s Rang auf " + rank + " geändert!");
                }
            }
        }

        [Command("getIVehicleinfo", true)]
        public static void GiveAdminWeapons(IPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                if (player.Vehicle != null)
                {
                    player.SendChatMessage("Info : " + player.Vehicle.Model);
                }
            }
        }


        [Command("giveweapon", true)]
        public static void GiveAdminWeapons(IPlayer player, string weapon)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                if (weapon == "mp5")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_MP5, Constants.ITEM_ART_WAFFE, 200, true);
                }
                else if (weapon == "m4")
                {
                    Main.GivePlayerItem(player, Constants.ITEM_HASH_KARABINER, Constants.ITEM_ART_WAFFE, 200, true);

                }
                vnx_stored_files.logfile.WriteLogs("admin", player.GetVnXName<string>() + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
                Admin.sendAdminNotification(player.GetVnXName<string>() + " hat sich eine " + weapon + " mit 90 Schuss gegeben!");
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
                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Der laufende Gangwar wurde gestoppt!");
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
        public static void GetAdminSerial(IPlayer player, string target_name)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
            {
                player.SendChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + target.GetVnXName<string>() + " hat serial : " + target.HardwareIdHash);
            }
        }



        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        /////////////////////////////////////////////////STELLV.PROJEKTLEITUNG/////////////////////////////////////////////////
        [Command("vnxgetelementdata")]
        public static void GetElementDataAdmin(IPlayer player, string target_name, string element)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
            {
                player.SendChatMessage("[vnxGetElementData(" + element + ") = " + target.vnxGetElementData<object>(element));
                player.SendChatMessage(target.GetVnXName<string>());
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
                    player.SendChatMessage(Constants.Rgba_ERROR + "Du bist an keinem Haus!");
                    return;
                }

                if (e == "interior")
                {
                    if (value >= 0 && value < Constants.HOUSE_IPL_LIST.Count)
                    {
                        house.ipl = Constants.HOUSE_IPL_LIST[value].ipl;

                        Database.UpdateHouse(house);
                        sendAdminInformation(player.GetVnXName<string>() + " hat den Hausmarker " + RageAPI.GetHexColorcode(0, 200, 255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255, 255, 255) + "Interior zu " + value + " geändert! ");
                        logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "]" + " hat den Hausmarker [ID: " + house.id + "] Interior zu " + value + " geändert! ");
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
                    sendAdminInformation(player.GetVnXName<string>() + " hat den Hausmarker " + RageAPI.GetHexColorcode(0, 200, 255) + " [ID : " + house.id + "] " + RageAPI.GetHexColorcode(255, 255, 255) + "Preis zu " + value + " geändert! ");
                    logfile.WriteLogs("admin", "[" + player.SocialClubId.ToString() + "][" + player.GetVnXName<string>() + "]" + " hat den Hausmarker [ID: " + house.id + "] Preis zu " + value + " geändert! ");
                }
            }
        }


        [Command("sethunger")]
        public static void SetPlayerAdminHunger(IPlayer player, string target_name, int value)
        {
            IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_STELLVP)
            {
                target.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, value);
                player.SendChatMessage("Du hast" + target.GetVnXName<string>() + " Hunger Level auf : " + value + " gesetzt!");
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
        public static void HealPlayerForSomeReason(IPlayer player, string target_name, string value, int valuea)
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

        [Command("giveweapons")]
        public static void GiveTestWeapons(IPlayer player)
        {
            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.BullpupRifleMkII, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.BullpupRifleMkII, 2);

            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Pistol50, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.Pistol50, 3);

            RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AssaultRifle, 200);
            player.SetWeaponTintIndex(AltV.Net.Enums.WeaponModel.AssaultRifle, 2);
        }

        [Command("createvehicle")]
        public static void CreatePermanentIVehicle(IPlayer player, string VehicleModel, string IVehicleOwner, int FID, int R, int G, int B, int R2, int G2, int B2, int IVehiclePreis, float IVehicleLiter)
        {
            try
            {
                if (R > 255 || G > 255 || B > 255 || R2 > 255 || G2 > 255 || B2 > 255)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Primary & Sec. Rgba darf nicht über 255 sein!");
                    return;
                }
                else if (R < 0 || G < 0 || B < 0 || R2 < 0 || G2 < 0 || B2 < 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Primary & Sec. Rgba darf nicht unter 0 sein!");
                    return;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_TSUPPORTER)
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
