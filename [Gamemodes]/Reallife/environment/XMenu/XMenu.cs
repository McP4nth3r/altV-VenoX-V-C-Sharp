﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.environment.XMenu
{
    public class XMenu : IScript
    {

        private static bool IsVehicleOwner(Client player, VehicleModel vehicle)
        {
            if (vehicle.Owner == player.Username) { return true; }
            else if (vehicle.Faction == player.Reallife.Faction) { return true; }
            else { return false; }
        }

        [ClientEvent("XMenu:ApplyServerButtonVehicle")]
        public static void OnXMenuButtonPressedVehicle(Client player, int Button, VehicleModel vehicle)
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
                case 9902:
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Fahrzeug ID : " + RageAPI.GetHexColorcode(255, 255, 255) + vehicle.ID);
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Fahrzeug Name : " + RageAPI.GetHexColorcode(255, 255, 255) + vehicle.Name);
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Fahrzeug Besitzer : " + RageAPI.GetHexColorcode(255, 255, 255) + vehicle.Owner);
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "Fahrzeug Fraktion : " + RageAPI.GetHexColorcode(255, 255, 255) + factions.Faction.GetFactionNameById(vehicle.Faction));
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
