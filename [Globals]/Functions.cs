using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Globals_
{
    public class Functions : IScript
    {
        public static bool IstargetInSameLobby(VnXPlayer player, VnXPlayer target)
        {
            try
            {
                if (player.Gamemode == target.Gamemode) return true;
                else return false;
            }
            catch { return false; }
        }

        public static VehicleModel CreateVehicle(AltV.Net.Enums.VehicleModel model, Vector3 position, Vector3 rotation, byte[] Color1RGB, byte[] Color2RGB, int dimension)
        {
            IVehicle veh = Alt.CreateVehicle(model, position, rotation);
            veh.PrimaryColorRgb = new AltV.Net.Data.Rgba(Color1RGB[0], Color1RGB[1], Color1RGB[2], 255);
            veh.SecondaryColorRgb = new AltV.Net.Data.Rgba(Color2RGB[0], Color2RGB[1], Color2RGB[2], 255);
            veh.Dimension = dimension;
            veh.EngineOn = false;

            return (VehicleModel)Alt.CreateVehicle(model, position, rotation);
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
        public static VehicleModel CreateVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel vehName, Position coord, float rot, Rgba primaryC, Rgba secondC, bool WarpPlayerIntoVeh, bool isRentedIVehicle, string Job, string NumberplateText)
        {
            try
            {

                VehicleModel CreatedVehicle = (VehicleModel)Alt.CreateVehicle(vehName, coord, new Rotation(0, 0, rot));
                if (WarpPlayerIntoVeh == true)
                {
                    player.WarpIntoVehicle(CreatedVehicle, -1);
                }

                CreatedVehicle.PrimaryColorRgb = new Rgba(primaryC.R, primaryC.G, primaryC.B, 255);
                CreatedVehicle.SecondaryColorRgb = new Rgba(secondC.R, secondC.G, secondC.B, 255);
                // EntityData Load & Save
                CreatedVehicle.Owner = player.Username;
                CreatedVehicle.Job = Job;

                // KM & Gas load and Safe.
                CreatedVehicle.Kms = 0;
                CreatedVehicle.Gas = 100;

                CreatedVehicle.NotSave = true;
                CreatedVehicle.NumberplateText = NumberplateText;
                CreatedVehicle.EngineOn = true;
                return CreatedVehicle;
            }
            catch { return null; }
        }
    }
}
