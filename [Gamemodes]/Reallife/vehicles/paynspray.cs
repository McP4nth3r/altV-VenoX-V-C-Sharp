//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Notifications_;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class PaynSpray
    {
        public static ColShapeModel PaynSpray1 = RageApi.CreateColShapeSphere(new Position(732.712f, -1088.656f, 21.77967f), 2);
        public static ColShapeModel PaynSpray2 = RageApi.CreateColShapeSphere(new Position(111.6471f, 6626.1836f, 31.1138f), 2);
        public static ColShapeModel PaynSpray3 = RageApi.CreateColShapeSphere(new Position(1174.6108f, 2641.1277f, 37.0905f), 2);
        public static ColShapeModel PaynSpray4 = RageApi.CreateColShapeSphere(new Position(-1155.225f, -2005.886f, 13.1803f), 2);

        private static readonly List<ColShapeModel> PaynSprayList = new List<ColShapeModel>
        {
            PaynSpray1,
            PaynSpray2,
            PaynSpray3,
            PaynSpray4
        };

        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Pay'n'Spray", new Vector3(733.8627f, -1089.26f, 21.77967f), 72, 0, true);
            RageApi.CreateBlip("Pay'n'Spray", new Vector3(111.6471f, 6626.1836f, 31.1138f), 72, 0, true);
            RageApi.CreateBlip("Pay'n'Spray", new Vector3(1174.6108f, 2641.1277f, 37.0905f), 72, 0, true);
            RageApi.CreateBlip("Pay'n'Spray", new Vector3(-1155.225f, -2005.886f, 13.1803f), 72, 0, true);
        }

        public static bool OnPlayerEnterColShapeModel(IColShape forpaynspray, VnXPlayer player)
        {
            try
            {
                if (!PaynSprayList.Contains((ColShapeModel)forpaynspray)) return false;

                if (!player.IsInVehicle) return true;
                if (player.Vehicle.Driver != player) return true;
                VehicleModel vehicle = (VehicleModel)player.Vehicle;
                if (vehicle.Npc) { Main.DrawNotification(player, Main.Types.Info, "Du kannst kein NPC-Fahrzeug Reparieren!"); return true; }
                int playerMoney = player.Reallife.Money;
                if (playerMoney >= 180)
                {
                    player.Reallife.Money -= 180;
                    vehicle.Repair();
                    Main.DrawNotification(player, Main.Types.Info, "Fahrzeug Repariert! [180 $]");
                }
                else Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                return true;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
    }
}
