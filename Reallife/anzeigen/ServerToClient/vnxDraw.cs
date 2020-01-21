//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.vnx_stored_files;

namespace VenoXV.Reallife.dxLibary
{
    public class VnX : IScript
    {
        public const string WINDOW_JOB_1 = "Job1";
        public const string WINDOW = "Window";
        public const string WINDOW_SELECTION = "WindowSelection";
        public const string WINDOW_INPUT = "WINDOW_INPUT";
        public static void DestroyWindow(IPlayer player, string window)
        {
            if (window == "Job1")
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "DestroyJobWindow1");
            }
            else if (window == "Window")
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "DestroyVnXSAWindowLib");
            }
            else if (window == "WindowSelection")
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "DestroyVnXSAWindowSel");
            }
            else if (window == WINDOW_INPUT)
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "DestroyInputWindow");
            }
            else
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, window);
            }
        }

        public static void DestroyRadarElement(IPlayer player, string element)
        {
            if (element == "Blip")
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "deleteBlipWaypoint");
            }
            else if (element == "Blip_lib")
            {
                AltV.Net.Alt.Server.TriggerClientEvent(player, "deleteBlip_lib");
            }
            else
            {
                logfile.WriteLogs("libLogs", "[ERROR] : Schwerwiegender Fehler! Element konnte nicht Gelöscht werden! : " + element);
                logfile.WriteLogs("libLogs", "[ERROR] : dieser Fehler verursacht das ein Blip oder ein Radar Wegpunkt nicht gelöscht werden konnte!");
            }
        }
        public static void DrawNotification(IPlayer player, string type, string message)
        {
            int triggerWert = 0;
            if (type == "info")
            {
                triggerWert = 0;
            }
            else if (type == "warning")
            {
                triggerWert = 1;
            }
            else if (type == "error")
            {
                triggerWert = 2;
            }
            else
            {
                triggerWert = 0;
            }
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXLiteNotify", triggerWert, message);
        }


        public static void DrawWindow(IPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXSAWindow", headertext, boxtext, buttontext1, buttontext2);
        }

        // Job Windows ( Job 1 = 3 Buttons , Job LvL Anzeige, Text Header , Text Info , Job DeIScription 1-3 ) 
        public static void DrawJobWindow(IPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2, string buttontext3, string button1desc, string button2desc, string button3desc, string joblvlinfo)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createJobWindow1", headertext, boxtext, buttontext1, buttontext2, buttontext3, button1desc, button2desc, button3desc, joblvlinfo);
        }

        public static void DrawWindowSelection(IPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXSAWindowSelection", headertext, boxtext, buttontext1, buttontext2);
        }

        public static void DrawBlip(IPlayer player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlip", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawZielBlip(IPlayer player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlipWaypoint", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawCustomZielBlip(IPlayer player, string name, Position position, float scale, int blipID, int blipRgba, int Dimension, int r, int g, int b, int a)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeCustomBlipWaypoint", name, position, scale, blipID, blipRgba, Dimension, r,g,b,a);
        }

        public static void DrawZielBlipTable(IPlayer player, string TableName, string name, Position position, int blipID, int blipRgba, int Dimension, int destroyedinms)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlipWaypoint_Table", TableName, name, position, blipID, blipRgba, Dimension, destroyedinms);
        }
        public static void DrawWaypoint(IPlayer player, float x, float y)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "VnXSetWaypoint", x,y);
        }

        public static void DrawInputWindow(IPlayer player, string headertext, string boxtext,  string buttontext)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createInputWindow", headertext, boxtext, buttontext);
        }

        public static void CreateCTimer(IPlayer player, string timername, int zeit)
        {
            if (zeit == 60)
            {
                zeit = 6 * 600000;
            }
            else if (zeit == 30)
            {
                zeit = 3 * 600000;
            }
            else if (zeit == 10)
            { zeit = 600000; }
            else if (zeit == 5)
            { zeit = 300000; }
            else if (zeit == 1)
            { zeit = 60000; }
            AltV.Net.Alt.Server.TriggerClientEvent(player, "VnX_LoadIPlayerSideTimer",player, timername, zeit);
        }
        public static void SetElementFrozen(IPlayer player, bool state)
        {
            
            AltV.Net.Alt.Server.TriggerClientEvent(player, "FreezePlayerPLAYER_VnX", state);
        }
        public static void SetIVehicleElementFrozen(IVehicle Vehicle, IPlayer sender, bool state)
        {
            if (Vehicle != null)
            {
                AltV.Net.Alt.Server.TriggerClientEvent(sender, "FreezeVEHICLEPLAYER_VnX", Vehicle, state);
            }
        }       
        public static void SetDelayedIVehicleElementFrozen(IVehicle Vehicle, IPlayer sender, bool state, int TimeInMS)
        {
            if (Vehicle != null)
            {
                AltV.Net.Alt.Server.TriggerClientEvent(sender, "FreezeVEHICLE_DelayedPLAYER_VnX", Vehicle, state, TimeInMS);
            }
        }
        public static void CreateDiscordUpdate(IPlayer player, string top, string main)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "discord_update", top, main);
        }
    }
}
