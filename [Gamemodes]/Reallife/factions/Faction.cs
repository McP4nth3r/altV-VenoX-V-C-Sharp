using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Language_.Main;

namespace VenoXV._Gamemodes_.Reallife.factions
{
    public class Faction : IScript
    {
        public static void CreateFactionInformation(int fid, string text, Main.Languages language = Main.Languages.English)
        {
            try
            {
                if (fid == Constants.FactionNone) return;

                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (target.Reallife.Faction == fid && target.Language == (int)language)
                        target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [INFO] : " + RageApi.GetHexColorcode(255, 255, 255) + text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void CreateCustomFactionInformation(int fid, string text, Main.Languages language = Main.Languages.English)
        {
            try
            {
                if (fid == Constants.FactionNone) return;
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (target.Reallife.Faction == fid && target.Language == (int)language)
                        target.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void CreateStateFactionInformation(string text, Main.Languages language = Main.Languages.English)
        {
            try
            {
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (Allround.IsStateFaction(target) && target.Language == (int)language)
                    {
                        target.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 0) + text);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }
        public static void CreateCustomStateFactionMessage(string text, Main.Languages language = Main.Languages.English)
        {
            try
            {
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (Allround.IsStateFaction(target) && target.Language == (int)language)
                        target.SendTranslatedChatMessage(text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void CreateCustomBadFactionMessage(string text, int uid, Main.Languages language = Main.Languages.English)
        {
            try
            {
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                    if (Allround.IsBadFaction(target) && target.Reallife.Faction == uid && target.Language == (int)language)
                        target.SendTranslatedChatMessage(text);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void CreateFactionMessage(int fid, string text, string rgba, VnXPlayer player)
        {
            try
            {
                if (fid == Constants.FactionNone) return;
                foreach (var target in from VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList() where target.Reallife.Faction == fid select target)
                {
                    target.SendChatMessage(rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        public static void CreateStateMessage(string text, string rgba, VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (Allround.IsStateFaction(target) || target.Reallife.Faction == Constants.FactionEmergency)
                        target.SendChatMessage(rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        public static void CreateBadMessage(string text, string rgba, VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer target in _Globals_.Main.ReallifePlayers.ToList())
                {
                    if (Allround.IsBadFaction(target))
                        target.SendChatMessage(rgba + GetPlayerFactionRank(player) + " | " + player.Username + " : " + text);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static string GetFactionNameById(int fid)
        {
            return fid switch
            {
                Constants.FactionNone => Constants.FactionNoneName,
                Constants.FactionLspd => Constants.FactionPoliceName,
                Constants.FactionLcn => Constants.FactionCosanostraName,
                Constants.FactionYakuza => Constants.FactionYakuzaName,
                Constants.FactionTerrorclosed => Constants.FactionTerrorclosedName,
                Constants.FactionNews => Constants.FactionNewsName,
                Constants.FactionFbi => Constants.FactionFbiName,
                Constants.FactionNarcos => Constants.FactionMs13Name,
                Constants.FactionUsarmy => Constants.FactionUsarmyName,
                Constants.FactionSamcro => Constants.FactionSamcroName,
                Constants.FactionEmergency => Constants.FactionEmergencyName,
                Constants.FactionMechanik => Constants.FactionMechanikName,
                Constants.FactionBallas => Constants.FactionBallasName,
                Constants.FactionCompton => Constants.FactionGroveName,
                _ => "ERROR - " + fid,
            };
        }


        public static string GetPlayerFactionRank(VnXPlayer player)
        {
            try
            {
                string rankString = string.Empty;
                int faction = player.Reallife.Faction;
                int rank = player.Reallife.FactionRank;
                foreach (FactionModel factionModel in Constants.FactionRankList)
                {
                    if (factionModel.Faction == faction && factionModel.Rank == rank)
                    {
                        rankString = player.Sex == Constants.SexMale ? factionModel.DescriptionMale : factionModel.DescriptionFemale;
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
