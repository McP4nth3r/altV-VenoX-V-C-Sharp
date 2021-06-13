//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.dxLibary
{
    public class VnX : IScript
    {
        public const string WindowJob1 = "Job1";
        public const string Window = "Window";
        public const string WindowSelection = "WindowSelection";
        public const string WindowInput = "WINDOW_INPUT";
        public static void DestroyWindow(VnXPlayer player, string window)
        {
            switch (window)
            {
                case "Job1":
                    VenoX.TriggerClientEvent(player, "DestroyJobWindow1");
                    break;
                case "Window":
                    VenoX.TriggerClientEvent(player, "DestroyVnXSAWindowLib");
                    break;
                case "WindowSelection":
                    VenoX.TriggerClientEvent(player, "DestroyVnXSAWindowSel");
                    break;
                case WindowInput:
                    VenoX.TriggerClientEvent(player, "DestroyInputWindow");
                    break;
                default:
                    VenoX.TriggerClientEvent(player, window);
                    break;
            }
        }

        public static void DestroyRadarElement(VnXPlayer player, string element)
        {
            switch (element)
            {
                case "Blip":
                    VenoX.TriggerClientEvent(player, "deleteBlipWaypoint");
                    break;
                case "Blip_lib":
                    VenoX.TriggerClientEvent(player, "deleteBlip_lib");
                    break;
                default:
                    Logfile.WriteLogs("libLogs", "[ERROR] : Schwerwiegender Fehler! Element konnte nicht Gelöscht werden! : " + element);
                    Logfile.WriteLogs("libLogs", "[ERROR] : dieser Fehler verursacht das ein Blip oder ein Radar Wegpunkt nicht gelöscht werden konnte!");
                    break;
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

        public static void DrawBlip(VnXPlayer player, string name, Position position, int blipId, int blipRgba, int dimension)
        {
            VenoX.TriggerClientEvent(player, "placeBlip", name, position, blipId, blipRgba, dimension);
        }

        public static void DrawZielBlip(VnXPlayer player, string name, Position position, int blipId, int blipRgba, int dimension)
        {
            VenoX.TriggerClientEvent(player, "placeBlipWaypoint", name, position, blipId, blipRgba, dimension);
        }

        public static void DrawCustomZielBlip(VnXPlayer player, string name, Position position, float scale, int blipId, int blipRgba, int dimension, int r, int g, int b, int a)
        {
            VenoX.TriggerClientEvent(player, "placeCustomBlipWaypoint", name, position, scale, blipId, blipRgba, dimension, r, g, b, a);
        }

        public static void DrawZielBlipTable(VnXPlayer player, string tableName, string name, Position position, int blipId, int blipRgba, int dimension, int destroyedinms)
        {
            VenoX.TriggerClientEvent(player, "placeBlipWaypoint_Table", tableName, name, position, blipId, blipRgba, dimension, destroyedinms);
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
        public static void SetDelayedIVehicleElementFrozen(VehicleModel vehicle, VnXPlayer sender, bool state, int timeInMs)
        {
            if (vehicle != null)
            {
                VenoX.TriggerClientEvent(sender, "FreezeVEHICLE_DelayedPLAYER_VnX", vehicle, state, timeInMs);
            }
        }
        public static void CreateDiscordUpdate(VnXPlayer player, string top, string main)
        {
            VenoX.TriggerClientEvent(player, "discord_update", top, main);
        }
    }
}
