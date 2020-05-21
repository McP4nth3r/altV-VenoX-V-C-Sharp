using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.environment.XMenu
{
    public class XMenu : IScript
    {

        private static bool IsVehicleOwner(Client player, IVehicle vehicle)
        {
            if (Core.RageAPI.vnxGetElementData<string>(vehicle, VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.Username) { return true; }
            else { return false; }
        }

        [ClientEvent("XMenu:ApplyServerButtonVehicle")]
        public static void OnXMenuButtonPressedVehicle(Client player, int Button, IVehicle vehicle)
        {
            if (vehicle == null) { return; }
            if (!IsVehicleOwner(player, vehicle)) { player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du bist nicht der Besitzer dieses Fahrzeuges!"); return; }
            switch (Button)
            {
                case 9900:
                    if (vehicle.LockState == AltV.Net.Enums.VehicleLockState.Locked) { player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 0) + "Fahrzeug aufgeschlossen!"); vehicle.LockState = AltV.Net.Enums.VehicleLockState.Unlocked; }
                    else { vehicle.LockState = AltV.Net.Enums.VehicleLockState.Locked; player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(150, 0, 0) + "Fahrzeug abgeschlossen!"); }
                    break;

                case 9901:
                    vehicle.EngineOn = !vehicle.EngineOn;
                    if (vehicle.EngineOn) { player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 0) + " Motor angeschaltet!"); }
                    else { player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(150, 0, 0) + " Motor ausgeschaltet!"); }
                    break;
            }
        }

        [ClientEvent("XMenu:ApplyServerButton")]
        public static void OnXMenuButtonPressed(Client player, int Button, Client target)
        {
            if (target == null) { return; }
            Core.Debug.OutputDebugString("Hallo " + player.Username + "ich habe deine nachricht bekommen von : " + Button + " Entity : " + target.Username);
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
