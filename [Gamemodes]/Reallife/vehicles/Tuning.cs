using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
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
    public class Server_All_Vehicle_Mods
    {
        public int id { get; set; }
        public long vehicleHash { get; set; }
        public string modName { get; set; }
        public int modType { get; set; }
        public int modId { get; set; }
    }

    public class Tuning : IScript
    {
        public static void OnResourceStart()
        {
            RageAPI.CreateBlip("Werkstatt", new Vector3(-354.7027f, -135.3738f, 38.57238f), 446, 0, true);
        }

        public static ColShapeModel TuningGaragenTeleport = RageAPI.CreateColShapeSphere(new Position(-354.7027f, -135.3738f, 38.57238f), 1);


        public static List<Server_All_Vehicle_Mods> ServerAllVehicleMods_ = new List<Server_All_Vehicle_Mods>();

        public static int ReturnMaxVehicleMods(VehicleModel veh, int modType)
        {
            int maxMods = 0;
            try
            {
                maxMods = ServerAllVehicleMods_.Where(x => x.vehicleHash == veh.Model && x.modType == modType).Count();
            }
            catch (Exception e)
            {
                Alt.Log($"{e}");
            }
            return maxMods;
        }
        public static int ReturnMaxTuningWheels(int modType)
        {
            try
            {
                int count = ServerAllVehicleMods_.Where(x => (int)x.vehicleHash == 0 && x.modType == modType).Count();
                return count;
            }
            catch (Exception e)
            {
                Alt.Log($"{e}");
            }
            return 0;
        }
        public static void EmitTuningWindow(VnXPlayer player, VehicleModel vehicle)
        {
            try
            {
                vehicle.ModKit = 1;
                //Primärfarbe:100;Sekundärfarbe:200;Pearl-Effekt:250;Neonröhren:300;
                string tuningItems = "Primärfarbe:100;Sekundärfarbe:200;";
                if (ReturnMaxVehicleMods(vehicle, 0) != 0) { tuningItems += ";Spoiler:0"; }
                if (ReturnMaxVehicleMods(vehicle, 1) != 0) { tuningItems += ";Frontstoßstange:1"; }
                if (ReturnMaxVehicleMods(vehicle, 2) != 0) { tuningItems += ";Heckstoßstange:2"; }
                if (ReturnMaxVehicleMods(vehicle, 3) != 0) { tuningItems += ";Seitenverkleidung:3"; }
                if (ReturnMaxVehicleMods(vehicle, 4) != 0) { tuningItems += ";Auspuff:4"; }
                if (ReturnMaxVehicleMods(vehicle, 5) != 0) { tuningItems += ";Überrollkäfig:5"; }
                if (ReturnMaxVehicleMods(vehicle, 6) != 0) { tuningItems += ";Kühlergrill:6"; }
                if (ReturnMaxVehicleMods(vehicle, 7) != 0) { tuningItems += ";Motorhaube:7"; }
                if (ReturnMaxVehicleMods(vehicle, 8) != 0) { tuningItems += ";Linker Kotflügel:8"; }
                if (ReturnMaxVehicleMods(vehicle, 9) != 0) { tuningItems += ";Rechter Kotflügel:9"; }
                if (ReturnMaxVehicleMods(vehicle, 10) != 0) { tuningItems += ";Dach:10"; }
                if (ReturnMaxVehicleMods(vehicle, 11) != 0) { tuningItems += ";Motor:11"; }
                //  if (ServerVehicles.ReturnMaxTuningWheels(11) != 0) { tuningItems += ";Motor:11"; }
                if (ReturnMaxTuningWheels(12) != 0) { tuningItems += ";Bremsen:12"; }
                if (ReturnMaxTuningWheels(13) != 0) { tuningItems += ";Getriebe:13"; }
                if (ReturnMaxTuningWheels(14) != 0) { tuningItems += ";Hupe:14"; }
                if (ReturnMaxTuningWheels(15) != 0) { tuningItems += ";Federung:15"; }
                if (ReturnMaxTuningWheels(22) != 0) { tuningItems += ";Xenon:22"; }
                tuningItems += ";Scheinwerferfarbe:280";
                //ToDo: Reifentyp
                //if (ServerVehicles.ReturnMaxTuningWheels(131) != 0) { tuningItems += ";Reifen Typ:131"; }

                int wheelT = vehicle.WheelType;
                if (wheelT == 255 || wheelT == 0) wheelT = 0;

                if (ReturnMaxTuningWheels(Convert.ToInt32(23 + "" + wheelT)) != 0) { tuningItems += ";Reifen:23"; }
                if (ReturnMaxTuningWheels(132) != 0) { tuningItems += ";Reifen Farbe:132"; }
                if (ReturnMaxVehicleMods(vehicle, 25) != 0) { tuningItems += ";Nummernschild Rahmen:25"; }
                if (ReturnMaxVehicleMods(vehicle, 27) != 0) { tuningItems += ";Innenpolster:27"; }
                if (ReturnMaxVehicleMods(vehicle, 28) != 0) { tuningItems += ";Wackelkopf:28"; }
                if (ReturnMaxVehicleMods(vehicle, 30) != 0) { tuningItems += ";Tacho Design:30"; }
                if (ReturnMaxVehicleMods(vehicle, 33) != 0) { tuningItems += ";Lenkrad:33"; }
                if (ReturnMaxVehicleMods(vehicle, 34) != 0) { tuningItems += ";Schaltknüppel:34"; }
                if (ReturnMaxVehicleMods(vehicle, 35) != 0) { tuningItems += ";Tafel:35"; }
                if (ReturnMaxVehicleMods(vehicle, 40) != 0) { tuningItems += ";Luftfilter:40"; }
                if (ReturnMaxTuningWheels(46) != 0) { tuningItems += ";Fenstertönung:46"; }
                if (ReturnMaxVehicleMods(vehicle, 48) != 0) { tuningItems += ";Vinyls:48"; }

                VenoX.TriggerClientEvent(player, "Tuning:Show", vehicle, tuningItems); //Emit to open UI Client 
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
                /*foreach (TunningModel tunning in Main.tunningList)
                {
                    if (Vehicle.ID == tunning.IVehicle)
                    {
                        IVehicle.SetMod(tunning.slot, tunning.component);
                    }
                }*/
            }
            catch { }
        }
        private int GetIVehicleTunningComponent(int IVehicleId, int slot)
        {
            try
            {
                // Get the component on the specified slot
                TunningModel tunning = Main.tunningList.Where(tunningModel => tunningModel.IVehicle == IVehicleId && tunningModel.slot == slot).FirstOrDefault();

                return tunning == null ? 255 : tunning.component;
            }
            catch { return 0; }
        }




        //[AltV.Net.ClientEvent("modifyIVehicle")]
        public void ModifyIVehicleEvent(VnXPlayer player, int slot, int component)
        {
            try
            {
                VehicleModel vehicle = (VehicleModel)player.Vehicle;

                if (component > 0)
                {
                    //(VehicleModel)player.Vehicle.SetMod(slot, component);
                }
                else
                {
                    //(VehicleModel)player.Vehicle.RemoveMod(slot);
                }
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

                for (int i = 0; i < 49; i++)
                {
                    // Get the component in the slot
                    int component = GetIVehicleTunningComponent(IVehicleId, i);

                    // Remove or add the tunning part
                    // (VehicleModel)player.Vehicle.SetMod(i, component);
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
