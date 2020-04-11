using AltV.Net.Elements.Entities;
using VenoXV.Reallife.model;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.chat;
using VenoXV.Reallife.database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System;
using VenoXV.Reallife.dxLibary;
using AltV.Net;
using VenoXV.Core;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Data;

namespace VenoXV.Reallife.factions
{
    public class Faction : IScript
    {
     



        public static void CreateFactionBaseBlip(IPlayer player)
        {
            if (Allround.isBadFaction(player) == false)
            {
                return;
            }
            /*if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_COSANOSTRA)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(266.2531f, -1007.264f, -101.0095f), 50, 20, 0);
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_YAKUZA)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(339.3727f, -997.0941f, -99.19626f), 50, 49, 0);
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_MS13)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(339.3727f, -997.0941f, -99.19626f), 50, 46, 0);
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_SAMCRO)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(339.3727f, -997.0941f, -99.19626f), 50, 21, 0);
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_BALLAS)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(339.3727f, -997.0941f, -99.19626f), 50, 7, 0);
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_GROVE)
            {
                VnX.DrawBlip(player, "Gang - Base", new Position(339.3727f, -997.0941f, -99.19626f), 50, 2, 0);
            }*/
        }
        public static void CreateFactionInformation(int FID, string text)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == FID)
                    {
                       target.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [INFO] : " + RageAPI.GetHexColorcode(255,255,255) + text);
                    }
                }
            }
            catch
            { 
            }
        }
        public static void CreateCustomFactionInformation(int FID, string text)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == FID)
                    {
                       target.SendChatMessage( text);
                    }
                }
            }
            catch
            { 
            }
        }
        public static void CreateStateFactionInformation(string text)
        {
            try
            {
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (Allround.isStateFaction(target))
                    {
                       target.SendChatMessage(RageAPI.GetHexColorcode(150,0,0) + text);
                    }
                }
            }
            catch
            {
            }
        }
        public static void CreateCustomStateFactionMessage(string text)
        {
            try
            {
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (Allround.isStateFaction(target))
                    {
                       target.SendChatMessage( text);
                    }
                }
            }
            catch
            {
            }
        }
        public static void CreateCustomBadFactionMessage(string text, int UID)
        {
            try
            {
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (Allround.isBadFaction(target) && target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == UID)
                    {
                       target.SendChatMessage( text);
                    }
                }
            }
            catch
            {
            }
        }
        public static void CreateFactionMessage(int FID, string text, string Rgba, IPlayer player)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == FID)
                    {
                       target.SendChatMessage( Rgba + GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }


        public static void CreateStateMessage(string text, string Rgba, IPlayer player)
        {
            try
            {
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (Allround.isStateFaction(target) || target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                    {
                       target.SendChatMessage( Rgba + GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }


        public static void CreateBadMessage(string text, string Rgba, IPlayer player)
        {
            try
            {
                foreach (IPlayer target in Alt.GetAllPlayers())
                {
                    if (Allround.isBadFaction(target))
                    {
                       target.SendChatMessage( Rgba + GetPlayerFactionRank(player) + " | " +player.GetVnXName<string>() + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }

        public static string GetPlayerFactionName(int FID)
        {
            string fraktionsname = string.Empty;
            if(FID == 0)
            {
                fraktionsname = Constants.FACTION_NONE_NAME;
            }
            else if (FID == 1)
            {
                fraktionsname = Constants.FACTION_POLICE_NAME;
            }
            else if (FID == 2)
            {
                fraktionsname = Constants.FACTION_COSANOSTRA_NAME;
            }
            else if (FID == 3)
            {
                fraktionsname = Constants.FACTION_YAKUZA_NAME;
            }
            else if (FID == 4)
            {
                fraktionsname = Constants.FACTION_TERRORCLOSED_NAME;
            }
            else if (FID == 5)
            {
                fraktionsname = Constants.FACTION_NEWS_NAME;
            }
            else if (FID == 6)
            {
                fraktionsname = Constants.FACTION_FBI_NAME;
            }
            else if (FID == 7)
            {
                fraktionsname = Constants.FACTION_MS13_NAME;
            }
            else if (FID == 8)
            {
                fraktionsname = Constants.FACTION_USARMY_NAME;
            }
            else if (FID == 9)
            {
                fraktionsname = Constants.FACTION_SAMCRO_NAME;
            }
            else if (FID == 10)
            {
                fraktionsname = Constants.FACTION_EMERGENCY_NAME;
            }
            else if (FID == 11)
            {
                fraktionsname = Constants.FACTION_MECHANIK_NAME;
            }
            else if (FID == 12)
            {
                fraktionsname = Constants.FACTION_BALLAS_NAME;
            }
            else if (FID == 13)
            {
                fraktionsname = Constants.FACTION_GROVE_NAME;
            }
            return fraktionsname;
        }


        public static string GetPlayerFactionRank(IPlayer player)
        {
            try
            {
                string rankString = string.Empty;
                int faction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                int rank = player.vnxGetElementData<int>(EntityData.PLAYER_RANK);
                foreach (FactionModel factionModel in Constants.FACTION_RANK_LIST)
                {
                    if (factionModel.faction == faction && factionModel.rank == rank)
                    {
                        rankString = player.vnxGetElementData<int>(EntityData.PLAYER_SEX) == Constants.SEX_MALE ? factionModel.descriptionMale : factionModel.descriptionFemale;
                        break;
                    }
                }
                return rankString;
            }
            catch
            {
                return "";
            }
        }
    }

}
