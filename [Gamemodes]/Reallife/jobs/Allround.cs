using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs
{
    public class JoB_Allround : IScript
    {
        public static IColShape JobAbgabeMarker { get; set; }



        // [ScriptEvent(ScriptEventType.PlayerLeaveIVehicle)]
        public void OnPlayerExitIVehicle(IVehicle Vehicle, Client player, byte seat)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_IN_JOB) == true)
                {
                    if (player.IsInVehicle)
                    {
                        if (
                        //LieferrantenJobIVehicle
                        Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.Username
                        || Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.Username
                        || Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.Username
                        )
                        {
                            player.vnxSetElementData(EntityData.PLAYER_IS_IN_JOB, false);
                            dxLibary.VnX.DestroyRadarElement(player, "Blip");
                            dxLibary.VnX.DrawWaypoint(player, player.Position.X, player.Position.Y);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Job beendet!");
                            if (JobAbgabeMarker.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) == player.Username)
                            {
                                AltV.Net.Alt.RemoveColShape(JobAbgabeMarker);
                            }
                            if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_AIRPORT)
                            {
                                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                player.SetPosition = new Position(-1037.645f, -2737.8f, 20.16929f);
                                player.Dimension = 0;
                            }
                            else if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_BUS)
                            {
                                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                player.SetPosition = new Position(437.9306f, -615.1742f, 28.71082f);
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



        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>(EntityData.PLAYER_IS_JOB_COL) == true)
                {
                    if (shape.vnxGetElementData<string>(EntityData.PLAYER_JOB_COLSHAPE_OWNER) != player.Username)
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
                            if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT)
                            {
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                AltV.Net.Alt.RemoveColShape(shape);
                                int stage = player.vnxGetElementData<int>("JOB_STAGE_TRANSPORTER_STARTED");
                                Lieferrant.Lieferrant.TriggerToNextJobMarker(player, stage);
                                player.vnxSetElementData("JOB_MARKER_ABGEGEBEN", true);
                                Core.VnX.SetDelayedBoolSharedData(player, "JOB_MARKER_ABGEGEBEN", false, 3000);
                                if (stage == 1)
                                {
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 85);
                                    player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " 85 $ " + RageAPI.GetHexColorcode(255, 255, 255) + "Bekommen.");
                                }
                                else if (stage == 2)
                                {
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 265);
                                    player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " 265 $ " + RageAPI.GetHexColorcode(255, 255, 255) + "Bekommen.");
                                }
                                else if (stage == 3)
                                {
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 425);
                                    player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 200, 255) + " 425 $ " + RageAPI.GetHexColorcode(255, 255, 255) + "Bekommen.");
                                }
                                return;
                            }
                            else if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT)
                            {
                                int JOB_STAGE = player.vnxGetElementData<int>("JOB_STAGE_LVL_AIRPORT");
                                player.vnxSetElementData("JOB_MARKER_ABGEGEBEN", true);
                                Core.VnX.SetDelayedBoolSharedData(player, "JOB_MARKER_ABGEGEBEN", false, 3000);
                                if (JOB_STAGE == 1)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 350);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Danke! Die Passagiere sind sicher gelandet! Du erhältst 2 Punkte.");
                                    player.SendTranslatedChatMessage("Auftrag abgeschlossen! Du erhälst " + RageAPI.GetHexColorcode(0, 200, 255) + " 350 " + RageAPI.GetHexColorcode(255, 255, 255) + "$!");
                                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 2);
                                    // player.WarpOutOfVehicle<bool>();
                                    return;
                                }
                                if (JOB_STAGE == 2)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 450);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Danke! Die Passagiere sind sicher gelandet! Du erhältst 4 Punkte.");
                                    player.SendTranslatedChatMessage("Auftrag abgeschlossen! Du erhälst " + RageAPI.GetHexColorcode(0, 200, 255) + " 450 " + RageAPI.GetHexColorcode(255, 255, 255) + "$!");
                                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 4);
                                    // player.WarpOutOfVehicle<bool>();
                                    return;
                                }
                                if (JOB_STAGE == 3)
                                {
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 1500);
                                    dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                    AltV.Net.Alt.RemoveColShape(shape);
                                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + 575);
                                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Danke! Die Passagiere sind sicher gelandet! Du erhältst 6 Punkte.");
                                    player.SendTranslatedChatMessage("Auftrag abgeschlossen! Du erhälst " + RageAPI.GetHexColorcode(0, 200, 255) + " 575 " + RageAPI.GetHexColorcode(255, 255, 255) + "$!");
                                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_AIRPORTJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) + 6);
                                    // player.WarpOutOfVehicle<bool>();
                                    return;
                                }
                            }
                            else if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_BUS)
                            {
                                dxLibary.VnX.DestroyRadarElement(player, "Blip");
                                AltV.Net.Alt.RemoveColShape(shape);
                                Reallife.jobs.Bus.Busjob.TriggerToNextMarker(player);
                                // Voi La !
                            }

                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Das ist kein Job Fahrzeug!");
                            }
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Fahrzeug?!");
                    }
                }
            }
            catch
            {
            }
        }



    }
}
