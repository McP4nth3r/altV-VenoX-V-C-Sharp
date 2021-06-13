using System;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.SWT
{
    public class MarkerWt : IScript
    {
        public static ColShapeModel LspdCol { get; set; }
        public static ColShapeModel MafiaCol { get; set; }
        public static ColShapeModel YakuzaCol { get; set; }
        public static ColShapeModel VatoslocosCol { get; set; }
        public static ColShapeModel AodCol { get; set; }
        public static ColShapeModel BallasCol { get; set; }
        public static ColShapeModel ComptonCol { get; set; }
        /*public static Marker LSPD_MARKER { get; set; }
        public static Marker LCN_MARKER { get; set; }
        public static Marker YAKUZA_MARKER { get; set; }
        public static Marker VL_MARKER { get; set; }
        public static Marker AOD_MARKER { get; set; }
        public static Marker BALLAS_MARKER { get; set; }
        public static Marker COMPTON_MARKER { get; set; }
        */
        public static string CurrentWeapontruck = "Staatswaffentruck";
        public static void CreateFactionWtEnter(bool stattedelete, string type)
        {
            try
            {
                if (stattedelete == false)
                {
                    if (type == "SWT")
                    {
                        LspdCol = RageApi.CreateColShapeSphere(new Position(479.4737f, -1020.995f, 27.74058f), 2f);
                        LspdCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionLspd);
                        //LSPD_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(479.4737f, -1020.995f, 27.74058f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
                        CurrentWeapontruck = "Staatswaffentruck";
                    }
                    else
                    {
                        CurrentWeapontruck = "Waffentruck";
                        MafiaCol = RageApi.CreateColShapeSphere(new Position(-1045.836f, 209.3303f, 63.32611f), 2f);
                        MafiaCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionLcn);
                        //LCN_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-1045.836f, 209.3303f, 63.32611f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        YakuzaCol = RageApi.CreateColShapeSphere(new Position(-1463.687f, 886.5746f, 183.0481f), 2f);
                        YakuzaCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionYakuza);
                        //YAKUZA_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-1463.687, 886.5746, 183.0481), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        VatoslocosCol = RageApi.CreateColShapeSphere(new Position(890.6336f, -1079.333f, 30.53848f), 2f);
                        VatoslocosCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionNarcos);
                        //VL_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(890.6336f, -1079.333f, 30.53848f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        AodCol = RageApi.CreateColShapeSphere(new Position(533.7743f, -179.3259f, 54.38534f), 2f);
                        AodCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionSamcro);
                        //AOD_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(533.7743f, -179.3259f, 54.38534f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        BallasCol = RageApi.CreateColShapeSphere(new Position(271.0188f, -2091.159f, 16.44794f), 2f);
                        BallasCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionBallas);
                        //BALLAS_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(271.0188f, -2091.159f, 16.44794f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                        ComptonCol = RageApi.CreateColShapeSphere(new Position(103.1415f, -1939.005f, 20.80372f), 2f);
                        ComptonCol.VnxSetElementData("WT_COL_FACTION", Constants.FactionCompton);
                        //COMPTON_MARKER = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(103.1415f, -1939.005f, 20.80372f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);

                    }
                }
                else
                {
                    RageApi.RemoveColShape(LspdCol);
                    //LSPD_MARKER.Remove();
                    RageApi.RemoveColShape(MafiaCol);
                    //LCN_MARKER.Remove();
                    RageApi.RemoveColShape(YakuzaCol);
                    //YAKUZA_MARKER.Remove();
                    RageApi.RemoveColShape(VatoslocosCol);
                    //VL_MARKER.Remove();
                    RageApi.RemoveColShape(AodCol);
                    //AOD_MARKER.Remove();
                    RageApi.RemoveColShape(BallasCol);
                    //BALLAS_COL.Remove();
                    RageApi.RemoveColShape(ComptonCol);
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


        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape.VnxGetElementData<int>("WT_COL_FACTION") > 0)
                {
                    int faction = player.Reallife.Faction;
                    if (faction > 0)
                    {
                        if (player.IsInVehicle)
                        {
                            VehicleModel vehicle = (VehicleModel)player.Vehicle;
                            if (vehicle.VnxGetElementData<bool>("AKTIONS_FAHRZEUG"))
                            {
                                if (player.Reallife.Faction > 0)
                                {
                                    Faction.CreateFactionMessage(shape.VnxGetElementData<int>("WT_COL_FACTION"), " hat den " + CurrentWeapontruck + " Erfolgreich in eurer Base abgegeben!", RageApi.GetHexColorcode(0, 150, 200) + "", player);
                                    RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(175, 0, 0) + "Der " + CurrentWeapontruck + " wurde abgegeben!");
                                    if (CurrentWeapontruck == "Staatswaffentruck")
                                    {
                                        //SWT.FinishSWT(player, vehicle, (int)shape.vnxGetElementData<int>("WT_COL_FACTION"));
                                        RageApi.RemoveColShape(LspdCol);
                                    }
                                    else
                                    {
                                        //WT.WT.FinishWT(player, vehicle, (int)shape.vnxGetElementData<int>("WT_COL_FACTION"));
                                        RageApi.RemoveColShape(MafiaCol);
                                        RageApi.RemoveColShape(YakuzaCol);
                                        RageApi.RemoveColShape(VatoslocosCol);
                                        RageApi.RemoveColShape(AodCol);
                                        RageApi.RemoveColShape(BallasCol);
                                        RageApi.RemoveColShape(ComptonCol);
                                    }
                                    // player.WarpOutOfVehicle();
                                    Alt.RemoveVehicle(vehicle);
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
