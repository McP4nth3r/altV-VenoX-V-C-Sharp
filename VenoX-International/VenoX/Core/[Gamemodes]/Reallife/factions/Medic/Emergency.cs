using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using EntityData = VenoX.Core._Gamemodes_.Reallife.globals.EntityData;

namespace VenoX.Core._Gamemodes_.Reallife.factions.Medic
{
    public class Emergency : IScript
    {

        public static ColShapeModel EmergencyReviveCol = RageApi.CreateColShapeSphere(new Position(364.3578f, -591.5056f, 28.29856f), 3);

        public static Dictionary<VnXPlayer, BlipModel> CurrentActiveMedicBlips = new Dictionary<VnXPlayer, BlipModel>();
        public static async void OnPlayerDeath(VnXPlayer player)
        {
            if (player.Dimension != (_Globals_.Initialize.ReallifeDimension + player.Language)) return;
            foreach (VnXPlayer medics in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
            {
                if (medics.Reallife.Faction == Constants.FactionEmergency)
                {
                    string translatedText = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)medics.Language, "needs help!");
                    if (!CurrentActiveMedicBlips.ContainsKey(player))
                        CurrentActiveMedicBlips.Add(player, RageApi.CreateBlip(player.CharacterUsername + " " + translatedText, player.Position, 303, 3, false, medics));
                }
            }
        }


        public static void DeleteCurrentMedicBlip(VnXPlayer player)
        {
            if (CurrentActiveMedicBlips.ContainsKey(player))
            {
                CurrentActiveMedicBlips.TryGetValue(player, out BlipModel blipClass);
                foreach (VnXPlayer medics in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
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
                    string translatedText = await global::VenoX.Core._Language_.Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "could not be found!");
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, player.CharacterUsername + " " + translatedText);
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
                                _RootCore_.VenoX.TriggerClientEvent(player, "start_screen_fx", "ExplosionJosh3", 0, false);
                                _RootCore_.VenoX.TriggerClientEvent(target, "start_screen_fx", "ExplosionJosh3", 0, false);
                                //NAPI.player.SpawnPlayerPlayer(target.vnxGetElementData<int>( target.position;
                                _RootCore_.VenoX.TriggerClientEvent(target, "destroyKrankenhausTimer");
                                _RootCore_.VenoX.TriggerClientEvent(target, "VnX_DestroyIPlayerSideTimer_KH");

                                foreach (VnXPlayer medics in Enumerable.ToList<VnXPlayer>(Initialize.ReallifePlayers))
                                {
                                    if (medics.Reallife.Faction == Constants.FactionEmergency)
                                    {
                                        medics.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 125, 0) + player.CharacterUsername + " hat " + target.CharacterUsername + " aufgesammelt!");
                                        _RootCore_.VenoX.TriggerClientEvent(medics, "Destroy_MedicBlips", target.CharacterUsername);
                                    }
                                }

                                _RootCore_.VenoX.TriggerClientEvent(target, "toggleHandcuffed", true);
                                //target.vnxGetElementData(SetIntoIVehicle(IVehicle, (int)IVehicleSeat.LeftRear);
                            }
                            else
                            {
                                _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du zu weit von " + target.CharacterUsername + " entfernt!");
                            }
                        }
                        else
                        {
                            _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "You are not in a Medic vehicle!");
                        }
                    }
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "You are not with any player!");
                }
            }
            catch
            {
            }
        }

    }
}