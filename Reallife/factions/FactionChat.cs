using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.factions
{
    public class FactionChat : IScript
    {

        public static string GetFactionRgba(int FID)
        {
            string Rgbacode = string.Empty;
            if(FID == Constants.FACTION_POLICE)
            {
                Rgbacode = "!{100, 100, 255}";
            }
            else if (FID == Constants.FACTION_COSANOSTRA)
            {
                Rgbacode = "!{80, 80, 80}";
            }
            else if(FID == Constants.FACTION_YAKUZA)
            {
                Rgbacode = "!{100, 0, 0}";
            }
            else if (FID == Constants.FACTION_TERRORCLOSED)
            {
                Rgbacode = "CLOSED!!";
            }
            else if (FID == Constants.FACTION_NEWS)
            {
                Rgbacode = "!{125, 50, 200}";
            }
            else if (FID == Constants.FACTION_FBI)
            {
                Rgbacode = "!{50, 50, 255}";
            }
            else if (FID == Constants.FACTION_MS13)
            {
                Rgbacode = "!{225, 225, 0}";
            }
            else if (FID == Constants.FACTION_USARMY)
            {
                Rgbacode = "!{0, 125, 0}";
            }
            else if (FID == Constants.FACTION_SAMCRO)
            {
                Rgbacode = "!{100, 50, 100}";
            }
            else if (FID == Constants.FACTION_EMERGENCY)
            {
                Rgbacode = "!{255, 51, 51}";
            }
            else if (FID == Constants.FACTION_MECHANIK)
            {
                Rgbacode = "!{255, 100, 0}";
            }
            else if (FID == Constants.FACTION_BALLAS)
            {
                Rgbacode = "!{138,43,226}";
            }
            else if (FID == Constants.FACTION_GROVE)
            {
                Rgbacode = "!{85, 107, 47}";
            }
            return Rgbacode;
        }

        // BASIC TEAMCHAT
        [Command("t",  true)]
        public void SendFactionChatMessage(IPlayer player, string text)
        {
            try {
                int FraktionsID = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                Faction.CreateFactionMessage(FraktionsID, text, GetFactionRgba(FraktionsID), player);
                vnx_stored_files.logfile.WriteLogs("teamsay" + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), "[TEAMSAY FID : " + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.Name + " ] : " + text);
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SendFactionChatMessage] " + ex.Message);
                Alt.Log("[EXCEPTION SendFactionChatMessage] " + ex.StackTrace);
            }
        }


        [Command("teamsay",  true)]
        public void SendFactionChatMessage_Kuerzung(IPlayer player, string text)
        {
            try
            {
                SendFactionChatMessage(player, text);
            }
            catch { }
        }




        // Staatschat
        [Command("g",  true)]
        public void SendStateChatMessage(IPlayer player, string text)
        {
            try
            {
                if (Allround.isStateFaction(player) || player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                {
                    Faction.CreateStateMessage(text, "!{ 140, 10, 10}", player);
                    vnx_stored_files.logfile.WriteLogs("staatschat", "[G-CHAT FID : " + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.Name + " ] : " + text);
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keiner Staats/Neutralen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SendStateChatMessage] " + ex.Message);
                Alt.Log("[EXCEPTION SendStateChatMessage] " + ex.StackTrace);
            }
        }


        // BadFactionchat
        [Command("b",  true)]
        public void SendBadChatMessage(IPlayer player, string text)
        {
            try
            {
                if (Allround.isBadFaction(player))
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_RANK) >= 2)
                    {
                        Faction.CreateBadMessage(text, "!{ 107, 107, 107}", player);
                        vnx_stored_files.logfile.WriteLogs("badchat", "[B-CHAT FID : " + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) + "]" + "[ " + player.SocialClubId.ToString() + " ]" + "[ " +player.Name + " ] : " + text);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Erst ab Rank 2!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keiner Bösen Fraktion!");
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SendBadChatMessage] " + ex.Message);
                Alt.Log("[EXCEPTION SendBadChatMessage] " + ex.StackTrace);
            }
        }

    }
}
