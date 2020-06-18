using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
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

        public static void OnPlayerEnterJobStartShape(IColShape shape, Client player)
        {
            try
            {
                if (shape == CITY_TRANSPORT_Col.Entity)
                {
                    if (player.Reallife.Job == Constants.JOB_CITY_TRANSPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL));
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
                else if (shape == AIRPORT_JOB_Col.Entity)
                {
                    if (player.Reallife.Job == Constants.JOB_AIRPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL));
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
                else if (shape == BUS_JOB_Col.Entity)
                {
                    if (player.Reallife.Job == Constants.JOB_BUS)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL));
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
            catch (Exception ex) { Debug.CatchExceptions("OnJobAcceptColHit", ex); }
        }
        // Wenn der Spieler seinen Job annimmt im Marker.
        [ClientEvent("accept_job_server")]
        public void Accept_job(Client player, string windowname)
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

        [ClientEvent("Job:StartStage")]
        public void trigger_job_window_1_buttons(Client player, int stage)
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

                        break;

                    default:
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "du bist bei keinem Job");
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "dein Job " + player.Reallife.Job);
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("TriggerJobButton", ex); }
        }


        [Command("quitjob")]
        public static void QuitJobServer(Client player)
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

        public static void CreateJobMarker(Client player, int BlipID, Vector3 Position, int Scale, int[] Color)
        {
            MarkerModel markerClass = RageAPI.CreateMarker(30, Position, new Vector3(Scale), Color, player);
            BlipModel blipClass = RageAPI.CreateBlip("Abgabe [Job]", Position, BlipID, 75, false, player);
            ColShapeModel colClass = RageAPI.CreateColShapeSphere(Position, Scale);
            player.vnxSetElementData(JOB_MARKER_ENTITY, markerClass);
            player.vnxSetElementData(JOB_BLIP_ENTITY, blipClass);
            player.vnxSetElementData(JOB_COL_ENTITY, colClass.Entity);
            player.vnxSetElementData(JOB_COLCLASS_ENTITY, colClass);
            CurrentJobMarker.Add(markerClass);
            CurrentJobBlips.Add(blipClass);
            CurrentJobColShapes.Add(colClass.Entity);
        }
        public static void DestroyJobMarker(Client player)
        {
            //Remove ColShapes
            if (CurrentJobColShapes.Contains(player.vnxGetElementData<IColShape>(JOB_COL_ENTITY)))
            {
                RageAPI.RemoveColShape(player.vnxGetElementData<ColShapeModel>(JOB_COLCLASS_ENTITY));
                CurrentJobColShapes.Remove(player.vnxGetElementData<IColShape>(JOB_COL_ENTITY));
            }
            //Remove Marker
            if (CurrentJobMarker.Contains(player.vnxGetElementData<MarkerModel>(JOB_MARKER_ENTITY)))
            {
                CurrentJobMarker.Remove(player.vnxGetElementData<MarkerModel>(JOB_MARKER_ENTITY));
            }
            //Remove Blips
            if (CurrentJobBlips.Contains(player.vnxGetElementData<BlipModel>(JOB_BLIP_ENTITY)))
            {
                CurrentJobBlips.Remove(player.vnxGetElementData<BlipModel>(JOB_BLIP_ENTITY));
            }
        }

        public static void OnColShapeHit(IColShape col, Client player)
        {
            OnPlayerEnterJobStartShape(col, player);
            if (CurrentJobColShapes.Contains(col))
            {
                switch (player.Reallife.Job)
                {
                    case Constants.JOB_AIRPORT:
                        Airport.Airport.OnJobMarkerHit(player);
                        break;
                    case Constants.JOB_BUS:

                        break;
                    case Constants.JOB_CITY_TRANSPORT:

                        break;
                }
            }
        }
        public static void OnPlayerDisconnect(Client player)
        {
            DestroyJobMarker(player);
        }
    }
}
