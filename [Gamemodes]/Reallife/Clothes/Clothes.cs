using AltV.Net;
using AltV.Net.Data;
using System;
using System.Numerics;
using VenoXV._RootCore_;
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


        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != ClothesShape) return false;

                if (player.Reallife.OnDuty == 1 || player.Reallife.OnDutyNeutral == 1)
                {
                    _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Geh zuerst Off-Duty!");
                    return true;
                }
                Random random = new Random();
                int dim = random.Next(1, 9999);
                //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                player.SetPosition = new Position(-158.886f, -296.9503f, 39.73328f);
                dxLibary.VnX.SetElementFrozen(player, true);
                player.Rotation = new Rotation(0f, 0f, 160f);
                player.vnxSetStreamSharedElementData("HideHUD", 1);
                player.Dimension = dim;
                VenoX.TriggerClientEvent(player, "showClothesMenu", "Klamottenshop ", 1);
                return true;
            }
            catch { return false; }
        }

        //[AltV.Net.ClientEvent("CloseClotheShop")]
        public void CloseClotheShop(VnXPlayer player)
        {
            try
            {
                player.vnxSetStreamSharedElementData("HideHUD", 0);
                player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION + player.Language;
                anzeigen.Usefull.VnX.ResetDiscordData(player);
                dxLibary.VnX.SetElementFrozen(player, false);
            }
            catch { }
        }
    }
}
