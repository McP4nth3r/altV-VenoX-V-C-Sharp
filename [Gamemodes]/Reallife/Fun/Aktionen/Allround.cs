using AltV.Net;
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
        public static List<BlipModel> ActionBlips = new List<BlipModel>();
        public static List<MarkerModel> ActionMarkers = new List<MarkerModel>();
        public static List<ColShapeModel> ActionColShapes = new List<ColShapeModel>();

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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        public static VehicleModel CreateActionVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel vehClass, Vector3 Position, Vector3 Rotation, bool WarpPlayer)
        {
            try
            {
                VehicleModel veh = (VehicleModel)Alt.CreateVehicle((uint)vehClass, Position, Rotation);
                veh.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Language;
                veh.Reallife.ActionVehicle = true;
                veh.NotSave = true;
                veh.Owner = ACTION_VEHICLE;
                veh.EngineOn = true;
                veh.Godmode = false;
                if (WarpPlayer) RageAPI.WarpIntoVehicle(player, veh, -1);
                ActionVehicles.Add(veh);
                return veh;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }

        public static void CreateTargetMarker(string Name, Vector3 Position, int Sprite, int Color, bool ShortRange, string Action)
        {
            try
            {
                foreach (VnXPlayer player in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    ActionBlips.Add(RageAPI.CreateBlip(Name, Position, Sprite, Color, ShortRange, player));
                }
                ActionMarkers.Add(RageAPI.CreateMarker(30, Position, new Vector3(1.5f, 1.5f, 1.5f), new int[] { 255, 0, 0, 255 }));
                ColShapeModel col = RageAPI.CreateColShapeSphere(Position, 1.5f, VenoXV.Globals.Main.REALLIFE_DIMENSION);
                col.AktionCol = Action;
                ActionColShapes.Add(col);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void DestroyTargetMarker()
        {
            try
            {
                //Remoe Blips
                foreach (BlipModel blipClass in ActionBlips.ToList()) RageAPI.RemoveBlip(blipClass, blipClass.VisibleOnlyFor);
                //Remove Markers
                foreach (MarkerModel markerClass in ActionMarkers.ToList()) RageAPI.RemoveMarker(markerClass);
                //Remove ColShapes
                foreach (ColShapeModel colClass in ActionColShapes.ToList()) RageAPI.RemoveColShape(colClass);

                foreach (VehicleModel vehClass in ActionVehicles.ToList()) RageAPI.DeleteVehicleThreadSafe((VehicleModel)vehClass);


                ActionBlips.Clear();
                ActionMarkers.Clear();
                ActionVehicles.Clear();
                ActionColShapes.Clear();
                //Add CoolDown
                ActionCooldown = DateTime.Now.AddMinutes(ACTION_COOLDOWN);
                ActionRunning = false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static bool OnClientEnterColShape(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (!ActionColShapes.Contains(shape)) return false;
                Aktionen.Kokain.KokainSell.OnPlayerEnterColShapeModel(shape, player);
                Kokaintruck.OnPlayerEnterColShapeModel(shape, player);
                return true;
                //Aktionen.Shoprob.Shoprob.OnPlayerEnterColShapeModel(shape, player);

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        public static void OnUpdate()
        {
            try
            {
                if (!ActionRunning) return;
                Aktionen.Shoprob.Shoprob.OnUpdate();
                if (ActionWillEnd <= DateTime.Now)
                {
                    foreach (VehicleModel vehClass in ActionVehicles.ToList())
                        RageAPI.DeleteVehicleThreadSafe((VehicleModel)vehClass);
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
