using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using VenoXV.Core;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.weapons
{
    public class Weapons : IScript
    {
        public static void GivePlayerWeaponItems(IPlayer player)
        {
            try
            {
                int itemId = 0;
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                foreach (ItemModel item in anzeigen.Inventar.Main.CurrentOnlineItemList)
                {
                    if (!int.TryParse(item.hash, out itemId) && item.ownerIdentifier == playerId && item.ownerEntity == Constants.ITEM_ENTITY_PLAYER && item.ITEM_ART == "Waffe")
                    {
                        AltV.Net.Enums.WeaponModel WeaponModel = (AltV.Net.Enums.WeaponModel)Alt.Hash(item.hash);
                        RageAPI.GivePlayerWeapon(player, WeaponModel, 0);
                        player.SetWeaponAmmo(WeaponModel, item.amount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION GivePlayerWeaponItems] " + ex.Message);
                Console.WriteLine("[EXCEPTION GivePlayerWeaponItems] " + ex.StackTrace);
            }
        }



        public static ItemModel GetEquippedWeaponItemModelByHash(int playerId, AltV.Net.Enums.WeaponModel weapon)
        {
            try
            {
                ItemModel item = null;
                foreach (ItemModel itemModel in anzeigen.Inventar.Main.CurrentOnlineItemList)
                {
                    if (itemModel.ownerIdentifier == playerId && (itemModel.ownerEntity == Constants.ITEM_ENTITY_WHEEL || itemModel.ownerEntity == Constants.ITEM_ENTITY_RIGHT_HAND) && weapon.ToString() == itemModel.hash)
                    {
                        item = itemModel;
                        break;
                    }
                }
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION GetEquippedWeaponItemModelByHash] " + ex.Message);
                Console.WriteLine("[EXCEPTION GetEquippedWeaponItemModelByHash] " + ex.StackTrace);
                return null;
            }
        }




        /*[ScriptEvent(ScriptEventType.PlayerWeap)]
        public void OnPlayerWeaponSwitch(IPlayer player, AltV.Net.Enums.WeaponModel oldWeapon, AltV.Net.Enums.WeaponModel WeaponModel)
        {
            try
            {
                if (WeaponModel != AltV.Net.Enums.WeaponModel.Fist)
                {
                    if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        Tactics.lobby.Anticheat_Weapon.LoadTacticsAnticheat(player, oldWeapon, WeaponModel);
                        return;
                    }                    
                    if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_ZOMBIE)
                    {
                        //Tactics.lobby.Anticheat_Weapon.LoadTacticsAnticheat(player, oldWeapon, AltV.Net.Enums.WeaponModel);
                        return;
                    }
               
                    if (oldWeapon == AltV.Net.Enums.WeaponModel.Snowballs)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Snowball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNOWBALL);
                        if (Snowball != null)
                        {
                            int Munition = NAPI.Player.GetPlayerWeaponAmmo(player, oldWeapon);
                            if (Munition <= 0)
                            {
                                Database.RemoveItem(Snowball.id);
                               anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(Snowball);
                                player.RemoveWeapon( oldWeapon);
                            }
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Snowball)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Snowball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNOWBALL);
                        if (Snowball == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_SNOWBALL_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Hammer)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Bottle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_HAMMER);
                        if (Bottle == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_HAMMER_HASH);

                        }
                        return;
                    }                    
                                       
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Bottle)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Bottle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_BROKENBOTTLE);
                        if (Bottle == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_BOTTLE_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.BaseballBat)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Baseball = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_BASEBALL);
                        if (Baseball == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_BASEBALL_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.Nightstick)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Nightstick = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_NIGHTSTICK);
                        if (Nightstick == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_NIGHTSTICK_HASH);

                        }
                        return;
                    }

                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.StunGun)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel TAZER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);
                        if (TAZER == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_TAZER_HASH);
                        }
                        return;
                    }


                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.SwitchBlade)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel KNIFE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SWITCHBLADE);
                        if (KNIFE == null)
                        {
                            Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_KNIFE_HASH);
                        }
                        return;
                    }


                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.VintagePistol)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                        if (Pistole != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                        if (Pistole != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                        if (Pistole50 != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                        if (Revolver != null)
                        {
                            ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel PumpShotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                        if (PumpShotgun != null)
                        {
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel, PumpShotgun.amount);
                            return;
                        }
                    }
                    else if (WeaponModel == AltV.Net.Enums.WeaponModel.CombatPDW)
                    {
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel MP5 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MP5);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel MP5 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KARABINER);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_AK47);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Sniperrifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RIFLE);
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
                        int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                        ItemModel RPG = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RPG);
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
        public void OnWeaponFire(IPlayer player, string weapon, string ammo)
        {
            try {
                if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) != VenoXV.globals.EntityData.GAMEMODE_REALLIFE)
                {
                    return;
                }
                int playerId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);
                ItemModel Pistoleold = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                //player.SendChatMessage("Dein Alter wert war : " + Pistoleold.amount);
                // player.SendChatMessage("Dein Alter wert war : " + weapon);

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
                    ItemModel SNOWBALL = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNOWBALL);
                    if (SNOWBALL == null)
                    {
                        Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_SNOWBALL_HASH);
                    }
                    return;
                }
                                
                else if (WeaponModel == AltV.Net.Enums.WeaponModel.StunGun)
                {
                    ItemModel TAZER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_TAZER);
                    if (TAZER == null)
                    {
                        Anti_Cheat_Weapons.anticheat_permanent_ban(player, Anti_Cheat_Weapons.ANTICHEAT_TAZER_HASH);
                    }
                    return;
                }

                else if(WeaponModel == AltV.Net.Enums.WeaponModel.Pistol)
                {
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                    if (Pistole != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                    if (Pistole != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                    ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                    if (Pistole50 != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                    ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                    if (Revolver != null)
                    {
                        ItemModel PistolenMagazin = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOL_AMMO);
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
                    ItemModel PumpShotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
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
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
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
                    ItemModel MP5 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MP5);
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
                    ItemModel MiniSMG = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
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
                    ItemModel KARABINER = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_KARABINER);
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
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
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
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_AK47);
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
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SNIPERRIFLE);
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
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RIFLE);
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
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_RPG);
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
                                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + " " + weapon + " | " + AltV.Net.Enums.WeaponModel);
                            }
                        }
                        if (weapon != "unbewaffnet" || AltV.Net.Enums.WeaponModel != AltV.Net.Enums.WeaponModel.Fist || AltV.Net.Enums.WeaponModel != 0
                        {
                            RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + " " + weapon + " | " + AltV.Net.Enums.WeaponModel);
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
