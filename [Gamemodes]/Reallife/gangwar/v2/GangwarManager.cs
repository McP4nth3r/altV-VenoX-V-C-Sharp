using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.gangwar.v2
{
    public class GangwarManager : IScript
    {
        /* GLOBALS */
        public static string TKType = "GW_TK_POINT";
        public static string AreaType = "GW_AREA_ZONE";
        public static float TKRange = 2.25f;
        public static int ATT_BLIP_Rgba = 1;
        public static int GW_PREPARE_TIME = 3;
        public static int GW_RUNNING_TIME = 15;
        public static int GW_ATTACK_CD = 60;
        public static int MIN_COUNT_PLAYER = 2;
        public static int MIN_RANK_ATTACK = 3;
        public static int MIN_DIST = 100;
        public static int MAX_ATTACKS_DAY = 16;
        public static int GW_DIM = 72;

        public static int EARN_KILL = 1500;
        public static int EARN_DMG = 10;

        public static bool AttackerCountMore = true;
        public static bool DefenderCountMore = false;
        public static bool FreezeIVehicles = true;

        /* GANGWAR MANAGER */
        public List<GangwarArea> GangwarAreas { get; set; }
        public GangwarArea currentArea { get; set; }
        public int attacksCount { get; set; }
        public DateTime resetTime;
        public static bool DatabaseConnectionCreated = false;

        public GangwarManager()
        {
            currentArea = null;
            GangwarAreas = new List<GangwarArea>();
            resetTime = DateTime.Today.AddDays(1);
            attacksCount = 0;
            if (DatabaseConnectionCreated) { fetchAreas(); }
        }

        public void fetchAreas()
        {
            try
            {
                //ToDo: Add function to remove any gangwar area
                List<GangwarModel> areas = Database.LoadAllGWAreas();

                foreach (var aModel in areas)
                {
                    var area = new GangwarArea(aModel.gang_area_name, aModel.gang_area_position, (int)aModel.gang_area_radius, aModel.gang_area_tk_position,
                        aModel.GANG_AREA_OWNER, aModel.gang_area_rotation, aModel.GANG_AREA_COOLDOWN);
                    this.CreateGangwarArea(area);
                }
            }
            catch { }
        }

        public void ResetCount()
        {
            resetTime = DateTime.Now.AddDays(1);
            attacksCount = 0;
        }

        public void CheckDay()
        {
            if (DateTime.Now >= resetTime)
            {
                ResetCount();
            }
        }

        public void Update()
        {
            try
            {
                // Update gangwar manager
                this.CheckDay();

                // Update current gangwar if one is running
                if (this.currentArea != null)
                {
                    this.currentArea.GetCurrentRound().UpdateTime();
                }
            }
            catch { }
        }

        public void ProcessDamage(IPlayer source, string target_name, float damage)
        {
            try
            {
                //if (this.currentArea != null)
                //this.currentArea.GetCurrentRound().ProcessDamage(source, target.vnxGetElementData<int>( damage);
            }
            catch { }
        }

        public void ProcessKill(Client source, Client target)
        {
            try
            {
                if (this.currentArea != null)
                    this.currentArea.GetCurrentRound().ProcessKill(source, target);
            }
            catch { }
        }

        public void UpdateData(Client player)
        {
            try
            {
                foreach (GangwarArea area in GangwarAreas)
                {
                    area.Update(player);
                }
            }
            catch { }
        }

        public void printInfo(string text) => Console.WriteLine("[GANGWAR] " + text);

        public void CreateGangwarArea(GangwarArea area)
        {
            this.GangwarAreas.Add(area);
            printInfo(area.Name + " is created!");
            area.CreateArea();
        }

        public void StopCurrentGangwar()
        {
            if (currentArea != null)
            {
                this.currentArea.Stop();
                this.currentArea = null;
            }
        }

        public GangwarArea GetAreaByName(string name)
        {
            try
            {
                foreach (var area in this.GangwarAreas)
                {
                    if (area.Name == name)
                        return area;
                }
                return null;
            }
            catch { return null; }

        }

        public int GetFactionCount(int facId)
        {
            try
            {
                int result = 0;
                foreach (var player in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (player.Reallife.Faction == facId)
                        ++result;
                }
                return result;
            }
            catch { return 0; }
        }
    }
}
