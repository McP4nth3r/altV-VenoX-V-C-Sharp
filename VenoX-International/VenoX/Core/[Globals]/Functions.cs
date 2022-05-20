using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Globals_
{
    public class Functions : IScript
    {
        public static bool IstargetInSameLobby(VnXPlayer player, VnXPlayer target)
        {
            try
            {
                if (player.Gamemode == target.Gamemode) return true;
                return false;
            }
            catch { return false; }
        }

        public static VehicleModel CreateVehicle(AltV.Net.Enums.VehicleModel model, Vector3 position, Vector3 rotation, byte[] color1Rgb, byte[] color2Rgb, int dimension)
        {
            IVehicle veh = Alt.CreateVehicle(model, position, rotation);
            veh.PrimaryColorRgb = new Rgba(color1Rgb[0], color1Rgb[1], color1Rgb[2], 255);
            veh.SecondaryColorRgb = new Rgba(color2Rgb[0], color2Rgb[1], color2Rgb[2], 255);
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
        /// <param name="warpPlayerIntoVeh">Should the Owner warped into the IVehicle?</param>
        /// <param name="isRentedIVehicle">Is it a Rented IVehicle?</param>
        /// <param name="job">IVehicle Job?</param>
        /// <param name="numberplateText">Numberlpate of the IVehicle</param>
        public static VehicleModel CreateVehicle(VnXPlayer player, AltV.Net.Enums.VehicleModel vehName, Position coord, float rot, Rgba primaryC, Rgba secondC, bool warpPlayerIntoVeh, bool isRentedIVehicle, string job, string numberplateText)
        {
            try
            {

                VehicleModel createdVehicle = (VehicleModel)Alt.CreateVehicle(vehName, coord, new Rotation(0, 0, rot));
                if (warpPlayerIntoVeh)
                {
                    player.WarpIntoVehicle(createdVehicle, -1);
                }

                createdVehicle.PrimaryColorRgb = new Rgba(primaryC.R, primaryC.G, primaryC.B, 255);
                createdVehicle.SecondaryColorRgb = new Rgba(secondC.R, secondC.G, secondC.B, 255);
                // EntityData Load & Save
                createdVehicle.Owner = player.CharacterUsername;
                createdVehicle.Job = job;

                // KM & Gas load and Safe.
                createdVehicle.Kms = 0;
                createdVehicle.Gas = 100;

                createdVehicle.NotSave = true;
                createdVehicle.NumberplateText = numberplateText;
                createdVehicle.EngineOn = true;
                return createdVehicle;
            }
            catch { return null; }
        }
    }
}
