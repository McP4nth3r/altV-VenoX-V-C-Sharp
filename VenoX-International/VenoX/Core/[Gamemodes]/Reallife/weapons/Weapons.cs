﻿using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Enums;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;

namespace VenoX.Core._Gamemodes_.Reallife.weapons
{
    public class Weapons : IScript
    {
        public static Dictionary<string, WeaponModel> WeaponHashList = new Dictionary<string, WeaponModel>
        {
            { Constants.ItemHashSwitchblade, WeaponModel.Switchblade },
            { Constants.ItemHashNightstick, WeaponModel.Nightstick },
            { Constants.ItemHashTazer, WeaponModel.StunGun },
            { Constants.ItemHashPistole, WeaponModel.Pistol },
            { Constants.ItemHashPistole50, WeaponModel.Pistol50 },
            { Constants.ItemHashRevolver, WeaponModel.HeavyRevolver },
            { Constants.ItemHashPdw, WeaponModel.CombatPDW },
            { Constants.ItemHashMp5, WeaponModel.SMG },
            { Constants.ItemHashAdvancedrifle, WeaponModel.AdvancedRifle },
            { Constants.ItemHashKarabiner, WeaponModel.CarbineRifle },
            { Constants.ItemHashAk47, WeaponModel.AssaultRifle },
            { Constants.ItemHashRifle, WeaponModel.Musket },
        };
        public static WeaponModel GetWeaponByHashName(string hashName)
        {
            if (!WeaponHashList.ContainsKey(hashName)) { ConsoleHandling.OutputDebugString("Weapon not Found : " + hashName); return WeaponModel.Fist; }
            return WeaponHashList[hashName];
        }

