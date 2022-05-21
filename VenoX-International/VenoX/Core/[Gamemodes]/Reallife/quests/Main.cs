using System;
using System.Collections.Generic;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.quests
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
            {   QuestVenoxrentals, new QuestModel{ Id = QuestVenoxrentals, Text = "Welcome to VenoX - V! Go to VenoX Rentals to get your first reward!", Money = 1350 } },
            {   QuestStadthalle, new QuestModel{ Id = QuestStadthalle,Text = "A refugee? Don't worry! Go to the town hall!", Money = 3500 } },
            {   QuestPerso, new QuestModel{ Id = QuestPerso,Text = "Apply for an identity card!", Money = 6535 } },
            {   QuestAutoschein, new QuestModel{ Id = QuestAutoschein,Text = "Never ride a bus again! Pass the driver's license exam!", Money = 5000 } },
            {   QuestAtmEinzahlen, new QuestModel{ Id = QuestAtmEinzahlen,Text = "Deposit $1000 at the ATM!", Money = 4000 } },
            {   QuestGasSnack, new QuestModel{ Id = QuestGasSnack,Text = "You're hungry! Buy a snack at the gas station!", Money = 1000 } },
            {   QuestAutokaufen, new QuestModel{ Id = QuestAutokaufen,Text = "A car is a dream! Buy your first car!", Money = 10000 } },
            {   QuestGet100K, new QuestModel{ Id = QuestGet100K,Text = "Buy yourself a gasoline cannister.", Money = 5000 } },
            {   QuestGetweaponlicense, new QuestModel{Id = QuestGetweaponlicense, Text = "Weapons are important! Get a weapon license (available from three hours of play).", Money = 10000 } },
            {   QuestGetadvancedrifle, new QuestModel{ Id = QuestGetadvancedrifle,Text = "A combat rifle? Not bad... Get an Advanced Rifle.", Money = 15000 } },
            {   QuestStartShoprob, new QuestModel{ Id = QuestStartShoprob,Text = "It's time to make some money... Rob a 24/7 shop!", Money = 10000 } }
        };

        public static void OnQuestDone(VnXPlayer player, QuestModel quest)
        {
            try
            {
                if (player.Reallife.Quests != quest.Id) return;
                player.Reallife.Quests += 1;
                player.Reallife.Money += quest.Money;
                Notification.DrawNotification(player, Notification.Types.Info, "Quest Done.");
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        private static QuestModel GetCurrentQuest(VnXPlayer player)
        {
            try
            {
                return QuestDict.ContainsKey(player.Reallife.Quests) ? QuestDict[player.Reallife.Quests] : null;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return null; }
        }
        public static async void ShowCurrentQuest(VnXPlayer player)
        {
            try
            {
                QuestModel questClass = GetCurrentQuest(player);
                if (questClass is null) 
                    _RootCore_.VenoX.TriggerClientEvent(player, "Quest:SetCurrentQuest", await _Language_.Main.GetTranslatedTextAsync((_Language_.Constants.Languages)player.Language, "There are no other quests available at the moment!"), "", 0);
                else _RootCore_.VenoX.TriggerClientEvent(player, "Quest:SetCurrentQuest", await _Language_.Main.GetTranslatedTextAsync((_Language_.Constants.Languages)player.Language, questClass.Text), questClass.Money, player.Reallife.Quests);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
