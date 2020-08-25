using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun
{
    public class Allround : IScript
    {

        //Settings
        public const int ACTION_COOLDOWN = 30;      // Zeit in minuten wann eine neue Aktion gestartet werden kann.
        public const int ACTION_WILL_END = 15;      // Zeit in minuten wann eine Aktion beendet wird automatisch.

        // Constants & Statics
        public static DateTime ActionCooldown = DateTime.Now;
        public static DateTime ActionWillEnd = DateTime.Now;
        public static bool ActionRunning = false;
        public static string ACTION_VEHICLE = "ACTION_VEHICLE";
        public static string ACTION_COLSHAPE = "ACTION_COLSHAPE";
        public static List<VehicleModel> ActionVehicles = new List<VehicleModel>();
        public static List<IColShape> ActionColShapes = new List<IColShape>();

        public const string ACTION_KOKAINTRUCK = "ACTION_KOKAINTRUCK";
        public const string ACTION_WAFFENTRUCK = "ACTION_WAFFENTRUCK";

        public static bool StartAction(VnXPlayer player, int CopCount = 0)
        {
            try
            {
                int cops = 0;
                foreach (VnXPlayer Spieler in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (Factions.Allround.isStateFaction(Spieler))
                    {
                        cops += 1;
                    }
                }
                if (cops < CopCount) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Nicht genug Cops Online!"); return false; }

                if (ActionRunning)
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Es läuft bereits eine Aktion!");
                    return false;
                }
                if (ActionCooldown >= DateTime.Now)
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Es lief bereits eine Aktion!");
                    player.SendChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Cooldown bis : " + ActionCooldown);
                    return false;
                }
                ActionRunning = true;
                ActionWillEnd = DateTime.Now.AddMinutes(ACTION_WILL_END);
                return true;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("StartAction", ex); return false; }
        }

        public static VehicleModel CreateActionVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel vehClass, Vector3 Position, Vector3 Rotation, bool WarpPlayer)
        {
            try
            {
                VehicleModel veh = (VehicleModel)Alt.CreateVehicle((uint)vehClass, Position, Rotation);
                veh.Reallife.ActionVehicle = true;
                veh.NotSave = true;
                veh.Owner = ACTION_VEHICLE;
                veh.EngineOn = true;
                veh.Godmode = false;
                if (WarpPlayer) { RageAPI.WarpIntoVehicle(player, veh, -1); }
                ActionVehicles.Add(veh);
                return veh;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateActionVehicle", ex); return null; }
        }

        public static void CreateTargetMarker(string Name, Vector3 Position, int Sprite, int Color, bool ShortRange, string Action)
        {
            try
            {
                foreach (VnXPlayer player in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    Core.RageAPI.CreateBlip(Name, Position, Sprite, Color, ShortRange, player);
                    Core.RageAPI.CreateMarker(30, Position, new Vector3(1.5f, 1.5f, 1.5f), new int[] { 255, 0, 0, 255 }, player);
                }
                ColShapeModel col = RageAPI.CreateColShapeSphere(Position, 1.5f);
                col.vnxSetElementData(ACTION_COLSHAPE, Action);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateTargetMarker", ex); }
        }

        public static void OnClientEnterColShape(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (ActionColShapes.Contains(shape))
                {
                    switch (shape.vnxGetElementData<string>(ACTION_COLSHAPE))
                    {
                        case ACTION_KOKAINTRUCK:
                            Aktionen.Kokain.KokainSell.OnPlayerEnterColShapeModel(shape, player);
                            Kokaintruck.OnPlayerEnterColShapeModel(shape, player);
                            return;
                        case ACTION_WAFFENTRUCK:
                            break;
                        default:
                            Aktionen.Shoprob.Shoprob.OnPlayerEnterColShapeModel(shape, player);
                            break;
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("CreateTargetMarker", ex); }
        }

        public static void OnUpdate()
        {
            try
            {
                if (!ActionRunning) { return; }
                Aktionen.Shoprob.Shoprob.OnUpdate();
                if (ActionWillEnd <= DateTime.Now)
                {
                    foreach (VehicleModel vehClass in ActionVehicles.ToList())
                    {
                        vehClass.Remove();
                    }
                    ActionVehicles.Clear();
                    ActionCooldown = DateTime.Now.AddMinutes(ACTION_COOLDOWN);
                    ActionRunning = false;
                }
            }
            catch { }
        }

        public static void OnResourceStart()
        {
            Kokaintruck.OnResourceStart();
            Aktionen.Kokain.KokainSell.OnResourceStart();
            Aktionen.Shoprob.Shoprob.OnResourceStart();
        }
    }
}
