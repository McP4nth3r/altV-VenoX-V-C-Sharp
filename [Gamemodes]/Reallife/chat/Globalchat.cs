using AltV.Net;
using AltV.Net.Resources.Chat.Api;
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
        public static string Global_Admin_Status = "Angeschaltet";
        [Command("global", true)]
        public static void SendGlobalMessage(VnXPlayer player, string text)
        {
            try
            {
                if (Global_Admin_Status == "Angeschaltet")
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
                            //if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) > 6000)
                            //{
                            if (onlinespieler.Settings.ShowGlobalChat == 1)
                            {
                                if (pl_adminlvl > 0)
                                {
                                    onlinespieler.SendChatMessage(BlueColor + "[GLOBAL]" + Clantag + player.Username + " : " + text);
                                    continue;
                                }
                                onlinespieler.SendChatMessage(BlueColor + "[GLOBAL]" + RageAPI.GetHexColorcode(255, 255, 255) + player.Username + " : " + text);

                            }
                            //}
                        }
                        vnx_stored_files.logfile.WriteLogs("globalchat", "[" + player.Username + "] : " + text);
                    }
                    else
                    {
                        player.SendTranslatedChatMessage("Du hast nicht genug Spielstunden ( Mind. 30 ) !");
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage("Der Globalchat ist augeschaltet!");
                }
            }
            catch { }
        }

        [Command("global_aus")]
        public async void setGlobal_status_on(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    if (Global_Admin_Status == "Ausgeschaltet") { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Ausgeschaltet";
                    foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                    {
                        string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat augeschaltet!");
                        onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " " + Translatedtext);
                    }
                }
            }
            catch { }
        }

        [Command("global_an")]
        public async void setGlobal_status_off(VnXPlayer player)
        {
            try
            {
                if (player.AdminRank >= 4)
                {
                    if (Global_Admin_Status == "Angeschaltet") { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Angeschaltet";
                    foreach (VnXPlayer onlinespieler in VenoX.GetAllPlayers().ToList())
                    {
                        string Translatedtext = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)onlinespieler.Language, "hat den Globalchat angeschaltet!");
                        onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " " + Translatedtext);
                    }
                }
            }
            catch { }
        }
    }
}
