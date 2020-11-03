//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.dxLibary
{
    public class VnX : IScript
    {
        public const string WINDOW_JOB_1 = "Job1";
        public const string WINDOW = "Window";
        public const string WINDOW_SELECTION = "WindowSelection";
        public const string WINDOW_INPUT = "WINDOW_INPUT";
        public static void DestroyWindow(VnXPlayer player, string window)
        {
            if (window == "Job1")
            {
                VenoX.TriggerClientEvent(player, "DestroyJobWindow1");
            }
            else if (window == "Window")
            {
                VenoX.TriggerClientEvent(player, "DestroyVnXSAWindowLib");
            }
            else if (window == "WindowSelection")
            {
                VenoX.TriggerClientEvent(player, "DestroyVnXSAWindowSel");
            }
            else if (window == WINDOW_INPUT)
            {
                VenoX.TriggerClientEvent(player, "DestroyInputWindow");
            }
            else
            {
                VenoX.TriggerClientEvent(player, window);
            }
        }

        public static void DestroyRadarElement(VnXPlayer player, string element)
        {
            if (element == "Blip")
            {
                VenoX.TriggerClientEvent(player, "deleteBlipWaypoint");
            }
            else if (element == "Blip_lib")
            {
                VenoX.TriggerClientEvent(player, "deleteBlip_lib");
            }
            else
            {
                logfile.WriteLogs("libLogs", "[ERROR] : Schwerwiegender Fehler! Element konnte nicht Gelöscht werden! : " + element);
                logfile.WriteLogs("libLogs", "[ERROR] : dieser Fehler verursacht das ein Blip oder ein Radar Wegpunkt nicht gelöscht werden konnte!");
            }
        }



        public static void DrawWindow(VnXPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            VenoX.TriggerClientEvent(player, "Job:ShowAcceptWindow", headertext, boxtext, buttontext1, buttontext2);
        }

        // Job Windows ( Job 1 = 3 Buttons , Job LvL Anzeige, Text Header , Text Info , Job description 1-3 ) 
        public static void DrawJobWindow(VnXPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2, string buttontext3, string button1desc, string button2desc, string button3desc, string joblvlinfo)
        {
            VenoX.TriggerClientEvent(player, "Job:ShowSelection1", headertext, boxtext, buttontext1, buttontext2, buttontext3, button1desc, button2desc, button3desc, joblvlinfo);
        }

        public static void DrawWindowSelection(VnXPlayer player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            VenoX.TriggerClientEvent(player, "createVnXSAWindowSelection", headertext, boxtext, buttontext1, buttontext2);
        }

        public static void DrawBlip(VnXPlayer player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            VenoX.TriggerClientEvent(player, "placeBlip", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawZielBlip(VnXPlayer player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            VenoX.TriggerClientEvent(player, "placeBlipWaypoint", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawCustomZielBlip(VnXPlayer player, string name, Position position, float scale, int blipID, int blipRgba, int Dimension, int r, int g, int b, int a)
        {
            VenoX.TriggerClientEvent(player, "placeCustomBlipWaypoint", name, position, scale, blipID, blipRgba, Dimension, r, g, b, a);
        }

        public static void DrawZielBlipTable(VnXPlayer player, string TableName, string name, Position position, int blipID, int blipRgba, int Dimension, int destroyedinms)
        {
            VenoX.TriggerClientEvent(player, "placeBlipWaypoint_Table", TableName, name, position, blipID, blipRgba, Dimension, destroyedinms);
        }
        public static void DrawWaypoint(VnXPlayer player, float x, float y)
        {
            VenoX.TriggerClientEvent(player, "VnXSetWaypoint", x, y);
        }

        public static void DrawInputWindow(VnXPlayer player, string headertext, string boxtext, string buttontext)
        {
            VenoX.TriggerClientEvent(player, "createInputWindow", headertext, boxtext, buttontext);
        }

        public static void SetElementFrozen(VnXPlayer player, bool state)
        {
            VenoX.TriggerClientEvent(player, "Player:Freeze", state);
        }
        public static void SetDelayedIVehicleElementFrozen(VehicleModel Vehicle, VnXPlayer sender, bool state, int TimeInMS)
        {
            if (Vehicle != null)
            {
                VenoX.TriggerClientEvent(sender, "FreezeVEHICLE_DelayedPLAYER_VnX", Vehicle, state, TimeInMS);
            }
        }
        public static void CreateDiscordUpdate(VnXPlayer player, string top, string main)
        {
            VenoX.TriggerClientEvent(player, "discord_update", top, main);
        }
    }
}
