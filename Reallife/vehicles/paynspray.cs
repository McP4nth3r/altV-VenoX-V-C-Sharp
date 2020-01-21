//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.Vehicles
{
    public class paynspray : IScript
    {
        public static IColShape paynsprayIColShape = Alt.CreateColShapeSphere(new Position(732.712f, -1088.656f,0f), 2);
        public static void OnResourceStart()
        {
            /*
            // Wir erstellen erstmal die ganzen IColShapes der PaynSprays !
            // LS PaynSpray
            Blip PaynSprayBlip = NAPI.Blip.CreateBlip(new Position(733.8627f, -1089.26f, 21.77967f));
            //PaynSprayBlip.Name = "Pay'n'Spray";
            PaynSprayBlip.Sprite = 72;

            //REPAIR PaletoBay
            Blip PaynSprayBlip1 = NAPI.Blip.CreateBlip(new Position(111.6471f, 6626.1836f, 31.1138f));
            //PaynSprayBlip1.Name = "Pay'n'Spray";
            PaynSprayBlip1.Sprite = 72;

            //REPAIR SANDY SHORES
            Blip PaynSprayBlip2 = NAPI.Blip.CreateBlip(new Position(1174.6108f, 2641.1277f, 37.0905f));
            //PaynSprayBlip2.Name = "Pay'n'Spray";
            PaynSprayBlip2.Sprite = 72;

            //REPAIR FLUGHAFEN
            Blip PaynSprayBlip3 = NAPI.Blip.CreateBlip(new Position(-1155.225f, -2005.886f, 13.1803f));
            //PaynSprayBlip3.Name = "Pay'n'Spray";
            PaynSprayBlip3.Sprite = 72;*/

        }

        public static void OnPlayerEnterIColShape(IColShape forpaynspray, IPlayer player)
        {
            try
            {/*
                if (forpaynspray == paynsprayIColShape)
                {
                    if (player.IsInVehicle && player.VehicleSeat == -1)
                    {
                        int playerMoney = player.vnxGetElementData<int>(EntityData.PLAYER_MONEY);
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) >= 180)
                        {
                            VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, playerMoney - 180);
                            var paynsprayfahrzeug = player.Vehicle;
                            player.SendChatMessage( "~g~Fahrzeug Repariert! [180 $]", true);
                            NAPI.Vehicle.RepairIVehicle(paynsprayfahrzeug);
                        }
                        else
                        {
                            player.SendChatMessage( "~r~Du hast nicht genug Geld!", true);
                        }
                    }
                    else
                    {
                        player.SendChatMessage( "~r~Du bist in keinem Fahrzeug!", false);
                    }
                }*/
            }
            catch { }
        }
    }
}
