using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.environment.XMenu
{
    public class XMenu : IScript
    {

        private static bool IsVehicleOwner(PlayerModel player, IVehicle vehicle)
        {
            if (Core.RageAPI.vnxGetElementData<string>(vehicle, VenoXV.Globals.EntityData.VEHICLE_OWNER) == Core.RageAPI.GetVnXName(player)) { return true; }
            else { return false; }
        }

        [ClientEvent("XMenu:ApplyServerButtonVehicle")]
        public static void OnXMenuButtonPressedVehicle(PlayerModel player, int Button, IVehicle vehicle)
        {
            if (vehicle == null) { return; }
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
        public static void OnXMenuButtonPressed(PlayerModel player, int Button, PlayerModel target)
        {
            if (target == null) { return; }
            Core.Debug.OutputDebugString("Hallo " + Core.RageAPI.GetVnXName(player) + "ich habe deine nachricht bekommen von : " + Button + " Entity : " + Core.RageAPI.GetVnXName(target));
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
