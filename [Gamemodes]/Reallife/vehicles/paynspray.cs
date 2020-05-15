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
using VenoXV.Core;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class paynspray : IScript
    {
        public static IColShape paynsprayIColShape = Alt.CreateColShapeSphere(new Position(732.712f, -1088.656f,0f), 2);
        public static void OnResourceStart()
        {
            BlipModel blip = new BlipModel();
            Position pos = new Position(733.8627f, -1089.26f, 21.77967f);
            blip.Name = "Pay'n'Spray";
            blip.posX = pos.X;
            blip.posY = pos.Y;
            blip.posZ = pos.Z;
            blip.Sprite = 72;
            blip.Color = 0;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);


            BlipModel blip1 = new BlipModel();
            Position pos1 = new Position(111.6471f, 6626.1836f, 31.1138f);
            blip1.Name = "Pay'n'Spray";
            blip1.posX = pos1.X;
            blip1.posY = pos1.Y;
            blip1.posZ = pos1.Z;
            blip1.Sprite = 72;
            blip1.Color = 0;
            blip1.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip1);


            BlipModel blip2 = new BlipModel();
            Position pos2 = new Position(1174.6108f, 2641.1277f, 37.0905f);
            blip2.Name = "Pay'n'Spray";
            blip2.posX = pos2.X;
            blip2.posY = pos2.Y;
            blip2.posZ = pos2.Z;
            blip2.Sprite = 72;
            blip2.Color = 0;
            blip2.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip2);


            BlipModel blip3 = new BlipModel();
            Position pos3 = new Position(-1155.225f, -2005.886f, 13.1803f);
            blip3.Name = "Pay'n'Spray";
            blip3.posX = pos3.X;
            blip3.posY = pos3.Y;
            blip3.posZ = pos3.Z;
            blip3.Sprite = 72;
            blip3.Color = 0;
            blip3.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip3);
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
