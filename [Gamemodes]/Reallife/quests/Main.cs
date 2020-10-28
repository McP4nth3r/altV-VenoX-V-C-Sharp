using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.quests
{
    public class Quests
    {
        public const int QUEST_VENOXRENTALS = 0;
        public const int QUEST_STADTHALLE = 1;
        public const int QUEST_PERSO = 2;
        public const int QUEST_AUTOSCHEIN = 3;
        public const int QUEST_ATM_EINZAHLEN = 4;
        public const int QUEST_GAS_SNACK = 5;
        public const int QUEST_AUTOKAUFEN = 6;
        public const int QUEST_GET100K = 7;
        public const int QUEST_GETWEAPONLICENSE = 8;
        public const int QUEST_GETADVANCEDRIFLE = 9;
        public const int QUEST_START_SHOPROB = 10;

        public static Dictionary<int, QuestModel> QuestDict = new Dictionary<int, QuestModel>
        {
            {   QUEST_VENOXRENTALS, new QuestModel{ Text = "Willkommen auf VenoX - V,<br>begib dich zu VenoX Rentals um<br>deine Erste Belohnung zu bekommen!", Money = 1350 } },
            {   QUEST_STADTHALLE, new QuestModel{ Text = "Asylant? Kein Problem!<br>Begib dich zur Stadthalle!<br>Drücke E um die Stadthalle zu betreten.", Money = 3500 } },
            {   QUEST_PERSO, new QuestModel{ Text = "Kauf dir einen Personalausweis!", Money = 6535 } },
            {   QUEST_AUTOSCHEIN, new QuestModel{ Text = "Nie wieder Bus Fahren!<br>Bestehe die Führerschein Prüfung!", Money = 5000 } },
            {   QUEST_ATM_EINZAHLEN, new QuestModel{ Text = "Sparkasse is on the Way!<br>Zahle 1000$ beim ATM ein!<br>Drücke E um einen Bankautomaten zu nutzen.", Money = 4000 } },
            {   QUEST_GAS_SNACK, new QuestModel{ Text = "Du bist hungrig!<br>Kaufe dir einen Snack bei der Tankstelle!", Money = 1000 } },
            {   QUEST_AUTOKAUFEN, new QuestModel{ Text = "One Car One Dream!<br>Kaufe dir dein erstes Auto!", Money = 10000 } },
            {   QUEST_GET100K, new QuestModel{ Text = "Kauf dir einen Benzinkannister.", Money = 5000 } },
            {   QUEST_GETWEAPONLICENSE, new QuestModel{ Text = "Waffen sind wichtig.....!!!<br>Besorge dir einen Waffenschein ( ab 3 H Verfügbar ).", Money = 10000 } },
            {   QUEST_GETADVANCEDRIFLE, new QuestModel{ Text = "Ein Kampfgewehr? Not Bad...<br>Besorge dir eine Advanced Rifle.", Money = 15000 } },
            {   QUEST_START_SHOPROB, new QuestModel{ Text = "Es wird Zeit etwas Geld zu verdienen...<br>Raube einen 24/7 Shop aus!", Money = 10000 } }
        };

        public static void OnQuestDone(VnXPlayer player, QuestModel quest)
        {
            try
            {
                player.Reallife.Quests += 1;
                player.Reallife.Money += quest.Money;
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Quest Done.");
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static QuestModel GetCurrentQuest(VnXPlayer player)
        {
            try
            {
                if (QuestDict.ContainsKey(player.Reallife.Quests))
                    return QuestDict[player.Reallife.Quests];
                return null;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
        public static void ShowCurrentQuest(VnXPlayer player)
        {
            try
            {
                QuestModel questClass = GetCurrentQuest(player);
                if (questClass is null) player.Emit("Quest:SetCurrentQuest", "Momentan sind keine weiteren Quests vorhanden!", "", player.Reallife.Quests);
                else player.Emit("Quest:SetCurrentQuest", questClass.Text, questClass.Money, player.Reallife.Quests);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
