using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.premium.viplevels
{
    public class VIPLEVELS : IScript
    {
        public const string VIP_BRONZE = "{cd7f32}Bronze";
        public const string VIP_SILVER = "{C0C0C0}Silber";
        public const string VIP_GOLD = "{DAA520}Gold";
        public const string VIP_PLATIN = "{e5e4e2}Platin";
        public const string VIP_ULTIMATE_RED = "ULTIMATE RED";
        public const string VIP_TOP_DONATOR = "{0096FF}TOP DONATOR";

        public static string GetVIPRangName(string Paket)
        {
            if (Paket == "Bronze")
            {
                return VIP_BRONZE;
            }
            else if (Paket == "Silber")
            {
                return VIP_SILVER;
            }
            else if (Paket == "Gold")
            {
                return VIP_GOLD;
            }
            else if (Paket == "UltimateRed")
            {
                return VIP_ULTIMATE_RED;
            }
            else if (Paket == "Platin")
            {
                return VIP_PLATIN;
            }
            else if (Paket == "TOP DONATOR")
            {
                return VIP_TOP_DONATOR;
            }
            return "Abgelaufen";
        }

        [Command("viptime")]
        public static void SendVIPNotify(VnXPlayer player)
        {
            try
            {
                VnXPlayer VipL = Database.GetPlayerVIP(player, player.UID);
                if (VipL.Vip_BisZum > DateTime.Now)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "---------- VIP Level : " + GetVIPRangName(VipL.Vip_Paket) + " " + RageAPI.GetHexColorcode(0, 175, 0) + " ----------");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "---------- Gültig bis : " + VipL.Vip_BisZum + " ----------");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, VipL.Vip_Paket);
                }
                else
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "---------- VIP Level : " + GetVIPRangName(VipL.Vip_Paket) + " ----------");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Abgelaufen am : " + VipL.Vip_BisZum);
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                }
            }
            catch { }
        }


        [Command("vip")]
        public static void ShowPlayerVIPWindow(VnXPlayer player)
        {
            try
            {
                VnXPlayer VipL = Database.GetPlayerVIP(player, player.UID);
                if (GetVIPRangName(VipL.Vip_Paket) != "Abgelaufen" || GetVIPRangName(VipL.Vip_Paket).Length > 3)
                {
                    VenoX.TriggerClientEvent(player, "CreateVIPWindow");
                }
            }
            catch { }
        }




        public static bool HaveVIPRights(VnXPlayer player, string paket)
        {
            try
            {
                VnXPlayer VipL = Database.GetPlayerVIP(player, player.UID);
                if (paket == VIP_BRONZE)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_BRONZE || GetVIPRangName(VipL.Vip_Paket) == VIP_SILVER || GetVIPRangName(VipL.Vip_Paket) == VIP_GOLD || GetVIPRangName(VipL.Vip_Paket) == VIP_PLATIN || GetVIPRangName(VipL.Vip_Paket) == VIP_ULTIMATE_RED || GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (paket == VIP_SILVER)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_SILVER || GetVIPRangName(VipL.Vip_Paket) == VIP_GOLD || GetVIPRangName(VipL.Vip_Paket) == VIP_PLATIN || GetVIPRangName(VipL.Vip_Paket) == VIP_ULTIMATE_RED || GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (paket == VIP_GOLD)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_GOLD || GetVIPRangName(VipL.Vip_Paket) == VIP_PLATIN || GetVIPRangName(VipL.Vip_Paket) == VIP_ULTIMATE_RED || GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (paket == VIP_PLATIN)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_PLATIN || GetVIPRangName(VipL.Vip_Paket) == VIP_ULTIMATE_RED || GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (paket == VIP_ULTIMATE_RED)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_ULTIMATE_RED || GetVIPRangName(VipL.Vip_Paket) == VIP_PLATIN || GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (paket == VIP_TOP_DONATOR)
                {
                    if (GetVIPRangName(VipL.Vip_Paket) == VIP_TOP_DONATOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }



        [AltV.Net.ClientEvent("TriggerVIPButtonToServer")]
        public void VIP_Button_Pressed(VnXPlayer player, int value, string betrag)
        {
            try
            {
                int playermoney = player.Reallife.Money;
                if (value == 1)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle != null)
                    {
                        if (player.Reallife.Money < 200)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                            return;
                        }
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 200);
                        vehicle.Gas = 100;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast dein Auto voll getankt!");
                    }
                }
                else if (value == 2)
                {
                    if (HaveVIPRights(player, VIP_GOLD))
                    {
                        bank.Bank.ATM_BUTTON_TRIGGERED(player, "einzahlen", betrag);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - Gold!");
                    }
                }
                else if (value == 3)
                {
                    if (HaveVIPRights(player, VIP_GOLD))
                    {
                        bank.Bank.ATM_BUTTON_TRIGGERED(player, "auszahlen", betrag);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - Gold!");
                    }
                }

                else if (value == 4)
                {
                    if (playermoney >= 100)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 100);
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                        VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_BROKENBOTTLE, ItemType.Gun, 1, false);
                    }
                }
                else if (value == 5)
                {
                    if (playermoney >= 150)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 150);
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                        VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_HAMMER, ItemType.Gun, 1, false);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                    }
                }
                else if (value == 6)
                {
                    if (HaveVIPRights(player, VIP_BRONZE))
                    {
                        if (playermoney >= 500)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 500);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                            int playerId = player.UID;
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                            if (Vintage == null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_VINTAGEPISTOL, ItemType.Gun, 1, false);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits eine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - Silver!");
                    }
                }
                else if (value == 7)
                {
                    if (HaveVIPRights(player, VIP_BRONZE))
                    {
                        if (playermoney >= 150)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 150);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.UID;
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                            if (Vintage != null)
                            {
                                Globals.Main.GivePlayerItem(player, Constants.ITEM_NAME_PISTOLAMMO, ItemType.Useable, 10, true);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - Silver!");
                    }
                }
                else if (value == 8)
                {
                    if (HaveVIPRights(player, VIP_ULTIMATE_RED))
                    {
                        if (playermoney >= 800)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 800);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Mini - SMG gekauft.");
                            int playerId = player.UID;
                            ItemModel MINISMG = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                            if (MINISMG == null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MINISMG, ItemType.Gun, 1, false);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits eine Mini - SMG!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - UltimateRed!");
                    }
                }
                else if (value == 9)
                {
                    if (HaveVIPRights(player, VIP_ULTIMATE_RED))
                    {
                        if (playermoney >= 300)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 300);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.UID;
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                            if (Vintage != null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MINISMG, ItemType.Gun, 10, true);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast keine Mini - SMG!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein VIP - UltimateRed!");
                    }
                }
            }
            catch { }
        }
    }
}
