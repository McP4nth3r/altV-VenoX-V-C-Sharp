
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.Kokain
{
    public class KokainSell : IScript
    {
        public static ColShapeModel KokainSell_Col = RageAPI.CreateColShapeSphere(new Position(140.425f, -239.0754f, 51.52684f), 1.5f);
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("Dealer", new Vector3(140.425f, -239.0754f, 51.52684f), 51, 27, true);
        }

        public static void OnPlayerEnterColShapeModel(IColShape shape, VnXPlayer player)
        {
            try
            {
                if (shape == KokainSell_Col.Entity)
                {
                    dxLibary.VnX.DrawInputWindow(player, "Kokain Dealer", "Hast du etwas Koks für mich?<br>Ich zahle dir pro Gramm 30$....", "Verkaufen");
                }
            }
            catch { }
        }
        public static void SellKokain(VnXPlayer player, int value)
        {
            try
            {
                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.UID, Constants.ITEM_HASH_KOKS);
                if (KOKS != null)
                {
                    if (value > 0)
                    {
                        if (value <= KOKS.amount)
                        {
                            int koksverkauf = value * 30;
                            player.SendTranslatedChatMessage("Du hast " + RageAPI.GetHexColorcode(0, 150, 200) + value + "g " + RageAPI.GetHexColorcode(255, 255, 255) + " Kokain für " + RageAPI.GetHexColorcode(0, 150, 200) + koksverkauf + "$ " + RageAPI.GetHexColorcode(255, 255, 255) + "verkauft.");
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + koksverkauf);
                            dxLibary.VnX.DestroyWindow(player, dxLibary.VnX.WINDOW_INPUT);
                            KOKS.amount -= value;
                            // Update the amount into the database
                            Database.UpdateItem(KOKS);
                            if (KOKS.amount == 0)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(KOKS.id);
                                anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(KOKS);
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
