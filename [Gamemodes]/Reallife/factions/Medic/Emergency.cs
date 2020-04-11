using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV.Core;
using VenoXV.Reallife.Globals;


namespace VenoXV.Reallife.factions
{
    public class Emergency : IScript
    {

        public static IColShape EmergencyReviveCol = Alt.CreateColShapeSphere(new Position(364.3578f, -591.5056f, 28.29856f), 3);

        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                /*if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        if(player.VehicleSeat == (int)IVehicleSeat.Driver)
                        {
                            if (Vehicle != null && Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION) == Constants.FACTION_EMERGENCY)
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
                                            player.SendChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Du hast " + spielerimauto.Name + " wiederbelebt! Du bekommst " + 350 + " $.");
                                            player.vnxSetStreamSharedElementData( Core.VnX.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + 350);
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
        public static void DestroyEmergencyDeathNotify(IPlayer player)
        {
            try
            {
                foreach (IPlayer medics in Alt.GetAllPlayers())
                {
                    if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                    {
                        medics.Emit("Destroy_MedicBlips",player.GetVnXName<string>());
                    }
                }
            }
            catch { }
        }
        public static void CreateEmergencyDeathNotify(IPlayer player, int time)
        {
            try
            {
                foreach (IPlayer medics in Alt.GetAllPlayers())
                {
                    if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                    {
                        medics.Emit("ShowMedicBlips",player.GetVnXName<string>(), player.Position);
                        medics.SendChatMessage(RageAPI.GetHexColorcode(0,150,200) + player.GetVnXName<string>() + " ist gestorben! Zeit bis zum Respawn : " + time);
                    }
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("DestroyForAllMedicBlip")]
        public void DestroyMedicBlipAfterSpawn(IPlayer player)
        {
            foreach (IPlayer medics in Alt.GetAllPlayers())
            {
                if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                {
                    medics.Emit("Destroy_MedicBlips",player.GetVnXName<string>());
                    medics.SendChatMessage(RageAPI.GetHexColorcode(150,0,0) + "Ihr seid zu langsam gewesen! Der Spieler " + player.GetVnXName<string>() + " ist Respawned!");
                }
            }
        }


        [Command("heal")]
        public void HealIPlayerMedic(IPlayer player, string target_name)
        {
            try
            {
                IPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (target.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                {
                    if (player.IsInVehicle)
                    {
                        IVehicle Vehicle = player.Vehicle;
                        if (Vehicle != null || Vehicle.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                        {
                            if (player.Position.Distance(target.Position) < 7)
                            {
                                Anti_Cheat.AntiCheat_Allround.SetTimeOutHealth(target,1000);
                                player.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                                target.Emit("start_screen_fx", "ExplosionJosh3", 0, false);
                                //NAPI.Player.SpawnPlayer(target.vnxGetElementData<int>( target.Position;
                                target.Emit("destroyKrankenhausTimer");
                                target.Emit("VnX_DestroyIPlayerSideTimer_KH");

                                foreach (IPlayer medics in Alt.GetAllPlayers())
                                {
                                    if (medics.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                                    {
                                        medics.SendChatMessage(RageAPI.GetHexColorcode(0,125,0)+ player.GetVnXName<string>() + " hat "+target.GetVnXName<string>() + " aufgesammelt!");
                                        medics.Emit("Destroy_MedicBlips", target.GetVnXName<string>());
                                    }
                                }

                                target.Emit("toggleHandcuffed", true);
                                //target.vnxGetElementData(SetIntoIVehicle(IVehicle, (int)IVehicleSeat.LeftRear);
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du zu weit von " + target.GetVnXName<string>() + " entfernt!");
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du bist in keinem Medic Fahrzeug!");
                        }
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist bei keinem Spieler!");
                }
            }
            catch
            {
            }
        }
            
    }
}