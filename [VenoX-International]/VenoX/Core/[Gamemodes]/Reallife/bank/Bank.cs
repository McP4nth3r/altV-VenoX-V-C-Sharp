using System;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.quests;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Notifications_;
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
                            Main.DrawTranslatedNotification(player, Main.Types.Error, "You don't have that much money!");
                            return;
                        }

                        player.Reallife.Bank += value;
                        player.Reallife.Money -= value;
                        Task.Run(async() =>
                        {
                            string[] translatedText = new[]
                            {
                                await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, "You have"),
                                RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $ ",
                                RageApi.GetHexColorcode(255, 255, 255) + await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, "deposited into your bank account.")
                            };
                            player.SendChatMessage(translatedText[0] + translatedText[1] + translatedText[2]);
                            Logfile.WriteLogs("bank", "[ " + player.Username + " ] deposited " + value + " $!");
                        });
                        break;
                    }
                    case "einzahlen":
                        Main.DrawTranslatedNotification(player, Main.Types.Error, "Invalid input!");
                        break;
                    case "auszahlen" when value != 0:
                    {
                        if (value > player.Reallife.Bank)
                            Main.DrawTranslatedNotification(player, Main.Types.Error, "You don't have that much money!");
                        
                        else
                        {
                            player.Reallife.Bank -= value;
                            player.Reallife.Money += value;
                            Task.Run(async() =>
                            {
                                string[] translatedText = new[]
                                {
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, "You have"),
                                    RageApi.GetHexColorcode(0, 200, 255) + " " + value + " $ ",
                                    RageApi.GetHexColorcode(255, 255, 255) + await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, "paid off from your bank account.")
                                };
                                player.SendChatMessage(translatedText[0] + translatedText[1] + translatedText[2]);
                                Logfile.WriteLogs("bank", "[ " + player.Username + " ] paid off " + value + " $!");
                            });
                        }

                        break;
                    }
                    case "auszahlen":
                        Main.DrawTranslatedNotification(player, Main.Types.Error, "Invalid input!");
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
                int value = int.Parse(svalue);
                if (value < 0)
                {
                    return;
                }
                if (player.Reallife.Bank < value)
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "You don't have that much money!");
                }
                else
                {
                    bool characterExists = Database.Database.FindCharacterByName(name);
                    if (characterExists)
                    {
                        string playerNameNormal = Database.Database.GetAccountPlayerName(Database.Database.GetCharacterSocialName(name));
                        VnXPlayer target = RageApi.GetPlayerFromName(playerNameNormal);
                        if (target is not {Playing: true})
                            Main.DrawTranslatedNotification(player, Main.Types.Error, "The player is not online!");
                        else
                        {
                            Task.Run(async() =>
                            {
                                string[] translatedText1 = new[]
                                {
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, "You Have"),
                                    RageApi.GetHexColorcode(0, 200, 255) + " " + player.Username,
                                    RageApi.GetHexColorcode(255, 255, 255) + " " + value,
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages) player.Language, " $ transferred!!")
                                };
                                player.SendChatMessage(translatedText1[0] + translatedText1[1] + translatedText1[2] + RageApi.GetHexColorcode(0, 200, 255) +translatedText1[3]);

                                string[] translatedText2 = new[]
                                {
                                    RageApi.GetHexColorcode(0, 255, 0) + player.Username,
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language,"transferred"),
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language,"to you."),
                                    await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language,"Reason :"),
                                };
                                target.SendChatMessage(translatedText2[0] + " " + translatedText2[1] + " " + value + " $ " + translatedText2[2] + "! ( " + translatedText2[3] + " " + reason + ")");
                                
                                if (value >= 150000)
                                    foreach (var otherAdmins in VenoX.GetAllPlayers().Where(otherAdmins => otherAdmins.AdminRank >= Constants.AdminlvlTsupporter))
                                        otherAdmins.SendChatMessage(RageApi.GetHexColorcode(150, 150, 0) + player.Username + " " + translatedText2[1] + " " + value + " $ " + target.Username + "! ( " + translatedText2[3] + " " + reason + ")");
                                
                            });
                            player.Reallife.Bank -= value;
                            target.Reallife.Bank += value;
                            Logfile.WriteLogs("bank", "[ " + player.Username + " ] transferred " + "[ " + target.Username + " ] " + value + " $! ( Reason : " + reason + ")");
                        }
                    }
                    else
                    {
                        Main.DrawTranslatedNotification(player, Main.Types.Error, "The player does not exist!");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
