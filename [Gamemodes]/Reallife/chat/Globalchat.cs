﻿using AltV.Net;
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
        public static void SendGlobalMessage(PlayerModel player, string text)
        {
            try
            {
                if (Global_Admin_Status == "Angeschaltet")
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) >= 1800)
                    {
                        int pl_adminlvl = player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK);
                        string Clantag = admin.Admin.GetRgbaedClantag(pl_adminlvl);
                        if (player.vnxGetElementData<string>("settings_globalchat") == "nein")
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast den Globalchat deaktiviert! Drücke F3 um ihn zu Aktivieren!");
                            return;
                        }
                        foreach (IPlayer onlinespieler in Alt.GetAllPlayers())
                        {
                            //if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) > 6000)
                            //{
                            if (onlinespieler.vnxGetElementData<string>("settings_globalchat") == "ja")
                            {
                                if (pl_adminlvl > 0)
                                {
                                    onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[GLOBAL]" + Clantag + player.GetVnXName() + " : " + text);
                                }
                                else
                                {
                                    onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[GLOBAL]" + RageAPI.GetHexColorcode(255, 255, 255) + player.GetVnXName() + " : " + text);
                                }
                            }
                            //}
                        }
                        vnx_stored_files.logfile.WriteLogs("globalchat", "[" + player.GetVnXName() + "] : " + text);

                    }
                    else
                    {
                        player.SendChatMessage("Du hast nicht genug Spielstunden ( Mind. 30 ) !");
                    }
                }
                else
                {
                    player.SendChatMessage("Der Globalchat ist augeschaltet!");
                }
            }
            catch
            {
            }
        }

        [Command("global_aus")]
        public void setGlobal_status_on(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= Constants.ADMINLVL_ADMINISTRATOR)
                {
                    if (Global_Admin_Status == "Ausgeschaltet") { dxLibary.VnX.DrawNotification(player, "error", "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Ausgeschaltet";
                    foreach (IPlayer onlinespieler in Alt.GetAllPlayers())
                    {
                        onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(125, 0, 0) + "[VnX]" + player.GetVnXName() + " hat den Globalchat augeschaltet!");
                    }
                }
            }
            catch { }
        }

        [Command("global_an")]
        public void setGlobal_status_off(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_RANK) >= 4)
                {
                    if (Global_Admin_Status == "Angeschaltet") { dxLibary.VnX.DrawNotification(player, "error", "Der Global chat ist bereits angeschaltet!"); return; }
                    Global_Admin_Status = "Angeschaltet";
                    foreach (IPlayer onlinespieler in Alt.GetAllPlayers())
                    {
                        onlinespieler.SendChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + "[VnX]" + player.GetVnXName() + " hat den Globalchat angeschaltet!");
                    }
                }
            }
            catch { }
        }
    }
}
