using System;
using AltV.Net;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV.Core;
using VenoXV.Models;
using VehicleModel = VenoXV.Models.VehicleModel;

namespace VenoXV._Gamemodes_.Reallife.environment.XMenu
{
    public class XMenu : IScript
    {

        private static bool IsVehicleOwner(VnXPlayer player, VehicleModel vehicle)
        {
            try
            {
                if (vehicle.Owner == player.Username) return true;
                if (vehicle.Faction == player.Reallife.Faction) return true;
                if (vehicle.Npc) return true;
                return false;
            }
            catch { return false; }
        }

        [VenoXRemoteEvent("XMenu:ApplyServerButtonVehicle")]
        public static void OnXMenuButtonPressedVehicle(VnXPlayer player, int button, VehicleModel vehicle = null)
        {
            try
            {
                if (vehicle == null) return;
                if (!IsVehicleOwner(player, vehicle)) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du bist nicht der Besitzer dieses Fahrzeuges!"); return; }
                if (vehicle.Gas <= 0) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "[Fehler] : Fahrzeug tank ist leer..."); return; }
                switch (button)
                {
                    case 9900:
                        if (player.IsInVehicle && vehicle.Driver != player) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Dies kann nur der Fahrer!"); return; }
                        if (vehicle.LockState == VehicleLockState.Locked) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Fahrzeug aufgeschlossen!"); vehicle.LockState = VehicleLockState.Unlocked; }
                        else { vehicle.LockState = VehicleLockState.Locked; player.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 0) + "Fahrzeug abgeschlossen!"); }
                        break;

                    case 9901:
                        if (player.IsInVehicle && vehicle.Driver != player) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Dies kann nur der Fahrer!"); return; }
                        vehicle.EngineOn = !vehicle.EngineOn;
                        if (vehicle.EngineOn) { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + " Motor angeschaltet!"); }
                        else { player.SendTranslatedChatMessage(RageApi.GetHexColorcode(150, 0, 0) + " Motor ausgeschaltet!"); }
                        break;
                    case 9902:
                        player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "Fahrzeug ID : " + RageApi.GetHexColorcode(255, 255, 255) + vehicle.DatabaseId);
                        player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "Fahrzeug Name : " + RageApi.GetHexColorcode(255, 255, 255) + vehicle.Name);
                        player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "Fahrzeug Besitzer : " + RageApi.GetHexColorcode(255, 255, 255) + vehicle.Owner);
                        player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "Fahrzeug Fraktion : " + RageApi.GetHexColorcode(255, 255, 255) + Faction.GetFactionNameById(vehicle.Faction));
                        break;
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("XMenu:ApplyServerButton")]
        public static void OnXMenuButtonPressed(VnXPlayer player, int button, VnXPlayer target)
        {
            try
            {
                if (target == null) return;
                switch (button)
                {
                    case 8800:
                        break;

                    case 8801:
                        break;

                    case 8802:
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
