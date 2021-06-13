using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Notifications_;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.quests
{
    public class Quests
    {
        public const int QuestVenoxrentals = 0;
        public const int QuestStadthalle = 1;
        public const int QuestPerso = 2;
        public const int QuestAutoschein = 3;
        public const int QuestAtmEinzahlen = 4;
        public const int QuestGasSnack = 5;
        public const int QuestAutokaufen = 6;
        public const int QuestGet100K = 7;
        public const int QuestGetweaponlicense = 8;
        public const int QuestGetadvancedrifle = 9;
        public const int QuestStartShoprob = 10;

        public static Dictionary<int, QuestModel> QuestDict = new Dictionary<int, QuestModel>
        {
            {   QuestVenoxrentals, new QuestModel{ Id = QuestVenoxrentals, Text = "Willkommen auf VenoX - V,<br>begib dich zu VenoX Rentals um<br>deine Erste Belohnung zu bekommen!", Money = 1350 } },
            {   QuestStadthalle, new QuestModel{ Id = QuestStadthalle,Text = "Asylant? Kein Problem!<br>Begib dich zur Stadthalle!<br>Drücke E um die Stadthalle zu betreten.", Money = 3500 } },
            {   QuestPerso, new QuestModel{ Id = QuestPerso,Text = "Kauf dir einen Personalausweis!", Money = 6535 } },
            {   QuestAutoschein, new QuestModel{ Id = QuestAutoschein,Text = "Nie wieder Bus Fahren!<br>Bestehe die Führerschein Prüfung!", Money = 5000 } },
            {   QuestAtmEinzahlen, new QuestModel{ Id = QuestAtmEinzahlen,Text = "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.", Money = 4000 } },
            {   QuestGasSnack, new QuestModel{ Id = QuestGasSnack,Text = "Du bist hungrig!<br>Kaufe dir einen Snack bei der Tankstelle!", Money = 1000 } },
            {   QuestAutokaufen, new QuestModel{ Id = QuestAutokaufen,Text = "One Car One Dream!<br>Kaufe dir dein erstes Auto!", Money = 10000 } },
            {   QuestGet100K, new QuestModel{ Id = QuestGet100K,Text = "Kauf dir einen Benzinkannister.", Money = 5000 } },
            {   QuestGetweaponlicense, new QuestModel{Id = QuestGetweaponlicense, Text = "Waffen sind wichtig.....!!!<br>Besorge dir einen Waffenschein ( ab 3 H Verfügbar ).", Money = 10000 } },
            {   QuestGetadvancedrifle, new QuestModel{ Id = QuestGetadvancedrifle,Text = "Ein Kampfgewehr? Not Bad...<br>Besorge dir eine Advanced Rifle.", Money = 15000 } },
            {   QuestStartShoprob, new QuestModel{ Id = QuestStartShoprob,Text = "Es wird Zeit etwas Geld zu verdienen...<br>Raube einen 24/7 Shop aus!", Money = 10000 } }
        };

        public static void OnQuestDone(VnXPlayer player, QuestModel quest)
        {
            try
            {
                if (player.Reallife.Quests != quest.Id) return;
                player.Reallife.Quests += 1;
                player.Reallife.Money += quest.Money;
                Main.DrawNotification(player, Main.Types.Info, "Quest Done.");
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static QuestModel GetCurrentQuest(VnXPlayer player)
        {
            try
            {
                if (QuestDict.ContainsKey(player.Reallife.Quests))
                    return QuestDict[player.Reallife.Quests];
                return null;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
        public static async void ShowCurrentQuest(VnXPlayer player)
        {
            try
            {
                QuestModel questClass = GetCurrentQuest(player);
                if (questClass is null) VenoX.TriggerClientEvent(player, "Quest:SetCurrentQuest", await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Momentan sind keine weiteren Quests vorhanden!"), "", 0);
                else VenoX.TriggerClientEvent(player, "Quest:SetCurrentQuest", await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, questClass.Text), questClass.Money, player.Reallife.Quests);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
