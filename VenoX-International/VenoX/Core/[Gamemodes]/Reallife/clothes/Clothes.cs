using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.clothes
{
    public class Clothes : IScript
    {
        public static ColShapeModel ClothesShape = RageApi.CreateColShapeSphere(new Position(-158.886f, -296.9503f, 39.73328f), 2f);
        //Marker ClothesImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-158.886f, -296.9503f, 39.73328f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Name", new Vector3(-158.886f, -296.9503f, 39.73328f), 73, 26, true);
        }


        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {

                if (shape != ClothesShape) return false;
                if (player.Reallife.OnDuty == 1 || player.Reallife.OnDutyNeutral == 1)
                {
                    Notification.DrawTranslatedNotification(player, Notification.Types.Error, "Get off-duty first!");
                    return true;
                }

                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.SetPosition = new Position(-158.886f, -296.9503f, 39.73328f);
                player.Freeze = true;
                player.Rotation = new Rotation(0f, 0f, 160f);
                player.VnxSetStreamSharedElementData("HideHUD", 1);
                player.Dimension = dim;
                _RootCore_.VenoX.TriggerClientEvent(player, "showClothesMenu", "Klamottenshop ", 1);
                return true;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return false; }
        }

        [VenoXRemoteEvent("CloseClotheShop")]
        public void CloseClotheShop(VnXPlayer player)
        {
            try
            {
                player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                player.Freeze = false;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
