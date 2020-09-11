﻿//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Chat;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.factions.State.LSPD;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Police : IScript
    {



        [Command("zeigen")]
        public static void ShowToPlayerLicense(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string Lizenzen = "";
                    if (player.Reallife.Autofuehrerschein == 1) { Lizenzen += Lizenzen + " Führerschein  [ ✔ ]"; }
                    else { Lizenzen += " Führerschein  [ ✘ ]"; }

                    if (player.Reallife.Motorradfuehrerschein == 1) { Lizenzen += Lizenzen + " Motorradschein  [ ✔ ]"; }
                    else { Lizenzen += " Motorradschein  [ ✘ ]"; }

                    if (player.Reallife.LKWfuehrerschein == 1) { Lizenzen += Lizenzen + " LKW-Führerschein  [ ✔ ]"; }
                    else { Lizenzen += " LKW-Führerschein  [ ✘ ]"; }

                    if (player.Reallife.Waffenschein == 1) { Lizenzen += Lizenzen + " Waffenschein  [ ✔ ]"; }
                    else { Lizenzen += " Waffenschein  [ ✘ ]"; }

                    if (player.Reallife.Motorbootschein == 1) { Lizenzen += Lizenzen + " Bootsführerschein  [ ✔ ]"; }
                    else { Lizenzen += " Bootsführerschein  [ ✘ ]"; }

                    if (player.Reallife.FlugscheinKlasseA == 1) { Lizenzen += Lizenzen + " Flugschein A  [ ✔ ]"; }
                    else { Lizenzen += " Flugschein A  [ ✘ ]"; }

                    if (player.Reallife.FlugscheinKlasseB == 1) { Lizenzen += Lizenzen + " Flugschein B  [ ✔ ]"; }
                    else { Lizenzen += Lizenzen + " Flugschein B  [ ✘ ]"; }

                    if (player.Reallife.Helikopterfuehrerschein == 1) { Lizenzen = Lizenzen + " Helikopterschein  [ ✔ ]"; }
                    else { Lizenzen += " Helikopterschein  [ ✘ ]"; }

                    if (player.Reallife.Angelschein == 1) { Lizenzen += " Angelschein  [ ✔ ]"; }
                    else { Lizenzen += Lizenzen + " Angelschein  [ ✘ ]"; }

                    player.SendReallifeMessage("Du hast " + target.Username + " deine Lizenzen gezeigt!");
                    target.SendReallifeMessage(RageAPI.GetHexColorcode(200, 0, 200) + "Vorhandene Lizenzen von " + player.Username + " : " + RageAPI.GetHexColorcode(200, 200, 0) + " Lizenzen");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                }
            }
            catch { }
        }


        [Command("frisk")]
        public static void FriskPlayer(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_MATS);
                    int kokain = 0;
                    int mats = 0;
                    int weed = 0;
                    if (KOKS != null)
                    {
                        kokain = KOKS.amount;
                    }
                    if (WEED != null)
                    {
                        weed = WEED.amount;
                    }
                    if (MATS != null)
                    {
                        mats = MATS.amount;
                    }

                    player.SendTranslatedChatMessage(inventory + "Materials: " + mats + " Stk, Kokain: " + kokain + "g , Drogen: " + weed + "g");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " hat dich durchsucht!");
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                }
            }
            catch
            {
            }
        }

        [Command("takeillegal")]
        public static void Takeillegal(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                    {
                        if (player.Position.Distance(target.Position) < 5)
                        {
                            string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                            ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_KOKS);
                            ItemModel WEED = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_WEED);
                            ItemModel MATS = Main.GetPlayerItemModelFromHash(target.UID, Constants.ITEM_HASH_MATS);
                            if (KOKS != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(KOKS.id);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(KOKS);
                            }
                            if (WEED != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(WEED.id);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(WEED);
                            }
                            if (MATS != null)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(MATS.id);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(MATS);
                            }

                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.Username + " hat dir deine Illegalen Gegenstaende abgenommen!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Du hast " + target.Username + " seine Illegalen Gegenstaende abgenommen!");
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zu weit von " + target.Username + " entfernt!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht im Dienst!!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Staatsfraktionist!");
                }
            }
            catch
            {
            }
        }

        [ClientEvent("Reallife:OnPoliceWeaponSelect")]
        public static void GivePlayerStateFactionWeapon(VnXPlayer player, string Button)
        {
            if (!Allround.isStateFaction(player)) { return; }
            FactionAllroundModel fweapon = new FactionAllroundModel();
            foreach (FactionAllroundModel fClass in Main.FactionAllroundList) { if (fClass.FID == Constants.FACTION_LSPD) { fweapon = fClass; } }
            if (fweapon.FID == 0) { return; }
            switch (Button)
            {
                case "Schlagstock":
                    ItemModel SCHLAGSTOCK = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_NIGHTSTICK);
                    if (SCHLAGSTOCK != null) { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Schlagstock!"); return; }
                    if (fweapon.Waffenlager.weapon_nightstick > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_NIGHTSTICK, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat einen Schlagstock vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Tazer":
                    ItemModel Item = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_TAZER);
                    if (Item != null) { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Tazer!"); return; }
                    if (fweapon.Waffenlager.weapon_tazer > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_TAZER, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat einen Tazer vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Pistol":
                    ItemModel Pistol = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_PISTOLE);
                    if (Pistol != null)
                    {
                        if (fweapon.Waffenlager.weapon_pistol_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Pistolen Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_pistol > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Pistole vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Pistol50":
                    ItemModel Pistol50 = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_PISTOLE50);
                    if (Pistol50 != null)
                    {
                        if (fweapon.Waffenlager.weapon_pistol50_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE50, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Pistol50 Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_pistol50 > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE50, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Pistol50 vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Shotgun":
                    ItemModel Shotgun = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_SHOTGUN);
                    if (Shotgun != null)
                    {
                        if (fweapon.Waffenlager.weapon_pumpshotgun_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_SHOTGUN, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Shotgun Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_pumpshotgun > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_SHOTGUN, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Shotgun vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "PDW":
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_PDW);
                    if (PDW != null)
                    {
                        if (fweapon.Waffenlager.weapon_mp5_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_PDW, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein PDW Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_mp5 > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_PDW, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine PDW vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Karabiner":
                    ItemModel Karabiner = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_KARABINER);
                    if (Karabiner != null)
                    {
                        if (fweapon.Waffenlager.weapon_carbinerifle_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_KARABINER, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Karabiner Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_carbinerifle > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_KARABINER, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Karabiner vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Rifle":
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_ADVANCEDRIFLE);
                    if (Rifle != null)
                    {
                        if (fweapon.Waffenlager.weapon_advancedrifle_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_ADVANCEDRIFLE, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Advancedrifle Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_advancedrifle > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_ADVANCEDRIFLE, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Advancedrifle vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
                case "Sniper":
                    ItemModel Sniper = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_SNIPERRIFLE);
                    if (Sniper != null)
                    {
                        if (fweapon.Waffenlager.weapon_sniperrifle_ammo > 0)
                        {
                            Main.GivePlayerItem(player, Constants.ITEM_HASH_SNIPERRIFLE, Constants.ITEM_ART_WAFFE, 1, true);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Sniper Magazin vom Lager genommen.");
                            return;
                        }
                        else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    }
                    if (fweapon.Waffenlager.weapon_sniperrifle > 0)
                    {
                        Main.GivePlayerItem(player, Constants.ITEM_HASH_SNIPERRIFLE, Constants.ITEM_ART_WAFFE, 1, false);
                        Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Sniper vom Lager genommen.");
                    }
                    else { player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!"); }
                    break;
            }
        }

        //[AltV.Net.ClientEvent("triggerBadWeaponWindowBtn_S")]
        public static void GivePlayerBadFactionWeapon(VnXPlayer player, string button)
        {
            try
            {
                if (Allround.isBadFaction(player))
                {
                    int playermoney = player.Reallife.Money;
                    int playerId = player.UID;

                    WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(player.Reallife.Faction);
                    //Waffen Datas = 

                    int weapon_knuckle = fweapon.weapon_knuckle;
                    int weapon_nightstick = fweapon.weapon_nightstick;
                    int weapon_baseball = fweapon.weapon_baseball;
                    int weapon_stungun = fweapon.weapon_tazer;
                    int weapon_pistol = fweapon.weapon_pistol;
                    int weapon_pistol50 = fweapon.weapon_pistol50;
                    int weapon_revolver = fweapon.weapon_revolver;
                    int weapon_pumpshotgun = fweapon.weapon_pumpshotgun;
                    int weapon_combatpdw = fweapon.weapon_combatpdw;
                    int weapon_mp5 = fweapon.weapon_mp5;
                    int weapon_mp5_ammo = fweapon.weapon_mp5_ammo;
                    int weapon_assaultrifle = fweapon.weapon_assaultrifle;
                    int weapon_carbinerifle = fweapon.weapon_carbinerifle;
                    int weapon_advancedrifle = fweapon.weapon_advancedrifle;
                    int weapon_gusenberg = fweapon.weapon_gusenberg;
                    int weapon_sniperrifle = fweapon.weapon_sniperrifle;
                    int weapon_rifle = fweapon.weapon_rifle;
                    int weapon_rpg = fweapon.weapon_rpg;
                    int weapon_bzgas = fweapon.weapon_bzgas;
                    int weapon_molotov = fweapon.weapon_molotov;
                    int weapon_smokegrenade = fweapon.weapon_smokegrenade;
                    int weapon_pistol_ammo = fweapon.weapon_pistol_ammo;
                    int weapon_pistol50_ammo = fweapon.weapon_pistol50_ammo;
                    int weapon_revolver_ammo = fweapon.weapon_revolver_ammo;
                    int weapon_pumpshotgun_ammo = fweapon.weapon_pumpshotgun_ammo;
                    int weapon_combatpdw_ammo = fweapon.weapon_combatpdw_ammo;
                    int weapon_assaultrifle_ammo = fweapon.weapon_assaultrifle_ammo;
                    int weapon_carbinerifle_ammo = fweapon.weapon_carbinerifle_ammo;
                    int weapon_advancedrifle_ammo = fweapon.weapon_advancedrifle_ammo;
                    int weapon_gusenberg_ammo = fweapon.weapon_gusenberg_ammo;
                    int weapon_sniperrifle_ammo = fweapon.weapon_sniperrifle_ammo;
                    int weapon_rifle_ammo = fweapon.weapon_rifle_ammo;
                    int weapon_rpg_ammo = fweapon.weapon_rpg_ammo;

                    ItemModel BASEBALL = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_BASEBALL);
                    ItemModel TAZER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);
                    ItemModel PISTOLE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                    ItemModel PISTOLE50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                    ItemModel REVOLVER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                    ItemModel MP5 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MP5);
                    ItemModel AK47 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_AK47);
                    ItemModel RIFLE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RIFLE);
                    ItemModel SNIPER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);
                    ItemModel RPG = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RPG);



                    if (button == "Baseball")
                    {
                        if (BASEBALL == null)
                        {
                            if (fweapon.weapon_baseball > 0)
                            {
                                BASEBALL = new ItemModel();
                                BASEBALL.amount = 0;
                                BASEBALL.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                BASEBALL.position = new Position(0.0f, 0.0f, 0.0f);
                                BASEBALL.hash = Constants.ITEM_HASH_BASEBALL;
                                BASEBALL.ownerIdentifier = playerId;
                                BASEBALL.ITEM_ART = "Waffe";
                                BASEBALL.objectHandle = null;
                                BASEBALL.id = Database.AddNewItem(BASEBALL);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(BASEBALL);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.BaseballBat, 0);
                                weapon_baseball = weapon_baseball - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat einen Baseball-Schläger vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Baseball-Schläger!");
                        }
                    }

                    if (button == "Pistol")
                    {
                        if (PISTOLE == null)
                        {
                            if (fweapon.weapon_pistol > 0)
                            {
                                PISTOLE = new ItemModel();
                                PISTOLE.amount = 0;
                                PISTOLE.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                PISTOLE.position = new Position(0.0f, 0.0f, 0.0f);
                                PISTOLE.hash = Constants.ITEM_HASH_PISTOLE;
                                PISTOLE.ownerIdentifier = playerId;
                                PISTOLE.ITEM_ART = "Waffe";
                                PISTOLE.objectHandle = null;

                                PISTOLE.id = Database.AddNewItem(PISTOLE);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PISTOLE);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Pistol, 0);
                                weapon_pistol = weapon_pistol - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Pistole vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (fweapon.weapon_pistol_ammo > 0)
                            {
                                if (PistolenMagazin == null)
                                {
                                    PistolenMagazin = new ItemModel();
                                    PistolenMagazin.amount = 12;
                                    PistolenMagazin.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                    PistolenMagazin.position = new Position(0.0f, 0.0f, 0.0f);
                                    PistolenMagazin.hash = Constants.ITEM_HASH_PISTOL_AMMO;
                                    PistolenMagazin.ownerIdentifier = playerId;
                                    PistolenMagazin.ITEM_ART = "Magazin";
                                    PistolenMagazin.objectHandle = null;


                                    PistolenMagazin.id = Database.AddNewItem(PistolenMagazin);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PistolenMagazin);
                                }
                                else
                                {
                                    PistolenMagazin.amount = PistolenMagazin.amount + 12;
                                    Database.UpdateItem(PistolenMagazin);
                                }
                                weapon_pistol_ammo = weapon_pistol_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol, PistolenMagazin.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Pistolen Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                    }

                    if (button == "Pistol50")
                    {
                        if (PISTOLE50 == null)
                        {
                            if (fweapon.weapon_pistol50 > 0)
                            {
                                PISTOLE50 = new ItemModel();
                                PISTOLE50.amount = 0;
                                PISTOLE50.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                PISTOLE50.position = new Position(0.0f, 0.0f, 0.0f);
                                PISTOLE50.hash = Constants.ITEM_HASH_PISTOLE50;
                                PISTOLE50.ownerIdentifier = playerId;
                                PISTOLE50.ITEM_ART = "Waffe";
                                PISTOLE50.objectHandle = null;

                                PISTOLE50.id = Database.AddNewItem(PISTOLE50);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PISTOLE50);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Pistol50, 0);
                                weapon_pistol50 = weapon_pistol50 - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Pistol50. vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (fweapon.weapon_pistol50_ammo > 0)
                            {
                                if (PistolenMagazin == null)
                                {
                                    PistolenMagazin = new ItemModel();
                                    PistolenMagazin.amount = 12;
                                    PistolenMagazin.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                    PistolenMagazin.position = new Position(0.0f, 0.0f, 0.0f);
                                    PistolenMagazin.hash = Constants.ITEM_HASH_PISTOL_AMMO;
                                    PistolenMagazin.ownerIdentifier = playerId;
                                    PistolenMagazin.ITEM_ART = "Magazin";
                                    PistolenMagazin.objectHandle = null;

                                    // Add the item into the database
                                    PistolenMagazin.id = Database.AddNewItem(PistolenMagazin);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PistolenMagazin);
                                }
                                else
                                {
                                    PistolenMagazin.amount = PistolenMagazin.amount + 12;
                                    Database.UpdateItem(PistolenMagazin);
                                }
                                weapon_pistol50_ammo = weapon_pistol50_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Pistol50, PistolenMagazin.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Pistol50. Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                    }
                    if (button == "Revolver")
                    {
                        if (REVOLVER == null)
                        {
                            if (fweapon.weapon_revolver > 0)
                            {
                                REVOLVER = new ItemModel();
                                REVOLVER.amount = 0;
                                REVOLVER.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                REVOLVER.position = new Position(0.0f, 0.0f, 0.0f);
                                REVOLVER.hash = Constants.ITEM_HASH_REVOLVER;
                                REVOLVER.ownerIdentifier = playerId;
                                REVOLVER.ITEM_ART = "Waffe";
                                REVOLVER.objectHandle = null;

                                REVOLVER.id = Database.AddNewItem(REVOLVER);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(REVOLVER);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.HeavyRevolver, 0);
                                weapon_revolver = weapon_revolver - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Revolver vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (fweapon.weapon_pistol50_ammo > 0)
                            {
                                if (PistolenMagazin == null)
                                {
                                    PistolenMagazin = new ItemModel();
                                    PistolenMagazin.amount = 12;
                                    PistolenMagazin.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                    PistolenMagazin.position = new Position(0.0f, 0.0f, 0.0f);
                                    PistolenMagazin.hash = Constants.ITEM_HASH_PISTOL_AMMO;
                                    PistolenMagazin.ownerIdentifier = playerId;
                                    PistolenMagazin.ITEM_ART = "Magazin";
                                    PistolenMagazin.objectHandle = null;

                                    // Add the item into the database
                                    PistolenMagazin.id = Database.AddNewItem(PistolenMagazin);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PistolenMagazin);
                                }
                                else
                                {
                                    PistolenMagazin.amount = PistolenMagazin.amount + 12;
                                    Database.UpdateItem(PistolenMagazin);
                                }
                                weapon_revolver_ammo = weapon_revolver_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.HeavyRevolver, PistolenMagazin.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Revolver Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                    }

                    if (button == "Mp5")
                    {
                        if (MP5 == null)
                        {
                            if (fweapon.weapon_mp5 > 0)
                            {
                                MP5 = new ItemModel();
                                MP5.amount = 0;
                                MP5.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                MP5.position = new Position(0.0f, 0.0f, 0.0f);
                                MP5.hash = Constants.ITEM_HASH_MP5;
                                MP5.ownerIdentifier = playerId;
                                MP5.ITEM_ART = "Waffe";
                                MP5.objectHandle = null;

                                MP5.id = Database.AddNewItem(MP5);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(MP5);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SMG, 0);
                                weapon_mp5 = weapon_mp5 - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine MP5 vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_mp5_ammo > 0)
                            {
                                MP5.amount = MP5.amount + 30;
                                Database.UpdateItem(MP5);
                                weapon_mp5_ammo = weapon_mp5_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.SMG, MP5.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Mp5 Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "Ak47")
                    {
                        if (AK47 == null)
                        {
                            if (fweapon.weapon_assaultrifle > 0)
                            {
                                AK47 = new ItemModel();
                                AK47.amount = 0;
                                AK47.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                AK47.position = new Position(0.0f, 0.0f, 0.0f);
                                AK47.hash = Constants.ITEM_HASH_AK47;
                                AK47.ownerIdentifier = playerId;
                                AK47.ITEM_ART = "Waffe";
                                AK47.objectHandle = null;
                                AK47.id = Database.AddNewItem(AK47);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(AK47);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AssaultRifle, 0);
                                weapon_assaultrifle = weapon_assaultrifle - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Ak-47 vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_assaultrifle_ammo > 0)
                            {
                                AK47.amount = AK47.amount + 30;
                                Database.UpdateItem(AK47);
                                weapon_assaultrifle_ammo = weapon_assaultrifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.AssaultRifle, AK47.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Ak-47 Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "Rifle")
                    {
                        if (RIFLE == null)
                        {
                            if (fweapon.weapon_rifle > 0)
                            {
                                RIFLE = new ItemModel();
                                RIFLE.amount = 0;
                                RIFLE.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                RIFLE.position = new Position(0.0f, 0.0f, 0.0f);
                                RIFLE.hash = Constants.ITEM_HASH_RIFLE;
                                RIFLE.ownerIdentifier = playerId;
                                RIFLE.ITEM_ART = "Waffe";
                                RIFLE.objectHandle = null;
                                RIFLE.id = Database.AddNewItem(RIFLE);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(RIFLE);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Musket, 0);
                                weapon_rifle = weapon_rifle - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Rifle vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_rifle_ammo > 0)
                            {
                                RIFLE.amount = RIFLE.amount + 30;
                                Database.UpdateItem(RIFLE);
                                weapon_rifle_ammo = weapon_rifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.Musket, RIFLE.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Rifle Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "Sniper")
                    {
                        if (SNIPER == null)
                        {
                            if (fweapon.weapon_sniperrifle > 0)
                            {
                                SNIPER = new ItemModel();
                                SNIPER.amount = 0;
                                SNIPER.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                SNIPER.position = new Position(0.0f, 0.0f, 0.0f);
                                SNIPER.hash = Constants.ITEM_HASH_SNIPERRIFLE;
                                SNIPER.ownerIdentifier = playerId;
                                SNIPER.ITEM_ART = "Waffe";
                                SNIPER.objectHandle = null;
                                SNIPER.id = Database.AddNewItem(SNIPER);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(SNIPER);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.SniperRifle, 0);
                                weapon_sniperrifle = weapon_sniperrifle - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine Sniper vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_sniperrifle_ammo > 0)
                            {
                                SNIPER.amount = SNIPER.amount + 30;
                                Database.UpdateItem(SNIPER);
                                weapon_sniperrifle_ammo = weapon_sniperrifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.SniperRifle, SNIPER.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein Sniper Magazin vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "RPG")
                    {
                        if (RPG == null)
                        {
                            if (fweapon.weapon_rpg > 0)
                            {
                                RPG = new ItemModel();
                                RPG.amount = 0;
                                RPG.dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                                RPG.position = new Position(0.0f, 0.0f, 0.0f);
                                RPG.hash = Constants.ITEM_HASH_RPG;
                                RPG.ownerIdentifier = playerId;
                                RPG.ITEM_ART = "Waffe";
                                RPG.objectHandle = null;

                                RPG.id = Database.AddNewItem(RPG);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(RPG);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.RPG, 0);
                                weapon_sniperrifle = weapon_sniperrifle - 1;
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat eine RPG vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_rpg_ammo > 0)
                            {
                                RPG.amount = RPG.amount + 5;
                                Database.UpdateItem(RPG);
                                weapon_rpg_ammo = weapon_rpg_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.RPG, RPG.amount);
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " hat ein RPG Schuss vom Lager genommen.", player.Reallife.Faction);
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    // WT FIX 

                    Database.SetFactionWeaponlager(player.Reallife.Faction, weapon_knuckle, weapon_nightstick, weapon_baseball, weapon_stungun, weapon_pistol, weapon_pistol50,
            weapon_revolver, weapon_pumpshotgun, weapon_combatpdw, weapon_mp5, weapon_assaultrifle, weapon_carbinerifle, weapon_advancedrifle,
            weapon_gusenberg, weapon_rifle, weapon_sniperrifle, weapon_rpg, weapon_bzgas, weapon_molotov, weapon_smokegrenade, weapon_pistol_ammo, weapon_pistol50_ammo, weapon_revolver_ammo, weapon_pumpshotgun_ammo, weapon_combatpdw_ammo, weapon_mp5_ammo, weapon_assaultrifle_ammo,
            weapon_carbinerifle_ammo, weapon_advancedrifle_ammo, weapon_gusenberg_ammo, weapon_rifle_ammo, weapon_sniperrifle_ammo, weapon_rpg_ammo);
                }
            }
            catch { }
        }

        [Command("ausknasten")]
        public void RemovePlayerFromKnast(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Reallife.FactionRank >= 3)
                {
                    if (target.Reallife.Knastzeit > 0)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                        target.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                        target.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 105, 145) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat " + target.Username + " ausgeknastet.");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab Rank 3 verfügbar!");
                }
            }
            catch { }
        }



        [Command("suspect", true)]
        public void GivePlayerStars_LongVersion(VnXPlayer player, string target_name, string action)
        {
            try
            {
                GivePlayerStars(player, target_name, action);
            }
            catch { }
        }


        private static List<WantedModel> WantedList = new List<WantedModel>
        {
            // 1 Stars
            new WantedModel("körperverletzung",                     1,  new string[]{ "kpv" },      "Körperverletzung"),
            new WantedModel("beamtenbehinderung",                   1,  new string[]{ "behind" },   "Beamtenbehinderung"),
            new WantedModel("beamtenbelästigung",                   1,  new string[]{ "beläst" },   "Beamtenbelästigung"),
            new WantedModel("beleidigung",                          1,  new string[]{ "belei" },    "Beleidigung"),
            new WantedModel("flucht vor kontrolle",                 1,  new string[]{ "vkk" },      "Flucht vor/aus Kontrolle"),
            new WantedModel("diebstahl",                            1,  new string[]{ "dieb" },     "Diebstahl"),
            new WantedModel("versuchter diebstahl",                 1,  new string[]{ "vdieb" },    "Versuchter Diebstahl"),
            new WantedModel("sachbeschädigung",                     1,  new string[]{ "sb" },       "Sachbeschädigung"),
            new WantedModel("illegale werbung",                     1,  new string[]{ "werb" },     "Illegale Werbung"),
            new WantedModel("illegales straßenrennen",              1,  new string[]{ "rennen" },   "Illegales straßenrennen"),
            new WantedModel("vortäuschen falscher tatsachen",       1,  new string[]{ "tat" },      "Vortäuschen falscher Tatsachen"),
            new WantedModel("fahren ohne fahrerlaubnis",            1,  new string[]{ "fof" },      "Fahren ohne Fahrerlaubnis"),
            new WantedModel("drogenbesitz1",                        1,  new string[]{ "drug1" },    "Drogenbesitz (10 - 49g)"),
            new WantedModel("kokainbesitz1",                        1,  new string[]{ "koks1" },    "Koksinbesitz (10 - 49g)"),
            new WantedModel("matsbesitz1",                          1,  new string[]{ "mats1" },    "Matsbesitz (10 - 49Stk.)"),

            // 2 Stars
            new WantedModel("verweigerung der durchsuchung",        2,  new string[]{ "verweig" },  "Verweigerung der Durchsuchung"),
            new WantedModel("schusswaffengebrauch",                 2,  new string[]{ "waffe" },    "Schusswaffengebrauch"),
            new WantedModel("körperverletzung durch schusswaffen",  2,  new string[]{ "kpvs" },     "Körperverletzung durch Schusswaffen"),
            new WantedModel("herstellung illegaler gegenstände",    2,  new string[]{ "btm" },      "Herstellung illegaler gegenstände"),
            new WantedModel("drogenkonsum",                         2,  new string[]{ "konsum" },   "Drogenkonsum"),
            new WantedModel("raubüberfall",                         2,  new string[]{ "raub" },     "Raubüberfall"),
            new WantedModel("bestechungsversuch",                   2,  new string[]{ "stech" },    "Bestechungsversuch"),
            new WantedModel("waffenverkauf",                        2,  new string[]{ "verkauf" },  "Waffenverkauf"),
            new WantedModel("carrob",                               2,  new string[]{ "cr" },       "Carrob"),
            new WantedModel("drogenbesitz2",                        2,  new string[]{ "drug2" },    "Drogenbesitz (50 - 149g)"),
            new WantedModel("kokainbesitz2",                        2,  new string[]{ "koks2" },    "Koksinbesitz (50 - 149g)"),
            new WantedModel("matsbesitz2",                          2,  new string[]{ "mats2" },    "Matsbesitz (50 - 149Stk.)"),

            // 3 Stars 
            new WantedModel("mord",                                 3,  new string[]{},             "Mord"),
            new WantedModel("betreten von sperrzonen",              3,  new string[]{ "sperr" },    "Betreten von Sperrzonen"),
            new WantedModel("beihilfe zur freiheitsberaubung",      3,  new string[]{ "beraub" },   "Beihilfe zur Freiheitsberaubung"),
            new WantedModel("drogentruck",                          3,  new string[]{ "dt" },       "Drogentruck (und Beihilfe)"),
            new WantedModel("kokaintruck",                          3,  new string[]{ "kt" },       "Kokaintruck (und Beihilfe)"),
            new WantedModel("matstruck",                            3,  new string[]{ "mt" },       "Matstruck (und Beihilfe)"),
            new WantedModel("waffentruck",                          3,  new string[]{ "wt" },       "Waffentruck (und Beihilfe)"),
            new WantedModel("drogenbesitz3",                        3,  new string[]{ "drug3" },    "Drogenbesitz (150g und mehr)"),
            new WantedModel("kokainbesitz3",                        3,  new string[]{ "koks3" },    "Koksinbesitz (150g und mehr)"),
            new WantedModel("matsbesitz3",                          3,  new string[]{ "mats3" },    "Matsbesitz (150 Stk. und mehr)"),

            // 4 Stars
            new WantedModel("bankraub",                             4,  new string[]{ "br" },       "Bankraub (und Beihilfe)"),
            new WantedModel("geiselnahme",                          4,  new string[]{ "geisel" },   "Geiselnahme (und Beihilfe)"),

            // 6 Stars
            new WantedModel("einbruch beim fib",                    4,  new string[]{ "fib" },      "Einbruch beim FIB"),
            new WantedModel("einbruch beim lspd",                   4,  new string[]{ "pd" },       "Einbruch beim LSPD"),
        };
        private static Dictionary<string, WantedModel> _wantedModelByCommand = new Dictionary<string, WantedModel>();
        public static void AddToWantedDictionary()
        {
            foreach (WantedModel wanted in WantedList)
            {
                _wantedModelByCommand[wanted.Reason] = wanted;
                foreach (var str in wanted.ShortReasons)
                    _wantedModelByCommand[str] = wanted;
            }
        }


        [Command("su", true)]
        public void GivePlayerStars(VnXPlayer player, string targetName, string action)
        {
            try
            {
                if (Allround.isStateFaction(player) == false) { player.SendTranslatedChatMessage("Du bist kein Staatsfraktionist!"); return; }
                VnXPlayer target = RageAPI.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    action = action.ToLower();
                    if (!_wantedModelByCommand.TryGetValue(action, out WantedModel wantedClass))
                    {
                        player.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Grund wurde nicht gefunden! Dein Grund war : " + action);
                        return;
                    }
                    target.Reallife.Wanteds = Math.Min(6, target.Reallife.Wanteds + wantedClass.Wanteds);
                    target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedClass.Description);
                    foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers())
                    {
                        if (Allround.isStateFaction(targetsingame))
                        {
                            targetsingame.SendChatMessage("!{0,145,200}" + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat das Fahndungslevel von " + target.Username + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedClass.Description);
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("GivePlayerStars", ex); }
        }

        [Command("clear", true)]
        public void Clearuserwanteds(VnXPlayer player, string targetName)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                VnXPlayer target = RageAPI.GetPlayerFromName(targetName);
                if (target is null) { target.SendReallifeMessage(RageAPI.GetHexColorcode(175, 0, 0) + targetName + " ist nicht Online/Wurde nicht gefunden."); return; }
                if (target.Playing && target.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    if (target.Reallife.Wanteds == 0) player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");
                    else
                    {
                        target.Reallife.Wanteds = 0;
                        target.SendTranslatedChatMessage("{007d00}Officer " + player.Username + " hat deine Akte Gelöscht!");

                        foreach (VnXPlayer targetsingame in VenoX.GetAllPlayers())
                        {
                            if (Allround.isStateFaction(targetsingame))
                            {
                                targetsingame.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat die Akte von " + target.Username + " Gelöscht!");
                            }
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist nicht in Reallife online.");
                }
            }
            catch { }
        }
    }
}