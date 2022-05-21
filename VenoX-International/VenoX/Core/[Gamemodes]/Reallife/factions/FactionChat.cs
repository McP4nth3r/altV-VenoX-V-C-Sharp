using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;

namespace VenoX.Core._Gamemodes_.Reallife.factions
{
    public class FactionChat : IScript
    {

        public static string GetFactionRgba(int fid)
        {
            string rgbacode = string.Empty;
            switch (fid)
            {
                case Constants.FactionLspd:
                    rgbacode = RageApi.GetHexColorcode(100, 100, 255);
                    break;
                case Constants.FactionLcn:
                    rgbacode = RageApi.GetHexColorcode(80, 80, 80);
                    break;
                case Constants.FactionYakuza:
                    rgbacode = RageApi.GetHexColorcode(100, 0, 0);
                    break;
                case Constants.FactionTerrorclosed:
                    rgbacode = "CLOSED!!";
                    break;
                case Constants.FactionNews:
                    rgbacode = RageApi.GetHexColorcode(125, 50, 200);
                    break;
                case Constants.FactionFbi:
                    rgbacode = RageApi.GetHexColorcode(50, 50, 255);
                    break;
                case Constants.FactionNarcos:
                    rgbacode = RageApi.GetHexColorcode(225, 225, 0);
                    break;
                case Constants.FactionUsarmy:
                    rgbacode = RageApi.GetHexColorcode(0, 125, 0);
                    break;
                case Constants.FactionSamcro:
                    rgbacode = RageApi.GetHexColorcode(100, 50, 100);
                    break;
                case Constants.FactionEmergency:
                    rgbacode = RageApi.GetHexColorcode(255, 51, 51);
                    break;
                case Constants.FactionMechanik:
                    rgbacode = RageApi.GetHexColorcode(255, 100, 0);
                    break;
                case Constants.FactionBallas:
                    rgbacode = RageApi.GetHexColorcode(138, 43, 226);
                    break;
                case Constants.FactionCompton:
                    rgbacode = RageApi.GetHexColorcode(85, 107, 47);
                    break;
            }
            return rgbacode;
        }

        // BASIC TEAMCHAT
        [Command("t", true, new[] { "teamsay" })]
        public void SendFactionChatMessage(VnXPlayer player, string text)
        {
            try
            {
                int fraktionsId = player.Reallife.Faction;
                Faction.CreateFactionMessage(fraktionsId, text, GetFactionRgba(fraktionsId), player);
                Logfile.WriteLogs("teamsay" + player.Reallife.Faction, "[TEAMSAY FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId + " ]" + "[ " + player.CharacterUsername + " ] : " + text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SendFactionChatMessage] " + ex.Message);
                Console.WriteLine("[EXCEPTION SendFactionChatMessage] " + ex.StackTrace);
            }
        }





        // Staatschat
        [Command("g", true)]
        public void SendStateChatMessage(VnXPlayer player, string text)
        {
            try
            {
                if (Allround.IsStateFaction(player) || player.Reallife.Faction == Constants.FactionEmergency)
                {
                    Faction.CreateStateMessage(text, RageApi.GetHexColorcode(140, 10, 10), player);
                    Logfile.WriteLogs("staatschat", "[G-CHAT FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId + " ]" + "[ " + player.CharacterUsername + " ] : " + text);
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist in keiner Staats/Neutralen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SendStateChatMessage] " + ex.Message);
                Console.WriteLine("[EXCEPTION SendStateChatMessage] " + ex.StackTrace);
            }
        }


        // BadFactionchat
        [Command("b", true)]
        public void SendBadChatMessage(VnXPlayer player, string text)
        {
            try
            {
                if (Allround.IsBadFaction(player))
                {
                    if (player.Reallife.FactionRank >= 2)
                    {
                        Faction.CreateBadMessage(text, RageApi.GetHexColorcode(107, 107, 107), player);
                        Logfile.WriteLogs("badchat", "[B-CHAT FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId + " ]" + "[ " + player.CharacterUsername + " ] : " + text);
                    }
                    else
                    {
                        Notification.DrawNotification(player, Notification.Types.Error, "Erst ab Rank 2!");
                    }
                }
                else
                {
                    Notification.DrawNotification(player, Notification.Types.Error, "Du bist in keiner Bösen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SendBadChatMessage] " + ex.Message);
                Console.WriteLine("[EXCEPTION SendBadChatMessage] " + ex.StackTrace);
            }
        }

    }
}
