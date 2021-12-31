using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using VenoX.Core._Gamemodes_.Reallife.quests;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.globals;
using VenoXV.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.Environment.ammunation
{
    public class Ammunation : IScript
    {
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Ammunation", new Vector3(21.11444f, -1106.664f, 29.79703f), 110, 4, false);
        }

        [VenoXRemoteEvent("Ammunation:BuyAmmo")]
        public void BuyWeaponAmmuAmmunation(VnXPlayer player, string item)
        {
            try
            {
                int playerId = player.UID;
                switch (item)
                {
                    case "Pistolen Magazin":
                        {
                            ItemModel pistole = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPistole);
                            if (pistole != null)
                            {
                                if (player.Reallife.Money >= 90)
                                {
                                    player.Inventory.GiveItem(Constants.ItemHashPistolAmmo, ItemType.Useable, 12, true);
                                    player.Reallife.Money -= 90;
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " Pistolen Magazin " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Pistole 50 Magazin":
                        {
                            ItemModel pistole50 = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPistole50);
                            if (pistole50 != null)
                            {
                                if (player.Reallife.Money >= 165)
                                {
                                    player.Inventory.GiveItem(Constants.ItemHashPistolAmmo, ItemType.Useable, 9, true);
                                    player.Reallife.Money -= 165;
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " Pistolen 50. Magazin " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Revolver Magazin":
                        {
                            ItemModel revolver = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashRevolver);
                            if (revolver != null)
                            {
                                if (player.Reallife.Money >= 220)
                                {
                                    player.Inventory.GiveItem(Constants.ItemHashPistolAmmo, ItemType.Useable, 9, true);
                                    player.Reallife.Money -= 220;
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " Revolver Magazin " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Shotgun Magazin":
                        {
                            ItemModel shotgun = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashShotgun);
                            if (shotgun != null)
                            {
                                if (player.Reallife.Money >= 100)
                                {
                                    player.Reallife.Money -= 100;
                                    shotgun.Amount += 6;
                                    player.SetWeaponAmmo(WeaponModel.PumpShotgun, shotgun.Amount);
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein paar " + RageApi.GetHexColorcode(0, 200, 255) + " Schrotkugeln " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "PDW Magazin":
                        {
                            ItemModel pdw = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPdw);
                            if (pdw != null)
                            {
                                if (player.Reallife.Money >= 450)
                                {
                                    player.Reallife.Money -= 450;
                                    pdw.Amount += 30;
                                    player.SetWeaponAmmo(WeaponModel.CombatPDW, pdw.Amount);
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " PDW Magazin " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                            return;

                        }
                    case "Rifle Magazin":
                        {
                            ItemModel rifle = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashAdvancedrifle);
                            if (rifle != null)
                            {
                                if (player.Reallife.Money >= 535)
                                {
                                    player.Reallife.Money -= 535;
                                    rifle.Amount += 30;
                                    player.SetWeaponAmmo(WeaponModel.AdvancedRifle, rifle.Amount);
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " Rifle Magazin " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                }
                                else
                                {
                                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                                }
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                            }
                        }
                        return;
                }

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [VenoXRemoteEvent("Ammunation:BuyWeapon")]
        public void BuyWeaponAmmunation(VnXPlayer player, string item)
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
                                player.SetArmor = 100;
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast bereits eine " + RageApi.GetHexColorcode(0, 200, 255) + " " + item);
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }

                        return;
                    case "Messer":
                        ItemModel switchblade = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashSwitchblade);
                        if (switchblade == null) // WEED
                        {
                            if (player.Reallife.Money >= 200)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashSwitchblade, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 200;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Messer!");
                        }
                        return;
                    case "Fallschirm":
                        ItemModel fallschirm = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashFallschirm);
                        if (fallschirm == null) // WEED
                        {
                            if (player.Reallife.Money >= 925)
                            {
                                //player.Inventory.GiveItem(Constants.ITEM_ART_FALLSCHIRM, Constants.ITEM_ART_FALLSCHIRM, 1, false);
                                player.Reallife.Money -= 925;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast einen " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Fallschirm!");
                        }

                        return;

                    case "Pistole":
                        ItemModel pistole = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPistole);
                        if (pistole == null) // WEED
                        {
                            if (player.Reallife.Money >= 265)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashPistole, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 265;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole!");
                        }

                        return;

                    case "Pistole50":

                        ItemModel pistole50 = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPistole50);
                        if (pistole50 == null) // WEED
                        {
                            if (player.Reallife.Money >= 385)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashPistole50, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 385;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole 50 !");
                        }

                        return;

                    case "Revolver":

                        ItemModel revolver = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashRevolver);
                        if (revolver == null) // WEED
                        {
                            if (player.Reallife.Money >= 400)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashRevolver, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 400;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Revolver!");
                        }

                        return;

                    case "Shotgun":

                        ItemModel shotgun = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashShotgun);
                        if (shotgun == null) // WEED
                        {
                            if (player.Reallife.Money >= 600)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashShotgun, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 600;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Shotgun!");
                        }

                        return;

                    case "PDW":
                        ItemModel pdw = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashPdw);
                        if (pdw == null) // WEED
                        {
                            if (player.Reallife.Money >= 800)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashPdw, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 800;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits eine PDW!");
                        }
                        return;
                    case "Rifle":
                        ItemModel rifle = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashAdvancedrifle);
                        if (rifle == null) // WEED
                        {
                            if (player.Reallife.Money >= 950)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashAdvancedrifle, ItemType.Gun, 1, false);
                                player.Reallife.Money -= 950;
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageApi.GetHexColorcode(0, 200, 255) + " " + item + " " + RageApi.GetHexColorcode(255, 255, 255) + "gekauft!");
                                //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);
                                if (Quests.QuestDict.ContainsKey(Quests.QuestGetadvancedrifle))
                                    Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestGetadvancedrifle]);

                            }
                            else
                            {
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                            }
                        }
                        else
                        {
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);
                            if (Quests.QuestDict.ContainsKey(Quests.QuestGetadvancedrifle))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestGetadvancedrifle]);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Gewehr!");
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


        public static ColShapeModel AmmunationCol = RageApi.CreateColShapeSphere(new Position(20.84089f, -1106.488f, 29.79704f), 2);
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != AmmunationCol) return false;

                if (player.Reallife.WeaponLicense != 1)
                {
                    player.SendTranslatedChatMessage(Constants.RgbaError + "Du hast keinen Waffenschein!");
                    return true;
                }
                VenoX.TriggerClientEvent(player, "Ammunation:Show");
                return true;

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
    }
}
