﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._RootCore_.Database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.bank
{
    public class Bank : IScript
    {

        //[AltV.Net.ClientEvent("ATM_MONEY_BUTTON_TRIGGER")]
        public static void ATM_BUTTON_TRIGGERED(Client player, string button, int value)
        {
            try
            {
                if (value < 0)
                {
                    return;
                }
                if (button == "einzahlen")
                {
                    if (value != 0)
                    {
                        if (value >= 1000)
                        {
                            anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_ATM_EINZAHLEN);
                        }
                        if (value > player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY))
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) + value);
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - value);
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " eingezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] hat " + value + " $ eingezahlt!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ungültige Eingabe!");
                    }
                }

                if (button == "auszahlen")
                {
                    if (value != 0)
                    {
                        if (value > player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK))
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - value);
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + value);
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " ausgezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] hat " + value + " $ aussgezahlt!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ungültige Eingabe!");
                    }
                }
            }
            catch
            {
            }
        }

        [ClientEvent("ATM_MONEY_SEND_TO")]
        public static void SendToPlayerMoney_ATM(Client player, string name, string svalue, string reason)
        {
            try
            {
                int value = Int32.Parse(svalue);
                if (value < 0)
                {
                    return;
                }
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) < value)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Geld hast du nicht!");
                    return;
                }
                else
                {
                    bool charakterexestiert = Database.FindCharacterByName(name);
                    if (charakterexestiert)
                    {
                        string SpielerNameNormal = Database.GetAccountSpielerName(Database.GetCharakterSocialName(name));
                        Client target = RageAPI.GetPlayerFromName(SpielerNameNormal);
                        if (target == null || target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) != true)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist nicht Online!");
                            return;
                        }
                        else
                        {
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + SpielerNameNormal + " " + RageAPI.GetHexColorcode(255, 255, 255) + +value + "  " + RageAPI.GetHexColorcode(0, 200, 255) + "  $ überwiesen!!");
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 255, 0) + player.GetVnXName() + " hat dir " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_BANKMONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - value);
                            target.vnxSetStreamSharedElementData(Core.VnX.PLAYER_BANKMONEY, target.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) + value);
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.GetVnXName() + " ] hat [ " + target.SocialClubId + " ]" + "[ " + target.GetVnXName() + " ] " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            if (value >= 150000)
                            {
                                admin.Admin.sendAdminNotification(player.GetVnXName() + " hat " + target.GetVnXName() + " " + value + " $ Geld überwiesen! ( Grund : " + reason + ")");
                            }
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler exestiert nicht!");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
