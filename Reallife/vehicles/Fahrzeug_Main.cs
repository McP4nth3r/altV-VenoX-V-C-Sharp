using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Vehicles
{
    public class Fahrzeug_Main : IScript
    {
        [Command("car")]
        public void showIVehicleMenu(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true)
                    {
                        return;
                    }
                    player.Emit("showIVehicleMenu");
                    player.SetData("HideHUD", 1);
                }
                else
                {
                    IVehicle Vehicle = Main.GetClosestIVehicle(player);
                    if (Vehicle == null)
                    {
                        player.SendChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                    }
                    if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true)
                    {
                        return;
                    }
                    else
                    {
                        player.Emit("showIVehicleMenu");
                        player.SetData("HideHUD", 1);
                    }
                    // Player.SendChatMessage("Du bist in keinem Fahrzeug! ");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("showIVehicleMenu")]
        public static void showIVehicleMenuClicked(IPlayer player, IVehicle Vehicle)
        {
            try
            {
                if (Vehicle == null)
                {
                    player.SendChatMessage("~r~Du bist in/an keinem Fahrzeug!");
                }
                else
                {
                    player.Emit("showIVehicleMenu");
                    player.SetData("HideHUD", 1);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("ResetIVehicleTimer")]
        public static void ResetIVehicleAktionsTimer(IPlayer player)
        {
            player.SetData("vehinfos_done_cmd", false);
        }

        [Command("vehinfos")]
        public void IVehiclelist(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<bool>("vehinfos_done_cmd") == true)
                {
                    dxLibary.VnX.DrawNotification(player, "info", "Nur alle 30 Sekunden möglich!");
                    return;
                }
                player.SendChatMessage("---------------Fahrzeuge---------------");
                foreach (IVehicle veh in Alt.GetAllVehicles())
                {
                    if (veh != null && veh.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>())
                    {
                        Random random = new Random();
                        int cevent = random.Next(1, 5);
                        string Model = veh.Model.ToString().ToLower();
                        if (Model == "" || Model.ToString() == null)
                        {
                            Model = veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL);
                        }
                        if (cevent == 1)
                        {

                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Fahrzeug Name : " + veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL) + " - Slot : " + veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                        }
                        else if (cevent == 2)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Fahrzeug Name : " + veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL) + " - Slot : " + veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                        }
                        else if (cevent == 3)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, cevent, player.Dimension, 30000);
                            player.SendChatMessage(RageAPI.GetHexColorcode(0, 125, 175) + "Fahrzeug Name : " + veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL) + " - Slot : " + veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                        }
                        else if (cevent == 4)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 5, player.Dimension, 30000);
                            player.SendChatMessage(RageAPI.GetHexColorcode(255, 140, 0) + "Fahrzeug Name : " + veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL) + " - Slot : " + veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                        }
                        else if (cevent == 5)
                        {
                            dxLibary.VnX.DrawZielBlipTable(player, "vehinfos", veh.ToString().ToLower(), new Position(veh.Position.X, veh.Position.Y, veh.Position.Z), 669, 7, player.Dimension, 30000);
                            player.SendChatMessage(RageAPI.GetHexColorcode(165, 0, 165) + "Fahrzeug Name : " + veh.vnxGetElementData<string>(EntityData.VEHICLE_MODEL) + " - Slot : " + veh.vnxGetElementData<int>(EntityData.VEHICLE_ID));
                        }

                    }
                }
                player.SetData("vehinfos_done_cmd", true);
                player.SendChatMessage("---------------------------------------");
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("LockIVehicleServer")]
        public void LockLocalIVehicle(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>())
                    {
                        //IVehicle.Locked = !IVehicle.Locked;
                        //player.SendChatMessage( IVehicle.Locked ? "Fahrzeug ~r~Abgeschlossen" : "Fahrzeug ~g~Aufgeschlossen", true);
                    }
                    else
                    {
                        //player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
                else
                {
                    IVehicle Vehicle = Main.GetClosestIVehicle(player);
                    if (Vehicle == null)
                    {
                        //player.SendChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>())
                        {
                            //IVehicle.Locked = !IVehicle.Locked;
                            //player.SendChatMessage( IVehicle.Locked ? "Fahrzeug ~r~Abgeschlossen" : "Fahrzeug ~g~Aufgeschlossen", true);
                        }
                        else
                        {
                            //player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }
                }
                //Player.SetData("HideHUD", 0);
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("ParkIVehicleServer")]
        public void ParkLocalIVehicle(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localVehicle = player.Vehicle;
                    VehicleModel Vehicle = new VehicleModel();
                    if (localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>())
                    {
                        Vehicle.position = player.Vehicle.Position;
                        Vehicle.rotation = player.Vehicle.Rotation;
                        Vehicle.id = player.Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_ID);
                        Core.VnX.IVehicleSetSharedPositionData(player.Vehicle, EntityData.VEHICLE_POSITION, Vehicle.position);
                        player.Vehicle.SetSyncedMetaData(EntityData.VEHICLE_ROTATION, Vehicle.rotation);
                        player.Vehicle.SetData(EntityData.VEHICLE_ROTATION, Vehicle.rotation);
                        // Update the IVehicle's position into the database
                        Database.UpdateIVehiclePosition(Vehicle);
                        player.SendChatMessage("~g~Du hast dein Fahrzeug hier geparkt.");
                    }
                    else
                    {
                        player.SendChatMessage("~r~Das Fahrzeug gehört dir nicht!");
                    }
                }
                else
                {
                    player.SendChatMessage("~r~Dafür musst du im Fahrzeug sitzen!");
                }
                player.SetData("HideHUD", 0);
            }
            catch { }
        }
        /*
        //[AltV.Net.ClientEvent("RespawnPrivIVehicleServer")]
        public void RespawnLocalIVehicle(IPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localVehicle = player.Vehicle;
                    if (localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 200)
                        {
                            if (localVehicle.Occupants.Count > 0)
                            {
                                dxLibary.VnX.DrawNotification(Player, "error", "Fahrzeug ist nicht leer!");
                                return;
                            }
                            localIVehicle.Repair();
                            localIVehicle.Position = localVehicle.vnxGetElementData<Position>(EntityData.VEHICLE_OWNER);
                            localIVehicle.Rotation = localVehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION);
                            Player.SetData(EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 200);
                            Core.VnX.VehiclevnxSetSharedData(localIVehicle,"VEHICLE_HEALTH_SERVER", 1000);
                            Player.SendChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                        }
                        else
                        {
                            player.SendChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                        }
                    }
                    else
                    {
                        player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        player.SendChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 200)
                            {
                                localIVehicle.Repair();
                                localIVehicle.Position = localVehicle.vnxGetElementData<Position>(EntityData.VEHICLE_OWNER);
                                localIVehicle.Rotation = localVehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION);
                                Core.VnX.vnxSetSharedData(Player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 200);
                                Player.SendChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                            }
                            else
                            {
                                player.SendChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                            }
                        }
                        else
                        {
                            player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }
                }
                Player.SetData("HideHUD", 0);
            }
            catch { }
        }


        [Command("towveh")]
        public static void TowVehServer(IPlayer player, int FahrzeugSlot)
        {
            try
            {
                IVehicle Vehicle = IVehicles.GetVehicleById(FahrzeugSlot);
                if (Vehicle != null)
                {
                    if (Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 200)
                        {
                            IVehicle.Repair();
                            IVehicle.Position = Vehicle.vnxGetElementData<Position>(EntityData.VEHICLE_OWNER);
                            IVehicle.Rotation = Vehicle.vnxGetElementData<Rotation>(EntityData.VEHICLE_ROTATION);
                            Vehicle.Dimension = (uint)Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_DIMENSION);
                            Core.VnX.VehiclevnxSetSharedData(Vehicle,"VEHICLE_HEALTH_SERVER", 1000);
                            Core.VnX.vnxSetSharedData(player, Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) - 200);
                            player.SendChatMessage("~g~Du hast dein Fahrzeug Respawnt!");
                        }
                        else
                        {
                            player.SendChatMessage( "~r~Du brauchst mindestens 200$ um dein Fahrzeug zu Respawnen!", true);
                        }
                    }
                    else
                    {
                        player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("ShowIVehicleInformation")]
        public void InformationsWindowIVehicle(IPlayer Player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localIVehicle = player.Vehicle;
                    player.SendChatMessage( "{0096c8}Fahrzeug Modell: " + localVehicle.Model.ToString() + ", Besitzer: " + localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER));
                    player.SendChatMessage( "{0096c8}Tunings: ");
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        player.SendChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        player.SendChatMessage( "{0096c8}Fahrzeug Modell: " + localVehicle.Model.ToString() + ", Besitzer: " + localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER));
                        player.SendChatMessage( "{0096c8}Tunings: ");
                    }

                    Player.SetData("HideHUD", 0);
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("HandBreakIVehicleServerside")]
        public void HandbremsenFunktionServer(IPlayer Player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle localIVehicle = player.Vehicle;
                    if (localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                    {
                        if (localVehicle.vnxGetElementData("HandbremseAngezogen") == false)
                        {
                            Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", true);
                            player.SendChatMessage( "~r~Handbremse angezogen!", true);
                            dxLibary.VnX.SetIVehicleElementFrozen(localIVehicle, Player, true);
                        }
                        else
                        {
                            Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", false);
                            player.SendChatMessage( "~g~Handbremse gelöst!", true);
                            dxLibary.VnX.SetIVehicleElementFrozen(localIVehicle, Player, false);
                        }
                    }
                    else
                    {
                        player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                    }
                }
                else
                {
                    IVehicle localIVehicle = Main.GetClosestIVehicle(Player);
                    if (localVehicle == null)
                    {
                        NAPI.Player.FreezePlayer(Player, true);
                        player.SendChatMessage( "~r~Du bist in/an keinem Fahrzeug!", true);
                    }
                    else
                    {
                        if (localVehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.GetVnXName<string>())
                        {
                            if (localVehicle.vnxGetElementData("HandbremseAngezogen") == false)
                            {
                                Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", true);
                                player.SendChatMessage( "~r~Handbremse angezogen!", true);
                                NAPI.Player.FreezePlayer(Player, true);
                            }
                            else
                            {
                                Core.VnX.IVehicleSetSharedBoolData(localIVehicle, "HandbremseAngezogen", false);
                                player.SendChatMessage( "~g~Handbremse gelöst!", true);
                                NAPI.Player.FreezePlayer(Player, false);
                            }
                        }
                        else
                        {
                            player.SendChatMessage( "~r~Das Fahrzeug gehört dir nicht!", true);
                        }
                    }

                    Player.SetData("HideHUD", 0);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("setquestbackagain")]
        public void justALittleAnzeigeFehlerFixDiesDas(IPlayer player)
        {
            try
            {
                player.SetData("HideHUD", 0);
            }
            catch { }
        }
        */
    }
}
