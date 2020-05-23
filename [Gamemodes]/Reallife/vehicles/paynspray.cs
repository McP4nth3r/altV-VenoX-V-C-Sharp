//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Numerics;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class paynspray : IScript
    {
        public static IColShape paynsprayIColShape = Alt.CreateColShapeSphere(new Position(732.712f, -1088.656f, 0f), 2);
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(733.8627f, -1089.26f, 21.77967f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(111.6471f, 6626.1836f, 31.1138f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(1174.6108f, 2641.1277f, 37.0905f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(-1155.225f, -2005.886f, 13.1803f), 72, 0, true);
        }

        public static void OnPlayerEnterIColShape(IColShape forpaynspray, IPlayer player)
        {
            try
            {/*
                if (forpaynspray == paynsprayIColShape)
                {
                    if (player.IsInVehicle && player.VehicleSeat == -1)
                    {
                        int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= 180)
                        {
                            player.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - 180);
                            var paynsprayfahrzeug = player.Vehicle;
                            player.SendTranslatedChatMessage( "~g~Fahrzeug Repariert! [180 $]", true);
                            NAPI.Vehicle.RepairIVehicle(paynsprayfahrzeug);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage( "~r~Du hast nicht genug Geld!", true);
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage( "~r~Du bist in keinem Fahrzeug!", false);
                    }
                }*/
            }
            catch { }
        }
    }
}
