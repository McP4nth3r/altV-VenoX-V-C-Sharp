using System;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using EntityData = VenoX.Core._Globals_.EntityData;
using Inventory = VenoX.Core._Globals_.Inventory.Inventory;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.ServerToClient.VnX;

namespace VenoX.Core._Gamemodes_.Reallife.fun.Aktionen.Kokain
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
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
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
                            Database.UpdateItem(koks);
                            if (koks.Amount == 0)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(koks.Id);
                                Inventory.DatabaseItems.Remove(koks);
                            }
                        }
                        else
                        {
                            _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Soviel Kokain hast du nicht!");
                        }
                    }
                    else
                    {
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Mindestens 1g Koks!");
                    }
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du hast kein Kokain!");
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
