using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;

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
            new WaffenlagerModel{ Faction = Constants.FACTION_LSPD },
            new WaffenlagerModel{ Faction = Constants.FACTION_LCN },
            new WaffenlagerModel{ Faction = Constants.FACTION_YAKUZA },
            new WaffenlagerModel{ Faction = Constants.FACTION_NARCOS },
            new WaffenlagerModel{ Faction = Constants.FACTION_SAMCRO },
            new WaffenlagerModel{ Faction = Constants.FACTION_BALLAS },
            new WaffenlagerModel{ Faction = Constants.FACTION_COMPTON },
        };

        public static WaffenlagerModel GetWaffenlagerById(int ID)
        {
            try
            {
                foreach (WaffenlagerModel _WaffenLager in WaffenlagerList.ToList())
                {
                    if (_WaffenLager.Faction == ID) { return _WaffenLager; }
                }
                Core.Debug.OutputDebugString("[Error] : Waffenlager konnte nicht gefunden werden... [" + ID + "]");
                return new WaffenlagerModel();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("GetWaffenlagerById", ex); return new WaffenlagerModel(); }
        }

        public static void WaffenlagerInit()
        {
            try
            {
                foreach (WaffenlagerModel _WaffenLager in WaffenlagerList.ToList())
                    Database.RefreshWaffenlager(_WaffenLager);
            }
            catch { }
        }
    }
}
