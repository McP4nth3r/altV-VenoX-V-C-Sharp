using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
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
                Debug.OutputDebugString("[Error] : Waffenlager konnte nicht gefunden werden... [" + id + "]");
                return new WaffenlagerModel();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new WaffenlagerModel(); }
        }

        public static void WaffenlagerInit()
        {
            try
            {
                foreach (WaffenlagerModel waffenLager in WaffenlagerList.ToList())
                    Database.Database.RefreshWaffenlager(waffenLager);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
