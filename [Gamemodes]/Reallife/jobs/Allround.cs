using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs
{
    public class Allround : IScript
    {

        public static ColShapeModel CITY_TRANSPORT_Col = RageAPI.CreateColShapeSphere(new Vector3(864.2459f, -2312.139f, 30), 2);
        public static ColShapeModel AIRPORT_JOB_Col = RageAPI.CreateColShapeSphere(new Vector3(-1047.312f, -2744.564f, 21.3594f), 2);
        public static ColShapeModel BUS_JOB_Col = RageAPI.CreateColShapeSphere(new Vector3(438.2896f, -626.1547f, 28.70835f), 2);
        public static void OnPlayerEnterJobStartShape(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == CITY_TRANSPORT_Col)
                {
                    if (player.Reallife.Job == Constants.JOB_CITY_TRANSPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.LIEFERJOB_LEVEL);
                    }
                    else if (player.Reallife.Job == "Arbeitslos")
                    {
                        dxLibary.VnX.DrawWindow(player, "Venox City Transport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Transport!<br>Du liebst es zu Fahren ?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Transporter Starten ?", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
                else if (shape == AIRPORT_JOB_Col)
                {
                    if (player.Reallife.Job == Constants.JOB_AIRPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.AIRPORTJOB_LEVEL);
                    }
                    else if (player.Reallife.Job == Constants.JOB_NONE)
                    {
                        dxLibary.VnX.DrawWindow(player, "LS Airport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Airport!<br>Du liebst es zu Fliegen?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Pilot Starten ?", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
                else if (shape == BUS_JOB_Col)
                {
                    if (player.Reallife.Job == Constants.JOB_BUS)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.BUSJOB_LEVEL);
                    }
                    else if (player.Reallife.Job == Constants.JOB_NONE)
                    {
                        dxLibary.VnX.DrawWindow(player, "VenoX Busdepot", "Hallo " + player.Username + ",<br>willkommen beim VenoX City Busdepot!<br>Du liebst es mit einem 500.000$ Benz zu fahren?<br>Du liebst es jedentag heiße Frauen in deinem Fahrzeug zu haben?<br>Dann werde heute noch Busfahrer!", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        // Wenn der Spieler seinen Job annimmt im Marker.
        [VenoXRemoteEvent("accept_job_server")]
        public void Accept_job(VnXPlayer player, string windowname)
        {
            try
            {
                switch (windowname)
                {
                    case "Venox City Transport":
                        player.Reallife.Job = Constants.JOB_CITY_TRANSPORT;
                        dxLibary.VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 100<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL));
                        break;
                    case "LS Airport":
                        player.Reallife.Job = Constants.JOB_AIRPORT;
                        dxLibary.VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL));
                        break;
                    case "VenoX Busdepot":
                        player.Reallife.Job = Constants.JOB_BUS;
                        dxLibary.VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL));
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("Job:StartStage")]
        public void trigger_job_window_1_buttons(VnXPlayer player, int stage)
        {
            try
            {
                switch (player.Reallife.Job)
                {
                    case Constants.JOB_CITY_TRANSPORT:

                        break;
                    case Constants.JOB_AIRPORT:
                        Airport.Airport.Airport_job_start(player, stage);
                        break;

                    case Constants.JOB_BUS:
                        Bus.Bus.StartBusJob(player, stage);
                        break;

                    default:
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "du bist bei keinem Job");
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "dein Job " + player.Reallife.Job);
                        break;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


        [Command("quitjob")]
        public static void QuitJobServer(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job != Constants.JOB_NONE)
                {
                    player.Reallife.Job = Constants.JOB_NONE;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du bist nun Arbeitslos.");
                }
            }
            catch { }
        }

        /* Usefull Functions & Calling - Events/Functions */

        public static List<IColShape> CurrentJobColShapes = new List<IColShape>();
        public static List<BlipModel> CurrentJobBlips = new List<BlipModel>();
        public static List<MarkerModel> CurrentJobMarker = new List<MarkerModel>();
        public static string JOB_COLCLASS_ENTITY = "JOB_COLCLASS_ENTITY";
        public static string JOB_COL_ENTITY = "JOB_COL_ENTITY";
        public static string JOB_MARKER_ENTITY = "JOB_MARKER_ENTITY";
        public static string JOB_BLIP_ENTITY = "JOB_BLIP_ENTITY";

        public static void CreateJobMarker(VnXPlayer player, int BlipID, Vector3 Position, int Scale, int[] Color)
        {
            try
            {
                player.DrawWaypoint(Position.X, Position.Y);
                MarkerModel markerClass = RageAPI.CreateMarker(30, Position, new Vector3(Scale), Color, player, player.Dimension);
                BlipModel blipClass = RageAPI.CreateBlip("Abgabe [Job]", Position, BlipID, 75, false, player);
                ColShapeModel colClass = RageAPI.CreateColShapeSphere(Position, Scale, player.Dimension);
                player.vnxSetElementData(JOB_MARKER_ENTITY, markerClass);
                player.vnxSetElementData(JOB_BLIP_ENTITY, blipClass);
                player.vnxSetElementData(JOB_COL_ENTITY, colClass);
                player.vnxSetElementData(JOB_COLCLASS_ENTITY, colClass);
                CurrentJobMarker.Add(markerClass);
                CurrentJobBlips.Add(blipClass);
                CurrentJobColShapes.Add(colClass);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static VehicleModel CreateJobVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel veh, Vector3 Position, Vector3 Rotation, string Job, int Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION, bool WarpIntoVehicle = true)
        {
            try
            {
                VehicleModel JobVehicle = (VehicleModel)Alt.CreateVehicle(veh, Position, Rotation);
                player.Dimension = Dimension;
                JobVehicle.Dimension = Dimension;
                JobVehicle.EngineOn = true;
                JobVehicle.Owner = player.Username;
                JobVehicle.Kms = 0;
                JobVehicle.Gas = 100;
                JobVehicle.Job = Job;
                JobVehicle.NotSave = true;
                if (WarpIntoVehicle) { player.WarpIntoVehicle(JobVehicle, -1); }
                return JobVehicle;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }

        public static void DestroyJobMarker(VnXPlayer player)
        {
            try
            {
                //Remove ColShapes
                IColShape col = player.vnxGetElementData<IColShape>(JOB_COL_ENTITY);
                if (col != null)
                {
                    if (CurrentJobColShapes.Contains(col))
                    {
                        ColShapeModel ColModel = player.vnxGetElementData<ColShapeModel>(JOB_COLCLASS_ENTITY);
                        if (ColModel != null) { RageAPI.RemoveColShape(ColModel); }
                        else { Alt.RemoveColShape(col); }
                        CurrentJobColShapes.Remove(col);
                    }
                }
                //Remove Marker
                MarkerModel MarkerModel = player.vnxGetElementData<MarkerModel>(JOB_MARKER_ENTITY);
                if (MarkerModel != null)
                {
                    if (CurrentJobMarker.Contains(MarkerModel))
                    {
                        RageAPI.RemoveMarker(MarkerModel);
                        CurrentJobMarker.Remove(MarkerModel);
                    }
                }
                //Remove Blips
                BlipModel BlipModel = player.vnxGetElementData<BlipModel>(JOB_BLIP_ENTITY);
                if (BlipModel != null)
                {
                    if (CurrentJobBlips.Contains(BlipModel))
                    {
                        RageAPI.RemoveBlip(BlipModel, player);
                        CurrentJobBlips.Remove(BlipModel);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static bool OnColShapeHit(IColShape col, VnXPlayer player)
        {
            try
            {
                if (!CurrentJobColShapes.Contains(col) || player.vnxGetElementData<IColShape>(JOB_COL_ENTITY) != col) return false;

                if (CurrentJobColShapes.Contains(col) && player.vnxGetElementData<IColShape>(JOB_COL_ENTITY) == col)
                {
                    switch (player.Reallife.Job)
                    {
                        case Constants.JOB_AIRPORT:
                            Airport.Airport.OnJobMarkerHit(player);
                            break;
                        case Constants.JOB_BUS:
                            Bus.Bus.OnJobMarkerHit(player);
                            break;
                        case Constants.JOB_CITY_TRANSPORT:

                            break;
                    }
                    return true;
                }
                else { OnPlayerEnterJobStartShape(col, player); return true; }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }
        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                DestroyJobMarker(player);
                foreach (VehicleModel vehClass in VenoXV._Globals_.Main.ReallifeVehicles.ToList())
                {
                    if (vehClass.Job == player.Reallife.Job && vehClass.Owner == player.Reallife.Job)
                    {
                        RageAPI.DeleteVehicleThreadSafe(vehClass);
                        //vehClass.Remove();
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void OnPlayerLeaveVehicle(VehicleModel vehClass, VnXPlayer player, byte Seat)
        {
            try
            {
                Airport.Airport.OnPlayerExitVehicle(vehClass, player);
                Bus.Bus.OnPlayerLeaveVehicle(vehClass, player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
