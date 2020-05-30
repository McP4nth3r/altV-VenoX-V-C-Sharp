﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.SWT
{
    public class Marker_WT : IScript
    {
        public static ColShapeModel LSPD_COL { get; set; }
        public static ColShapeModel MAFIA_COL { get; set; }
        public static ColShapeModel YAKUZA_COL { get; set; }
        public static ColShapeModel VATOSLOCOS_COL { get; set; }
        public static ColShapeModel AOD_COL { get; set; }
        public static ColShapeModel BALLAS_COL { get; set; }
        public static ColShapeModel COMPTON_COL { get; set; }
        /*public static Marker LSPD_MARKER { get; set; }
        public static Marker LCN_MARKER { get; set; }
        public static Marker YAKUZA_MARKER { get; set; }
        public static Marker VL_MARKER { get; set; }
        public static Marker AOD_MARKER { get; set; }
        public static Marker BALLAS_MARKER { get; set; }
        public static Marker COMPTON_MARKER { get; set; }
        */
        public static string CURRENT_WEAPONTRUCK = "Staatswaffentruck";
        public static void CreateFactionWTEnter(bool stattedelete, string type)
        {
            try
            {
                if (stattedelete == false)
                {
                    if (type == "SWT")
                    {
                        LSPD_COL = RageAPI.CreateColShapeSphere(new Position(479.4737f, -1020.995f, 27.74058f), 2f);
                        LSPD_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_POLICE);
                        //LSPD_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(479.4737f, -1020.995f, 27.74058f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
                        CURRENT_WEAPONTRUCK = "Staatswaffentruck";
                    }
                    else
                    {
                        CURRENT_WEAPONTRUCK = "Waffentruck";
                        MAFIA_COL = RageAPI.CreateColShapeSphere(new Position(-1045.836f, 209.3303f, 63.32611f), 2f);
                        MAFIA_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_COSANOSTRA);
                        //LCN_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-1045.836f, 209.3303f, 63.32611f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        YAKUZA_COL = RageAPI.CreateColShapeSphere(new Position(-1463.687f, 886.5746f, 183.0481f), 2f);
                        YAKUZA_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_YAKUZA);
                        //YAKUZA_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-1463.687, 886.5746, 183.0481), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        VATOSLOCOS_COL = RageAPI.CreateColShapeSphere(new Position(890.6336f, -1079.333f, 30.53848f), 2f);
                        VATOSLOCOS_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_MS13);
                        //VL_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(890.6336f, -1079.333f, 30.53848f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        AOD_COL = RageAPI.CreateColShapeSphere(new Position(533.7743f, -179.3259f, 54.38534f), 2f);
                        AOD_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_SAMCRO);
                        //AOD_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(533.7743f, -179.3259f, 54.38534f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        BALLAS_COL = RageAPI.CreateColShapeSphere(new Position(271.0188f, -2091.159f, 16.44794f), 2f);
                        BALLAS_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_BALLAS);
                        //BALLAS_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(271.0188f, -2091.159f, 16.44794f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        COMPTON_COL = RageAPI.CreateColShapeSphere(new Position(103.1415f, -1939.005f, 20.80372f), 2f);
                        COMPTON_COL.vnxSetElementData("WT_COL_FACTION", Constants.FACTION_GROVE);
                        //COMPTON_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(103.1415f, -1939.005f, 20.80372f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                    }
                }
                else
                {
                    RageAPI.RemoveColShape(LSPD_COL);
                    //LSPD_MARKER.Remove();
                    RageAPI.RemoveColShape(MAFIA_COL);
                    //LCN_MARKER.Remove();
                    RageAPI.RemoveColShape(YAKUZA_COL);
                    //YAKUZA_MARKER.Remove();
                    RageAPI.RemoveColShape(VATOSLOCOS_COL);
                    //VL_MARKER.Remove();
                    RageAPI.RemoveColShape(AOD_COL);
                    //AOD_MARKER.Remove();
                    RageAPI.RemoveColShape(BALLAS_COL);
                    //BALLAS_COL.Remove();
                    RageAPI.RemoveColShape(COMPTON_COL);
                    // COMPTON_COL.Remove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION CreateFactionWTEnter] " + ex.Message);
                Console.WriteLine("[EXCEPTION CreateFactionWTEnter] " + ex.StackTrace);
            }
        }


        //[ServerEvent(Event.IVehicleDeath)]
        public void OnIVehicleDeath(IVehicle veh)
        {
            try
            {
                /*if (veh.GetSharedData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200,0,0) + "Der Waffentruck wurde zerstört!");
                    RageAPI.RemoveColShape(LSPD_COL);
                    //LSPD_MARKER.Remove();
                    RageAPI.RemoveColShape(MAFIA_COL);
                    //LCN_MARKER.Remove();
                    RageAPI.RemoveColShape(YAKUZA_COL);
                    //YAKUZA_MARKER.Remove();
                    RageAPI.RemoveColShape(VATOSLOCOS_COL);
                    //VL_MARKER.Remove();
                    RageAPI.RemoveColShape(AOD_COL);
                    //AOD_MARKER.Remove();
                    RageAPI.RemoveColShape(BALLAS_COL);
                    //BALLAS_COL.Remove();
                    RageAPI.RemoveColShape(COMPTON_COL);
                    //COMPTON_COL.Remove();
                    veh.Remove();
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION OnIVehicleDeath] " + ex.Message);
                Console.WriteLine("[EXCEPTION OnIVehicleDeath] " + ex.StackTrace);
            }
        }


        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<int>("WT_COL_FACTION") > 0)
                {
                    int faction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                    if (faction > 0)
                    {
                        if (player.IsInVehicle)
                        {
                            VehicleModel vehicle = (VehicleModel)player.Vehicle;
                            if (vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                            {
                                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) > 0)
                                {
                                    factions.Faction.CreateFactionMessage((int)shape.vnxGetElementData<int>("WT_COL_FACTION"), " hat den " + CURRENT_WEAPONTRUCK + " Erfolgreich in eurer Base abgegeben!", RageAPI.GetHexColorcode(0, 150, 200) + "", player);
                                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(175, 0, 0) + "Der " + CURRENT_WEAPONTRUCK + " wurde abgegeben!");
                                    if (CURRENT_WEAPONTRUCK == "Staatswaffentruck")
                                    {
                                        SWT.FinishSWT(player, vehicle, (int)shape.vnxGetElementData<int>("WT_COL_FACTION"));
                                        RageAPI.RemoveColShape(LSPD_COL);
                                    }
                                    else
                                    {
                                        WT.WT.FinishWT(player, vehicle, (int)shape.vnxGetElementData<int>("WT_COL_FACTION"));
                                        RageAPI.RemoveColShape(MAFIA_COL);
                                        RageAPI.RemoveColShape(YAKUZA_COL);
                                        RageAPI.RemoveColShape(VATOSLOCOS_COL);
                                        RageAPI.RemoveColShape(AOD_COL);
                                        RageAPI.RemoveColShape(BALLAS_COL);
                                        RageAPI.RemoveColShape(COMPTON_COL);
                                    }
                                    // player.WarpOutOfVehicle<bool>();
                                    AltV.Net.Alt.RemoveVehicle(vehicle);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION CreateFactionWTEnter] " + ex.Message);
                Console.WriteLine("[EXCEPTION CreateFactionWTEnter] " + ex.StackTrace);
            }
        }
    }
}
