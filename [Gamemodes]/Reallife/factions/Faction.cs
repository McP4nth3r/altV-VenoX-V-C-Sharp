using AltV.Net;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions
{
    public class Faction : IScript
    {
        public static void CreateFactionInformation(int FID, string text)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (target.Reallife.Faction == FID)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [INFO] : " + RageAPI.GetHexColorcode(255, 255, 255) + text);
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
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (target.Reallife.Faction == FID)
                    {
                        target.SendTranslatedChatMessage(text);
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
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (Allround.isStateFaction(target))
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 0) + text);
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
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (Allround.isStateFaction(target))
                    {
                        target.SendTranslatedChatMessage(text);
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
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (Allround.isBadFaction(target) && target.Reallife.Faction == UID)
                    {
                        target.SendTranslatedChatMessage(text);
                    }
                }
            }
            catch
            {
            }
        }
        public static void CreateFactionMessage(int FID, string text, string Rgba, Client player)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (target.Reallife.Faction == FID)
                    {
                        target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }


        public static void CreateStateMessage(string text, string Rgba, Client player)
        {
            try
            {
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (Allround.isStateFaction(target) || target.Reallife.Faction == Constants.FACTION_EMERGENCY)
                    {
                        target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }


        public static void CreateBadMessage(string text, string Rgba, Client player)
        {
            try
            {
                foreach (Client target in VenoXV.Globals.Main.ReallifePlayers)
                {
                    if (Allround.isBadFaction(target))
                    {
                        target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                    }
                }
            }
            catch
            {
            }
        }

        public static string GetFactionNameById(int FID)
        {
            string fraktionsname = string.Empty;
            if (FID == 0)
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


        public static string GetPlayerFactionRank(Client player)
        {
            try
            {
                string rankString = string.Empty;
                int faction = player.Reallife.Faction;
                int rank = player.Reallife.FactionRank;
                foreach (FactionModel factionModel in Constants.FACTION_RANK_LIST)
                {
                    if (factionModel.faction == faction && factionModel.rank == rank)
                    {
                        rankString = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX) == Constants.SEX_MALE ? factionModel.descriptionMale : factionModel.descriptionFemale;
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
