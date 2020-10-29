﻿using AltV.Net;
using System;
using VenoXV._Admin_;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.bank
{
    public class Bank : IScript
    {

        [ClientEvent("ATM_MONEY_BUTTON_TRIGGER")]
        public static void ATM_BUTTON_TRIGGERED(VnXPlayer player, string button, string v)
        {
            try
            {
                int value = int.Parse(v);
                if (value < 0) { return; }
                if (button == "einzahlen")
                {
                    if (value != 0)
                    {
                        if (value >= 1000)
                        {
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_ATM_EINZAHLEN);
                            if (quests.Quests.QuestDict.ContainsKey(Quests.QUEST_ATM_EINZAHLEN))
                                Quests.OnQuestDone(player, quests.Quests.QuestDict[Quests.QUEST_ATM_EINZAHLEN]);
                        }
                        if (value > player.Reallife.Money)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            player.Reallife.Bank += value;
                            player.Reallife.Money -= value;
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " eingezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + value + " $ eingezahlt!");
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
                        if (value > player.Reallife.Bank)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Geld hast du nicht!");
                            return;
                        }
                        else
                        {
                            player.Reallife.Bank -= value;
                            player.Reallife.Money += value;
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageAPI.GetHexColorcode(255, 255, 255) + " ausgezahlt!");
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat " + value + " $ aussgezahlt!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Ungültige Eingabe!");
                    }
                }
            }
            catch { }
        }

        [ClientEvent("ATM_MONEY_SEND_TO")]
        public static void SendToPlayerMoney_ATM(VnXPlayer player, string name, string svalue, string reason)
        {
            try
            {
                int value = Int32.Parse(svalue);
                if (value < 0)
                {
                    return;
                }
                if (player.Reallife.Bank < value)
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
                        VnXPlayer target = RageAPI.GetPlayerFromName(SpielerNameNormal);
                        if (target == null || target.Playing != true)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist nicht Online!");
                            return;
                        }
                        else
                        {
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " " + SpielerNameNormal + " " + RageAPI.GetHexColorcode(255, 255, 255) + +value + "  " + RageAPI.GetHexColorcode(0, 200, 255) + "  $ überwiesen!!");
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 255, 0) + player.Username + " hat dir " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            player.Reallife.Bank -= value;
                            target.Reallife.Bank += value;
                            vnx_stored_files.logfile.WriteLogs("bank", "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] hat [ " + target.SocialClubId + " ]" + "[ " + target.Username + " ] " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            if (value >= 150000)
                            {
                                Admin.sendAdminNotification(player.Username + " hat " + target.Username + " " + value + " $ Geld überwiesen! ( Grund : " + reason + ")");
                            }
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler exestiert nicht!");
                    }
                }
            }
            catch { }
        }
    }
}
