using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.bank;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using EntityData = VenoX.Core._Globals_.EntityData;

namespace VenoX.Core._Gamemodes_.Reallife.premium.viplevels
{
    public class Viplevels : IScript
    {
        public const string VipBronze = "{cd7f32}Bronze";
        public const string VipSilver = "{C0C0C0}Silber";
        public const string VipGold = "{DAA520}Gold";
        public const string VipPlatin = "{e5e4e2}Platin";
        public const string VipUltimateRed = "ULTIMATE RED";
        public const string VipTopDonator = "{0096FF}TOP DONATOR";

        public static string GetVipRangName(string paket)
        {
            switch (paket)
            {
                case "Bronze":
                    return VipBronze;
                case "Silber":
                    return VipSilver;
                case "Gold":
                    return VipGold;
                case "UltimateRed":
                    return VipUltimateRed;
                case "Platin":
                    return VipPlatin;
                case "TOP DONATOR":
                    return VipTopDonator;
                default:
                    return "Abgelaufen";
            }
        }

        [Command("viptime")]
        public static void SendVipNotify(VnXPlayer player)
        {
            try
            {
                VnXPlayer vipL = Database.GetPlayerVip(player, player.CharacterId);
                if (vipL.VipTill > DateTime.Now)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "---------- VIP Level : " + GetVipRangName(vipL.VipPaket) + " " + RageApi.GetHexColorcode(0, 175, 0) + " ----------");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "---------- Gültig bis : " + vipL.VipTill + " ----------");
                    player.VnxSetElementData(EntityData.PlayerVipLevel, vipL.VipPaket);
                }
                else
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "---------- VIP Level : " + GetVipRangName(vipL.VipPaket) + " ----------");
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Abgelaufen am : " + vipL.VipTill);
                    player.VnxSetElementData(EntityData.PlayerVipLevel, "-");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        [Command("vip")]
        public static void ShowPlayerVipWindow(VnXPlayer player)
        {
            try
            {
                VnXPlayer vipL = Database.GetPlayerVip(player, player.CharacterId);
                if (GetVipRangName(vipL.VipPaket) != "Abgelaufen" || GetVipRangName(vipL.VipPaket).Length > 3)
                {
                    _RootCore_.VenoX.TriggerClientEvent(player, "CreateVIPWindow");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }




        public static bool HaveVipRights(VnXPlayer player, string paket)
        {
            try
            {
                VnXPlayer vipL = Database.GetPlayerVip(player, player.CharacterId);
                switch (paket)
                {
                    case VipBronze when GetVipRangName(vipL.VipPaket) == VipBronze || GetVipRangName(vipL.VipPaket) == VipSilver || GetVipRangName(vipL.VipPaket) == VipGold || GetVipRangName(vipL.VipPaket) == VipPlatin || GetVipRangName(vipL.VipPaket) == VipUltimateRed || GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipBronze:
                        return false;
                    case VipSilver when GetVipRangName(vipL.VipPaket) == VipSilver || GetVipRangName(vipL.VipPaket) == VipGold || GetVipRangName(vipL.VipPaket) == VipPlatin || GetVipRangName(vipL.VipPaket) == VipUltimateRed || GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipSilver:
                        return false;
                    case VipGold when GetVipRangName(vipL.VipPaket) == VipGold || GetVipRangName(vipL.VipPaket) == VipPlatin || GetVipRangName(vipL.VipPaket) == VipUltimateRed || GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipGold:
                        return false;
                    case VipPlatin when GetVipRangName(vipL.VipPaket) == VipPlatin || GetVipRangName(vipL.VipPaket) == VipUltimateRed || GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipPlatin:
                        return false;
                    case VipUltimateRed when GetVipRangName(vipL.VipPaket) == VipUltimateRed || GetVipRangName(vipL.VipPaket) == VipPlatin || GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipUltimateRed:
                        return false;
                    case VipTopDonator when GetVipRangName(vipL.VipPaket) == VipTopDonator:
                        return true;
                    case VipTopDonator:
                        return false;
                    default:
                        return false;
                }
            }
            catch { return false; }
        }



        [ClientEvent("TriggerVIPButtonToServer")]
        public void VIP_Button_Pressed(VnXPlayer player, int value, string betrag)
        {
            try
            {
                int playermoney = player.Reallife.Money;
                switch (value)
                {
                    case 1:
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        if (vehicle != null)
                        {
                            if (player.Reallife.Money < 200)
                            {
                                Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                                return;
                            }
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money - 200);
                            vehicle.Gas = 100;
                            Notification.DrawNotification(player, Notification.Types.Info, "Du hast dein Auto voll getankt!");
                        }

                        break;
                    }
                    case 2 when HaveVipRights(player, VipGold):
                        Bank.ATM_BUTTON_TRIGGERED(player, "einzahlen", betrag);
                        break;
                    case 2:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - Gold!");
                        break;
                    case 3 when HaveVipRights(player, VipGold):
                        Bank.ATM_BUTTON_TRIGGERED(player, "auszahlen", betrag);
                        break;
                    case 3:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - Gold!");
                        break;
                    case 4:
                    {
                        if (playermoney >= 100)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 100);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                            player.Inventory.GiveItem(Constants.ItemHashBrokenbottle, ItemType.Gun, 1, false);
                        }

                        break;
                    }
                    case 5 when playermoney >= 150:
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 150);
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                        player.Inventory.GiveItem(Constants.ItemHashHammer, ItemType.Gun, 1, false);
                        break;
                    case 5:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                        break;
                    case 6 when HaveVipRights(player, VipBronze):
                    {
                        if (playermoney >= 500)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 500);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                            int playerId = player.CharacterId;
                            ItemModel vintage = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashVintagepistol);
                            if (vintage == null)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashVintagepistol, ItemType.Gun, 1, false);
                            }
                            else
                            {
                                Notification.DrawNotification(player, Notification.Types.Error, "Du hast bereits eine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                        }

                        break;
                    }
                    case 6:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - Silver!");
                        break;
                    case 7 when HaveVipRights(player, VipBronze):
                    {
                        if (playermoney >= 150)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 150);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.CharacterId;
                            ItemModel vintage = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashVintagepistol);
                            if (vintage != null)
                            {
                                player.Inventory.GiveItem(Constants.ItemNamePistolammo, ItemType.Useable, 10, true);
                            }
                            else
                            {
                                Notification.DrawNotification(player, Notification.Types.Error, "Du hast keine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                        }

                        break;
                    }
                    case 7:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - Silver!");
                        break;
                    case 8 when HaveVipRights(player, VipUltimateRed):
                    {
                        if (playermoney >= 800)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 800);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Mini - SMG gekauft.");
                            int playerId = player.CharacterId;
                            ItemModel minismg = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashMinismg);
                            if (minismg == null)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashMinismg, ItemType.Gun, 1, false);
                            }
                            else
                            {
                                Notification.DrawNotification(player, Notification.Types.Error, "Du hast bereits eine Mini - SMG!");
                            }
                        }
                        else
                        {
                            Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                        }

                        break;
                    }
                    case 8:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - UltimateRed!");
                        break;
                    case 9 when HaveVipRights(player, VipUltimateRed):
                    {
                        if (playermoney >= 300)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playermoney - 300);
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.CharacterId;
                            ItemModel vintage = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashMinismg);
                            if (vintage != null)
                            {
                                player.Inventory.GiveItem(Constants.ItemHashMinismg, ItemType.Gun, 10, true);
                            }
                            else
                            {
                                Notification.DrawNotification(player, Notification.Types.Error, "Du hast keine Mini - SMG!");
                            }
                        }
                        else
                        {
                            Notification.DrawNotification(player, Notification.Types.Error, "Du hast nicht genug Geld!");
                        }

                        break;
                    }
                    case 9:
                        Notification.DrawNotification(player, Notification.Types.Error, "Du hast kein VIP - UltimateRed!");
                        break;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
