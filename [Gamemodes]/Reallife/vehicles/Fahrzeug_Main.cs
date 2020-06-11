using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Fahrzeug_Main : IScript
    {
        [Command("car")]
        public void showIVehicleMenu(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.Testing)
                    {
                        return;
                    }
                    Alt.Server.TriggerClientEvent(player,"showIVehicleMenu");
                    player.vnxSetElementData("HideHUD", 1);
                }
                else
                {
                    VehicleModel vehicle = Main.GetClosestIVehicle(player);
                    if (vehicle == null)
                    {
                        player.SendTranslatedChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                    }
                    if (vehicle.Testing)
                    {
                        return;
                    }
                    else
                    {
                        Alt.Server.TriggerClientEvent(player,"showIVehicleMenu");
                        player.vnxSetElementData("HideHUD", 1);
                    }
                    // Player.SendTranslatedChatMessage("Du bist in keinem Fahrzeug! ");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("showIVehicleMenu")]
        public static void showIVehicleMenuClicked(Client player, VehicleModel Vehicle)
        {
            try
            {
                if (Vehicle == null)
                {
                    player.SendTranslatedChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                }
                else
                {
                    Alt.Server.TriggerClientEvent(player,"showIVehicleMenu");
                    player.vnxSetElementData("HideHUD", 1);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("ResetIVehicleTimer")]
        public static void ResetIVehicleAktionsTimer(Client player)
        {
            player.vnxSetElementData("vehinfos_done_cmd", false);
        }

        [Command("vehinfos")]
        public void IVehiclelist(Client player)
        {
            try
            {
                if (player.vnxGetElementData<bool>("vehinfos_done_cmd") == true)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Nur alle 30 Sekunden möglich!");
                    return;
                }
                player.SendTranslatedChatMessage("---------------Fahrzeuge---------------");
                foreach (IVehicle vehicle in Alt.GetAllVehicles())
                {
                    VehicleModel veh = (VehicleModel)vehicle;
                    if (veh != null && veh.Owner == player.Username)
                    {
                        Random random = new Random();
                        int cevent = random.Next(1, 5);
                        string Model = veh.Model.ToString().ToLower();
                        if (Model == "" || Model.ToString() == null)
                        {
                            Model = veh.Name;
                        }
                        if (cevent == 1)
                        {

                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.ID);
                        }
                        else if (cevent == 2)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.ID);
                        }
                        else if (cevent == 3)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 175) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.ID);
                        }
                        else if (cevent == 4)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 5, player.Dimension, 30000);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 140, 0) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.ID);
                        }
                        else if (cevent == 5)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 7, player.Dimension, 30000);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(165, 0, 165) + "Fahrzeug Name : " + veh.Name + " - Slot : " + veh.ID);
                        }

                    }
                }
                player.vnxSetElementData("vehinfos_done_cmd", true);
                player.SendTranslatedChatMessage("---------------------------------------");
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("LockIVehicleServer")]
        public void LockLocalIVehicle(Client player)
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
                    else
                    {
                        //player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
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
                        else
                        {
                            //player.SendTranslatedChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }
                }
                //player.vnxSetElementData("HideHUD", 0);
            }
            catch { }
        }


        [ClientEvent("ParkVehicleServer")]
        public void ParkLocalIVehicle(Client player)
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
                player.vnxSetElementData("HideHUD", 0);
            }
            catch { }
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
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 200)
                        {
                            if (localVehicle.Occupants.Count > 0)
                            {
                                dxLibary.VnX.DrawNotification(Player, "error", "Fahrzeug ist nicht leer!");
                                return;
                            }
                            localIVehicle.Repair();
                            localIVehicle.position = localVehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            localIVehicle.Rotation = localVehicle.SpawnRot;
                            player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 200);
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
                            if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 200)
                            {
                                localIVehicle.Repair();
                                localIVehicle.position = localVehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                                localIVehicle.Rotation = localVehicle.SpawnRot;
                                player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 200);
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
            catch { }
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
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 200)
                        {
                            IVehicle.Repair();
                            IVehicle.position = Vehicle.vnxGetElementData<Position>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                            IVehicle.Rotation = Vehicle.SpawnRot;
                            Vehicle.Dimension = (uint)Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_DIMENSION);
                            Vehicle.vnxSetStreamSharedElementData("VEHICLE_HEALTH_SERVER", 1000);
                            player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - 200);
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
            catch { }
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
            catch { }
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
            catch { }
        }

        //[AltV.Net.ClientEvent("setquestbackagain")]
        public void justALittleAnzeigeFehlerFixDiesDas(PlayerModel player)
        {
            try
            {
                player.vnxSetElementData("HideHUD", 0);
            }
            catch { }
        }
        */
    }
}
