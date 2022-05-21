using System;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.quests;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.bank
{
    public class Bank : IScript
    {

        [VenoXRemoteEvent("ATM_MONEY_BUTTON_TRIGGER")]
        public static void ATM_BUTTON_TRIGGERED(VnXPlayer player, string button, string v)
        {
            try
            {
                int value = int.Parse(v);
                if (value < 0) return;
                switch (button)
                {
                    case "einzahlen" when value != 0:
                    {
                        if (value >= 1000)
                        {
                            if (Quests.QuestDict.ContainsKey(Quests.QuestAtmEinzahlen))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestAtmEinzahlen]);
                        }
                        if (value > player.Reallife.Money)
                        {
                            Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You don't have that much money!");
                            return;
                        }

                        player.Reallife.Bank += value;
                        player.Reallife.Money -= value;
                        Task.Run(async() =>
                        {
                            string[] translatedText = new[]
                            {
                                await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, "You have"),
                                RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $ ",
                                RageApi.GetHexColorcode(255, 255, 255) + await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, "deposited into your bank account.")
                            };
                            player.SendChatMessage(translatedText[0] + translatedText[1] + translatedText[2]);
                            Logfile.WriteLogs("bank", "[ " + player.CharacterUsername + " ] deposited " + value + " $!");
                        });
                        break;
                    }
                    case "einzahlen":
                        Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Invalid input!");
                        break;
                    case "auszahlen" when value != 0:
                    {
                        if (value > player.Reallife.Bank)
                            Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You don't have that much money!");
                        
                        else
                        {
                            player.Reallife.Bank -= value;
                            player.Reallife.Money += value;
                            Task.Run(async() =>
                            {
                                string[] translatedText = new[]
                                {
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, "You have"),
                                    RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $ ",
                                    RageApi.GetHexColorcode(255, 255, 255) + await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, "paid off from your bank account.")
                                };
                                player.SendChatMessage(translatedText[0] + translatedText[1] + translatedText[2]);
                                Logfile.WriteLogs("bank", "[ " + player.CharacterUsername + " ] paid off " + value + " $!");
                            });
                        }

                        break;
                    }
                    case "auszahlen":
                        Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Invalid input!");
                        break;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [VenoXRemoteEvent("ATM_MONEY_SEND_TO")]
        public static void SendToPlayerMoney_ATM(VnXPlayer player, string name, string svalue, string reason)
        {
            try
            {
                int value = int.Parse(svalue);
                if (value < 0)
                {
                    return;
                }
                if (player.Reallife.Bank < value)
                {
                    Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You don't have that much money!");
                }
                else
                {
                    bool characterExists = Database.FindCharacterByName(name);
                    if (characterExists)
                    {
                        string playerNameNormal = Database.GetAccountPlayerName(Database.GetCharacterSocialName(name));
                        VnXPlayer target = RageApi.GetPlayerFromName(playerNameNormal);
                        if (target is not {Playing: true})
                            Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The player is not online!");
                        else
                        {
                            Task.Run(async() =>
                            {
                                string[] translatedText1 = new[]
                                {
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, "You Have"),
                                    RageApi.GetHexColorcode(0, 200, 255) + " " + player.CharacterUsername,
                                    RageApi.GetHexColorcode(255, 255, 255) + " " + value,
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages) player.Language, " $ transferred!!")
                                };
                                player.SendChatMessage(translatedText1[0] + translatedText1[1] + translatedText1[2] + RageApi.GetHexColorcode(0, 200, 255) +translatedText1[3]);

                                string[] translatedText2 = new[]
                                {
                                    RageApi.GetHexColorcode(0, 255, 0) + player.CharacterUsername,
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language,"transferred"),
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language,"to you."),
                                    await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language,"Reason :"),
                                };
                                target.SendChatMessage(translatedText2[0] + " " + translatedText2[1] + " " + value + " $ " + translatedText2[2] + "! ( " + translatedText2[3] + " " + reason + ")");
                                
                                if (value >= 150000)
                                    foreach (VnXPlayer otherAdmins in _RootCore_.VenoX.GetAllPlayers().Where(otherAdmins => otherAdmins.AdminRank >= Constants.AdminlvlTsupporter))
                                        otherAdmins.SendChatMessage(RageApi.GetHexColorcode(150, 150, 0) + player.CharacterUsername + " " + translatedText2[1] + " " + value + " $ " + target.CharacterUsername + "! ( " + translatedText2[3] + " " + reason + ")");
                                
                            });
                            player.Reallife.Bank -= value;
                            target.Reallife.Bank += value;
                            Logfile.WriteLogs("bank", "[ " + player.CharacterUsername + " ] transferred " + "[ " + target.CharacterUsername + " ] " + value + " $! ( Reason : " + reason + ")");
                        }
                    }
                    else
                    {
                        Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The player does not exist!");
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
