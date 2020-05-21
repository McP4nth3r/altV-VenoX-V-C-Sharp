using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.chat
{
    public class Globalchat : IScript
    {
        public static string Global_Admin_Status = "Angeschaltet";


        [Command("global", true)]
        public static void SendGlobalMessage(Client player, string text)
        {
            try
            {
                if (Global_Admin_Status == "Angeschaltet")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) >= 1800)
                    {
                        int pl_adminlvl = player.AdminRank;
                        string Clantag = admin.Admin.GetRgbaedClantag(pl_adminlvl);
                        if (player.vnxGetElementData<string>("settings_globalchat") == "nein")
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast den Globalchat deaktiviert! Drücke F3 um ihn zu Aktivieren!");
                            return;
                        }
                        foreach (Client onlinespieler in Alt.GetAllPlayers())
                        {
                            //if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) > 6000)
                            //{
                            if (onlinespieler.vnxGetElementData<string>("settings_globalchat") == "ja")
                            {
                                if (pl_adminlvl > 0)
                                {
                                    onlinespieler.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[GLOBAL]" + Clantag + player.Username + " : " + text);
                                }
                                else
                                {
                                    onlinespieler.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[GLOBAL]" + RageAPI.GetHexColorcode(255, 255, 255) + player.Username + " : " + text);
                                }
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
            catch
            {
            }
        }

        [Command("global_aus")]
        public void setGlobal_status_on(Client player)
        {
            try
            {
                if (player.AdminRank >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    if (Global_Admin_Status == "Ausgeschaltet") { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Ausgeschaltet";
                    foreach (Client onlinespieler in Alt.GetAllPlayers())
                    {
                        onlinespieler.SendTranslatedChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[VnX]" + player.Username + " hat den Globalchat augeschaltet!");
                    }
                }
            }
            catch { }
        }

        [Command("global_an")]
        public void setGlobal_status_off(Client player)
        {
            try
            {
                if (player.AdminRank >= 4)
                {
                    if (Global_Admin_Status == "Angeschaltet") { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Angeschaltet";
                    foreach (Client onlinespieler in Alt.GetAllPlayers())
                    {
                        onlinespieler.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + "[VnX]" + player.Username + " hat den Globalchat angeschaltet!");
                    }
                }
            }
            catch { }
        }
    }
}
