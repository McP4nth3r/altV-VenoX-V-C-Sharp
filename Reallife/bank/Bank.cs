﻿using AltV.Net.Elements.Entities;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.database;
using System;
using VenoXV.Reallife.Core;
using AltV.Net.Resources.Chat.Api;
using AltV.Net;

namespace VenoXV.Reallife.bank
{
    public class Bank : IScript
    {
        
        //[AltV.Net.ClientEvent("ATM_MONEY_BUTTON_TRIGGER")]
        public static  void ATM_BUTTON_TRIGGERED(IPlayer player, string button, int value)
        {
            try
            {
                if(value < 0)
                {
                    return;
                }
                if (button == "einzahlen")
                {
                    if (value != 0)
                    {
                        if(value >= 1000)
                        {
                            anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_ATM_EINZAHLEN);
                        }
                        if (value > player.vnxGetElementData<int>(EntityData.PLAYER_MONEY))
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(EntityData.PLAYER_BANK) + value);
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - value);
                            player.SendChatMessage( "Du hast " + RageAPI.GetHexColorcode(0,200,255) + " " + value + " $" + RageAPI.GetHexColorcode(255,255,255) + " eingezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] hat " + value + " $ eingezahlt!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Ungültige Eingabe!");
                    }
                }

                if (button == "auszahlen")
                {
                    if (value != 0)
                    {
                        if (value > player.vnxGetElementData<int>(EntityData.PLAYER_BANK))
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(EntityData.PLAYER_BANK) - value);
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + value);
                            player.SendChatMessage( "Du hast " + RageAPI.GetHexColorcode(0,200,255) + " " + value + " $" + RageAPI.GetHexColorcode(255,255,255) + " ausgezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] hat " + value + " $ aussgezahlt!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Ungültige Eingabe!");
                    }
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("ATM_MONEY_SEND_TO")]
        public static void SendToPlayerMoney_ATM(IPlayer player, string name , int value, string reason)
        {
            try
            {
                if (value < 0)
                {
                    return;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_BANK) < value)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Soviel Geld hast du nicht!");
                    return;
                }
                else
                {
                    bool charakterexestiert = Database.FindCharacterByName(name);
                    if (charakterexestiert)
                    {
                        string SpielerNameNormal = Database.GetAccountSpielerName(Database.GetCharakterSocialName(name));
                        IPlayer target = Reallife.Core.RageAPI.GetPlayerFromName(SpielerNameNormal);
                        if (target == null || target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) != true)
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Der Spieler ist nicht Online!");
                            return;
                        }
                        else
                        {
                            player.SendChatMessage( "Du hast " + RageAPI.GetHexColorcode(0,200,255) + " " + SpielerNameNormal + " " + RageAPI.GetHexColorcode(255,255,255) +  + value + "  " + RageAPI.GetHexColorcode(0,200,255) + "  $ überwiesen!!");
                           target.SendChatMessage(RageAPI.GetHexColorcode(0,255,0) +player.GetVnXName<string>() + " hat dir " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(EntityData.PLAYER_BANK) - value);
                            Core.VnX.vnxSetSharedData(target, Core.VnX.PLAYER_BANKMONEY, target.vnxGetElementData<int>(EntityData.PLAYER_BANK) + value);
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.GetVnXName<string>() + " ] hat [ " + target.SocialClubId + " ]" + "[ " + target.Name + " ] " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            if (value >= 150000)
                            {
                                admin.Admin.sendAdminNotification(player.GetVnXName<string>() + " hat " + target.Name + " " + value + " $ Geld überwiesen! ( Grund : " + reason + ")");
                            }
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler exestiert nicht!");
                    }
                }
            }
            catch
            {
              
            }
        }
    }
}
