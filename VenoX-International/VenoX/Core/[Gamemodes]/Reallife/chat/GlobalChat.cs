using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Admin_;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.chat
{
    public class GlobalChat : IScript
    {
        public static int GlobalAdminStatus = 1; // 1 = enabled | 0 = disabled.
        [Command("global", true)]
        public static void SendGlobalMessage(VnXPlayer player, string text)
        {
            try
            {
                if (GlobalAdminStatus == 1)
                {
                    if (player.PlayTime >= 1800)
                    {
                        int playerAdminRank = player.AdminRank;
                        string adminClanTag = Admin.GetRgbaedClantag(playerAdminRank);
                        if (player.Settings.ShowGlobalChat == 0)
                        {
                            Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You have deactivated the Globalchat! Press F3 to activate it!");
                            return;
                        }
                        string blueColor = RageApi.GetHexColorcode(0, 200, 255);
                        string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                        foreach (VnXPlayer vnXPlayer in _RootCore_.VenoX.GetAllPlayers().ToList().Where(xPlayer => xPlayer.Settings.ShowGlobalChat == 1))
                        {
                            if (playerAdminRank > 0)
                            {
                                vnXPlayer.SendChatMessage(blueColor + "[GLOBAL]" + adminClanTag + player.CharacterUsername + " : " + text);
                                continue;
                            }
                            vnXPlayer.SendChatMessage(blueColor + "[GLOBAL]" + whiteColor + player.CharacterUsername + " : " + text);
                        }
                        Logfile.WriteLogs("globalchat", player.CharacterUsername + " : " + text);
                    }
                    else
                    {
                        Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You don't have enough game hours (at least 30h) !");
                    }
                }
                else
                {
                    Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The Globalchat is switched off!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("enablegc")]
        public async void setGlobal_status_on(VnXPlayer player, int state)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlAdministrator)
                {
                    if (state == 0)
                    {
                        if (GlobalAdminStatus == state) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The Global chat is already turned on!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer xPlayer in _RootCore_.VenoX.GetAllPlayers().ToList())
                        {
                            string translatedTextAsync = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)xPlayer.Language, "turned off the globalchat!");
                            xPlayer.SendChatMessage(RageApi.GetHexColorcode(125, 0, 0) + "[VnX]" + player.CharacterUsername + " " + translatedTextAsync);
                        }
                    }
                    else
                    {
                        if (GlobalAdminStatus == state) { Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The Global chat is already turned on!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer xPlayer in _RootCore_.VenoX.GetAllPlayers().ToList())
                        {
                            string translatedTextAsync = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)xPlayer.Language, "turned off the globalchat!");
                            xPlayer.SendChatMessage(RageApi.GetHexColorcode(0, 125, 0) + "[VnX]" + player.CharacterUsername + " " + translatedTextAsync);
                        }
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("lang", greedyArg: true, aliases: new[] { "language" })]
        public static void LanguageChat(VnXPlayer player, string text)
        {
            try
            {

                if (player.PlayTime < 1800)
                {
                    Notification.DrawTranslatedNotification(player, Notification.Types.Error, "You don't have enough game hours (at least 30h) !");
                    return;
                }
                if (GlobalAdminStatus == 0)
                {
                    Notification.DrawTranslatedNotification(player, Notification.Types.Error, "The Globalchat is switched off!");
                    return;
                }
                int plAdminlvl = player.AdminRank;
                string clantag = Admin.GetRgbaedClantag(plAdminlvl);
                string redColor = RageApi.GetHexColorcode(175, 0, 0);
                string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                string languagePair = global::VenoX.Core._Language_.Main.GetClientLanguagePair((global::VenoX.Core._Language_.Constants.Languages)player.Language);
                foreach (VnXPlayer vnXPlayer in _RootCore_.VenoX.GetAllPlayers().ToList().Where(xPlayer => xPlayer.Settings.ShowGlobalChat == 1 && xPlayer.Language == player.Language))
                {
                    if (plAdminlvl > 0)
                    {
                        vnXPlayer.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + clantag + player.CharacterUsername + " : " + text);
                        continue;
                    }
                    vnXPlayer.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + whiteColor + player.CharacterUsername + " : " + text);
                }
                Logfile.WriteLogs("language-" + languagePair.ToUpper(), player.CharacterUsername + " : " + text);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
