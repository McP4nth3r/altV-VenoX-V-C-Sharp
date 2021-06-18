
using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.globals;
using EntityData = VenoXV._Globals_.EntityData;
using Inventory = VenoXV._Globals_.Inventory.Inventory;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.Kokain
{
    public class KokainSell : IScript
    {
        public static ColShapeModel KokainSellCol = RageApi.CreateColShapeSphere(new Position(140.425f, -239.0754f, 51.52684f), 1.5f);
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("Dealer", new Vector3(140.425f, -239.0754f, 51.52684f), 51, 27, true);
        }

        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == KokainSellCol)
                {
                    VnX.DrawInputWindow(player, "Kokain Dealer", "Hast du etwas Koks für mich?<br>Ich zahle dir pro Gramm 30$....", "Verkaufen");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
        public static void SellKokain(VnXPlayer player, int value)
        {
            try
            {
                ItemModel koks = Main.GetPlayerItemModelFromHash(player, Constants.ItemHashKoks);
                if (koks != null)
                {
                    if (value > 0)
                    {
                        if (value <= koks.Amount)
                        {
                            int koksverkauf = value * 30;
                            player.SendTranslatedChatMessage("Du hast " + RageApi.GetHexColorcode(0, 150, 200) + value + "g " + RageApi.GetHexColorcode(255, 255, 255) + " Kokain für " + RageApi.GetHexColorcode(0, 150, 200) + koksverkauf + "$ " + RageApi.GetHexColorcode(255, 255, 255) + "verkauft.");
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money + koksverkauf);
                            VnX.DestroyWindow(player, VnX.WindowInput);
                            koks.Amount -= value;
                            // Update the amount into the database
                            Database.Database.UpdateItem(koks);
                            if (koks.Amount == 0)
                            {
                                // Remove the item from the database
                                Database.Database.RemoveItem(koks.Id);
                                Inventory.DatabaseItems.Remove(koks);
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Soviel Kokain hast du nicht!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Mindestens 1g Koks!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast kein Kokain!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SellKokain] " + ex.Message);
                Console.WriteLine("[EXCEPTION SellKokain] " + ex.StackTrace);
            }
        }
    }
}
