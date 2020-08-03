//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using System.Linq;
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
        public static void ShowToPlayerLicense(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string Lizenzen = "";
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Führerschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Führerschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Motorradschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Motorradschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " LKW-Führerschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " LKW-Führerschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Waffenschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Waffenschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Bootsführerschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Bootsführerschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Flugschein A  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Flugschein A  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Flugschein B  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Flugschein B  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Helikopterschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Helikopterschein  [ ✘ ]"; }

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN) == 1) { Lizenzen = Lizenzen + " Angelschein  [ ✔ ]"; }
                    else { Lizenzen = Lizenzen + " Angelschein  [ ✘ ]"; }


                    player.SendTranslatedChatMessage("Du hast " + target.Username + " deine Lizenzen gezeigt!");
                    target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 200) + "Vorhandene Lizenzen von " + player.Username + " : " + RageAPI.GetHexColorcode(200, 200, 0) + " Lizenzen");
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


        [Command("frisk")]
        public static void FriskPlayer(Client player, string target_name)
        {
            try
            {
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_MATS);
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
        public static void Takeillegal(Client player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    Client target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                    {
                        if (player.Position.Distance(target.Position) < 5)
                        {
                            string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.Username + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                            ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                            ItemModel WEED = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_WEED);
                            ItemModel MATS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_MATS);
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
        public static void GivePlayerStateFactionWeapon(Client player, string Button)
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
        public static void GivePlayerBadFactionWeapon(Client player, string button)
        {
            try
            {
                if (Allround.isBadFaction(player))
                {
                    int playermoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                    int playerId = player.UID;

                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(player.Reallife.Faction);
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
                                BASEBALL.dimension = 0;
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
                                PISTOLE.dimension = 0;
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
                                    PistolenMagazin.dimension = 0;
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
                                PISTOLE50.dimension = 0;
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
                                    PistolenMagazin.dimension = 0;
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
                                REVOLVER.dimension = 0;
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
                                    PistolenMagazin.dimension = 0;
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
                                MP5.dimension = 0;
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
                                AK47.dimension = 0;
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
                                RIFLE.dimension = 0;
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
                                SNIPER.dimension = 0;
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
                                RPG.dimension = 0;
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
        public void RemovePlayerFromKnast(Client player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Reallife.FactionRank >= 3)
                {
                    if (target.Reallife.Knastzeit > 0)
                    {
                        //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                        target.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                        target.Dimension = 0;
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
        public void GivePlayerStars_LongVersion(Client player, string target_name, string action)
        {
            try
            {
                GivePlayerStars(player, target_name, action);
            }
            catch { }
        }


        public static List<WantedModel> WantedList = new List<WantedModel>
        {
            new WantedModel("kpv", 1),
        };


        [Command("su", true)]
        public void GivePlayerStars(Client player, string target_name, string action)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    player.SendTranslatedChatMessage("Du bist kein Staatsfraktionist!");
                    return;
                }
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (!Allround.isStateFaction(player))
                {
                    player.SendChatMessage("Du bist kein Staatsfraktionist!");
                    return;
                }

                if (target.Playing)
                {
                    action = action.ToLower();
                    if (target.Reallife.Wanteds == 6 || target.Reallife.Wanteds > 6)
                    {
                        player.SendChatMessage("!{#007d00}Der Spieler hat bereits 6 Wanteds!");
                        return;
                    }
                    int SpielerWanteds = target.Reallife.Wanteds;
                    string wantedgrund = action;

                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////
                    if (
                       action == "kpv" || action == "körperverletzung"
                    || action == "beamtenbehinderung" || action == "behind"
                    || action == "beamtenbelästigung" || action == "beläst"
                    || action == "beleidigung" || action == "belei"
                    || action == "flucht vor kontrolle" || action == "vkk"
                    || action == "diebstahl" || action == "dieb"
                    || action == "versuchter diebstahl" || action == "vdieb"
                    || action == "sachbeschädigung" || action == "sb"
                    || action == "illegale werbung" || action == "werb"
                    || action == "illegales straßenrennen" || action == "rennen"
                    || action == "vortäuschen falscher tatsachen" || action == "tat"
                    || action == "fahren ohne fahrerlaubnis" || action == "fof"
                    || action == "drogenbesitz1" || action == "drug1"
                    || action == "kokainbesitz1" || action == "koks1"
                    || action == "matsbesitz1" || action == "mats1"
                    )
                    {
                        target.Reallife.Wanteds += 1;

                        if (action == "kpv") { wantedgrund = "Körperverletzung"; }
                        else if (action == "behind") { wantedgrund = "Beamtenbehinderung"; }
                        else if (action == "beläst") { wantedgrund = "Beamtenbelästigung"; }
                        else if (action == "belei") { wantedgrund = "Beleidigung"; }
                        else if (action == "vkk") { wantedgrund = "Flucht vor/aus Kontrolle"; }
                        else if (action == "dieb") { wantedgrund = "Diebstahl"; }
                        else if (action == "vdieb") { wantedgrund = "Versuchter Diebstahl"; }
                        else if (action == "sb") { wantedgrund = "Sachbeschädigung"; }
                        else if (action == "werb") { wantedgrund = "Illegale Werbung"; }
                        else if (action == "rennen") { wantedgrund = "illegales straßenrennen"; }
                        else if (action == "tat") { wantedgrund = "Vortäuschen falscher Tatsachen"; }
                        else if (action == "fof") { wantedgrund = "Fahren ohne Fahrerlaubnis"; }
                        else if (action == "drug1") { wantedgrund = "Drogenbesitz (10 - 49g)"; }
                        else if (action == "koks1") { wantedgrund = "Koksinbesitz (10 - 49g)"; }
                        else if (action == "mats1") { wantedgrund = "Matsbesitz (10 - 49Stk.)"; }

                        target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);
                    }
                    /////////////////////////////// 2 STAR /////////////////////////////// 
                    /////////////////////////////// 2 STAR /////////////////////////////// 
                    /////////////////////////////// 2 STAR /////////////////////////////// 
                    /////////////////////////////// 2 STAR /////////////////////////////// 
                    else if (
                           action == "verweigerung der durchsuchung" || action == "verweig"
                        || action == "schusswaffengebrauch" || action == "waffe"
                        || action == "körperverletzung durch schusswaffen" || action == "kpvs"
                        || action == "herstellung illegaler gegenstände" || action == "btm"
                        || action == "drogenkonsum" || action == "konsum"
                        || action == "raubüberfall" || action == "raub"
                        || action == "bestechungsversuch" || action == "stech"
                        || action == "waffenverkauf" || action == "verkauf"
                        || action == "carrob" || action == "cr"
                        || action == "drogenbesitz2" || action == "drug2"
                        || action == "kokainbesitz2" || action == "koks2"
                        || action == "matsbesitz2" || action == "mats2"
                        )
                    {
                        if (target.Reallife.Wanteds == 5)
                        {
                            target.Reallife.Wanteds = 6;
                        }
                        else
                        {
                            target.Reallife.Wanteds += 2;
                        }

                        if (action == "verweig") { wantedgrund = "Verweigerung der Durchsuchung"; }
                        else if (action == "waffe") { wantedgrund = "Schusswaffengebrauch"; }
                        else if (action == "kpvs") { wantedgrund = "Körperverletzung durch Schusswaffen"; }
                        else if (action == "btm") { wantedgrund = "Herstellung illegaler gegenstände"; }
                        else if (action == "konsum") { wantedgrund = "Drogenkonsum"; }
                        else if (action == "raub") { wantedgrund = "Raubüberfall"; }
                        else if (action == "stech") { wantedgrund = "Bestechungsversuch"; }
                        else if (action == "verkauf") { wantedgrund = "Waffenverkauf"; }
                        else if (action == "cr") { wantedgrund = "Carrob"; }
                        else if (action == "drug2") { wantedgrund = "Drogenbesitz (50 - 149g)"; }
                        else if (action == "koks2") { wantedgrund = "Koksinbesitz (50 - 149g)"; }
                        else if (action == "mats2") { wantedgrund = "Matsbesitz (50 - 149Stk.)"; }

                        target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);


                    }
                    /////////////////////////////// 3 STAR /////////////////////////////// 
                    else if (
                           action == "mord" //Mord == Mord (Kein Kürzel)
                        || action == "betreten von sperrzonen" || action == "sperr"
                        || action == "beihilfe zur freiheitsberaubung" || action == "beraub"
                        || action == "drogentruck" || action == "dt"
                        || action == "kokaintruck" || action == "kt"
                        || action == "matstruck" || action == "mt"
                        || action == "waffentruck" || action == "wt"
                        || action == "drogenbesitz3" || action == "drug3"
                        || action == "kokainbesitz3" || action == "koks3"
                        || action == "matsbesitz3" || action == "mats3"
                        )
                    {
                        if (target.Reallife.Wanteds > 3)
                        {
                            target.Reallife.Wanteds = 6;
                        }
                        else
                        {
                            target.Reallife.Wanteds += 3;
                        }
                        if (action == "mord") { wantedgrund = "Mord"; }
                        else if (action == "sperr") { wantedgrund = "Betreten von Sperrzonen"; }
                        else if (action == "beraub") { wantedgrund = "Beihilfe zur Freiheitsberaubung"; }
                        else if (action == "dt") { wantedgrund = "Drogentruck (und Beihilfe)"; }
                        else if (action == "kt") { wantedgrund = "Kokaintruck (und Beihilfe)"; }
                        else if (action == "mt") { wantedgrund = "Matstruck (und Beihilfe)"; }
                        else if (action == "wt") { wantedgrund = "Waffentruck (und Beihilfe)"; }
                        else if (action == "drug3") { wantedgrund = "Drogenbesitz (150g und mehr)"; }
                        else if (action == "koks3") { wantedgrund = "Koksinbesitz (150g und mehr)"; }
                        else if (action == "mats3") { wantedgrund = "Matsbesitz (150 Stk. und mehr)"; }

                        target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);
                    }

                    /////////////////////////////// 4 STAR /////////////////////////////// 
                    else if (
                            action == "bankraub" || action == "br"
                         || action == "geiselnahme" || action == "geisel"
                        )
                    {
                        if (target.Reallife.Wanteds > 2)
                        {
                            target.Reallife.Wanteds = 6;
                        }
                        else
                        {
                            target.Reallife.Wanteds += 4;
                        }
                        if (action == "br") { wantedgrund = "Bankraub"; }
                        else if (action == "geisel") { wantedgrund = "Geiselnahme"; }

                        target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);
                    }
                    /////////////////////////////// 6 STAR /////////////////////////////// 
                    else if (
                            action == "einbruch beim fib" || action == "fib"
                        || action == "einbruch beim lspd" || action == "pd"
                        )
                    {
                        if (target.Reallife.Wanteds > 2)
                        {
                            target.Reallife.Wanteds = 6;
                        }
                        else
                        {
                            target.Reallife.Wanteds += 4;
                        }
                        if (action == "fib") { wantedgrund = "Einbruch beim FIB"; }
                        else if (action == "pd") { wantedgrund = "Einbruch beim LSPD"; }

                        target.SendReallifeMessage("{#ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);
                    }
                    else
                    {
                        player.SendReallifeMessage("{175,0,0}Grund wurde nicht gefunden! Dein Grund war : " + action);
                        return;
                    }
                    foreach (Client targetsingame in VenoX.GetAllPlayers().ToList())
                    {
                        if (Allround.isStateFaction(targetsingame))
                        {
                            targetsingame.SendChatMessage("!{0,145,200}" + Faction.GetPlayerFactionRank(player) + " | " + player.Name + " hat das Fahndungslevel von " + target.Name + " erhöht auf " + target.Reallife.Wanteds + "! Grund : " + wantedgrund);
                        }
                    }
                }
                else
                {
                    player.SendChatMessage("!{200,0,0}" + target.Name + " ist grade am Connecten....");
                }
            }
            catch { }
        }

        [Command("clear", true)]
        public void Clearuserwanteds(Client player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                    return;
                }
                Client target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }

                if (target != null && target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                    {
                        player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                    }
                    else
                    {
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                        target.SendTranslatedChatMessage("{007d00}Officer " + player.Username + " hat deine Akte Gelöscht!");
                        anzeigen.Usefull.VnX.onWantedChange(target);

                        foreach (Client targetsingame in VenoXV.Globals.Main.ReallifePlayers.ToList())
                        {
                            if (targetsingame.Reallife.Faction == 1)
                            {
                                targetsingame.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat die Akte von " + target.Username + " Gelöscht!");
                            }
                        }
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage(target.Username + " ist grade am Connecten...");
                }
            }
            catch { }
        }
    }
}