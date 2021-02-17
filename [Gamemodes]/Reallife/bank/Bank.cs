using System;
using AltV.Net;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Notifications_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.bank
{
    public class Bank : IScript
    {

        [VenoXRemoteEvent("ATM_MONEY_BUTTON_TRIGGER")]
        public static void ATM_BUTTON_TRIGGERED(VnXPlayer player, string button, string v)
        {
            try
            {
                int value = int.Parse(v);
                if (value < 0) { return; }
                switch (button)
                {
                    case "einzahlen" when value != 0:
                    {
                        if (value >= 1000)
                        {
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_ATM_EINZAHLEN);
                            if (Quests.QuestDict.ContainsKey(Quests.QuestAtmEinzahlen))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestAtmEinzahlen]);
                        }
                        if (value > player.Reallife.Money)
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Soviel Geld hast du nicht!");
                            return;
                        }

                        player.Reallife.Bank += value;
                        player.Reallife.Money -= value;
                        player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageApi.GetHexColorcode(255, 255, 255) + " eingezahlt!");
                        Logfile.WriteLogs("bank", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] hat " + value + " $ eingezahlt!");
                        break;
                    }
                    case "einzahlen":
                        Main.DrawNotification(player, Main.Types.Error, "Ungültige Eingabe!");
                        break;
                    case "auszahlen" when value != 0:
                    {
                        if (value > player.Reallife.Bank)
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Soviel Geld hast du nicht!");
                        }
                        else
                        {
                            player.Reallife.Bank -= value;
                            player.Reallife.Money += value;
                            player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $" + RageApi.GetHexColorcode(255, 255, 255) + " ausgezahlt!");
                            Logfile.WriteLogs("bank", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] hat " + value + " $ aussgezahlt!");
                        }

                        break;
                    }
                    case "auszahlen":
                        Main.DrawNotification(player, Main.Types.Error, "Ungültige Eingabe!");
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("ATM_MONEY_SEND_TO")]
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
                    Main.DrawNotification(player, Main.Types.Error, "Soviel Geld hast du nicht!");
                }
                else
                {
                    bool charakterexestiert = Database.Database.FindCharacterByName(name);
                    if (charakterexestiert)
                    {
                        string spielerNameNormal = Database.Database.GetAccountSpielerName(Database.Database.GetCharakterSocialName(name));
                        VnXPlayer target = RageApi.GetPlayerFromName(spielerNameNormal);
                        if (target == null || target.Playing != true)
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Der Spieler ist nicht Online!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 200, 255) + " " + spielerNameNormal + " " + RageApi.GetHexColorcode(255, 255, 255) + +value + "  " + RageApi.GetHexColorcode(0, 200, 255) + "  $ überwiesen!!");
                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 255, 0) + player.Username + " hat dir " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            player.Reallife.Bank -= value;
                            target.Reallife.Bank += value;
                            Logfile.WriteLogs("bank", "[ " + player.SocialClubId + " ]" + "[ " + player.Username + " ] hat [ " + target.SocialClubId + " ]" + "[ " + target.Username + " ] " + value + " $ überwiesen! ( Grund : " + reason + ")");
                            if (value >= 150000)
                            {
                                Admin.SendAdminNotification(player.Username + " hat " + target.Username + " " + value + " $ Geld überwiesen! ( Grund : " + reason + ")");
                            }
                        }
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Der Spieler exestiert nicht!");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
