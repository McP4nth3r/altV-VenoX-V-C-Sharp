using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Clothes
{
    public class Clothes : IScript
    {
        public static ColShapeModel ClothesShape = RageAPI.CreateColShapeSphere(new Position(-158.886f, -296.9503f, 39.73328f), 2f);
        //Marker ClothesImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-158.886f, -296.9503f, 39.73328f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static void OnResourceStart()
        {
            RageAPI.CreateBlip("Name", new Vector3(-158.886f, -296.9503f, 39.73328f), 73, 26, true);
        }


        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == ClothesShape.Entity)
                {
                    if (player.Reallife.OnDuty == 1 || player.Reallife.OnDutyNeutral == 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Geh zuerst Off-Duty!");
                        return;
                    }
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                    player.SetPosition = new Position(-158.886f, -296.9503f, 39.73328f);
                    dxLibary.VnX.SetElementFrozen(player, true);
                    player.Rotation = new Rotation(0f, 0f, 160f);
                    player.vnxSetStreamSharedElementData("HideHUD", 1);
                    player.Dimension = dim;
                    Alt.Server.TriggerClientEvent(player, "showClothesMenu", "Klamottenshop ", 1);
                    dxLibary.VnX.CreateDiscordUpdate(player, "Kauft grad neue Klamotten", "VenoX - Reallife");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("CloseClotheShop")]
        public void CloseClotheShop(Client player)
        {
            try
            {
                player.vnxSetStreamSharedElementData("HideHUD", 0);
                player.Dimension = 0;
                anzeigen.Usefull.VnX.ResetDiscordData(player);
                dxLibary.VnX.SetElementFrozen(player, false);
            }
            catch { }
        }
    }
}
