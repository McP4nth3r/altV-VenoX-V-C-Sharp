using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Notifications_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.Clothes
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
                Debug.OutputDebugString("-- Entered ColShape 2--");

                if (shape != ClothesShape) return false;

                if (player.Reallife.OnDuty == 1 || player.Reallife.OnDutyNeutral == 1)
                {
                    Main.DrawTranslatedNotification(player, Main.Types.Error, "Geh zuerst Off-Duty!");
                    return true;
                }
                Debug.OutputDebugString("-- Entered ColShape 3--");

                Random random = new Random();
                int dim = random.Next(1, 9999);
                player.SetPosition = new Position(-158.886f, -296.9503f, 39.73328f);
                player.Freeze = true;
                player.Rotation = new Rotation(0f, 0f, 160f);
                player.VnxSetStreamSharedElementData("HideHUD", 1);
                player.Dimension = dim;
                VenoX.TriggerClientEvent(player, "showClothesMenu", "Klamottenshop ", 1);
                return true;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }

        [VenoXRemoteEvent("CloseClotheShop")]
        public void CloseClotheShop(VnXPlayer player)
        {
            try
            {
                player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                player.Freeze = false;
            }
            catch { }
        }
    }
}
