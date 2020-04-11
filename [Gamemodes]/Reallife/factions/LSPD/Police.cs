//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.factions
{
    public class Police : IScript
    {
        [Command("zeigen")]
        public static void ShowToPlayerLicense(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
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


                    player.SendChatMessage("Du hast " + target.GetVnXName<string>() + " deine Lizenzen gezeigt!");
                    target.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 200) + "Vorhandene Lizenzen von " + player.GetVnXName<string>() + " : " + RageAPI.GetHexColorcode(200, 200, 0) + " Lizenzen");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist zu weit von " + target.GetVnXName<string>() + " entfernt!");
                }
            }
            catch
            {
            }
        }


        [Command("frisk")]
        public static void FriskPlayer(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Position.Distance(target.Position) < 5)
                {
                    string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.GetVnXName<string>() + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                    ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                    ItemModel WEED = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_WEED);
                    ItemModel MATS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_MATS);
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

                    player.SendChatMessage(inventory + "Materials: " + mats + " Stk, Kokain: " + kokain + "g , Drogen: " + weed + "g");
                    target.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.GetVnXName<string>() + " hat dich durchsucht!");
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist zu weit von " + target.GetVnXName<string>() + " entfernt!");
                }
            }
            catch
            {
            }
        }

        [Command("takeillegal")]
        public static void Takeillegal(IPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                    {
                        if (player.Position.Distance(target.Position) < 5)
                        {
                            string inventory = RageAPI.GetHexColorcode(175, 0, 0) + " Gegenstände von " + target.GetVnXName<string>() + " : " + RageAPI.GetHexColorcode(255, 255, 255) + "";

                            ItemModel KOKS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                            ItemModel WEED = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_WEED);
                            ItemModel MATS = Main.GetPlayerItemModelFromHash(target.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_MATS);
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

                            target.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + player.GetVnXName<string>() + " hat dir deine Illegalen Gegenstaende abgenommen!");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Du hast " + target.GetVnXName<string>() + " seine Illegalen Gegenstaende abgenommen!");
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du bist zu weit von " + target.GetVnXName<string>() + " entfernt!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht im Dienst!!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Staatsfraktionist!");
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("triggerStateWeaponWindowBtn_S")]
        public static void GivePlayerStateFactionWeapon(IPlayer player, string button)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    int playermoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                    int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(Constants.FACTION_POLICE);
                    //Waffen Datas = 

                    int weapon_knuckle = fweapon.weapon_knuckle;
                    int weapon_nightstick = fweapon.weapon_nightstick;
                    int weapon_stungun = fweapon.weapon_tazer;
                    int weapon_pistol = fweapon.weapon_pistol;
                    int weapon_pistol50 = fweapon.weapon_pistol50;
                    int weapon_revolver = fweapon.weapon_revolver;
                    int weapon_pumpshotgun = fweapon.weapon_pumpshotgun;
                    int weapon_combatpdw = fweapon.weapon_combatpdw_ammo;
                    int weapon_assaultrifle = fweapon.weapon_assaultrifle;
                    int weapon_carbinerifle = fweapon.weapon_carbinerifle;
                    int weapon_advancedrifle = fweapon.weapon_advancedrifle;
                    int weapon_gusenberg = fweapon.weapon_gusenberg;
                    int weapon_sniperrifle = fweapon.weapon_sniperrifle;
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
                    int weapon_rpg_ammo = fweapon.weapon_rpg_ammo;

                    ItemModel SCHLAGSTOCK = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_NIGHTSTICK);
                    ItemModel TAZER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);
                    ItemModel PISTOLE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                    ItemModel PISTOLE50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                    ItemModel SHOTGUN = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
                    ItemModel KARABINER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KARABINER);
                    ItemModel ADVANCEDRIFLE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                    ItemModel SNIPER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);

                    if (button == "Schlagstock")
                    {
                        if (SCHLAGSTOCK == null)
                        {
                            if (fweapon.weapon_nightstick > 0)
                            {
                                SCHLAGSTOCK = new ItemModel();
                                SCHLAGSTOCK.amount = 0;
                                SCHLAGSTOCK.dimension = 0;
                                SCHLAGSTOCK.position = new Position(0.0f, 0.0f, 0.0f);
                                SCHLAGSTOCK.hash = Constants.ITEM_HASH_NIGHTSTICK;
                                SCHLAGSTOCK.ownerIdentifier = playerId;
                                SCHLAGSTOCK.ITEM_ART = "Waffe";
                                SCHLAGSTOCK.objectHandle = null;
                                SCHLAGSTOCK.id = Database.AddNewItem(SCHLAGSTOCK);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(SCHLAGSTOCK);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.Nightstick, 0);
                                weapon_nightstick = weapon_nightstick - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat einen Schlagstock vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Schlagstock!");
                        }
                    }

                    if (button == "Tazer")
                    {
                        if (TAZER == null)
                        {
                            if (fweapon.weapon_tazer > 0)
                            {
                                TAZER = new ItemModel();
                                TAZER.amount = 0;
                                TAZER.dimension = 0;
                                TAZER.position = new Position(0.0f, 0.0f, 0.0f);
                                TAZER.hash = Constants.ITEM_HASH_TAZER;
                                TAZER.ownerIdentifier = playerId;
                                TAZER.ITEM_ART = "Waffe";
                                TAZER.objectHandle = null;


                                TAZER.id = Database.AddNewItem(TAZER);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(TAZER);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.StunGun, 0);
                                weapon_stungun = weapon_stungun - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat einen Tazer vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Tazer!");
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
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Pistole vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Pistolen Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Pistol50. vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Pistol50. Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                    }

                    if (button == "Shotgun")
                    {
                        if (SHOTGUN == null)
                        {
                            if (fweapon.weapon_pumpshotgun > 0)
                            {
                                SHOTGUN = new ItemModel();
                                SHOTGUN.amount = 0;
                                SHOTGUN.dimension = 0;
                                SHOTGUN.position = new Position(0.0f, 0.0f, 0.0f);
                                SHOTGUN.hash = Constants.ITEM_HASH_SHOTGUN;
                                SHOTGUN.ownerIdentifier = playerId;
                                SHOTGUN.ITEM_ART = "Waffe";
                                SHOTGUN.objectHandle = null;

                                SHOTGUN.id = Database.AddNewItem(SHOTGUN);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(SHOTGUN);

                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.PumpShotgun, 0);
                                weapon_pumpshotgun = weapon_pumpshotgun - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Shotgun vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_pumpshotgun_ammo > 0)
                            {
                                SHOTGUN.amount = SHOTGUN.amount + 6;
                                Database.UpdateItem(SHOTGUN);
                                weapon_pumpshotgun_ammo = weapon_pumpshotgun_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.PumpShotgun, SHOTGUN.amount);
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Shotgun Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "PDW")
                    {
                        if (PDW == null)
                        {
                            if (fweapon.weapon_combatpdw > 0)
                            {
                                PDW = new ItemModel();
                                PDW.amount = 0;
                                PDW.dimension = 0;
                                PDW.position = new Position(0.0f, 0.0f, 0.0f);
                                PDW.hash = Constants.ITEM_HASH_PDW;
                                PDW.ownerIdentifier = playerId;
                                PDW.ITEM_ART = "Waffe";
                                PDW.objectHandle = null;
                                PDW.id = Database.AddNewItem(PDW);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(PDW);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CombatPDW, 0);
                                weapon_combatpdw = weapon_combatpdw - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine PDW vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_combatpdw_ammo > 0)
                            {
                                PDW.amount = PDW.amount + 30;
                                Database.UpdateItem(PDW);
                                weapon_combatpdw_ammo = weapon_combatpdw_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.CombatPDW, PDW.amount);
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein PDW Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "Karabiner")
                    {
                        if (KARABINER == null)
                        {
                            if (fweapon.weapon_carbinerifle > 0)
                            {
                                KARABINER = new ItemModel();
                                KARABINER.amount = 0;
                                KARABINER.dimension = 0;
                                KARABINER.position = new Position(0.0f, 0.0f, 0.0f);
                                KARABINER.hash = Constants.ITEM_HASH_KARABINER;
                                KARABINER.ownerIdentifier = playerId;
                                KARABINER.ITEM_ART = "Waffe";
                                KARABINER.objectHandle = null;

                                ItemModel AdvancedRifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                                if (AdvancedRifle != null)
                                {
                                    Database.RemoveItem(AdvancedRifle.id);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(AdvancedRifle);
                                    player.RemoveWeapon(AltV.Net.Enums.WeaponModel.AdvancedRifle);
                                }
                                KARABINER.id = Database.AddNewItem(KARABINER);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(KARABINER);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.CarbineRifle, 0);
                                weapon_carbinerifle = weapon_carbinerifle - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Karabiner vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_carbinerifle_ammo > 0)
                            {
                                KARABINER.amount = KARABINER.amount + 30;
                                Database.UpdateItem(KARABINER);
                                weapon_carbinerifle_ammo = weapon_carbinerifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.CarbineRifle, KARABINER.amount);
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Karabiner Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    if (button == "Rifle")
                    {
                        if (ADVANCEDRIFLE == null)
                        {
                            if (fweapon.weapon_advancedrifle > 0)
                            {
                                ADVANCEDRIFLE = new ItemModel();
                                ADVANCEDRIFLE.amount = 0;
                                ADVANCEDRIFLE.dimension = 0;
                                ADVANCEDRIFLE.position = new Position(0.0f, 0.0f, 0.0f);
                                ADVANCEDRIFLE.hash = Constants.ITEM_HASH_ADVANCEDRIFLE;
                                ADVANCEDRIFLE.ownerIdentifier = playerId;
                                ADVANCEDRIFLE.ITEM_ART = "Waffe";
                                ADVANCEDRIFLE.objectHandle = null;
                                ItemModel Karabiner = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KARABINER);
                                if (Karabiner != null)
                                {
                                    Database.RemoveItem(Karabiner.id);
                                    anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Karabiner);
                                    player.RemoveWeapon(AltV.Net.Enums.WeaponModel.CarbineRifle);
                                }
                                ADVANCEDRIFLE.id = Database.AddNewItem(ADVANCEDRIFLE);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Add(ADVANCEDRIFLE);
                                RageAPI.GivePlayerWeapon(player, AltV.Net.Enums.WeaponModel.AdvancedRifle, 0);
                                weapon_advancedrifle = weapon_advancedrifle - 1;
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine AdvancedRifle vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_advancedrifle_ammo > 0)
                            {
                                ADVANCEDRIFLE.amount = ADVANCEDRIFLE.amount + 30;
                                Database.UpdateItem(ADVANCEDRIFLE);
                                weapon_advancedrifle_ammo = weapon_advancedrifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.AdvancedRifle, ADVANCEDRIFLE.amount);
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein AdvancedRifle Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
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
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Sniper vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
                            }
                        }
                        else
                        {
                            if (fweapon.weapon_sniperrifle_ammo > 0)
                            {
                                SNIPER.amount = SNIPER.amount + 5;
                                Database.UpdateItem(SNIPER);
                                weapon_sniperrifle_ammo = weapon_sniperrifle_ammo - 1;
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.SniperRifle, SNIPER.amount);
                                Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Sniper Magazin vom Lager genommen.");
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    // WT FIX 

                    int weapon_baseball = 0;
                    int weapon_mp5 = 0;
                    int weapon_mp5_ammo = 0;
                    int weapon_rifle = 0;
                    int weapon_rifle_ammo = 0;
                    Database.SetFactionWeaponlager(Constants.FACTION_POLICE, weapon_knuckle, weapon_nightstick, weapon_baseball, weapon_stungun, weapon_pistol, weapon_pistol50,
            weapon_revolver, weapon_pumpshotgun, weapon_combatpdw, weapon_mp5, weapon_assaultrifle, weapon_carbinerifle, weapon_advancedrifle,
            weapon_gusenberg, weapon_rifle, weapon_sniperrifle, weapon_rpg, weapon_bzgas, weapon_molotov, weapon_smokegrenade, weapon_pistol_ammo, weapon_pistol50_ammo, weapon_revolver_ammo, weapon_pumpshotgun_ammo, weapon_combatpdw_ammo, weapon_mp5_ammo, weapon_assaultrifle_ammo,
            weapon_carbinerifle_ammo, weapon_advancedrifle_ammo, weapon_gusenberg_ammo, weapon_rifle_ammo, weapon_sniperrifle_ammo, weapon_rpg_ammo);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("triggerBadWeaponWindowBtn_S")]
        public static void GivePlayerBadFactionWeapon(IPlayer player, string button)
        {
            try
            {
                if (Allround.isBadFaction(player))
                {
                    int playermoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                    int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);

                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat einen Baseball-Schläger vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
                            }
                        }
                        else
                        {
                            player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Baseball-Schläger!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Pistole vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Pistolen Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Pistol50. vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Pistol50. Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Revolver vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Revolver Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine MP5 vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Mp5 Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Ak-47 vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Ak-47 Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Rifle vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Rifle Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine Sniper vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein Sniper Magazin vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat eine RPG vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Waffen im Lager!");
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
                                Faction.CreateCustomBadFactionMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.GetVnXName<string>() + " hat ein RPG Schuss vom Lager genommen.", player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            }
                            else
                            {
                                player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Nicht genug Magazine im Lager!");
                            }
                        }
                    }

                    // WT FIX 

                    Database.SetFactionWeaponlager(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), weapon_knuckle, weapon_nightstick, weapon_baseball, weapon_stungun, weapon_pistol, weapon_pistol50,
            weapon_revolver, weapon_pumpshotgun, weapon_combatpdw, weapon_mp5, weapon_assaultrifle, weapon_carbinerifle, weapon_advancedrifle,
            weapon_gusenberg, weapon_rifle, weapon_sniperrifle, weapon_rpg, weapon_bzgas, weapon_molotov, weapon_smokegrenade, weapon_pistol_ammo, weapon_pistol50_ammo, weapon_revolver_ammo, weapon_pumpshotgun_ammo, weapon_combatpdw_ammo, weapon_mp5_ammo, weapon_assaultrifle_ammo,
            weapon_carbinerifle_ammo, weapon_advancedrifle_ammo, weapon_gusenberg_ammo, weapon_rifle_ammo, weapon_sniperrifle_ammo, weapon_rpg_ammo);
                }
            }
            catch { }
        }
        /*
        [Command("barricade")]
        public void PutCommand(IPlayer player, string item)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0
            {
                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
            }
            else if (Allround.isStateFaction(player) == false)
            {
                dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Beamter im Dienst!");
                return;
            }
            else
            {
                PoliceControlModel policeControl = null;
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_POLICE)
                {
                    switch (item.ToLower())
                    {
                        case Messages.ARG_CONE:
                            policeControl = new PoliceControlModel(0, string.Empty, Constants.POLICE_DEPLOYABLE_CONE, player.Position, player.Rotation);
                            policeControl.position = new Position(policeControl.position.X, policeControl.position.Y, policeControl.position.Z - 1.0f);
                            policeControl.controlObject = NAPI.Object.CreateObject(Constants.POLICE_DEPLOYABLE_CONE, policeControl.position, policeControl.rotation);
                            policeControlList.Add(policeControl);
                            break;
                        case Messages.ARG_BEACON:
                            policeControl = new PoliceControlModel(0, string.Empty, Constants.POLICE_DEPLOYABLE_BEACON, player.Position, player.Rotation);
                            policeControl.position = new Position(policeControl.position.X, policeControl.position.Y, policeControl.position.Z - 1.0f);
                            policeControl.controlObject = NAPI.Object.CreateObject(Constants.POLICE_DEPLOYABLE_BEACON, policeControl.position, policeControl.rotation);
                            policeControlList.Add(policeControl);
                            break;
                        case Messages.ARG_BARRIER:
                            policeControl = new PoliceControlModel(0, string.Empty, Constants.POLICE_DEPLOYABLE_BARRIER, player.Position, player.Rotation);
                            policeControl.position = new Position(policeControl.position.X, policeControl.position.Y, policeControl.position.Z - 1.0f);
                            policeControl.controlObject = NAPI.Object.CreateObject(Constants.POLICE_DEPLOYABLE_BARRIER, policeControl.position, policeControl.rotation);
                            policeControlList.Add(policeControl);
                            break;
                        case "nagelband":
                            policeControl = new PoliceControlModel(0, string.Empty, Constants.POLICE_DEPLOYABLE_SPIKES, player.Position, player.Rotation);
                            policeControl.position = new Position(policeControl.position.X, policeControl.position.Y, policeControl.position.Z - 1.0f);
                            policeControl.controlObject = NAPI.Object.CreateObject(Constants.POLICE_DEPLOYABLE_SPIKES, policeControl.position, policeControl.rotation);
                            policeControlList.Add(policeControl);
                            break;
                        default:
                            player.SendChatMessage(Constants.Rgba_HELP + Messages.GEN_POLICE_PUT_COMMAND);
                            break;
                    }
                }
                else
                {
                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_PLAYER_NOT_POLICE_FACTION);
                }
            }
        }
        
        [Command(Messages.COM_REMOVE, Messages.GEN_POLICE_REMOVE_COMMAND)]
        public void RemoveCommand(IPlayer player, string item)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0
            {
                dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
            }
            else if (Allround.isStateFaction(player) == false)
            {
                dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Beamter im Dienst!");
                return;
            }
            else
            {
                switch (item.ToLower())
                {
                    case Messages.ARG_CONE:
                        RemoveClosestPoliceControlItem(player, Constants.POLICE_DEPLOYABLE_CONE);
                        break;
                    case Messages.ARG_BEACON:
                        RemoveClosestPoliceControlItem(player, Constants.POLICE_DEPLOYABLE_BEACON);
                        break;
                    case Messages.ARG_BARRIER:
                        RemoveClosestPoliceControlItem(player, Constants.POLICE_DEPLOYABLE_BARRIER);
                        break;
                    case Messages.ARG_SPIKES:
                        RemoveClosestPoliceControlItem(player, Constants.POLICE_DEPLOYABLE_SPIKES);
                        break;
                    default:
                        player.SendChatMessage(Constants.Rgba_HELP + Messages.GEN_POLICE_REMOVE_COMMAND);
                        break;
                }
            }
        }
        */

        [Command("ausknasten")]
        public void RemovePlayerFromKnast(IPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Beamter im Dienst!");
                    return;
                }
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_RANK) >= 3)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                    {
                        Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                        target.Position = new Position(427.5651f, -981.0995f, 30.71008f);
                        target.Dimension = 0;
                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(0, 105, 145) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " hat " + target.GetVnXName<string>() + " ausgeknastet.");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Erst ab Rank 3 verfügbar!");
                }
            }
            catch { }
        }



        [Command("suspect", true)]
        public void GivePlayerStars_LongVersion(IPlayer player, string target_name, string action)
        {
            try
            {
                GivePlayerStars(player, target_name, action);
            }
            catch { }
        }

        [Command("su", true)]
        public void GivePlayerStars(IPlayer player, string target_name, string action)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    player.SendChatMessage("Du bist kein Staatsfraktionist!");
                    return;
                }
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }

                if (target != null && target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    action = action.ToLower();
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 6 || target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 6)
                    {
                        player.SendChatMessage("{007d00}Der Spieler hat bereits 6 Wanteds!");
                        return;
                    }
                    int SpielerWanteds = target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS);
                    string wantedgrund = action;

                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////
                    /////////////////////////////// 1 STAR ///////////////////////////////

                    switch (action)
                    {
                        case "kpv":
                        case "körperverletzung":
                        case "behind":
                        case "beamtenbehinderung":
                        case "behinderung":
                        case "beläst":
                        case "beamtenbelästigung":
                        case "belästigung":
                        case "belei":
                        case "beamtenbeleidigung":
                        case "beleidigung":
                        case "vkk":
                        case "flucht":
                        case "kontrolle":
                        case "dieb":
                        case "diebstahl":
                        case "vdieb":
                        case "sb":
                        case "sachbeschädigung":
                        case "beschädigung":
                        case "werb":
                        case "illegale werbung":
                        case "werbung":
                        case "rennen":
                        case "straßenrennen":
                        case "tat":
                        case "tatsachen":
                        case "fof":
                        case "fahrerlaubnis":
                        case "besitz1":
                        case "illegal1":
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 1);
                            break;
                        default:
                            player.SendChatMessage("Falsches Wantedkürzel");
                            break;

                    }


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
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 1);

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

                        target.SendChatMessage("{ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);
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
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 5)
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 6);
                        }
                        else
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 2);
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


                        target.SendChatMessage("{ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);


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
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 3)
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 6);
                        }
                        else
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 3);
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

                        target.SendChatMessage("{ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);
                    }

                    /////////////////////////////// 4 STAR /////////////////////////////// 
                    else if (
                            action == "bankraub" || action == "br"
                         || action == "geiselnahme" || action == "geisel"
                        )
                    {
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 2)
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 6);
                        }
                        else
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 4);
                        }
                        if (action == "br") { wantedgrund = "Bankraub"; }
                        else if (action == "geisel") { wantedgrund = "Geiselnahme"; }

                        target.SendChatMessage("{ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);
                    }
                    /////////////////////////////// 6 STAR /////////////////////////////// 
                    else if (
                            action == "einbruch beim fib" || action == "fib"
                        || action == "einbruch beim lspd" || action == "pd"
                        )
                    {
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) > 2)
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 6);
                        }
                        else
                        {
                            target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + 4);
                        }
                        if (action == "fib") { wantedgrund = "Einbruch beim FIB"; }
                        else if (action == "pd") { wantedgrund = "Einbruch beim LSPD"; }

                        target.SendChatMessage("{ffff00}Dein Fahndungslevel wurde von " + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);
                    }
                    else
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Grund wurde nicht gefunden! Dein Grund war : " + action);
                        return;
                    }
                    foreach (IPlayer targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_FACTION)))
                    {
                        if (Allround.isStateFaction(targetsingame))
                        {
                            targetsingame.SendChatMessage(RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " hat das Fahndungslevel von " + target.GetVnXName<string>() + " erhöht auf " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "! Grund : " + wantedgrund);

                        }
                    }
                    //IPlayer seitig bei ihm Ändern.
                    anzeigen.Usefull.VnX.onWantedChange(target);
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + target.GetVnXName<string>() + " ist grade am Connecten....");
                }
            }
            catch { }
        }
        [Command("clear", true)]
        public void Clearuserwanteds(IPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player) == false)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Beamter im Dienst!");
                    return;
                }
                IPlayer target = Core.RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }

                if (target != null && target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                    {
                        player.SendChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                    }
                    else
                    {
                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                        target.SendChatMessage("{007d00}Officer " + player.GetVnXName<string>() + " hat deine Akte Gelöscht!");
                        anzeigen.Usefull.VnX.onWantedChange(target);

                        foreach (IPlayer targetsingame in Alt.GetAllPlayers().OrderBy(p => p.vnxGetElementData<int>(EntityData.PLAYER_FACTION)))
                        {
                            if (targetsingame.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 1)
                            {
                                targetsingame.SendChatMessage(RageAPI.GetHexColorcode(0, 145, 200) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName<string>() + " hat die Akte von " + target.GetVnXName<string>() + " Gelöscht!");
                            }
                        }
                    }
                }
                else
                {
                    player.SendChatMessage(target.GetVnXName<string>() + " ist grade am Connecten...");
                }
            }
            catch { }
        }
    }
}