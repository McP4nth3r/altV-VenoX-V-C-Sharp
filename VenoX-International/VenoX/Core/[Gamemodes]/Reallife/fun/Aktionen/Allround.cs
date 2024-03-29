﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.fun.Aktionen.Kokain;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.fun.Aktionen
{
    public class Allround : IScript
    {
        //Settings
        public static int ActionCooldown = 30;
        public const int ActionWillEnd = 15;      // Zeit in minuten wann eine Aktion beendet wird automatisch.

        // Constants & Statics
        public static DateTime ActionCooldownDateTime = DateTime.Now;
        public static DateTime ActionWillEndDateTime = DateTime.Now;
        public static bool ActionRunning;
        private static readonly string ActionVehicle = "ACTION_VEHICLE";
        private static readonly List<VehicleModel> ActionVehicles = new List<VehicleModel>();
        private static readonly List<BlipModel> ActionBlips = new List<BlipModel>();
        private static readonly List<MarkerModel> ActionMarkers = new List<MarkerModel>();
        private static readonly List<ColShapeModel> ActionColShapes = new List<ColShapeModel>();

        public const string ActionKokaintruck = "ACTION_KOKAINTRUCK";
        public const string ActionWaffentruck = "ACTION_WAFFENTRUCK";

        public static bool StartAction(VnXPlayer player, int copCount = 0)
        {
            try
            {
                int cops = Enumerable.Count<VnXPlayer>(Initialize.ReallifePlayers, factions.Allround.IsStateFaction);
                if (cops < copCount) { _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Nicht genug Cops Online!"); return false; }

                if (ActionRunning)
                {
                    player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Es läuft bereits eine Aktion!");
                    return false;
                }
                if (ActionCooldownDateTime >= DateTime.Now)
                {
                    player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Es lief bereits eine Aktion!");
                    player.SendChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Cooldown bis : " + ActionCooldownDateTime);
                    return false;
                }
                ActionRunning = true;
                ActionCooldownDateTime = DateTime.Now.AddMinutes(ActionWillEnd);
                return true;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }

        public static VehicleModel CreateActionVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel vehClass, Vector3 position, Vector3 rotation, bool warpPlayer)
        {
            try
            {
                VehicleModel veh = (VehicleModel)Alt.CreateVehicle((uint)vehClass, position, rotation);
                veh.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                veh.Reallife.ActionVehicle = true;
                veh.NotSave = true;
                veh.Owner = ActionVehicle;
                veh.EngineOn = true;
                veh.Godmode = false;
                if (warpPlayer) player.WarpIntoVehicle(veh, -1);
                ActionVehicles.Add(veh);
                return veh;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return null; }
        }

        public static void CreateTargetMarker(string name, Vector3 position, int sprite, int color, bool shortRange, string action)
        {
            try
            {
                foreach (VnXPlayer player in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
                {
                    ActionBlips.Add(RageApi.CreateBlip(name, position, sprite, color, shortRange, player));
                }
                ActionMarkers.Add(RageApi.CreateMarker(30, position, new Vector3(1.5f, 1.5f, 1.5f), new[] { 255, 0, 0, 255 }));
                ColShapeModel col = RageApi.CreateColShapeSphere(position, 1.5f, _Globals_.Initialize.ReallifeDimension);
                col.ActionCol = action;
                ActionColShapes.Add(col);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void DestroyTargetMarker()
        {
            try
            {
                //Remoe Blips
                foreach (BlipModel blipClass in ActionBlips.ToList()) RageApi.RemoveBlip(blipClass, blipClass.VisibleOnlyFor);
                //Remove Markers
                foreach (MarkerModel markerClass in ActionMarkers.ToList()) RageApi.RemoveMarker(markerClass);
                //Remove ColShapes
                foreach (ColShapeModel colClass in ActionColShapes.ToList()) RageApi.RemoveColShape(colClass);

                foreach (VehicleModel vehClass in ActionVehicles.ToList()) RageApi.DeleteVehicleThreadSafe(vehClass);


                ActionBlips.Clear();
                ActionMarkers.Clear();
                ActionVehicles.Clear();
                ActionColShapes.Clear();
                //Add CoolDown
                ActionCooldownDateTime = DateTime.Now.AddMinutes(ActionCooldown);
                ActionRunning = false;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static bool OnClientEnterColShape(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (!ActionColShapes.Contains(shape)) return false;
                KokainSell.OnPlayerEnterColShapeModel(shape, player);
                Kokaintruck.OnPlayerEnterColShapeModel(shape, player);
                return true;
                //Aktionen.Shoprob.Shoprob.OnPlayerEnterColShapeModel(shape, player);

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }

        public static void OnUpdate()
        {
            try
            {
                if (!ActionRunning) return;
                Shoprob.Shoprob.OnUpdate();
                if (ActionWillEndDateTime <= DateTime.Now)
                {
                    foreach (VehicleModel vehClass in ActionVehicles.ToList())
                        RageApi.DeleteVehicleThreadSafe(vehClass);
                    ActionVehicles.Clear();
                    ActionCooldownDateTime = DateTime.Now.AddMinutes(ActionCooldown);
                    ActionRunning = false;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static void OnResourceStart()
        {
            Kokaintruck.OnResourceStart();
            KokainSell.OnResourceStart();
            Shoprob.Shoprob.OnResourceStart();
        }
    }
}
