using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Emergency : IScript
    {

        public static ColShapeModel EmergencyReviveCol = RageAPI.CreateColShapeSphere(new Position(364.3578f, -591.5056f, 28.29856f), 3);

        public static void OnPlayerEnterColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
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
            catch
            {
            }
        }
        public static void DestroyEmergencyDeathNotify(VnXPlayer player)
        {
            try
            {
                foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                    {
                        medics.Emit("Destroy_MedicBlips", player.Username);
                    }
                }
            }
            catch { }
        }
        public static void CreateEmergencyDeathNotify(VnXPlayer player, int time)
        {
            try
            {
                foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
                {
                    if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                    {
                        medics.Emit("ShowMedicBlips", player.Username, player.Position);
                        medics.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + player.Username + " ist gestorben! Zeit bis zum Respawn : " + time);
                    }
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("DestroyForAllMedicBlip")]
        public void DestroyMedicBlipAfterSpawn(VnXPlayer player)
        {
            foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
            {
                if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                {
                    medics.Emit("Destroy_MedicBlips", player.Username);
                    medics.SendTranslatedChatMessage(RageAPI.GetHexColorcode(150, 0, 0) + "Ihr seid zu langsam gewesen! Der Spieler " + player.Username + " ist Respawned!");
                }
            }
        }


        [Command("heal")]
        public void HealIPlayerMedic(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (target.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                {
                    if (player.IsInVehicle)
                    {
                        VehicleModel vehicle = (VehicleModel)player.Vehicle;
                        if (vehicle != null || vehicle.Faction == Constants.FACTION_EMERGENCY)
                        {
                            if (player.Position.Distance(target.Position) < 7)
                            {
                                //Anti_Cheat.//AntiCheat_Allround.SetTimeOutHealth(target, 1000);
                                Alt.Server.TriggerClientEvent(player, "start_screen_fx", "ExplosionJosh3", 0, false);
                                target.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                                //NAPI.player.SpawnPlayerPlayer(target.vnxGetElementData<int>( target.position;
                                target.Emit("destroyKrankenhausTimer");
                                target.Emit("VnX_DestroyIPlayerSideTimer_KH");

                                foreach (VnXPlayer medics in VenoXV.Globals.Main.ReallifePlayers.ToList())
                                {
                                    if (medics.Reallife.Faction == Constants.FACTION_EMERGENCY)
                                    {
                                        medics.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + player.Username + " hat " + target.Username + " aufgesammelt!");
                                        medics.Emit("Destroy_MedicBlips", target.Username);
                                    }
                                }

                                target.Emit("toggleHandcuffed", true);
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