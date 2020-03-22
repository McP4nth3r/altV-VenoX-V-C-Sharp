using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.Core
{

    public class VnX : IScript
    {
        public static object Usefull { get; internal set; }
        public static string PLAYER_MONEY = EntityData.PLAYER_MONEY;
        public static string PLAYER_BANKMONEY = EntityData.PLAYER_BANK;

        public static void vnxSetSharedData(IPlayer player, string e, int v)
        {
            try
            {
                switch(e)
                {
                    case EntityData.PLAYER_MONEY:
                        player.SetData(EntityData.PLAYER_MONEY, v);
                        player.SetSyncedMetaData(EntityData.PLAYER_MONEY, v);
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        break;
                    case EntityData.PLAYER_BANK:
                        player.SetData(EntityData.PLAYER_BANK, v);
                        player.SetSyncedMetaData("PLAYER_BANK_Player", v);
                        break;
                    case EntityData.PLAYER_QUESTS:
                        player.SetData(EntityData.PLAYER_QUESTS, v);
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        break;
                    case EntityData.PLAYER_HUNGER:
                        player.SetData(EntityData.PLAYER_HUNGER, v);
                        player.Emit("UpdateHunger", v);
                        break;
                    default:
                        player.SetData(e, v);
                        player.SetSyncedMetaData(e, v);
                        break;
                }
            }
            catch{}
        }

        public static void SetSharedSettingsData(IPlayer player, string e, string v)
        {
            try
            {
                if (e == "settings_atm" || e == "settings_haus" || e == "settings_tacho" || e == "settings_quest"
                || e == "settings_reporter" || e == "settings_globalchat")
                {
                    player.SetData(e, v);
                    player.SetStreamSyncedMetaData(e, v);
                }
                else
                {
                    player.SetData(e, v);
                    player.SetStreamSyncedMetaData(e, v);
                }
            }
            catch
            {
            }
        }


        public static void UpdateHUDArmorHealth(IPlayer player)
        {
            try
            {
                player.Emit("UpdateHealth", player.Armor, player.Health);
            }
            catch { }
        }


        public static void VehiclevnxSetSharedData(IVehicle Vehicle, string e, float v)
        {
            try
            {
                if (e == "gas")
                {
                    Vehicle.SetData(EntityData.VEHICLE_GAS, v);
                    Vehicle.SetSyncedMetaData("VEHICLE_GAS_CLIENT", v);
                }
                else if (e == "kms")
                {
                    Vehicle.SetData(EntityData.VEHICLE_KMS, v);
                    Vehicle.SetSyncedMetaData("VEHICLE_KMS_CLIENT", v);
                }
                else
                {
                    //Reallife.Core.RageAPI.SendChatMessageToAll(e + " : " + v + ": " + IVehicle.ClassName);
                    Vehicle.SetData(e, v);
                    Vehicle.SetSyncedMetaData(e, v);
                }
            }
            catch
            {
            }
        }
        public static void IVehicleSetSharedINTData(IVehicle Vehicle, string e, int v)
        {
            try
            {
                Vehicle.SetData(e, v);
                Vehicle.SetStreamSyncedMetaData(e, v);
            }
            catch
            {
            }
        }
        public static void IVehicleSetSharedStringData(IVehicle Vehicle, string e, string v)
        {
            try
            {
                Vehicle.SetData(e, v);
                Vehicle.SetStreamSyncedMetaData(e, v);
            }
            catch
            {
            }
        }
        public static void IVehicleSetSharedPositionData(IVehicle Vehicle, string e, Position v)
        {
            try
            {
                Vehicle.SetData(e, v);
                Vehicle.SetStreamSyncedMetaData(e, v);
            }
            catch
            {
            }
        }
        public static void IVehicleSetSharedBoolData(IVehicle Vehicle, string e, bool v)
        {
            try
            {
                Vehicle.SetData(e, v);
                Vehicle.SetData(e, v);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Der Spieler wird Definiert.</param>
        /// <param name="args">[0] = Element Name, [1] = value für die Element Data, [2] Type der Value, [3] = TimeInMS (TimeOut-JS-CS)</param>
        public static void SetDelayedData(IPlayer player, string[] args)
        {
            try
            {
                player.Emit("delay_element_data", args[0], args[1], args[2], args[3]);
            }
            catch { }
        }
        
        public static void SetDelayedBoolSharedData(IPlayer player, string element, bool value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "bool", TimeInMS);
            }
            catch { }
        }
        public static void SetDelayedINTSharedData(IPlayer player, string element, int value, int TimeInMS)
        {
            try
            {
                player.Emit("delay_element_data", element, value, "int", TimeInMS);
            }
            catch { }
        }
        
    }
}
