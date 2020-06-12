using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class FactionChat : IScript
    {

        public static string GetFactionRgba(int FID)
        {
            string Rgbacode = string.Empty;
            if (FID == Constants.FACTION_POLICE)
            {
                Rgbacode = RageAPI.GetHexColorcode(100, 100, 255);
            }
            else if (FID == Constants.FACTION_COSANOSTRA)
            {
                Rgbacode = RageAPI.GetHexColorcode(80, 80, 80);
            }
            else if (FID == Constants.FACTION_YAKUZA)
            {
                Rgbacode = RageAPI.GetHexColorcode(100, 0, 0);
            }
            else if (FID == Constants.FACTION_TERRORCLOSED)
            {
                Rgbacode = "CLOSED!!";
            }
            else if (FID == Constants.FACTION_NEWS)
            {
                Rgbacode = RageAPI.GetHexColorcode(125, 50, 200);
            }
            else if (FID == Constants.FACTION_FBI)
            {
                Rgbacode = RageAPI.GetHexColorcode(50, 50, 255);
            }
            else if (FID == Constants.FACTION_MS13)
            {
                Rgbacode = RageAPI.GetHexColorcode(225, 225, 0);
            }
            else if (FID == Constants.FACTION_USARMY)
            {
                Rgbacode = RageAPI.GetHexColorcode(0, 125, 0);
            }
            else if (FID == Constants.FACTION_SAMCRO)
            {
                Rgbacode = RageAPI.GetHexColorcode(100, 50, 100);
            }
            else if (FID == Constants.FACTION_EMERGENCY)
            {
                Rgbacode = RageAPI.GetHexColorcode(255, 51, 51);
            }
            else if (FID == Constants.FACTION_MECHANIK)
            {
                Rgbacode = RageAPI.GetHexColorcode(255, 100, 0);
            }
            else if (FID == Constants.FACTION_BALLAS)
            {
                Rgbacode = RageAPI.GetHexColorcode(138, 43, 226);
            }
            else if (FID == Constants.FACTION_GROVE)
            {
                Rgbacode = RageAPI.GetHexColorcode(85, 107, 47);
            }
            return Rgbacode;
        }

        // BASIC TEAMCHAT
        [Command("t", true)]
        public void SendFactionChatMessage(Client player, string text)
        {
            try
            {
                int FraktionsID = player.Reallife.Faction;
                Faction.CreateFactionMessage(FraktionsID, text, GetFactionRgba(FraktionsID), player);
                vnx_stored_files.logfile.WriteLogs("teamsay" + player.Reallife.Faction, "[TEAMSAY FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] : " + text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SendFactionChatMessage] " + ex.Message);
                Console.WriteLine("[EXCEPTION SendFactionChatMessage] " + ex.StackTrace);
            }
        }


        [Command("teamsay", true)]
        public void SendFactionChatMessage_Kuerzung(Client player, string text)
        {
            try
            {
                SendFactionChatMessage(player, text);
            }
            catch { }
        }




        // Staatschat
        [Command("g", true)]
        public void SendStateChatMessage(Client player, string text)
        {
            try
            {
                if (Allround.isStateFaction(player) || player.Reallife.Faction == Constants.FACTION_EMERGENCY)
                {
                    Faction.CreateStateMessage(text, RageAPI.GetHexColorcode(140, 10, 10), player);
                    vnx_stored_files.logfile.WriteLogs("staatschat", "[G-CHAT FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] : " + text);
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keiner Staats/Neutralen Fraktion!");
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
        public void SendBadChatMessage(Client player, string text)
        {
            try
            {
                if (Allround.isBadFaction(player))
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_RANK) >= 2)
                    {
                        Faction.CreateBadMessage(text, RageAPI.GetHexColorcode(107, 107, 107), player);
                        vnx_stored_files.logfile.WriteLogs("badchat", "[B-CHAT FID : " + player.Reallife.Faction + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " + player.Username + " ] : " + text);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab Rank 2!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keiner Bösen Fraktion!");
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
