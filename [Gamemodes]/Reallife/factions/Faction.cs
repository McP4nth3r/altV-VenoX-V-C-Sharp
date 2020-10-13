using AltV.Net;
using System.Linq;
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
                if (FID == Constants.FACTION_NONE) return;

                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (target.Reallife.Faction == FID)
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [INFO] : " + RageAPI.GetHexColorcode(255, 255, 255) + text);
                }
            }
            catch { }
        }
        public static void CreateCustomFactionInformation(int FID, string text)
        {
            try
            {
                if (FID == Constants.FACTION_NONE)
                {
                    return;
                }
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (target.Reallife.Faction == FID)
                    {
                        target.SendTranslatedChatMessage(text);
                    }
                }
            }
            catch { }
        }
        public static void CreateStateFactionInformation(string text)
        {
            try
            {
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Allround.isStateFaction(target))
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 0) + text);
                    }
                }
            }
            catch { }

        }
        public static void CreateCustomStateFactionMessage(string text)
        {
            try
            {
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Allround.isStateFaction(target))
                    {
                        target.SendTranslatedChatMessage(text);
                    }
                }
            }
            catch { }
        }
        public static void CreateCustomBadFactionMessage(string text, int UID)
        {
            try
            {
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Allround.isBadFaction(target) && target.Reallife.Faction == UID)
                    {
                        target.SendTranslatedChatMessage(text);
                    }
                }
            }
            catch { }
        }
        public static void CreateFactionMessage(int FID, string text, string Rgba, VnXPlayer player)
        {
            try
            {
                if (FID == Constants.FACTION_NONE) return;
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (target.Reallife.Faction == FID) target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch { }
        }


        public static void CreateStateMessage(string text, string Rgba, VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Allround.isStateFaction(target) || target.Reallife.Faction == Constants.FACTION_EMERGENCY)
                        target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch { }
        }


        public static void CreateBadMessage(string text, string Rgba, VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer target in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Allround.isBadFaction(target))
                        target.SendTranslatedChatMessage(Rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch { }
        }

        public static string GetFactionNameById(int FID)
        {
            return FID switch
            {
                Constants.FACTION_NONE => Constants.FACTION_NONE_NAME,
                Constants.FACTION_LSPD => Constants.FACTION_POLICE_NAME,
                Constants.FACTION_LCN => Constants.FACTION_COSANOSTRA_NAME,
                Constants.FACTION_YAKUZA => Constants.FACTION_YAKUZA_NAME,
                Constants.FACTION_TERRORCLOSED => Constants.FACTION_TERRORCLOSED_NAME,
                Constants.FACTION_NEWS => Constants.FACTION_NEWS_NAME,
                Constants.FACTION_FBI => Constants.FACTION_FBI_NAME,
                Constants.FACTION_NARCOS => Constants.FACTION_MS13_NAME,
                Constants.FACTION_USARMY => Constants.FACTION_USARMY_NAME,
                Constants.FACTION_SAMCRO => Constants.FACTION_SAMCRO_NAME,
                Constants.FACTION_EMERGENCY => Constants.FACTION_EMERGENCY_NAME,
                Constants.FACTION_MECHANIK => Constants.FACTION_MECHANIK_NAME,
                Constants.FACTION_BALLAS => Constants.FACTION_BALLAS_NAME,
                Constants.FACTION_COMPTON => Constants.FACTION_GROVE_NAME,
                _ => "ERROR - " + FID,
            };
        }


        public static string GetPlayerFactionRank(VnXPlayer player)
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
                        rankString = player.Sex == Constants.SEX_MALE ? factionModel.descriptionMale : factionModel.descriptionFemale;
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
