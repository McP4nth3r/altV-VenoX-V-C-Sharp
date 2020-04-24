using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
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
        public static void SendVIPNotify(IPlayer player)
        {
            try
            {
                PlayerModel VipL = Database.GetPlayerVIP(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));
                if (VipL.Vip_BisZum > DateTime.Now)
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "---------- VIP Level : " + GetVIPRangName(VipL.Vip_Paket) + " " + RageAPI.GetHexColorcode(0, 175, 0) + " ----------");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "---------- Gültig bis : " + VipL.Vip_BisZum + " ----------");
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, VipL.Vip_Paket);
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "---------- VIP Level : " + GetVIPRangName(VipL.Vip_Paket) + " ----------");
                    player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Abgelaufen am : " + VipL.Vip_BisZum);
                    player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                }
            }
            catch { }
        }


        [Command("vip")]
        public static void ShowPlayerVIPWindow(IPlayer player)
        {
            try
            {
                PlayerModel VipL = Database.GetPlayerVIP(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));
                if (GetVIPRangName(VipL.Vip_Paket) != "Abgelaufen" || GetVIPRangName(VipL.Vip_Paket).Length > 3)
                {
                    player.Emit("CreateVIPWindow");
                }
            }
            catch { }
        }




        public static bool HaveVIPRights(IPlayer player, string paket)
        {
            try
            {
                PlayerModel VipL = Database.GetPlayerVIP(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));
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



        //[AltV.Net.ClientEvent("TriggerVIPButtonToServer")]
        public void VIP_Button_Pressed(IPlayer player, int value, int betrag)
        {
            try
            {
                int playermoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                if (value == 1)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle != null)
                    {
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) < 200)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                            return;
                        }
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 200);
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);
                        dxLibary.VnX.DrawNotification(player, "info", "Du hast dein Auto voll getankt!");
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
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - Gold!");
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
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - Gold!");
                    }
                }

                else if (value == 4)
                {
                    if (playermoney >= 100)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 100);
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                        VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_BROKENBOTTLE, Constants.ITEM_ART_WAFFE, 1, false);
                    }
                }
                else if (value == 5)
                {
                    if (playermoney >= 150)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 150);
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                        VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_HAMMER, Constants.ITEM_ART_WAFFE, 1, false);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                    }
                }
                else if (value == 6)
                {
                    if (HaveVIPRights(player, VIP_BRONZE))
                    {
                        if (playermoney >= 500)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 500);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Waffe gekauft.");
                            int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                            if (Vintage == null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_VINTAGEPISTOL, Constants.ITEM_ART_WAFFE, 1, false);
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits eine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - Silver!");
                    }
                }
                else if (value == 7)
                {
                    if (HaveVIPRights(player, VIP_BRONZE))
                    {
                        if (playermoney >= 150)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 150);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_VINTAGEPISTOL);
                            if (Vintage != null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_NAME_PISTOLAMMO, Constants.ITEM_ART_MAGAZIN, 10, true);
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Vintage - Pistole!");
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - Silver!");
                    }
                }
                else if (value == 8)
                {
                    if (HaveVIPRights(player, VIP_ULTIMATE_RED))
                    {
                        if (playermoney >= 800)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 800);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Mini - SMG gekauft.");
                            int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                            ItemModel MINISMG = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                            if (MINISMG == null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MINISMG, Constants.ITEM_ART_WAFFE, 1, false);
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du hast bereits eine Mini - SMG!");
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - UltimateRed!");
                    }
                }
                else if (value == 9)
                {
                    if (HaveVIPRights(player, VIP_ULTIMATE_RED))
                    {
                        if (playermoney >= 300)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 300);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " Magazin gekauft.");
                            int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                            ItemModel Vintage = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_MINISMG);
                            if (Vintage != null)
                            {
                                VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_MINISMG, Constants.ITEM_ART_WAFFE, 10, true);
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du hast keine Mini - SMG!");
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast kein VIP - UltimateRed!");
                    }
                }
            }
            catch { }
        }
    }
}
