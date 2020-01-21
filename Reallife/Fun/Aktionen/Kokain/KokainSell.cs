
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Threading.Tasks;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Fun.Aktionen.Kokain
{
    public class KokainSell : IScript
    {
        public static IColShape KokainSell_Col = Alt.CreateColShapeSphere(new Position(140.425f, -239.0754f, 51.52684f), 1.5f);
        public static void OnResourceStart()
        {
            /*
            Blip KokaintruckBlip = NAPI.Blip.CreateBlip(new Position(140.425, -239.0754, 51.52684));
            KokaintruckBlip.Name = "Dealer";
            KokaintruckBlip.ShortRange = true;
            KokaintruckBlip.Sprite = 51;
            KokaintruckBlip.Rgba = 27;*/
        }

        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == KokainSell_Col)
                {
                    dxLibary.VnX.DrawInputWindow(player, "Kokain Dealer", "Hast du etwas Koks für mich?<br>Ich zahle dir pro Gramm 30$....", "Verkaufen");
                }
            }
            catch { }
        }
        public static void SellKokain(IPlayer player, int value)
        {
            try
            {
                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                if(KOKS != null)
                {
                    if(value > 0)
                    {
                        if(value <= KOKS.amount)
                        {
                            int koksverkauf = value * 30;
                            player.SendChatMessage( "Du hast !{0,150,200}" + value + "g !{255, 255,255} Kokain für !{0,150,200}" + koksverkauf + "$ !{255, 255,255}verkauft.");
                            Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + koksverkauf);
                            dxLibary.VnX.DestroyWindow(player, dxLibary.VnX.WINDOW_INPUT);
                            KOKS.amount -= value;
                                // Update the amount into the database
                                Database.UpdateItem(KOKS);
                            if (KOKS.amount == 0)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(KOKS.id);
                                Main.itemList.Remove(KOKS);
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Soviel Kokain hast du nicht!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Mindestens 1g Koks!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast kein Kokain!");
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SellKokain] " + ex.Message);
                Alt.Log("[EXCEPTION SellKokain] " + ex.StackTrace);
            }
        }
    }
}
