using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.Chat
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
                    if (player.Played >= 1800)
                    {
                        int playerAdminRank = player.AdminRank;
                        string adminClanTag = Admin.GetRgbaedClantag(playerAdminRank);
                        if (player.Settings.ShowGlobalChat == 0)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Error, "You have deactivated the Globalchat! Press F3 to activate it!");
                            return;
                        }
                        string blueColor = RageApi.GetHexColorcode(0, 200, 255);
                        string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                        foreach (var vnXPlayer in VenoX.GetAllPlayers().ToList().Where(xPlayer => xPlayer.Settings.ShowGlobalChat == 1))
                        {
                            if (playerAdminRank > 0)
                            {
                                vnXPlayer.SendChatMessage(blueColor + "[GLOBAL]" + adminClanTag + player.Username + " : " + text);
                                continue;
                            }
                            vnXPlayer.SendChatMessage(blueColor + "[GLOBAL]" + whiteColor + player.Username + " : " + text);
                        }
                        Logfile.WriteLogs("globalchat", player.Username + " : " + text);
                    }
                    else
                    {
                        Main.DrawTranslatedNotification(player, Main.Types.Error, "You don't have enough game hours (at least 30h) !");
                    }
                }
                else
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "The Globalchat is switched off!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
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
                        if (GlobalAdminStatus == state) { Main.DrawTranslatedNotification(player, Main.Types.Error, "The Global chat is already turned on!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer xPlayer in VenoX.GetAllPlayers().ToList())
                        {
                            string translatedTextAsync = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)xPlayer.Language, "turned off the globalchat!");
                            xPlayer.SendChatMessage(RageApi.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " " + translatedTextAsync);
                        }
                    }
                    else
                    {
                        if (GlobalAdminStatus == state) { Main.DrawTranslatedNotification(player, Main.Types.Error, "The Global chat is already turned on!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer xPlayer in VenoX.GetAllPlayers().ToList())
                        {
                            string translatedTextAsync = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)xPlayer.Language, "turned off the globalchat!");
                            xPlayer.SendChatMessage(RageApi.GetHexColorcode(0, 125, 0) + "[VnX]" + player.Username + " " + translatedTextAsync);
                        }
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("lang", greedyArg: true, aliases: new[] { "language" })]
        public static void LanguageChat(VnXPlayer player, string text)
        {
            try
            {

                if (player.Played < 1800)
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "You don't have enough game hours (at least 30h) !");
                    return;
                }
                if (GlobalAdminStatus == 0)
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "The Globalchat is switched off!");
                    return;
                }
                int plAdminlvl = player.AdminRank;
                string clantag = Admin.GetRgbaedClantag(plAdminlvl);
                string redColor = RageApi.GetHexColorcode(175, 0, 0);
                string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                string languagePair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                foreach (var vnXPlayer in VenoX.GetAllPlayers().ToList().Where(xPlayer => xPlayer.Settings.ShowGlobalChat == 1 && xPlayer.Language == player.Language))
                {
                    if (plAdminlvl > 0)
                    {
                        vnXPlayer.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + clantag + player.Username + " : " + text);
                        continue;
                    }
                    vnXPlayer.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + whiteColor + player.Username + " : " + text);
                }
                Logfile.WriteLogs("language-" + languagePair.ToUpper(), player.Username + " : " + text);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
