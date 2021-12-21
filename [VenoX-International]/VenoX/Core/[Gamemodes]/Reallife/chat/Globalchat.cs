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
    public class Globalchat : IScript
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
                        int plAdminlvl = player.AdminRank;
                        string clantag = Admin.GetRgbaedClantag(plAdminlvl);
                        if (player.Settings.ShowGlobalChat == 0)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Error, "Du hast den Globalchat deaktiviert! Drücke F3 um ihn zu Aktivieren!");
                            return;
                        }
                        string blueColor = RageApi.GetHexColorcode(0, 200, 255);
                        string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            if (onlinespieler.Settings.ShowGlobalChat == 1)
                            {
                                if (plAdminlvl > 0)
                                {
                                    onlinespieler.SendChatMessage(blueColor + "[GLOBAL]" + clantag + player.Username + " : " + text);
                                    continue;
                                }
                                onlinespieler.SendChatMessage(blueColor + "[GLOBAL]" + whiteColor + player.Username + " : " + text);
                            }
                        }
                        Logfile.WriteLogs("globalchat", player.Username + " : " + text);
                    }
                    else
                    {
                        Main.DrawTranslatedNotification(player, Main.Types.Error, "Du hast nicht genug Spielstunden ( Mindestens 30h ) !");
                    }
                }
                else
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "Der Globalchat ist augeschaltet!");
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
                        if (GlobalAdminStatus == state) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            string translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat augeschaltet!");
                            onlinespieler.SendChatMessage(RageApi.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " " + translatedtext);
                        }
                    }
                    else
                    {
                        if (GlobalAdminStatus == state) { Main.DrawTranslatedNotification(player, Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                        GlobalAdminStatus = state;
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            string translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat angeschaltet!");
                            onlinespieler.SendChatMessage(RageApi.GetHexColorcode(0, 125, 0) + "[VnX]" + player.Username + " " + translatedtext);
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
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "Du hast nicht genug Spielstunden ( Mindestens 30h ) !");
                    return;
                }
                if (GlobalAdminStatus == 0)
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "Der Globalchat ist augeschaltet!");
                    return;
                }
                int plAdminlvl = player.AdminRank;
                string clantag = Admin.GetRgbaedClantag(plAdminlvl);
                string redColor = RageApi.GetHexColorcode(175, 0, 0);
                string whiteColor = RageApi.GetHexColorcode(255, 255, 255);
                string languagePair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                foreach (VnXPlayer otherplayers in VenoX.GetAllPlayers().ToList())
                {
                    if (otherplayers.Settings.ShowGlobalChat == 1 && otherplayers.Language == player.Language)
                    {
                        if (plAdminlvl > 0)
                        {
                            otherplayers.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + clantag + player.Username + " : " + text);
                            continue;
                        }
                        otherplayers.SendChatMessage(redColor + "[Language-" + languagePair.ToUpper() + "]" + whiteColor + player.Username + " : " + text);
                    }
                }
                Logfile.WriteLogs("language-" + languagePair.ToUpper(), player.Username + " : " + text);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
