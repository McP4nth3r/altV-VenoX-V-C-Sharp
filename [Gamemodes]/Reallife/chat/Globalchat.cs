using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Linq;
using VenoXV._Admin_;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Chat
{
    public class Globalchat : IScript
    {
        public static int Global_Admin_Status = 1; // 1 = enabled | 0 = disabled.
        [Command("global", true)]
        public static void SendGlobalMessage(VnXPlayer player, string text)
        {
            try
            {
                if (Global_Admin_Status == 1)
                {
                    if (player.Played >= 1800)
                    {
                        int pl_adminlvl = player.AdminRank;
                        string Clantag = Admin.GetRgbaedClantag(pl_adminlvl);
                        if (player.Settings.ShowGlobalChat == 0)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast den Globalchat deaktiviert! Drücke F3 um ihn zu Aktivieren!");
                            return;
                        }
                        string BlueColor = RageAPI.GetHexColorcode(0, 200, 255);
                        string WhiteColor = RageAPI.GetHexColorcode(255, 255, 255);
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            if (onlinespieler.Settings.ShowGlobalChat == 1)
                            {
                                if (pl_adminlvl > 0)
                                {
                                    onlinespieler.SendChatMessage(BlueColor + "[GLOBAL]" + Clantag + player.Username + " : " + text);
                                    continue;
                                }
                                onlinespieler.SendChatMessage(BlueColor + "[GLOBAL]" + WhiteColor + player.Username + " : " + text);
                            }
                        }
                        vnx_stored_files.logfile.WriteLogs("globalchat", player.Username + " : " + text);
                    }
                    else
                    {
                        _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Spielstunden ( Mindestens 30h ) !");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Der Globalchat ist augeschaltet!");
                }
            }
            catch { }
        }

        [Command("enablegc")]
        public async void setGlobal_status_on(VnXPlayer player, int state)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    if (state == 0)
                    {
                        if (Global_Admin_Status == state) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                        Global_Admin_Status = state;
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat augeschaltet!");
                            onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " " + Translatedtext);
                        }
                    }
                    else
                    {
                        if (Global_Admin_Status == state) { _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                        Global_Admin_Status = state;
                        foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                        {
                            string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat angeschaltet!");
                            onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + "[VnX]" + player.Username + " " + Translatedtext);
                        }
                    }
                }
            }
            catch { }
        }

        [Command("lang", greedyArg: true, aliases: new string[] { "language" })]
        public static void LanguageChat(VnXPlayer player, string text)
        {
            try
            {

                if (player.Played < 1800)
                {
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Spielstunden ( Mindestens 30h ) !");
                    return;
                }
                if (Global_Admin_Status == 0)
                {
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Der Globalchat ist augeschaltet!");
                    return;
                }
                int pl_adminlvl = player.AdminRank;
                string Clantag = Admin.GetRgbaedClantag(pl_adminlvl);
                string RedColor = RageAPI.GetHexColorcode(175, 0, 0);
                string WhiteColor = RageAPI.GetHexColorcode(255, 255, 255);
                string LanguagePair = _Language_.Main.GetClientLanguagePair((_Language_.Main.Languages)player.Language);
                foreach (VnXPlayer otherplayers in VenoX.GetAllPlayers().ToList())
                {
                    if (otherplayers.Settings.ShowGlobalChat == 1 && otherplayers.Language == player.Language)
                    {
                        if (pl_adminlvl > 0)
                        {
                            otherplayers.SendChatMessage(RedColor + "[Language-" + LanguagePair.ToUpper() + "]" + Clantag + player.Username + " : " + text);
                            continue;
                        }
                        otherplayers.SendChatMessage(RedColor + "[Language-" + LanguagePair.ToUpper() + "]" + WhiteColor + player.Username + " : " + text);
                    }
                }
                vnx_stored_files.logfile.WriteLogs("language-" + LanguagePair.ToUpper(), player.Username + " : " + text);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
