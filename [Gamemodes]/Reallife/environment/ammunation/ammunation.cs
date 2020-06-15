﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.ammunation
{
    public class Ammunation : IScript
    {
        public static void OnResourceStart()
        {
            RageAPI.CreateBlip("Ammunation", new System.Numerics.Vector3(21.11444f, -1106.664f, 29.79703f), 110, 4, false);
        }

        [ClientEvent("Ammunation:BuyAmmo")]
        public void BuyWeaponAmmuAmmunation(Client player, string item)
        {
            try
            {
                int playerId = player.UID;
                switch (item)
                {
                    case "Pistolen Magazin":
                        {
                            ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                            if (Pistole != null)
                            {
                                if (player.Reallife.Money >= 90)
                                {
                                    Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 12, true);
                                    player.Reallife.Money -= 90;
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Pistolen Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Pistole 50 Magazin":
                        {
                            ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                            if (Pistole50 != null)
                            {
                                if (player.Reallife.Money >= 165)
                                {
                                    Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 9, true);
                                    player.Reallife.Money -= 165;
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Pistolen 50. Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Revolver Magazin":
                        {
                            ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                            if (Revolver != null)
                            {
                                if (player.Reallife.Money >= 220)
                                {
                                    Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 9, true);
                                    player.Reallife.Money -= 220;
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Revolver Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Shotgun Magazin":
                        {
                            ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                            if (Shotgun != null)
                            {
                                if (player.Reallife.Money >= 100)
                                {
                                    player.Reallife.Money -= 100;
                                    Shotgun.amount += 6;
                                    player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.PumpShotgun, Shotgun.amount);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein paar " + RageAPI.GetHexColorcode(0, 200, 255) + " Schrotkugeln " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                    Database.UpdateItem(Shotgun);
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "PDW Magazin":
                        {
                            ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
                            if (PDW != null)
                            {
                                if (player.Reallife.Money >= 450)
                                {
                                    player.Reallife.Money -= 450;
                                    PDW.amount += 30;
                                    player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.CombatPDW, PDW.amount);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " PDW Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                    Database.UpdateItem(PDW);
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Rifle Magazin":
                        {
                            ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                            if (Rifle != null)
                            {
                                if (player.Reallife.Money >= 535)
                                {
                                    player.Reallife.Money -= 535;
                                    Rifle.amount += 30;
                                    player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.AdvancedRifle, Rifle.amount);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Rifle Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                    Database.UpdateItem(Rifle);
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                        }
                        return;
                }

            }
            catch (Exception ex) { Core.Debug.CatchExceptions("Ammunation:BuyAmmo", ex); }
        }


        [ClientEvent("Ammunation:BuyWeapon")]
        public void BuyWeaponAmmunation(Client player, string item)
        {
            try
            {
                int playerId = player.UID;
                switch (item)
                {
                    case "Weste":

                        if (player.Reallife.Money >= 100)
                        {
                            if (player.Armor != 100)
                            {
                                player.Reallife.Money -= 100;
                                player.Armor = 100;
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast bereits eine " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item);
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }

                        return;
                    case "Messer":
                        ItemModel SWITCHBLADE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SWITCHBLADE);
                        if (SWITCHBLADE == null) // WEED
                        {
                            if (player.Reallife.Money >= 200)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_SWITCHBLADE, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 200;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Messer!");
                        }
                        return;
                    case "Fallschirm":
                        ItemModel FALLSCHIRM = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_FALLSCHIRM);
                        if (FALLSCHIRM == null) // WEED
                        {
                            if (player.Reallife.Money >= 925)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_ART_FALLSCHIRM, Constants.ITEM_ART_FALLSCHIRM, 1, false);
                                player.Reallife.Money -= 925;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Fallschirm!");
                        }

                        return;

                    case "Pistole":
                        ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                        if (Pistole == null) // WEED
                        {
                            if (player.Reallife.Money >= 265)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 265;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole!");
                        }

                        return;

                    case "Pistole50":

                        ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                        if (Pistole50 == null) // WEED
                        {
                            if (player.Reallife.Money >= 385)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE50, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 385;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole 50 !");
                        }

                        return;

                    case "Revolver":

                        ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                        if (Revolver == null) // WEED
                        {
                            if (player.Reallife.Money >= 400)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_REVOLVER, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 400;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Revolver!");
                        }

                        return;

                    case "Shotgun":

                        ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                        if (Shotgun == null) // WEED
                        {
                            if (player.Reallife.Money >= 600)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_SHOTGUN, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 600;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Shotgun!");
                        }

                        return;

                    case "PDW":
                        ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
                        if (PDW == null) // WEED
                        {
                            if (player.Reallife.Money >= 800)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_PDW, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 800;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine PDW!");
                        }
                        return;
                    case "Rifle":
                        ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                        if (Rifle == null) // WEED
                        {
                            if (player.Reallife.Money >= 950)
                            {
                                Main.GivePlayerItem(player, Constants.ITEM_HASH_RIFLE, Constants.ITEM_ART_WAFFE, 1, false);
                                player.Reallife.Money -= 950;
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);

                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Gewehr!");
                        }
                        return;
                    default:
                        player.SendTranslatedChatMessage("[Venox - Debug Module 1.0] : Ammunation Button konnte nicht geladen werden! Info # :" + item);
                        return;
                }

            }
            catch
            {
            }
        }


        public static ColShapeModel AmmunationCOL = RageAPI.CreateColShapeSphere(new Position(20.84089f, -1106.488f, 29.79704f), 2);
        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == AmmunationCOL.Entity)
                {
                    if (player.Reallife.Waffenschein != 1)
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast keinen Waffenschein!");
                        return;
                    }
                    Alt.Server.TriggerClientEvent(player, "Ammunation:Show");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerAmmunationColShapeHit", ex); }
        }
    }
}
