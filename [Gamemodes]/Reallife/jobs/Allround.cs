using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Reallife.jobs
{
    public class Allround : IScript
    {

        public static ColShapeModel CityTransportCol = RageApi.CreateColShapeSphere(new Vector3(864.2459f, -2312.139f, 30), 2);
        public static ColShapeModel AirportJobCol = RageApi.CreateColShapeSphere(new Vector3(-1047.312f, -2744.564f, 21.3594f), 2);
        public static ColShapeModel BusJobCol = RageApi.CreateColShapeSphere(new Vector3(438.2896f, -626.1547f, 28.70835f), 2);
        public static void OnPlayerEnterJobStartShape(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == CityTransportCol)
                {
                    switch (player.Reallife.Job)
                    {
                        case Constants.JobCityTransport:
                            VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.TruckerJobLevel);
                            break;
                        case "Arbeitslos":
                            VnX.DrawWindow(player, "Venox City Transport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Transport!<br>Du liebst es zu Fahren ?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Transporter Starten ?", "Job Annehmen", "Job Ablehnen");
                            break;
                        default:
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                            break;
                    }
                }
                else if (shape == AirportJobCol)
                {
                    switch (player.Reallife.Job)
                    {
                        case Constants.JobAirport:
                            VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.AirportJobLevel);
                            break;
                        case Constants.JobNone:
                            VnX.DrawWindow(player, "LS Airport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Airport!<br>Du liebst es zu Fliegen?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Pilot Starten ?", "Job Annehmen", "Job Ablehnen");
                            break;
                        default:
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                            break;
                    }
                }
                else if (shape == BusJobCol)
                {
                    switch (player.Reallife.Job)
                    {
                        case Constants.JobBus:
                            VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.Reallife.BusJobLevel);
                            break;
                        case Constants.JobNone:
                            VnX.DrawWindow(player, "VenoX Busdepot", "Hallo " + player.Username + ",<br>willkommen beim VenoX City Busdepot!<br>Du liebst es mit einem 500.000$ Benz zu fahren?<br>Du liebst es jedentag heiße Frauen in deinem Fahrzeug zu haben?<br>Dann werde heute noch Busfahrer!", "Job Annehmen", "Job Ablehnen");
                            break;
                        default:
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                            break;
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
                        player.Reallife.Job = Constants.JobCityTransport;
                        VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 100<br>", "Dein Job-level beträgt : " + player.VnxGetElementData<int>(EntityData.PlayerLieferjobLevel));
                        break;
                    case "LS Airport":
                        player.Reallife.Job = Constants.JobAirport;
                        VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.VnxGetElementData<int>(EntityData.PlayerAirportjobLevel));
                        break;
                    case "VenoX Busdepot":
                        player.Reallife.Job = Constants.JobBus;
                        VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.VnxGetElementData<int>(EntityData.PlayerBusjobLevel));
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("Job:StartStage")]
        public void trigger_job_window_1_buttons(VnXPlayer player, int stage)
        {
            try
            {
                switch (player.Reallife.Job)
                {
                    case Constants.JobCityTransport:

                        break;
                    case Constants.JobAirport:
                        Airport.Airport.Airport_job_start(player, stage);
                        break;

                    case Constants.JobBus:
                        Bus.Bus.StartBusJob(player, stage);
                        break;

                    default:
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "du bist bei keinem Job");
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "dein Job " + player.Reallife.Job);
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }


        [Command("quitjob")]
        public static void QuitJobServer(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Job != Constants.JobNone)
                {
                    player.Reallife.Job = Constants.JobNone;
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du bist nun Arbeitslos.");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        /* Usefull Functions & Calling - Events/Functions */

        public static List<IColShape> CurrentJobColShapes = new List<IColShape>();
        public static List<BlipModel> CurrentJobBlips = new List<BlipModel>();
        public static List<MarkerModel> CurrentJobMarker = new List<MarkerModel>();
        public static string JobColclassEntity = "JOB_COLCLASS_ENTITY";
        public static string JobColEntity = "JOB_COL_ENTITY";
        public static string JobMarkerEntity = "JOB_MARKER_ENTITY";
        public static string JobBlipEntity = "JOB_BLIP_ENTITY";

        public static void CreateJobMarker(VnXPlayer player, int blipId, Vector3 position, int scale, int[] color)
        {
            try
            {
                player.DrawWaypoint(position.X, position.Y);
                MarkerModel markerClass = RageApi.CreateMarker(30, position, new Vector3(scale), color, player, player.Dimension);
                BlipModel blipClass = RageApi.CreateBlip("Abgabe [Job]", position, blipId, 75, false, player);
                ColShapeModel colClass = RageApi.CreateColShapeSphere(position, scale, player.Dimension);
                player.VnxSetElementData(JobMarkerEntity, markerClass);
                player.VnxSetElementData(JobBlipEntity, blipClass);
                player.VnxSetElementData(JobColEntity, colClass);
                player.VnxSetElementData(JobColclassEntity, colClass);
                CurrentJobMarker.Add(markerClass);
                CurrentJobBlips.Add(blipClass);
                CurrentJobColShapes.Add(colClass);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static VehicleModel CreateJobVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel veh, Vector3 position, Vector3 rotation, string job, int dimension = Main.ReallifeDimension, bool warpIntoVehicle = true)
        {
            try
            {
                VehicleModel jobVehicle = (VehicleModel)Alt.CreateVehicle(veh, position, rotation);
                player.Dimension = dimension;
                jobVehicle.Dimension = dimension;
                jobVehicle.EngineOn = true;
                jobVehicle.Owner = player.Username;
                jobVehicle.Kms = 0;
                jobVehicle.Gas = 100;
                jobVehicle.Job = job;
                jobVehicle.NotSave = true;
                if (warpIntoVehicle) { player.WarpIntoVehicle(jobVehicle, -1); }
                return jobVehicle;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }

        public static void DestroyJobMarker(VnXPlayer player)
        {
            try
            {
                //Remove ColShapes
                IColShape col = player.VnxGetElementData<IColShape>(JobColEntity);
                if (col != null)
                {
                    if (CurrentJobColShapes.Contains(col))
                    {
                        ColShapeModel colModel = player.VnxGetElementData<ColShapeModel>(JobColclassEntity);
                        if (colModel != null) { RageApi.RemoveColShape(colModel); }
                        else { Alt.RemoveColShape(col); }
                        CurrentJobColShapes.Remove(col);
                    }
                }
                //Remove Marker
                MarkerModel markerModel = player.VnxGetElementData<MarkerModel>(JobMarkerEntity);
                if (markerModel != null)
                {
                    if (CurrentJobMarker.Contains(markerModel))
                    {
                        RageApi.RemoveMarker(markerModel);
                        CurrentJobMarker.Remove(markerModel);
                    }
                }
                //Remove Blips
                BlipModel blipModel = player.VnxGetElementData<BlipModel>(JobBlipEntity);
                if (blipModel != null)
                {
                    if (CurrentJobBlips.Contains(blipModel))
                    {
                        RageApi.RemoveBlip(blipModel, player);
                        CurrentJobBlips.Remove(blipModel);
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static bool OnColShapeHit(IColShape col, VnXPlayer player)
        {
            try
            {
                if (!CurrentJobColShapes.Contains(col) || player.VnxGetElementData<IColShape>(JobColEntity) != col) return false;

                if (CurrentJobColShapes.Contains(col) && player.VnxGetElementData<IColShape>(JobColEntity) == col)
                {
                    switch (player.Reallife.Job)
                    {
                        case Constants.JobAirport:
                            Airport.Airport.OnJobMarkerHit(player);
                            break;
                        case Constants.JobBus:
                            Bus.Bus.OnJobMarkerHit(player);
                            break;
                        case Constants.JobCityTransport:

                            break;
                    }
                    return true;
                }

                OnPlayerEnterJobStartShape(col, player); return true;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
        public static void OnPlayerDisconnect(VnXPlayer player)
        {
            try
            {
                DestroyJobMarker(player);
                foreach (VehicleModel vehClass in Main.ReallifeVehicles.ToList())
                {
                    if (vehClass.Job == player.Reallife.Job && vehClass.Owner == player.Reallife.Job)
                    {
                        RageApi.DeleteVehicleThreadSafe(vehClass);
                        //vehClass.Remove();
                    }
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        public static void OnPlayerLeaveVehicle(VehicleModel vehClass, VnXPlayer player, byte seat)
        {
            try
            {
                Airport.Airport.OnPlayerExitVehicle(vehClass, player);
                Bus.Bus.OnPlayerLeaveVehicle(vehClass, player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
