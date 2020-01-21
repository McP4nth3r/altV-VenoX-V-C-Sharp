using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.anzeigen;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.jobs
{
    public class JoB_Allround : IScript
    {
        public static IColShape JobAbgabeMarker { get; set; }



       // [ScriptEvent(ScriptEventType.PlayerLeaveIVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, IPlayer player, byte seat)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_IN_JOB) == true)
                {
                    if (player.IsInVehicle)
                    {
                        if (
                        //LieferrantenJobIVehicle
                        Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name       
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name
                        )
                        {
                            player.SetData(EntityData.PLAYER_IS_IN_JOB, false);
                            dxLibary.VnX.DestroyRadarElement(player, "Blip");
                            dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                            player.SendChatMessage("!{0,200,0}Job beendet!");
                            if (JobAbgabeMarker.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) ==player.Name)
                            {
                                AltV.Net.Alt.RemoveColShape(JobAbgabeMarker);
                            }
                            if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_AIRPORT)
                            {
                                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                player.Position = new Position(-1037.645f, -2737.8f, 20.16929f);
                                player.Dimension = 0;
                            }
                            else if(player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_BUS)
                            {
                                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                player.Position = new Position(437.9306f, -615.1742f, 28.71082f);
                                player.Dimension = 0;
                            }
                            if (Vehicle != null)
                            {
                                AltV.Net.Alt.RemoveVehicle(Vehicle);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }



        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>(EntityData.PLAYER_IS_JOB_COL) == true)
                {
                    if (shape.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) !=player.Name)
                    {
                        return;
                    }
                    if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_IN_JOB) == false)
                    {
                        AltV.Net.Alt.RemoveColShape(shape);
                        dxLibary.VnX.DestroyRadarElement(player, "Blip");
                        return;
                    }
                    if (player.IsInVehicle)
                    {
                        if (player.vnxGetElementData<bool>("JOB_MARKER_ABGEGEBEN") != true)
                        {
                            IVehicle Vehicle = player.Vehicle;
                            if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT)
                            {
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                AltV.Net.Alt.RemoveColShape(shape);
                                int stage = player.vnxGetElementData<int>("JOB_STAGE_TRANSPORTER_STARTED");
                                Lieferrant.Lieferrant.TriggerToNextJobMarker(player, stage);
                                player.SetData("JOB_MARKER_ABGEGEBEN", true);
                                Core.VnX.SetDelayedBoolSharedData(player, "JOB_MARKER_ABGEGEBEN", false, 3000);
                                if (stage == 1)
                                {
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 85);
                                    player.SendChatMessage( "Du hast !{0,200,255}85 $ !{255,255,255}Bekommen.");
                                }
                                else if (stage == 2)
                                {
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 265);
                                    player.SendChatMessage( "Du hast !{0,200,255}265 $ !{255,255,255}Bekommen.");
                                }
                                else if (stage == 3)
                                {
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 425);
                                    player.SendChatMessage( "Du hast !{0,200,255}425 $ !{255,255,255}Bekommen.");
                                }
                                return;
                            }
                            else if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT)
                            {
                                int JOB_STAGE = player.vnxGetElementData<int>("JOB_STAGE_LVL_AIRPORT");
                                player.SetData("JOB_MARKER_ABGEGEBEN", true);
                                Core.VnX.SetDelayedBoolSharedData(player, "JOB_MARKER_ABGEGEBEN", false, 3000);
                                if (JOB_STAGE == 1)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 350);
                                    player.SendChatMessage( "!{0,200,0}Danke! Die Passagiere sind sicher gelandet! Du erhältst 2 Punkte.");
                                    player.SendChatMessage( "Auftrag abgeschlossen! Du erhälst !{0,200,255}350 !{255,255,255}$!");
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 2);
                                   // //ToDo :  Fix player.WarpOutOfIVehicle();
                                    return;
                                }
                                if (JOB_STAGE == 2)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 450);
                                    player.SendChatMessage( "!{0,200,0}Danke! Die Passagiere sind sicher gelandet! Du erhältst 4 Punkte.");
                                    player.SendChatMessage( "Auftrag abgeschlossen! Du erhälst !{0,200,255}450 !{255,255,255}$!");
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 4);
                                   // //ToDo :  Fix player.WarpOutOfIVehicle();
                                    return;
                                }
                                if (JOB_STAGE == 3)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 575);
                                    player.SendChatMessage( "!{0,200,0}Danke! Die Passagiere sind sicher gelandet! Du erhältst 6 Punkte.");
                                    player.SendChatMessage( "Auftrag abgeschlossen! Du erhälst !{0,200,255}575 !{255,255,255}$!");
                                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 6);
                                   // //ToDo :  Fix player.WarpOutOfIVehicle();
                                    return;
                                }
                            }
                            else if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_BUS)
                            {
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                AltV.Net.Alt.RemoveColShape(shape);
                                Reallife.jobs.Bus.Busjob.TriggerToNextMarker(player); 
                                // Voi La !
                            }

                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Das ist kein Job Fahrzeug!");
                            }
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Fahrzeug?!");
                    }
                }
            }
            catch 
            {
            }
        }



    }
}
