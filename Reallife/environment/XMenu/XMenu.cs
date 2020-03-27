using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.environment.XMenu
{
    public class XMenu : IScript
    {

        private static bool IsVehicleOwner(IPlayer player, IVehicle vehicle)
        {
            if(Core.RageAPI.vnxGetElementData<string>(vehicle, EntityData.VEHICLE_OWNER) == Core.RageAPI.GetVnXName<string>(player)) { return true; }
            else { return false; }
        }

        [ClientEvent("XMenu:ApplyServerButtonVehicle")]
        public static void OnXMenuButtonPressedVehicle(IPlayer player, int Button, IVehicle vehicle)
        {
            if(vehicle == null) { return; }
            if (!IsVehicleOwner(player, vehicle)) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nicht der Besitzer dieses Fahrzeuges!"); return; }
            switch (Button)
            {
                case 9900:
                    if (vehicle.LockState == AltV.Net.Enums.VehicleLockState.Locked) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 0) + "Fahrzeug aufgeschlossen!"); vehicle.LockState = AltV.Net.Enums.VehicleLockState.Unlocked; }
                    else { vehicle.LockState = AltV.Net.Enums.VehicleLockState.Locked; player.SendChatMessage(Core.RageAPI.GetHexColorcode(150, 0, 0) + "Fahrzeug abgeschlossen!"); }
                    break;

                case 9901:
                    vehicle.EngineOn = !vehicle.EngineOn;
                    if (vehicle.EngineOn) { player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 0) + " Motor angeschaltet!"); }
                    else { player.SendChatMessage(Core.RageAPI.GetHexColorcode(150, 0, 0) + " Motor ausgeschaltet!"); }
                    break;
            }
        }

        [ClientEvent("XMenu:ApplyServerButton")]
        public static void OnXMenuButtonPressed(IPlayer player, int Button, IPlayer target)
        {
            if(target == null) { return; }
            Core.Debug.OutputDebugString("Hallo " + Core.RageAPI.GetVnXName<string>(player) + "ich habe deine nachricht bekommen von : " + Button + " Entity : " + Core.RageAPI.GetVnXName<string>(target));
            switch (Button)
            {
                case 8800:
                    break;

                case 8801:
                    break;

                case 8802:
                    break;
            }
        }

    }
}
