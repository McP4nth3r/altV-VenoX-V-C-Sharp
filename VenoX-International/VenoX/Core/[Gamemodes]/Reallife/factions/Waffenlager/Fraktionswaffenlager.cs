using System;
using System.Collections.Generic;
using System.Linq;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_.Database;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.factions.Waffenlager
{
    public class Fraktionswaffenlager
    {
        /*
        public static Dictionary<int, WaffenlagerModel> Waffenlagerdict = new Dictionary<int, WaffenlagerModel>
        {
            { Constants.FACTION_LSPD, new WaffenlagerModel() },
            { Constants.FACTION_LCN, new WaffenlagerModel() },
            { Constants.FACTION_YAKUZA, new WaffenlagerModel() },
            { Constants.FACTION_NARCOS, new WaffenlagerModel() },
            { Constants.FACTION_SAMCRO, new WaffenlagerModel() },
            { Constants.FACTION_BALLAS, new WaffenlagerModel() },
            { Constants.FACTION_COMPTON, new WaffenlagerModel() },
        };
        */

        // Waffenlager der Fraktionen.
        public static List<WaffenlagerModel> WaffenlagerList = new List<WaffenlagerModel>
        {
            new WaffenlagerModel{ Faction = Constants.FactionLspd },
            new WaffenlagerModel{ Faction = Constants.FactionLcn },
            new WaffenlagerModel{ Faction = Constants.FactionYakuza },
            new WaffenlagerModel{ Faction = Constants.FactionNarcos },
            new WaffenlagerModel{ Faction = Constants.FactionSamcro },
            new WaffenlagerModel{ Faction = Constants.FactionBallas },
            new WaffenlagerModel{ Faction = Constants.FactionCompton },
        };

        public static WaffenlagerModel GetWaffenlagerById(int id)
        {
            try
            {
                foreach (WaffenlagerModel waffenLager in WaffenlagerList.ToList())
                {
                    if (waffenLager.Faction == id) { return waffenLager; }
                }
                ConsoleHandling.OutputDebugString("[Error] : Waffenlager konnte nicht gefunden werden... [" + id + "]");
                return new WaffenlagerModel();
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new WaffenlagerModel(); }
        }

        public static void WaffenlagerInit()
        {
            try
            {
                foreach (WaffenlagerModel waffenLager in WaffenlagerList.ToList())
                    Database.RefreshWaffenlager(waffenLager);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
