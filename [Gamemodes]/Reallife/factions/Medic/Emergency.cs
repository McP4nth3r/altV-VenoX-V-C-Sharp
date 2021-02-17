﻿using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Emergency : IScript
    {

        public static ColShapeModel EmergencyReviveCol = RageApi.CreateColShapeSphere(new Position(364.3578f, -591.5056f, 28.29856f), 3);

        public static Dictionary<VnXPlayer, BlipModel> CurrentActiveMedicBlips = new Dictionary<VnXPlayer, BlipModel>();
        public static async void OnPlayerDeath(VnXPlayer player)
        {
            if (player.Dimension != (Main.ReallifeDimension + player.Language)) return;
            foreach (VnXPlayer medics in Main.ReallifePlayers.ToList())
            {
                if (medics.Reallife.Faction == Constants.FactionEmergency)
                {
                    string translatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)medics.Language, "braucht hilfe!");
                    if (!CurrentActiveMedicBlips.ContainsKey(player))
                        CurrentActiveMedicBlips.Add(player, RageApi.CreateBlip(player.Username + " " + translatedText, player.Position, 303, 3, false, medics));
                }
            }
        }


        public static void DeleteCurrentMedicBlip(VnXPlayer player)
        {
            if (CurrentActiveMedicBlips.ContainsKey(player))
            {
                CurrentActiveMedicBlips.TryGetValue(player, out BlipModel blipClass);
                foreach (VnXPlayer medics in Main.ReallifePlayers.ToList())
                {
                    if (medics.Reallife.Faction == Constants.FactionEmergency) RageApi.RemoveBlip(blipClass, medics);
                }
                CurrentActiveMedicBlips.Remove(player);
            }
        }




        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                return false;
                /*if (player.Reallife.Faction == Constants.FACTION_EMERGENCY)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        if((VehicleModel)player.VehicleSeat == (int)IVehicleSeat.Driver)
                        {
                            if (Vehicle != null && Vehicle.Faction == Constants.FACTION_EMERGENCY)
                            {
                                if (Vehicle.Occupants.Count > 0)
                                {
                                    var playersInCar = NAPI.Vehicle.GetIVehicleOccupants(Vehicle);
                                    foreach (var spielerimauto in playersInCar)
                                    {
                                        if (spielerimauto.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                                        {
                                            //spielerimauto.WarpOutOfIVehicle();
                                            spielerimauto.Emit("toggleHandcuffed", false);
                                            Core.VnX.vnxSetSharedData(spielerimauto, EntityData.PLAYER_KILLED, 0);
                                            player.SendTranslatedChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Du hast " + spielerimauto.Name + " wiederbelebt! Du bekommst " + 350 + " $.");
                                            player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.Reallife.Money + 350);
                                            Spawn.spawnplayer_on_spawnpoint(spielerimauto);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }*/
            }
            catch { return false; }
        }


        [Command("heal")]
        public static async void HealIPlayerMedic(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null)
                {
                    string translatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "konnte nicht gefunden werden!");
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, player.Username + " " + translatedText);
                    return;
                };
                if (target.VnxGetElementData<int>(EntityData.PlayerKilled) == 1)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        if (vehicle != null || vehicle.Faction == Constants.FactionEmergency)
                        {
                            if (player.Position.Distance(target.Position) < 7)
                            {
                                //Anti_Cheat.//AntiCheat_Allround.SetTimeOutHealth(target, 1000);
                                VenoX.TriggerClientEvent(player, "start_screen_fx", "ExplosionJosh3", 0, false);
                                VenoX.TriggerClientEvent(target, "start_screen_fx", "ExplosionJosh3", 0, false);
                                //NAPI.player.SpawnPlayerPlayer(target.vnxGetElementData<int>( target.position;
                                VenoX.TriggerClientEvent(target, "destroyKrankenhausTimer");
                                VenoX.TriggerClientEvent(target, "VnX_DestroyIPlayerSideTimer_KH");

                                foreach (VnXPlayer medics in Main.ReallifePlayers.ToList())
                                {
                                    if (medics.Reallife.Faction == Constants.FactionEmergency)
                                    {
                                        medics.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 125, 0) + player.Username + " hat " + target.Username + " aufgesammelt!");
                                        VenoX.TriggerClientEvent(medics, "Destroy_MedicBlips", target.Username);
                                    }
                                }

                                VenoX.TriggerClientEvent(target, "toggleHandcuffed", true);
                                //target.vnxGetElementData(SetIntoIVehicle(IVehicle, (int)IVehicleSeat.LeftRear);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du zu weit von " + target.Username + " entfernt!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist in keinem Medic Fahrzeug!");
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist bei keinem Spieler!");
                }
            }
            catch
            {
            }
        }

    }
}