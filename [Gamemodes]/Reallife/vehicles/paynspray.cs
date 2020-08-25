//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class PaynSpray
    {
        public static ColShapeModel PaynSpray_1 = RageAPI.CreateColShapeSphere(new Position(732.712f, -1088.656f, 21.77967f), 2);
        public static ColShapeModel PaynSpray_2 = RageAPI.CreateColShapeSphere(new Position(111.6471f, 6626.1836f, 31.1138f), 2);
        public static ColShapeModel PaynSpray_3 = RageAPI.CreateColShapeSphere(new Position(1174.6108f, 2641.1277f, 37.0905f), 2);
        public static ColShapeModel PaynSpray_4 = RageAPI.CreateColShapeSphere(new Position(-1155.225f, -2005.886f, 13.1803f), 2);

        private static readonly List<ColShapeModel> PaynSprayList = new List<ColShapeModel>
        {
            PaynSpray_1,
            PaynSpray_2,
            PaynSpray_3,
            PaynSpray_4
        };

        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(733.8627f, -1089.26f, 21.77967f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(111.6471f, 6626.1836f, 31.1138f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(1174.6108f, 2641.1277f, 37.0905f), 72, 0, true);
            Core.RageAPI.CreateBlip("Pay'n'Spray", new Vector3(-1155.225f, -2005.886f, 13.1803f), 72, 0, true);
        }

        public static void OnPlayerEnterColShapeModel(IColShape forpaynspray, VnXPlayer player)
        {
            try
            {
                if (PaynSprayList.Contains((ColShapeModel)forpaynspray))
                {
                    if (!player.IsInVehicle) { return; }
                    VehicleModel vehicle = (VehicleModel)player.Vehicle;
                    if (vehicle.NPC) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du kannst kein NPC-Fahrzeug Reparieren!"); return; }
                    int playerMoney = player.Reallife.Money;
                    if (playerMoney >= 180)
                    {
                        player.Reallife.Money -= 180;
                        vehicle.Repair();
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Fahrzeug Repariert! [180 $]");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                    }
                }
                else
                {
                    Core.Debug.OutputDebugString("OnPlayerEnterColShape : " + forpaynspray);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnPlayerEnterColShapeModel", ex); }
        }
    }
}
