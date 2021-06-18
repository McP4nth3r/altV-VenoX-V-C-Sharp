using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.globals;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class FahrzeugMain : IScript
    {
        [Command("car")]
        public void ShowIVehicleMenu(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.IsTestVehicle)
                    {
                        return;
                    }
                    VenoX.TriggerClientEvent(player, "showIVehicleMenu");
                    player.VnxSetElementData("HideHUD", 1);
                }
                else
                {
                    VehicleModel vehicle = Main.GetClosestIVehicle(player);
                    if (vehicle == null)
                    {
                        player.SendTranslatedChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                    }
                    if (vehicle.IsTestVehicle)
                    {
                    }
                    else
                    {
                        VenoX.TriggerClientEvent(player, "showIVehicleMenu");
                        player.VnxSetElementData("HideHUD", 1);
                    }
                    // Player.SendTranslatedChatMessage("Du bist in keinem Fahrzeug! ");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("showIVehicleMenu")]
        public static void ShowIVehicleMenuClicked(VnXPlayer player, VehicleModel vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    player.SendTranslatedChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                }
                else
                {
                    VenoX.TriggerClientEvent(player, "showIVehicleMenu");
                    player.VnxSetElementData("HideHUD", 1);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        //[AltV.Net.ClientEvent("ResetIVehicleTimer")]
        public static void ResetIVehicleAktionsTimer(VnXPlayer player)
        {
            player.VnxSetElementData("vehinfos_done_cmd", false);
        }

        [Command("vehinfos")]
        public void Vehiclelist(VnXPlayer player)
        {
            try
            {
                if (player.VnxGetElementData<bool>("vehinfos_done_cmd"))
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Nur alle 30 Sekunden möglich!");
                    return;
                }
                player.SendTranslatedChatMessage("---------------Fahrzeuge---------------");
                foreach (VehicleModel veh in _Globals_.Main.ReallifeVehicles.ToList())
                {
                    if (veh != null && veh.Owner == player.Username)
                    {
                        Random random = new Random();
                        int cevent = random.Next(1, 5);
                        string model = veh.Model.ToString().ToLower();
                        if (model == "" || model == null)
                        {
                            model = veh.Name;
                        }
                        switch (cevent)
                        {
                            case 1:
                                VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.DatabaseId);
                                break;
                            case 2:
                                VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.DatabaseId);
                                break;
                            case 3:
                                VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 125, 175) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.DatabaseId);
                                break;
                            case 4:
                                VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 5, player.Dimension, 30000);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(255, 140, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.DatabaseId);
                                break;
                            case 5:
                                VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 7, player.Dimension, 30000);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(165, 0, 165) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.DatabaseId);
                                break;
                        }

                    }
                }
                player.VnxSetElementData("vehinfos_done_cmd", true);
                player.SendTranslatedChatMessage("---------------------------------------");
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("LockIVehicleServer")]
        public void LockLocalIVehicle(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.Owner == player.Username)
                    {
                        //IVehicle.Locked = !IVehicle.Locked;
                        //player.SendTranslatedChatMessage( IVehicle.Locked ? "Fahrzeug ~r~Abgeschlossen" : "Fahrzeug ~g~Aufgeschlossen", true);
                    }
                }
                else
                {
                    VehicleModel vehicle = Main.GetClosestIVehicle(player);
                    if (vehicle == null)
                    {
                        //player.SendTranslatedChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (vehicle.Owner == player.Username)
                        {
                            //IVehicle.Locked = !IVehicle.Locked;
                            //player.SendTranslatedChatMessage( IVehicle.Locked ? "Fahrzeug ~r~Abgeschlossen" : "Fahrzeug ~g~Aufgeschlossen", true);
                        }
                    }
                }
                //player.vnxSetElementData("HideHUD", 0);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("ParkVehicleServer")]
        public void ParkLocalIVehicle(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel localVehicle = (VehicleModel)player.Vehicle;
                    if (localVehicle.Owner == player.Username)
                    {
                        localVehicle.SpawnCoord = player.Vehicle.Position;
                        localVehicle.SpawnRot = player.Vehicle.Rotation;
                        player.SendTranslatedChatMessage("~g~Du hast dein Fahrzeug hier geparkt.");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage("~r~Das Fahrzeug gehört dir nicht!");
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage("~r~Dafür musst du im Fahrzeug sitzen!");
                }
                player.VnxSetElementData("HideHUD", 0);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        /*
        //[AltV.Net.ClientEvent("RespawnPrivIVehicleServer")]
        public void RespawnLocalIVehicle(PlayerModel player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localVehicle = (VehicleModel)player.Vehicle;
                    if (localVehicle.Owner ==player.Username)
                    {
                        if (player.Reallife.Money >= 200)
                        {
                            if (localVehicle.Occupants.Count > 0)
                            {
                                dxLibary.VnX.DrawNotification(Player, "error", "Fahrzeug ist nicht leer!");
                                return;
                            }
                            localIVehicle.Repair();
                            localIVehicle.position = localVehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            localIVehicle.Rotation = localVehicle.SpawnRot;
                            player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - 200);
                            Core.VnX.VehiclevnxSetSharedData(localIVehicle,"VEHICLE_HEALTH_SERVER", 1000);
                            Player.SendTranslatedChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        player.SendTranslatedChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (localVehicle.Owner ==player.Username)
                        {
                            if (player.Reallife.Money >= 200)
                            {
                                localIVehicle.Repair();
                                localIVehicle.position = localVehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                                localIVehicle.Rotation = localVehicle.SpawnRot;
                                player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.Reallife.Money - 200);
                                Player.SendTranslatedChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }
                }
                player.vnxSetElementData("HideHUD", 0);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [Command("towveh")]
        public static void TowVehServer(PlayerModel player, int FahrzeugSlot)
        {
            try
            {
                VehicleModel vehicle = IVehicles.GetVehicleById(FahrzeugSlot);
                if (Vehicle != null)
                {
                    if (Vehicle.Owner ==player.Username)
                    {
                        if (player.Reallife.Money >= 200)
                        {
                            IVehicle.Repair();
                            IVehicle.position = Vehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            IVehicle.Rotation = Vehicle.SpawnRot;
                            Vehicle.Dimension = (uint)Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_DIMENSION);
                            Vehicle.vnxSetStreamSharedElementData("VEHICLE_HEALTH_SERVER", 1000);
                            player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.Reallife.Money - 200);
                            player.SendTranslatedChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("ShowIVehicleInformation")]
        public void InformationsWindowIVehicle(PlayerModel player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localIVehicle = (VehicleModel)player.Vehicle;
                    player.SendTranslatedChatMessage( "{0096c8}Fahrzeug Modell: " + localVehicle.Model.ToString() + ", Besitzer: " + localVehicle.Owner);
                    player.SendTranslatedChatMessage( "{0096c8}Tunings: ");
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        player.SendTranslatedChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "{0096c8}Fahrzeug Modell: " + localVehicle.Model.ToString() + ", Besitzer: " + localVehicle.Owner);
                        player.SendTranslatedChatMessage( "{0096c8}Tunings: ");
                    }

                    player.vnxSetElementData("HideHUD", 0);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        //[AltV.Net.ClientEvent("HandBreakIVehicleServerside")]
        public void HandbremsenFunktionServer(PlayerModel player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localIVehicle = (VehicleModel)player.Vehicle;
                    if (localVehicle.Owner ==player.Username)
                    {
                        if (localVehicle.vnxGetElementData("HandbremseAngezogen") == false)
                        {
                            Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", true);
                            player.SendTranslatedChatMessage( "~r~Handbremse angezogen!", true);
                            dxLibary.VnX.SetIVehicleElementFrozen(localIVehicle, Player, true);
                        }
                        else
                        {
                            Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", false);
                            player.SendTranslatedChatMessage( "~g~Handbremse gelöst!", true);
                            dxLibary.VnX.SetIVehicleElementFrozen(localIVehicle, Player, false);
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        NAPI.Player.FreezePlayer(Player, true);
                        player.SendTranslatedChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (localVehicle.Owner ==player.Username)
                        {
                            if (localVehicle.vnxGetElementData("HandbremseAngezogen") == false)
                            {
                                Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", true);
                                player.SendTranslatedChatMessage( "~r~Handbremse angezogen!", true);
                                NAPI.Player.FreezePlayer(Player, true);
                            }
                            else
                            {
                                Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", false);
                                player.SendTranslatedChatMessage( "~g~Handbremse gelöst!", true);
                                NAPI.Player.FreezePlayer(Player, false);
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }

                    player.vnxSetElementData("HideHUD", 0);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("setquestbackagain")]
        public void justALittleAnzeigeFehlerFixDiesDas(PlayerModel player)
        {
            try
            {
                player.vnxSetElementData("HideHUD", 0);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        */
    }
}
