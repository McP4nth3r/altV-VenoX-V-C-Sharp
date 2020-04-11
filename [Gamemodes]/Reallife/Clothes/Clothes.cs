using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.anzeigen;
using VenoXV.Core;
using VenoXV.Reallife.dxLibary;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Clothes
{
    public class Clothes : IScript
    {
        public static IColShape ClothesShape = Alt.CreateColShapeSphere(new Position(-158.886f, -296.9503f, 39.73328f), 2f);
        //Marker ClothesImInterior = //ToDo Create Marker NAPI.Marker.CreateMarker(0, new Position(-158.886f, -296.9503f, 39.73328f), new Position(0, 0, 0), new Position(0, 0, 0), 1, new Rgba(0, 150, 200), true, 0);
        public static void OnResourceStart()
        {
            BlipModel blip = new BlipModel();
            blip.Name = "Klamottengeschäft";
            blip.posX = -158.886f;
            blip.posY = -296.9503f;
            blip.posZ = 39.73328f;
            blip.Sprite = 73;
            blip.Color = 26;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);
        }


        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == ClothesShape)
                {
                    if(player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1 || player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY_NEUTRAL) == 1)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Geh zuerst Off-Duty!");
                        return;
                    }
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                    player.Position = new Position(-158.886f, -296.9503f, 39.73328f);
                    dxLibary.VnX.SetElementFrozen(player, true);
                    player.Rotation = new Rotation(0f, 0f, 160f);
                    player.vnxSetStreamSharedElementData( "HideHUD", 1);
                    anzeigen.Usefull.VnX.UpdateHUD(player);
                    player.Dimension = dim;
                    player.Emit("showClothesMenu", "Klamottenshop ", 1);
                    dxLibary.VnX.CreateDiscordUpdate(player, "Kauft grad neue Klamotten", "VenoX - Reallife");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("CloseClotheShop")]
        public void CloseClotheShop(IPlayer player)
        {
            try
            {
                player.vnxSetStreamSharedElementData( "HideHUD", 0);
                player.Dimension = 0;
                anzeigen.Usefull.VnX.UpdateHUD(player);
                anzeigen.Usefull.VnX.ResetDiscordData(player);
                 dxLibary.VnX.SetElementFrozen(player, false);
            }
            catch { }
        }
    }
}
