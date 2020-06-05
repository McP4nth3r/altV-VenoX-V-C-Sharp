//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.dxLibary
{
    public class VnX : IScript
    {
        public const string WINDOW_JOB_1 = "Job1";
        public const string WINDOW = "Window";
        public const string WINDOW_SELECTION = "WindowSelection";
        public const string WINDOW_INPUT = "WINDOW_INPUT";
        public static void DestroyWindow(Client player, string window)
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

        public static void DestroyRadarElement(Client player, string element)
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



        public static void DrawWindow(Client player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXSAWindow", headertext, boxtext, buttontext1, buttontext2);
        }

        // Job Windows ( Job 1 = 3 Buttons , Job LvL Anzeige, Text Header , Text Info , Job description 1-3 ) 
        public static void DrawJobWindow(Client player, string headertext, string boxtext, string buttontext1, string buttontext2, string buttontext3, string button1desc, string button2desc, string button3desc, string joblvlinfo)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createJobWindow1", headertext, boxtext, buttontext1, buttontext2, buttontext3, button1desc, button2desc, button3desc, joblvlinfo);
        }

        public static void DrawWindowSelection(Client player, string headertext, string boxtext, string buttontext1, string buttontext2)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createVnXSAWindowSelection", headertext, boxtext, buttontext1, buttontext2);
        }

        public static void DrawBlip(Client player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlip", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawZielBlip(Client player, string name, Position position, int blipID, int blipRgba, int Dimension)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlipWaypoint", name, position, blipID, blipRgba, Dimension);
        }

        public static void DrawCustomZielBlip(Client player, string name, Position position, float scale, int blipID, int blipRgba, int Dimension, int r, int g, int b, int a)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeCustomBlipWaypoint", name, position, scale, blipID, blipRgba, Dimension, r, g, b, a);
        }

        public static void DrawZielBlipTable(Client player, string TableName, string name, Position position, int blipID, int blipRgba, int Dimension, int destroyedinms)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "placeBlipWaypoint_Table", TableName, name, position, blipID, blipRgba, Dimension, destroyedinms);
        }
        public static void DrawWaypoint(Client player, float x, float y)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "VnXSetWaypoint", x, y);
        }

        public static void DrawInputWindow(Client player, string headertext, string boxtext, string buttontext)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "createInputWindow", headertext, boxtext, buttontext);
        }

        public static void SetElementFrozen(Client player, bool state)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "Player:Freeze", state);
        }
        public static void SetDelayedIVehicleElementFrozen(VehicleModel Vehicle, IPlayer sender, bool state, int TimeInMS)
        {
            if (Vehicle != null)
            {
                AltV.Net.Alt.Server.TriggerClientEvent(sender, "FreezeVEHICLE_DelayedPLAYER_VnX", Vehicle, state, TimeInMS);
            }
        }
        public static void CreateDiscordUpdate(Client player, string top, string main)
        {
            AltV.Net.Alt.Server.TriggerClientEvent(player, "discord_update", top, main);
        }
    }
}
