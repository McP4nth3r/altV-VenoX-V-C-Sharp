﻿using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.gangwar.v2
{
    public class GangwarManager : IScript
    {
        /* GLOBALS */
        public static string TkType = "GW_TK_POINT";
        public static string AreaType = "GW_AREA_ZONE";
        public static float TkRange = 2.25f;
        public static int AttBlipRgba = 1;
        public static int GwPrepareTime = 3;
        public static int GwRunningTime = 15;
        public static int GwAttackCd = 60;
        public static int MinCountPlayer = 0;
        public static int MinRankAttack = 3;
        public static int MinDist = 100;
        public static int MaxAttacksDay = 16;
        public static int GwDim = 72;

        public static int EarnKill = 1500;
        public static int EarnDmg = 10;

        public static bool AttackerCountMore = true;
        public static bool DefenderCountMore = false;
        public static bool FreezeIVehicles = true;

        /* GANGWAR MANAGER */
        public List<GangwarArea> GangwarAreas { get; set; }
        public GangwarArea CurrentArea { get; set; }
        public int AttacksCount { get; set; }
        public DateTime ResetTime;
        public static bool DatabaseConnectionCreated = false;

        public GangwarManager()
        {
            CurrentArea = null;
            GangwarAreas = new List<GangwarArea>();
            ResetTime = DateTime.Today.AddDays(1);
            AttacksCount = 0;
            if (DatabaseConnectionCreated) FetchAreas();
        }

        public void FetchAreas()
        {
            try
            {
                //ToDo: Add function to remove any gangwar area
                List<GangwarModel> areas = Database.LoadAllGwAreas();
                foreach (GangwarArea area in areas.Select(aModel => new GangwarArea(aModel.GangAreaName, aModel.GangAreaPosition, (int)aModel.GangAreaRadius, aModel.GangAreaTkPosition,
                    aModel.GangAreaOwner, aModel.GangAreaRotation, aModel.GangAreaCooldown)))
                {
                    CreateGangwarArea(area);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void ResetCount()
        {
            ResetTime = DateTime.Now.AddDays(1);
            AttacksCount = 0;
        }

        public void CheckDay()
        {
            if (DateTime.Now >= ResetTime)
                ResetCount();

        }

        public void Update()
        {
            try
            {
                // Update gangwar manager
                CheckDay();

                // Update current gangwar if one is running
                if (CurrentArea != null)
                    CurrentArea.GetCurrentRound().UpdateTime();
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void ProcessDamage(VnXPlayer source, VnXPlayer target, float damage)
        {
            try
            {
                if (CurrentArea != null)
                    CurrentArea.GetCurrentRound().ProcessDamage(source, target, damage);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void ProcessKill(VnXPlayer source, VnXPlayer target)
        {
            try
            {
                if (CurrentArea != null)
                    CurrentArea.GetCurrentRound().ProcessKill(source, target);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void UpdateData(VnXPlayer player)
        {
            try
            {
                foreach (GangwarArea area in GangwarAreas)
                {
                    area.Update(player);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void PrintInfo(string text) => Console.WriteLine("[GANGWAR] " + text);

        public void CreateGangwarArea(GangwarArea area)
        {
            GangwarAreas.Add(area);
            PrintInfo(area.Name + " is created!");
            area.CreateArea();
        }

        public void StopCurrentGangwar()
        {
            if (CurrentArea == null) return;
            CurrentArea.Stop();
            CurrentArea = null;
        }

        public GangwarArea GetAreaByName(string name)
        {
            try
            {
                return GangwarAreas.FirstOrDefault(area => area.Name == name);
            }
            catch { return null; }

        }

        public int GetFactionCount(int facId)
        {
            try
            {
                return Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers).Count(player => player.Reallife.Faction == facId);
            }
            catch { return 0; }
        }
    }
}