        private static void GivePistolAmmo(VnXPlayer player, int ammo)
        {
            int playerId = player.CharacterId;
            foreach (ItemModel item in Inventory.DatabaseItems.ToList())
            {
                if (item.Uid == playerId)
                {
                    if (item.Type == ItemType.Gun || item.Type == ItemType.Useable)
                    {
                        switch (item.Hash)
                        {
                            case Constants.ItemHashPistole:
                                player.GivePlayerWeapon(WeaponModel.Pistol, ammo);
                                break;
                            case Constants.ItemHashPistole50:
                                player.GivePlayerWeapon(WeaponModel.Pistol50, ammo);
                                break;
                            case Constants.ItemHashRevolver:
                                player.GivePlayerWeapon(WeaponModel.HeavyRevolver, ammo);
                                break;
                        }
                    }
                }
            }
        }
        public static void GivePlayerWeaponItems(VnXPlayer player)
        {
            try
            {
                int playerId = player.CharacterId;
                foreach (ItemModel item in Inventory.DatabaseItems.ToList())
                {
                    if (item.Uid == playerId)
                    {
                        if (item.Type == ItemType.Gun || item.Type == ItemType.Useable)
                        {
                            if (item.Hash == Constants.ItemHashPistolAmmo) { GivePistolAmmo(player, item.Amount); }
                            else { player.GivePlayerWeapon(GetWeaponByHashName(item.Hash), item.Amount); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION GivePlayerWeaponItems] " + ex.Message);
                Console.WriteLine("[EXCEPTION GivePlayerWeaponItems] " + ex.StackTrace);
            }
        }


        /*[ScriptEvent(ScriptEventType.PlayerWeap)]
        public void OnPlayerWeaponSwitch(PlayerModel player, AltV.Net.Enums.WeaponModel oldWeapon, AltV.Net.Enums.WeaponModel WeaponModel)
        {
            try
            {
                if (WeaponModel != AltV.Net.Enums.WeaponModel.Fist)
                {
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS)
                    {
                        Tactics.lobby.Anticheat_Weapon.LoadTacticsAnticheat(player, oldWeapon, WeaponModel);
                        return;
                    }                    
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_ZOMBIE)
                    {
                        //Tactics.lobby.Anticheat_Weapon.LoadTacticsAnticheat(player, oldWeapon, AltV.Net.Enums.WeaponModel);
                        return;
                    }

                    if (oldWeapon == AltV.Net.Enums.WeaponModel.Snowballs)
                    {
                        int playerId = player.UID;
                        ItemModel Snowball = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNOWBALL);
                        if (Snowball != null)
                        {
                            int Munition = NAPI.Player.GetPlayerWeaponAmmo(player, oldWeapon);
                            if (Munition <= 0)
                            {
                                Database.RemoveItem(Snowball.id);
                               _Globals_.Inventory.Inventory.DatabaseItems.Remove(Snowball);
                                player.RemovePlayerWeapon( oldWeapon);
                            }
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Snowball)
                    {
                        int playerId = player.UID;
                        ItemModel Snowball = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNOWBALL);
                        if (Snowball == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_SNOWBALL_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Hammer)
                    {
                        int playerId = player.UID;
                        ItemModel Bottle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_HAMMER);
                        if (Bottle == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_HAMMER_HASH);

                        }
                        return;
                    }                    

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Bottle)
                    {
                        int playerId = player.UID;
                        ItemModel Bottle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_BROKENBOTTLE);
                        if (Bottle == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_BOTTLE_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.BaseballBat)
                    {
                        int playerId = player.UID;
                        ItemModel Baseball = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_BASEBALL);
                        if (Baseball == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_BASEBALL_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Nightstick)
                    {
                        int playerId = player.UID;
                        ItemModel Nightstick = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_NIGHTSTICK);
                        if (Nightstick == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_NIGHTSTICK_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.StunGun)
                    {
                        int playerId = player.UID;
                        ItemModel TAZER = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_TAZER);
                        if (TAZER == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_TAZER_HASH);
                        }
                        return;
                    }


                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.SwitchBlade)
                    {
                        int playerId = player.UID;
                        ItemModel KNIFE = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SWITCHBLADE);
                        if (KNIFE == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_KNIFE_HASH);
                        }
                        return;
                    }


                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.VintagePistol)
                    {
                        int playerId = player.UID;
                        ItemModel Pistole = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_VINTAGEPISTOL);
                        if (Pistole != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (PistolenMagazin != null)
                            {
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                                return;
                            }
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_VINTAGEPISTOL_HASH);
                        }
                    }                   
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Pistol)
                    {
                        int playerId = player.UID;
                        ItemModel Pistole = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOLE);
                        if (Pistole != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (PistolenMagazin != null)
                            {
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                                return;
                            }
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_PISTOL_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Pistol50)
                    {
                        int playerId = player.UID;
                        ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOLE50);
                        if (Pistole50 != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (PistolenMagazin != null)
                            {
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                                return;
                            }
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_PISTOL50_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.HeavyRevolver)
                    {
                        int playerId = player.UID;
                        ItemModel Revolver = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_REVOLVER);
                        if (Revolver != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                            if (PistolenMagazin != null)
                            {
                                player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                                return;
                            }
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_REVOLVER_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.PumpShotgun)
                    {
                        int playerId = player.UID;
                        ItemModel PumpShotgun = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SHOTGUN);
                        if (PumpShotgun != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PumpShotgun.amount);
                            return;
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.CombatPDW)
                    {
                        int playerId = player.UID;
                        ItemModel PDW = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PDW);
                        if (PDW != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PDW.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_PDW_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.SMG)
                    {
                        int playerId = player.UID;
                        ItemModel MP5 = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_MP5);
                        if (MP5 != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MP5.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_MP5_HASH);
                        }
                    }                    
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.MiniSMG)
                    {
                        int playerId = player.UID;
                        ItemModel MP5 = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_MINISMG);
                        if (MP5 != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MP5.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_MINISMG_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.CarbineRifle)
                    {
                        int playerId = player.UID;
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_KARABINER);
                        if (Rifle != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_KARABINER_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.AdvancedRifle)
                    {
                        int playerId = player.UID;
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_ADVANCEDRIFLE);
                        if (Rifle != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_ADVANCED_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.AssaultRifle)
                    {
                        int playerId = player.UID;
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_AK47);
                        if (Rifle != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_AK47_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.SniperRifle)
                    {
                        int playerId = player.UID;
                        ItemModel Sniperrifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNIPERRIFLE);
                        if (Sniperrifle != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Sniperrifle.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_SNIPER_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Musket)
                    {
                        int playerId = player.UID;
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_RIFLE);
                        if (Rifle != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_RIFLE_HASH);
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.RPG)
                    {
                        int playerId = player.UID;
                        ItemModel RPG = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_RPG);
                        if (RPG != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, RPG.amount);
                            return;
                        }
                        else
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_RPG_HASH);
                        }
                    }
                    else
                    {
                        Anti_Cheat_Weapons.anticheat_permanent_ban(player, "ANTICHEAT_WEAPON_" + AltV.Net.Enums.WeaponModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnPlayerWeaponSwitch] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnPlayerWeaponSwitch] " + ex.StackTrace);
            }
        }





        //[AltV.Net.ClientEvent("WeaponFiredToServer")]
        public void OnWeaponFire(PlayerModel player, string weapon, string ammo)
        {
            try {
                if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) != EntityData.GAMEMODE_REALLIFE)
                {
                    return;
                }
                int playerId = player.UID;
                ItemModel Pistoleold = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOLE);
                //player.SendTranslatedChatMessage("Dein Alter wert war : " + Pistoleold.amount);
                // player.SendTranslatedChatMessage("Dein Alter wert war : " + weapon);

                AltV.Net.Enums.WeaponModel WeaponModel = NAPI.Util.WeaponNameToModel(weapon);
                if (weapon == "Pistol") { WeaponModel = AltV.Net.Enums.WeaponModel.Pistol; }
                else if (weapon == "Tazer") { WeaponModel = AltV.Net.Enums.WeaponModel.StunGun; }
                else if(weapon == "Revolver") { WeaponModel = AltV.Net.Enums.WeaponModel.HeavyRevolver; }
                else if (weapon == "Pistol 50.") { WeaponModel = AltV.Net.Enums.WeaponModel.Pistol50; }
                else if (weapon == "Einsatz PDW") { WeaponModel = AltV.Net.Enums.WeaponModel.CombatPDW; }
                else if (weapon == "MP") { WeaponModel = AltV.Net.Enums.WeaponModel.SMG; }
                else if (weapon == "Mini - SMG") { WeaponModel = AltV.Net.Enums.WeaponModel.MiniSMG; }
                else if (weapon == "Kampfgewehr") { WeaponModel = AltV.Net.Enums.WeaponModel.AdvancedRifle; }
                else if (weapon == "Karabiner") { WeaponModel = AltV.Net.Enums.WeaponModel.CarbineRifle; }
                else if (weapon == "Pump Shotgun") { WeaponModel = AltV.Net.Enums.WeaponModel.PumpShotgun; }
                else if (weapon == "Sniper") { WeaponModel = AltV.Net.Enums.WeaponModel.SniperRifle; }
                if (WeaponModel == AltV.Net.Enums.WeaponModel.Snowball)
                {
                    ItemModel SNOWBALL = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNOWBALL);
                    if (SNOWBALL == null)
                    {
                        Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_SNOWBALL_HASH);
                    }
                    return;
                }

                else if (WeaponModel == AltV.Net.Enums.WeaponModel.StunGun)
                {
                    ItemModel TAZER = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_TAZER);
                    if (TAZER == null)
                    {
                        Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_TAZER_HASH);
                    }
                    return;
                }

                else if(WeaponModel == AltV.Net.Enums.WeaponModel.Pistol)
                {
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOLE);
                    if (Pistole != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                        if (PistolenMagazin != null)
                        {
                            PistolenMagazin.amount -= 1;
                            // Update the amount into the database
                            Database.UpdateItem(PistolenMagazin);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                            return;
                        }
                    }
                    return;
                }
                else if(WeaponModel == AltV.Net.Enums.WeaponModel.VintagePistol)
                {
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_VINTAGEPISTOL);
                    if (Pistole != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                        if (PistolenMagazin != null)
                        {
                            PistolenMagazin.amount -= 1;
                            // Update the amount into the database
                            Database.UpdateItem(PistolenMagazin);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                            return;
                        }
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.Pistol50)
                {
                    ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOLE50);
                    if (Pistole50 != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                        if (PistolenMagazin != null)
                        {
                            PistolenMagazin.amount -= 1;
                            // Update the amount into the database
                            Database.UpdateItem(PistolenMagazin);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                            return;
                        }
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.HeavyRevolver)
                {
                    ItemModel Revolver = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_REVOLVER);
                    if (Revolver != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PISTOL_AMMO);
                        if (PistolenMagazin != null)
                        {
                            PistolenMagazin.amount -= 1;
                            // Update the amount into the database
                            Database.UpdateItem(PistolenMagazin);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PistolenMagazin.amount);
                            return;
                        }
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.PumpShotgun)
                {
                    ItemModel PumpShotgun = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SHOTGUN);
                    if (PumpShotgun != null)
                    {
                        PumpShotgun.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(PumpShotgun);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PumpShotgun.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.CombatPDW)
                {
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_PDW);
                    if (PDW != null)
                    {
                        if (PDW.amount == 1)
                        {
                            PDW.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(PDW);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PDW.amount);
                            return;
                        }
                        PDW.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(PDW);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PDW.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.SMG)
                {
                    ItemModel MP5 = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_MP5);
                    if (MP5 != null)
                    {
                        if (MP5.amount == 1)
                        {
                            MP5.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(MP5);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MP5.amount);
                            return;
                        }
                        MP5.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(MP5);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MP5.amount);
                        return;
                    }
                    return;
                }               
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.MiniSMG)
                {
                    ItemModel MiniSMG = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_MINISMG);
                    if (MiniSMG != null)
                    {
                        if (MiniSMG.amount == 1)
                        {
                            MiniSMG.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(MiniSMG);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MiniSMG.amount);
                            return;
                        }
                        MiniSMG.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(MiniSMG);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, MiniSMG.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.CarbineRifle)
                {
                    ItemModel KARABINER = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_KARABINER);
                    if (KARABINER != null)
                    {
                        if (KARABINER.amount == 1)
                        {
                            KARABINER.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(KARABINER);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, KARABINER.amount);
                            return;
                        }
                        KARABINER.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(KARABINER);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, KARABINER.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.AdvancedRifle)
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_ADVANCEDRIFLE);
                    if (Rifle != null)
                    {
                        if (Rifle.amount == 1)
                        {
                            Rifle.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(Rifle);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        Rifle.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(Rifle);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.AssaultRifle)
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_AK47);
                    if (Rifle != null)
                    {
                        if (Rifle.amount == 1)
                        {
                            Rifle.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(Rifle);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        Rifle.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(Rifle);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                        return;
                    }
                    return;
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.SniperRifle)
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_SNIPERRIFLE);
                    if (Rifle != null)
                    {
                        if (Rifle.amount == 1)
                        {
                            Rifle.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(Rifle);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        Rifle.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(Rifle);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                        return;
                    }
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.Musket)
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_RIFLE);
                    if (Rifle != null)
                    {
                        if (Rifle.amount == 1)
                        {
                            Rifle.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(Rifle);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        Rifle.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(Rifle);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                        return;
                    }
                }
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.RPG)
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(player, Constants.ITEM_HASH_RPG);
                    if (Rifle != null)
                    {
                        if (Rifle.amount == 1)
                        {
                            Rifle.amount = 0;
                            // Update the amount into the database
                            Database.UpdateItem(Rifle);
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                            return;
                        }
                        Rifle.amount -= 1;
                        // Update the amount into the database
                        Database.UpdateItem(Rifle);
                        player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, Rifle.amount);
                        return;
                    }
                }
                else
                {
                    if (AltV.Net.Enums.WeaponModel != 0
                    {
                        if (WeaponModel == AltV.Net.Enums.WeaponModel.CarbineRifle || WeaponModel == AltV.Net.Enums.WeaponModel.CombatPDW || WeaponModel == AltV.Net.Enums.WeaponModel.AssaultRifle || WeaponModel == AltV.Net.Enums.WeaponModel.AdvancedRifle)
                        {
                            int ammodev = player.GetWeaponAmmo(AltV.Net.Enums.WeaponModel);
                            if (ammodev == 1)
                            {
                                return;
                            }
                            else
                            {
                                RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + " " + weapon + " | " + AltV.Net.Enums.WeaponModel);
                            }
                        }
                        if (weapon != "unbewaffnet" || AltV.Net.Enums.WeaponModel != AltV.Net.Enums.WeaponModel.Fist || AltV.Net.Enums.WeaponModel != 0
                        {
                            RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + " " + weapon + " | " + AltV.Net.Enums.WeaponModel);
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, "0x047_" + AltV.Net.Enums.WeaponModel);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnWeaponFire] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnWeaponFire] " + ex.StackTrace);
            }
        }*/
    }
}
