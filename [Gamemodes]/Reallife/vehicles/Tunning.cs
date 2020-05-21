using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._RootCore_.Database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Tunning : IScript
    {
        public static void OnResourceStart()
        {
            //Ped verleihped = NAPI.Ped.CreatePed(PedHash.BoatADMINLVL01F, new Position(-2302.375f, 365.1267f, 174.6016f), 0.0f);
            //Blip TuningGaragenBlip = NAPI.Blip.CreateBlip(new Position(-354.7027f, -135.3738f, 38.57238f));
            //TuningGaragenBlip.Name = "Werkstatt";
            //TuningGaragenBlip.Sprite = 446;

            BlipModel blip = new BlipModel();
            Position pos = new Position(-354.7027f, -135.3738f, 38.57238f);
            blip.Name = "Werkstatt";
            blip.posX = pos.X;
            blip.posY = pos.Y;
            blip.posZ = pos.Z;
            blip.Sprite = 446;
            blip.Color = 0;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);
        }

        public static IColShape TuningGaragenTeleport = Alt.CreateColShapeSphere(new Position(-354.7027f, -135.3738f, 38.57238f), 1);



        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                /*
                if (shape == TuningGaragenTeleport)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "In der BETA Phase leider nicht möglich...");
                    return;
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        if (Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_FACTION) > Constants.FACTION_NONE)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                            return;
                        }
                        else if (Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) !=player.Username)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keine Fraktions fahrzeuge Tunen!");
                            return;
                        }
                        else if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst kein Aktions fahrzeug Tunen!");
                            return;
                        }
                        else if (Vehicle.vnxGetElementData("VenoX_Rentals_Fahrzeug") == true)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst kein Miet-fahrzeug Tunen!");
                            return;
                        }
                        else if (Vehicle.vnxGetElementData<bool>("PRUEFUNGS_AUTO") == true || Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED) == true)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst dieses Fahrzeug nicht Tunen!");
                            return;
                        }
                        player.Emit("Remote_Speedo_Hide", true);
                        player.vnxSetStreamSharedElementData("HideHUD", 1);
                        IVehicle.position = new Position(-337.9052f, -136.9406f, 38.58294f);
                        IVehicle.Rotation = new Position(0, 0, 300);
                        dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, true);
                        VnX.CreateDiscordUpdate(player, "Am Auto Schrauben", "VenoX Reallife Tuning");
                        anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                        player.Emit("showTuningMenu");
                        player.vnxSetElementData("InTuningGarage", true);
                    }
                }*/
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("CloseTuning")]
        public static void CloseTunningWindow(Client player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    IVehicle Vehicle = player.Vehicle;
                    player.Emit("Remote_Speedo_Hide", false);
                    player.vnxSetStreamSharedElementData("HideHUD", 1);
                    Vehicle.Rotation = new Rotation(0f, 0f, 90f);
                    dxLibary.VnX.SetIVehicleElementFrozen(Vehicle, player, false);
                    Vehicle.Position = new Position(-363.4763f, -131.8629f, 38.68012f);
                    anzeigen.Usefull.VnX.ResetDiscordData(player);
                }
                player.Emit("CloseTuningWindow");
            }
            catch { }
        }

        public static void AddTunningToIVehicle(IVehicle Vehicle)
        {
            try
            {
                /*foreach (TunningModel tunning in Main.tunningList)
                {
                    if (Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID) == tunning.IVehicle)
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
        public void ModifyIVehicleEvent(Client player, int slot, int component)
        {
            try
            {
                IVehicle Vehicle = player.Vehicle;

                if (component > 0)
                {
                    //player.Vehicle.SetMod(slot, component);
                }
                else
                {
                    //player.Vehicle.RemoveMod(slot);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("cancelIVehicleModification")]
        public void CancelIVehicleModificationEvent(Client player)
        {
            try
            {
                int IVehicleId = player.Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID);

                for (int i = 0; i < 49; i++)
                {
                    // Get the component in the slot
                    int component = GetIVehicleTunningComponent(IVehicleId, i);

                    // Remove or add the tunning part
                    // player.Vehicle.SetMod(i, component);
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
        public void ConfirmIVehicleModificationEvent(Client player, int slot, int mod)
        {
            try
            {

                // Get the IVehicle's id
                int IVehicleId = player.Vehicle.vnxGetElementData<int>(VenoXV.Globals.EntityData.VEHICLE_ID);
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
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
