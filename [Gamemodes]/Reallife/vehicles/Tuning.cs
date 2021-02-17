﻿using System;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Tuning : IScript
    {
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Werkstatt", new Vector3(-354.7027f, -135.3738f, 38.57238f), 446, 0, true);
        }

        public static ColShapeModel TuningGaragenTeleport = RageApi.CreateColShapeSphere(new Position(-354.7027f, -135.3738f, 38.57238f), 1);


        public static void EmitTuningWindow(VnXPlayer player, VehicleModel vehicle)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "Tuning:Show"); //Emit to open UI Client 
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {

                if (shape != TuningGaragenTeleport) return false;
                // _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "In der BETA Phase leider nicht möglich...");
                //return;
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.Faction > Constants.FactionNone)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                        return true;
                    }

                    if (vehicle.Owner != player.Username)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                        return true;
                    }

                    if (vehicle.NotSave)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du kannst dieses Fahrzeug nicht Tunen!");
                        return true;
                    }
                    vehicle.Position = new Position(-337.9052f, -136.9406f, 38.58294f);
                    vehicle.Rotation = new Position(0, 0, 300);
                    vehicle.Frozen = true;
                    // anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                    EmitTuningWindow(player, vehicle);
                    //VenoX.TriggerClientEvent(player, "Tuning:Show");
                    VenoX.TriggerClientEvent(player, "Remote_Speedo_Hide", true);
                    player.VnxSetElementData("InTuningGarage", true);
                }
                return true;

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }

        [VenoXRemoteEvent("Reallife-Tuning:Close")]
        public static void CloseTunningWindow(VnXPlayer player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    VenoX.TriggerClientEvent(player, "Remote_Speedo_Hide", false);
                    vehicle.Rotation = new Rotation(0f, 0f, 90f);
                    vehicle.Frozen = false;
                    vehicle.Position = new Position(-363.4763f, -131.8629f, 38.68012f);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public static void AddTunningToIVehicle(VehicleModel vehClass)
        {
            try
            {
                foreach (TunningModel tunning in Globals.Main.TunningList)
                {
                    if (vehClass.DatabaseId == tunning.Vehicle)
                        vehClass.SetMod((byte)tunning.Slot, (byte)tunning.Component);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
        private byte GetIVehicleTunningComponent(int vehicleId, int slot)
        {
            try
            {
                // Get the component on the specified slot
                TunningModel tunning = Globals.Main.TunningList.Where(tunningModel => tunningModel.Vehicle == vehicleId && tunningModel.Slot == slot).FirstOrDefault();

                return tunning == null ? 255 : (byte)tunning.Component;
            }
            catch { return 0; }
        }




        [VenoXRemoteEvent("modifyIVehicle")]
        public void ModifyIVehicleEvent(VnXPlayer player, byte slot, byte component)
        {
            try
            {
                if (!player.IsInVehicle) return;
                VehicleModel vehicle = (VehicleModel)player.Vehicle;

                if (component > 0)
                    vehicle.SetMod(slot, component);
                //else
                //vehicle.RemoveMod(slot);
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("cancelIVehicleModification")]
        public void CancelIVehicleModificationEvent(VnXPlayer player)
        {
            try
            {
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                int vehicleId = vehClass.DatabaseId;

                for (byte i = 0; i < 49; i++)
                {
                    // Get the component in the slot
                    byte component = GetIVehicleTunningComponent(vehicleId, i);

                    // Remove or add the tunning part
                    player.Vehicle.SetMod(i, component);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static int GetTuningCosts(int slot, int modold)
        {
            int mod = modold / 3;
            switch (slot)
            {
                case 0:
                    return 2500;
                case 1:
                    return mod * 3500;
                case 2:
                    return mod * 3500;
                case 3:
                    return mod * 3500;
                case 4:
                    return mod * 2000;
                case 5:
                    return mod * 5500;
                case 6:
                    return mod * 3200;
                case 7:
                    return mod * 4500;
                case 8:
                    return mod * 3000;
                case 9:
                    return mod * 3000;
                case 10:
                    return mod * 2500;
                case 11:
                    return mod * 6000;
                case 12:
                    return mod * 5000;
            }

            switch (slot)
            {
                case 12:
                    return mod * 5000;
                case 13:
                    return mod * 5500;
                case 14:
                    return 10000;
                case 15:
                    return mod * 4000;
                case 18:
                    return 12000;
                case 22:
                    return mod * 1500;
                case 23:
                    return 8500;
                case 24:
                    return 5000;
                case 25:
                    return 2500;
                case 46:
                    return mod * 4000;
                default:
                    return 2000;
            }
        }

        //[AltV.Net.ClientEvent("confirmIVehicleModification")]
        public void ConfirmIVehicleModificationEvent(VnXPlayer player, int slot, int mod)
        {
            try
            {

                // Get the IVehicle's id
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                int vehicleId = vehClass.DatabaseId;
                int playerId = player.UID;
                TunningModel tunning = Globals.Main.GetIVehicleTuningBySlot();
                if (tunning != null && tunning.Slot == slot)
                {
                    Database.Database.RemoveTunning(vehicleId, slot);
                    Globals.Main.TunningList.Remove(tunning);
                    player.SendTranslatedChatMessage("Dein Altes Tuning wurde gelöscht!.");
                    TunningModel tunningModel = new TunningModel();
                    {
                        tunningModel.Slot = slot;
                        tunningModel.Component = mod;
                        tunningModel.Vehicle = vehicleId;
                    }
                    tunningModel.Id = Database.Database.AddTunning(tunningModel);
                    Globals.Main.TunningList.Add(tunningModel);
                    Main.DrawNotification(player, Main.Types.Info, "Tunning Erfolgreich gekauft!");
                }
                else
                {
                    TunningModel tunningModel = new TunningModel();
                    {
                        tunningModel.Slot = slot;
                        tunningModel.Component = mod;
                        tunningModel.Vehicle = vehicleId;
                    }
                    tunningModel.Id = Database.Database.AddTunning(tunningModel);
                    Globals.Main.TunningList.Add(tunningModel);
                    Main.DrawNotification(player, Main.Types.Info, "Tunning Erfolgreich gekauft!");
                }
            }
            catch
            {

            }
        }
    }
}
