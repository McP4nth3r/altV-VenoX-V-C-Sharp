using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Functions : IScript
    {
        public static List<BlipModel> BlipList = new List<BlipModel>();

        public static bool IstargetInSameLobby(IPlayer player, IPlayer target)
        {
            try
            {
                string CurrentPlayerLobby = player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE);
                string CurrenttargetLobby = target.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE);
                if (CurrentPlayerLobby == CurrenttargetLobby)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static IVehicle CreateVehicle(AltV.Net.Enums.VehicleModel model, Vector3 position, Vector3 rotation, byte[] Color1RGB, byte[] Color2RGB, int dimension)
        {
            IVehicle veh = Alt.CreateVehicle(model, position, rotation);
            veh.PrimaryColorRgb = new AltV.Net.Data.Rgba(Color1RGB[0], Color1RGB[1], Color1RGB[2], 255);
            veh.SecondaryColorRgb = new AltV.Net.Data.Rgba(Color2RGB[0], Color2RGB[1], Color2RGB[2], 255);
            veh.Dimension = dimension;
            veh.EngineOn = false;

            return Alt.CreateVehicle(model, position, rotation);
        }

        /// <param name="player">The Owner of the IVehicle.</param>
        /// <param name="vehName">IVehicle Hash ( See GTA Network Wiki )</param>
        /// <param name="coord">Position Where the Car should spawn</param>
        /// <param name="rot">Simple Float of Rotation</param>
        /// <param name="primaryC">Primary Rgba of the IVehicle</param>
        /// <param name="secondC">Secondary Rgba of the IVehicle</param>
        /// <param name="WarpPlayerIntoVeh">Should the Owner warped into the IVehicle?</param>
        /// <param name="isRentedIVehicle">Is it a Rented IVehicle?</param>
        /// <param name="Job">IVehicle Job?</param>
        /// <param name="NumberplateText">Numberlpate of the IVehicle</param>
        public static IVehicle CreateVehicle(IPlayer player, AltV.Net.Enums.VehicleModel vehName, Position coord, float rot, Rgba primaryC, Rgba secondC, bool WarpPlayerIntoVeh, bool isRentedIVehicle, string Job, string NumberplateText)
        {
            try
            {

                IVehicle CreatedVehicle = Alt.CreateVehicle(vehName, coord, new Rotation(0, 0, rot));
                if (WarpPlayerIntoVeh == true)
                {
                    //ToDo : Fix Warp Ped! NAPI.Player.SetPlayerIntoIVehicle(player, CreatedIVehicle, -1); 
                }

                CreatedVehicle.PrimaryColorRgb = new Rgba(primaryC.R, primaryC.G, primaryC.B, 255);
                CreatedVehicle.SecondaryColorRgb = new Rgba(secondC.R, secondC.G, secondC.B, 255);
                // EntityData Load & Save
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_ID, 9999);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_MODEL, CreatedVehicle.Model.ToString());
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_FACTION, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PLATE, "VenoX");
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_OWNER, player.GetVnXName());
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_Rgba_TYPE, _Gamemodes_.Reallife.Globals.Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_FIRST_Rgba, primaryC.R + "," + primaryC.G + "," + primaryC.B);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_SECOND_Rgba, secondC.R + "," + secondC.G + "," + secondC.B);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PRICE, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PARKING, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_PARKED, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_RENTED, isRentedIVehicle);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_JOB, Job);

                // KM & Gas load and Safe.
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_KMS, 0);
                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_GAS, 100);

                CreatedVehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_NOT_SAVED, true);
                CreatedVehicle.NumberplateText = NumberplateText;
                CreatedVehicle.EngineOn = true;
                return CreatedVehicle;
            }
            catch { return null; }
        }
    }
}
