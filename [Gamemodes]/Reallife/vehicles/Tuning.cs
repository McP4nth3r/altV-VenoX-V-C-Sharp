using AltV.Net;
using AltV.Net.Data;
using System;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Tuning : IScript
    {
        public static void OnResourceStart()
        {
            RageAPI.CreateBlip("Werkstatt", new Vector3(-354.7027f, -135.3738f, 38.57238f), 446, 0, true);
        }

        public static ColShapeModel TuningGaragenTeleport = RageAPI.CreateColShapeSphere(new Position(-354.7027f, -135.3738f, 38.57238f), 1);


        public static void EmitTuningWindow(VnXPlayer player, VehicleModel vehicle)
        {
            try
            {
                VenoX.TriggerClientEvent(player, "Tuning:Show"); //Emit to open UI Client 
            }
            catch { }
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
                    if (vehicle.Faction > Constants.FACTION_NONE)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                        return true;
                    }
                    else if (vehicle.Owner != player.Username)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                        return true;
                    }
                    else if (vehicle.NotSave == true)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst dieses Fahrzeug nicht Tunen!");
                        return true;
                    }
                    vehicle.Position = new Position(-337.9052f, -136.9406f, 38.58294f);
                    vehicle.Rotation = new Position(0, 0, 300);
                    vehicle.Frozen = true;
                    // anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                    EmitTuningWindow(player, vehicle);
                    //VenoX.TriggerClientEvent(player, "Tuning:Show");
                    VenoX.TriggerClientEvent(player, "Remote_Speedo_Hide", true);
                    player.vnxSetElementData("InTuningGarage", true);
                }
                return true;

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        [ClientEvent("Reallife-Tuning:Close")]
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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void AddTunningToIVehicle(VehicleModel vehClass)
        {
            try
            {
                foreach (TunningModel tunning in Main.tunningList)
                {
                    if (vehClass.ID == tunning.IVehicle)
                        vehClass.SetMod((byte)tunning.slot, (byte)tunning.component);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        private byte GetIVehicleTunningComponent(int IVehicleId, int slot)
        {
            try
            {
                // Get the component on the specified slot
                TunningModel tunning = Main.tunningList.Where(tunningModel => tunningModel.IVehicle == IVehicleId && tunningModel.slot == slot).FirstOrDefault();

                return tunning == null ? 255 : (byte)tunning.component;
            }
            catch { return 0; }
        }




        [ClientEvent("modifyIVehicle")]
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
            catch { }
        }

        //[AltV.Net.ClientEvent("cancelIVehicleModification")]
        public void CancelIVehicleModificationEvent(VnXPlayer player)
        {
            try
            {
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                int IVehicleId = vehClass.ID;

                for (byte i = 0; i < 49; i++)
                {
                    // Get the component in the slot
                    byte component = GetIVehicleTunningComponent(IVehicleId, i);

                    // Remove or add the tunning part
                    player.Vehicle.SetMod(i, component);
                }
            }
            catch { }
        }

        public static int GetTuningCosts(int slot, int modold)
        {
            int mod = modold / 3;
            if (slot == 0)
            {
                return 2500;
            }
            else if (slot == 1)
            {
                return mod * 3500;
            }
            else if (slot == 2)
            {
                return mod * 3500;
            }
            else if (slot == 3)
            {
                return mod * 3500;
            }
            else if (slot == 4)
            {
                return mod * 2000;
            }
            else if (slot == 5)
            {
                return mod * 5500;
            }
            else if (slot == 6)
            {
                return mod * 3200;
            }
            else if (slot == 7)
            {
                return mod * 4500;
            }
            else if (slot == 8)
            {
                return mod * 3000;
            }
            else if (slot == 9)
            {
                return mod * 3000;
            }
            else if (slot == 10)
            {
                return mod * 2500;
            }
            else if (slot == 11)
            {
                return mod * 6000;
            }
            else if (slot == 12)
            {
                return mod * 5000;
            }
            else if (slot == 12)
            {
                return mod * 5000;
            }
            else if (slot == 13)
            {
                return mod * 5500;
            }
            else if (slot == 14)
            {
                return 10000;
            }
            else if (slot == 15)
            {
                return mod * 4000;
            }
            else if (slot == 18)
            {
                return 12000;
            }
            else if (slot == 22)
            {
                return mod * 1500;
            }
            else if (slot == 23)
            {
                return 8500;
            }
            else if (slot == 24)
            {
                return 5000;
            }
            else if (slot == 25)
            {
                return 2500;
            }
            else if (slot == 46)
            {
                return mod * 4000;
            }
            return 2000;
        }

        //[AltV.Net.ClientEvent("confirmIVehicleModification")]
        public void ConfirmIVehicleModificationEvent(VnXPlayer player, int slot, int mod)
        {
            try
            {

                // Get the IVehicle's id
                VehicleModel vehClass = (VehicleModel)player.Vehicle;
                int IVehicleId = vehClass.ID;
                int playerId = player.UID;
                TunningModel Tunning = Main.GetIVehicleTuningBySlot();
                if (Tunning != null && Tunning.slot == slot)
                {
                    Database.RemoveTunning(IVehicleId, slot);
                    Main.tunningList.Remove(Tunning);
                    player.SendTranslatedChatMessage("Dein Altes Tuning wurde gelöscht!.");
                    TunningModel tunningModel = new TunningModel();
                    {
                        tunningModel.slot = slot;
                        tunningModel.component = mod;
                        tunningModel.IVehicle = IVehicleId;
                    }
                    tunningModel.id = Database.AddTunning(tunningModel);
                    Main.tunningList.Add(tunningModel);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Tunning Erfolgreich gekauft!");
                }
                else
                {
                    TunningModel tunningModel = new TunningModel();
                    {
                        tunningModel.slot = slot;
                        tunningModel.component = mod;
                        tunningModel.IVehicle = IVehicleId;
                    }
                    tunningModel.id = Database.AddTunning(tunningModel);
                    Main.tunningList.Add(tunningModel);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Tunning Erfolgreich gekauft!");
                }
            }
            catch
            {

            }
        }
    }
}
